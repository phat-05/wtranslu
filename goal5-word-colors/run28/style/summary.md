# goal5-word-colors style scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 1746 | 1 | 0 | yes | 12 | Chapter 2: The Lighthouse |
| s1 | 1 | 1191 | 3 | 1 | yes | 18 | Find the red key before the tide turns. |
| s1 | 2 | 350 | 3 | 0 | yes | 19 | Continue / Load Game / Settings / Quit |
| s1 | 3 | 464 | 2 | 0 | yes | 20 | QUEST COMPLETE: THE LIGHTHOUSE KEEPER |
| s1 | 4 | 654 | 3 | 0 | yes | 18 | The storm is coming. Hold on to the mast! |
| s1 | 5 | 425 | 3 | 0 | yes | 18 | Tip: press Space to skip the cutscene. |
| s1 | 6 | 1073 | 2 | 1 | yes | 20 | The blue door opens only for the green lantern. |
| s1 | 7 | 786 | 3 | 0 | yes | 18 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors style scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 836,
    "median_ms": 720,
    "min_ms": 350,
    "max_ms": 1746,
    "ocr_runs": 20,
    "translation_requests": 2,
    "from_cache": 8,
    "image_cache_hits": 143
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 836,
    "median_ms": 720,
    "min_ms": 350,
    "max_ms": 1746,
    "ocr_runs": 20,
    "translation_requests": 2,
    "from_cache": 8,
    "image_cache_hits": 143
  },
  "repeated_lines": {
    "n": 0
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 836,
      "median_ms": 720,
      "min_ms": 350,
      "max_ms": 1746,
      "ocr_runs": 20,
      "translation_requests": 2,
      "from_cache": 8,
      "image_cache_hits": 143
    }
  }
}
```
