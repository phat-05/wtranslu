using System;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// Whether a font can show Vietnamese: every vowel with every tone mark (precomposed forms, which is
    /// how translations arrive), plus đ/Đ. A font missing some of them shows boxes or falls back to
    /// another font for single letters, which looks broken in the middle of a word.
    /// </summary>
    public static class VietnameseCoverage
    {
        public const string RequiredCharacters =
            "aàảãáạăằẳẵắặâầẩẫấậeèẻẽéẹêềểễếệiìỉĩíịoòỏõóọôồổỗốộơờởỡớợuùủũúụưừửữứựyỳỷỹýỵđ" +
            "AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬEÈẺẼÉẸÊỀỂỄẾỆIÌỈĨÍỊOÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢUÙỦŨÚỤƯỪỬỮỨỰYỲỶỸÝỴĐ";

        /// <summary>The required characters the font has no glyph for (empty = full support).</summary>
        public static string Missing(Func<char, bool> hasGlyph) =>
            new string(RequiredCharacters.Where(c => !hasGlyph(c)).ToArray());

        public static bool IsSupported(Func<char, bool> hasGlyph) => Missing(hasGlyph).Length == 0;
    }
}
