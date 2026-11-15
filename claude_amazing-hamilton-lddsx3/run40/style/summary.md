# claude/amazing-hamilton-lddsx3 style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2041 | 1 | 1 |  | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 1412 | 3 | 1 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 512 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 800 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 554 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 305 | 2 | 0 | yes | 21 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 774 | 3 | 1 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 7 | 316 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 839,
    "median_ms": 664,
    "min_ms": 305,
    "max_ms": 2041,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 7,
    "image_cache_hits": 140
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 839,
    "median_ms": 664,
    "min_ms": 305,
    "max_ms": 2041,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 7,
    "image_cache_hits": 140
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 839,
      "median_ms": 664,
      "min_ms": 305,
      "max_ms": 2041,
      "ocr_runs": 20,
      "translation_requests": 3,
      "from_cache": 7,
      "image_cache_hits": 140
    }
  }
}
```
