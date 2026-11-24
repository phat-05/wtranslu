# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 4 | 0 |  | 21 | Find the red key before the tide turns. |
| s1 | 1 | 12540 | 6 | 1 |  | 36 | The blue door opens only for the green lantern. |
| s1 | 2 | 9642 | 3 | 2 |  | 16 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 11091,
    "median_ms": 11091,
    "min_ms": 9642,
    "max_ms": 12540,
    "ocr_runs": 13,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 73
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 11091,
    "median_ms": 11091,
    "min_ms": 9642,
    "max_ms": 12540,
    "ocr_runs": 13,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 73
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 11091,
      "median_ms": 11091,
      "min_ms": 9642,
      "max_ms": 12540,
      "ocr_runs": 13,
      "translation_requests": 3,
      "from_cache": 0,
      "image_cache_hits": 73
    }
  }
}
```
