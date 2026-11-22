using System.IO.Compression;
using System.Text.Json;
using RSTGameTranslation.Layout;
using Xunit;
using Xunit.Abstractions;

/// <summary>
/// Bold / italic / gradient read from real anti-aliased text (fixtures made by
/// Fixtures/make_shape_fixtures.py with Liberation, Carlito and Caladea fonts).
/// </summary>
public class TextShapeAnalyzerTests
{
    private readonly ITestOutputHelper _out;
    public TextShapeAnalyzerTests(ITestOutputHelper output) => _out = output;

    private static readonly string Dir = Path.Combine(AppContext.BaseDirectory, "Fixtures", "shape");

    public static IEnumerable<object[]> Names() =>
        JsonDocument.Parse(File.ReadAllText(Path.Combine(Dir, "fixtures.json"))).RootElement
            .EnumerateArray().Select(e => new object[] { e.GetProperty("name").GetString()! });

    private static (byte[] Px, int W, int H, JsonElement Spec) Load(string name)
    {
        var spec = JsonDocument.Parse(File.ReadAllText(Path.Combine(Dir, "fixtures.json"))).RootElement
            .EnumerateArray().First(e => e.GetProperty("name").GetString() == name);
        using var gz = new GZipStream(File.OpenRead(Path.Combine(Dir, name + ".bgra.gz")), CompressionMode.Decompress);
        using var ms = new MemoryStream();
        gz.CopyTo(ms);
        var bytes = ms.ToArray();
        int w = BitConverter.ToInt32(bytes, 0), h = BitConverter.ToInt32(bytes, 4);
        return (bytes[8..], w, h, spec);
    }

    private (TextStyle Style, TextShape Shape) Analyze(string name)
    {
        var (px, w, h, spec) = Load(name);
        var box = spec.GetProperty("box").EnumerateArray().Select(v => v.GetInt32()).ToArray();
        var style = TextColorAnalyzer.Analyze(px, w, h, w * 4, box[0], box[1], box[2], box[3])!;
        var shape = TextShapeAnalyzer.Analyze(px, w, h, w * 4, box[0], box[1], box[2], box[3], style,
            spec.GetProperty("font_px").GetDouble(), spec.GetProperty("lines").GetInt32())!;
        _out.WriteLine($"{name}: fill {style.Fill} bg {style.Background} {style.Effect} -> {shape}");
        return (style, shape);
    }

    [Theory]
    [MemberData(nameof(Names))]
    public void Shape_matches_the_font(string name)
    {
        var (_, _, _, spec) = Load(name);
        var (_, shape) = Analyze(name);
        Assert.Equal(spec.GetProperty("bold").GetBoolean(), shape.Bold);
        Assert.Equal(spec.GetProperty("italic").GetBoolean(), shape.Italic);
        Assert.Equal(spec.GetProperty("gradient").GetBoolean(), shape.GradientTop != null);
    }

    [Fact]
    public void Gradient_colours_are_close_to_the_game()
    {
        var (_, shape) = Analyze("gradient_serif_bold");
        Assert.NotNull(shape.GradientTop);
        Assert.True(shape.GradientTop!.Value.DistanceTo(new Rgb(0xFF, 0xF4, 0xAA)) < 70, $"top {shape.GradientTop}");
        Assert.True(shape.GradientBottom!.Value.DistanceTo(new Rgb(0xE1, 0x6E, 0x19)) < 70, $"bottom {shape.GradientBottom}");
    }

    [Fact]
    public void Unknown_font_size_never_claims_bold()
    {
        var (px, w, h, spec) = Load("sans_bold");
        var box = spec.GetProperty("box").EnumerateArray().Select(v => v.GetInt32()).ToArray();
        var style = TextColorAnalyzer.Analyze(px, w, h, w * 4, box[0], box[1], box[2], box[3])!;
        var shape = TextShapeAnalyzer.Analyze(px, w, h, w * 4, box[0], box[1], box[2], box[3], style, 0)!;
        Assert.False(shape.Bold);
    }

    [Fact]
    public void Tiny_box_is_ignored()
    {
        var px = new byte[10 * 10 * 4];
        var style = new TextStyle { Fill = new Rgb(255, 255, 255), Background = new Rgb(0, 0, 0) };
        Assert.Null(TextShapeAnalyzer.Analyze(px, 10, 10, 40, 2, 2, 3, 3, style, 20));
    }
}
