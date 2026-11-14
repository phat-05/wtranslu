# goal5-word-colors coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 5 | 1 |  | 28 | Find the red key before the tide turns. |
| s1 | 1 | 5231 | 7 | 1 |  | 43 | The blue door opens only for the green lantern. |
| s1 | 2 | 568 | 8 | 1 |  | 54 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "goal5-word-colors coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 2900,
    "median_ms": 2900,
    "min_ms": 568,
    "max_ms": 5231,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 125
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 2900,
    "median_ms": 2900,
    "min_ms": 568,
    "max_ms": 5231,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 125
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 2900,
      "median_ms": 2900,
      "min_ms": 568,
      "max_ms": 5231,
      "ocr_runs": 20,
      "translation_requests": 3,
      "from_cache": 0,
      "image_cache_hits": 125
    }
  }
}
```
