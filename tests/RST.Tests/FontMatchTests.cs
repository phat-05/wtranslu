using System.IO.Compression;
using System.Text.Json;
using RSTGameTranslation.Layout;
using Xunit;
using Xunit.Abstractions;

/// <summary>
/// The kind of font (serif / sans / mono) of a game is recognised by comparing its letters with the
/// same text in candidate fonts of other families (fixtures: Fixtures/make_font_fixtures.py).
/// </summary>
public class FontMatcherTests
{
    private readonly ITestOutputHelper _out;
    public FontMatcherTests(ITestOutputHelper output) => _out = output;

    private static readonly string Dir = Path.Combine(AppContext.BaseDirectory, "Fixtures", "fonts");

    public static IEnumerable<object[]> Games() =>
        JsonDocument.Parse(File.ReadAllText(Path.Combine(Dir, "fixtures.json"))).RootElement.EnumerateArray()
            .Select(e => new object[] { e.GetProperty("name").GetString()!, e.GetProperty("kind").GetString()! });

    private static FontMatcher.Ink Load(string name)
    {
        using var gz = new GZipStream(File.OpenRead(Path.Combine(Dir, name + ".cov.gz")), CompressionMode.Decompress);
        using var ms = new MemoryStream();
        gz.CopyTo(ms);
        var bytes = ms.ToArray();
        int w = BitConverter.ToInt32(bytes, 0), h = BitConverter.ToInt32(bytes, 4);
        return new FontMatcher.Ink(bytes.Skip(8).Select(b => b / 255f).ToArray(), w, h);
    }

    [Theory]
    [MemberData(nameof(Games))]
    public void Picks_the_same_kind_of_font(string game, string kind)
    {
        var candidates = new[] { "sans", "serif", "mono" }.Select(k => (k, Load("candidate_" + k)));
        var (best, all) = FontMatcher.Best(Load(game), candidates);
        _out.WriteLine($"{game}: " + string.Join(", ", all.Select(d => $"{d.Font} {d.Total:F3} ({d.Shape:F2}/{d.Aspect:F2}/{d.Contrast:F2})")));
        Assert.Equal(kind, best);
    }

    [Fact]
    public void Serif_letters_have_thinner_horizontals()
    {
        Assert.True(FontMatcher.StrokeContrast(Load("candidate_serif")) < FontMatcher.StrokeContrast(Load("candidate_sans")) - 0.1);
    }

    [Fact]
    public void Empty_image_is_far_from_everything()
    {
        var empty = new FontMatcher.Ink(new float[100], 10, 10);
        Assert.True(FontMatcher.Compare("x", empty, Load("candidate_sans")).Total > 5);
    }
}
