# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1604 | 2 | 1 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 845 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 912 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 730 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 793 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1643 | 3 | 1 |  | 10 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 702 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 572 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 440 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 559 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 669 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 498 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 818 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 664 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 729 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1630 | 1 | 1 |  | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 644 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 740 | 1 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 386 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 436 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 550 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 664 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 554 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 334 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 467 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 630 | 2 | 1 |  | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 409 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 536 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 579 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 670 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 493 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 706,
    "median_ms": 644,
    "min_ms": 334,
    "max_ms": 1643,
    "ocr_runs": 61,
    "translation_requests": 4,
    "from_cache": 27,
    "image_cache_hits": 358
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 1033,
    "median_ms": 845,
    "min_ms": 702,
    "max_ms": 1643,
    "ocr_runs": 18,
    "translation_requests": 2,
    "from_cache": 5,
    "image_cache_hits": 74
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 611,
    "median_ms": 566,
    "min_ms": 334,
    "max_ms": 1630,
    "ocr_runs": 43,
    "translation_requests": 2,
    "from_cache": 22,
    "image_cache_hits": 284
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 812,
      "median_ms": 729,
      "min_ms": 440,
      "max_ms": 1643,
      "ocr_runs": 34,
      "translation_requests": 2,
      "from_cache": 13,
      "image_cache_hits": 168
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 608,
      "median_ms": 552,
      "min_ms": 334,
      "max_ms": 1630,
      "ocr_runs": 27,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 190
    }
  }
}
```
