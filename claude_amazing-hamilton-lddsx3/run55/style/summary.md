# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1372 | 1 | 0 | yes | 14 | Chapter 2: The Lighthouse |
| s1 | 1 | 682 | 3 | 1 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 577 | 3 | 0 | yes | 20 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 523 | 3 | 0 | yes | 19 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 522 | 3 | 0 | yes | 20 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 753 | 2 | 0 | yes | 20 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 628 | 3 | 0 | yes | 19 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 457 | 3 | 1 |  | 19 | The Lighthouse Awakens |
| s1 | 8 | 339 | 3 | 0 | yes | 20 | The tide rises with the moon. / Every sailor knows |
| s1 | 9 | 514 | 3 | 1 | yes | 20 | The blue door opens only for the green lantern. |
| s1 | 10 | 641 | 2 | 0 | yes | 20 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 11,
    "missing": 0,
    "mean_ms": 637,
    "median_ms": 577,
    "min_ms": 339,
    "max_ms": 1372,
    "ocr_runs": 29,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 209
  },
  "first_time_lines": {
    "n": 11,
    "missing": 0,
    "mean_ms": 637,
    "median_ms": 577,
    "min_ms": 339,
    "max_ms": 1372,
    "ocr_runs": 29,
    "translation_requests": 3,
    "from_cache": 10,
    "image_cache_hits": 209
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 0,
      "mean_ms": 637,
      "median_ms": 577,
      "min_ms": 339,
      "max_ms": 1372,
      "ocr_runs": 29,
      "translation_requests": 3,
      "from_cache": 10,
      "image_cache_hits": 209
    }
  }
}
```
