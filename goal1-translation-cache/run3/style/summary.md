# goal1-translation-cache style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2719 | 3 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 2206 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 1239 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1998 | 4 | 0 | yes | 16 | The blue door opens only for the green lantern. |
| s1 | 4 | 1279 | 4 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal1-translation-cache style scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1888,
    "median_ms": 1998,
    "min_ms": 1239,
    "max_ms": 2719,
    "ocr_runs": 17,
    "translation_requests": 0,
    "from_cache": 5,
    "image_cache_hits": 81
  },
  "first_time_lines": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1888,
    "median_ms": 1998,
    "min_ms": 1239,
    "max_ms": 2719,
    "ocr_runs": 17,
    "translation_requests": 0,
    "from_cache": 5,
    "image_cache_hits": 81
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 5,
      "missing": 0,
      "mean_ms": 1888,
      "median_ms": 1998,
      "min_ms": 1239,
      "max_ms": 2719,
      "ocr_runs": 17,
      "translation_requests": 0,
      "from_cache": 5,
      "image_cache_hits": 81
    }
  }
}
```
