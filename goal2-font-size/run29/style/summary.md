# goal2-font-size style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1328 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 1039 | 3 | 0 | yes | 16 | Find the red key before the tide turns. |
| s1 | 2 | 346 | 2 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 737 | 3 | 0 | yes | 17 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 527 | 2 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 5 | 833 | 3 | 1 |  | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size style scenario",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 802,
    "median_ms": 785,
    "min_ms": 346,
    "max_ms": 1328,
    "ocr_runs": 14,
    "translation_requests": 1,
    "from_cache": 5,
    "image_cache_hits": 99
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 802,
    "median_ms": 785,
    "min_ms": 346,
    "max_ms": 1328,
    "ocr_runs": 14,
    "translation_requests": 1,
    "from_cache": 5,
    "image_cache_hits": 99
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 802,
      "median_ms": 785,
      "min_ms": 346,
      "max_ms": 1328,
      "ocr_runs": 14,
      "translation_requests": 1,
      "from_cache": 5,
      "image_cache_hits": 99
    }
  }
}
```
