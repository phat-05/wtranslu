using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>How the game's letters are drawn: bold, italic, and a vertical colour gradient.</summary>
    public sealed class TextShape
    {
        public bool Bold { get; init; }
        public bool Italic { get; init; }
        // Typical stroke width as a fraction of the font size (regular text ~0.08-0.10, bold ~0.13-0.16)
        public double StrokeEm { get; init; }
        // Slant evidence: share of edge strength leaning like italic minus upright / back-leaning share
        public double SlantScore { get; init; }
        // Fill colour at the top and the bottom of the letters when the game fills them with a vertical
        // gradient; null for a plain fill
        public Rgb? GradientTop { get; init; }
        public Rgb? GradientBottom { get; init; }
        // How much of every pixel of the box is the fill colour (row by row), for font matching;
        // dropped (null) once used
        public float[]? Coverage { get; set; }
        public int CoverageWidth { get; init; }
        public int CoverageHeight { get; init; }

        public override string ToString() =>
            $"{(Bold ? "bold" : "regular")} {(Italic ? "italic" : "upright")} stroke={StrokeEm:F3} slant={SlantScore:F2}" +
            (GradientTop != null ? $" gradient={GradientTop}>{GradientBottom}" : "");
    }

    /// <summary>
    /// Reads the shape of a line of game text from its pixels, once its colours are known
    /// (TextColorAnalyzer): how much of each pixel is covered by the fill colour, then
    ///
    /// - BOLD: the typical width of a stroke. Every row of the text is cut into runs of covered pixels
    ///   (a run crosses one stroke); the coverage of a run summed up is the stroke width, with
    ///   sub-pixel precision thanks to anti-aliasing. The median over all runs, divided by the font
    ///   size, is about 0.08-0.10 for regular fonts and 0.13-0.16 for bold ones (measured on 9 font
    ///   families at 12-32 px), so 0.112 tells them apart.
    /// - ITALIC: the direction of the edges of the letters. The upright edges of regular text are
    ///   exactly vertical; italic ones lean by 8-15 degrees. Each edge pixel votes with its gradient
    ///   strength for "upright" (within 3 degrees), "leans right" (5 to 20 degrees) or "leans left";
    ///   italic when the right-leaning votes clearly win.
    /// - GRADIENT: the colour of the core of the letters row by row. A vertical gradient changes it
    ///   steadily from the top of the line to the bottom; words in two colours do not (their rows
    ///   look alike) and neither do two lines in two colours (each line is measured on its own).
    /// </summary>
    public static class TextShapeAnalyzer
    {
        public const double BoldStrokeEm = 0.112;
        public const double ItalicSlantScore = 0.15;
        // Below this font size the letters are too few pixels wide to tell
        public const double MinFontPx = 11;
        private const double MinGradientDistance = 60;

        /// <param name="fontPx">Font size of the text in pixels of this image (0 = unknown: no bold).</param>
        /// <param name="lineCount">Lines of text in the box, for the gradient (measured per line).</param>
        public static TextShape? Analyze(ReadOnlySpan<byte> bgra, int imageWidth, int imageHeight, int stride,
                                         int boxX, int boxY, int boxW, int boxH, TextStyle style, double fontPx, int lineCount = 1)
        {
            int x0 = Math.Max(0, boxX), y0 = Math.Max(0, boxY);
            int x1 = Math.Min(imageWidth, boxX + boxW), y1 = Math.Min(imageHeight, boxY + boxH);
            int w = x1 - x0, h = y1 - y0;
            if (w < 4 || h < 4)
                return null;

            var pixels = new Rgb[w * h];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    int p = (y0 + y) * stride + (x0 + x) * 4;
                    pixels[y * w + x] = new Rgb(bgra[p + 2], bgra[p + 1], bgra[p]);
                }

            Rgb? effect = style.Effect != TextEffectKind.None && !style.EffectAdded ? style.EffectColor : null;
            var (top, bottom) = FindGradient(pixels, w, h, style.Fill, style.Background, effect, Math.Max(1, lineCount));

            // Fill colour of every row: the gradient's colour at that height, else the plain fill
            var rowFill = new Rgb[h];
            for (int y = 0; y < h; y++)
                rowFill[y] = top == null ? style.Fill : GradientAt(top.Value, bottom!.Value, y, h, Math.Max(1, lineCount));

            var coverage = Coverage(pixels, w, h, rowFill, style.Background, effect);
            double strokePx = StrokeWidth(coverage, w, h);
            double strokeEm = fontPx > 0 ? strokePx / fontPx : 0;
            double slant = SlantScore(coverage, w, h, out int edgePixels);

            bool bigEnough = fontPx >= MinFontPx || (fontPx <= 0 && h / (double)Math.Max(1, lineCount) >= MinFontPx * 1.1);
            return new TextShape
            {
                Bold = fontPx >= MinFontPx && strokeEm >= BoldStrokeEm,
                Italic = bigEnough && edgePixels >= 30 && slant >= ItalicSlantScore,
                StrokeEm = strokeEm,
                SlantScore = slant,
                GradientTop = top,
                GradientBottom = bottom,
                Coverage = Array.ConvertAll(coverage, v => (float)v),
                CoverageWidth = w,
                CoverageHeight = h,
            };
        }

        /// <summary>
        /// How much of every pixel is the fill colour (0..1): its position on the way from the
        /// background (and from the outline/shadow colour, when there is one) to the fill colour of its row.
        /// </summary>
        public static double[] Coverage(Rgb[] pixels, int w, int h, Rgb[] rowFill, Rgb background, Rgb? effect)
        {
            var c = new double[w * h];
            for (int y = 0; y < h; y++)
            {
                Rgb fill = rowFill[y];
                for (int x = 0; x < w; x++)
                {
                    var p = pixels[y * w + x];
                    double t = Along(p, background, fill);
                    if (effect != null)
                        t = Math.Min(t, Along(p, effect.Value, fill));
                    c[y * w + x] = Math.Clamp(t, 0, 1);
                }
            }
            return c;
        }

        // Position of p on the line from a (0) to b (1)
        private static double Along(Rgb p, Rgb a, Rgb b)
        {
            double ar = b.R - a.R, ag = b.G - a.G, ab = b.B - a.B;
            double len2 = ar * ar + ag * ag + ab * ab;
            if (len2 < 1)
                return 0;
            return ((p.R - a.R) * ar + (p.G - a.G) * ag + (p.B - a.B) * ab) / len2;
        }

        /// <summary>Median width (pixels) of the horizontal runs of covered pixels, coverage summed.</summary>
        public static double StrokeWidth(double[] coverage, int w, int h)
        {
            var runs = new List<double>();
            for (int y = 0; y < h; y++)
            {
                double sum = 0;
                bool inRun = false;
                for (int x = 0; x < w; x++)
                {
                    double v = coverage[y * w + x];
                    if (v > 0.08)
                    {
                        sum += v;
                        inRun = true;
                    }
                    else if (inRun)
                    {
                        if (sum > 0.5) runs.Add(sum);
                        sum = 0;
                        inRun = false;
                    }
                }
                if (inRun && sum > 0.5)
                    runs.Add(sum);
            }
            if (runs.Count == 0)
                return 0;
            runs.Sort();
            return runs[runs.Count / 2];
        }

        /// <summary>
        /// Italic evidence from the direction of the letter edges (Sobel gradients of the coverage):
        /// share of edge strength leaning right by 5-20 degrees, minus the share leaning left by as
        /// much, minus the share within 3 degrees of upright. Regular text scores below about 0.1,
        /// italic text 0.15-0.6.
        /// </summary>
        public static double SlantScore(double[] c, int w, int h, out int edgePixels)
        {
            double upright = 0, right = 0, left = 0, total = 0;
            edgePixels = 0;
            double maxTan = Math.Tan(30 * Math.PI / 180);
            for (int y = 1; y < h - 1; y++)
                for (int x = 1; x < w - 1; x++)
                {
                    double tl = c[(y - 1) * w + x - 1], tc = c[(y - 1) * w + x], tr = c[(y - 1) * w + x + 1];
                    double ml = c[y * w + x - 1], mr = c[y * w + x + 1];
                    double bl = c[(y + 1) * w + x - 1], bc = c[(y + 1) * w + x], br = c[(y + 1) * w + x + 1];
                    double gx = (tr + 2 * mr + br) - (tl + 2 * ml + bl);
                    double gy = (bl + 2 * bc + br) - (tl + 2 * tc + tr);
                    if (Math.Abs(gx) <= 0.3 || Math.Abs(gy) >= Math.Abs(gx) * maxTan)
                        continue;
                    // Edges leaning right at the top have gy/gx > 0 (y grows downward)
                    double angle = Math.Atan(gy / gx) * 180 / Math.PI;
                    double weight = gx * gx + gy * gy;
                    total += weight;
                    edgePixels++;
                    if (Math.Abs(angle) < 3) upright += weight;
                    else if (angle >= 5 && angle <= 20) right += weight;
                    else if (angle <= -5 && angle >= -20) left += weight;
                }
            return total > 0 ? (right - left - upright) / total : 0;
        }

        /// <summary>
        /// Top and bottom colours of a vertical gradient fill, or (null, null). Per row, the colour of
        /// the core of the letters (the ink pixels farthest from the background); then a straight-line
        /// fit of that colour against the height within the line.
        /// </summary>
        public static (Rgb? Top, Rgb? Bottom) FindGradient(Rgb[] pixels, int w, int h, Rgb fill, Rgb background, Rgb? effect, int lineCount)
        {
            double inkDistance = Math.Max(40, fill.DistanceTo(background) * 0.35);
            var samples = new List<(double Pos, Rgb Colour, int Weight)>();
            double band = h / (double)lineCount;
            for (int line = 0; line < lineCount; line++)
            {
                int top = (int)Math.Round(line * band), bottom = (int)Math.Round((line + 1) * band);
                var rows = new List<(int Y, Rgb Colour, int N)>();
                for (int y = top; y < bottom; y++)
                {
                    var ink = new List<(double D, Rgb P)>();
                    for (int x = 0; x < w; x++)
                    {
                        var p = pixels[y * w + x];
                        double d = p.DistanceTo(background);
                        if (d <= inkDistance)
                            continue;
                        if (effect != null && p.DistanceTo(effect.Value) < p.DistanceTo(fill) * 0.8)
                            continue;
                        ink.Add((d, p));
                    }
                    if (ink.Count < 3)
                        continue;
                    // Core of the letters: the 40% of ink farthest from the background (no blended edges)
                    var core = ink.OrderByDescending(i => i.D).Take(Math.Max(2, ink.Count * 2 / 5)).Select(i => i.P).ToList();
                    rows.Add((y, Mean(core), core.Count));
                }
                if (rows.Count < 4)
                    continue;
                int inkTop = rows.First().Y, inkBottom = rows.Last().Y;
                if (inkBottom - inkTop < 4)
                    continue;
                foreach (var r in rows)
                    samples.Add(((r.Y - inkTop) / (double)(inkBottom - inkTop), r.Colour, r.N));
            }
            if (samples.Count < 6)
                return (null, null);

            // Weighted straight-line fit per channel: colour = a + b * pos (pos 0 = top, 1 = bottom of the ink)
            double sw = samples.Sum(s => s.Weight);
            double mp = samples.Sum(s => s.Pos * s.Weight) / sw;
            double vp = samples.Sum(s => s.Weight * (s.Pos - mp) * (s.Pos - mp));
            if (vp <= 0)
                return (null, null);
            var fitTop = new double[3];
            var fitBottom = new double[3];
            double explained = 0, totalVar = 0;
            for (int ch = 0; ch < 3; ch++)
            {
                Func<Rgb, double> get = ch == 0 ? (c => c.R) : ch == 1 ? (c => c.G) : (c => c.B);
                double mc = samples.Sum(s => get(s.Colour) * s.Weight) / sw;
                double cov = samples.Sum(s => s.Weight * (s.Pos - mp) * (get(s.Colour) - mc));
                double slope = cov / vp;
                double intercept = mc - slope * mp;
                fitTop[ch] = intercept;
                fitBottom[ch] = intercept + slope;
                explained += slope * slope * vp;
                totalVar += samples.Sum(s => s.Weight * (get(s.Colour) - mc) * (get(s.Colour) - mc));
            }
            var topColour = ToRgb(fitTop);
            var bottomColour = ToRgb(fitBottom);
            double r2 = totalVar > 0 ? explained / totalVar : 0;
            if (topColour.DistanceTo(bottomColour) < MinGradientDistance || r2 < 0.6)
                return (null, null);
            return (topColour, bottomColour);
        }

        // Fill colour at row y of a box of height h holding lineCount lines, each with the gradient
        // from the top (0.15 of the line) to the bottom (0.85) of its letters
        private static Rgb GradientAt(Rgb top, Rgb bottom, int y, int h, int lineCount)
        {
            double band = h / (double)lineCount;
            double pos = (y % band) / band;
            double t = Math.Clamp((pos - 0.15) / 0.7, 0, 1);
            return new Rgb((byte)Math.Round(top.R + (bottom.R - top.R) * t),
                           (byte)Math.Round(top.G + (bottom.G - top.G) * t),
                           (byte)Math.Round(top.B + (bottom.B - top.B) * t));
        }

        private static Rgb ToRgb(double[] c) =>
            new Rgb((byte)Math.Clamp(Math.Round(c[0]), 0, 255), (byte)Math.Clamp(Math.Round(c[1]), 0, 255), (byte)Math.Clamp(Math.Round(c[2]), 0, 255));

        private static Rgb Mean(List<Rgb> pixels)
        {
            double r = 0, g = 0, b = 0;
            foreach (var p in pixels) { r += p.R; g += p.G; b += p.B; }
            int n = Math.Max(1, pixels.Count);
            return new Rgb((byte)Math.Round(r / n), (byte)Math.Round(g / n), (byte)Math.Round(b / n));
        }
    }
}
