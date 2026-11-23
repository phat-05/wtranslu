using System;
using System.IO;
using RSTGameTranslation.Layout;

namespace RSTGameTranslation
{
    /// <summary>
    /// The dictionary of the game being translated (see Layout.GameDictionary): the file
    /// GameDictionaries\&lt;game&gt;.&lt;target language&gt;.json next to rst.exe, for a known game (see
    /// GamePresets), and the player's own &lt;game&gt;.&lt;target language&gt;.user.json beside it, over
    /// it (never shipped, so an update keeps it). Reloaded when either file changes, so the player's
    /// additions apply at once.
    /// </summary>
    public static class GameDictionaries
    {
        public static string Folder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameDictionaries");

        private static readonly object _lock = new();
        private static string _path = "";
        private static (DateTime App, DateTime Player) _stamp;
        private static DateTime _lastCheck;
        private static GameDictionary? _dictionary;

        private static DateTime Stamp(string path) => File.Exists(path) ? File.GetLastWriteTimeUtc(path) : DateTime.MinValue;

        public static GameDictionary? Active
        {
            get
            {
                var preset = GamePresets.Active;
                if (preset == null)
                    return null;
                string name = $"{preset.Id}.{ConfigManager.Instance.GetTargetLanguage()}";
                string path = Path.Combine(Folder, name + ".json");
                string playerPath = Path.Combine(Folder, name + ".user.json");
                lock (_lock)
                {
                    if (path == _path && DateTime.UtcNow - _lastCheck < TimeSpan.FromSeconds(2))
                        return _dictionary;
                    _lastCheck = DateTime.UtcNow;
                    var stamp = (Stamp(path), Stamp(playerPath));
                    if (path == _path && stamp == _stamp)
                        return _dictionary;
                    _path = path;
                    _stamp = stamp;
                    _dictionary = null;
                    if (stamp.Item1 == DateTime.MinValue && stamp.Item2 == DateTime.MinValue)
                        return null;
                    try
                    {
                        string app = stamp.Item1 != DateTime.MinValue ? File.ReadAllText(path) : "{}";
                        string? player = stamp.Item2 != DateTime.MinValue ? File.ReadAllText(playerPath) : null;
                        _dictionary = GameDictionary.Parse(app, player);
                        Console.WriteLine($"Game dictionary: {path}{(player != null ? " + " + playerPath : "")} ({_dictionary.Count} entries)");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Game dictionary {name} could not be read: {ex.Message}");
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
