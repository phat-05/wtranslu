# goal3-colors style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1228 | 2 | 0 | yes | 14 | Chapter 2: The Lighthouse |
| s1 | 1 | 702 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 378 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 679 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 578 | 4 | 0 | yes | 17 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 660 | 3 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 557 | 4 | 0 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 7 | 696 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 685,
    "median_ms": 670,
    "min_ms": 378,
    "max_ms": 1228,
    "ocr_runs": 25,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 139
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 685,
    "median_ms": 670,
    "min_ms": 378,
    "max_ms": 1228,
    "ocr_runs": 25,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 139
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 685,
      "median_ms": 670,
      "min_ms": 378,
      "max_ms": 1228,
      "ocr_runs": 25,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 139
    }
  }
}
```
