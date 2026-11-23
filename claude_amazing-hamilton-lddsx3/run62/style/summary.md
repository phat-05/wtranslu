# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1678 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1210 | 3 | 1 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 385 | 2 | 0 | yes | 20 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 671 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 521 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 685 | 2 | 0 | yes | 19 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 712 | 3 | 0 | yes | 18 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 1413 | 3 | 1 | yes | 18 | The Lighthouse Awakens |
| s1 | 8 | 434 | 2 | 0 | yes | 20 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 604 | 3 | 1 |  | 19 | The blue door opens only for the green lantern. |
| s1 | 10 | 540 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 805,
    "median_ms": 671,
    "min_ms": 385,
    "max_ms": 1678,
    "ocr_runs": 28,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 197
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 805,
    "median_ms": 671,
    "min_ms": 385,
    "max_ms": 1678,
    "ocr_runs": 28,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 197
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 805,
      "median_ms": 671,
      "min_ms": 385,
      "max_ms": 1678,
      "ocr_runs": 28,
      "translation_requests": 3,
      "from_cache": 10,
      "image_cache_hits": 197
    }
  }
}
```
