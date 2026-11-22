# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 18248 | 6 | 1 |  | 41 | Find the red key before the tide turns. |
| s1 | 1 | 5552 | 9 | 2 |  | 53 | The blue door opens only for the green lantern. |
| s1 | 2 | 9305 | 9 | 1 |  | 53 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 3,
    "missing": 0,
    "mean_ms": 11035,
    "median_ms": 9305,
    "min_ms": 5552,
    "max_ms": 18248,
    "ocr_runs": 24,
    "translation_requests": 4,
    "from_cache": 0,
    "image_cache_hits": 147
  },
  "first_time_lines": {
    "n": 3,
    "missing": 0,
    "mean_ms": 11035,
    "median_ms": 9305,
    "min_ms": 5552,
    "max_ms": 18248,
    "ocr_runs": 24,
    "translation_requests": 4,
    "from_cache": 0,
    "image_cache_hits": 147
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 3,
      "missing": 0,
      "mean_ms": 11035,
      "median_ms": 9305,
      "min_ms": 5552,
      "max_ms": 18248,
      "ocr_runs": 24,
      "translation_requests": 4,
      "from_cache": 0,
      "image_cache_hits": 147
    }
  }
}
```
