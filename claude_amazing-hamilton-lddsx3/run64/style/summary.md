# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1089 | 1 | 0 | yes | 14 | Chapter 2: The Lighthouse |
| s1 | 1 | 2900 | 3 | 1 |  | 18 | Find the red key before the tide turns. |
| s1 | 2 | 364 | 3 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 561 | 2 | 0 | yes | 20 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 609 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 584 | 3 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 546 | 2 | 0 | yes | 20 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 790 | 3 | 1 |  | 18 | The Lighthouse Awakens |
| s1 | 8 | 463 | 3 | 0 | yes | 18 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 439 | 2 | 1 |  | 20 | The blue door opens only for the green lantern. |
| s1 | 10 | 577 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 811,
    "median_ms": 577,
    "min_ms": 364,
    "max_ms": 2900,
    "ocr_runs": 28,
    "translation_requests": 3,
    "from_cache": 8,
    "image_cache_hits": 200
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 811,
    "median_ms": 577,
    "min_ms": 364,
    "max_ms": 2900,
    "ocr_runs": 28,
    "translation_requests": 3,
    "from_cache": 8,
    "image_cache_hits": 200
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 811,
      "median_ms": 577,
      "min_ms": 364,
      "max_ms": 2900,
      "ocr_runs": 28,
      "translation_requests": 3,
      "from_cache": 8,
      "image_cache_hits": 200
    }
  }
}
```
