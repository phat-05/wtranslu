# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 72 | 2 | 1 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 794 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1174 | 2 | 0 | yes | 9 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 699 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 1282 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1479 | 2 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 687 | 3 | 0 | yes | 9 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 370 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 691 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 561 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 560 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 789 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 513 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 501 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 734 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2313 | 1 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 830 | 1 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 376 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 432 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 666 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 553 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 418 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 911 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 349 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 361 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 828 | 1 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 541 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 412 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 727 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 335 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 334 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 687,
    "median_ms": 561,
    "min_ms": 72,
    "max_ms": 2313,
    "ocr_runs": 56,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 347
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 884,
    "median_ms": 794,
    "min_ms": 72,
    "max_ms": 1479,
    "ocr_runs": 18,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 629,
    "median_ms": 547,
    "min_ms": 334,
    "max_ms": 2313,
    "ocr_runs": 38,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 277
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 727,
      "median_ms": 691,
      "min_ms": 72,
      "max_ms": 1479,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 165
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 649,
      "median_ms": 486,
      "min_ms": 334,
      "max_ms": 2313,
      "ocr_runs": 25,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 182
    }
  }
}
```
