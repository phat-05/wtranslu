using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using Color = System.Drawing.Color;
using MediaColor = System.Windows.Media.Color;

namespace RSTGameTranslation
{
    public static class ColorUtils
    {
        // Pixels within this RGB distance of the background count as background, not text
        private const double TextDistanceFromBackground = 60;
        // Pixels within this distance of the dominant color are averaged into it
        private const double SameColorDistance = 40;
        // Below this share of the text box, "text" pixels are noise and the original text color is unknown
        private const double MinTextPixelShare = 0.03;
        // WCAG minimum contrast for normal text
        private const double MinTextContrast = 4.5;

        /// <summary>
        /// Picks overlay colors that blend with the original: the background comes from a ring just
        /// outside the text box (inside it, dense or bold glyphs can outnumber the background), and the
        /// text keeps the original ink color when it contrasts enough, otherwise black or white.
        /// </summary>
        public static (MediaColor Background, MediaColor Text) SampleOverlayColors(Bitmap bitmap, Rectangle textBox)
        {
            var image = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            int margin = Math.Clamp(Math.Min(textBox.Width, textBox.Height) / 4, 3, 12);
            Rectangle area = Rectangle.Intersect(Rectangle.Inflate(textBox, margin, margin), image);
            Rectangle inner = Rectangle.Intersect(textBox, image);
            if (area.Width <= 0 || area.Height <= 0)
                return (Colors.Black, Colors.White);

            var ring = new List<Color>();
            var inside = new List<Color>();
            var data = bitmap.LockBits(area, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            try
            {
                byte[] row = new byte[Math.Abs(data.Stride)];
                for (int y = 0; y < area.Height; y++)
                {
                    System.Runtime.InteropServices.Marshal.Copy(data.Scan0 + y * data.Stride, row, 0, row.Length);
                    for (int x = 0; x < area.Width; x++)
                    {
                        var pixel = Color.FromArgb(row[x * 3 + 2], row[x * 3 + 1], row[x * 3]); // BGR
                        if (inner.Contains(area.X + x, area.Y + y))
                            inside.Add(pixel);
                        else
                            ring.Add(pixel);
                    }
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }

            // A box touching the image edge on all sides has no ring; fall back to its own pixels
            Color background = DominantColor(ring.Count > 0 ? ring : inside);

            var ink = inside.Where(p => Distance(p, background) > TextDistanceFromBackground).ToList();
            MediaColor backgroundColor = MediaColor.FromRgb(background.R, background.G, background.B);
            if (ink.Count >= inside.Count * MinTextPixelShare)
            {
                Color original = DominantColor(ink);
                MediaColor originalText = MediaColor.FromRgb(original.R, original.G, original.B);
                if (ContrastRatio(originalText, backgroundColor) >= MinTextContrast)
                    return (backgroundColor, originalText);
            }

            return (backgroundColor, ContrastRatio(Colors.Black, backgroundColor) >= ContrastRatio(Colors.White, backgroundColor)
                ? Colors.Black
                : Colors.White);
        }

        // Most common color (coarsely binned), refined as the average of all pixels close to it
        private static Color DominantColor(List<Color> pixels)
        {
            if (pixels.Count == 0)
                return Color.Black;

            var mode = pixels
                .GroupBy(p => (p.R >> 4, p.G >> 4, p.B >> 4))
                .OrderByDescending(g => g.Count())
                .First();
            var seed = Color.FromArgb((int)mode.Average(p => p.R), (int)mode.Average(p => p.G), (int)mode.Average(p => p.B));

            var close = pixels.Where(p => Distance(p, seed) <= SameColorDistance).ToList();
            return Color.FromArgb((int)close.Average(p => p.R), (int)close.Average(p => p.G), (int)close.Average(p => p.B));
        }

        private static double Distance(Color a, Color b)
        {
            int dr = a.R - b.R, dg = a.G - b.G, db = a.B - b.B;
            return Math.Sqrt(dr * dr + dg * dg + db * db);
        }

        // WCAG contrast ratio, 1 (same) to 21 (black on white)
        private static double ContrastRatio(MediaColor a, MediaColor b)
        {
            double la = RelativeLuminance(a), lb = RelativeLuminance(b);
            return (Math.Max(la, lb) + 0.05) / (Math.Min(la, lb) + 0.05);
        }

        private static double RelativeLuminance(MediaColor c)
        {
            static double Channel(byte v)
            {
                double s = v / 255.0;
                return s <= 0.03928 ? s / 12.92 : Math.Pow((s + 0.055) / 1.055, 2.4);
            }
            return 0.2126 * Channel(c.R) + 0.7152 * Channel(c.G) + 0.0722 * Channel(c.B);
        }

        /// <summary>
        /// Fill colour, background and outline/shadow of the game text in the box (see
        /// Layout.TextColorAnalyzer). Null when the box is unusable.
        /// </summary>
        /// <param name="fontPx">The game's font size in bitmap pixels (0 = unknown), for bold detection.</param>
        /// <param name="lineCount">Lines of text in the box, for gradient detection.</param>
        /// <param name="text">OCR text of the box: with one line, its font size is measured on the letters.</param>
        public static RSTGameTranslation.Layout.TextStyle? AnalyzeTextStyle(Bitmap bitmap, Rectangle textBox, double fontPx = 0, int lineCount = 1, string? text = null)
        {
            var image = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            int margin = Math.Clamp(Math.Min(textBox.Width, textBox.Height) / 4, 3, 12);
            Rectangle area = Rectangle.Intersect(Rectangle.Inflate(textBox, margin, margin), image);
            if (area.Width <= 0 || area.Height <= 0)
                return null;

            byte[] pixels = CopyRegion(bitmap, area, out int stride);
            // Box position relative to the copied area
            var style = RSTGameTranslation.Layout.TextColorAnalyzer.Analyze(pixels, area.Width, area.Height, stride,
                textBox.X - area.X, textBox.Y - area.Y, textBox.Width, textBox.Height);
            if (style != null)
            {
                // Bold, italic and gradient fill, read from the same pixels
                style.Shape = RSTGameTranslation.Layout.TextShapeAnalyzer.Analyze(pixels, area.Width, area.Height, stride,
                    textBox.X - area.X, textBox.Y - area.Y, textBox.Width, textBox.Height, style, fontPx, lineCount, text);
            }
            return style;
        }

        /// <summary>
        /// Copies the pixels of <paramref name="area"/> as 32-bit BGRA, row after row, into a compact
        /// buffer (stride = area width * 4).
        ///
        /// Row by row on purpose: when the bitmap already is 32-bit, LockBits on a part of it returns a
        /// pointer into the bitmap itself whose rows are the full image width apart. Copying
        /// "stride * height" bytes from there reads past the end of the image for an area at the bottom
        /// edge (by its X offset * 4 bytes) and crashed the process (0xc0000005 in coreclr) on
        /// HUD text in the bottom-right corner of a game.
        /// </summary>
        public static byte[] CopyRegion(Bitmap bitmap, Rectangle area, out int stride)
        {
            stride = area.Width * 4;
            var pixels = new byte[stride * area.Height];
            var data = bitmap.LockBits(area, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try
            {
                for (int y = 0; y < area.Height; y++)
                {
                    System.Runtime.InteropServices.Marshal.Copy(data.Scan0 + y * data.Stride, pixels, y * stride, stride);
                }
            }
            finally
            {
                bitmap.UnlockBits(data);
            }
            return pixels;
        }

        public static MediaColor ToMediaColor(this RSTGameTranslation.Layout.Rgb c) => MediaColor.FromRgb(c.R, c.G, c.B);

        /// <summary>
        /// Determines if a color is light or dark
        /// </summary>
        public static bool IsLightColor(Color color)
        {
            // Calculate perceived brightness using the formula:
            // (0.299*R + 0.587*G + 0.114*B)
            double brightness = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            return brightness > 0.5;
        }

        /// <summary>
        /// Converts System.Drawing.Color to System.Windows.Media.Color
        /// </summary>
        public static MediaColor ToMediaColor(this Color color)
        {
            return MediaColor.FromArgb(color.A, color.R, color.G, color.B);
        }

    }
}