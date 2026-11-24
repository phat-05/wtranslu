using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using RSTGameTranslation.Layout;

namespace RSTGameTranslation
{
    /// <summary>
    /// Wraps a machine translator (Google, Microsoft, Yandex) while a known game is translated: the
    /// game's names and terms are swapped for tokens in the request and back in the answer (see
    /// Layout.TermGuard). AI translators are told about the game instead (game info).
    /// </summary>
    public sealed class TermGuardTranslationService : ITranslationService
    {
        private readonly ITranslationService _inner;
        private readonly IReadOnlyCollection<string> _terms;
        private readonly IReadOnlyDictionary<string, string>? _glossary;

        public TermGuardTranslationService(ITranslationService inner, IReadOnlyCollection<string> terms,
                                           IReadOnlyDictionary<string, string>? glossary = null)
        {
            _inner = inner;
            _terms = terms;
            _glossary = glossary;
        }

        /// <summary>
        /// The terms of the game being translated: its names and terms kept as they are, and the terms
        /// of its dictionary's glossary for the target language (shown in their translation).
        /// </summary>
        public static (IReadOnlyCollection<string> Terms, IReadOnlyDictionary<string, string>? Glossary) ActiveTerms()
        {
            var preset = GamePresets.Active;
            if (preset == null)
                return (Array.Empty<string>(), null);
            var glossary = GameDictionaries.Active?.Glossary;
            var terms = preset.ProtectedTerms.Concat(glossary?.Keys ?? Enumerable.Empty<string>()).Distinct().ToArray();
            return (terms, glossary is { Count: > 0 } ? glossary : null);
        }

        // The services wrapped (see TranslationServiceFactory): their translations always keep the terms
        private static readonly HashSet<string> Guarded = new(StringComparer.OrdinalIgnoreCase) { "Google Translate", "Yandex", "Microsoft" };

        public static bool Guards(string? service) => service != null && Guarded.Contains(service);

        /// <summary>The service, wrapped when a known game with terms is being translated.</summary>
        public static ITranslationService Wrap(ITranslationService service)
        {
            var (terms, glossary) = ActiveTerms();
            return terms.Count > 0 ? new TermGuardTranslationService(service, terms, glossary) : service;
        }

        public async Task<string?> TranslateAsync(string jsonData, string prompt)
        {
            JsonNode? request;
            try
            {
                request = JsonNode.Parse(jsonData);
            }
            catch (JsonException)
            {
                return await _inner.TranslateAsync(jsonData, prompt);
            }
            if (request?["text_blocks"] is not JsonArray blocks)
                return await _inner.TranslateAsync(jsonData, prompt);

            // Protect every block's text; remember each block's tokens by its id (or position)
            var maps = new Dictionary<string, IReadOnlyList<(string Token, string Term)>>();
            var originals = new Dictionary<string, string>();
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i] is not JsonObject block || block["text"]?.GetValue<string>() is not string text)
                    continue;
                string id = block["id"]?.ToString() ?? i.ToString();
                var guarded = TermGuard.Protect(text, _terms);
                if (guarded.Map.Count == 0)
                    continue;
                maps[id] = guarded.Map;
                originals[id] = text;
                block["text"] = guarded.Text;
            }
            if (maps.Count == 0)
                return await _inner.TranslateAsync(jsonData, prompt);

            string? response = await _inner.TranslateAsync(request.ToJsonString(), prompt);
            if (response == null)
                return null;
            try
            {
                var result = JsonNode.Parse(response);
                if (result?["translations"] is not JsonArray translations)
                    return response;
                for (int i = 0; i < translations.Count; i++)
                {
                    if (translations[i] is not JsonObject t)
                        continue;
                    string id = t["id"]?.ToString() ?? i.ToString();
                    if (!maps.TryGetValue(id, out var map))
                        continue;
                    if (t["translated_text"]?.GetValue<string>() is string translated)
                        t["translated_text"] = TermGuard.Restore(translated, map, _glossary);
                    if (t["original_text"] != null)
                        t["original_text"] = originals[id];
                }
                return result.ToJsonString(new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Restoring game terms failed: {ex.Message}");
                return response;
            }
        }
    }
}
