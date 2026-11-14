# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1929 | 12 | 1 | yes | 0 | Chapter 2: The Lighthouse |
| s1 | 1 | 1211 | 16 | 0 | yes | 0 | Find the red key before the tide turns. |
| s1 | 2 | 1465 | 17 | 0 | yes | 0 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1305 | 17 | 0 | yes | 0 | The blue door opens only for the green lantern. |
| s1 | 4 | 1592 | 16 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1500,
    "median_ms": 1465,
    "min_ms": 1211,
    "max_ms": 1929,
    "ocr_runs": 78,
    "translation_requests": 1,
    "from_cache": 5,
    "image_cache_hits": 0
  },
  "first_time_lines": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1500,
    "median_ms": 1465,
    "min_ms": 1211,
    "max_ms": 1929,
    "ocr_runs": 78,
    "translation_requests": 1,
    "from_cache": 5,
    "image_cache_hits": 0
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 5,
      "missing": 0,
      "mean_ms": 1500,
      "median_ms": 1465,
      "min_ms": 1211,
      "max_ms": 1929,
      "ocr_runs": 78,
      "translation_requests": 1,
      "from_cache": 5,
      "image_cache_hits": 0
    }
  }
}
```
