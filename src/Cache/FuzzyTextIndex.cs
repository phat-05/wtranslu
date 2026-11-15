using System;
using System.Collections.Generic;

namespace RSTGameTranslation.Cache
{
    /// <summary>
    /// Finds a cached sentence that is the same as a new one except for OCR misreads
    /// ("rnodern" for "modern", "I" for "l", a dropped comma), without comparing against every entry.
    ///
    /// How: every key is cut into overlapping 3-letter pieces (trigrams). A misread changes only the
    /// few pieces around it, so the right entry shares most pieces with the query. Only entries that
    /// share enough pieces and have a similar length are compared letter by letter (Levenshtein =
    /// the number of single-letter edits from one to the other).
    ///
    /// Safety rules, because a wrong reuse is worse than a slow translation:
    /// - short sentences (under MinFuzzyLength) only match exactly;
    /// - all numbers must be identical ("10 gold" never reuses "16 gold");
    /// - word by word, a differing word may differ by at most 1 letter (2 for words of 5+ letters)
    ///   and its length by at most 1, so "can" / "can't" or an added "not" never match;
    /// - two words may be merged into one (a missed space), nothing else may be added or removed.
    /// </summary>
    public sealed class FuzzyTextIndex
    {
        public const int MinFuzzyLength = 6;

        private readonly List<string?> _keys = new();
        private readonly Dictionary<string, int> _ids = new();
        private readonly Dictionary<int, List<int>> _postings = new();

        public int Count => _ids.Count;

        public void Add(string key)
        {
            if (string.IsNullOrEmpty(key) || _ids.ContainsKey(key))
                return;
            int id = _keys.Count;
            _keys.Add(key);
            _ids[key] = id;
            foreach (int gram in Trigrams(key))
            {
                if (!_postings.TryGetValue(gram, out var list))
                    _postings[gram] = list = new List<int>();
                list.Add(id);
            }
        }

        public void Remove(string key)
        {
            // Postings keep the id; the null key makes it skipped (cheap, removals are rare)
            if (_ids.Remove(key, out int id))
                _keys[id] = null;
        }

        public void Clear()
        {
            _keys.Clear();
            _ids.Clear();
            _postings.Clear();
        }

        /// <summary>Best key with similarity >= threshold that passes the safety rules, or null.</summary>
        public string? FindBest(string query, double threshold, out double similarity)
        {
            similarity = 0;
            if (query.Length < MinFuzzyLength || _ids.Count == 0)
                return null;

            var grams = new HashSet<int>(Trigrams(query));
            if (grams.Count == 0)
                return null;

            // Count shared trigrams per candidate
            var shared = new Dictionary<int, int>();
            foreach (int gram in grams)
            {
                if (!_postings.TryGetValue(gram, out var list))
                    continue;
                foreach (int id in list)
                    shared[id] = shared.TryGetValue(id, out int n) ? n + 1 : 1;
            }

            string digits = TextKey.Digits(query);
            // A single edit changes at most 3 trigrams; allow the edits the threshold allows
            int maxEdits = (int)Math.Floor((1 - threshold) * query.Length) + 1;
            int minShared = Math.Max(1, grams.Count - 3 * maxEdits);

            string? best = null;
            foreach (var (id, count) in shared)
            {
                if (count < minShared)
                    continue;
                string? key = _keys[id];
                if (key == null || key.Length < MinFuzzyLength)
                    continue;
                int maxLen = Math.Max(key.Length, query.Length);
                if (Math.Abs(key.Length - query.Length) > (1 - threshold) * maxLen + 1)
                    continue;
                int limit = (int)Math.Floor((1 - threshold) * maxLen);
                int distance = BoundedLevenshtein(query, key, limit);
                if (distance > limit)
                    continue;
                double sim = 1.0 - (double)distance / maxLen;
                if (sim < threshold || sim <= similarity)
                    continue;
                if (TextKey.Digits(key) != digits || !WordsCompatible(query, key))
                    continue;
                best = key;
                similarity = sim;
            }
            return best;
        }

        // ---- safety rule: compare word by word ----

        public static bool WordsCompatible(string a, string b)
        {
            string[] wa = a.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] wb = b.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (wa.Length == wb.Length)
                return PairsCompatible(wa, 0, wb, 0, wa.Length);
            if (Math.Abs(wa.Length - wb.Length) != 1)
                return false;

            // One space missing or extra: some adjacent pair in the longer equals one word in the shorter
            string[] longer = wa.Length > wb.Length ? wa : wb;
            string[] shorter = wa.Length > wb.Length ? wb : wa;
            for (int merge = 0; merge < shorter.Length; merge++)
            {
                if (!PairsCompatible(longer, 0, shorter, 0, merge))
                    continue;
                string joined = longer[merge] + longer[merge + 1];
                if (!WordCompatible(joined, shorter[merge]))
                    continue;
                if (PairsCompatible(longer, merge + 2, shorter, merge + 1, shorter.Length - merge - 1))
                    return true;
            }
            return false;
        }

        private static bool PairsCompatible(string[] a, int ia, string[] b, int ib, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (!WordCompatible(a[ia + i], b[ib + i]))
                    return false;
            }
            return true;
        }

        private static bool WordCompatible(string a, string b)
        {
            if (a == b)
                return true;
            if (Math.Abs(a.Length - b.Length) > 1)
                return false;
            int allowed = Math.Max(a.Length, b.Length) >= 5 ? 2 : 1;
            return BoundedLevenshtein(a, b, allowed) <= allowed;
        }

        // ---- helpers ----

        private static IEnumerable<int> Trigrams(string s)
        {
            if (s.Length < 3)
            {
                if (s.Length > 0)
                    yield return s.GetHashCode();
                yield break;
            }
            for (int i = 0; i + 3 <= s.Length; i++)
                yield return (s[i] * 31 + s[i + 1]) * 31 + s[i + 2];
        }

        /// <summary>
        /// Levenshtein distance, giving up (returning limit + 1) as soon as it must exceed limit.
        /// Only the diagonal band of width 2*limit+1 can stay within the limit, so only that is computed.
        /// </summary>
        public static int BoundedLevenshtein(string a, string b, int limit)
        {
            if (Math.Abs(a.Length - b.Length) > limit)
                return limit + 1;
            if (a == b)
                return 0;

            int n = a.Length, m = b.Length;
            const int Inf = int.MaxValue / 2;
            var prev = new int[m + 1];
            var curr = new int[m + 1];
            for (int j = 0; j <= m; j++)
                prev[j] = j <= limit ? j : Inf;

            for (int i = 1; i <= n; i++)
            {
                int from = Math.Max(1, i - limit), to = Math.Min(m, i + limit);
                curr[0] = i <= limit ? i : Inf;
                if (from > 1)
                    curr[from - 1] = Inf;
                int rowMin = curr[0];
                for (int j = from; j <= to; j++)
                {
                    int cost = a[i - 1] == b[j - 1] ? 0 : 1;
                    int v = Math.Min(Math.Min(prev[j] + 1, curr[j - 1] + 1), prev[j - 1] + cost);
                    curr[j] = v;
                    if (v < rowMin)
                        rowMin = v;
                }
                if (to < m)
                    curr[to + 1] = Inf;
                if (rowMin > limit)
                    return limit + 1;
                (prev, curr) = (curr, prev);
            }
            return prev[m] > limit ? limit + 1 : prev[m];
        }
    }
}
