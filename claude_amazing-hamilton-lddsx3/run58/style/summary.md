# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1433 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 1329 | 3 | 1 | yes | 15 | Find the red key before the tide turns. |
| s1 | 2 | 389 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 475 | 3 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 522 | 2 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 700 | 3 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 505 | 2 | 0 | yes | 18 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 616 | 3 | 1 | yes | 17 | The Lighthouse Awakens |
| s1 | 8 | 507 | 2 | 0 | yes | 19 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 578 | 3 | 1 |  | 16 | The blue door opens only for the green lantern. |
| s1 | 10 | 525 | 2 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 689,
    "median_ms": 525,
    "min_ms": 389,
    "max_ms": 1433,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 186
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 689,
    "median_ms": 525,
    "min_ms": 389,
    "max_ms": 1433,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 186
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 689,
      "median_ms": 525,
      "min_ms": 389,
      "max_ms": 1433,
      "ocr_runs": 26,
      "translation_requests": 3,
      "from_cache": 10,
      "image_cache_hits": 186
    }
  }
}
```
