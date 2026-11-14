# goal2-font-size style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1955 | 2 | 0 | yes | 11 | Chapter 2: The Lighthouse |
| s1 | 1 | 1494 | 3 | 0 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 512 | 2 | 0 | yes | 20 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 884 | 4 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 552 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 5 | 524 | 4 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size style scenario, features off",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 987,
    "median_ms": 718,
    "min_ms": 512,
    "max_ms": 1955,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 99
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 987,
    "median_ms": 718,
    "min_ms": 512,
    "max_ms": 1955,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 99
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 987,
      "median_ms": 718,
      "min_ms": 512,
      "max_ms": 1955,
      "ocr_runs": 18,
      "translation_requests": 0,
      "from_cache": 6,
      "image_cache_hits": 99
    }
  }
}
```
