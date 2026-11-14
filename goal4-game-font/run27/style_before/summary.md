# goal4-game-font style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2894 | 2 | 0 | yes | 7 | Chapter 2: The Lighthouse |
| s1 | 1 | 2691 | 2 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 435 | 3 | 0 | yes | 17 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 860 | 3 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 737 | 3 | 0 | yes | 16 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 859 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 1310 | 4 | 0 | yes | 14 | The blue door opens only for the green lantern. |
| s1 | 7 | 667 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1307,
    "median_ms": 860,
    "min_ms": 435,
    "max_ms": 2894,
    "ocr_runs": 23,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 122
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1307,
    "median_ms": 860,
    "min_ms": 435,
    "max_ms": 2894,
    "ocr_runs": 23,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 122
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 1307,
      "median_ms": 860,
      "min_ms": 435,
      "max_ms": 2894,
      "ocr_runs": 23,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 122
    }
  }
}
```
