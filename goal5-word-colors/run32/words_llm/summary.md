# goal5-word-colors coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 5 | 1 |  | 29 | Find the red key before the tide turns. |
| s1 | 1 | 6135 | 8 | 1 |  | 48 | The blue door opens only for the green lantern. |
| s1 | 2 | 3027 | 7 | 1 |  | 46 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "goal5-word-colors coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 4581,
    "median_ms": 4581,
    "min_ms": 3027,
    "max_ms": 6135,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 123
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 4581,
    "median_ms": 4581,
    "min_ms": 3027,
    "max_ms": 6135,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 123
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 4581,
      "median_ms": 4581,
      "min_ms": 3027,
      "max_ms": 6135,
      "ocr_runs": 20,
      "translation_requests": 3,
      "from_cache": 0,
      "image_cache_hits": 123
    }
  }
}
```
