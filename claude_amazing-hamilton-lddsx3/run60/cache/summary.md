# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3248 | 1 | 1 |  | 4 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1355 | 3 | 1 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 603 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 770 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 546 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 479 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 611 | 3 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 708 | 3 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 471 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 547 | 2 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 588 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 759 | 3 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 445 | 2 | 1 |  | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 388 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 382 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 489 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1844 | 1 | 1 |  | 9 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 599 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 442 | 1 | 0 | yes | 14 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 511 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 534 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 511 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 574 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 389 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 355 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 353 | 2 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 710 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 496 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 444 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 467 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 552 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 326 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 672,
    "median_ms": 522,
    "min_ms": 326,
    "max_ms": 3248,
    "ocr_runs": 65,
    "translation_requests": 4,
    "from_cache": 28,
    "image_cache_hits": 392
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1040,
    "median_ms": 660,
    "min_ms": 479,
    "max_ms": 3248,
    "ocr_runs": 20,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 86
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 549,
    "median_ms": 492,
    "min_ms": 326,
    "max_ms": 1844,
    "ocr_runs": 45,
    "translation_requests": 2,
    "from_cache": 22,
    "image_cache_hits": 306
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 774,
      "median_ms": 568,
      "min_ms": 382,
      "max_ms": 3248,
      "ocr_runs": 36,
      "translation_requests": 3,
      "from_cache": 13,
      "image_cache_hits": 189
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 569,
      "median_ms": 504,
      "min_ms": 326,
      "max_ms": 1844,
      "ocr_runs": 29,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 203
    }
  }
}
```
