using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace RSTGameTranslation.Cache
{
    /// <summary>
    /// The image tier of the cache: recognises text already OCR'd from the pixels alone, so OCR
    /// can be skipped for text shown again (and for every frame of a still text over an animated
    /// background, which otherwise is OCR'd 4 times a second).
    ///
    /// After each real OCR, the boxes of the lines it found (the "layout") and a fingerprint of each
    /// box are stored with the OCR result. On a new frame, the fingerprints are taken at the boxes of
    /// the most recently seen layouts; when all boxes of a stored entry match, its OCR result is reused.
    ///
    /// Text in a place that is not part of any stored layout (a new popup over an unchanged dialogue)
    /// would not be noticed by the fingerprints alone, so OCR still runs for real every VerifyEvery
    /// hits; when it reads something else than the entry said, the entry is dropped.
    /// </summary>
    public sealed class ImageTextCache
    {
        public sealed class Line
        {
            public int X, Y, W, H;
            public string Text = "";
        }

        private sealed class Entry
        {
            public int FrameW, FrameH;
            // Lines large enough to fingerprint (a lone "X" or "." is too small to tell apart reliably);
            // the OCR result below still has all lines
            public Line[] Lines = Array.Empty<Line>();
            public TextFingerprint[] Prints = Array.Empty<TextFingerprint>();
            public string OcrJson = "";
            public LinkedListNode<Entry>? Node;
        }

        public const int VerifyEvery = 8;
        // Entries tried per frame, most recently used first. Fingerprints are computed once per box
        // and frame, and entries of the same scene share boxes, so this stays cheap.
        private const int MaxEntriesChecked = 64;
        private const int MaxEntries = 3000;
        private const int BoxPadding = 2;
        private const int MinBoxWidth = 16, MinBoxHeight = 10;
        // Boxes of two OCR runs of the same picture differ by a pixel or two
        private const int SameBoxTolerance = 4;

        private readonly LinkedList<Entry> _entries = new(); // most recently used first
        private readonly object _lock = new();
        private readonly string? _path;
        private int _hitsSinceVerify;
        private Entry? _verifying;

        public int Count { get { lock (_lock) return _entries.Count; } }

        public ImageTextCache(string? path)
        {
            _path = path;
            Load();
        }

        /// <summary>
        /// Looks the frame up. Returns the stored OCR result (JSON) on a hit. Returns null on a miss,
        /// and also on a hit that is due for verification: then the caller runs OCR as usual and
        /// passes its result to OnOcrResult, which checks the entry.
        /// </summary>
        public string? Lookup(ReadOnlySpan<byte> bgra, int width, int height, int stride, out int linesMatched)
        {
            linesMatched = 0;
            lock (_lock)
            {
                _verifying = null;
                var memo = new Dictionary<(int, int, int, int), TextFingerprint?>();
                int tried = 0;
                for (var node = _entries.First; node != null && tried < MaxEntriesChecked; node = node.Next)
                {
                    var entry = node.Value;
                    if (entry.FrameW != width || entry.FrameH != height || entry.Lines.Length == 0)
                        continue;
                    tried++;

                    bool all = true;
                    for (int i = 0; i < entry.Lines.Length && all; i++)
                    {
                        var l = entry.Lines[i];
                        var box = (l.X, l.Y, l.W, l.H);
                        if (!memo.TryGetValue(box, out var print))
                        {
                            print = TextFingerprint.Compute(bgra, width, height, stride,
                                l.X - BoxPadding, l.Y - BoxPadding, l.W + 2 * BoxPadding, l.H + 2 * BoxPadding);
                            memo[box] = print;
                        }
                        all = print != null && entry.Prints[i].Matches(print);
                    }
                    if (!all)
                        continue;

                    MoveToFront(entry);
                    if (++_hitsSinceVerify >= VerifyEvery)
                    {
                        _hitsSinceVerify = 0;
                        _verifying = entry;
                        return null;
                    }
                    linesMatched = entry.Lines.Length;
                    return entry.OcrJson;
                }
            }
            return null;
        }

        /// <summary>
        /// A real OCR of the frame finished: remember its lines with their fingerprints. Returns false
        /// when a verified entry turned out wrong (it is removed).
        /// </summary>
        public bool OnOcrResult(string ocrJson, ReadOnlySpan<byte> bgra, int width, int height, int stride)
        {
            var lines = ParseLines(ocrJson).Where(IsLargeEnough).ToList();
            bool verifiedOk = true;
            lock (_lock)
            {
                if (_verifying != null)
                {
                    if (!SameText(Signature(_verifying.Lines), Signature(lines)))
                    {
                        Remove(_verifying);
                        verifiedOk = false;
                    }
                    _verifying = null;
                }
            }
            if (lines.Count == 0)
                return verifiedOk;

            var prints = new TextFingerprint[lines.Count];
            for (int i = 0; i < lines.Count; i++)
            {
                var l = lines[i];
                var p = TextFingerprint.Compute(bgra, width, height, stride,
                    l.X - BoxPadding, l.Y - BoxPadding, l.W + 2 * BoxPadding, l.H + 2 * BoxPadding);
                if (p == null)
                    return verifiedOk; // a box we could not fingerprint: do not store a partial entry
                prints[i] = p;
            }

            var entry = new Entry
            {
                FrameW = width,
                FrameH = height,
                Lines = lines.ToArray(),
                Prints = prints,
                OcrJson = ocrJson,
            };
            bool isNew;
            lock (_lock)
            {
                isNew = Add(entry);
            }
            if (isNew)
                Append(entry);
            return verifiedOk;
        }

        public void Clear()
        {
            lock (_lock)
            {
                _entries.Clear();
                _verifying = null;
            }
            if (_path != null)
            {
                try { File.Delete(_path); } catch { }
            }
        }

        // ---- internals ----

        private static bool IsLargeEnough(Line l) => l.W >= MinBoxWidth && l.H >= MinBoxHeight;

        // Returns false when the same picture with the same text was already stored
        private bool Add(Entry entry)
        {
            // Same picture already stored (same boxes give or take a pixel, matching fingerprints):
            // keep the newer OCR result instead of a duplicate
            int tried = 0;
            for (var node = _entries.First; node != null && tried < MaxEntriesChecked; node = node.Next, tried++)
            {
                var old = node.Value;
                if (!SamePicture(old, entry))
                    continue;
                bool changed = !SameText(Signature(old.Lines), Signature(entry.Lines));
                Remove(old);
                entry.Node = _entries.AddFirst(entry);
                return changed;
            }

            entry.Node = _entries.AddFirst(entry);
            if (_entries.Count > MaxEntries)
                Remove(_entries.Last!.Value);
            return true;
        }

        private static bool SamePicture(Entry a, Entry b)
        {
            if (a.FrameW != b.FrameW || a.FrameH != b.FrameH || a.Lines.Length != b.Lines.Length)
                return false;
            for (int i = 0; i < a.Lines.Length; i++)
            {
                Line x = a.Lines[i], y = b.Lines[i];
                if (Math.Abs(x.X - y.X) > SameBoxTolerance || Math.Abs(x.Y - y.Y) > SameBoxTolerance ||
                    Math.Abs(x.W - y.W) > SameBoxTolerance || Math.Abs(x.H - y.H) > SameBoxTolerance)
                    return false;
                // Boxes differ by a pixel, so the fingerprints may differ in width: compare the old
                // box's picture only when the widths agree, otherwise the boxes decide
                if (a.Prints[i].Width == b.Prints[i].Width && !a.Prints[i].Matches(b.Prints[i]))
                    return false;
            }
            return true;
        }

        private void Remove(Entry entry)
        {
            if (entry.Node != null && entry.Node.List == _entries)
                _entries.Remove(entry.Node);
            entry.Node = null;
        }

        private void MoveToFront(Entry entry)
        {
            if (entry.Node == null || entry.Node == _entries.First)
                return;
            _entries.Remove(entry.Node);
            _entries.AddFirst(entry.Node);
        }

        // OCR of the same picture varies a little between runs ("X" / "×"): 90% similar is the same text
        private static bool SameText(string a, string b)
        {
            if (a == b)
                return true;
            int maxLen = Math.Max(a.Length, b.Length);
            int limit = maxLen / 10;
            return FuzzyTextIndex.BoundedLevenshtein(a, b, limit) <= limit;
        }

        private static string Signature(IEnumerable<Line> lines) =>
            string.Join("\n", lines.Select(l => TextKey.Normalize(l.Text)));

        /// <summary>Lines (text + bounding box) of an OCR result in RST's JSON format.</summary>
        public static List<Line> ParseLines(string ocrJson)
        {
            var lines = new List<Line>();
            try
            {
                using var doc = JsonDocument.Parse(ocrJson);
                if (!doc.RootElement.TryGetProperty("results", out var results) || results.ValueKind != JsonValueKind.Array)
                    return lines;
                foreach (var item in results.EnumerateArray())
                {
                    string text = item.TryGetProperty("text", out var t) ? t.GetString() ?? "" : "";
                    if (string.IsNullOrWhiteSpace(text) || !item.TryGetProperty("rect", out var rect) || rect.ValueKind != JsonValueKind.Array)
                        continue;
                    double minX = double.MaxValue, minY = double.MaxValue, maxX = double.MinValue, maxY = double.MinValue;
                    foreach (var point in rect.EnumerateArray())
                    {
                        if (point.ValueKind != JsonValueKind.Array || point.GetArrayLength() < 2)
                            continue;
                        double px = point[0].GetDouble(), py = point[1].GetDouble();
                        minX = Math.Min(minX, px); minY = Math.Min(minY, py);
                        maxX = Math.Max(maxX, px); maxY = Math.Max(maxY, py);
                    }
                    if (minX > maxX)
                        continue;
                    lines.Add(new Line
                    {
                        X = (int)Math.Floor(minX),
                        Y = (int)Math.Floor(minY),
                        W = (int)Math.Ceiling(maxX - minX),
                        H = (int)Math.Ceiling(maxY - minY),
                        Text = text,
                    });
                }
            }
            catch (JsonException)
            {
            }
            return lines;
        }

        // ---- file: one JSON line per entry, appended; read back at start ----

        private sealed class Stored
        {
            public int fw { get; set; }
            public int fh { get; set; }
            public int[][] r { get; set; } = Array.Empty<int[]>();
            public string[] x { get; set; } = Array.Empty<string>();
            public int[] pw { get; set; } = Array.Empty<int>();
            public string[] p { get; set; } = Array.Empty<string>();
            public string j { get; set; } = "";
        }

        private void Append(Entry e)
        {
            if (_path == null)
                return;
            try
            {
                var s = new Stored
                {
                    fw = e.FrameW,
                    fh = e.FrameH,
                    r = e.Lines.Select(l => new[] { l.X, l.Y, l.W, l.H }).ToArray(),
                    x = e.Lines.Select(l => l.Text).ToArray(),
                    pw = e.Prints.Select(p => p.Width).ToArray(),
                    p = e.Prints.Select(p => p.ToBase64()).ToArray(),
                    j = e.OcrJson,
                };
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                File.AppendAllText(_path, JsonSerializer.Serialize(s) + "\n", new UTF8Encoding(false));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Image cache: could not write {_path}: {ex.Message}");
            }
        }

        private void Load()
        {
            if (_path == null || !File.Exists(_path))
                return;
            int lines = 0;
            try
            {
                foreach (string line in File.ReadLines(_path, Encoding.UTF8))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    lines++;
                    Stored? s;
                    try { s = JsonSerializer.Deserialize<Stored>(line); }
                    catch { continue; }
                    if (s == null || s.r.Length == 0 || s.r.Length != s.p.Length)
                        continue;
                    var entry = new Entry
                    {
                        FrameW = s.fw,
                        FrameH = s.fh,
                        Lines = s.r.Select((r, i) => new Line { X = r[0], Y = r[1], W = r[2], H = r[3], Text = s.x.ElementAtOrDefault(i) ?? "" }).ToArray(),
                        Prints = s.p.Select((p, i) => TextFingerprint.FromBase64(s.pw[i], p)).ToArray(),
                        OcrJson = s.j,
                    };
                    if (entry.Lines.All(IsLargeEnough))
                        Add(entry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Image cache: could not read {_path}: {ex.Message}");
            }

            // Rewrite without the replaced duplicates when they dominate
            if (lines > 100 && lines > _entries.Count * 2)
            {
                try
                {
                    string tmp = _path + ".tmp";
                    File.WriteAllText(tmp, "");
                    // Oldest first, so that loading puts the most recently used in front again
                    var all = _entries.Reverse().ToList();
                    string realPath = _path;
                    foreach (var e in all)
                    {
                        var s = new Stored
                        {
                            fw = e.FrameW, fh = e.FrameH,
                            r = e.Lines.Select(l => new[] { l.X, l.Y, l.W, l.H }).ToArray(),
                            x = e.Lines.Select(l => l.Text).ToArray(),
                            pw = e.Prints.Select(p => p.Width).ToArray(),
                            p = e.Prints.Select(p => p.ToBase64()).ToArray(),
                            j = e.OcrJson,
                        };
                        File.AppendAllText(tmp, JsonSerializer.Serialize(s) + "\n", new UTF8Encoding(false));
                    }
                    File.Move(tmp, realPath, overwrite: true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Image cache: compaction failed: {ex.Message}");
                }
            }
        }
    }
}
