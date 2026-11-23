# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3755 | 1 | 0 | yes | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 736 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 768 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 660 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 813 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 541 | 3 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 681 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 625 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 349 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 557 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 513 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 549 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 483 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 379 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 562 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 556 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1113 | 1 | 0 | yes | 10 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 424 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 652 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 606 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 365 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 543 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 493 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 731 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 671 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 428 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 395 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 330 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 508 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 733 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 505 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 412 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 670,
    "median_ms": 552,
    "min_ms": 330,
    "max_ms": 3755,
    "ocr_runs": 62,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 375
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1072,
    "median_ms": 708,
    "min_ms": 541,
    "max_ms": 3755,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 78
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 536,
    "median_ms": 510,
    "min_ms": 330,
    "max_ms": 1113,
    "ocr_runs": 43,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 297
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 783,
      "median_ms": 560,
      "min_ms": 349,
      "max_ms": 3755,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 179
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 557,
      "median_ms": 506,
      "min_ms": 330,
      "max_ms": 1113,
      "ocr_runs": 29,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 196
    }
  }
}
```
