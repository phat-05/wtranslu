# goal2-font-size style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 896 | 2 | 0 | yes | 14 | Chapter 2: The Lighthouse |
| s1 | 1 | 2514 | 2 | 0 | yes | 20 | Find the red key before the tide turns. |
| s1 | 2 | 969 | 3 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 470 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 370 | 2 | 0 | yes | 20 | The blue door opens only for the green lantern. |
| s1 | 5 | 558 | 3 | 0 | yes | 19 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size style scenario",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 963,
    "median_ms": 727,
    "min_ms": 370,
    "max_ms": 2514,
    "ocr_runs": 15,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 109
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 963,
    "median_ms": 727,
    "min_ms": 370,
    "max_ms": 2514,
    "ocr_runs": 15,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 109
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 963,
      "median_ms": 727,
      "min_ms": 370,
      "max_ms": 2514,
      "ocr_runs": 15,
      "translation_requests": 0,
      "from_cache": 6,
      "image_cache_hits": 109
    }
  }
}
```
