# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1446 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1390 | 3 | 1 |  | 16 | Find the red key before the tide turns. |
| s1 | 2 | 401 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 513 | 3 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 556 | 2 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 698 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 589 | 2 | 0 | yes | 18 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 509 | 3 | 1 |  | 17 | The Lighthouse Awakens |
| s1 | 8 | 583 | 2 | 0 | yes | 18 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 429 | 3 | 1 |  | 17 | The blue door opens only for the green lantern. |
| s1 | 10 | 496 | 2 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 692,
    "median_ms": 556,
    "min_ms": 401,
    "max_ms": 1446,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 8,
    "image_cache_hits": 186
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 692,
    "median_ms": 556,
    "min_ms": 401,
    "max_ms": 1446,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 8,
    "image_cache_hits": 186
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 692,
      "median_ms": 556,
      "min_ms": 401,
      "max_ms": 1446,
      "ocr_runs": 26,
      "translation_requests": 3,
      "from_cache": 8,
      "image_cache_hits": 186
    }
  }
}
```
