using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>How far one candidate font's rendering of the text is from the game's letters.</summary>
    /// <param name="AspectLog">ln(candidate ink aspect / game ink aspect): above 0 when the candidate
    /// draws the text wider than the game.</param>
    public sealed record FontDistance(string Font, double Shape, double Aspect, double Contrast, double AspectLog = 0)
    {
        // Weights tuned on 14 game fonts x 6 texts x 3 sizes against Liberation Sans/Serif/Mono
        // (91% of single lines got the right kind of font: serif, sans or monospace)
        public double Total => Shape + 0.5 * Aspect + 2 * Contrast;
    }

    /// <summary>
    /// Picks, among fonts the overlay can use, the one that looks most like the game's font, by
    /// comparing the game's letters with the same text drawn in each candidate (drawn by the caller,
    /// at the game's font size, bold/italic like the game). Three measures, all independent of where
    /// exactly the text sits and of small errors in the estimated font size:
    ///
    /// - Shape: both inks cropped to their bounds, scaled to the same 24-pixel-high box, slightly
    ///   blurred, then the mean pixel difference (relative to the amount of ink).
    /// - Aspect: width / height of the ink. The same words are much narrower in a condensed font and
    ///   wider in a monospaced one.
    /// - Contrast: thickness of horizontal strokes / thickness of vertical stems. Serif fonts have thin
    ///   horizontals (about 0.4-0.6 of a stem), sans fonts nearly even strokes (about 0.8-1.0); this is
    ///   what tells serif text apart once shapes are blurred.
    /// </summary>
    public static class FontMatcher
    {
        private const int CompareHeight = 24;
        private const double InkThreshold = 0.25;

        /// <summary>Coverage map (0..1 per pixel, row by row) of a piece of text.</summary>
        public readonly record struct Ink(float[] Coverage, int Width, int Height);

        public static FontDistance Compare(string font, Ink game, Ink candidate)
        {
            var g = Crop(game);
            var c = Crop(candidate);
            if (g.Width < 2 || g.Height < 2 || c.Width < 2 || c.Height < 2)
                return new FontDistance(font, 9, 9, 9);
            double aspectGame = g.Width / (double)g.Height, aspectCandidate = c.Width / (double)c.Height;
            int w = Math.Max(8, (int)Math.Round(CompareHeight * aspectGame));
            var gs = Blur(Resample(g, w, CompareHeight), w, CompareHeight);
            var cs = Blur(Resample(c, w, CompareHeight), w, CompareHeight);
            double diff = 0, inkG = 0, inkC = 0;
            for (int i = 0; i < gs.Length; i++)
            {
                diff += Math.Abs(gs[i] - cs[i]);
                inkG += gs[i];
                inkC += cs[i];
            }
            double shape = diff / Math.Max(1e-6, (inkG + inkC) / 2);
            double aspectLog = Math.Log(aspectCandidate / aspectGame);
            double contrast = Math.Abs(Math.Log(Math.Max(1e-3, StrokeContrast(c)) / Math.Max(1e-3, StrokeContrast(g))));
            return new FontDistance(font, shape, Math.Abs(aspectLog), contrast, aspectLog);
        }

        /// <summary>The candidate closest to the game text (smallest total distance), with all distances.</summary>
        public static (string? Best, List<FontDistance> All) Best(Ink game, IEnumerable<(string Font, Ink Ink)> candidates)
        {
            var all = candidates.Select(c => Compare(c.Font, game, c.Ink)).OrderBy(d => d.Total).ToList();
            return (all.Count > 0 ? all[0].Font : null, all);
        }

        /// <summary>Horizontal stroke thickness / vertical stem thickness (median run widths).</summary>
        public static double StrokeContrast(Ink ink)
        {
            double stems = MedianRun(ink, horizontal: true);
            double bars = MedianRun(ink, horizontal: false);
            return stems > 0 ? bars / stems : 1;
        }

        private static double MedianRun(Ink ink, bool horizontal)
        {
            var runs = new List<double>();
            int outer = horizontal ? ink.Height : ink.Width, inner = horizontal ? ink.Width : ink.Height;
            for (int o = 0; o < outer; o++)
            {
                double sum = 0;
                bool inRun = false;
                for (int i = 0; i < inner; i++)
                {
                    double v = horizontal ? ink.Coverage[o * ink.Width + i] : ink.Coverage[i * ink.Width + o];
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

        private static Ink Crop(Ink ink)
        {
            int x0 = int.MaxValue, y0 = int.MaxValue, x1 = -1, y1 = -1;
            for (int y = 0; y < ink.Height; y++)
                for (int x = 0; x < ink.Width; x++)
                    if (ink.Coverage[y * ink.Width + x] > InkThreshold)
                    {
                        if (x < x0) x0 = x;
                        if (x > x1) x1 = x;
                        if (y < y0) y0 = y;
                        if (y > y1) y1 = y;
                    }
            if (x1 < 0)
                return new Ink(Array.Empty<float>(), 0, 0);
            int w = x1 - x0 + 1, h = y1 - y0 + 1;
            var c = new float[w * h];
            for (int y = 0; y < h; y++)
                Array.Copy(ink.Coverage, (y0 + y) * ink.Width + x0, c, y * w, w);
            return new Ink(c, w, h);
        }

        // Bilinear resampling to w x h
        private static float[] Resample(Ink ink, int w, int h)
        {
            var r = new float[w * h];
            for (int y = 0; y < h; y++)
            {
                double sy = Math.Clamp((y + 0.5) * ink.Height / h - 0.5, 0, ink.Height - 1);
                int ya = (int)sy, yb = Math.Min(ya + 1, ink.Height - 1);
                double fy = sy - ya;
                for (int x = 0; x < w; x++)
                {
                    double sx = Math.Clamp((x + 0.5) * ink.Width / w - 0.5, 0, ink.Width - 1);
                    int xa = (int)sx, xb = Math.Min(xa + 1, ink.Width - 1);
                    double fx = sx - xa;
                    double top = ink.Coverage[ya * ink.Width + xa] * (1 - fx) + ink.Coverage[ya * ink.Width + xb] * fx;
                    double bottom = ink.Coverage[yb * ink.Width + xa] * (1 - fx) + ink.Coverage[yb * ink.Width + xb] * fx;
                    r[y * w + x] = (float)(top * (1 - fy) + bottom * fy);
                }
            }
            return r;
        }

        // Light blur (centre 4/8, each neighbour 1/8) so a one-pixel shift does not count as a difference
        private static float[] Blur(float[] c, int w, int h)
        {
            var r = new float[c.Length];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    float centre = c[y * w + x];
                    float up = y > 0 ? c[(y - 1) * w + x] : centre, down = y < h - 1 ? c[(y + 1) * w + x] : centre;
                    float left = x > 0 ? c[y * w + x - 1] : centre, right = x < w - 1 ? c[y * w + x + 1] : centre;
                    r[y * w + x] = (4 * centre + up + down + left + right) / 8;
                }
            return r;
        }
    }
}
