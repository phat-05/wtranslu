using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace RSTGameTranslation.Layout
{
    /// <summary>
    /// A game's own dictionary, translated once and kept with the app: the menus, buttons and labels
    /// that come back all the time are shown from here, with short translations chosen to fit where
    /// the game's words were and to mean what the game means ("Go" -> "Đi", not "đi đi"; "Expedition
    /// Motorbike" -> "Mô tô thám hiểm"). No translation service is called for them; only text the
    /// dictionary does not know goes out (and is then remembered by the translation cache).
    ///
    /// JSON (user-editable, see app/GameDictionaries):
    ///   "keep":     words left as the game shows them when a text holds only these and numbers
    ///               (Lv., ATK, HP, Crit Rate...): no overlay at all
    ///   "entries":  whole texts, matched ignoring case, spaces, line breaks and a trailing colon
    ///   "patterns": texts with placeholders: {n} a number (180, 3175/12000, 59.7%, 1,200),
    ///               {t} a duration (11h 59m), {x} any words (a name)
    /// </summary>
    public sealed class GameDictionary
    {
        private readonly Dictionary<string, string> _entries = new(StringComparer.Ordinal);
        private readonly List<(Regex Pattern, string Translation, string[] Slots)> _patterns = new();
        private readonly Regex? _keep;

        public int Count => _entries.Count + _patterns.Count;

        private const string Number = @"[+\-]?\d[\d.,:/%]*";
        private const string Duration = @"(?:\d+\s*[dhms]\s*)+";

        public GameDictionary(IEnumerable<KeyValuePair<string, string>> entries,
                              IEnumerable<KeyValuePair<string, string>> patterns,
                              IEnumerable<string> keep)
        {
            foreach (var (source, translation) in entries)
            {
                string key = Normalize(source);
                if (key.Length > 0 && !string.IsNullOrWhiteSpace(translation))
                    _entries[key] = translation.Trim();
            }
            foreach (var (template, translation) in patterns)
            {
                if (string.IsNullOrWhiteSpace(template) || string.IsNullOrWhiteSpace(translation))
                    continue;
                var slots = new List<string>();
                var regex = new StringBuilder("^");
                string normalized = Normalize(template);
                int i = 0;
                foreach (Match m in Regex.Matches(normalized, @"\{([ntx])\}"))
                {
                    regex.Append(Regex.Escape(normalized[i..m.Index]).Replace(@"\ ", @"\s*"));
                    string kind = m.Groups[1].Value;
                    regex.Append(kind switch { "n" => $"({Number})", "t" => $"({Duration})", _ => "(.+?)" });
                    slots.Add(kind);
                    i = m.Index + m.Length;
                }
                regex.Append(Regex.Escape(normalized[i..]).Replace(@"\ ", @"\s*")).Append('$');
                _patterns.Add((new Regex(regex.ToString(), RegexOptions.CultureInvariant), translation.Trim(), slots.ToArray()));
            }
            var keepTerms = keep.Where(k => !string.IsNullOrWhiteSpace(k)).Select(k => Regex.Escape(Normalize(k)))
                                .OrderByDescending(k => k.Length).ToList();
            string keepAlternatives = keepTerms.Count > 0 ? "|" + string.Join("|", keepTerms) : "";
            // Only kept words, numbers, durations and punctuation
            _keep = new Regex($@"^(?:\s|[^\p{{L}}\p{{N}}]|{Number}|{Duration}{keepAlternatives})+$", RegexOptions.CultureInvariant);
        }

        public static GameDictionary Parse(string json)
        {
            using var doc = JsonDocument.Parse(json, new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip, AllowTrailingCommas = true });
            var root = doc.RootElement;
            IEnumerable<KeyValuePair<string, string>> Pairs(string name) =>
                root.TryGetProperty(name, out var obj) && obj.ValueKind == JsonValueKind.Object
                    ? obj.EnumerateObject().Where(p => p.Value.ValueKind == JsonValueKind.String)
                         .Select(p => new KeyValuePair<string, string>(p.Name, p.Value.GetString()!)).ToList()
                    : new List<KeyValuePair<string, string>>();
            var keep = root.TryGetProperty("keep", out var k) && k.ValueKind == JsonValueKind.Array
                ? k.EnumerateArray().Where(v => v.ValueKind == JsonValueKind.String).Select(v => v.GetString()!).ToList()
                : new List<string>();
            return new GameDictionary(Pairs("entries"), Pairs("patterns"), keep);
        }

        /// <summary>Lowercase, one space between words (line breaks too), no trailing colon or dots of
        /// an ellipsis, straight quotes: how OCR text and dictionary keys are compared.</summary>
        public static string Normalize(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";
            string t = text.Replace('’', '\'').Replace('‘', '\'').Replace('“', '"').Replace('”', '"').Replace('…', ' ');
            t = Regex.Replace(t, @"\s+", " ").Trim();
            t = t.TrimEnd(':', '：', ' ');
            return t.ToLowerInvariant();
        }

        /// <summary>Whether the text holds only words the game keeps (stats, abbreviations) and
        /// numbers: shown as the game shows it, not translated.</summary>
        public bool IsKept(string text)
        {
            string t = Normalize(text);
            return t.Length > 0 && _keep != null && _keep.IsMatch(t);
        }

        public bool TryTranslate(string text, out string translation)
        {
            string t = Normalize(text);
            if (_entries.TryGetValue(t, out var exact))
            {
                translation = exact;
                return true;
            }
            // Original casing of the slots (names, numbers) is taken from the text itself
            string spaced = Regex.Replace(text ?? "", @"\s+", " ").Trim().TrimEnd(':', '：', ' ');
            foreach (var (pattern, template, slots) in _patterns)
            {
                var m = pattern.Match(t);
                if (!m.Success)
                    continue;
                var original = new Regex(pattern.ToString(), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant).Match(spaced);
                var source = original.Success ? original : m;
                var counters = new Dictionary<string, int>();
                string result = Regex.Replace(template, @"\{([ntx])\}", s =>
                {
                    string kind = s.Groups[1].Value;
                    int nth = counters.GetValueOrDefault(kind);
                    counters[kind] = nth + 1;
                    // The nth slot of that kind in the template
                    int index = -1, seen = 0;
                    for (int i = 0; i < slots.Length; i++)
                        if (slots[i] == kind && seen++ == nth) { index = i; break; }
                    return index >= 0 ? source.Groups[index + 1].Value.Trim() : s.Value;
                });
                translation = result;
                return true;
            }
            translation = "";
            return false;
        }
    }
}
