using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using RSTGameTranslation.Layout;

namespace RSTGameTranslation
{
    /// <summary>
    /// Games the app knows (see Layout.GamePresets, today Wuthering Waves): their window is found by
    /// itself, at startup or whenever the game is started later, and translation starts with no
    /// clicks: the window is captured, the game's dialogue and answer-choice areas are set, the
    /// overlay shown and translation started. The Game Mode hotkey (Alt+M) switches between the
    /// dialogue areas and the full screen (menus, items, quests).
    /// </summary>
    public partial class MainWindow
    {
        private GamePreset? _activePreset;
        private GameCaptureMode _gameMode = GameCaptureMode.Dialogue;
        private DispatcherTimer? _knownGameTimer;
        private (int W, int H) _gameClientSize;
        private bool _gameTipShown;
        // The translation areas are the preset's (not drawn by the user)
        private bool _presetAreasActive;

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);


        /// <summary>Begins watching for known games (call once the main window is up).</summary>
        private void StartKnownGameWatcher()
        {
            if (_knownGameTimer != null || TestAutomation.IsEnabled && Environment.GetEnvironmentVariable("RST_AUTOMATION_KNOWN_GAMES") != "1")
                return;
            KeyboardShortcuts.GameModeToggleRequested += (s, e) => Dispatcher.Invoke(ToggleGameMode);
            _knownGameTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            _knownGameTimer.Tick += (s, e) => KnownGameTick();
            _knownGameTimer.Start();
        }

        // Every 2 s: start with a known game when nothing is selected yet; follow its window's size
        private void KnownGameTick()
        {
            try
            {
                if (_activePreset != null && isCapturingWindow && capturedWindowHandle != IntPtr.Zero)
                {
                    if (!_presetAreasActive)
                        return;
                    // Resolution changed in the game: the areas follow
                    var size = ClientSize(capturedWindowHandle);
                    if (size.W > 0 && size != _gameClientSize)
                        ApplyGameMode(_gameMode, notify: false);
                    return;
                }
                if (!isCapturingWindow)
                    _activePreset = null;
                if (isCapturingWindow || isSelectingTranslationArea || !IsLoaded ||
                    !ConfigManager.Instance.IsAutoStartKnownGamesEnabled())
                    return;
                TryAutoStartKnownGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Known game check failed: {ex.Message}");
            }
        }

        /// <summary>Finds a running known game and starts translating it. True when one was started.</summary>
        private bool TryAutoStartKnownGame()
        {
            if (!ConfigManager.Instance.IsAutoStartKnownGamesEnabled() || isCapturingWindow)
                return false;
            var found = FindKnownGameWindow();
            if (found == null)
                return false;
            var (handle, title, preset) = found.Value;
            Console.WriteLine($"Known game found: {preset.Name} ('{title}')");
            OcrTiming.Metrics.Write("known_game", $"{preset.Id}|{title}");
            OnWindowSelected(handle, title, showConfirmation: false);
            if (!IsOverlayShown)
                ToggleMonitorWindow();
            if (!isStarted)
                OnStartButtonToggleClicked(toggleButton, new RoutedEventArgs());
            return true;
        }

        /// <summary>
        /// A window was selected (by hand or by the watcher): when it is a known game, its preset is
        /// applied (settings for the session, and its dialogue areas unless the user chose areas).
        /// </summary>
        private void OnGameWindowSelected(IntPtr handle, string title)
        {
            var preset = GamePresets.Find(title, ProcessNameOfWindow(handle));
            if (preset == null)
            {
                _activePreset = null;
                return;
            }
            _activePreset = preset;
            foreach (var (key, value) in preset.Settings)
                ConfigManager.Instance.SetValue(key, value);
            _gameMode = GameCaptureMode.Dialogue;
            // Areas the user drew for this game are kept; the Game Mode hotkey still switches to the preset's
            if (!hasSelectedTranslationArea || _presetAreasActive)
                ApplyGameMode(_gameMode, notify: false);
            if (!_gameTipShown)
            {
                _gameTipShown = true;
                bool vietnamese = LocalizationManager.Instance.CurrentLanguage?.StartsWith("vi", StringComparison.OrdinalIgnoreCase) == true;
                string tip = string.Format(vietnamese ? preset.TipVi : preset.TipEn,
                    ConfigManager.Instance.GetHotKey("Game Mode"), ConfigManager.Instance.GetHotKey("Start/Stop"));
                ShowFastNotification(preset.Name, tip, 9000);
            }
        }

