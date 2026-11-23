using System;
using System.IO;
using RSTGameTranslation.Layout;

namespace RSTGameTranslation
{
    /// <summary>
    /// The dictionary of the game being translated (see Layout.GameDictionary): the file
    /// GameDictionaries\&lt;game&gt;.&lt;target language&gt;.json next to rst.exe, for a known game (see
    /// GamePresets). Reloaded when the file changes, so the player's own additions apply at once.
    /// </summary>
    public static class GameDictionaries
    {
        public static string Folder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameDictionaries");

        private static readonly object _lock = new();
        private static string _path = "";
        private static DateTime _stamp;
        private static DateTime _lastCheck;
        private static GameDictionary? _dictionary;

        public static GameDictionary? Active
        {
            get
            {
                var preset = GamePresets.Active;
                if (preset == null)
                    return null;
                string path = Path.Combine(Folder, $"{preset.Id}.{ConfigManager.Instance.GetTargetLanguage()}.json");
                lock (_lock)
                {
                    if (path == _path && DateTime.UtcNow - _lastCheck < TimeSpan.FromSeconds(2))
                        return _dictionary;
                    _lastCheck = DateTime.UtcNow;
                    DateTime stamp = File.Exists(path) ? File.GetLastWriteTimeUtc(path) : DateTime.MinValue;
                    if (path == _path && stamp == _stamp)
                        return _dictionary;
                    _path = path;
                    _stamp = stamp;
                    _dictionary = null;
                    if (stamp == DateTime.MinValue)
                        return null;
                    try
                    {
                        _dictionary = GameDictionary.Parse(File.ReadAllText(path));
                        Console.WriteLine($"Game dictionary: {path} ({_dictionary.Count} entries)");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Game dictionary {path} could not be read: {ex.Message}");
                    }
                    return _dictionary;
                }
            }
        }

        public static bool TryTranslate(string text, out string translation)
        {
            translation = "";
            return Active?.TryTranslate(text, out translation) == true;
        }

        public static bool IsKept(string text) => Active?.IsKept(text) == true;
    }
}
