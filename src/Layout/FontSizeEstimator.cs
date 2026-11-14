using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// Estimates the game's font size from the height of the OCR box of each text line.
    ///
    /// Why height and not width: the width of a line depends on the font (a narrow game font fits
    /// more letters than Arial), so sizing by "what fits in the box" made the translation of big,
    /// narrow text come out small. The height of a line hardly depends on the font.
    ///
    /// An OCR line box spans the ink of the line plus a little padding. How tall the ink is depends
    /// on the letters: "Pay him" reaches from the top of "P"/"h" down to the tail of "y" (about 0.93 of
    /// the font size), "HELLO" only covers capital height (about 0.72), "use" only x-height (about 0.5).
    /// So: font size = box height / (ink height of these letters + padding).
    /// </summary>
    public static class FontSizeEstimator
    {
        // Measured on OneOCR boxes of Segoe UI and Georgia text: the box is ~0.2 em taller than the ink
        public const double DefaultPaddingEm = 0.2;
        // Windows OCR builds line boxes from word boxes, which hug the ink more closely
        public const double WindowsOcrPaddingEm = 0.1;

        // Q and J only dip below the line in some fonts, by a hair: not counted
        private const string Descenders = "gjpqy,;()[]{}|/";
        private const string Ascenders = "bdfhiklt0123456789'\"!?";

        /// <summary>Font size (same unit as boxHeight) of one horizontal line of text.</summary>
        public static double FromLine(double boxHeight, string text, double paddingEm = DefaultPaddingEm)
        {
            if (boxHeight <= 0)
                return 0;
            // Measured: OneOCR pads boxes of lines with lowercase letters by ~0.2 em, while a line of
            // capitals only (a banner, "QUEST COMPLETE") gets a box that hugs the capitals
            bool hasLowercase = false;
            foreach (char c in text)
                if (char.IsLower(c)) { hasLowercase = true; break; }
            double padding = hasLowercase ? paddingEm : paddingEm * 0.15;
            return boxHeight / (InkHeightEm(text) + padding);
        }

        /// <summary>
        /// Font size of a block from its lines: the median of the per-line estimates, so a line that
        /// OCR boxed oddly does not move the result.
        /// </summary>
        public static double FromLines(IEnumerable<(double BoxHeight, string Text)> lines, double paddingEm = DefaultPaddingEm)
        {
            var sizes = lines.Where(l => l.BoxHeight > 0 && !string.IsNullOrWhiteSpace(l.Text))
                             .Select(l => FromLine(l.BoxHeight, l.Text, paddingEm))
                             .OrderBy(v => v)
                             .ToList();
            if (sizes.Count == 0)
                return 0;
            int mid = sizes.Count / 2;
            return sizes.Count % 2 == 1 ? sizes[mid] : (sizes[mid - 1] + sizes[mid]) / 2;
        }

        /// <summary>Height of the ink of these letters, as a fraction of the font size.</summary>
        public static double InkHeightEm(string text)
        {
            bool descender = false, tall = false;
            foreach (char c in text)
            {
                if (IsCjk(c))
                    return 0.92; // CJK glyphs fill most of the em square
                if (Descenders.IndexOf(c) >= 0)
                    descender = true;
                if (char.IsUpper(c) || Ascenders.IndexOf(c) >= 0 || IsAccented(c))
                    tall = true;
            }
            if (descender)
                return 0.93;   // ascender/cap top down to descender bottom
            if (tall)
                return 0.73;   // cap/ascender height down to the baseline
            return 0.52;       // x-height only ("use", "nor")
        }

        // Lowercase letters with marks above (é, ô, ữ) reach ascender height
        private static bool IsAccented(char c) =>
            c > 127 && char.IsLetter(c) && char.IsLower(c) &&
            c.ToString().Normalize(System.Text.NormalizationForm.FormD).Length > 1;

        private static bool IsCjk(char c) =>
            (c >= '぀' && c <= 'ヿ') || (c >= '一' && c <= '鿿') || (c >= '가' && c <= '힯');
    }
}
