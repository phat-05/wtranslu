# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1156 | 1 | 0 | yes | 14 | Chapter 2: The Lighthouse |
| s1 | 1 | 771 | 3 | 1 |  | 18 | Find the red key before the tide turns. |
| s1 | 2 | 446 | 3 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 556 | 2 | 0 | yes | 20 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 747 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 573 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 409 | 2 | 0 | yes | 20 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 844 | 3 | 1 | yes | 17 | The Lighthouse Awakens |
| s1 | 8 | 447 | 2 | 0 | yes | 19 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 655 | 3 | 1 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 10 | 492 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 645,
    "median_ms": 573,
    "min_ms": 409,
    "max_ms": 1156,
    "ocr_runs": 28,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 196
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 645,
    "median_ms": 573,
    "min_ms": 409,
    "max_ms": 1156,
    "ocr_runs": 28,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 196
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 645,
      "median_ms": 573,
      "min_ms": 409,
      "max_ms": 1156,
      "ocr_runs": 28,
      "translation_requests": 3,
      "from_cache": 10,
      "image_cache_hits": 196
    }
  }
}
```
