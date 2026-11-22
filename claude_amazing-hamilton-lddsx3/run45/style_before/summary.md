# claude/amazing-hamilton-lddsx3 style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2793 | 2 | 0 | yes | 7 | Chapter 2: The Lighthouse |
| s1 | 1 | 150 | 2 | 0 | yes | 19 | Find the red key before the tide turns. |
| s1 | 2 | 849 | 3 | 1 | yes | 16 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1023 | 4 | 0 | yes | 15 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 801 | 3 | 0 | yes | 16 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 694 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 768 | 4 | 0 | yes | 15 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 1010 | 3 | 0 | yes | 16 | The Lighthouse Awakens |
| s1 | 8 | 838 | 3 | 0 | yes | 17 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 860 | 3 | 0 | yes | 16 | The blue door opens only for the green lantern. |
| s1 | 10 | 1088 | 4 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario, features off",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 989,
    "median_ms": 849,
    "min_ms": 150,
    "max_ms": 2793,
    "ocr_runs": 34,
    "translation_requests": 1,
    "from_cache": 11,
    "image_cache_hits": 168
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 989,
    "median_ms": 849,
    "min_ms": 150,
    "max_ms": 2793,
    "ocr_runs": 34,
    "translation_requests": 1,
    "from_cache": 11,
    "image_cache_hits": 168
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 989,
      "median_ms": 849,
      "min_ms": 150,
      "max_ms": 2793,
      "ocr_runs": 34,
      "translation_requests": 1,
      "from_cache": 11,
      "image_cache_hits": 168
    }
  }
}
```
