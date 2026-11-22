# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2854 | 1 | 1 |  | 5 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 516 | 3 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 746 | 3 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 657 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 434 | 3 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 581 | 3 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1312 | 2 | 1 |  | 13 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 605 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 379 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 389 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 429 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 462 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 491 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 550 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 421 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 479 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1524 | 1 | 1 |  | 10 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 567 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 503 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 625 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 634 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 640 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 511 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 475 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 543 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 364 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 395 | 2 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 619 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 628 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 602 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 496 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 345 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 649,
    "median_ms": 530,
    "min_ms": 345,
    "max_ms": 2854,
    "ocr_runs": 64,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 397
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 963,
    "median_ms": 631,
    "min_ms": 434,
    "max_ms": 2854,
    "ocr_runs": 20,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 87
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 545,
    "median_ms": 500,
    "min_ms": 345,
    "max_ms": 1524,
    "ocr_runs": 44,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 310
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 707,
      "median_ms": 504,
      "min_ms": 379,
      "max_ms": 2854,
      "ocr_runs": 35,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 192
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 592,
      "median_ms": 555,
      "min_ms": 345,
      "max_ms": 1524,
      "ocr_runs": 29,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 205
    }
  }
}
```
