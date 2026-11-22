# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3332 | 1 | 0 | yes | 3 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1380 | 3 | 1 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 873 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 617 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 528 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 729 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1397 | 2 | 1 |  | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 807 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 549 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 554 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 485 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 705 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 467 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 397 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 355 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 536 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1309 | 1 | 1 |  | 10 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 479 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 776 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 754 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 555 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 480 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 470 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 712 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 490 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 423 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 391 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 580 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 773 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 545 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 546 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 484 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 734,
    "median_ms": 552,
    "min_ms": 355,
    "max_ms": 3332,
    "ocr_runs": 62,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 377
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1208,
    "median_ms": 840,
    "min_ms": 528,
    "max_ms": 3332,
    "ocr_runs": 19,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 80
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 576,
    "median_ms": 540,
    "min_ms": 355,
    "max_ms": 1309,
    "ocr_runs": 43,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 297
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 857,
      "median_ms": 586,
      "min_ms": 355,
      "max_ms": 3332,
      "ocr_runs": 33,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 181
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 610,
      "median_ms": 546,
      "min_ms": 391,
      "max_ms": 1309,
      "ocr_runs": 29,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 196
    }
  }
}
```
