# goal2-font-size style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1803 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1194 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 424 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 655 | 2 | 0 | yes | 19 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 520 | 3 | 0 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 5 | 337 | 2 | 0 | yes | 20 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size style scenario",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 822,
    "median_ms": 588,
    "min_ms": 337,
    "max_ms": 1803,
    "ocr_runs": 14,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 105
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 822,
    "median_ms": 588,
    "min_ms": 337,
    "max_ms": 1803,
    "ocr_runs": 14,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 105
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 822,
      "median_ms": 588,
      "min_ms": 337,
      "max_ms": 1803,
      "ocr_runs": 14,
      "translation_requests": 0,
      "from_cache": 6,
      "image_cache_hits": 105
    }
  }
}
```
