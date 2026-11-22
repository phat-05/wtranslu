# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3368 | 1 | 0 | yes | 3 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1303 | 3 | 1 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 622 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 717 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 655 | 3 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 598 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1428 | 3 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 659 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 464 | 1 | 0 | yes | 14 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 555 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 634 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 565 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 436 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 605 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 476 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 526 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1665 | 1 | 1 |  | 9 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 479 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 704 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 853 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 531 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 390 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 502 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 546 | 2 | 0 | yes | 14 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 587 | 1 | 0 | yes | 14 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 646 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 310 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 353 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 395 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 404 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 458 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 513 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 717,
    "median_ms": 560,
    "min_ms": 310,
    "max_ms": 3368,
    "ocr_runs": 65,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 388
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1169,
    "median_ms": 688,
    "min_ms": 598,
    "max_ms": 3368,
    "ocr_runs": 20,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 84
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 567,
    "median_ms": 520,
    "min_ms": 310,
    "max_ms": 1665,
    "ocr_runs": 45,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 304
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 851,
      "median_ms": 614,
      "min_ms": 436,
      "max_ms": 3368,
      "ocr_runs": 36,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 185
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 584,
      "median_ms": 508,
      "min_ms": 310,
      "max_ms": 1665,
      "ocr_runs": 29,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 203
    }
  }
}
```
