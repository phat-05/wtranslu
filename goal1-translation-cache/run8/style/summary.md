# goal1-translation-cache style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1974 | 2 | 0 | yes | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 1430 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 888 | 3 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 796 | 4 | 0 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 4 | 882 | 4 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal1-translation-cache style scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1194,
    "median_ms": 888,
    "min_ms": 796,
    "max_ms": 1974,
    "ocr_runs": 16,
    "translation_requests": 0,
    "from_cache": 5,
    "image_cache_hits": 80
  },
  "first_time_lines": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1194,
    "median_ms": 888,
    "min_ms": 796,
    "max_ms": 1974,
    "ocr_runs": 16,
    "translation_requests": 0,
    "from_cache": 5,
    "image_cache_hits": 80
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 5,
      "missing": 0,
      "mean_ms": 1194,
      "median_ms": 888,
      "min_ms": 796,
      "max_ms": 1974,
      "ocr_runs": 16,
      "translation_requests": 0,
      "from_cache": 5,
      "image_cache_hits": 80
    }
  }
}
```
