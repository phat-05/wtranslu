using System.IO.Compression;
using System.Text.Json;
using RSTGameTranslation.Layout;
using Xunit;
using Xunit.Abstractions;

/// <summary>
/// The text analysers on text boxes captured on Windows in CI (GDI+ text, see Fixtures/windows),
/// checked against what MockGame really drew.
/// </summary>
public class WindowsTextTests
{
    private readonly ITestOutputHelper _out;
    public WindowsTextTests(ITestOutputHelper output) => _out = output;

    private static readonly string Dir = Path.Combine(AppContext.BaseDirectory, "Fixtures", "windows");

    public static IEnumerable<object[]> Names() =>
        JsonDocument.Parse(File.ReadAllText(Path.Combine(Dir, "fixtures.json"))).RootElement
            .EnumerateArray().Select(e => new object[] { e.GetProperty("name").GetString()! });

    private static Rgb Hex(string h) => new(Convert.ToByte(h[1..3], 16), Convert.ToByte(h[3..5], 16), Convert.ToByte(h[5..7], 16));

    [Theory]
    [MemberData(nameof(Names))]
    public void Reads_the_game_style(string name)
    {
        var spec = JsonDocument.Parse(File.ReadAllText(Path.Combine(Dir, "fixtures.json"))).RootElement
            .EnumerateArray().First(e => e.GetProperty("name").GetString() == name);
        using var gz = new GZipStream(File.OpenRead(Path.Combine(Dir, name + ".bgra.gz")), CompressionMode.Decompress);
        using var ms = new MemoryStream();
        gz.CopyTo(ms);
        var bytes = ms.ToArray();
        int w = BitConverter.ToInt32(bytes, 0), h = BitConverter.ToInt32(bytes, 4);
        var px = bytes.AsSpan(8);
        var box = spec.GetProperty("box").EnumerateArray().Select(v => v.GetInt32()).ToArray();
        int lines = spec.GetProperty("lines").GetInt32();
        var style = TextColorAnalyzer.Analyze(px, w, h, w * 4, box[0], box[1], box[2], box[3])!;
        var shape = TextShapeAnalyzer.Analyze(px, w, h, w * 4, box[0], box[1], box[2], box[3], style,
            spec.GetProperty("font_px").GetDouble(), lines, lines == 1 ? spec.GetProperty("text").GetString() : null)!;
        _out.WriteLine($"{name}: fill {style.Fill} {style.Effect} {style.ShadowDx},{style.ShadowDy} outline {style.OutlineWidth:F1} | {shape} | ink {shape.FontPxFromInk:F1}");

        Assert.Equal(spec.GetProperty("effect").GetString(), style.Effect.ToString());
        Assert.Equal(spec.GetProperty("bold").GetBoolean(), shape.Bold);
        Assert.Equal(spec.GetProperty("italic").GetBoolean(), shape.Italic);
        Assert.Equal(spec.GetProperty("gradient").GetBoolean(), shape.GradientTop != null);
        if (spec.TryGetProperty("fill", out var fill))
            Assert.True(style.Fill.DistanceTo(Hex(fill.GetString()!)) < 12, $"fill {style.Fill}, game {fill}");
        if (shape.GradientTop != null)
        {
            Assert.True(shape.GradientTop.Value.DistanceTo(Hex(spec.GetProperty("top").GetString()!)) < 30, $"top {shape.GradientTop}");
            Assert.True(shape.GradientBottom!.Value.DistanceTo(Hex(spec.GetProperty("bottom").GetString()!)) < 30, $"bottom {shape.GradientBottom}");
        }
        if (style.Effect == TextEffectKind.Shadow)
            Assert.True(style.ShadowDx is >= 2 and <= 3 && style.ShadowDy is >= 2 and <= 3, $"shadow {style.ShadowDx},{style.ShadowDy}");
        double truthPx = spec.GetProperty("px").GetDouble();
        if (truthPx == 0)
            Assert.Equal(0, shape.FontPxFromInk); // cut by the screen edge: not measured
        else if (shape.FontPxFromInk > 0)
            Assert.InRange(shape.FontPxFromInk, truthPx * 0.9, truthPx * 1.15);
    }
}
