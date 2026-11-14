using RSTGameTranslation.Layout;
using Xunit;

/// <summary>Synthetic text lines: blocky letters drawn with optional outline / shadow / second colour.</summary>
public class TextColorAnalyzerTests
{
    private const int W = 300, H = 80;
    private static readonly (int X, int Y, int W, int H) Box = (20, 20, 260, 40);

    private sealed class Canvas
    {
        public readonly byte[] Px = new byte[W * H * 4];
        public Canvas(Rgb bg) { for (int i = 0; i < W * H; i++) Set(i % W, i / W, bg); }
        public void Set(int x, int y, Rgb c)
        {
            if (x < 0 || y < 0 || x >= W || y >= H) return;
            int p = (y * W + x) * 4;
            Px[p] = c.B; Px[p + 1] = c.G; Px[p + 2] = c.R; Px[p + 3] = 255;
        }
        public void Rect(int x, int y, int w, int h, Rgb c)
        {
            for (int yy = y; yy < y + h; yy++)
                for (int xx = x; xx < x + w; xx++)
                    Set(xx, yy, c);
        }
    }

    // "Letters": an H-like glyph every 22 px, strokes 4 px thick
    private static void Letters(Canvas c, Func<int, Rgb> colourOf, int dx = 0, int dy = 0, int grow = 0)
    {
        for (int n = 0; n < 11; n++)
        {
            int x = 26 + n * 22 + dx, y = 26 + dy;
            var col = colourOf(n);
            c.Rect(x - grow, y - grow, 4 + 2 * grow, 28 + 2 * grow, col);
            c.Rect(x + 10 - grow, y - grow, 4 + 2 * grow, 28 + 2 * grow, col);
            c.Rect(x - grow, y + 12 - grow, 14 + 2 * grow, 4 + 2 * grow, col);
        }
    }

    private static TextStyle Analyze(Canvas c) =>
        TextColorAnalyzer.Analyze(c.Px, W, H, W * 4, Box.X, Box.Y, Box.W, Box.H)!;

    private static readonly Rgb Navy = new(18, 24, 48), White = new(255, 255, 255), Black = new(0, 0, 0),
        Gold = new(255, 214, 120), Grey = new(128, 128, 128), Red = new(255, 80, 80),
        PaleYellow = new(250, 240, 200), Cream = new(245, 240, 225);

    [Fact]
    public void Plain_text_keeps_its_colour()
    {
        var c = new Canvas(Navy);
        Letters(c, _ => White);
        var s = Analyze(c);
        Assert.True(s.Fill.DistanceTo(White) < 20);
        Assert.True(s.Background.DistanceTo(Navy) < 20);
        Assert.Equal(TextEffectKind.None, s.Effect);
    }

    [Fact]
    public void Outline_is_detected()
    {
        var c = new Canvas(Grey);
        Letters(c, _ => Black, grow: 2);
        Letters(c, _ => White);
        var s = Analyze(c);
        Assert.Equal(TextEffectKind.Outline, s.Effect);
        Assert.True(s.Fill.DistanceTo(White) < 30, s.Fill.ToString());
        Assert.True(s.EffectColor.DistanceTo(Black) < 30, s.EffectColor.ToString());
    }

    [Fact]
    public void Drop_shadow_is_detected_with_its_direction()
    {
        var c = new Canvas(Navy);
        Letters(c, _ => Black, dx: 3, dy: 3);
        Letters(c, _ => Gold);
        var s = Analyze(c);
        Assert.Equal(TextEffectKind.Shadow, s.Effect);
        Assert.True(s.Fill.DistanceTo(Gold) < 30, s.Fill.ToString());
        Assert.True(s.ShadowDx > 0 && s.ShadowDy > 0);
    }

    [Fact]
    public void Low_contrast_colour_is_kept_and_an_outline_added()
    {
        var c = new Canvas(Cream);
        Letters(c, _ => PaleYellow);
        // Pale on cream is below the ink threshold: make it just visible
        var c2 = new Canvas(new Rgb(200, 190, 160));
        Letters(c2, _ => PaleYellow);
        var s = Analyze(c2);
        Assert.True(s.Fill.DistanceTo(PaleYellow) < 30, s.Fill.ToString());
        Assert.Equal(TextEffectKind.Outline, s.Effect);
        Assert.True(s.EffectAdded);
    }

    [Fact]
    public void Anti_aliased_edges_are_not_an_outline()
    {
        var c = new Canvas(Navy);
        // A 1-2 px fringe halfway between the text colour and the background, as smoothed text has
        var fringe = new Rgb((byte)((Gold.R + Navy.R) / 2), (byte)((Gold.G + Navy.G) / 2), (byte)((Gold.B + Navy.B) / 2));
        Letters(c, _ => fringe, grow: 2);
        Letters(c, _ => Gold);
        var s = Analyze(c);
        Assert.Equal(TextEffectKind.None, s.Effect);
        Assert.True(s.Fill.DistanceTo(Gold) < 30, s.Fill.ToString());
    }

    [Fact]
    public void Mostly_coloured_words_keep_the_plain_main_colour()
    {
        var c = new Canvas(Navy);
        var Blue = new Rgb(96, 192, 255);
        Letters(c, n => n is >= 2 and <= 6 ? Blue : White);
        var s = Analyze(c);
        Assert.True(s.Fill.DistanceTo(White) < 30, s.Fill.ToString());
    }

    [Fact]
    public void A_coloured_word_does_not_become_an_outline()
    {
        var c = new Canvas(Navy);
        Letters(c, n => n is 3 or 4 ? Red : White);
        var s = Analyze(c);
        Assert.Equal(TextEffectKind.None, s.Effect);
        Assert.True(s.Fill.DistanceTo(White) < 30, s.Fill.ToString());
    }
}

public class VietnameseCoverageTests
{
    [Fact]
    public void A_font_with_all_letters_is_accepted()
    {
        Assert.True(VietnameseCoverage.IsSupported(_ => true));
    }

    [Fact]
    public void Missing_tone_marks_are_reported()
    {
        // A Latin-1 font: has à á â ã è é ê ì í ò ó ô õ ù ú ý but none of ă đ ơ ư or the dot-below forms
        string latin1 = "aàáâãeèéêiìíoòóôõuùúyýAÀÁÂÃEÈÉÊIÌÍOÒÓÔÕUÙÚYÝ";
        string missing = VietnameseCoverage.Missing(c => latin1.Contains(c));
        Assert.Contains('ă', missing);
        Assert.Contains('đ', missing);
        Assert.Contains('ữ', missing);
        Assert.DoesNotContain('à', missing);
    }
}
