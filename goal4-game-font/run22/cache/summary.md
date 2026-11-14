# goal4-game-font cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 3240 | 1 | 0 | yes | 4 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 726 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 672 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 654 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 591 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 572 | 3 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 746 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 790 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 363 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 331 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 510 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 506 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 503 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 533 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 680 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1725 | 1 | 0 | yes | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 395 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 795 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 340 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 542 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 478 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 715 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 682 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 431 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 396 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 359 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 570 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 316 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 730 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 444 | 1 | 0 | yes | 14 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 732 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 680,
    "median_ms": 570,
    "min_ms": 316,
    "max_ms": 3240,
    "ocr_runs": 62,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 361
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 1029,
    "median_ms": 672,
    "min_ms": 572,
    "max_ms": 3240,
    "ocr_runs": 17,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 578,
    "median_ms": 508,
    "min_ms": 316,
    "max_ms": 1725,
    "ocr_runs": 45,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 291
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 761,
      "median_ms": 591,
      "min_ms": 331,
      "max_ms": 3240,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 167
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 603,
      "median_ms": 510,
      "min_ms": 316,
      "max_ms": 1725,
      "ocr_runs": 29,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 194
    }
  }
}
```
