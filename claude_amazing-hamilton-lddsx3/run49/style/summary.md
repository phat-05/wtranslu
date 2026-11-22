# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1516 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1368 | 3 | 1 |  | 16 | Find the red key before the tide turns. |
| s1 | 2 | 505 | 2 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 607 | 3 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 705 | 2 | 0 | yes | 17 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 621 | 2 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 890 | 3 | 0 | yes | 17 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 498 | 3 | 1 |  | 18 | The Lighthouse Awakens |
| s1 | 8 | 824 | 2 | 0 | yes | 17 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 561 | 2 | 1 |  | 18 | The blue door opens only for the green lantern. |
| s1 | 10 | 1015 | 3 | 0 | yes | 15 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 828,
    "median_ms": 705,
    "min_ms": 498,
    "max_ms": 1516,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 8,
    "image_cache_hits": 183
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 828,
    "median_ms": 705,
    "min_ms": 498,
    "max_ms": 1516,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 8,
    "image_cache_hits": 183
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 828,
      "median_ms": 705,
      "min_ms": 498,
      "max_ms": 1516,
      "ocr_runs": 26,
      "translation_requests": 3,
      "from_cache": 8,
      "image_cache_hits": 183
    }
  }
}
```
