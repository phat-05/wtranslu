# goal4-game-font style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1214 | 2 | 0 | yes | 14 | Chapter 2: The Lighthouse |
| s1 | 1 | 686 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 355 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 947 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 600 | 4 | 0 | yes | 16 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 1351 | 3 | 0 | yes | 19 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 766 | 4 | 0 | yes | 15 | The blue door opens only for the green lantern. |
| s1 | 7 | 617 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 817,
    "median_ms": 726,
    "min_ms": 355,
    "max_ms": 1351,
    "ocr_runs": 25,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 137
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 817,
    "median_ms": 726,
    "min_ms": 355,
    "max_ms": 1351,
    "ocr_runs": 25,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 137
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 817,
      "median_ms": 726,
      "min_ms": 355,
      "max_ms": 1351,
      "ocr_runs": 25,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 137
    }
  }
}
```
