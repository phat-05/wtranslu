# goal3-colors style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1749 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1161 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 430 | 3 | 1 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 599 | 2 | 0 | yes | 19 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 757 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 533 | 3 | 0 | yes | 19 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 410 | 2 | 0 | yes | 20 | The blue door opens only for the green lantern. |
| s1 | 7 | 610 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 781,
    "median_ms": 604,
    "min_ms": 410,
    "max_ms": 1749,
    "ocr_runs": 20,
    "translation_requests": 1,
    "from_cache": 8,
    "image_cache_hits": 143
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 781,
    "median_ms": 604,
    "min_ms": 410,
    "max_ms": 1749,
    "ocr_runs": 20,
    "translation_requests": 1,
    "from_cache": 8,
    "image_cache_hits": 143
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 781,
      "median_ms": 604,
      "min_ms": 410,
      "max_ms": 1749,
      "ocr_runs": 20,
      "translation_requests": 1,
      "from_cache": 8,
      "image_cache_hits": 143
    }
  }
}
```
