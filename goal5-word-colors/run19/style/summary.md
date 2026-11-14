# goal5-word-colors style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1639 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1088 | 3 | 1 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 540 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 414 | 2 | 0 | yes | 20 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 567 | 3 | 0 | yes | 19 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 525 | 3 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 468 | 2 | 2 |  | 20 | The blue door opens only for the green lantern. |
| s1 | 7 | 606 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 731,
    "median_ms": 554,
    "min_ms": 414,
    "max_ms": 1639,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 7,
    "image_cache_hits": 144
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 731,
    "median_ms": 554,
    "min_ms": 414,
    "max_ms": 1639,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 7,
    "image_cache_hits": 144
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 731,
      "median_ms": 554,
      "min_ms": 414,
      "max_ms": 1639,
      "ocr_runs": 20,
      "translation_requests": 3,
      "from_cache": 7,
      "image_cache_hits": 144
    }
  }
}
```
