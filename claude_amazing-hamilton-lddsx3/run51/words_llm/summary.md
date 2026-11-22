# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 4 | 0 |  | 21 | Find the red key before the tide turns. |
| s1 | 1 | 10067 | 5 | 2 |  | 32 | The blue door opens only for the green lantern. |
| s1 | 2 | 9937 | 5 | 1 |  | 28 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 10002,
    "median_ms": 10002,
    "min_ms": 9937,
    "max_ms": 10067,
    "ocr_runs": 14,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 81
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 10002,
    "median_ms": 10002,
    "min_ms": 9937,
    "max_ms": 10067,
    "ocr_runs": 14,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 81
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 10002,
      "median_ms": 10002,
      "min_ms": 9937,
      "max_ms": 10067,
      "ocr_runs": 14,
      "translation_requests": 3,
      "from_cache": 0,
      "image_cache_hits": 81
    }
  }
}
```
