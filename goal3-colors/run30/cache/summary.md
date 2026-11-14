# goal3-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2597 | 1 | 0 | yes | 6 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 615 | 3 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 647 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 844 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 625 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 791 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 543 | 3 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 680 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 657 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 394 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 381 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 351 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 598 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 540 | 3 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 519 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 522 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1653 | 1 | 0 | yes | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 351 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 567 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 608 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 384 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 383 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 415 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 640 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 350 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 540 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 516 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 476 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 714 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 448 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 376 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 366 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 628,
    "median_ms": 540,
    "min_ms": 350,
    "max_ms": 2597,
    "ocr_runs": 62,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 377
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 918,
    "median_ms": 664,
    "min_ms": 543,
    "max_ms": 2597,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 83
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 531,
    "median_ms": 496,
    "min_ms": 350,
    "max_ms": 1653,
    "ocr_runs": 43,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 294
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 706,
      "median_ms": 606,
      "min_ms": 351,
      "max_ms": 2597,
      "ocr_runs": 34,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 181
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 549,
      "median_ms": 462,
      "min_ms": 350,
      "max_ms": 1653,
      "ocr_runs": 28,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 196
    }
  }
}
```
