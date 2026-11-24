using RSTGameTranslation.Layout;
using Xunit;

namespace RST.Tests;

public class ScriptFilterTests
{
    [Theory]
    [InlineData("프추한교화정 한다정")]   // a menu card's decorative strokes, read on a Wuthering Waves screen
    [InlineData("불은2m")]
    [InlineData("ВВВ ЕЕЕ")]
    [InlineData("三三三")]
    public void Misread_decorations_in_an_English_game_are_dropped(string text) =>
        Assert.True(ScriptFilter.IsForeignScript(text, "en"));

    [Theory]
    [InlineData("Boss Challenge")]
    [InlineData("Weapon Type/All")]
    [InlineData("Jué")]
    [InlineData("Lv. 70")]
    [InlineData("Café crème")]
    [InlineData("Rover 漂泊者")]           // mostly Latin
    [InlineData("480")]
    public void Text_in_the_games_script_stays(string text) =>
        Assert.False(ScriptFilter.IsForeignScript(text, "en"));

    [Fact]
    public void Games_in_other_scripts_are_not_filtered()
    {
        Assert.False(ScriptFilter.IsForeignScript("한다정", "ko"));
        Assert.False(ScriptFilter.IsForeignScript("こんにちは", "ja"));
        Assert.False(ScriptFilter.IsForeignScript("한다정", "auto"));
    }
}
