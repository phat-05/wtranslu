using RSTGameTranslation.Cache;
using Xunit;

public class TextKeyTests
{
    [Theory]
    [InlineData("Hello,  world!", "hello, world!")]
    [InlineData("“Quoted” — text…", "\"quoted\" - text...")]
    [InlineData("| Welcome aboard. |", "welcome aboard.")]
    [InlineData("ＦＵＬＬ　ｗｉｄｔｈ", "full width")]
    [InlineData("今日は いい 天気", "今日はいい天気")]
    [InlineData("It’s ok​", "it's ok")]
    public void Normalizes_ocr_variations(string input, string expected)
    {
        Assert.Equal(expected, TextKey.Normalize(input));
    }
}

public class FuzzyTextIndexTests
{
    private static FuzzyTextIndex IndexOf(params string[] sentences)
    {
        var index = new FuzzyTextIndex();
        foreach (var s in sentences)
            index.Add(TextKey.Normalize(s));
        return index;
    }

    [Theory]
    [InlineData("Welcome aboard. The harbor has been quiet for days.", "Welcome aboard. The harbor has been quiet tor days.")]
    [InlineData("Welcome aboard. The harbor has been quiet for days.", "Welcome aboard The harbor has been quiet for days.")]
    [InlineData("Nobody sails at night anymore. The fog is too thick.", "Nobody sails at night anymore. The fog is too thlck.")]
    [InlineData("The modern ships never come here.", "The rnodern ships never come here.")]
    [InlineData("Then we leave at dawn. Prepare the ropes.", "Then we leave atdawn. Prepare the ropes.")]
    public void Matches_ocr_misreads(string stored, string ocr)
    {
        var index = IndexOf(stored);
        Assert.Equal(TextKey.Normalize(stored), index.FindBest(TextKey.Normalize(ocr), 0.9, out _));
    }

    [Theory]
    [InlineData("The merchant wants twelve gold coins, 10 in total.", "The merchant wants twelve gold coins, 16 in total.")]
    [InlineData("I can go to the market with you tomorrow morning.", "I can't go to the market with you tomorrow morning.")]
    [InlineData("You can open the door with this key now, friend.", "You cannot open the door with this key now, friend.")]
    [InlineData("You should open the red door before the tide.", "You should not open the red door before the tide.")]
    [InlineData("Open", "Opeh")]
    [InlineData("Find the red key before the tide turns.", "Find the old key before the tide turns.")]
    public void Refuses_meaning_changes(string stored, string ocr)
    {
        var index = IndexOf(stored);
        Assert.Null(index.FindBest(TextKey.Normalize(ocr), 0.9, out _));
    }

    [Fact]
    public void Picks_the_closest_of_several()
    {
        var index = IndexOf(
            "Pay him. That map is worth far more than gold.",
            "Pay him. That map is worth far more than silver.");
        Assert.Equal("pay him. that map is worth far more than gold.",
            index.FindBest(TextKey.Normalize("Pay him. That map is worth far rnore than gold."), 0.9, out var sim));
        Assert.True(sim >= 0.9);
    }

    [Fact]
    public void Bounded_levenshtein_agrees_with_full_computation()
    {
        var rng = new Random(1);
        const string alphabet = "abc d";
        for (int n = 0; n < 2000; n++)
        {
            string a = new string(Enumerable.Range(0, rng.Next(0, 12)).Select(_ => alphabet[rng.Next(alphabet.Length)]).ToArray());
            string b = new string(Enumerable.Range(0, rng.Next(0, 12)).Select(_ => alphabet[rng.Next(alphabet.Length)]).ToArray());
            int full = Full(a, b);
            for (int limit = 0; limit <= 6; limit++)
            {
                int bounded = FuzzyTextIndex.BoundedLevenshtein(a, b, limit);
                Assert.Equal(full <= limit ? full : limit + 1, bounded);
            }
        }
    }

    private static int Full(string a, string b)
    {
        var d = new int[a.Length + 1, b.Length + 1];
        for (int i = 0; i <= a.Length; i++) d[i, 0] = i;
        for (int j = 0; j <= b.Length; j++) d[0, j] = j;
        for (int i = 1; i <= a.Length; i++)
            for (int j = 1; j <= b.Length; j++)
                d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + (a[i - 1] == b[j - 1] ? 0 : 1));
        return d[a.Length, b.Length];
    }
}

public class TranslationStoreTests
{
    [Fact]
    public void Persists_and_reloads_per_file()
    {
        string path = Path.Combine(Path.GetTempPath(), $"rst_store_{Guid.NewGuid():N}.jsonl");
        try
        {
            using (var store = new TranslationStore(path))
            {
                store.Set("Welcome aboard. The harbor has been quiet for days.", "Chào mừng lên tàu.", "Google Translate");
                store.Set("Raise the anchor!", "Nhổ neo!", "Google Translate");
                store.Flush();
            }
            using (var reloaded = new TranslationStore(path))
            {
                Assert.Equal(2, reloaded.Count);
                Assert.True(reloaded.TryGet("“Raise the anchor!”".Trim('“', '”'), "Google Translate", true, 0.9, out var t, out var m, out _));
                Assert.Equal("Nhổ neo!", t);
                Assert.Equal(CacheMatch.Exact, m);
                Assert.True(reloaded.TryGet("Welcome aboard. The harbor has been quiet tor days.", "Gemini", true, 0.9, out t, out m, out _));
                Assert.Equal("Chào mừng lên tàu.", t);
                Assert.Equal(CacheMatch.Fuzzy, m);
            }
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void Prefers_the_current_service_and_survives_a_torn_last_line()
    {
        string path = Path.Combine(Path.GetTempPath(), $"rst_store_{Guid.NewGuid():N}.jsonl");
        try
        {
            using (var store = new TranslationStore(path))
            {
                store.Set("Raise the anchor!", "Nhổ neo!", "Google Translate");
                store.Set("Raise the anchor!", "Kéo neo lên!", "Gemini");
                store.Flush();
            }
            File.AppendAllText(path, "{\"k\":\"half writ");
            using var reloaded = new TranslationStore(path);
            Assert.True(reloaded.TryGet("Raise the anchor!", "Google Translate", false, 0.9, out var t, out _, out _));
            Assert.Equal("Nhổ neo!", t);
            Assert.True(reloaded.TryGet("Raise the anchor!", "Gemini", false, 0.9, out t, out _, out _));
            Assert.Equal("Kéo neo lên!", t);
        }
        finally
        {
            File.Delete(path);
        }
    }
}
