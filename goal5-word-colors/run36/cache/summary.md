# goal5-word-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 2049 | 2 | 1 |  | 8 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 777 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 906 | 3 | 0 | yes | 9 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 1060 | 2 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 800 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1618 | 3 | 1 |  | 8 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 701 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 344 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 356 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 640 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 886 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 576 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 578 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 866 | 2 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 578 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2619 | 0 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 933 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 462 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 484 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 831 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 508 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 519 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 802 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 451 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 454 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 716 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 381 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 367 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 847 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 528 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 500 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 779,
    "median_ms": 640,
    "min_ms": 344,
    "max_ms": 2619,
    "ocr_runs": 56,
    "translation_requests": 3,
    "from_cache": 28,
    "image_cache_hits": 343
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 1130,
    "median_ms": 906,
    "min_ms": 701,
    "max_ms": 2049,
    "ocr_runs": 17,
    "translation_requests": 2,
    "from_cache": 5,
    "image_cache_hits": 68
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 676,
    "median_ms": 552,
    "min_ms": 344,
    "max_ms": 2619,
    "ocr_runs": 39,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 275
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 849,
      "median_ms": 777,
      "min_ms": 344,
      "max_ms": 2049,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 13,
      "image_cache_hits": 161
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 713,
      "median_ms": 514,
      "min_ms": 367,
      "max_ms": 2619,
      "ocr_runs": 25,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 182
    }
  }
}
```
