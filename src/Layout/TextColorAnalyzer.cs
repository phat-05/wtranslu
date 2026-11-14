using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    public readonly record struct Rgb(byte R, byte G, byte B)
    {
        public double DistanceTo(Rgb o)
        {
            int dr = R - o.R, dg = G - o.G, db = B - o.B;
            return Math.Sqrt(dr * dr + dg * dg + db * db);
        }

        /// <summary>WCAG relative luminance, 0 (black) to 1 (white).</summary>
        public double Luminance
        {
            get
            {
                static double C(byte v)
                {
                    double s = v / 255.0;
                    return s <= 0.03928 ? s / 12.92 : Math.Pow((s + 0.055) / 1.055, 2.4);
                }
                return 0.2126 * C(R) + 0.7152 * C(G) + 0.0722 * C(B);
            }
        }

        /// <summary>WCAG contrast ratio, 1 (same) to 21 (black on white).</summary>
        public double ContrastWith(Rgb o)
        {
            double a = Luminance, b = o.Luminance;
            return (Math.Max(a, b) + 0.05) / (Math.Min(a, b) + 0.05);
        }

        public override string ToString() => $"#{R:X2}{G:X2}{B:X2}";
    }

    public enum TextEffectKind { None, Outline, Shadow }

    /// <summary>What the game's text looks like: fill colour, background, and an outline or a drop shadow.</summary>
    public sealed class TextStyle
    {
        public Rgb Background { get; init; }
        public Rgb Fill { get; init; }
        public TextEffectKind Effect { get; init; }
        public Rgb EffectColor { get; init; }
        // Shadow offset in pixels (right / down positive)
        public double ShadowDx { get; init; }
        public double ShadowDy { get; init; }
        // True when the game's text had no outline but its colour is too close to the background to read
        // without one, so an outline was added
        public bool EffectAdded { get; init; }
    }

    /// <summary>
    /// Reads the colours of a line of game text from the screen pixels around and inside its box.
    ///
    /// 1. Background: the most common colour in a thin ring just outside the box.
    /// 2. Ink: pixels inside the box clearly different from the background.
    /// 3. The ink is split into its two main colours (k-means with k = 2: start with two far-apart
    ///    colours, then repeat "assign every pixel to the nearer colour, move each colour to the mean
    ///    of its pixels").
    /// 4. If both colours are substantial, where their pixels sit tells what they are:
    ///    - an OUTLINE surrounds the fill, so fill pixels are mostly enclosed by other ink pixels and
    ///      the two groups have the same centre;
    ///    - a SHADOW is a copy of the text shifted by a few pixels, so its centre is offset;
    ///    - otherwise the line simply has words in two colours (handled per word elsewhere): the fill
    ///      is the colour of most of the text.
    /// The original fill colour is kept even when its contrast is low (games often use pale or
    /// tinted text); only when it would be unreadable without help is an outline added.
    /// </summary>
    public static class TextColorAnalyzer
    {
        private const double MinInkDistance = 40;
        private const double InkContrastShare = 0.35;
        private const double MinInkShare = 0.03;
        private const double MinClusterDistance = 70;
        private const double MinClusterShare = 0.12;
        private const double ReadableContrast = 2.0;

        public static TextStyle? Analyze(ReadOnlySpan<byte> bgra, int imageWidth, int imageHeight, int stride,
                                         int boxX, int boxY, int boxW, int boxH)
        {
            int x0 = Math.Max(0, boxX), y0 = Math.Max(0, boxY);
            int x1 = Math.Min(imageWidth, boxX + boxW), y1 = Math.Min(imageHeight, boxY + boxH);
            if (x1 - x0 < 3 || y1 - y0 < 3)
                return null;

            // 1. background from the ring around the box
            int margin = Math.Clamp(Math.Min(x1 - x0, y1 - y0) / 4, 3, 12);
            int rx0 = Math.Max(0, x0 - margin), ry0 = Math.Max(0, y0 - margin);
            int rx1 = Math.Min(imageWidth, x1 + margin), ry1 = Math.Min(imageHeight, y1 + margin);
            var ring = new List<Rgb>();
            for (int y = ry0; y < ry1; y++)
                for (int x = rx0; x < rx1; x++)
                    if (x < x0 || x >= x1 || y < y0 || y >= y1)
                        ring.Add(Pixel(bgra, stride, x, y));

            int w = x1 - x0, h = y1 - y0;
            var inside = new Rgb[w * h];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                    inside[y * w + x] = Pixel(bgra, stride, x0 + x, y0 + y);

            Rgb background = Dominant(ring.Count > 0 ? ring : inside.ToList());

            // 2. ink: far enough from the background (threshold adapts to the strongest contrast)
            var distances = inside.Select(p => p.DistanceTo(background)).ToArray();
            double strongest = distances.OrderBy(d => d).ElementAt((int)((distances.Length - 1) * 0.98));
            double threshold = Math.Max(MinInkDistance, strongest * InkContrastShare);
            var isInk = distances.Select(d => d > threshold).ToArray();
            int inkCount = isInk.Count(v => v);
            if (inkCount < inside.Length * MinInkShare)
                return new TextStyle { Background = background, Fill = ReadableOn(background), Effect = TextEffectKind.None };

            var ink = new List<int>(inkCount);
            for (int i = 0; i < isInk.Length; i++)
                if (isInk[i]) ink.Add(i);

            // 3. two main ink colours
            var (a, b, label) = TwoMeans(inside, ink);
            int countA = label.Count(l => l == 0), countB = ink.Count - countA;

            Rgb fill;
            TextEffectKind effect = TextEffectKind.None;
            Rgb effectColor = default;
            double dx = 0, dy = 0;

            bool twoColours = a.DistanceTo(b) >= MinClusterDistance &&
                              Math.Min(countA, countB) >= ink.Count * MinClusterShare;
            if (!twoColours)
            {
                fill = countA >= countB ? a : b;
            }
            else
            {
                // 4. how enclosed each group is, and where its centre lies
                var stats = new (double Enclosed, double Cx, double Cy, int N)[2];
                for (int k = 0; k < ink.Count; k++)
                {
                    int i = ink[k], x = i % w, y = i / w, g = label[k];
                    bool enclosed = IsInkAt(isInk, w, h, x - 1, y) && IsInkAt(isInk, w, h, x + 1, y) &&
                                    IsInkAt(isInk, w, h, x, y - 1) && IsInkAt(isInk, w, h, x, y + 1);
                    stats[g].Enclosed += enclosed ? 1 : 0;
                    stats[g].Cx += x;
                    stats[g].Cy += y;
                    stats[g].N++;
                }
                for (int g = 0; g < 2; g++)
                {
                    stats[g].Enclosed /= stats[g].N;
                    stats[g].Cx /= stats[g].N;
                    stats[g].Cy /= stats[g].N;
                }

                double offX = stats[1].Cx - stats[0].Cx, offY = stats[1].Cy - stats[0].Cy;
                double offset = Math.Sqrt(offX * offX + offY * offY);
                double maxEffectOffset = Math.Max(3, h * 0.15);
                int fillIdx, effectIdx;

                if (Math.Abs(stats[0].Enclosed - stats[1].Enclosed) > 0.25 && offset <= maxEffectOffset)
                {
                    // Outline: the fill is the group enclosed by ink
                    fillIdx = stats[0].Enclosed > stats[1].Enclosed ? 0 : 1;
                    effectIdx = 1 - fillIdx;
                    effect = TextEffectKind.Outline;
                }
                else if (offset > 0.6 && offset <= maxEffectOffset)
                {
                    // Shadow: the shifted copy; the fill is the brighter-contrasting, on-top group
                    // (the shadow is partly hidden behind the fill, so it is usually the smaller one)
                    fillIdx = countA >= countB ? 0 : 1;
                    effectIdx = 1 - fillIdx;
                    effect = TextEffectKind.Shadow;
                    double sx = fillIdx == 0 ? offX : -offX, sy = fillIdx == 0 ? offY : -offY;
                    // The centroid shift of a partly hidden shadow is about half the real offset
                    dx = Math.Clamp(sx * 2, -4, 4);
                    dy = Math.Clamp(sy * 2, -4, 4);
                }
                else
                {
                    // Words in two colours: the colour of most of the text
                    fillIdx = countA >= countB ? 0 : 1;
                    effectIdx = -1;
                }
                fill = fillIdx == 0 ? a : b;
                if (effectIdx >= 0)
                    effectColor = effectIdx == 0 ? a : b;
            }

            // A dark shadow on a dark background is too close to the background to count as ink:
            // look for it by shifting the fill's shape (see FindShadow)
            if (effect == TextEffectKind.None)
            {
                var shadow = FindShadow(inside, w, h, fill, background);
                if (shadow != null)
                {
                    effect = TextEffectKind.Shadow;
                    effectColor = shadow.Value.Colour;
                    dx = shadow.Value.Dx;
                    dy = shadow.Value.Dy;
                }
            }

            // Keep the game's colour; add an outline only when the text would be unreadable
            bool added = false;
            if (effect == TextEffectKind.None && fill.ContrastWith(background) < ReadableContrast)
            {
                effect = TextEffectKind.Outline;
                effectColor = fill.Luminance > 0.4 ? new Rgb(0, 0, 0) : new Rgb(255, 255, 255);
                added = true;
            }

            return new TextStyle
            {
                Background = background,
                Fill = fill,
                Effect = effect,
                EffectColor = effectColor,
                ShadowDx = dx,
                ShadowDy = dy,
                EffectAdded = added,
            };
        }

        /// <summary>
        /// Main ink colour of one word: the most common colour among the pixels of its box that are
        /// clearly different from the line's background and from its outline/shadow colour.
        /// Null when the box holds too little ink to tell.
        /// </summary>
        public static Rgb? InkColor(ReadOnlySpan<byte> bgra, int imageWidth, int imageHeight, int stride,
                                    int boxX, int boxY, int boxW, int boxH, Rgb background, Rgb? effectColor)
        {
            int x0 = Math.Max(0, boxX), y0 = Math.Max(0, boxY);
            int x1 = Math.Min(imageWidth, boxX + boxW), y1 = Math.Min(imageHeight, boxY + boxH);
            if (x1 - x0 < 2 || y1 - y0 < 2)
                return null;
            var ink = new List<Rgb>();
            int total = 0;
            for (int y = y0; y < y1; y++)
                for (int x = x0; x < x1; x++)
                {
                    total++;
                    var p = Pixel(bgra, stride, x, y);
                    if (p.DistanceTo(background) <= 60)
                        continue;
                    if (effectColor != null && p.DistanceTo(effectColor.Value) <= 50)
                        continue;
                    ink.Add(p);
                }
            if (ink.Count < Math.Max(4, total * 0.02))
                return null;
            return Dominant(ink);
        }

        /// <summary>
        /// A drop shadow is the text's shape repeated a few pixels down/right in a darker colour. For
        /// each candidate offset, look at the pixels where the shifted fill lands outside the fill:
        /// with a shadow they are consistently darker than the background, while on the opposite side
        /// (shifted the other way) they are plain background.
        /// </summary>
        private static (Rgb Colour, double Dx, double Dy)? FindShadow(Rgb[] pixels, int w, int h, Rgb fill, Rgb bg)
        {
            var isFill = pixels.Select(p => p.DistanceTo(fill) < Math.Max(40, fill.DistanceTo(bg) * 0.4)).ToArray();
            if (isFill.Count(v => v) < pixels.Length * MinInkShare)
                return null;
            double bgLum = bg.Luminance;

            (Rgb, double, double)? best = null;
            double bestScore = 0;
            int[][] offsets = { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 }, new[] { 2, 1 }, new[] { 1, 2 },
                                new[] { 3, 2 }, new[] { 2, 3 }, new[] { 0, 2 }, new[] { 2, 0 }, new[] { 4, 4 } };
            foreach (var o in offsets)
            {
                var (darkShare, colour) = ShiftedDarkness(pixels, isFill, w, h, o[0], o[1], bgLum);
                var (oppositeShare, _) = ShiftedDarkness(pixels, isFill, w, h, -o[0], -o[1], bgLum);
                double score = darkShare - oppositeShare;
                if (darkShare >= 0.6 && oppositeShare <= 0.3 && score > bestScore)
                {
                    bestScore = score;
                    best = (colour, o[0], o[1]);
                }
            }
            return best;
        }

        // Share of the pixels "fill shifted by (dx, dy), outside the fill" that are clearly darker than
        // the background, and their mean colour
        private static (double Share, Rgb Colour) ShiftedDarkness(Rgb[] pixels, bool[] isFill, int w, int h, int dx, int dy, double bgLum)
        {
            int total = 0, dark = 0;
            double r = 0, g = 0, b = 0;
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    int sx = x - dx, sy = y - dy;
                    if (sx < 0 || sy < 0 || sx >= w || sy >= h || !isFill[sy * w + sx] || isFill[y * w + x])
                        continue;
                    total++;
                    var p = pixels[y * w + x];
                    if (p.Luminance < bgLum * 0.6 - 0.005)
                    {
                        dark++;
                        r += p.R; g += p.G; b += p.B;
                    }
                }
            if (total < 20 || dark == 0)
                return (0, default);
            return ((double)dark / total, new Rgb((byte)(r / dark), (byte)(g / dark), (byte)(b / dark)));
        }

        private static bool IsInkAt(bool[] isInk, int w, int h, int x, int y) =>
            x >= 0 && y >= 0 && x < w && y < h && isInk[y * w + x];

        private static Rgb Pixel(ReadOnlySpan<byte> bgra, int stride, int x, int y)
        {
            int p = y * stride + x * 4;
            return new Rgb(bgra[p + 2], bgra[p + 1], bgra[p]);
        }

        private static Rgb ReadableOn(Rgb bg) =>
            new Rgb(0, 0, 0).ContrastWith(bg) >= new Rgb(255, 255, 255).ContrastWith(bg) ? new Rgb(0, 0, 0) : new Rgb(255, 255, 255);

        // Most common colour (coarse bins), refined as the mean of the pixels close to it
        private static Rgb Dominant(List<Rgb> pixels)
        {
            if (pixels.Count == 0)
                return new Rgb(0, 0, 0);
            var mode = pixels.GroupBy(p => (p.R >> 4, p.G >> 4, p.B >> 4)).MaxBy(g => g.Count())!;
            var seed = Mean(mode.ToList());
            var close = pixels.Where(p => p.DistanceTo(seed) <= 40).ToList();
            return Mean(close.Count > 0 ? close : mode.ToList());
        }

        private static Rgb Mean(IReadOnlyCollection<Rgb> pixels)
        {
            double r = 0, g = 0, b = 0;
            foreach (var p in pixels) { r += p.R; g += p.G; b += p.B; }
            int n = Math.Max(1, pixels.Count);
            return new Rgb((byte)Math.Round(r / n), (byte)Math.Round(g / n), (byte)Math.Round(b / n));
        }

        // k-means with k = 2 over the ink pixels; returns both colours and each pixel's group
        private static (Rgb A, Rgb B, int[] Label) TwoMeans(Rgb[] pixels, List<int> ink)
        {
            // Start from the ink pixel most unlike the average, and the one most unlike that
            var all = ink.Select(i => pixels[i]).ToList();
            var mean = Mean(all);
            Rgb a = all.MaxBy(p => p.DistanceTo(mean));
            Rgb b = all.MaxBy(p => p.DistanceTo(a));
            var label = new int[ink.Count];
            for (int iter = 0; iter < 8; iter++)
            {
                double ar = 0, ag = 0, ab = 0, br = 0, bg = 0, bb = 0;
                int na = 0, nb = 0;
                for (int k = 0; k < all.Count; k++)
                {
                    var p = all[k];
                    bool toA = p.DistanceTo(a) <= p.DistanceTo(b);
                    label[k] = toA ? 0 : 1;
                    if (toA) { ar += p.R; ag += p.G; ab += p.B; na++; }
                    else { br += p.R; bg += p.G; bb += p.B; nb++; }
                }
                if (na > 0) a = new Rgb((byte)(ar / na), (byte)(ag / na), (byte)(ab / na));
                if (nb > 0) b = new Rgb((byte)(br / nb), (byte)(bg / nb), (byte)(bb / nb));
            }
            return (a, b, label);
        }
    }
}
