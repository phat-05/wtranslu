# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1383 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 1208 | 3 | 1 | yes | 16 | Find the red key before the tide turns. |
| s1 | 2 | 394 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1878 | 3 | 1 |  | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 428 | 2 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 809 | 3 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 574 | 2 | 0 | yes | 19 | Lv.70  776,256  2026-11-15 14:39:01 HD |
| s1 | 7 | 766 | 3 | 1 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 8 | 544 | 2 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 9,
    "missing": 0,
    "mean_ms": 887,
    "median_ms": 766,
    "min_ms": 394,
    "max_ms": 1878,
    "ocr_runs": 21,
    "translation_requests": 3,
    "from_cache": 8,
    "image_cache_hits": 154
  },
  "first_time_lines": {
    "n": 9,
    "missing": 0,
    "mean_ms": 887,
    "median_ms": 766,
    "min_ms": 394,
    "max_ms": 1878,
    "ocr_runs": 21,
    "translation_requests": 3,
    "from_cache": 8,
    "image_cache_hits": 154
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 9,
      "missing": 0,
      "mean_ms": 887,
      "median_ms": 766,
      "min_ms": 394,
      "max_ms": 1878,
      "ocr_runs": 21,
      "translation_requests": 3,
      "from_cache": 8,
      "image_cache_hits": 154
    }
  }
}
```
