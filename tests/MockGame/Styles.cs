using System.Text.Json;

namespace MockGame;

/// <summary>
/// How each kind of text is drawn. The drawing code uses these values, and --truth writes them out,
/// so the end-to-end test can score how close RST's overlay comes to the original text.
/// </summary>
internal sealed record StyleSpec(
    string Font, float Px, bool Bold, bool Italic, Color Fill,
    string Effect = "none", Color? EffectColor = null, Color? GradientTo = null, string Align = "left");

internal static class Styles
{
    public static readonly Dictionary<string, StyleSpec> All = new()
    {
        ["title"] = new("Georgia", 30, true, false, Color.FromArgb(255, 214, 120), "shadow", Color.Black),
        ["speaker"] = new("Segoe UI", 24, true, false, Color.FromArgb(255, 200, 60)),
        ["dialogue"] = new("Segoe UI", 26, false, false, Color.White),
        ["menu"] = new("Segoe UI", 20, false, false, Color.FromArgb(60, 40, 20)),
        ["banner"] = new("Bahnschrift Condensed", 44, true, false, Color.FromArgb(255, 90, 70), "shadow", Color.Black),
        ["subtitle"] = new("Segoe UI", 30, true, false, Color.White, "outline", Color.Black),
        ["hint"] = new("Segoe UI", 22, false, true, Color.FromArgb(176, 150, 110)),
        ["hud"] = new("Consolas", 18, true, false, Color.White, Align: "right"),
        // Wuthering Waves-like screen (WuwaScene)
        ["wuwa_speaker"] = new("Segoe UI", 20, true, false, Color.FromArgb(0xE8, 0xC7, 0x7A), Align: "center"),
        ["wuwa_dialogue"] = new("Segoe UI", 22, false, false, Color.White, "shadow", Color.Black, Align: "center"),
        ["wuwa_choice"] = new("Segoe UI", 18, false, false, Color.FromArgb(0xF0, 0xF0, 0xF0)),
        ["uid"] = new("Consolas", 13, false, false, Color.FromArgb(0xC8, 0xC8, 0xC8)),
        ["minimap"] = new("Segoe UI", 14, true, false, Color.White),
        ["wuwa_menu_header"] = new("Segoe UI", 24, true, false, Color.White),
        ["wuwa_menu_label"] = new("Segoe UI", 15, false, false, Color.FromArgb(0xEE, 0xEE, 0xEE), Align: "center"),
        ["gradient"] = new("Georgia", 36, true, false, Color.FromArgb(255, 244, 170), GradientTo: Color.FromArgb(225, 110, 25)),
        ["centered"] = new("Segoe UI", 26, false, false, Color.FromArgb(215, 235, 255), "shadow", Color.Black, Align: "center"),
    };

    public static Font MakeFont(StyleSpec s) =>
        new(s.Font, s.Px, (s.Bold ? FontStyle.Bold : FontStyle.Regular) | (s.Italic ? FontStyle.Italic : FontStyle.Regular), GraphicsUnit.Pixel);

    static string Hex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

    public static void WriteTruth(string path)
    {
        var table = All.ToDictionary(kv => kv.Key, kv => new
        {
            font = kv.Value.Font,
            px = kv.Value.Px,
            bold = kv.Value.Bold,
            italic = kv.Value.Italic,
            fill = Hex(kv.Value.Fill),
            effect = kv.Value.Effect,
            effect_color = kv.Value.EffectColor is { } e ? Hex(e) : null,
            gradient_to = kv.Value.GradientTo is { } g ? Hex(g) : null,
            align = kv.Value.Align,
        });
        File.WriteAllText(path, JsonSerializer.Serialize(table, new JsonSerializerOptions { WriteIndented = true }));
    }
}
