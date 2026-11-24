# claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 18796 | 7 | 1 |  | 43 | Find the red key before the tide turns. |
| s1 | 1 | 1688 | 9 | 1 | yes | 55 | The blue door opens only for the green lantern. |
| s1 | 2 | 8090 | 9 | 1 |  | 60 | Ask Captain Mira about the Storm Crystal. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 3,
    "missing": 0,
    "mean_ms": 9525,
    "median_ms": 8090,
    "min_ms": 1688,
    "max_ms": 18796,
    "ocr_runs": 25,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 158
  },
  "first_time_lines": {
    "n": 3,
    "missing": 0,
    "mean_ms": 9525,
    "median_ms": 8090,
    "min_ms": 1688,
    "max_ms": 18796,
    "ocr_runs": 25,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 158
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 3,
      "missing": 0,
      "mean_ms": 9525,
      "median_ms": 8090,
      "min_ms": 1688,
      "max_ms": 18796,
      "ocr_runs": 25,
      "translation_requests": 3,
      "from_cache": 1,
      "image_cache_hits": 158
    }
  }
}
```
