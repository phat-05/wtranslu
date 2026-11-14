# fix-wgc-latest-frame style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3229 | 8 | 0 | yes | 0 | Chapter 2: The Lighthouse |
| s1 | 1 | 1314 | 14 | 0 | yes | 0 | Find the red key before the tide turns. |
| s1 | 2 | 2380 | 13 | 0 | yes | 0 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1167 | 14 | 0 | yes | 0 | The blue door opens only for the green lantern. |
| s1 | 4 | 1493 | 13 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "fix-wgc-latest-frame style scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1917,
    "median_ms": 1493,
    "min_ms": 1167,
    "max_ms": 3229,
    "ocr_runs": 62,
    "translation_requests": 0,
    "from_cache": 5,
    "image_cache_hits": 0
  },
  "first_time_lines": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1917,
    "median_ms": 1493,
    "min_ms": 1167,
    "max_ms": 3229,
    "ocr_runs": 62,
    "translation_requests": 0,
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
      "mean_ms": 1917,
      "median_ms": 1493,
      "min_ms": 1167,
      "max_ms": 3229,
      "ocr_runs": 62,
      "translation_requests": 0,
      "from_cache": 5,
      "image_cache_hits": 0
    }
  }
}
```
