using RSTGameTranslation.Layout;
using Xunit;

namespace RST.Tests;

public class LineGapsTests
{
    [Fact]
    public void Menu_names_in_a_row_are_separate_items()
    {
        // "Store   Pioneer Podcast   Convene" at 15 px, names 60+ px apart (run 62's Terminal menu)
        var words = new (double, double, double, double)[]
        {
            (430, 210, 34, 15), (520, 210, 52, 15), (577, 210, 54, 15), (690, 210, 56, 15),
        };
        var groups = LineGaps.Split(words);
        Assert.Equal(3, groups.Count);
        Assert.Equal(new[] { 1, 2 }, groups[1]);
    }

    [Fact]
    public void A_label_and_its_value_far_apart_are_split()
    {
        var groups = LineGaps.Split(new (double, double, double, double)[] { (38, 95, 38, 15), (80, 95, 36, 15), (188, 89, 26, 22) });
        Assert.Equal(2, groups.Count);
    }

    [Fact]
    public void Words_of_a_sentence_stay_together()
    {
        // Normal and justified spacing
        var words = new (double, double, double, double)[] { (0, 0, 40, 20), (46, 0, 30, 20), (90, 0, 60, 20), (170, 0, 30, 20) };
        Assert.Single(LineGaps.Split(words));
    }
}

public class LabelSplitTests
{
    private static bool IsLabel(string text) => text is "Current" or "Go" or "Claim";

    [Fact]
    public void A_badge_beside_a_name_is_split_off()
    {
        // "Current" (9 px badge) 12 px before "Lily" (14 px), read as one line
        var words = new (double, double, double, double)[] { (99, 96, 34, 11), (145, 94, 22, 16) };
        Assert.Equal(1, LineGaps.LabelSplit(words, new[] { "Current", "Lily" }, IsLabel));
    }

    [Fact]
    public void A_sentence_starting_with_a_label_word_stays_whole()
    {
        // "Go now." with a normal space
        var words = new (double, double, double, double)[] { (0, 0, 22, 18), (27, 2, 40, 16) };
        Assert.Equal(-1, LineGaps.LabelSplit(words, new[] { "Go", "now." }, IsLabel));
    }

    [Fact]
    public void A_short_word_after_a_label_word_stays_whole()
    {
        // "Go on." : "on." measures only its x-height
        var words = new (double, double, double, double)[] { (0, 0, 22, 17), (27, 5, 22, 10) };
        Assert.Equal(-1, LineGaps.LabelSplit(words, new[] { "Go", "on." }, IsLabel));
    }

    [Fact]
    public void No_label_no_split()
    {
        var words = new (double, double, double, double)[] { (0, 0, 60, 16), (80, 0, 60, 16) };
        Assert.Equal(-1, LineGaps.LabelSplit(words, new[] { "Boss", "Challenge" }, IsLabel));
    }
}
