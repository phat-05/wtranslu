# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 4 | 0 |  | 21 | Find the red key before the tide turns. |
| s1 | 1 | 14538 | 5 | 1 |  | 34 | The blue door opens only for the green lantern. |
| s1 | 2 | 17300 | 6 | 1 |  | 29 | Ask Captain Mira about the Storm Crystal. |
| s1 | 1 | None | 0 | 0 |  | 0 | The blue door opens only for the green lantern. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 2,
    "missing": 2,
    "mean_ms": 15919,
    "median_ms": 15919,
    "min_ms": 14538,
    "max_ms": 17300,
    "ocr_runs": 15,
    "translation_requests": 2,
    "from_cache": 0,
    "image_cache_hits": 84
  },
  "first_time_lines": {
    "n": 2,
    "missing": 1,
    "mean_ms": 15919,
    "median_ms": 15919,
    "min_ms": 14538,
    "max_ms": 17300,
    "ocr_runs": 15,
    "translation_requests": 2,
    "from_cache": 0,
    "image_cache_hits": 84
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 2,
      "missing": 2,
      "mean_ms": 15919,
      "median_ms": 15919,
      "min_ms": 14538,
      "max_ms": 17300,
      "ocr_runs": 15,
      "translation_requests": 2,
      "from_cache": 0,
      "image_cache_hits": 84
    }
  }
}
```
