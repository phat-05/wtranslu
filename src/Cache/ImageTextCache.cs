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
            public string LayoutKey = "";
            public int FrameW, FrameH;
            public Line[] Lines = Array.Empty<Line>();
            public TextFingerprint[] Prints = Array.Empty<TextFingerprint>();
            public string OcrJson = "";
            public long LastUsed;
        }

        private sealed class Layout
        {
            public string Key = "";
            public int FrameW, FrameH;
            public Line[] Lines = Array.Empty<Line>();
            public readonly List<Entry> Entries = new();
        }

        public const int VerifyEvery = 8;
        private const int MaxLayoutsChecked = 8;
        private const int MaxEntries = 3000;
        private const int BoxPadding = 2;

        private readonly Dictionary<string, Layout> _layouts = new();
        private readonly LinkedList<string> _recentLayouts = new(); // most recent first
        private readonly object _lock = new();
        private readonly string? _path;
        private int _entryCount;
        private long _clock;
        private int _hitsSinceVerify;
        private Entry? _verifying;

        public int Count { get { lock (_lock) return _entryCount; } }

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
                int checkedLayouts = 0;
                foreach (string key in _recentLayouts)
                {
                    if (++checkedLayouts > MaxLayoutsChecked)
                        break;
                    var layout = _layouts[key];
                    if (layout.FrameW != width || layout.FrameH != height || layout.Entries.Count == 0)
                        continue;

                    var prints = new TextFingerprint?[layout.Lines.Length];
                    bool readable = true;
                    for (int i = 0; i < layout.Lines.Length && readable; i++)
                    {
                        var l = layout.Lines[i];
                        prints[i] = TextFingerprint.Compute(bgra, width, height, stride,
                            l.X - BoxPadding, l.Y - BoxPadding, l.W + 2 * BoxPadding, l.H + 2 * BoxPadding);
                        readable = prints[i] != null;
                    }
                    if (!readable)
                        continue;

                    foreach (var entry in layout.Entries)
                    {
                        bool all = true;
                        for (int i = 0; i < prints.Length && all; i++)
                            all = entry.Prints[i].Matches(prints[i]!);
                        if (!all)
                            continue;

                        Touch(layout.Key);
                        entry.LastUsed = ++_clock;
                        if (++_hitsSinceVerify >= VerifyEvery)
                        {
                            _hitsSinceVerify = 0;
                            _verifying = entry;
                            return null;
                        }
                        linesMatched = prints.Length;
                        return entry.OcrJson;
                    }
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
            var lines = ParseLines(ocrJson);
            bool verifiedOk = true;
            lock (_lock)
            {
                if (_verifying != null)
                {
                    string expected = Signature(_verifying.Lines);
                    string actual = Signature(lines);
                    if (expected != actual)
                    {
                        RemoveEntry(_verifying);
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
                _layouts.Clear();
                _recentLayouts.Clear();
                _entryCount = 0;
                _verifying = null;
            }
            if (_path != null)
            {
                try { File.Delete(_path); } catch { }
            }
        }

        // ---- internals ----

        // Returns false when the same picture with the same text was already stored
        private bool Add(Entry entry)
        {
            entry.LayoutKey = LayoutKey(entry.FrameW, entry.FrameH, entry.Lines);
            entry.LastUsed = ++_clock;
            if (!_layouts.TryGetValue(entry.LayoutKey, out var layout))
            {
                layout = new Layout { Key = entry.LayoutKey, FrameW = entry.FrameW, FrameH = entry.FrameH, Lines = entry.Lines };
                _layouts[layout.Key] = layout;
            }

            // Same picture already stored: keep the newer OCR result instead of a duplicate
            int same = layout.Entries.FindIndex(e => e.Prints.Zip(entry.Prints).All(p => p.First.Matches(p.Second)));
            bool isNew = true;
            if (same >= 0)
            {
                isNew = Signature(layout.Entries[same].Lines) != Signature(entry.Lines);
                layout.Entries[same] = entry;
            }
            else
            {
                layout.Entries.Add(entry);
                _entryCount++;
            }
            Touch(layout.Key);

            if (_entryCount > MaxEntries)
                RemoveEntry(_layouts.Values.SelectMany(l => l.Entries).OrderBy(e => e.LastUsed).First());
            return isNew;
        }

        private void RemoveEntry(Entry entry)
        {
            if (_layouts.TryGetValue(entry.LayoutKey, out var layout) && layout.Entries.Remove(entry))
            {
                _entryCount--;
                if (layout.Entries.Count == 0)
                {
                    _layouts.Remove(layout.Key);
                    _recentLayouts.Remove(layout.Key);
                }
            }
        }

        private void Touch(string layoutKey)
        {
            _recentLayouts.Remove(layoutKey);
            _recentLayouts.AddFirst(layoutKey);
        }

        // Boxes rounded to 4 px, so the same layout read with a pixel of jitter is still one layout
        private static string LayoutKey(int frameW, int frameH, Line[] lines)
        {
            var sb = new StringBuilder();
            sb.Append(frameW).Append('x').Append(frameH);
            foreach (var l in lines)
                sb.Append('|').Append(l.X / 4).Append(',').Append(l.Y / 4).Append(',').Append(l.W / 4).Append(',').Append(l.H / 4);
            return sb.ToString();
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
                    Add(entry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Image cache: could not read {_path}: {ex.Message}");
            }

            // Rewrite without the replaced duplicates when they dominate
            if (lines > 100 && lines > _entryCount * 2)
            {
                try
                {
                    string tmp = _path + ".tmp";
                    File.WriteAllText(tmp, "");
                    var all = _layouts.Values.SelectMany(l => l.Entries).OrderBy(e => e.LastUsed).ToList();
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
