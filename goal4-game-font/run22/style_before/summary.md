# goal4-game-font style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2065 | 2 | 0 | yes | 10 | Chapter 2: The Lighthouse |
| s1 | 1 | 1543 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 530 | 2 | 1 | yes | 21 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 829 | 4 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 1443 | 3 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 1459 | 4 | 1 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 508 | 3 | 0 | yes | 19 | The blue door opens only for the green lantern. |
| s1 | 7 | 947 | 4 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1166,
    "median_ms": 1195,
    "min_ms": 508,
    "max_ms": 2065,
    "ocr_runs": 25,
    "translation_requests": 2,
    "from_cache": 8,
    "image_cache_hits": 135
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1166,
    "median_ms": 1195,
    "min_ms": 508,
    "max_ms": 2065,
    "ocr_runs": 25,
    "translation_requests": 2,
    "from_cache": 8,
    "image_cache_hits": 135
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 1166,
      "median_ms": 1195,
      "min_ms": 508,
      "max_ms": 2065,
      "ocr_runs": 25,
      "translation_requests": 2,
      "from_cache": 8,
      "image_cache_hits": 135
    }
  }
}
```
