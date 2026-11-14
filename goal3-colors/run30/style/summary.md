# goal3-colors style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 890 | 2 | 0 | yes | 14 | Chapter 2: The Lighthouse |
| s1 | 1 | 2482 | 2 | 0 | yes | 19 | Find the red key before the tide turns. |
| s1 | 2 | 987 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 476 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 440 | 2 | 0 | yes | 20 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 926 | 3 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 419 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 337 | 2 | 0 | yes | 20 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 870,
    "median_ms": 683,
    "min_ms": 337,
    "max_ms": 2482,
    "ocr_runs": 20,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 146
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 870,
    "median_ms": 683,
    "min_ms": 337,
    "max_ms": 2482,
    "ocr_runs": 20,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 146
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 870,
      "median_ms": 683,
      "min_ms": 337,
      "max_ms": 2482,
      "ocr_runs": 20,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 146
    }
  }
}
```
