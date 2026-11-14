# goal4-game-font style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1262 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 974 | 3 | 0 | yes | 16 | Find the red key before the tide turns. |
| s1 | 2 | 533 | 2 | 0 | yes | 20 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 818 | 3 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 319 | 2 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 681 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 368 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 813 | 2 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 721,
    "median_ms": 747,
    "min_ms": 319,
    "max_ms": 1262,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 136
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 721,
    "median_ms": 747,
    "min_ms": 319,
    "max_ms": 1262,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 136
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 721,
      "median_ms": 747,
      "min_ms": 319,
      "max_ms": 1262,
      "ocr_runs": 19,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 136
    }
  }
}
```
