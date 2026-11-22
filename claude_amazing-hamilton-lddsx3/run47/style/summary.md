# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2317 | 1 | 0 | yes | 9 | Chapter 2: The Lighthouse |
| s1 | 1 | 2230 | 2 | 1 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 841 | 3 | 0 | yes | 16 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 416 | 2 | 0 | yes | 19 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 861 | 3 | 0 | yes | 16 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 573 | 2 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 426 | 3 | 0 | yes | 16 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 536 | 2 | 1 | yes | 19 | The Lighthouse Awakens |
| s1 | 8 | 577 | 3 | 0 | yes | 16 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 501 | 2 | 1 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 10 | 553 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 894,
    "median_ms": 573,
    "min_ms": 416,
    "max_ms": 2317,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 11,
    "image_cache_hits": 182
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 894,
    "median_ms": 573,
    "min_ms": 416,
    "max_ms": 2317,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 11,
    "image_cache_hits": 182
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 894,
      "median_ms": 573,
      "min_ms": 416,
      "max_ms": 2317,
      "ocr_runs": 26,
      "translation_requests": 3,
      "from_cache": 11,
      "image_cache_hits": 182
    }
  }
}
```
