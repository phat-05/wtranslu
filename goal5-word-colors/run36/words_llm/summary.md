# goal5-word-colors coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 3 | 0 |  | 17 | Find the red key before the tide turns. |
| s1 | 1 | 10726 | 6 | 2 |  | 32 | The blue door opens only for the green lantern. |
| s1 | 2 | 11007 | 6 | 1 |  | 35 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "goal5-word-colors coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 10866,
    "median_ms": 10866,
    "min_ms": 10726,
    "max_ms": 11007,
    "ocr_runs": 15,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 84
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 10866,
    "median_ms": 10866,
    "min_ms": 10726,
    "max_ms": 11007,
    "ocr_runs": 15,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 84
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 10866,
      "median_ms": 10866,
      "min_ms": 10726,
      "max_ms": 11007,
      "ocr_runs": 15,
      "translation_requests": 3,
      "from_cache": 0,
      "image_cache_hits": 84
    }
  }
}
```
