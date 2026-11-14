# goal2-font-size style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2699 | 2 | 0 | yes | 7 | Chapter 2: The Lighthouse |
| s1 | 1 | 2695 | 2 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 794 | 3 | 0 | yes | 16 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 641 | 4 | 0 | yes | 15 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 915 | 3 | 0 | yes | 16 | The blue door opens only for the green lantern. |
| s1 | 5 | 764 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size style scenario, features off",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 1418,
    "median_ms": 854,
    "min_ms": 641,
    "max_ms": 2699,
    "ocr_runs": 17,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 88
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 1418,
    "median_ms": 854,
    "min_ms": 641,
    "max_ms": 2699,
    "ocr_runs": 17,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 88
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 1418,
      "median_ms": 854,
      "min_ms": 641,
      "max_ms": 2699,
      "ocr_runs": 17,
      "translation_requests": 0,
      "from_cache": 6,
      "image_cache_hits": 88
    }
  }
}
```
