# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1980 | 1 | 0 | yes | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 1534 | 3 | 1 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 538 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 2107 | 3 | 1 |  | 19 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 571 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 689 | 2 | 0 | yes | 19 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 412 | 3 | 0 | yes | 18 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 487 | 3 | 1 |  | 19 | The Lighthouse Awakens |
| s1 | 8 | 648 | 2 | 0 | yes | 19 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 477 | 3 | 1 |  | 18 | The blue door opens only for the green lantern. |
| s1 | 10 | 398 | 3 | 0 | yes | 19 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 895,
    "median_ms": 571,
    "min_ms": 398,
    "max_ms": 2107,
    "ocr_runs": 28,
    "translation_requests": 4,
    "from_cache": 8,
    "image_cache_hits": 196
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 895,
    "median_ms": 571,
    "min_ms": 398,
    "max_ms": 2107,
    "ocr_runs": 28,
    "translation_requests": 4,
    "from_cache": 8,
    "image_cache_hits": 196
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 895,
      "median_ms": 571,
      "min_ms": 398,
      "max_ms": 2107,
      "ocr_runs": 28,
      "translation_requests": 4,
      "from_cache": 8,
      "image_cache_hits": 196
    }
  }
}
```
