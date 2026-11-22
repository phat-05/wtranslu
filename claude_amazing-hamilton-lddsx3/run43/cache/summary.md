# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3771 | 1 | 0 | yes | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1849 | 2 | 1 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 1031 | 3 | 0 | yes | 9 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1713 | 2 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 1123 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 2047 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1481 | 2 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 1350 | 3 | 0 | yes | 9 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 470 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 786 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 460 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 442 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 710 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 405 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 437 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 703 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1473 | 1 | 1 |  | 9 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 554 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 868 | 1 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 545 | 2 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 336 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 841 | 1 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 493 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 475 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 757 | 1 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 412 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 473 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 688 | 1 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 360 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 347 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 575 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 820 | 2 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s2 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 1,
    "mean_ms": 900,
    "median_ms": 696,
    "min_ms": 336,
    "max_ms": 3771,
    "ocr_runs": 57,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 349
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1796,
    "median_ms": 1597,
    "min_ms": 1031,
    "max_ms": 3771,
    "ocr_runs": 18,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 71
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 601,
    "median_ms": 519,
    "min_ms": 336,
    "max_ms": 1473,
    "ocr_runs": 39,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 278
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 1174,
      "median_ms": 908,
      "min_ms": 405,
      "max_ms": 3771,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 165
    },
    "s2": {
      "n": 16,
      "missing": 1,
      "mean_ms": 626,
      "median_ms": 550,
      "min_ms": 336,
      "max_ms": 1473,
      "ocr_runs": 26,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 184
    }
  }
}
```
