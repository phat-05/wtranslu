# goal4-game-font cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1542 | 2 | 0 | yes | 8 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 767 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 782 | 3 | 0 | yes | 9 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 927 | 2 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 676 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1237 | 3 | 0 | yes | 9 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 764 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 1034 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 464 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 524 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 735 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 367 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 337 | 1 | 0 | yes | 14 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 912 | 2 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 374 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2887 | 0 | 0 | yes | 6 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 1262 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 450 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 745 | 1 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 387 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 391 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 697 | 1 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 394 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 384 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 666 | 1 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 918 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 367 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 615 | 1 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 900 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 312 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 552 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 754,
    "median_ms": 676,
    "min_ms": 312,
    "max_ms": 2887,
    "ocr_runs": 56,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 342
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 956,
    "median_ms": 782,
    "min_ms": 676,
    "max_ms": 1542,
    "ocr_runs": 17,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 69
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 695,
    "median_ms": 538,
    "min_ms": 312,
    "max_ms": 2887,
    "ocr_runs": 39,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 273
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 763,
      "median_ms": 764,
      "min_ms": 337,
      "max_ms": 1542,
      "ocr_runs": 31,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 161
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 745,
      "median_ms": 584,
      "min_ms": 312,
      "max_ms": 2887,
      "ocr_runs": 25,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 181
    }
  }
}
```
