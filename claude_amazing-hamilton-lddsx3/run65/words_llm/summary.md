# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 4 | 1 |  | 21 | Find the red key before the tide turns. |
| s1 | 1 | 5037 | 6 | 1 |  | 42 | The blue door opens only for the green lantern. |
| s1 | 2 | 13488 | 6 | 1 |  | 33 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 1,
    "mean_ms": 9262,
    "median_ms": 9262,
    "min_ms": 5037,
    "max_ms": 13488,
    "ocr_runs": 16,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 96
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 9262,
    "median_ms": 9262,
    "min_ms": 5037,
    "max_ms": 13488,
    "ocr_runs": 16,
    "translation_requests": 3,
    "from_cache": 0,
    "image_cache_hits": 96
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 1,
      "mean_ms": 9262,
      "median_ms": 9262,
      "min_ms": 5037,
      "max_ms": 13488,
      "ocr_runs": 16,
      "translation_requests": 3,
      "from_cache": 0,
      "image_cache_hits": 96
    }
  }
}
```
