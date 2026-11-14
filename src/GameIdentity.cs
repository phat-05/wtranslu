using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace RSTGameTranslation
{
    /// <summary>
    /// Which game is being translated, for per-game data (the translation cache files):
    /// the game profile loaded in Settings if any, otherwise the program (exe) name of the selected
    /// game window, otherwise "default" (a screen area with no window and no profile).
    /// </summary>
    public static class GameIdentity
    {
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        private static IntPtr _cachedHandle;
        private static string _cachedName = "";

        public static string Current
        {
            get
            {
                string profile = ConfigManager.Instance.GetCurrentGameProfile();
                if (!string.IsNullOrWhiteSpace(profile))
                    return profile;

                IntPtr handle = MainWindow.Instance?.CapturedWindowHandle ?? IntPtr.Zero;
                if (handle != IntPtr.Zero)
                {
                    if (handle == _cachedHandle)
                        return _cachedName;
                    string name = ProcessNameOf(handle);
                    if (name.Length > 0)
                    {
                        _cachedHandle = handle;
                        _cachedName = name;
                        return name;
                    }
                }
                return "default";
            }
        }

        private static string ProcessNameOf(IntPtr handle)
        {
            try
            {
                GetWindowThreadProcessId(handle, out uint pid);
                using var process = Process.GetProcessById((int)pid);
                return process.ProcessName;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>The name with characters that are not allowed in file names replaced.</summary>
        public static string FileSafe(string name)
        {
            char[] invalid = Path.GetInvalidFileNameChars();
            string safe = new string(name.Select(c => invalid.Contains(c) || c == '.' ? '_' : c).ToArray()).Trim();
            return safe.Length == 0 ? "default" : safe;
        }
    }
}
