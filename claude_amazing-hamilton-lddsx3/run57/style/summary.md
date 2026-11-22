# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1903 | 1 | 0 | yes | 10 | Chapter 2: The Lighthouse |
| s1 | 1 | 1973 | 2 | 1 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 888 | 3 | 0 | yes | 16 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 466 | 2 | 0 | yes | 19 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 895 | 3 | 0 | yes | 16 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 588 | 2 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 956 | 3 | 0 | yes | 17 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 535 | 2 | 1 | yes | 18 | The Lighthouse Awakens |
| s1 | 8 | 919 | 3 | 0 | yes | 17 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 485 | 2 | 1 |  | 19 | The blue door opens only for the green lantern. |
| s1 | 10 | 820 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 948,
    "median_ms": 888,
    "min_ms": 466,
    "max_ms": 1973,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 184
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 948,
    "median_ms": 888,
    "min_ms": 466,
    "max_ms": 1973,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 184
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 948,
      "median_ms": 888,
      "min_ms": 466,
      "max_ms": 1973,
      "ocr_runs": 26,
      "translation_requests": 3,
      "from_cache": 10,
      "image_cache_hits": 184
    }
  }
}
```
