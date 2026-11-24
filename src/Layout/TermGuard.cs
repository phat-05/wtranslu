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

        private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, Regex> Patterns = new();

        // The term as a whole word, exact case
        private static Regex PatternFor(string term) =>
            Patterns.GetOrAdd(term, t => new Regex(@"(?<![\p{L}\p{N}])" + Regex.Escape(t) + @"(?![\p{L}\p{N}])", RegexOptions.CultureInvariant));

        /// <summary>The terms the text holds (longest first; a term inside a longer one found is not repeated).</summary>
        public static List<string> TermsIn(string text, IReadOnlyCollection<string> terms)
        {
            var found = new List<string>();
            if (string.IsNullOrEmpty(text) || terms.Count == 0)
                return found;
            string rest = text;
            foreach (string term in terms.Where(t => t.Length > 1).Distinct().OrderByDescending(t => t.Length))
            {
                var pattern = PatternFor(term);
                if (!pattern.IsMatch(rest))
                    continue;
                found.Add(term);
                rest = pattern.Replace(rest, " ");
            }
            return found;
        }

        /// <summary>
        /// Whether a translation of the text kept its terms: each term the text holds is in it, as the
        /// term or as its glossary translation (any case). A cached translation from before a term was
        /// protected ("Bộ cộng hưởng" for "Resonator") fails this and is translated again.
        /// </summary>
        public static bool KeepsTerms(string text, string translation, IReadOnlyCollection<string> terms,
                                      IReadOnlyDictionary<string, string>? glossary = null)
        {
            foreach (string term in TermsIn(text, terms))
            {
                string expected = glossary != null && glossary.TryGetValue(term, out var t) ? t : term;
                if (translation.IndexOf(expected, StringComparison.OrdinalIgnoreCase) < 0)
                    return false;
            }
            return true;
        }

        public static Protected Protect(string text, IReadOnlyCollection<string> terms)
        {
            var map = new List<(string Token, string Term)>();
            if (string.IsNullOrEmpty(text) || terms.Count == 0)
                return new Protected(text, map);
            string result = text;
            // Longest first: "Tacet Discord" before a shorter term inside it
            foreach (string term in terms.Where(t => t.Length > 1).Distinct().OrderByDescending(t => t.Length))
            {
                var pattern = PatternFor(term);
                if (!pattern.IsMatch(result))
                    continue;
                string token = $"QZX{map.Count + 1}";
                result = pattern.Replace(result, token);
                map.Add((token, term));
            }
            return new Protected(result, map);
        }

        /// <summary>The translation with its tokens turned back into the terms, or into their glossary
        /// translations (spaces a translator put inside a token, or a changed case, are tolerated).</summary>
        public static string Restore(string translated, IReadOnlyList<(string Token, string Term)> map,
                                     IReadOnlyDictionary<string, string>? glossary = null)
        {
            if (string.IsNullOrEmpty(translated) || map.Count == 0)
                return translated;
            var terms = map.ToDictionary(m => int.Parse(m.Token[3..]),
                                         m => glossary != null && glossary.TryGetValue(m.Term, out var t) ? t : m.Term);
            return Regex.Replace(translated, @"Q\s?Z\s?X\s?(\d+)", m =>
                int.TryParse(m.Groups[1].Value, out int n) && terms.TryGetValue(n, out var term) ? term : m.Value,
                RegexOptions.IgnoreCase);
        }
    }
}
