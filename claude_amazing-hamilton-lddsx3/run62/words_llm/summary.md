# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 4 | 1 |  | 21 | Find the red key before the tide turns. |
| s1 | 1 | 4411 | 4 | 1 |  | 22 | The blue door opens only for the green lantern. |
| s1 | 2 | 13969 | 5 | 0 |  | 27 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 9190,
    "median_ms": 9190,
    "min_ms": 4411,
    "max_ms": 13969,
    "ocr_runs": 13,
    "translation_requests": 2,
    "from_cache": 0,
    "image_cache_hits": 70
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 9190,
    "median_ms": 9190,
    "min_ms": 4411,
    "max_ms": 13969,
    "ocr_runs": 13,
    "translation_requests": 2,
    "from_cache": 0,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 9190,
      "median_ms": 9190,
      "min_ms": 4411,
      "max_ms": 13969,
      "ocr_runs": 13,
      "translation_requests": 2,
      "from_cache": 0,
      "image_cache_hits": 70
    }
  }
}
```
