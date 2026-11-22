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

        /// <summary>
        /// Several lines whose right edges line up while their left edges do not: right-aligned
        /// (numbers, scores, HUD text against the right side).
        /// </summary>
        public static bool LinesRightAligned(IReadOnlyList<(double Left, double Width)> lines, double fontPx)
        {
            if (lines.Count < 2)
                return false;
            double em = fontPx > 0 ? fontPx : lines.Average(l => l.Width) / 20;
            var rights = lines.Select(l => l.Left + l.Width).ToList();
            double rightSpread = rights.Max() - rights.Min();
            double leftSpread = lines.Max(l => l.Left) - lines.Min(l => l.Left);
            return rightSpread <= Math.Max(3, 0.3 * em) && leftSpread >= Math.Max(0.5 * em, 3 * rightSpread);
        }

        /// <summary>
        /// One line ending at the right edge of the screen area (within 2.5% of its width) and starting
        /// past its first third: drawn against the right side, as HUD text in a corner is.
        /// </summary>
        public static bool LineAtRightOfArea(double left, double width, double areaLeft, double areaWidth)
        {
            if (areaWidth <= 0 || width <= 0)
                return false;
            double gap = areaLeft + areaWidth - (left + width);
            return gap >= -2 && gap <= areaWidth * 0.025 && left - areaLeft >= areaWidth / 3;
        }

        /// <param name="minMarginShare">Free space needed on each side, as a share of the area: 8% of
        /// the whole screen (a long left-aligned line can end up centred by chance), less for a
        /// translation area drawn around the text, whose middle is the text's middle.</param>
        public static bool LineCenteredInArea(double left, double width, double areaLeft, double areaWidth, double minMarginShare = 0.08)
        {
            if (areaWidth <= 0 || width <= 0 || width > areaWidth * (1 - 2 * minMarginShare))
                return false;
            double centre = left + width / 2, areaCentre = areaLeft + areaWidth / 2;
            return Math.Abs(centre - areaCentre) <= areaWidth * 0.015 && left - areaLeft >= areaWidth * minMarginShare;
        }
    }
}
