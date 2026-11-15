using System;
using System.Globalization;
using System.Text;

namespace RSTGameTranslation.Cache
{
    /// <summary>
    /// Turns an OCR'd sentence into the key it is cached under, so the same sentence read slightly
    /// differently (curly vs straight quotes, extra spaces, full-width letters, stray "|" at the end,
    /// upper/lower case) still finds its translation. The whole sentence is the key, never single words.
    /// </summary>
    public static class TextKey
    {
        // Characters OCR often invents at the edges of a text box (box borders, cursors, sparkles)
        private const string EdgeJunk = "|_~`^*•·¦‖│┃";

        public static string Normalize(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            // NFKC folds look-alike forms: full-width "Ａ" -> "A", ligatures "ﬁ" -> "fi", "①" -> "1"
            string s = text.Normalize(NormalizationForm.FormKC);
            var sb = new StringBuilder(s.Length);
            bool pendingSpace = false;
            foreach (char raw in s)
            {
                char c = MapPunctuation(raw);
                if (c == '\0')
                    continue; // zero-width characters
                if (char.IsWhiteSpace(c))
                {
                    pendingSpace = sb.Length > 0;
                    continue;
                }
                if (pendingSpace)
                {
                    // Japanese/Chinese have no spaces between words: OCR spaces there are noise
                    if (!IsCjk(c) && !IsCjk(sb[sb.Length - 1]))
                        sb.Append(' ');
                    pendingSpace = false;
                }
                if (c == '…')
                    sb.Append("...");
                else
                    sb.Append(char.ToLowerInvariant(c));
            }

            return TrimEdgeJunk(sb.ToString());
        }

        /// <summary>All digits in order: two sentences may only share a translation if these are equal.</summary>
        public static string Digits(string normalized)
        {
            var sb = new StringBuilder();
            foreach (char c in normalized)
            {
                if (c >= '0' && c <= '9')
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private static char MapPunctuation(char c) => c switch
        {
            '‘' or '’' or '‚' or '‛' or '′' or '´' => '\'',
            '“' or '”' or '„' or '‟' or '″' or '«' or '»' => '"',
            '‐' or '‑' or '‒' or '–' or '—' or '―' or '−' => '-',
            '​' or '‌' or '‍' or '⁠' or '﻿' or '‎' or '‏' => '\0',
            ' ' or '　' => ' ',
            _ => c,
        };

        private static string TrimEdgeJunk(string s)
        {
            int start = 0, end = s.Length;
            while (start < end && (EdgeJunk.IndexOf(s[start]) >= 0 || s[start] == ' '))
                start++;
            while (end > start && (EdgeJunk.IndexOf(s[end - 1]) >= 0 || s[end - 1] == ' '))
                end--;
            return s.Substring(start, end - start);
        }

        public static bool IsCjk(char c) =>
            (c >= '぀' && c <= 'ヿ') ||   // Hiragana, Katakana
            (c >= '㐀' && c <= '䶿') ||   // CJK extension A
            (c >= '一' && c <= '鿿') ||   // CJK unified ideographs
            (c >= '　' && c <= '〿') ||   // CJK punctuation
            (c >= '＀' && c <= '￯');     // half/full-width forms
    }
}
