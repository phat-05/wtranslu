# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3728 | 5 | 0 | yes | 0 | Chapter 2: The Lighthouse |
| s1 | 1 | 2960 | 10 | 0 | yes | 0 | Find the red key before the tide turns. |
| s1 | 2 | 1695 | 11 | 2 |  | 0 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 3190 | 10 | 1 | yes | 0 | The blue door opens only for the green lantern. |
| s1 | 4 | 828 | 10 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 2480,
    "median_ms": 2960,
    "min_ms": 828,
    "max_ms": 3728,
    "ocr_runs": 46,
    "translation_requests": 3,
    "from_cache": 4,
    "image_cache_hits": 0
  },
  "first_time_lines": {
    "n": 5,
    "missing": 0,
    "mean_ms": 2480,
    "median_ms": 2960,
    "min_ms": 828,
    "max_ms": 3728,
    "ocr_runs": 46,
    "translation_requests": 3,
    "from_cache": 4,
    "image_cache_hits": 0
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 5,
      "missing": 0,
      "mean_ms": 2480,
      "median_ms": 2960,
      "min_ms": 828,
      "max_ms": 3728,
      "ocr_runs": 46,
      "translation_requests": 3,
      "from_cache": 4,
      "image_cache_hits": 0
    }
  }
}
```
