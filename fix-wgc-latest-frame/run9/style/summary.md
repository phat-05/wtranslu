# fix-wgc-latest-frame style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 4729 | 6 | 1 |  | 0 | Chapter 2: The Lighthouse |
| s1 | 1 | 1007 | 12 | 0 | yes | 0 | Find the red key before the tide turns. |
| s1 | 2 | 1329 | 13 | 1 | yes | 0 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 757 | 13 | 0 | yes | 0 | The blue door opens only for the green lantern. |
| s1 | 4 | 938 | 12 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "fix-wgc-latest-frame style scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1752,
    "median_ms": 1007,
    "min_ms": 757,
    "max_ms": 4729,
    "ocr_runs": 56,
    "translation_requests": 2,
    "from_cache": 4,
    "image_cache_hits": 0
  },
  "first_time_lines": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1752,
    "median_ms": 1007,
    "min_ms": 757,
    "max_ms": 4729,
    "ocr_runs": 56,
    "translation_requests": 2,
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
      "mean_ms": 1752,
      "median_ms": 1007,
      "min_ms": 757,
      "max_ms": 4729,
      "ocr_runs": 56,
      "translation_requests": 2,
      "from_cache": 4,
      "image_cache_hits": 0
    }
  }
}
```
