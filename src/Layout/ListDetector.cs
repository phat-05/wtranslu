using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// Menus and option lists: short lines stacked under one another, each its own item ("Continue",
    /// "Load Game", "Settings", "Quit"). Merged into one block they were translated as one sentence
    /// and wrapped anyhow ("Tiếp tục tải / Cài đặt trò / chơi Thoát"); kept apart, every item is
    /// translated alone and shown on its own line, where the game shows it.
    ///
    /// An item: at most 3 words and 24 characters, starting with a capital letter or a digit, not
    /// ending in a comma, hyphen or colon (which continue onto the next line). A list: 3 or more
    /// items stacked with less than a line of space between them, sharing their left edge or their
    /// middle.
    /// </summary>
    public static class ListDetector
    {
        public static bool IsItem(string text)
        {
            string t = text.Trim();
            if (t.Length == 0 || t.Length > 24)
                return false;
            if (t.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length > 3)
                return false;
            char first = t[0];
            bool startsLikeItem = char.IsDigit(first) || (char.IsLetter(first) && char.IsUpper(first) && first < 'ɐ');
            return startsLikeItem && !",-:;".Contains(t[^1]);
        }

        /// <summary>Indexes of the lines that belong to a list (3+ stacked items).</summary>
        public static HashSet<int> ListLines(IReadOnlyList<(string Text, double X, double Y, double Width, double Height)> lines)
        {
            var result = new HashSet<int>();
            var items = Enumerable.Range(0, lines.Count).Where(i => IsItem(lines[i].Text)).OrderBy(i => lines[i].Y).ToList();
            var used = new HashSet<int>();
            foreach (int start in items)
            {
                if (used.Contains(start))
                    continue;
                // Grow a stack downward from this item
                var stack = new List<int> { start };
                int last = start;
                foreach (int next in items)
                {
                    if (next == last || stack.Contains(next) || lines[next].Y <= lines[last].Y)
                        continue;
                    var a = lines[last];
                    var b = lines[next];
                    double lineHeight = Math.Max(a.Height, b.Height);
                    double gap = b.Y - (a.Y + a.Height);
                    bool sameLeft = Math.Abs(a.X - b.X) <= Math.Max(4, lineHeight * 0.4);
                    bool sameMiddle = Math.Abs(a.X + a.Width / 2 - (b.X + b.Width / 2)) <= Math.Max(4, lineHeight * 0.4);
                    bool similarSize = Math.Abs(a.Height - b.Height) <= lineHeight * 0.35;
                    if (gap < lineHeight && gap > -lineHeight * 0.5 && (sameLeft || sameMiddle) && similarSize)
                    {
                        stack.Add(next);
                        last = next;
                    }
                }
                if (stack.Count >= 3)
                {
                    foreach (int i in stack)
                    {
                        result.Add(i);
                        used.Add(i);
                    }
                }
            }
            return result;
        }
    }
}
