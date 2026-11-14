using System.Text.Json;
using RSTGameTranslation.Cache;
using Xunit;

/// <summary>
/// Synthetic frames: a dark dialogue box with "text" drawn as a blocky 5x7 pseudo-font (each
/// character gets its own fixed pattern), over a background that can flicker like an animation.
/// </summary>
public class ImageTierTests
{
    private const int W = 640, H = 360;

    private static byte[] Frame(string text, int seed, int noise, int textX = 40, int textY = 250, int scale = 4)
    {
        var rng = new Random(seed);
        var px = new byte[W * H * 4];
        for (int y = 0; y < H; y++)
            for (int x = 0; x < W; x++)
            {
                int i = (y * W + x) * 4;
                bool box = y >= 230 && y < 330;
                int baseV = box ? 30 : 120 + (x + y) % 60;
                int v = Math.Clamp(baseV + (noise > 0 ? rng.Next(-noise, noise + 1) : 0), 0, 255);
                px[i] = (byte)v; px[i + 1] = (byte)v; px[i + 2] = (byte)(v + (box ? 10 : 0)); px[i + 3] = 255;
            }
        for (int c = 0; c < text.Length; c++)
        {
            int pattern = text[c] * 2654435761u is var h ? (int)(h >> 3) : 0;
            for (int gy = 0; gy < 7; gy++)
                for (int gx = 0; gx < 5; gx++)
                {
                    if (text[c] == ' ' || ((pattern >> ((gy * 5 + gx) % 29)) & 1) == 0)
                        continue;
                    for (int sy = 0; sy < scale; sy++)
                        for (int sx = 0; sx < scale; sx++)
                        {
                            int x = textX + c * 6 * scale + gx * scale + sx, y = textY + gy * scale + sy;
                            if (x >= W || y >= H) continue;
                            int i = (y * W + x) * 4;
                            px[i] = 240; px[i + 1] = 240; px[i + 2] = 240;
                        }
                }
        }
        return px;
    }

    private static string OcrJson(string text, int textX = 40, int textY = 250, int scale = 4)
    {
        int w = text.Length * 6 * scale, h = 7 * scale;
        var result = new
        {
            status = "success",
            results = new[] { new { text, confidence = 0.99, rect = new[] {
                new[] { (double)textX, textY }, new[] { (double)textX + w, textY },
                new[] { (double)textX + w, textY + h }, new[] { (double)textX, textY + h } } } }
        };
        return JsonSerializer.Serialize(result);
    }

    [Fact]
    public void Same_text_over_flickering_background_is_recognised()
    {
        var cache = new ImageTextCache(null);
        const string line = "Welcome aboard 12 coins";
        cache.OnOcrResult(OcrJson(line), Frame(line, 1, 0), W, H, W * 4);

        for (int seed = 2; seed < 2 + ImageTextCache.VerifyEvery - 1; seed++)
        {
            string? hit = cache.Lookup(Frame(line, seed, 12), W, H, W * 4, out int matched);
            Assert.NotNull(hit);
            Assert.Equal(1, matched);
            Assert.Contains(line, hit);
        }
    }

    [Fact]
    public void A_changed_digit_or_word_is_a_miss()
    {
        var cache = new ImageTextCache(null);
        const string line = "Welcome aboard 12 coins";
        cache.OnOcrResult(OcrJson(line), Frame(line, 1, 0), W, H, W * 4);

        Assert.Null(cache.Lookup(Frame("Welcome aboard 13 coins", 3, 6), W, H, W * 4, out _));
        Assert.Null(cache.Lookup(Frame("Welcome abroad 12 coins", 4, 6), W, H, W * 4, out _));
        Assert.Null(cache.Lookup(Frame("", 5, 6), W, H, W * 4, out _));
    }

    [Fact]
    public void Several_texts_in_the_same_place_are_told_apart()
    {
        var cache = new ImageTextCache(null);
        string[] lines = { "Captain Mira says hello", "The fog is too thick now", "Raise the anchor at dawn" };
        foreach (var l in lines)
            cache.OnOcrResult(OcrJson(l), Frame(l, 7, 0), W, H, W * 4);

        foreach (var l in lines)
        {
            string? hit = cache.Lookup(Frame(l, 9, 8), W, H, W * 4, out _);
            Assert.NotNull(hit);
            Assert.Contains(l, hit);
        }
    }

    [Fact]
    public void Verification_drops_an_entry_that_ocr_contradicts()
    {
        var cache = new ImageTextCache(null);
        const string line = "Raise the anchor at dawn";
        cache.OnOcrResult(OcrJson(line), Frame(line, 1, 0), W, H, W * 4);

        string? hit = null;
        int n = 0;
        do { hit = cache.Lookup(Frame(line, 20 + n, 4), W, H, W * 4, out _); n++; } while (hit != null && n < 50);
        Assert.Null(hit); // the verification turn
        // OCR "reads" something else in that box: the entry must go
        Assert.False(cache.OnOcrResult(OcrJson("Raise the anchor at dusk"), Frame(line, 99, 0), W, H, W * 4));
    }

    [Fact]
    public void Entries_survive_a_restart_through_the_file()
    {
        string path = Path.Combine(Path.GetTempPath(), $"rst_img_{Guid.NewGuid():N}.jsonl");
        try
        {
            const string line = "Stories will not stop us";
            new ImageTextCache(path).OnOcrResult(OcrJson(line), Frame(line, 1, 0), W, H, W * 4);
            var reloaded = new ImageTextCache(path);
            Assert.Equal(1, reloaded.Count);
            Assert.NotNull(reloaded.Lookup(Frame(line, 5, 8), W, H, W * 4, out _));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
