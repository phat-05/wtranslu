# claude/amazing-hamilton-lddsx3 style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2611 | 2 | 0 | yes | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 2394 | 3 | 0 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 564 | 2 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1711 | 3 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 2637 | 4 | 1 |  | 15 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 1690 | 3 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 1398 | 3 | 0 | yes | 16 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 1737 | 4 | 0 | yes | 15 | The Lighthouse Awakens |
| s1 | 8 | 826 | 3 | 0 | yes | 16 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 1686 | 3 | 0 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 10 | 801 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario, features off",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 1641,
    "median_ms": 1690,
    "min_ms": 564,
    "max_ms": 2637,
    "ocr_runs": 33,
    "translation_requests": 1,
    "from_cache": 10,
    "image_cache_hits": 175
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 1641,
    "median_ms": 1690,
    "min_ms": 564,
    "max_ms": 2637,
    "ocr_runs": 33,
    "translation_requests": 1,
    "from_cache": 10,
    "image_cache_hits": 175
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 1641,
      "median_ms": 1690,
      "min_ms": 564,
      "max_ms": 2637,
      "ocr_runs": 33,
      "translation_requests": 1,
      "from_cache": 10,
      "image_cache_hits": 175
    }
  }
}
```
