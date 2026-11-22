using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace RSTGameTranslation
{
    /// <summary>
    /// Unattended start for automated end-to-end tests (CI). Off unless the environment variable
    /// RST_AUTOMATION_WINDOW is set to the title of the window to translate. Then, once the main
    /// window is up, the startup dialogs are skipped, that window is selected (Windows Graphics
    /// Capture), the overlay is shown and translation is started — what a user would click by hand.
    /// </summary>
    public static class TestAutomation
    {
        public static string? WindowTitle { get; } = Environment.GetEnvironmentVariable("RST_AUTOMATION_WINDOW");

        public static bool IsEnabled => !string.IsNullOrEmpty(WindowTitle);

        // RST_AUTOMATION_WINDOW=@known: select nothing; RST must find a game it knows by itself, as
        // a user would see it (see MainWindow.KnownGames.cs)
        public static bool FindsKnownGame => WindowTitle == "@known";

        /// <summary>
        /// RST_AUTOMATION_CONFIG="key=value;key=value" overrides config values for this run only
        /// (languages, OCR method, translation service, ...). Not saved unless the app saves later.
        /// </summary>
        public static void ApplyConfigOverrides(System.Collections.Generic.Dictionary<string, string> configValues)
        {
            if (!IsEnabled)
                return;
            // Never show the first-run dialogs in a test run
            configValues["show_quick_start"] = "false";
            configValues["window_selector_at_startup"] = "false";
            string? overrides = Environment.GetEnvironmentVariable("RST_AUTOMATION_CONFIG");
            if (string.IsNullOrEmpty(overrides))
                return;
            foreach (string pair in overrides.Split(';', StringSplitOptions.RemoveEmptyEntries))
            {
                int eq = pair.IndexOf('=');
                if (eq <= 0)
                    continue;
                configValues[pair.Substring(0, eq).Trim()] = pair.Substring(eq + 1).Trim();
                Console.WriteLine($"[Automation] Config override {pair.Substring(0, eq).Trim()}");
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);

        public static async void Run(MainWindow mainWindow)
        {
            try
            {
                if (FindsKnownGame)
                {
                    Console.WriteLine("[Automation] Waiting for RST to find a known game by itself");
                    for (int i = 0; i < 120 && !mainWindow.isCapturingWindow; i++)
                        await Task.Delay(500);
                    if (!mainWindow.isCapturingWindow)
                    {
                        OcrTiming.Metrics.Write("automation_error", "known game not found");
                        return;
                    }
                    await Task.Delay(1500);
                    mainWindow.WindowState = System.Windows.WindowState.Minimized;
                    OcrTiming.Metrics.Write("automation_started", "@known");
                    return;
                }
                Console.WriteLine($"[Automation] Waiting for window '{WindowTitle}'");
                IntPtr handle = IntPtr.Zero;
                for (int i = 0; i < 120 && handle == IntPtr.Zero; i++)
                {
                    handle = FindWindow(null, WindowTitle!);
                    if (handle == IntPtr.Zero)
                        await Task.Delay(500);
                }
                if (handle == IntPtr.Zero)
                {
                    Console.WriteLine("[Automation] Window not found, giving up");
                    OcrTiming.Metrics.Write("automation_error", "window not found");
                    return;
                }

                mainWindow.SelectGameWindow(handle, WindowTitle!);
                await Task.Delay(500);
                mainWindow.AutomationShowOverlay();
                await Task.Delay(500);
                mainWindow.AutomationStart();
                // Out of the way of the game, so screenshots show the game with the overlay
                await Task.Delay(500);
                mainWindow.WindowState = System.Windows.WindowState.Minimized;
                Console.WriteLine("[Automation] Translation started");
                var vietnameseFonts = GameFonts.VietnameseFontNames();
                Console.WriteLine($"[Automation] {vietnameseFonts.Count} fonts with Vietnamese letters: {string.Join(", ", vietnameseFonts)}");
                OcrTiming.Metrics.Write("game_font", $"{GameIdentity.Current}|{GameFonts.Resolve().Source.Split(',')[0]}|{vietnameseFonts.Count} Vietnamese fonts");
                OcrTiming.Metrics.Write("automation_started", WindowTitle!);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Automation] Failed: {ex.Message}");
                OcrTiming.Metrics.Write("automation_error", ex.Message);
            }
        }
    }
}
