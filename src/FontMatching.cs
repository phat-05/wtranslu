using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RSTGameTranslation.Layout;
using FontFamily = System.Windows.Media.FontFamily;
using Point = System.Windows.Point;
using Brushes = System.Windows.Media.Brushes;
using FlowDirection = System.Windows.FlowDirection;

namespace RSTGameTranslation
{
    /// <summary>
    /// When no font is chosen for the game, picks the Windows font that looks most like the game's:
    /// the source text is drawn in each candidate font (at the game's size, bold/italic like the game)
    /// and compared with the game's letters (Layout.FontMatcher).
    ///
    /// A game uses the same font for the same kind of text, so the choice is remembered per text
    /// style (game, colour, bold, italic, size). The first three one-line texts of a style vote
    /// (distances summed); later texts of that style, including blocks of several lines, reuse the
    /// result without drawing anything.
    /// </summary>
    public static class FontMatching
    {
        // Fonts that come with Windows 10/11, a few per kind of typeface; only those with every
        // Vietnamese letter are used
        private static readonly string[] Candidates =
        {
            "Segoe UI", "Arial", "Tahoma", "Bahnschrift",
            "Georgia", "Times New Roman", "Cambria", "Palatino Linotype",
            "Consolas", "Courier New",
            "Bahnschrift Condensed",
        };
        private const int SamplesPerStyle = 3;

        private sealed class Votes
        {
            public readonly Dictionary<string, double> Sum = new();
            // Sum of ln(candidate width / game width) per font
            public readonly Dictionary<string, double> AspectLog = new();
            public int Samples;
        }

        // A font that draws the game's text this much wider (or more) is squeezed to the game's
        // width: the game uses a condensed face that no candidate has (a banner measured 0.67; boxes
        // drawn around answer choices made a normal font measure 0.83, so not below 0.8)
        private const double CondenseFrom = 0.8, MostCondensed = 0.6;
        // Shorter texts (a name like "Yangyang") look alike in too many fonts to tell them apart
        private const int MinSampleLength = 10;

        private static readonly Dictionary<string, Votes> _byStyle = new();
        private static List<string>? _usable;
        private static readonly Dictionary<string, FontFamily> _families = new();

        /// <summary>Whether to match fonts: enabled, and no font chosen for the game or the language.</summary>
        public static bool Active =>
            ConfigManager.Instance.IsAutoMatchFontEnabled() &&
            string.IsNullOrWhiteSpace(ConfigManager.Instance.GetGameFont(GameIdentity.Current)) &&
            !ConfigManager.Instance.IsLanguageFontOverrideEnabled();

        /// <summary>
        /// Name of the font closest to the game's for this text, or null (unknown: default font), and
        /// the horizontal scale that gives it the game's width (1 = as is; below 1 = condensed).
        /// Must run on the UI thread (draws with WPF).
        /// </summary>
        public static (string? Font, double ScaleX) Match(string text, TextStyle style, double fontPx, int lineCount)
        {
            var shape = style.Shape;
            if (shape == null)
                return (null, 1);
            try
            {
                string key = StyleKey(style, shape, fontPx);
                _byStyle.TryGetValue(key, out var votes);
                // One whole line: its letters were measured (FontPxFromInk > 0), so none are cut off by
                // the box or the screen edge (cut letters look like another font)
                bool canSample = shape.Coverage != null && lineCount == 1 && shape.FontPxFromInk > 0 && fontPx >= 10 &&
                                 text.Trim().Length >= MinSampleLength && !text.Any(IsWide);
                if ((votes == null || votes.Samples < SamplesPerStyle) && canSample)
                {
                    var started = DateTime.UtcNow;
                    var game = new FontMatcher.Ink(shape.Coverage!, shape.CoverageWidth, shape.CoverageHeight);
                    var candidates = UsableFonts().Select(f => (f, Render(text.Trim(), f, fontPx, shape.Bold, shape.Italic))).ToList();
                    var (_, all) = FontMatcher.Best(game, candidates);
                    Dump(text, game, candidates);
                    if (all.Count > 0)
                    {
                        votes ??= _byStyle[key] = new Votes();
                        foreach (var d in all)
                        {
                            votes.Sum[d.Font] = votes.Sum.GetValueOrDefault(d.Font) + d.Total;
                            votes.AspectLog[d.Font] = votes.AspectLog.GetValueOrDefault(d.Font) + d.AspectLog;
                        }
                        votes.Samples++;
                        OcrTiming.Metrics.Write("font_match", $"{(DateTime.UtcNow - started).TotalMilliseconds:F0} ms|{key}|{text}|" +
                            string.Join(",", all.Take(4).Select(d => $"{d.Font}={d.Total:F3}({d.Shape:F2}/{d.Aspect:F2}/{d.Contrast:F2})")));
                    }
                }
                if (votes == null || votes.Samples == 0)
                {
                    // Too short to tell (a button, a menu name): the font the game's other text matched
                    string? gameFont = GameBest();
                    return (gameFont, 1);
                }
                string best = votes.Sum.MinBy(kv => kv.Value).Key;
                double widthRatio = Math.Exp(-votes.AspectLog.GetValueOrDefault(best) / votes.Samples);
                double scaleX = widthRatio <= CondenseFrom ? Math.Max(MostCondensed, widthRatio) : 1;
                return (best, scaleX);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Font matching failed: {ex.Message}");
                return (null, 1);
            }
            finally
            {
                shape.Coverage = null; // only needed here
            }
        }

