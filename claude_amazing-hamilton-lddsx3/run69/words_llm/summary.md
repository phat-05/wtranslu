# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 3 | 0 |  | 14 | Find the red key before the tide turns. |
| s1 | 1 | 16245 | 3 | 1 |  | 18 | The blue door opens only for the green lantern. |
| s1 | 2 | 14929 | 4 | 1 |  | 21 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 15587,
    "median_ms": 15587,
    "min_ms": 14929,
    "max_ms": 16245,
    "ocr_runs": 10,
    "translation_requests": 2,
    "from_cache": 0,
    "image_cache_hits": 53
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 15587,
    "median_ms": 15587,
    "min_ms": 14929,
    "max_ms": 16245,
    "ocr_runs": 10,
    "translation_requests": 2,
    "from_cache": 0,
    "image_cache_hits": 53
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 15587,
      "median_ms": 15587,
      "min_ms": 14929,
      "max_ms": 16245,
      "ocr_runs": 10,
      "translation_requests": 2,
      "from_cache": 0,
      "image_cache_hits": 53
    }
  }
}
```
