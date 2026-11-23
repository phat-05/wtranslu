# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3458 | 1 | 0 | yes | 3 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1435 | 3 | 1 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 969 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 673 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 570 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 747 | 3 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 662 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 902 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 429 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 397 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 643 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 651 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 429 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 650 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 607 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 363 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2068 | 1 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 494 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 974 | 3 | 0 | yes | 9 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 575 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 350 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 644 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 415 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 478 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 440 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 735 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 718 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 492 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 460 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 556 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 325 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 485 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 744,
    "median_ms": 591,
    "min_ms": 325,
    "max_ms": 3458,
    "ocr_runs": 63,
    "translation_requests": 2,
    "from_cache": 30,
    "image_cache_hits": 369
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1177,
    "median_ms": 824,
    "min_ms": 570,
    "max_ms": 3458,
    "ocr_runs": 19,
    "translation_requests": 1,
    "from_cache": 7,
    "image_cache_hits": 80
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 599,
    "median_ms": 493,
    "min_ms": 325,
    "max_ms": 2068,
    "ocr_runs": 44,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 289
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 849,
      "median_ms": 650,
      "min_ms": 363,
      "max_ms": 3458,
      "ocr_runs": 34,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 178
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 638,
      "median_ms": 493,
      "min_ms": 325,
      "max_ms": 2068,
      "ocr_runs": 29,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 191
    }
  }
}
```
