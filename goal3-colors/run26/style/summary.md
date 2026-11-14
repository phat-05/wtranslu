# goal3-colors style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1285 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 957 | 3 | 0 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 488 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 823 | 3 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 349 | 2 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 682 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 447 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 815 | 2 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 731,
    "median_ms": 748,
    "min_ms": 349,
    "max_ms": 1285,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 136
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 731,
    "median_ms": 748,
    "min_ms": 349,
    "max_ms": 1285,
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
      "mean_ms": 731,
      "median_ms": 748,
      "min_ms": 349,
      "max_ms": 1285,
      "ocr_runs": 19,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 136
    }
  }
}
```