        /// <summary>Game Mode hotkey: the game's dialogue areas or its full screen.</summary>
        private void ToggleGameMode()
        {
            if (_activePreset == null || !isCapturingWindow)
                return;
            _gameMode = _gameMode == GameCaptureMode.Dialogue ? GameCaptureMode.Full : GameCaptureMode.Dialogue;
            ApplyGameMode(_gameMode, notify: true);
        }

        private void ApplyGameMode(GameCaptureMode mode, bool notify)
        {
            if (_activePreset == null || capturedWindowHandle == IntPtr.Zero)
                return;
            var (left, top, width, height) = ClientRectOnScreen(capturedWindowHandle);
            if (width <= 0 || height <= 0)
                return;
            _gameClientSize = (width, height);

            DpiHelper.GetDpiForWindowHandle(capturedWindowHandle, out double dpiX, out double dpiY);
            var screens = System.Windows.Forms.Screen.AllScreens;
            var screen = System.Windows.Forms.Screen.FromHandle(capturedWindowHandle);
            int screenIndex = Math.Max(0, Array.IndexOf(screens, screens.FirstOrDefault(s => s.DeviceName == screen.DeviceName)));

            var areas = _activePreset.Areas(mode)
                .Select(r => GamePresets.ToScreen(r, left, top, width, height))
                .Select(a => new TranslationAreaInfo(new Rect(Math.Round(a.X), Math.Round(a.Y), Math.Round(a.W), Math.Round(a.H)),
                                                     screenIndex, dpiX, dpiY, screen.DeviceName))
                .ToList();
            bool multi = areas.Count > 1;
            if (ConfigManager.Instance.IsMultiSelectionAreaEnabled() != multi)
                ConfigManager.Instance.SetUseMultiSelectionArea(multi);
            SetTranslationAreas(areas);
            _presetAreasActive = true;
            Console.WriteLine($"{_activePreset.Name}: {mode} mode, {areas.Count} area(s) in a {width}x{height} window");
            OcrTiming.Metrics.Write("game_mode", $"{_activePreset.Id}|{mode}|{width}x{height}|" +
                string.Join(";", areas.Select(a => $"{a.X:F0},{a.Y:F0},{a.Width:F0},{a.Height:F0}")));
            if (notify)
            {
                ShowFastNotification(_activePreset.Name, LocalizationManager.Instance.Strings[
                    mode == GameCaptureMode.Dialogue ? "Msg_GameModeDialogue" : "Msg_GameModeFull"], 2500);
            }
        }

        private static (IntPtr Handle, string Title, GamePreset Preset)? FindKnownGameWindow()
        {
            (IntPtr, string, GamePreset)? found = null;
            EnumWindows((hwnd, _) =>
            {
                if (!IsWindowVisible(hwnd) || IsIconic(hwnd))
                    return true;
                var text = new StringBuilder(256);
                if (GetWindowText(hwnd, text, text.Capacity) <= 0)
                    return true;
                string title = text.ToString();
                // Cheap title test first; the process name only for candidates
                if (!GamePresets.All.Any(p => p.TitleKeywords.Any(k => title.Contains(k, StringComparison.OrdinalIgnoreCase))))
                    return true;
                var preset = GamePresets.Find(title, ProcessNameOfWindow(hwnd));
                if (preset == null)
                    return true;
                found = (hwnd, title, preset);
                return false;
            }, IntPtr.Zero);
            return found;
        }

        private static string ProcessNameOfWindow(IntPtr hwnd)
        {
            try
            {
                GetWindowThreadProcessId(hwnd, out uint pid);
                using var process = Process.GetProcessById((int)pid);
                return process.ProcessName;
            }
            catch
            {
                return "";
            }
        }

        // The game's drawing area (no title bar or borders) in physical screen pixels
        private static (int Left, int Top, int Width, int Height) ClientRectOnScreen(IntPtr hwnd)
        {
            if (!GetClientRect(hwnd, out RECT client))
                return (0, 0, 0, 0);
            var origin = new System.Drawing.Point();
            if (!ClientToScreen(hwnd, ref origin))
                return (0, 0, 0, 0);
            return (origin.X, origin.Y, client.Right - client.Left, client.Bottom - client.Top);
        }

        private static (int W, int H) ClientSize(IntPtr hwnd) =>
            GetClientRect(hwnd, out RECT client) ? (client.Right - client.Left, client.Bottom - client.Top) : (0, 0);
    }
}
