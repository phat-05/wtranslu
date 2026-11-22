# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3983 | 1 | 0 | yes | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1675 | 2 | 1 |  | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 971 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1115 | 3 | 0 | yes | 8 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 909 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 694 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1538 | 2 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 773 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 858 | 1 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 558 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 359 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 928 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 338 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 554 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 836 | 1 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 479 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s1 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 0 | 1582 | 1 | 1 |  | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 488 | 1 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 737 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 448 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 452 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 751 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 510 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 561 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 789 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 515 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 541 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 806 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 443 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 443 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 997 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 406 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 1,
    "mean_ms": 845,
    "median_ms": 716,
    "min_ms": 338,
    "max_ms": 3983,
    "ocr_runs": 57,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 345
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1457,
    "median_ms": 1043,
    "min_ms": 694,
    "max_ms": 3983,
    "ocr_runs": 18,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 641,
    "median_ms": 548,
    "min_ms": 338,
    "max_ms": 1582,
    "ocr_runs": 39,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 275
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 1,
      "mean_ms": 1036,
      "median_ms": 847,
      "min_ms": 338,
      "max_ms": 3983,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 163
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 654,
      "median_ms": 528,
      "min_ms": 406,
      "max_ms": 1582,
      "ocr_runs": 26,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 182
    }
  }
}
```
