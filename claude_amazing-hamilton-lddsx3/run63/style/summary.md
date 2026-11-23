# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1488 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 1201 | 3 | 1 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 546 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 696 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 548 | 3 | 0 | yes | 17 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 736 | 2 | 0 | yes | 20 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 707 | 3 | 0 | yes | 18 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 556 | 3 | 1 |  | 18 | The Lighthouse Awakens |
| s1 | 8 | 509 | 2 | 0 | yes | 20 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 841 | 3 | 1 |  | 17 | The blue door opens only for the green lantern. |
| s1 | 10 | 343 | 3 | 0 | yes | 19 | Captain, the merchant wants twelve gold coins for  |
| s1 | 1 | None | 0 | 0 |  | 0 | Find the red key before the tide turns. |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 1,
    "mean_ms": 743,
    "median_ms": 696,
    "min_ms": 343,
    "max_ms": 1488,
    "ocr_runs": 28,
    "translation_requests": 3,
    "from_cache": 9,
    "image_cache_hits": 196
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 743,
    "median_ms": 696,
    "min_ms": 343,
    "max_ms": 1488,
    "ocr_runs": 28,
    "translation_requests": 3,
    "from_cache": 9,
    "image_cache_hits": 196
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 1,
      "mean_ms": 743,
      "median_ms": 696,
      "min_ms": 343,
      "max_ms": 1488,
      "ocr_runs": 28,
      "translation_requests": 3,
      "from_cache": 9,
      "image_cache_hits": 196
    }
  }
}
```
