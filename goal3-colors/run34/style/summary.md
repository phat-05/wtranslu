# goal3-colors style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1347 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 958 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 490 | 3 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 564 | 2 | 0 | yes | 19 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 773 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 414 | 3 | 0 | yes | 19 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 670 | 2 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 546 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 720,
    "median_ms": 617,
    "min_ms": 414,
    "max_ms": 1347,
    "ocr_runs": 20,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 141
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 720,
    "median_ms": 617,
    "min_ms": 414,
    "max_ms": 1347,
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
      "mean_ms": 720,
      "median_ms": 617,
      "min_ms": 414,
      "max_ms": 1347,
      "ocr_runs": 20,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 141
    }
  }
}
```
