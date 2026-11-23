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
