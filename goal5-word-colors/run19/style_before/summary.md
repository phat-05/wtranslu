# goal5-word-colors style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2192 | 2 | 0 | yes | 10 | Chapter 2: The Lighthouse |
| s1 | 1 | 1687 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 631 | 3 | 0 | yes | 18 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 520 | 4 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 673 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 581 | 4 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 617 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 572 | 4 | 0 | yes | 17 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 934,
    "median_ms": 624,
    "min_ms": 520,
    "max_ms": 2192,
    "ocr_runs": 26,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 133
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 934,
    "median_ms": 624,
    "min_ms": 520,
    "max_ms": 2192,
    "ocr_runs": 26,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 133
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 934,
      "median_ms": 624,
      "min_ms": 520,
      "max_ms": 2192,
      "ocr_runs": 26,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 133
    }
  }
}
```
