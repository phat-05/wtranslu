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

        // A label is split off at a gap at least this many text heights wide (spaces between words of
        // a sentence are narrower)
        public const double MinLabelGapEm = 0.5;

        /// <summary>
        /// A known game: where a line starts or ends with one of the game's labels set a little apart
        /// (a "Current" badge beside a name), the index of the first word after the split; -1 when the
        /// line is one item. Words in reading order; isLabel tells a label of the game.
        /// </summary>
        public static int LabelSplit(IReadOnlyList<(double X, double Y, double W, double H)> words, IReadOnlyList<string> texts,
                                     Func<string, bool> isLabel, string separator = " ")
        {
            if (words.Count < 2 || words.Count != texts.Count || isLabel(string.Join(separator, texts)))
                return -1;
            int best = -1;
            double bestRatio = MinLabelGapEm;
            for (int k = 1; k < words.Count; k++)
            {
                // Against the taller of the two words (a lower-case word measures only its x-height)
                double em = Math.Max(words[k].H, words[k - 1].H);
                double gap = words[k].X - (words[k - 1].X + words[k - 1].W);
                if (em <= 0 || gap / em < bestRatio)
                    continue;
                string before = string.Join(separator, texts.Take(k));
                string after = string.Join(separator, texts.Skip(k));
                if (isLabel(before) || isLabel(after))
                {
                    best = k;
                    bestRatio = gap / em;
                }
            }
            return best;
        }
    }
}
