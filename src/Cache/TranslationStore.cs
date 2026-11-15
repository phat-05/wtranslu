using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RSTGameTranslation.Cache
{
    /// <summary>How a cached translation was found.</summary>
    public enum CacheMatch { None, Exact, Fuzzy }

    /// <summary>
    /// The text tier of the cache for one game and one language pair, kept in memory and in a file.
    ///
    /// Key = the normalized sentence (see TextKey). Each key keeps one translation per translation
    /// service; a lookup prefers the service in use and otherwise takes the most recent one.
    ///
    /// File format: JSON Lines, one translation per line, only ever appended to (a crash can at worst
    /// lose the last line, never the file). On load, later lines win; when the file holds many
    /// overwritten lines it is rewritten compactly. Lines can be edited by hand to fix a translation.
    /// Writes happen on a background task so the translation pipeline never waits for the disk.
    /// </summary>
    public sealed class TranslationStore : IDisposable
    {
        public sealed class Record
        {
            public string k { get; set; } = "";   // normalized key
            public string o { get; set; } = "";   // original OCR text (first seen)
            public string t { get; set; } = "";   // translation
            public string s { get; set; } = "";   // translation service
            public long u { get; set; }            // updated, unix ms
        }

        private sealed class Entry
        {
            public string Original = "";
            public readonly Dictionary<string, (string Text, long Updated)> ByService = new();
        }

        private readonly Dictionary<string, Entry> _entries = new();
        private readonly FuzzyTextIndex _fuzzy = new();
        private readonly object _lock = new();
        private readonly ConcurrentQueue<string> _pendingLines = new();
        private readonly SemaphoreSlim _writeSignal = new(0);
        private readonly CancellationTokenSource _stop = new();
        private readonly Task? _writer;
        private readonly string? _path;

        public string? FilePath => _path;
        public int Count { get { lock (_lock) return _entries.Count; } }

        /// <param name="path">File to load and append to; null keeps the store in memory only.</param>
        public TranslationStore(string? path)
        {
            _path = path;
            if (_path != null)
            {
                Load();
                _writer = Task.Run(WriterLoop);
            }
        }

        public bool TryGet(string text, string preferredService, bool allowFuzzy, double fuzzyThreshold,
                           out string translation, out CacheMatch match, out double similarity)
        {
            translation = "";
            match = CacheMatch.None;
            similarity = 0;
            string key = TextKey.Normalize(text);
            if (key.Length == 0)
                return false;

            lock (_lock)
            {
                if (_entries.TryGetValue(key, out var entry) && Pick(entry, preferredService, out translation))
                {
                    match = CacheMatch.Exact;
                    similarity = 1;
                    return true;
                }
                if (!allowFuzzy)
                    return false;
                string? near = _fuzzy.FindBest(key, fuzzyThreshold, out similarity);
                if (near != null && _entries.TryGetValue(near, out entry) && Pick(entry, preferredService, out translation))
                {
                    match = CacheMatch.Fuzzy;
                    return true;
                }
            }
            similarity = 0;
            return false;
        }

        public void Set(string text, string translation, string service)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(translation))
                return;
            string key = TextKey.Normalize(text);
            if (key.Length == 0)
                return;
            long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            lock (_lock)
            {
                if (!_entries.TryGetValue(key, out var entry))
                {
                    _entries[key] = entry = new Entry { Original = text };
                    _fuzzy.Add(key);
                }
                else if (entry.ByService.TryGetValue(service, out var existing) && existing.Text == translation)
                {
                    return; // nothing new to write
                }
                entry.ByService[service] = (translation, now);
            }

            if (_path != null)
            {
                _pendingLines.Enqueue(JsonSerializer.Serialize(new Record { k = key, o = text, t = translation, s = service, u = now }));
                _writeSignal.Release();
            }
        }

        public void Remove(string text)
        {
            string key = TextKey.Normalize(text);
            lock (_lock)
            {
                if (_entries.Remove(key))
                    _fuzzy.Remove(key);
            }
            if (_path != null)
            {
                // An empty translation marks the key as deleted for the next load
                _pendingLines.Enqueue(JsonSerializer.Serialize(new Record { k = key, u = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }));
                _writeSignal.Release();
            }
        }

        public void ClearAll()
        {
            lock (_lock)
            {
                _entries.Clear();
                _fuzzy.Clear();
            }
            if (_path != null)
            {
                Flush();
                try { File.Delete(_path); } catch { }
            }
        }

        private static bool Pick(Entry entry, string preferredService, out string translation)
        {
            if (entry.ByService.TryGetValue(preferredService, out var mine))
            {
                translation = mine.Text;
                return true;
            }
            if (entry.ByService.Count > 0)
            {
                translation = entry.ByService.Values.OrderByDescending(v => v.Updated).First().Text;
                return true;
            }
            translation = "";
            return false;
        }

        // ---- file ----

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
                    Record? r;
                    try { r = JsonSerializer.Deserialize<Record>(line); }
                    catch { continue; } // a half-written last line after a crash
                    if (r == null || string.IsNullOrEmpty(r.k))
                        continue;
                    // Hand-edited files may hold keys that are not normalized yet
                    string key = TextKey.Normalize(r.k);
                    if (string.IsNullOrEmpty(r.t))
                    {
                        if (_entries.Remove(key))
                            _fuzzy.Remove(key);
                        continue;
                    }
                    if (!_entries.TryGetValue(key, out var entry))
                    {
                        _entries[key] = entry = new Entry { Original = r.o };
                        _fuzzy.Add(key);
                    }
                    entry.ByService[r.s ?? ""] = (r.t, r.u);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Translation cache: could not read {_path}: {ex.Message}");
                return;
            }

            int live = _entries.Values.Sum(e => e.ByService.Count);
            if (lines > 200 && lines > live * 3 / 2)
                Compact();
        }

        // Rewrite the file with one line per live translation (via a temp file, then an atomic move)
        private void Compact()
        {
            if (_path == null)
                return;
            try
            {
                string tmp = _path + ".tmp";
                using (var w = new StreamWriter(tmp, false, new UTF8Encoding(false)))
                {
                    foreach (var (key, entry) in _entries)
                        foreach (var (service, value) in entry.ByService)
                            w.WriteLine(JsonSerializer.Serialize(new Record { k = key, o = entry.Original, t = value.Text, s = service, u = value.Updated }));
                }
                File.Move(tmp, _path, overwrite: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Translation cache: compaction failed: {ex.Message}");
            }
        }

        private async Task WriterLoop()
        {
            while (!_stop.IsCancellationRequested)
            {
                try
                {
                    await _writeSignal.WaitAsync(_stop.Token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                WritePending();
            }
            WritePending();
        }

        private readonly object _fileLock = new();

        private void WritePending()
        {
            if (_path == null || _pendingLines.IsEmpty)
                return;
            lock (_fileLock)
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                    var sb = new StringBuilder();
                    while (_pendingLines.TryDequeue(out string? line))
                        sb.Append(line).Append('\n');
                    File.AppendAllText(_path, sb.ToString(), new UTF8Encoding(false));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Translation cache: could not write {_path}: {ex.Message}");
                }
            }
        }

        /// <summary>Writes everything still queued, now (used on exit and in tests).</summary>
        public void Flush() => WritePending();

        public void Dispose()
        {
            _stop.Cancel();
            try { _writer?.Wait(2000); } catch { }
            WritePending();
        }
    }
}
