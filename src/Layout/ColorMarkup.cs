using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RSTGameTranslation.Layout
{
    /// <summary>A run of words in one colour that differs from the line's main colour, e.g. a key item name.</summary>
    public sealed record ColorSpan(int Number, Rgb Color, string SourceText)
    {
        public string Open => $"<c{Number}>";
        public string Close => $"</c{Number}>";
    }

    /// <summary>
    /// Colour tags for words in a different colour: "Find the &lt;c1&gt;red key&lt;/c1&gt; before dawn".
    /// The tagged sentence goes to the AI translator, which is asked to keep each tag pair around the
    /// words that translate the tagged ones ("Tìm &lt;c1&gt;chìa khóa đỏ&lt;/c1&gt; trước bình minh"), so the
    /// overlay can paint those words in the colour the game used.
    /// </summary>
    public static class ColorMarkup
    {
        private static readonly Regex Tag = new(@"</?c(\d+)>", RegexOptions.Compiled);

        // Words this far (RGB distance) from the line's main colour count as differently coloured
        public const double MinWordColorDistance = 90;
        // Neighbouring coloured words closer than this to each other share a tag
        private const double SameSpanDistance = 60;
        // Below this spread between its channels a colour is a grey (white, grey, black)
        private const int MaxGreyChroma = 40;

        private static bool IsGrey(Rgb c) => Math.Max(c.R, Math.Max(c.G, c.B)) - Math.Min(c.R, Math.Min(c.G, c.B)) < MaxGreyChroma;

        /// <summary>
        /// Whether a word's colour stands out from the line's: far enough from it, and not only lighter
        /// or darker grey on grey (small white text reads as grey words where it is thin or blurred).
        /// </summary>
        public static bool IsDistinctColor(Rgb word, Rgb fill) =>
            word.DistanceTo(fill) >= MinWordColorDistance && !(IsGrey(word) && IsGrey(fill));

        public static bool HasTags(string? text) => !string.IsNullOrEmpty(text) && Tag.IsMatch(text);

        public static string Strip(string? text) => string.IsNullOrEmpty(text) ? text ?? "" : Tag.Replace(text, "");

        /// <summary>
        /// Tags runs of words whose colour differs from the fill. Returns null when every word has the
        /// main colour (nothing to tag).
        /// </summary>
        public static string? BuildTagged(IReadOnlyList<(string Word, Rgb? Color)> words, Rgb fill, out List<ColorSpan> spans)
        {
            var found = new List<ColorSpan>();
            var sb = new StringBuilder();
            ColorSpan? open = null;
            var openWords = new List<string>();

            void CloseOpen(StringBuilder b)
            {
                if (open == null) return;
                b.Append(open.Close);
                found.Add(open with { SourceText = string.Join(" ", openWords) });
                open = null;
                openWords.Clear();
            }

            for (int i = 0; i < words.Count; i++)
            {
                var (word, color) = words[i];
                bool coloured = color != null && IsDistinctColor(color.Value, fill);
                if (open != null && (!coloured || color!.Value.DistanceTo(open.Color) >= SameSpanDistance))
                    CloseOpen(sb);
                if (sb.Length > 0)
                    sb.Append(' ');
                if (coloured && open == null)
                {
                    int number = found.Count + 1;
                    open = new ColorSpan(number, color!.Value, "");
                    sb.Append(open.Open);
                }
                sb.Append(word);
                if (open != null)
                    openWords.Add(word);
            }
            CloseOpen(sb);
            spans = found;
            return found.Count == 0 ? null : sb.ToString();
        }

        /// <summary>
        /// Splits a translation into pieces, each with the span number it is inside (null = main colour).
        /// Tolerates what translators do to tags: missing closing tags (the span ends at the next tag or
        /// the end), stray closing tags, unknown numbers.
        /// </summary>
        public static List<(string Text, int? Span)> Parse(string text)
        {
            var parts = new List<(string, int?)>();
            int pos = 0;
            int? current = null;
            foreach (Match m in Tag.Matches(text))
            {
                if (m.Index > pos)
                    parts.Add((text.Substring(pos, m.Index - pos), current));
                bool closing = m.Value.StartsWith("</", StringComparison.Ordinal);
                int number = int.Parse(m.Groups[1].Value);
                current = closing ? null : number;
                pos = m.Index + m.Length;
            }
            if (pos < text.Length)
                parts.Add((text.Substring(pos), current));
            return parts.Where(p => p.Item1.Length > 0).ToList();
        }

        /// <summary>
        /// For translators that cannot keep tags (Google Translate, ...): a coloured span that appears
        /// word for word in the translation (names, numbers, untranslated terms) is tagged there.
        /// </summary>
        public static string TagVerbatim(string translation, IReadOnlyList<ColorSpan> spans)
        {
            string result = translation;
            foreach (var span in spans)
            {
                if (span.SourceText.Length < 2)
                    continue;
                int at = result.IndexOf(span.SourceText, StringComparison.OrdinalIgnoreCase);
                if (at < 0 || HasTags(result.Substring(at, span.SourceText.Length)))
                    continue;
                result = result.Substring(0, at) + span.Open + result.Substring(at, span.SourceText.Length) + span.Close +
                         result.Substring(at + span.SourceText.Length);
            }
            return result;
        }

        /// <summary>The instruction added to the AI prompt when some text carries colour tags.</summary>
        public const string PromptRule =
            "\n\nSome texts contain colour tags such as <c1>...</c1> around words shown in another colour in the game. " +
            "Keep every tag pair exactly as written (same name, e.g. <c1> and </c1>) around the words of your translation " +
            "that translate the tagged words. Do not add, remove, rename or translate tags.";
    }
}
