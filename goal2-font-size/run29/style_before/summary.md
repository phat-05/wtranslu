# goal2-font-size style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2721 | 2 | 0 | yes | 9 | Chapter 2: The Lighthouse |
| s1 | 1 | 2817 | 2 | 0 | yes | 19 | Find the red key before the tide turns. |
| s1 | 2 | 1575 | 4 | 1 |  | 14 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 1701 | 3 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 1604 | 3 | 0 | yes | 16 | The blue door opens only for the green lantern. |
| s1 | 5 | 692 | 3 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size style scenario, features off",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 1852,
    "median_ms": 1652,
    "min_ms": 692,
    "max_ms": 2817,
    "ocr_runs": 17,
    "translation_requests": 1,
    "from_cache": 5,
    "image_cache_hits": 90
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 1852,
    "median_ms": 1652,
    "min_ms": 692,
    "max_ms": 2817,
    "ocr_runs": 17,
    "translation_requests": 1,
    "from_cache": 5,
    "image_cache_hits": 90
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 1852,
      "median_ms": 1652,
      "min_ms": 692,
      "max_ms": 2817,
      "ocr_runs": 17,
      "translation_requests": 1,
      "from_cache": 5,
      "image_cache_hits": 90
    }
  }
}
```
