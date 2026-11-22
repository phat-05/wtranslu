# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2301 | 1 | 0 | yes | 9 | Chapter 2: The Lighthouse |
| s1 | 1 | 2082 | 2 | 1 |  | 19 | Find the red key before the tide turns. |
| s1 | 2 | 692 | 3 | 0 | yes | 17 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 427 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 748 | 2 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 569 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 630 | 2 | 0 | yes | 18 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 403 | 3 | 0 | yes | 17 | The Lighthouse Awakens |
| s1 | 8 | 399 | 2 | 0 | yes | 19 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 505 | 3 | 1 | yes | 16 | The blue door opens only for the green lantern. |
| s1 | 10 | 394 | 2 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 832,
    "median_ms": 569,
    "min_ms": 394,
    "max_ms": 2301,
    "ocr_runs": 26,
    "translation_requests": 2,
    "from_cache": 10,
    "image_cache_hits": 186
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 832,
    "median_ms": 569,
    "min_ms": 394,
    "max_ms": 2301,
    "ocr_runs": 26,
    "translation_requests": 2,
    "from_cache": 10,
    "image_cache_hits": 186
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 832,
      "median_ms": 569,
      "min_ms": 394,
      "max_ms": 2301,
      "ocr_runs": 26,
      "translation_requests": 2,
      "from_cache": 10,
      "image_cache_hits": 186
    }
  }
}
```
