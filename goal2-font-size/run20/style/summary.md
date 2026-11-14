# goal2-font-size style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1328 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 1013 | 3 | 0 | yes | 16 | Find the red key before the tide turns. |
| s1 | 2 | 294 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1698 | 3 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 461 | 2 | 0 | yes | 19 | The blue door opens only for the green lantern. |
| s1 | 5 | 875 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size style scenario",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 945,
    "median_ms": 944,
    "min_ms": 294,
    "max_ms": 1698,
    "ocr_runs": 14,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 100
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 945,
    "median_ms": 944,
    "min_ms": 294,
    "max_ms": 1698,
    "ocr_runs": 14,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 100
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 945,
      "median_ms": 944,
      "min_ms": 294,
      "max_ms": 1698,
      "ocr_runs": 14,
      "translation_requests": 0,
      "from_cache": 6,
      "image_cache_hits": 100
    }
  }
}
```
