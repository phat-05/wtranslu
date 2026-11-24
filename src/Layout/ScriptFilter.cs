using System;
using System.Collections.Generic;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// OCR reads a game's tiny decorative strokes (the dashes and dots on menu cards) as Korean,
    /// Chinese or Cyrillic letters. In a game whose text is in a Latin-script language, text that is
    /// mostly in another script is such a misreading: not translated, no overlay.
    /// </summary>
    public static class ScriptFilter
    {
        // Source languages not written in the Latin alphabet (and auto-detect): never filtered
        private static readonly HashSet<string> NonLatin = new(StringComparer.OrdinalIgnoreCase)
        {
            "auto", "ja", "zh", "zh-CN", "zh-TW", "zh-Hans", "zh-Hant", "ko", "ru", "uk", "be", "bg", "sr", "mk", "kk", "mn",
            "el", "ar", "fa", "ur", "he", "yi", "th", "lo", "km", "my", "hi", "mr", "ne", "bn", "pa", "gu", "ta", "te",
            "kn", "ml", "si", "ka", "hy", "am",
        };

        public static bool IsLatinLanguage(string? language) =>
            !string.IsNullOrWhiteSpace(language) && !NonLatin.Contains(language.Trim());

        private static bool IsLatinLetter(char c) =>
            c <= '\u024F' || (c >= '\u1E00' && c <= '\u1EFF') || (c >= '\u2C60' && c <= '\u2C7F') || (c >= '\uA720' && c <= '\uA7FF');

        /// <summary>Whether most letters of the text are not Latin while the game's language is.</summary>
        public static bool IsForeignScript(string? text, string? sourceLanguage)
        {
            if (string.IsNullOrEmpty(text) || !IsLatinLanguage(sourceLanguage))
                return false;
            int letters = 0, latin = 0;
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                    continue;
                letters++;
                if (IsLatinLetter(c))
                    latin++;
            }
            return letters > 0 && latin * 2 < letters;
        }
    }
}
