# claude/amazing-hamilton-lddsx3 style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1975 | 2 | 0 | yes | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 1422 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 364 | 2 | 1 | yes | 20 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 713 | 4 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 555 | 4 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 902 | 3 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 670 | 3 | 0 | yes | 16 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 474 | 4 | 0 | yes | 17 | The Lighthouse Awakens |
| s1 | 8 | 515 | 3 | 0 | yes | 19 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 861 | 4 | 0 | yes | 16 | The blue door opens only for the green lantern. |
| s1 | 10 | 564 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario, features off",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 820,
    "median_ms": 670,
    "min_ms": 364,
    "max_ms": 1975,
    "ocr_runs": 35,
    "translation_requests": 1,
    "from_cache": 11,
    "image_cache_hits": 188
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 820,
    "median_ms": 670,
    "min_ms": 364,
    "max_ms": 1975,
    "ocr_runs": 35,
    "translation_requests": 1,
    "from_cache": 11,
    "image_cache_hits": 188
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 820,
      "median_ms": 670,
      "min_ms": 364,
      "max_ms": 1975,
      "ocr_runs": 35,
      "translation_requests": 1,
      "from_cache": 11,
      "image_cache_hits": 188
    }
  }
}
```
