# goal5-word-colors coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 5 | 1 |  | 29 | Find the red key before the tide turns. |
| s1 | 1 | 3278 | 7 | 1 |  | 43 | The blue door opens only for the green lantern. |
| s1 | 2 | 1735 | 8 | 1 | yes | 48 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "goal5-word-colors coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 2506,
    "median_ms": 2506,
    "min_ms": 1735,
    "max_ms": 3278,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 120
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 2506,
    "median_ms": 2506,
    "min_ms": 1735,
    "max_ms": 3278,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 120
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 2506,
      "median_ms": 2506,
      "min_ms": 1735,
      "max_ms": 3278,
      "ocr_runs": 20,
      "translation_requests": 3,
      "from_cache": 1,
      "image_cache_hits": 120
    }
  }
}
```
