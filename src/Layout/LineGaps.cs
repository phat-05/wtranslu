using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// OCR reads words on the same baseline as one line even when they are separate labels far
    /// apart (a menu's icon names in a row: "Store   Pioneer Podcast   Convene", a label and its
    /// value: "Union Level      46"). A gap much wider than a space between words splits the line.
    /// </summary>
    public static class LineGaps
    {
        // A gap wider than this many text heights is not a space between words
        public const double MaxWordGapEm = 2.5;

        /// <summary>
        /// The words of a horizontal line (boxes in reading order) in groups separated by wide gaps;
        /// one group when there are none.
        /// </summary>
        public static List<List<int>> Split(IReadOnlyList<(double X, double Y, double W, double H)> words, double maxGapEm = MaxWordGapEm)
        {
            var groups = new List<List<int>>();
            if (words.Count == 0)
                return groups;
            var order = Enumerable.Range(0, words.Count).OrderBy(i => words[i].X).ToList();
            var heights = words.Select(w => w.H).Where(h => h > 0).OrderBy(h => h).ToList();
            double em = heights.Count > 0 ? heights[heights.Count / 2] : 0;
            var current = new List<int> { order[0] };
            for (int k = 1; k < order.Count; k++)
            {
                var previous = words[order[k - 1]];
                var word = words[order[k]];
                double gap = word.X - (previous.X + previous.W);
                if (em > 0 && gap > maxGapEm * em)
                {
                    groups.Add(current);
                    current = new List<int>();
                }
                current.Add(order[k]);
            }
            groups.Add(current);
            return groups;
        }
    }
}
