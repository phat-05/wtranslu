using System;
using System.IO;
using RSTGameTranslation.Cache;

namespace RSTGameTranslation
{
    /// <summary>
    /// Translations of text seen before (menus, repeated lines, text that flickers out and back in),
    /// shown instantly instead of going through the translation service.
    ///
    /// The cache belongs to one game and one language pair (the "context"). It is kept on disk per
    /// game (Cache\&lt;game&gt;.&lt;source&gt;-&lt;target&gt;.jsonl next to rst.exe), so it survives restarts and
    /// grows into a translation memory of the game. A sentence OCR'd slightly differently still finds
    /// its translation (see TextKey and FuzzyTextIndex). Each translation remembers its service; the
    /// service in use is preferred, another one's translation is used when there is no own one.
    /// </summary>
    public sealed class TranslationCache
    {
        public static TranslationCache Instance { get; } = new TranslationCache();

        private readonly object _lock = new object();
        private TranslationStore _store = new TranslationStore(null);
        private string _context = "";
        private string _storeScope = "";
        private string _service = "";
        private bool _persistent;

        public static string CacheFolder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache");

        /// <summary>
        /// Switch to the given context, made by BuildContext. A different game or language pair loads
        /// that game's cache file; a different service only changes which translation is preferred.
        /// </summary>
        public void UseContext(string context)
        {
            lock (_lock)
            {
                bool persistent = ConfigManager.Instance.IsTranslationCachePersistent();
                if (context == _context && persistent == _persistent)
                    return;
                _context = context;

                string[] parts = context.Split('\u001F');
                string game = parts.Length > 0 ? parts[0] : "";
                string scope = parts.Length > 2 ? $"{GameIdentity.FileSafe(game)}.{parts[1]}-{parts[2]}" : context;
                _service = parts.Length > 3 ? parts[3] : "";

                if (scope != _storeScope || persistent != _persistent)
                {
                    _store.Dispose();
                    _store = new TranslationStore(persistent ? Path.Combine(CacheFolder, scope + ".jsonl") : null);
                    _storeScope = scope;
                    _persistent = persistent;
                    Console.WriteLine($"Translation cache: {(persistent ? _store.FilePath : "memory only")} ({_store.Count} entries)");
                }
            }
        }

        public static string BuildContext(string game, string sourceLanguage, string targetLanguage, string service) =>
            string.Join("\u001F", game, sourceLanguage, targetLanguage, service);

        public bool TryGet(string text, out string translation) => TryGet(text, out translation, out _, out _);

        public bool TryGet(string text, out string translation, out CacheMatch match, out double similarity)
        {
            TranslationStore store;
            string service;
            lock (_lock)
            {
                store = _store;
                service = _service;
            }
            bool fuzzy = ConfigManager.Instance.IsTranslationCacheFuzzyEnabled();
            double threshold = ConfigManager.Instance.GetTranslationCacheFuzzyThreshold();
            return store.TryGet(text, service, fuzzy, threshold, out translation, out match, out similarity);
        }

        public void Set(string text, string translation)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(translation))
                return;
            TranslationStore store;
            string service;
            lock (_lock)
            {
                store = _store;
                service = _service;
            }
            store.Set(text, translation, service);
        }

        // Store only if the cache is still on the given context, for results that arrive late
        // (a prefetch started before the user changed the language, game, ...)
        public void SetIfContext(string context, string text, string translation)
        {
            lock (_lock)
            {
                if (context != _context)
                    return;
            }
            Set(text, translation);
        }

        public string Context
        {
            get { lock (_lock) return _context; }
        }

        public int Count
        {
            get { lock (_lock) return _store.Count; }
        }

        public string? FilePath
        {
            get { lock (_lock) return _store.FilePath; }
        }

        /// <summary>Forget the loaded cache (the file stays); the next UseContext loads it again.</summary>
        public void Clear()
        {
            lock (_lock)
            {
                _store.Dispose();
                _store = new TranslationStore(null);
                _context = "";
                _storeScope = "";
            }
        }

        /// <summary>Delete the current game's cached translations, in memory and on disk.</summary>
        public void DeleteCurrent()
        {
            lock (_lock)
            {
                _store.ClearAll();
            }
        }

        /// <summary>Write what is still queued (on exit).</summary>
        public void Flush()
        {
            lock (_lock)
            {
                _store.Flush();
            }
        }
    }
}
