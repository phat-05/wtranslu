# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2468 | 1 | 0 | yes | 8 | Chapter 2: The Lighthouse |
| s1 | 1 | 2442 | 2 | 1 |  | 19 | Find the red key before the tide turns. |
| s1 | 2 | 874 | 3 | 0 | yes | 16 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 379 | 2 | 0 | yes | 19 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 713 | 3 | 0 | yes | 17 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 667 | 2 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 822 | 3 | 0 | yes | 16 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 630 | 2 | 1 | yes | 19 | The Lighthouse Awakens |
| s1 | 8 | 709 | 3 | 0 | yes | 17 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 509 | 2 | 1 |  | 19 | The blue door opens only for the green lantern. |
| s1 | 10 | 1091 | 3 | 0 | yes | 15 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 1028,
    "median_ms": 713,
    "min_ms": 379,
    "max_ms": 2468,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 9,
    "image_cache_hits": 183
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 1028,
    "median_ms": 713,
    "min_ms": 379,
    "max_ms": 2468,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 9,
    "image_cache_hits": 183
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 1028,
      "median_ms": 713,
      "min_ms": 379,
      "max_ms": 2468,
      "ocr_runs": 26,
      "translation_requests": 3,
      "from_cache": 9,
      "image_cache_hits": 183
    }
  }
}
```
