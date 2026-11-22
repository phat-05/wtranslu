# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2332 | 1 | 0 | yes | 9 | Chapter 2: The Lighthouse |
| s1 | 1 | 2330 | 2 | 1 |  | 18 | Find the red key before the tide turns. |
| s1 | 2 | 821 | 3 | 1 | yes | 16 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 384 | 2 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 516 | 3 | 0 | yes | 17 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 736 | 2 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 472 | 3 | 0 | yes | 17 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 977 | 2 | 1 |  | 17 | The Lighthouse Awakens |
| s1 | 8 | 499 | 3 | 0 | yes | 18 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 826 | 2 | 1 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 10 | 359 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 932,
    "median_ms": 736,
    "min_ms": 359,
    "max_ms": 2332,
    "ocr_runs": 26,
    "translation_requests": 4,
    "from_cache": 9,
    "image_cache_hits": 182
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 932,
    "median_ms": 736,
    "min_ms": 359,
    "max_ms": 2332,
    "ocr_runs": 26,
    "translation_requests": 4,
    "from_cache": 9,
    "image_cache_hits": 182
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 932,
      "median_ms": 736,
      "min_ms": 359,
      "max_ms": 2332,
      "ocr_runs": 26,
      "translation_requests": 4,
      "from_cache": 9,
      "image_cache_hits": 182
    }
  }
}
```
