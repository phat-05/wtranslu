# goal5-word-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1926 | 2 | 1 |  | 8 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 911 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 667 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 988 | 2 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 727 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1603 | 3 | 1 |  | 7 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 784 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 528 | 2 | 0 | yes | 10 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 389 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 695 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 388 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 373 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 657 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 324 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 389 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2589 | 0 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 921 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 360 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 404 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 700 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 364 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 399 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 922 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 575 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 368 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 876 | 2 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 339 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 335 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 891 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 352 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 337 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 712,
    "median_ms": 575,
    "min_ms": 324,
    "max_ms": 2589,
    "ocr_runs": 55,
    "translation_requests": 3,
    "from_cache": 28,
    "image_cache_hits": 342
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 1087,
    "median_ms": 911,
    "min_ms": 667,
    "max_ms": 1926,
    "ocr_runs": 17,
    "translation_requests": 2,
    "from_cache": 5,
    "image_cache_hits": 67
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 603,
    "median_ms": 394,
    "min_ms": 324,
    "max_ms": 2589,
    "ocr_runs": 38,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 275
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 757,
      "median_ms": 667,
      "min_ms": 324,
      "max_ms": 1926,
      "ocr_runs": 30,
      "translation_requests": 2,
      "from_cache": 13,
      "image_cache_hits": 161
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 671,
      "median_ms": 402,
      "min_ms": 335,
      "max_ms": 2589,
      "ocr_runs": 25,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 181
    }
  }
}
```
