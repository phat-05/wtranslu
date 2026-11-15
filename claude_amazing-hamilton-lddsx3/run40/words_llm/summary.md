# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 5 | 1 |  | 29 | Find the red key before the tide turns. |
| s1 | 1 | 3327 | 7 | 1 |  | 48 | The blue door opens only for the green lantern. |
| s1 | 2 | 15094 | 8 | 1 | yes | 45 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 9210,
    "median_ms": 9210,
    "min_ms": 3327,
    "max_ms": 15094,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 122
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 9210,
    "median_ms": 9210,
    "min_ms": 3327,
    "max_ms": 15094,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 122
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 9210,
      "median_ms": 9210,
      "min_ms": 3327,
      "max_ms": 15094,
      "ocr_runs": 20,
      "translation_requests": 3,
      "from_cache": 1,
      "image_cache_hits": 122
    }
  }
}
```
