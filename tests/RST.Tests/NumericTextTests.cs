using RSTGameTranslation.Layout;
using Xunit;

namespace RST.Tests;

public class NumericTextTests
{
    [Theory]
    [InlineData("312")]
    [InlineData("3175/12000")]
    [InlineData("59.7%")]
    [InlineData("+15%")]
    [InlineData("11:59")]
    [InlineData("1,200")]
    [InlineData("x3")]
    [InlineData("×10")]
    [InlineData("11h 59m")]
    [InlineData("1.2K")]
    [InlineData("96 / 2000")]
    [InlineData("12\n30")]
    [InlineData("★★★")]
    [InlineData("- - -")]
    public void NumbersAndSymbolsHaveNoWords(string text) => Assert.True(NumericText.HasNoWords(text));

    [Theory]
    [InlineData("Go")]
    [InlineData("Weapons 96/2000")]
    [InlineData("Level 70")]
    [InlineData("A1")]
    [InlineData("3 hours left")]
    [InlineData("Claim x3")]
    [InlineData("第3章")]
    public void TextWithWordsIsTranslated(string text) => Assert.False(NumericText.HasNoWords(text));
}
