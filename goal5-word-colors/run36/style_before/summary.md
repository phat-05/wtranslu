# goal5-word-colors style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3233 | 1 | 0 | yes | 7 | Chapter 2: The Lighthouse |
| s1 | 1 | 726 | 3 | 0 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 847 | 3 | 1 | yes | 16 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 676 | 4 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 1164 | 3 | 0 | yes | 15 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 12 | 3 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 806 | 3 | 0 | yes | 16 | The blue door opens only for the green lantern. |
| s1 | 7 | 737 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |
| s1 | 1 | None | 0 | 0 |  | 0 | Find the red key before the tide turns. |

```json
{
  "label": "goal5-word-colors style scenario, features off",
  "all": {
    "n": 8,
    "missing": 1,
    "mean_ms": 1025,
    "median_ms": 772,
    "min_ms": 12,
    "max_ms": 3233,
    "ocr_runs": 23,
    "translation_requests": 1,
    "from_cache": 8,
    "image_cache_hits": 119
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1025,
    "median_ms": 772,
    "min_ms": 12,
    "max_ms": 3233,
    "ocr_runs": 23,
    "translation_requests": 1,
    "from_cache": 8,
    "image_cache_hits": 119
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 1,
      "mean_ms": 1025,
      "median_ms": 772,
      "min_ms": 12,
      "max_ms": 3233,
      "ocr_runs": 23,
      "translation_requests": 1,
      "from_cache": 8,
      "image_cache_hits": 119
    }
  }
}
```
