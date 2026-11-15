# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2471 | 1 | 0 | yes | 9 | Chapter 2: The Lighthouse |
| s1 | 1 | 2028 | 3 | 1 | yes | 19 | Find the red key before the tide turns. |
| s1 | 2 | 632 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 387 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 347 | 3 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 490 | 2 | 0 | yes | 20 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 906 | 3 | 1 |  | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 363 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 953,
    "median_ms": 561,
    "min_ms": 347,
    "max_ms": 2471,
    "ocr_runs": 20,
    "translation_requests": 2,
    "from_cache": 7,
    "image_cache_hits": 140
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 953,
    "median_ms": 561,
    "min_ms": 347,
    "max_ms": 2471,
    "ocr_runs": 20,
    "translation_requests": 2,
    "from_cache": 7,
    "image_cache_hits": 140
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 953,
      "median_ms": 561,
      "min_ms": 347,
      "max_ms": 2471,
      "ocr_runs": 20,
      "translation_requests": 2,
      "from_cache": 7,
      "image_cache_hits": 140
    }
  }
}
```
