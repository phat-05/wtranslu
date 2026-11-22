# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 590 | 2 | 1 | yes | 7 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 1042 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 851 | 3 | 0 | yes | 9 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 938 | 2 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 678 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1454 | 3 | 1 |  | 9 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 809 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 830 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 509 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 489 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 743 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 458 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 777 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 423 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 433 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s1 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 0 | 1593 | 1 | 1 |  | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 487 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1284 | 3 | 0 | yes | 8 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 495 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 721 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 407 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 505 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 792 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 437 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 445 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 721 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 396 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 402 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 665 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 562 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 539 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 2,
    "mean_ms": 693,
    "median_ms": 590,
    "min_ms": 396,
    "max_ms": 1593,
    "ocr_runs": 58,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 343
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 909,
    "median_ms": 851,
    "min_ms": 590,
    "max_ms": 1454,
    "ocr_runs": 17,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 69
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 630,
    "median_ms": 507,
    "min_ms": 396,
    "max_ms": 1593,
    "ocr_runs": 41,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 274
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 2,
      "mean_ms": 735,
      "median_ms": 743,
      "min_ms": 423,
      "max_ms": 1454,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 161
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 653,
      "median_ms": 522,
      "min_ms": 396,
      "max_ms": 1593,
      "ocr_runs": 27,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 182
    }
  }
}
```