        /// <summary>
        /// The font closest over all of this game's measured text (mean distance per style), or null
        /// when nothing was measured yet.
        /// </summary>
        private static string? GameBest()
        {
            string prefix = GameIdentity.Current + "|";
            var total = new Dictionary<string, double>();
            int styles = 0;
            foreach (var (key, votes) in _byStyle)
            {
                if (!key.StartsWith(prefix, StringComparison.Ordinal) || votes.Samples == 0)
                    continue;
                styles++;
                foreach (var (font, sum) in votes.Sum)
                    total[font] = total.GetValueOrDefault(font) + sum / votes.Samples;
            }
            // Every style is measured in every usable font, so the sums compare
            return styles == 0 || total.Count == 0 ? null : total.MinBy(kv => kv.Value).Key;
        }

        /// <summary>The family for a matched font name (with the fallback chain for other scripts).</summary>
        public static FontFamily Family(string name)
        {
            if (!_families.TryGetValue(name, out var family))
                _families[name] = family = GameFonts.Create(name);
            return family;
        }

        /// <summary>Forget the choices (new game, fonts changed).</summary>
        public static void Reset()
        {
            _byStyle.Clear();
            _usable = null;
            _families.Clear();
        }

        // Same game, same colour (coarsely), same weight/slant and about the same size (20% steps)
        private static string StyleKey(TextStyle style, TextShape shape, double fontPx) =>
            $"{GameIdentity.Current}|{style.Fill.R >> 5},{style.Fill.G >> 5},{style.Fill.B >> 5}|" +
            $"{(shape.Bold ? "b" : "")}{(shape.Italic ? "i" : "")}|{Math.Round(Math.Log(Math.Max(1, fontPx)) / Math.Log(1.2))}";

        private static List<string> UsableFonts()
        {
            if (_usable != null)
                return _usable;
            var installed = new HashSet<string>(Fonts.SystemFontFamilies.Select(f => f.Source), StringComparer.OrdinalIgnoreCase);
            _usable = Candidates.Where(n => installed.Contains(n) && GameFonts.SupportsVietnamese(n)).ToList();
            Console.WriteLine($"Font matching candidates: {string.Join(", ", _usable)}; left out: " +
                string.Join(", ", Candidates.Except(_usable).Select(n => $"{n} ({(installed.Contains(n) ? "no Vietnamese" : "not installed")})")));
            return _usable;
        }

        /// <summary>The text drawn white on black in a font, as coverage 0..1 per pixel.</summary>
        private static FontMatcher.Ink Render(string text, string font, double px, bool bold, bool italic)
        {
            var typeface = new Typeface(new FontFamily(font), italic ? FontStyles.Italic : FontStyles.Normal,
                bold ? FontWeights.Bold : FontWeights.Normal, FontStretches.Normal);
            // Ideal (unhinted) layout: tried hinted Display mode to look more like GDI text, but on Windows
            // CI data it matched the game's letters worse for 10 of 13 lines
            var formatted = new FormattedText(text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                typeface, px, Brushes.White, 1.0);
            int w = Math.Clamp((int)Math.Ceiling(formatted.WidthIncludingTrailingWhitespace) + 8, 8, 4000);
            int h = Math.Clamp((int)Math.Ceiling(formatted.Height) + 8, 8, 1000);
            var visual = new DrawingVisual();
            // Grey-scale anti-aliasing like most games (no ClearType colour fringes)
            TextOptions.SetTextRenderingMode(visual, TextRenderingMode.Grayscale);
            using (var dc = visual.RenderOpen())
            {
                dc.DrawRectangle(Brushes.Black, null, new Rect(0, 0, w, h));
                dc.DrawText(formatted, new Point(4, 4));
            }
            var bitmap = new RenderTargetBitmap(w, h, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var pixels = new byte[w * h * 4];
            bitmap.CopyPixels(pixels, w * 4, 0);
            var coverage = new float[w * h];
            for (int i = 0; i < coverage.Length; i++)
                coverage[i] = pixels[i * 4 + 1] / 255f;
            return new FontMatcher.Ink(coverage, w, h);
        }

        // Test runs only (RST_STYLE_DUMP_DIR set): the game's letters and each candidate's drawing, as
        // coverage images (int32 width, int32 height, one byte per pixel), to tune the matcher offline
        private static readonly string? _dumpDir = Environment.GetEnvironmentVariable("RST_STYLE_DUMP_DIR");
        private static int _dumpCount;

        private static void Dump(string text, FontMatcher.Ink game, List<(string Font, FontMatcher.Ink Ink)> candidates)
        {
            if (string.IsNullOrEmpty(_dumpDir) || _dumpCount >= 60)
                return;
            try
            {
                int n = ++_dumpCount;
                string dir = System.IO.Path.Combine(_dumpDir, "fonts");
                System.IO.Directory.CreateDirectory(dir);
                void Save(string name, FontMatcher.Ink ink)
                {
                    using var fs = System.IO.File.Create(System.IO.Path.Combine(dir, name));
                    using var gz = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionLevel.Optimal);
                    gz.Write(BitConverter.GetBytes(ink.Width));
                    gz.Write(BitConverter.GetBytes(ink.Height));
                    gz.Write(ink.Coverage.Select(v => (byte)Math.Clamp(v * 255, 0, 255)).ToArray());
                }
                Save($"{n:D2}_game.cov.gz", game);
                foreach (var (font, ink) in candidates)
                    Save($"{n:D2}_{font.Replace(' ', '_')}.cov.gz", ink);
                System.IO.File.AppendAllText(System.IO.Path.Combine(dir, "index.jsonl"),
                    System.Text.Json.JsonSerializer.Serialize(new { n, text, fonts = candidates.Select(c => c.Font).ToArray() }) + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Font dump failed: {ex.Message}");
            }
        }

        // CJK and other wide scripts: the candidate Latin fonts say nothing about them
        private static bool IsWide(char c) => c >= '⺀';
    }
}
