using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// Keeps a game's names and terms through machine translation (Google, Microsoft, Yandex), which
    /// turns some into common words ("Resonators" -> "Các Bộ cộng hưởng", a device). Before
    /// translating, each term (whole word, exact case: "Echo" the game term, not "an echo") becomes a
    /// token translators leave alone (QZX1, QZX2...); afterwards the tokens become the terms again.
    /// </summary>
    public static class TermGuard
    {
        public sealed record Protected(string Text, IReadOnlyList<(string Token, string Term)> Map);

        public static Protected Protect(string text, IReadOnlyCollection<string> terms)
        {
            var map = new List<(string Token, string Term)>();
            if (string.IsNullOrEmpty(text) || terms.Count == 0)
                return new Protected(text, map);
            string result = text;
            // Longest first: "Tacet Discord" before a shorter term inside it
            foreach (string term in terms.Where(t => t.Length > 1).Distinct().OrderByDescending(t => t.Length))
            {
                var pattern = new Regex(@"(?<![\p{L}\p{N}])" + Regex.Escape(term) + @"(?![\p{L}\p{N}])");
                if (!pattern.IsMatch(result))
                    continue;
                string token = $"QZX{map.Count + 1}";
                result = pattern.Replace(result, token);
                map.Add((token, term));
            }
            return new Protected(result, map);
        }

        /// <summary>The translation with its tokens turned back into the terms (spaces a translator put
        /// inside a token, or a changed case, are tolerated).</summary>
        public static string Restore(string translated, IReadOnlyList<(string Token, string Term)> map)
        {
            if (string.IsNullOrEmpty(translated) || map.Count == 0)
                return translated;
            var terms = map.ToDictionary(m => int.Parse(m.Token[3..]), m => m.Term);
            return Regex.Replace(translated, @"Q\s?Z\s?X\s?(\d+)", m =>
                int.TryParse(m.Groups[1].Value, out int n) && terms.TryGetValue(n, out var term) ? term : m.Value,
                RegexOptions.IgnoreCase);
        }
    }
}
