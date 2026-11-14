# goal2-font-size style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1624 | 1 | 0 | yes | 13 | Chapter 2: The Lighthouse |
| s1 | 1 | 994 | 3 | 0 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 316 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 443 | 2 | 0 | yes | 20 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 686 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 5 | 443 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size style scenario",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 751,
    "median_ms": 564,
    "min_ms": 316,
    "max_ms": 1624,
    "ocr_runs": 15,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 105
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 751,
    "median_ms": 564,
    "min_ms": 316,
    "max_ms": 1624,
    "ocr_runs": 15,
    "translation_requests": 0,
    "from_cache": 6,
    "image_cache_hits": 105
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 751,
      "median_ms": 564,
      "min_ms": 316,
      "max_ms": 1624,
      "ocr_runs": 15,
      "translation_requests": 0,
      "from_cache": 6,
      "image_cache_hits": 105
    }
  }
}
```
