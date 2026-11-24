# claude/amazing-hamilton-lddsx3 style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2869 | 2 | 0 | yes | 7 | Chapter 2: The Lighthouse |
| s1 | 1 | 2632 | 2 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 328 | 3 | 1 | yes | 17 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 688 | 3 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 1307 | 3 | 0 | yes | 16 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 651 | 4 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 1029 | 3 | 0 | yes | 15 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 670 | 3 | 0 | yes | 17 | The Lighthouse Awakens |
| s1 | 8 | 742 | 3 | 0 | yes | 17 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 1095 | 4 | 0 | yes | 14 | The blue door opens only for the green lantern. |
| s1 | 10 | 654 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario, features off",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 1151,
    "median_ms": 742,
    "min_ms": 328,
    "max_ms": 2869,
    "ocr_runs": 33,
    "translation_requests": 1,
    "from_cache": 11,
    "image_cache_hits": 171
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 1151,
    "median_ms": 742,
    "min_ms": 328,
    "max_ms": 2869,
    "ocr_runs": 33,
    "translation_requests": 1,
    "from_cache": 11,
    "image_cache_hits": 171
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 1151,
      "median_ms": 742,
      "min_ms": 328,
      "max_ms": 2869,
      "ocr_runs": 33,
      "translation_requests": 1,
      "from_cache": 11,
      "image_cache_hits": 171
    }
  }
}
```
