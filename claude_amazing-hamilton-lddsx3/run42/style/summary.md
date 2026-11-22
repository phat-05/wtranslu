# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1321 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 1126 | 3 | 1 | yes | 16 | Find the red key before the tide turns. |
| s1 | 2 | 347 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 679 | 3 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 429 | 2 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 821 | 3 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 542 | 2 | 0 | yes | 19 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 654 | 3 | 0 | yes | 17 | The Lighthouse Awakens |
| s1 | 8 | 353 | 3 | 0 | yes | 18 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 679 | 2 | 1 |  | 18 | The blue door opens only for the green lantern. |
| s1 | 10 | 451 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 673,
    "median_ms": 654,
    "min_ms": 347,
    "max_ms": 1321,
    "ocr_runs": 27,
    "translation_requests": 2,
    "from_cache": 10,
    "image_cache_hits": 189
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 673,
    "median_ms": 654,
    "min_ms": 347,
    "max_ms": 1321,
    "ocr_runs": 27,
    "translation_requests": 2,
    "from_cache": 10,
    "image_cache_hits": 189
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 673,
      "median_ms": 654,
      "min_ms": 347,
      "max_ms": 1321,
      "ocr_runs": 27,
      "translation_requests": 2,
      "from_cache": 10,
      "image_cache_hits": 189
    }
  }
}
```
