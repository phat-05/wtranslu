# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3986 | 1 | 0 | yes | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1498 | 2 | 1 |  | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 689 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 614 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 778 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 747 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1431 | 2 | 1 |  | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 605 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 561 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 531 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 745 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 543 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 505 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 640 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 618 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 557 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1975 | 1 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 329 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 541 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 770 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 548 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 537 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 469 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 683 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 429 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 382 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 384 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 581 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 540 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 530 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 473 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 416 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 1,
    "mean_ms": 770,
    "median_ms": 559,
    "min_ms": 329,
    "max_ms": 3986,
    "ocr_runs": 63,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 372
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1294,
    "median_ms": 762,
    "min_ms": 605,
    "max_ms": 3986,
    "ocr_runs": 19,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 78
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 595,
    "median_ms": 540,
    "min_ms": 329,
    "max_ms": 1975,
    "ocr_runs": 44,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 294
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 940,
      "median_ms": 629,
      "min_ms": 505,
      "max_ms": 3986,
      "ocr_runs": 35,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 176
    },
    "s2": {
      "n": 16,
      "missing": 1,
      "mean_ms": 599,
      "median_ms": 534,
      "min_ms": 329,
      "max_ms": 1975,
      "ocr_runs": 28,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 196
    }
  }
}
```
