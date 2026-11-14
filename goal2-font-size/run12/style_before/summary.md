# goal2-font-size style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2301 | 2 | 0 | yes | 9 | Chapter 2: The Lighthouse |
| s1 | 1 | 1781 | 3 | 0 | yes | 19 | Find the red key before the tide turns. |
| s1 | 2 | 663 | 3 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1033 | 4 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 1600 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 5 | 591 | 4 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |
| s1 | 1 | None | 0 | 0 |  | 0 | Find the red key before the tide turns. |

```json
{
  "label": "goal2-font-size style scenario, features off",
  "all": {
    "n": 6,
    "missing": 1,
    "mean_ms": 1328,
    "median_ms": 1316,
    "min_ms": 591,
    "max_ms": 2301,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 98
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 1328,
    "median_ms": 1316,
    "min_ms": 591,
    "max_ms": 2301,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 98
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 1,
      "mean_ms": 1328,
      "median_ms": 1316,
      "min_ms": 591,
      "max_ms": 2301,
      "ocr_runs": 19,
      "translation_requests": 0,
      "from_cache": 6,
      "image_cache_hits": 98
    }
  }
}
```
