using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>Letter case of the game text, kept in the translation (headings, banners in capitals).</summary>
    public static class TextCase
    {
        /// <summary>
        /// Whether the text is written in capitals: at least 4 letters, all upper case among the
        /// letters that have a case (digits, punctuation and caseless scripts do not count).
        /// </summary>
        public static bool IsAllCaps(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            var cased = text.Where(c => char.IsLetter(c) && char.ToUpperInvariant(c) != char.ToLowerInvariant(c)).ToList();
            return cased.Count >= 4 && cased.All(char.IsUpper);
        }

        /// <summary>The translation in the game text's case: capitals when the game wrote capitals.</summary>
        public static string Match(string source, string translation) =>
            IsAllCaps(source) ? translation.ToUpperInvariant() : translation;
    }
}
