# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 5 | 1 |  | 29 | Find the red key before the tide turns. |
| s1 | 1 | 4511 | 7 | 1 |  | 41 | The blue door opens only for the green lantern. |
| s1 | 2 | 12099 | 8 | 1 |  | 49 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 8305,
    "median_ms": 8305,
    "min_ms": 4511,
    "max_ms": 12099,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 119
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 8305,
    "median_ms": 8305,
    "min_ms": 4511,
    "max_ms": 12099,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 119
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 8305,
      "median_ms": 8305,
      "min_ms": 4511,
      "max_ms": 12099,
      "ocr_runs": 20,
      "translation_requests": 3,
      "from_cache": 0,
      "image_cache_hits": 119
    }
  }
}
```
