using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using RSTGameTranslation.Layout;
using FontFamily = System.Windows.Media.FontFamily;
using Fonts = System.Windows.Media.Fonts;

namespace RSTGameTranslation
{
    /// <summary>
    /// The font the overlay draws translations in. Each game can have its own (chosen in Overlay
    /// options, kept in the config, so also in the game's profile); otherwise the language font
    /// override, otherwise the default font chain.
    ///
    /// Fonts can be system fonts or font files (.ttf/.otf) dropped into the "Fonts" folder next to
    /// rst.exe, so a game-like font with Vietnamese letters can be used without installing it.
    /// Only fonts that have every Vietnamese letter are offered (see Layout.VietnameseCoverage).
    /// </summary>
    public static class GameFonts
    {
        // Same chain as TextObject's default, used for characters the chosen font lacks (e.g. CJK names)
        public const string FallbackChain = "Arial, Noto Sans SC, Noto Sans JP, Noto Sans, Noto Sans KR, Noto Sans Devanagari, MS Gothic, Malgun Gothic, Yu Gothic, Microsoft YaHei, Arial Unicode MS";

        public static string FontsFolder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts");

        private static readonly Dictionary<string, bool> _vietnameseSupport = new();
        private static List<FontFamily>? _folderFonts;
        private static string _resolvedKey = "";
        private static FontFamily? _resolved;

        /// <summary>Font family for the overlay text of the current game.</summary>
        public static FontFamily Resolve()
        {
            string game = GameIdentity.Current;
            string gameFont = ConfigManager.Instance.GetGameFont(game);
            bool overrideOn = ConfigManager.Instance.IsLanguageFontOverrideEnabled();
            string languageFont = ConfigManager.Instance.GetLanguageFontFamily();
            string key = $"{game}|{gameFont}|{overrideOn}|{languageFont}";
            if (_resolved != null && key == _resolvedKey)
                return _resolved;

            FontFamily family;
            if (!string.IsNullOrWhiteSpace(gameFont))
                family = Create(gameFont);
            else if (overrideOn)
                family = new FontFamily(languageFont);
            else
                family = new FontFamily(FallbackChain);

            _resolvedKey = key;
            _resolved = family;
            return family;
        }

        /// <summary>The family by name: a font from the Fonts folder if one has that name, else a system font.</summary>
        public static FontFamily Create(string name)
        {
            var fromFolder = FolderFonts().FirstOrDefault(f => NameOf(f).Equals(name, StringComparison.OrdinalIgnoreCase));
            if (fromFolder != null)
                return new FontFamily(fromFolder.BaseUri, fromFolder.Source + ", " + FallbackChain);
            return new FontFamily(name + ", " + FallbackChain);
        }

        /// <summary>Names of all fonts (system and Fonts folder) that can show Vietnamese, sorted.</summary>
        public static List<string> VietnameseFontNames()
        {
            return Fonts.SystemFontFamilies.Concat(FolderFonts())
                .Where(SupportsVietnamese)
                .Select(NameOf)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(n => n, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public static List<string> AllFontNames() =>
            Fonts.SystemFontFamilies.Concat(FolderFonts()).Select(NameOf)
                .Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(n => n, StringComparer.OrdinalIgnoreCase).ToList();

        public static bool SupportsVietnamese(string name)
        {
            var family = FolderFonts().FirstOrDefault(f => NameOf(f).Equals(name, StringComparison.OrdinalIgnoreCase))
                         ?? new FontFamily(name);
            return SupportsVietnamese(family);
        }

        private static bool SupportsVietnamese(FontFamily family)
        {
            string key = (family.BaseUri?.ToString() ?? "") + family.Source;
            lock (_vietnameseSupport)
            {
                if (_vietnameseSupport.TryGetValue(key, out bool known))
                    return known;
            }
            bool ok = false;
            try
            {
                // The regular face decides; a family whose regular face lacks the letters is not usable
                var typeface = new Typeface(family, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
                if (typeface.TryGetGlyphTypeface(out GlyphTypeface glyphs))
                    ok = VietnameseCoverage.IsSupported(c => glyphs.CharacterToGlyphMap.ContainsKey(c));
            }
            catch
            {
                ok = false;
            }
            lock (_vietnameseSupport)
            {
                _vietnameseSupport[key] = ok;
            }
            return ok;
        }

        private static string NameOf(FontFamily f)
        {
            // Folder fonts have a Source like "./#Name"; their family name is the readable one
            if (f.FamilyNames.TryGetValue(System.Windows.Markup.XmlLanguage.GetLanguage("en-us"), out string? name))
                return name;
            string source = f.Source;
            int hash = source.LastIndexOf('#');
            return hash >= 0 ? source.Substring(hash + 1) : source;
        }

        private static List<FontFamily> FolderFonts()
        {
            if (_folderFonts != null)
                return _folderFonts;
            var list = new List<FontFamily>();
            try
            {
                if (Directory.Exists(FontsFolder))
                    list.AddRange(Fonts.GetFontFamilies(new Uri(FontsFolder.TrimEnd('\\', '/') + "/")));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not read the Fonts folder: {ex.Message}");
            }
            _folderFonts = list;
            return list;
        }

        /// <summary>Forget what was read, after fonts were added to the Fonts folder.</summary>
        public static void Reload()
        {
            _folderFonts = null;
            _resolved = null;
            lock (_vietnameseSupport)
                _vietnameseSupport.Clear();
        }
    }
}
