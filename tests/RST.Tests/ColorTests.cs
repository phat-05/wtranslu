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
    public void A_heavy_black_shadow_does_not_become_the_text_colour()
    {
        var mauve = new Rgb(111, 91, 102);
        var c = new Canvas(mauve);
        Letters(c, _ => new Rgb(37, 25, 27), dx: 3, dy: 3, grow: 1);
        Letters(c, _ => Red);
        var s = Analyze(c);
        Assert.True(s.Fill.DistanceTo(Red) < 40, s.Fill.ToString());
        Assert.NotEqual(TextEffectKind.None, s.Effect);
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

public class ColorMarkupTests
{
    private static readonly Rgb White = new(255, 255, 255), Red = new(255, 80, 80), Blue = new(96, 192, 255), Green = new(128, 255, 128);

    [Fact]
    public void Tags_runs_of_coloured_words()
    {
        var words = new (string, Rgb?)[] { ("The", White), ("blue", Blue), ("door", Blue), ("opens", White), ("for", White), ("the", White), ("green", Green), ("lantern.", Green) };
        string? tagged = ColorMarkup.BuildTagged(words, White, out var spans);
        Assert.Equal("The <c1>blue door</c1> opens for the <c2>green lantern.</c2>", tagged);
        Assert.Equal(2, spans.Count);
        Assert.Equal("blue door", spans[0].SourceText);
    }

    [Fact]
    public void Nothing_to_tag_when_all_words_share_the_colour()
    {
        var words = new (string, Rgb?)[] { ("Raise", White), ("the", new Rgb(240, 240, 240)), ("anchor!", White) };
        Assert.Null(ColorMarkup.BuildTagged(words, White, out _));
    }

    [Fact]
    public void Parses_a_translation_and_tolerates_a_missing_closing_tag()
    {
        var parts = ColorMarkup.Parse("Tìm <c1>chìa khóa đỏ</c1> trước <c2>bình minh");
        Assert.Equal(new (string, int?)[] { ("Tìm ", null), ("chìa khóa đỏ", 1), (" trước ", null), ("bình minh", 2) }, parts);
        Assert.Equal("Tìm chìa khóa đỏ trước bình minh", ColorMarkup.Strip("Tìm <c1>chìa khóa đỏ</c1> trước <c2>bình minh"));
    }

    [Fact]
    public void Verbatim_spans_are_found_in_a_translation_without_tags()
    {
        var spans = new[] { new ColorSpan(1, Red, "Mira"), new ColorSpan(2, Red, "12") };
        Assert.Equal("Thuyền trưởng <c1>Mira</c1> trả <c2>12</c2> đồng vàng",
            ColorMarkup.TagVerbatim("Thuyền trưởng Mira trả 12 đồng vàng", spans));
    }
}

public class AlignmentDetectorTests
{
    [Fact]
    public void Centred_lines_share_their_middle()
    {
        // "The tide rises with the moon." / "Every sailor knows its song." centred at x = 490
        Assert.True(AlignmentDetector.LinesCentered(new[] { (325.0, 330.0), (343.0, 294.0) }, 26));
    }

    [Fact]
    public void Left_aligned_lines_are_not_centred()
    {
        Assert.False(AlignmentDetector.LinesCentered(new[] { (60.0, 330.0), (60.0, 294.0) }, 26));
        // Same length, same left edge: nothing tells, keep left
        Assert.False(AlignmentDetector.LinesCentered(new[] { (60.0, 300.0), (61.0, 299.0) }, 26));
        Assert.False(AlignmentDetector.LinesCentered(new[] { (60.0, 300.0) }, 26));
    }

    [Fact]
    public void A_line_in_the_middle_of_the_screen_is_centred()
    {
        Assert.True(AlignmentDetector.LineCenteredInArea(340, 300, 0, 980));
        Assert.False(AlignmentDetector.LineCenteredInArea(60, 300, 0, 980));
        Assert.False(AlignmentDetector.LineCenteredInArea(20, 940, 0, 980));
    }
}

public class TextCaseTests
{
    [Theory]
    [InlineData("QUEST COMPLETE: THE LIGHTHOUSE KEEPER", true)]
    [InlineData("GAME OVER", true)]
    [InlineData("HP 70/100", false)]
    [InlineData("Chapter 2: The Lighthouse", false)]
    [InlineData("OK", false)]
    [InlineData("ゲームオーバー", false)]
    public void Detects_text_in_capitals(string text, bool caps) => Assert.Equal(caps, TextCase.IsAllCaps(text));

    [Fact]
    public void Vietnamese_letters_become_capitals()
    {
        Assert.Equal("NHIỆM VỤ HOÀN THÀNH: NGƯỜI GIỮ HẢI ĐĂNG",
            TextCase.Match("QUEST COMPLETE: THE LIGHTHOUSE KEEPER", "Nhiệm vụ hoàn thành: Người giữ hải đăng"));
        Assert.Equal("Người giữ hải đăng", TextCase.Match("The keeper", "Người giữ hải đăng"));
    }
}

public class RightAlignmentTests
{
    [Fact]
    public void Lines_sharing_their_right_edge_are_right_aligned()
    {
        Assert.True(AlignmentDetector.LinesRightAligned(new[] { (600.0, 370.0), (700.0, 270.0) }, 18));
        Assert.False(AlignmentDetector.LinesRightAligned(new[] { (600.0, 370.0), (600.0, 270.0) }, 18));
    }

    [Fact]
    public void Hud_text_in_the_bottom_right_corner_is_right_aligned()
    {
        // MockGame's HUD: Consolas 18 bold drawn 2 px from the right edge of a 964 px wide client
        Assert.True(AlignmentDetector.LineAtRightOfArea(570, 390, 0, 964));
        Assert.False(AlignmentDetector.LineAtRightOfArea(60, 890, 0, 964));   // a full-width line
        Assert.False(AlignmentDetector.LineAtRightOfArea(570, 300, 0, 964));  // ends far from the edge
    }
}

public class ListDetectorTests
{
    [Fact]
    public void A_menu_is_a_list()
    {
        var lines = new (string, double, double, double, double)[]
        {
            ("Continue", 674, 124, 90, 24), ("Load Game", 674, 158, 110, 24),
            ("Settings", 674, 192, 88, 24), ("Quit", 674, 226, 46, 24),
        };
        Assert.Equal(4, ListDetector.ListLines(lines).Count);
    }

    [Fact]
    public void Wrapped_dialogue_is_not_a_list()
    {
        var lines = new (string, double, double, double, double)[]
        {
            ("Welcome aboard. The harbor has been", 60, 400, 500, 26),
            ("quiet for days, and the fog", 60, 430, 380, 26),
            ("is too thick.", 60, 460, 150, 26),
        };
        Assert.Empty(ListDetector.ListLines(lines));
    }

    [Fact]
    public void Two_short_lines_are_not_enough()
    {
        var lines = new (string, double, double, double, double)[] { ("Chapter 2", 60, 50, 120, 30), ("The Lighthouse", 60, 85, 190, 30) };
        Assert.Empty(ListDetector.ListLines(lines));
    }

    [Theory]
    [InlineData("Load Game", true)]
    [InlineData("2 Players", true)]
    [InlineData("quiet for days", false)]
    [InlineData("Hello there,", false)]
    [InlineData("This line has far too many words", false)]
    public void Items_are_short_and_start_with_a_capital(string text, bool item) => Assert.Equal(item, ListDetector.IsItem(text));
}

public class GamePresetTests
{
    [Theory]
    [InlineData("Wuthering Waves  ", "Client-Win64-Shipping", true)]
    [InlineData("鸣潮", "Client-Win64-Shipping.exe", true)]
    [InlineData("Wuthering Waves", "launcher", false)]                    // the launcher, not the game
    [InlineData("Wuthering Waves 3.0 trailer - YouTube", "chrome", false)] // a browser tab
    [InlineData("Some Unreal Game", "Client-Win64-Shipping", false)]
    public void Recognises_the_Wuthering_Waves_window(string title, string process, bool match) =>
        Assert.Equal(match, GamePresets.Find(title, process) == GamePresets.WutheringWaves);

    [Fact]
    public void Dialogue_band_sits_at_the_bottom_centre_of_a_1080p_window()
    {
        var band = GamePresets.WutheringWaves.DialogueAreas[0];
        var (x, y, w, h) = GamePresets.ToScreen(band, 0, 0, 1920, 1080);
        Assert.InRange(x + w / 2, 955, 965);         // centred
        Assert.InRange(y, 780, 800);                 // speaker name row
        Assert.InRange(y + h, 1010, 1030);           // above the UID line at the very bottom
    }

    [Fact]
    public void Ultrawide_and_16_by_10_keep_the_16_by_9_interface_box()
    {
        var band = GamePresets.WutheringWaves.DialogueAreas[0];
        // 3440x1440: the 16:9 box is 2560 wide, centred (440 px of scenery each side)
        var (x, _, w, _) = GamePresets.ToScreen(band, 0, 0, 3440, 1440);
        Assert.InRange(x, 440 + 0.13 * 2560 - 1, 440 + 0.13 * 2560 + 1);
        Assert.InRange(w, 0.74 * 2560 - 1, 0.74 * 2560 + 1);
        // 1920x1200: the box is 1080 high, 60 px above and below
        var (_, y, _, h) = GamePresets.ToScreen(band, 100, 50, 1920, 1200);
        Assert.InRange(y, 50 + 60 + 0.735 * 1080 - 1, 50 + 60 + 0.735 * 1080 + 1);
        Assert.InRange(h, 0.215 * 1080 - 1, 0.215 * 1080 + 1);
    }

    [Fact]
    public void Full_mode_leaves_out_the_uid_line()
    {
        var (_, y, _, h) = GamePresets.ToScreen(GamePresets.WutheringWaves.FullAreas[0], 0, 0, 1920, 1080);
        Assert.True(y + h < 1080 * 0.97, $"full area ends at {y + h}");
    }
}

public class SpeakerNameDetectorTests
{
    [Theory]
    [InlineData("Yangyang", 90, "Then we leave now. Stay close to me.", 380, true)]
    [InlineData("Captain Mira:", 140, "Find the red key before the tide turns.", 420, true)]
    [InlineData("Then we leave", 150, "now. Stay close to me.", 260, false)]   // a wrapped sentence
    [InlineData("Hello there,", 120, "Captain, the map is ready.", 300, false)]
    [InlineData("Chapter Two", 200, "The Lighthouse", 210, false)]             // two-line heading
    [InlineData("Rover", 60, "and the others left.", 250, false)]             // the next line continues
    public void Finds_a_name_above_its_line(string first, double firstWidth, string next, double nextWidth, bool name) =>
        Assert.Equal(name, SpeakerNameDetector.IsNameAbove(first, firstWidth, next, nextWidth));
}
