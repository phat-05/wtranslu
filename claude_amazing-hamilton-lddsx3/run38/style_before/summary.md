# claude/amazing-hamilton-lddsx3 style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2806 | 2 | 0 | yes | 7 | Chapter 2: The Lighthouse |
| s1 | 1 | 115 | 2 | 0 | yes | 19 | Find the red key before the tide turns. |
| s1 | 2 | 412 | 3 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 688 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 777 | 4 | 0 | yes | 15 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 770 | 3 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 800 | 4 | 0 | yes | 17 | The blue door opens only for the green lantern. |
| s1 | 7 | 873 | 3 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 905,
    "median_ms": 774,
    "min_ms": 115,
    "max_ms": 2806,
    "ocr_runs": 24,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 129
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 905,
    "median_ms": 774,
    "min_ms": 115,
    "max_ms": 2806,
    "ocr_runs": 24,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 129
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 905,
      "median_ms": 774,
      "min_ms": 115,
      "max_ms": 2806,
      "ocr_runs": 24,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 129
    }
  }
}
```
