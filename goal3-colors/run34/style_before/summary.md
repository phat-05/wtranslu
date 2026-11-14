# goal3-colors style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3037 | 2 | 0 | yes | 7 | Chapter 2: The Lighthouse |
| s1 | 1 | 335 | 2 | 0 | yes | 19 | Find the red key before the tide turns. |
| s1 | 2 | 707 | 4 | 0 | yes | 16 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 665 | 3 | 0 | yes | 18 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 726 | 3 | 0 | yes | 17 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 1378 | 4 | 0 | yes | 16 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 535 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 608 | 4 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 999,
    "median_ms": 686,
    "min_ms": 335,
    "max_ms": 3037,
    "ocr_runs": 25,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 127
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 999,
    "median_ms": 686,
    "min_ms": 335,
    "max_ms": 3037,
    "ocr_runs": 25,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 127
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 999,
      "median_ms": 686,
      "min_ms": 335,
      "max_ms": 3037,
      "ocr_runs": 25,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 127
    }
  }
}
```
