# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 5 | 1 |  | 34 | Find the red key before the tide turns. |
| s1 | 1 | 622 | 8 | 1 |  | 44 | The blue door opens only for the green lantern. |
| s1 | 2 | 11363 | 8 | 1 |  | 48 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 5992,
    "median_ms": 5992,
    "min_ms": 622,
    "max_ms": 11363,
    "ocr_runs": 21,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 126
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 5992,
    "median_ms": 5992,
    "min_ms": 622,
    "max_ms": 11363,
    "ocr_runs": 21,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 126
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 5992,
      "median_ms": 5992,
      "min_ms": 622,
      "max_ms": 11363,
      "ocr_runs": 21,
      "translation_requests": 3,
      "from_cache": 0,
      "image_cache_hits": 126
    }
  }
}
```
