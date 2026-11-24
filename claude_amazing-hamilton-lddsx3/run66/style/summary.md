# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1511 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1466 | 3 | 1 | yes | 16 | Find the red key before the tide turns. |
| s1 | 2 | 609 | 2 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 483 | 3 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 1028 | 2 | 0 | yes | 16 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 984 | 2 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 393 | 3 | 0 | yes | 17 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 883 | 2 | 1 |  | 16 | The Lighthouse Awakens |
| s1 | 8 | 386 | 2 | 0 | yes | 18 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 937 | 3 | 1 |  | 16 | The blue door opens only for the green lantern. |
| s1 | 10 | 513 | 2 | 0 | yes | 19 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 836,
    "median_ms": 883,
    "min_ms": 386,
    "max_ms": 1511,
    "ocr_runs": 25,
    "translation_requests": 3,
    "from_cache": 9,
    "image_cache_hits": 181
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 836,
    "median_ms": 883,
    "min_ms": 386,
    "max_ms": 1511,
    "ocr_runs": 25,
    "translation_requests": 3,
    "from_cache": 9,
    "image_cache_hits": 181
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 836,
      "median_ms": 883,
      "min_ms": 386,
      "max_ms": 1511,
      "ocr_runs": 25,
      "translation_requests": 3,
      "from_cache": 9,
      "image_cache_hits": 181
    }
  }
}
```
