# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1923 | 1 | 0 | yes | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 2264 | 2 | 1 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 715 | 3 | 0 | yes | 17 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 537 | 2 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 798 | 3 | 0 | yes | 16 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 537 | 2 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 1733 | 3 | 0 | yes | 17 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 1013 | 2 | 1 |  | 18 | The Lighthouse Awakens |
| s1 | 8 | 926 | 3 | 0 | yes | 17 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 574 | 2 | 1 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 10 | 755 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 1070,
    "median_ms": 798,
    "min_ms": 537,
    "max_ms": 2264,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 183
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 1070,
    "median_ms": 798,
    "min_ms": 537,
    "max_ms": 2264,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 183
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 1070,
      "median_ms": 798,
      "min_ms": 537,
      "max_ms": 2264,
      "ocr_runs": 26,
      "translation_requests": 3,
      "from_cache": 10,
      "image_cache_hits": 183
    }
  }
}
```
