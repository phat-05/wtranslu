# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1619 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 1016 | 3 | 1 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 400 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 605 | 3 | 0 | yes | 20 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 630 | 2 | 0 | yes | 20 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 655 | 3 | 0 | yes | 19 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 425 | 3 | 0 | yes | 19 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 473 | 3 | 1 |  | 19 | The Lighthouse Awakens |
| s1 | 8 | 343 | 2 | 0 | yes | 21 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 561 | 3 | 1 | yes | 19 | The blue door opens only for the green lantern. |
| s1 | 10 | 351 | 3 | 0 | yes | 19 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 643,
    "median_ms": 561,
    "min_ms": 343,
    "max_ms": 1619,
    "ocr_runs": 29,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 206
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 643,
    "median_ms": 561,
    "min_ms": 343,
    "max_ms": 1619,
    "ocr_runs": 29,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 206
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 643,
      "median_ms": 561,
      "min_ms": 343,
      "max_ms": 1619,
      "ocr_runs": 29,
      "translation_requests": 3,
      "from_cache": 10,
      "image_cache_hits": 206
    }
  }
}
```
