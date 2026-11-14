# goal3-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3701 | 1 | 0 | yes | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 867 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 690 | 3 | 0 | yes | 9 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 792 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 632 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 691 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 913 | 3 | 0 | yes | 10 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 783 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 817 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 467 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 496 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 585 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 588 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 455 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 454 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 552 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1352 | 1 | 0 | yes | 9 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 500 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 694 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 738 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 353 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 379 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 724 | 1 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 346 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 373 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 423 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 725 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 714 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 529 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 581 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 639 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 713 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 727,
    "median_ms": 636,
    "min_ms": 346,
    "max_ms": 3701,
    "ocr_runs": 59,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 368
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1134,
    "median_ms": 788,
    "min_ms": 632,
    "max_ms": 3701,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 77
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 592,
    "median_ms": 566,
    "min_ms": 346,
    "max_ms": 1352,
    "ocr_runs": 41,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 291
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 843,
      "median_ms": 661,
      "min_ms": 454,
      "max_ms": 3701,
      "ocr_runs": 32,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 175
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 611,
      "median_ms": 610,
      "min_ms": 346,
      "max_ms": 1352,
      "ocr_runs": 27,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 193
    }
  }
}
```
