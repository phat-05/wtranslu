# goal5-word-colors coloured words, Ollama qwen2.5:3b

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1889 | 8 | 0 | yes | 54 | Find the red key before the tide turns. |
| s1 | 1 | 898 | 9 | 0 | yes | 58 | The blue door opens only for the green lantern. |
| s1 | 2 | 12644 | 10 | 1 |  | 56 | Ask Captain Mira about the Storm Crystal. |
| s1 | 1 | None | 0 | 0 |  | 0 | The blue door opens only for the green lantern. |

```json
{
  "label": "goal5-word-colors coloured words, Ollama qwen2.5:3b",
  "all": {
    "n": 3,
    "missing": 1,
    "mean_ms": 5144,
    "median_ms": 1889,
    "min_ms": 898,
    "max_ms": 12644,
    "ocr_runs": 27,
    "translation_requests": 1,
    "from_cache": 2,
    "image_cache_hits": 168
  },
  "first_time_lines": {
    "n": 3,
    "missing": 0,
    "mean_ms": 5144,
    "median_ms": 1889,
    "min_ms": 898,
    "max_ms": 12644,
    "ocr_runs": 27,
    "translation_requests": 1,
    "from_cache": 2,
    "image_cache_hits": 168
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 3,
      "missing": 1,
      "mean_ms": 5144,
      "median_ms": 1889,
      "min_ms": 898,
      "max_ms": 12644,
      "ocr_runs": 27,
      "translation_requests": 1,
      "from_cache": 2,
      "image_cache_hits": 168
    }
  }
}
```
