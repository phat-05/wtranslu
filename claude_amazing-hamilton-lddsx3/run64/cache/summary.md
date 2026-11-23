# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 0 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | None | 0 | 0 |  | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | None | 0 | 0 |  | 0 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | None | 1 | 0 |  | 0 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 791 | 2 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 617 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 706 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 667 | 3 | 0 | yes | 10 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 357 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 571 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 747 | 3 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 431 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 552 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 749 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 681 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1746 | 1 | 0 | yes | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 546 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1015 | 3 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 523 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 463 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 397 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 583 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 355 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 577 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 506 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 492 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 664 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 392 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 570 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 545 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 491 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 27,
    "missing": 5,
    "mean_ms": 620,
    "median_ms": 570,
    "min_ms": 355,
    "max_ms": 1746,
    "ocr_runs": 54,
    "translation_requests": 0,
    "from_cache": 27,
    "image_cache_hits": 322
  },
  "first_time_lines": {
    "n": 3,
    "missing": 5,
    "mean_ms": 705,
    "median_ms": 706,
    "min_ms": 617,
    "max_ms": 791,
    "ocr_runs": 8,
    "translation_requests": 0,
    "from_cache": 3,
    "image_cache_hits": 32
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 609,
    "median_ms": 549,
    "min_ms": 355,
    "max_ms": 1746,
    "ocr_runs": 46,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 290
  },
  "per_session": {
    "s1": {
      "n": 11,
      "missing": 5,
      "mean_ms": 624,
      "median_ms": 667,
      "min_ms": 357,
      "max_ms": 791,
      "ocr_runs": 26,
      "translation_requests": 0,
      "from_cache": 11,
      "image_cache_hits": 126
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 617,
      "median_ms": 534,
      "min_ms": 355,
      "max_ms": 1746,
      "ocr_runs": 28,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 196
    }
  }
}
```
