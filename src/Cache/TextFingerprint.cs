using System;
using System.Numerics;

namespace RSTGameTranslation.Cache
{
    /// <summary>
    /// A small black-and-white picture of one OCR'd text line, used to recognise the same text again
    /// without running OCR.
    ///
    /// How it is made from the screen pixels inside the line's box:
    /// 1. shrink the box to Height rows (width keeps the proportions), averaging the pixels of each
    ///    cell into one grey value, so tiny noise and anti-aliasing differences fade out;
    /// 2. split grey values into "ink" and "background" with Otsu's method: it picks the threshold
    ///    that separates the two groups of greys best, so it works for light-on-dark and dark-on-light
    ///    text and for any colours;
    /// 3. keep one bit per cell.
    ///
    /// Two fingerprints match when they have the same size and differ in very few bits overall and
    /// in no small vertical strip (a changed letter or digit is a dense cluster of differing bits,
    /// while background flicker is scattered).
    /// </summary>
    public sealed class TextFingerprint
    {
        public const int Height = 20;
        private const int MaxWidth = 1024;
        // Below this grey range the box holds no readable text
        private const int MinContrast = 40;
        private const double MaxTotalDiff = 0.03;
        private const double MaxStripDiff = 0.12;

        public int Width { get; }
        public ulong[] Bits { get; }

        public TextFingerprint(int width, ulong[] bits)
        {
            Width = width;
            Bits = bits;
        }

        public int BitCount => Width * Height;

        /// <summary>
        /// Fingerprint of the box (x, y, w, h) in a 32-bit BGRA image, or null when the box is
        /// empty, outside the image or has no contrast.
        /// </summary>
        public static TextFingerprint? Compute(ReadOnlySpan<byte> bgra, int imageWidth, int imageHeight, int stride,
                                               int x, int y, int w, int h)
        {
            // Clip to the image
            int x0 = Math.Max(0, x), y0 = Math.Max(0, y);
            int x1 = Math.Min(imageWidth, x + w), y1 = Math.Min(imageHeight, y + h);
            w = x1 - x0;
            h = y1 - y0;
            if (w < 4 || h < 4)
                return null;

            int outW = (int)Math.Round((double)Height * w / h);
            outW = Math.Clamp(outW, 4, Math.Min(MaxWidth, w));

            // 1. average grey per cell (sampling at most 4x4 pixels per cell keeps it cheap)
            var grey = new byte[outW * Height];
            int min = 255, max = 0;
            for (int cy = 0; cy < Height; cy++)
            {
                int sy0 = y0 + cy * h / Height, sy1 = Math.Max(sy0 + 1, y0 + (cy + 1) * h / Height);
                int stepY = Math.Max(1, (sy1 - sy0) / 4);
                for (int cx = 0; cx < outW; cx++)
                {
                    int sx0 = x0 + cx * w / outW, sx1 = Math.Max(sx0 + 1, x0 + (cx + 1) * w / outW);
                    int stepX = Math.Max(1, (sx1 - sx0) / 4);
                    int sum = 0, n = 0;
                    for (int sy = sy0; sy < sy1; sy += stepY)
                    {
                        int row = sy * stride;
                        for (int sx = sx0; sx < sx1; sx += stepX)
                        {
                            int p = row + sx * 4;
                            // BGRA -> luma (integer approximation of 0.114 B + 0.587 G + 0.299 R)
                            sum += (bgra[p] * 29 + bgra[p + 1] * 150 + bgra[p + 2] * 77) >> 8;
                            n++;
                        }
                    }
                    int g = sum / n;
                    grey[cy * outW + cx] = (byte)g;
                    if (g < min) min = g;
                    if (g > max) max = g;
                }
            }
            if (max - min < MinContrast)
                return null;

            // 2. Otsu threshold
            int threshold = Otsu(grey);

            // 3. bits
            var bits = new ulong[(outW * Height + 63) / 64];
            for (int i = 0; i < grey.Length; i++)
            {
                if (grey[i] > threshold)
                    bits[i >> 6] |= 1UL << (i & 63);
            }
            return new TextFingerprint(outW, bits);
        }

        private static int Otsu(byte[] values)
        {
            var hist = new int[256];
            foreach (byte v in values)
                hist[v]++;
            long total = values.Length, sumAll = 0;
            for (int i = 0; i < 256; i++)
                sumAll += (long)i * hist[i];

            long weightBack = 0, sumBack = 0;
            double bestVar = -1;
            int best = 127;
            for (int t = 0; t < 256; t++)
            {
                weightBack += hist[t];
                if (weightBack == 0)
                    continue;
                long weightFore = total - weightBack;
                if (weightFore == 0)
                    break;
                sumBack += (long)t * hist[t];
                double meanBack = (double)sumBack / weightBack;
                double meanFore = (double)(sumAll - sumBack) / weightFore;
                double between = (double)weightBack * weightFore * (meanBack - meanFore) * (meanBack - meanFore);
                if (between > bestVar)
                {
                    bestVar = between;
                    best = t;
                }
            }
            return best;
        }

        public bool Matches(TextFingerprint other)
        {
            if (other.Width != Width)
                return false;

            int total = 0;
            for (int i = 0; i < Bits.Length; i++)
                total += BitOperations.PopCount(Bits[i] ^ other.Bits[i]);
            if (total == 0)
                return true;
            if (total > BitCount * MaxTotalDiff)
                return false;

            // Differing bits per column, then the worst strip of stripWidth columns
            int stripWidth = Math.Max(2, Height / 2);
            var perColumn = new int[Width];
            for (int i = 0; i < Bits.Length; i++)
            {
                ulong diff = Bits[i] ^ other.Bits[i];
                while (diff != 0)
                {
                    int bit = BitOperations.TrailingZeroCount(diff);
                    perColumn[(i * 64 + bit) % Width]++;
                    diff &= diff - 1;
                }
            }
            int window = 0;
            int limit = (int)(stripWidth * Height * MaxStripDiff);
            for (int c = 0; c < Width; c++)
            {
                window += perColumn[c];
                if (c >= stripWidth)
                    window -= perColumn[c - stripWidth];
                if (window > limit)
                    return false;
            }
            return true;
        }

        public string ToBase64() => Convert.ToBase64String(MemoryMarshalBytes());

        private byte[] MemoryMarshalBytes()
        {
            var bytes = new byte[Bits.Length * 8];
            Buffer.BlockCopy(Bits, 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static TextFingerprint FromBase64(int width, string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            var bits = new ulong[(width * Height + 63) / 64];
            Buffer.BlockCopy(bytes, 0, bits, 0, Math.Min(bytes.Length, bits.Length * 8));
            return new TextFingerprint(width, bits);
        }
    }
}
