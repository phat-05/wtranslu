# goal4-game-font style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2125 | 2 | 0 | yes | 10 | Chapter 2: The Lighthouse |
| s1 | 1 | 1597 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 557 | 2 | 1 | yes | 20 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 538 | 4 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 601 | 3 | 0 | yes | 12 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 557 | 3 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 555 | 4 | 0 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 7 | 908 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 930,
    "median_ms": 579,
    "min_ms": 538,
    "max_ms": 2125,
    "ocr_runs": 24,
    "translation_requests": 1,
    "from_cache": 8,
    "image_cache_hits": 129
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 930,
    "median_ms": 579,
    "min_ms": 538,
    "max_ms": 2125,
    "ocr_runs": 24,
    "translation_requests": 1,
    "from_cache": 8,
    "image_cache_hits": 129
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 930,
      "median_ms": 579,
      "min_ms": 538,
      "max_ms": 2125,
      "ocr_runs": 24,
      "translation_requests": 1,
      "from_cache": 8,
      "image_cache_hits": 129
    }
  }
}
```
