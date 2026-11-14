# goal3-colors style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1823 | 2 | 0 | yes | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 1598 | 3 | 0 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 608 | 2 | 1 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 692 | 3 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 1145 | 4 | 0 | yes | 14 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 811 | 3 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 668 | 3 | 0 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 7 | 812 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1020,
    "median_ms": 812,
    "min_ms": 608,
    "max_ms": 1823,
    "ocr_runs": 23,
    "translation_requests": 1,
    "from_cache": 8,
    "image_cache_hits": 126
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1020,
    "median_ms": 812,
    "min_ms": 608,
    "max_ms": 1823,
    "ocr_runs": 23,
    "translation_requests": 1,
    "from_cache": 8,
    "image_cache_hits": 126
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 1020,
      "median_ms": 812,
      "min_ms": 608,
      "max_ms": 1823,
      "ocr_runs": 23,
      "translation_requests": 1,
      "from_cache": 8,
      "image_cache_hits": 126
    }
  }
}
```
