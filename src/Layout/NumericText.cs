using System.Text.RegularExpressions;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// Text with nothing to translate: numbers, counters and timers (312, 3175/12000, 59.7%, +15%,
    /// 11:59, x3, 11h 59m, 1.2K), symbols and punctuation. It is left as the game shows it, with no
    /// overlay over it, in every game.
    /// </summary>
    public static class NumericText
    {
        // A number with an optional multiplier before it and a short unit after it (d h m s ms k K M)
        private static readonly Regex NumberToken = new(
            @"(?<!\p{L})[x×]?\d[\d.,:/%]*\s*(?:ms|[dhmskKM])?(?!\p{L})",
            RegexOptions.CultureInvariant);

        /// <summary>Whether the text holds no words: only numbers (with units), symbols, punctuation.</summary>
        public static bool HasNoWords(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return true;
            string rest = NumberToken.Replace(text, " ");
            foreach (char c in rest)
            {
                if (char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}
