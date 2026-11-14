# goal4-game-font cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3913 | 1 | 0 | yes | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 660 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 660 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 619 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 747 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 730 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 742 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 699 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 384 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 559 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 529 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 318 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 537 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 521 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 749 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 744 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1661 | 1 | 0 | yes | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 395 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 909 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 467 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 515 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 515 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 746 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 584 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 576 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 526 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 535 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 999 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 489 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 445 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 431 | 1 | 0 | yes | 14 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 634 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 736,
    "median_ms": 580,
    "min_ms": 318,
    "max_ms": 3913,
    "ocr_runs": 61,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 372
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1096,
    "median_ms": 714,
    "min_ms": 619,
    "max_ms": 3913,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 78
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 615,
    "median_ms": 532,
    "min_ms": 318,
    "max_ms": 1661,
    "ocr_runs": 42,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 294
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 819,
      "median_ms": 660,
      "min_ms": 318,
      "max_ms": 3913,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 178
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 652,
      "median_ms": 530,
      "min_ms": 395,
      "max_ms": 1661,
      "ocr_runs": 28,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 194
    }
  }
}
```
