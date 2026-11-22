using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// How much to shrink a capture before OCR. On large screens (1440p, 4K) game text is often
    /// 40-60 pixels tall, far more than OCR needs, and OCR time grows with the picture: the picture is
    /// shrunk so the smallest line of the last result stays about 26 pixels tall (never below half
    /// size). Unknown sizes, small pictures and small text: full size.
    /// </summary>
    public static class OcrScale
    {
        public const double TargetLinePx = 26;
        public const double MinScale = 0.5;
        private const long MinPixels = 1_200_000;

        public static double For(int width, int height, double smallestLinePx)
        {
            if ((long)width * height < MinPixels || smallestLinePx <= 0)
                return 1;
            double scale = Math.Clamp(TargetLinePx / smallestLinePx, MinScale, 1);
            return scale > 0.85 ? 1 : scale;
        }

        /// <summary>Height of the smaller lines of a result (10th percentile), 0 when there are none.</summary>
        public static double SmallLineHeight(IEnumerable<double> lineHeights)
        {
            var sorted = lineHeights.Where(h => h > 0).OrderBy(h => h).ToList();
            return sorted.Count == 0 ? 0 : sorted[(int)Math.Floor((sorted.Count - 1) * 0.1)];
        }
    }
}
