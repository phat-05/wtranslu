# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 3 | 0 |  | 14 | Find the red key before the tide turns. |
| s1 | 1 | 14508 | 4 | 1 |  | 21 | The blue door opens only for the green lantern. |
| s1 | 2 | 16959 | 3 | 1 |  | 15 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 15734,
    "median_ms": 15734,
    "min_ms": 14508,
    "max_ms": 16959,
    "ocr_runs": 10,
    "translation_requests": 2,
    "from_cache": 0,
    "image_cache_hits": 50
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 15734,
    "median_ms": 15734,
    "min_ms": 14508,
    "max_ms": 16959,
    "ocr_runs": 10,
    "translation_requests": 2,
    "from_cache": 0,
    "image_cache_hits": 50
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 15734,
      "median_ms": 15734,
      "min_ms": 14508,
      "max_ms": 16959,
      "ocr_runs": 10,
      "translation_requests": 2,
      "from_cache": 0,
      "image_cache_hits": 50
    }
  }
}
```
