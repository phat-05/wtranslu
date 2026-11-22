using System;
using System.Collections.Generic;
using System.Linq;

namespace RSTGameTranslation.Layout
{
    /// <summary>A rectangle as fractions (0..1) of a game's 16:9 screen.</summary>
    public readonly record struct RelRect(double X, double Y, double W, double H);

    /// <summary>What the game's mode captures: the text the player reads most, or everything.</summary>
    public enum GameCaptureMode { Dialogue, Full }

    /// <summary>
    /// Ready-made settings for a game the app knows: how to recognise its window, where its text
    /// is on screen, and what to leave out. With one, the app finds the game by itself and starts
    /// translating without any setup.
    /// </summary>
    public sealed class GamePreset
    {
        public string Id { get; init; } = "";
        public string Name { get; init; } = "";
        // Executable names without ".exe" (any of them)
        public string[] ProcessNames { get; init; } = Array.Empty<string>();
        // Words in the window title (any of them); with process names too, both must match
        public string[] TitleKeywords { get; init; } = Array.Empty<string>();
        // Dialogue mode: where the game shows dialogue lines and the player's answer choices
        public RelRect[] DialogueAreas { get; init; } = Array.Empty<RelRect>();
        // Full mode: the whole screen but these strips (the player's ID, HUD corners)
        public RelRect[] FullAreas { get; init; } = Array.Empty<RelRect>();
        // Proper names the game uses: kept as they are in the translation
        public string[] KeepTerms { get; init; } = Array.Empty<string>();
        // Config values that suit the game (key=value), applied for this session
        public Dictionary<string, string> Settings { get; init; } = new();
        // Shown once when the game is found (how to set it up for the overlay)
        public string TipVi { get; init; } = "";
        public string TipEn { get; init; } = "";

        public bool Matches(string windowTitle, string processName)
        {
            string title = windowTitle ?? "";
            string process = (processName ?? "").Trim();
            if (process.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                process = process[..^4];
            bool titleOk = TitleKeywords.Any(k => title.Contains(k, StringComparison.OrdinalIgnoreCase));
            bool processOk = ProcessNames.Any(p => p.Equals(process, StringComparison.OrdinalIgnoreCase));
            // A generic Unreal executable name (Client-Win64-Shipping) alone is not enough
            return titleOk && (ProcessNames.Length == 0 || processOk || process.Length == 0);
        }

        public RelRect[] Areas(GameCaptureMode mode) => mode == GameCaptureMode.Dialogue ? DialogueAreas : FullAreas;
    }

    public static class GamePresets
    {
        /// <summary>
        /// Wuthering Waves (Kuro Games). Dialogue: speaker name and lines centred at the bottom of the
        /// screen, answer choices stacked on the right. The player's UID sits in the bottom-right
        /// corner on every screen and the menu icons along the top: full mode leaves both out.
        /// The game must run windowed or borderless for an overlay to show above it.
        /// </summary>
        public static readonly GamePreset WutheringWaves = new()
        {
            Id = "wuthering-waves",
            Name = "Wuthering Waves",
            ProcessNames = new[] { "Client-Win64-Shipping", "Wuthering Waves" },
            TitleKeywords = new[] { "Wuthering Waves", "鸣潮", "鳴潮", "명조" },
            DialogueAreas = new[]
            {
                new RelRect(0.13, 0.735, 0.74, 0.215), // speaker name + dialogue lines
                new RelRect(0.58, 0.34, 0.39, 0.42),   // answer choices
            },
            FullAreas = new[]
            {
                new RelRect(0.0, 0.06, 1.0, 0.905),    // all but the top icon bar and the UID line
            },
            KeepTerms = new[]
            {
                "Rover", "Resonator", "Resonators", "Tacet Discord", "Tacet Field", "Echo", "Echoes", "Waveplate", "Waveplates",
                "Solaris-3", "Jinzhou", "Huanglong", "Rinascita", "Lahai-Roi", "Black Shores", "Mt. Firmament",
                "Abby", "Yangyang", "Chixia", "Baizhi", "Sanhua", "Jiyan", "Jianxin", "Yinlin", "Encore", "Lingyang",
                "Calcharo", "Verina", "Danjin", "Aalto", "Mortefi", "Taoqi", "Yuanwu", "Changli", "Jinhsi", "Zhezhi",
                "Xiangli Yao", "Shorekeeper", "Camellya", "Carlotta", "Roccia", "Phoebe", "Brant", "Cantarella", "Zani",
                "Ciaccona", "Cartethyia", "Lupa", "Phrolova", "Augusta", "Iuno", "Scar", "Rover's", "Magistrate",
                "Tethys", "Lollo", "Union Level", "Data Bank", "Forte Circuit", "Resonance Chain",
            },
            Settings = new()
            {
                // Lines type out letter by letter: wait for each line to finish before translating
                ["block_detection_settle_time"] = "0.25",
            },
            TipVi = "Đã nhận Wuthering Waves và bắt đầu dịch phần hội thoại. Để bản dịch hiện trên game, đặt WuWa ở chế độ Cửa sổ hoặc Toàn màn hình không viền (Cài đặt > Đồ họa > Chế độ hiển thị). {0}: chuyển Hội thoại / Toàn màn hình. {1}: tạm dừng.",
            TipEn = "Wuthering Waves found: translating the dialogue. For the overlay to show above the game, run WuWa windowed or borderless (Settings > Graphics > Display Mode). {0}: switch Dialogue / Full screen. {1}: pause.",
        };

        public static readonly IReadOnlyList<GamePreset> All = new[] { WutheringWaves };

        public static GamePreset? Find(string windowTitle, string processName) =>
            All.FirstOrDefault(p => p.Matches(windowTitle, processName));

        /// <summary>
        /// Screen rectangle (same units as the window's) of an area: the game draws its interface in a
        /// 16:9 box centred in the window (wider screens get bars of scenery left and right, taller
        /// ones above and below), so the fractions are of that box.
        /// </summary>
        public static (double X, double Y, double W, double H) ToScreen(RelRect r, double windowX, double windowY, double windowW, double windowH)
        {
            double boxW = Math.Min(windowW, windowH * 16 / 9);
            double boxH = Math.Min(windowH, windowW * 9 / 16);
            double boxX = windowX + (windowW - boxW) / 2;
            double boxY = windowY + (windowH - boxH) / 2;
            return (boxX + r.X * boxW, boxY + r.Y * boxH, r.W * boxW, r.H * boxH);
        }
    }
}
