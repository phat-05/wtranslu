# goal4-game-font style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2898 | 2 | 0 | yes | 7 | Chapter 2: The Lighthouse |
| s1 | 1 | 256 | 2 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 332 | 3 | 0 | yes | 17 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 735 | 3 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 813 | 3 | 0 | yes | 14 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 1331 | 3 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 771 | 3 | 0 | yes | 15 | The blue door opens only for the green lantern. |
| s1 | 7 | 990 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1016,
    "median_ms": 792,
    "min_ms": 256,
    "max_ms": 2898,
    "ocr_runs": 22,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 119
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1016,
    "median_ms": 792,
    "min_ms": 256,
    "max_ms": 2898,
    "ocr_runs": 22,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 119
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 1016,
      "median_ms": 792,
      "min_ms": 256,
      "max_ms": 2898,
      "ocr_runs": 22,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 119
    }
  }
}
```
