# goal4-game-font style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2050 | 1 | 0 | yes | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 1512 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 490 | 2 | 0 | yes | 20 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 639 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 330 | 3 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 517 | 2 | 0 | yes | 19 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 762 | 3 | 0 | yes | 19 | The blue door opens only for the green lantern. |
| s1 | 7 | 525 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 853,
    "median_ms": 582,
    "min_ms": 330,
    "max_ms": 2050,
    "ocr_runs": 20,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 141
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 853,
    "median_ms": 582,
    "min_ms": 330,
    "max_ms": 2050,
    "ocr_runs": 20,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 141
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 853,
      "median_ms": 582,
      "min_ms": 330,
      "max_ms": 2050,
      "ocr_runs": 20,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 141
    }
  }
}
```
