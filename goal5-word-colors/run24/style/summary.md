# goal5-word-colors style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1374 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 1213 | 3 | 1 | yes | 16 | Find the red key before the tide turns. |
| s1 | 2 | 471 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1945 | 3 | 1 |  | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 347 | 2 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 950 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 480 | 2 | 1 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 716 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 937,
    "median_ms": 833,
    "min_ms": 347,
    "max_ms": 1945,
    "ocr_runs": 19,
    "translation_requests": 3,
    "from_cache": 7,
    "image_cache_hits": 134
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 937,
    "median_ms": 833,
    "min_ms": 347,
    "max_ms": 1945,
    "ocr_runs": 19,
    "translation_requests": 3,
    "from_cache": 7,
    "image_cache_hits": 134
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 937,
      "median_ms": 833,
      "min_ms": 347,
      "max_ms": 1945,
      "ocr_runs": 19,
      "translation_requests": 3,
      "from_cache": 7,
      "image_cache_hits": 134
    }
  }
}
```
