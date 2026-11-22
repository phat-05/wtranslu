# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 17092 | 6 | 2 |  | 42 | Find the red key before the tide turns. |
| s1 | 1 | 3168 | 8 | 1 |  | 43 | The blue door opens only for the green lantern. |
| s1 | 2 | 8413 | 9 | 1 | yes | 58 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 3,
    "missing": 0,
    "mean_ms": 9558,
    "median_ms": 8413,
    "min_ms": 3168,
    "max_ms": 17092,
    "ocr_runs": 23,
    "translation_requests": 4,
    "from_cache": 1,
    "image_cache_hits": 143
  },
  "first_time_lines": {
    "n": 3,
    "missing": 0,
    "mean_ms": 9558,
    "median_ms": 8413,
    "min_ms": 3168,
    "max_ms": 17092,
    "ocr_runs": 23,
    "translation_requests": 4,
    "from_cache": 1,
    "image_cache_hits": 143
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 3,
      "missing": 0,
      "mean_ms": 9558,
      "median_ms": 8413,
      "min_ms": 3168,
      "max_ms": 17092,
      "ocr_runs": 23,
      "translation_requests": 4,
      "from_cache": 1,
      "image_cache_hits": 143
    }
  }
}
```
