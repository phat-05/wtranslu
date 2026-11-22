# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 409 | 2 | 1 | yes | 8 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 852 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 927 | 3 | 0 | yes | 9 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 767 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 759 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1905 | 2 | 1 |  | 10 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 917 | 2 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 906 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 349 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 349 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 872 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 507 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 491 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 732 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 350 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2586 | 0 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 984 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 538 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 581 | 1 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 889 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 579 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 611 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 842 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 506 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 494 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 751 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 388 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 377 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 924 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 347 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 377 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 738,
    "median_ms": 611,
    "min_ms": 347,
    "max_ms": 2586,
    "ocr_runs": 56,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 343
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 934,
    "median_ms": 852,
    "min_ms": 409,
    "max_ms": 1905,
    "ocr_runs": 17,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 69
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 680,
    "median_ms": 558,
    "min_ms": 347,
    "max_ms": 2586,
    "ocr_runs": 39,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 274
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 739,
      "median_ms": 759,
      "min_ms": 349,
      "max_ms": 1905,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 162
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 736,
      "median_ms": 580,
      "min_ms": 347,
      "max_ms": 2586,
      "ocr_runs": 25,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 181
    }
  }
}
```
