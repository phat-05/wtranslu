using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// Whether game text is centred, so the translation (longer or shorter than the original) can be
    /// centred on the same point instead of starting at the original's left edge.
    ///
    /// - Several lines: centred when their middles line up while their left edges do not (lines of
    ///   different lengths). Left-aligned lines share the left edge instead.
    /// - One line: centred when its middle is at the middle of the screen area (within 1.5% of its
    ///   width) and it does not start near the left edge, as subtitles and titles are drawn.
    /// </summary>
    public static class AlignmentDetector
    {
        public static bool LinesCentered(IReadOnlyList<(double Left, double Width)> lines, double fontPx)
        {
            if (lines.Count < 2)
                return false;
            double em = fontPx > 0 ? fontPx : lines.Average(l => l.Width) / 20;
            var centres = lines.Select(l => l.Left + l.Width / 2).ToList();
            var lefts = lines.Select(l => l.Left).ToList();
            double centreSpread = centres.Max() - centres.Min();
            double leftSpread = lefts.Max() - lefts.Min();
            return centreSpread <= Math.Max(3, 0.3 * em) && leftSpread >= Math.Max(0.5 * em, 3 * centreSpread);
        }

        public static bool LineCenteredInArea(double left, double width, double areaLeft, double areaWidth)
        {
            if (areaWidth <= 0 || width <= 0 || width > areaWidth * 0.9)
                return false;
            double centre = left + width / 2, areaCentre = areaLeft + areaWidth / 2;
            return Math.Abs(centre - areaCentre) <= areaWidth * 0.015 && left - areaLeft >= areaWidth * 0.08;
        }
    }
}
