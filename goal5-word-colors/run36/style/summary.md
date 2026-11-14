# goal5-word-colors style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1487 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1452 | 3 | 1 | yes | 16 | Find the red key before the tide turns. |
| s1 | 2 | 442 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 521 | 3 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 382 | 2 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 428 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 567 | 2 | 1 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 1208 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 811,
    "median_ms": 544,
    "min_ms": 382,
    "max_ms": 1487,
    "ocr_runs": 19,
    "translation_requests": 2,
    "from_cache": 8,
    "image_cache_hits": 134
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 811,
    "median_ms": 544,
    "min_ms": 382,
    "max_ms": 1487,
    "ocr_runs": 19,
    "translation_requests": 2,
    "from_cache": 8,
    "image_cache_hits": 134
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 811,
      "median_ms": 544,
      "min_ms": 382,
      "max_ms": 1487,
      "ocr_runs": 19,
      "translation_requests": 2,
      "from_cache": 8,
      "image_cache_hits": 134
    }
  }
}
```
