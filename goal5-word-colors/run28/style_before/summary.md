# goal5-word-colors style scenario, features off

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1728 | 2 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1245 | 3 | 0 | yes | 17 | Find the red key before the tide turns. |
| s1 | 2 | 361 | 2 | 0 | yes | 20 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 778 | 4 | 0 | yes | 16 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 704 | 3 | 0 | yes | 17 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 725 | 4 | 0 | yes | 17 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 693 | 3 | 0 | yes | 18 | The blue door opens only for the green lantern. |
| s1 | 7 | 619 | 4 | 0 | yes | 16 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors style scenario, features off",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 857,
    "median_ms": 714,
    "min_ms": 361,
    "max_ms": 1728,
    "ocr_runs": 25,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 133
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 857,
    "median_ms": 714,
    "min_ms": 361,
    "max_ms": 1728,
    "ocr_runs": 25,
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
      "mean_ms": 857,
      "median_ms": 714,
      "min_ms": 361,
      "max_ms": 1728,
      "ocr_runs": 25,
      "translation_requests": 0,
      "from_cache": 8,
      "image_cache_hits": 133
    }
  }
}
```
