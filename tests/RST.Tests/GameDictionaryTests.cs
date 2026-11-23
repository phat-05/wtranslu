using RSTGameTranslation.Layout;
using Xunit;

/// <summary>The Wuthering Waves dictionary shipped in app/GameDictionaries, on text from the game's menus.</summary>
public class GameDictionaryTests
{
    private static readonly GameDictionary Dict = GameDictionary.Parse(
        File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "GameDictionaries", "wuthering-waves.vi.json")));

    [Theory]
    [InlineData("Go", "Đi")]
    [InlineData("Claim", "Nhận")]
    [InlineData("Expedition\nMotorbike", "Mô tô thám hiểm")]
    [InlineData("Pioneer Podcast", "Podcast Tiên Phong")]
    [InlineData("Sort by Rarity", "Xếp theo độ hiếm")]
    [InlineData("Upgrade", "Nâng cấp")]
    [InlineData("Birthday:", "Sinh nhật")]
    [InlineData("Weapons 96/2000", "Vũ khí 96/2000")]
    [InlineData("Level 70/70", "Cấp 70/70")]
    [InlineData("Rank 5", "Hạng 5")]
    [InlineData("Equipped by Cartethyia", "Cartethyia đang dùng")]
    [InlineData("Resets after 11h 59m", "Làm mới sau 11h 59m")]
    [InlineData("Spend 180 Waveplates", "Dùng 180 Waveplate")]
    [InlineData("Complete 1 Daily Quest", "Làm 1 nhiệm vụ ngày")]
    [InlineData("Clear Nightmare Nest or Tacet Discord Nest 1 time", "Phá Tổ Ác Mộng hoặc Tổ Tacet Discord 1 lần")]
    public void Menus_are_translated_from_the_dictionary(string text, string translation)
    {
        Assert.True(Dict.TryTranslate(text, out var result), text);
        Assert.Equal(translation, result);
    }

    [Theory]
    [InlineData("Lv. 70")]
    [InlineData("ATK 312")]
    [InlineData("HP 59.7%")]
    [InlineData("Crit DMG")]
    [InlineData("User ID: 712903107")]
    [InlineData("4974535")]
    [InlineData("Union EXP 3175/12000")]
    [InlineData("Resonators")]
    [InlineData("80%")]
    public void Stats_abbreviations_and_numbers_stay_as_the_game_shows_them(string text) => Assert.True(Dict.IsKept(text), text);

    [Theory]
    [InlineData("Upgrade")]
    [InlineData("Max HP is increased by 12%.")]
    [InlineData("Attack")]
    public void Words_are_not_kept(string text) => Assert.False(Dict.IsKept(text), text);

    [Theory]
    [InlineData("Daily", "Ngày")]
    [InlineData("Team", "Đội")]
    [InlineData("Owned: 12", "Đang có: 12")]
    [InlineData("Data Bank Lv. 18", "Kho dữ liệu Lv. 18")]
    [InlineData("Click anywhere to close", "Bấm bất kỳ đâu để đóng")]
    [InlineData("Defeat 3 enemies", "Hạ 3 kẻ địch")]
    public void More_screens_are_translated_from_the_dictionary(string text, string translation)
    {
        Assert.True(Dict.TryTranslate(text, out var result), text);
        Assert.Equal(translation, result);
    }

    /// <summary>
    /// A translation must fit where the game's words were: no entry may be much longer than its
    /// English (at most 2.5 times, or 6 more letters for very short words).
    /// </summary>
    [Fact]
    public void Translations_stay_close_to_the_length_of_the_game_text()
    {
        string json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "GameDictionaries", "wuthering-waves.vi.json"));
        using var doc = System.Text.Json.JsonDocument.Parse(json, new System.Text.Json.JsonDocumentOptions
        {
            CommentHandling = System.Text.Json.JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
        });
        var tooLong = doc.RootElement.GetProperty("entries").EnumerateObject()
            .Where(e => e.Value.GetString()!.Length > Math.Max(e.Name.Length * 2.5, e.Name.Length + 6))
            .Select(e => $"{e.Name} -> {e.Value.GetString()}")
            .ToList();
        Assert.Empty(tooLong);
    }

    [Fact]
    public void The_players_own_file_goes_over_the_apps()
    {
        string app = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "GameDictionaries", "wuthering-waves.vi.json"));
        var dict = GameDictionary.Parse(app, """
            // the player's own words
            { "keep": ["Crimson Jadeite"], "entries": { "Go": "Đến" }, "patterns": { "Level {n}": "Lv {n}" } }
            """);
        Assert.True(dict.TryTranslate("Go", out var go));
        Assert.Equal("Đến", go);
        Assert.True(dict.TryTranslate("Level 70/70", out var level));
        Assert.Equal("Lv 70/70", level);
        Assert.True(dict.TryTranslate("Claim", out var claim));
        Assert.Equal("Nhận", claim);
        Assert.True(dict.IsKept("Crimson Jadeite"));
        Assert.True(dict.IsKept("ATK 312"));
    }

    [Fact]
    public void New_text_is_left_to_the_translator()
    {
        Assert.False(Dict.TryTranslate("Beyond the door lies a battlefield long past.", out _));
    }
}
