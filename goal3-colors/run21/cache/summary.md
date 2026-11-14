# goal3-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3241 | 1 | 0 | yes | 3 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 779 | 3 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 729 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 754 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 652 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 588 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 787 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 1065 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 501 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 410 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 437 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 694 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 535 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 472 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 458 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 677 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 955 | 1 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 396 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 397 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 386 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 589 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 350 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 362 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 303 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 461 | 1 | 0 | yes | 14 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 657 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 428 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 350 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 518 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 473 | 1 | 0 | yes | 14 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 662 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 441 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 641,
    "median_ms": 510,
    "min_ms": 303,
    "max_ms": 3241,
    "ocr_runs": 61,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 380
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1074,
    "median_ms": 766,
    "min_ms": 588,
    "max_ms": 3241,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 81
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 496,
    "median_ms": 460,
    "min_ms": 303,
    "max_ms": 955,
    "ocr_runs": 42,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 299
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 799,
      "median_ms": 664,
      "min_ms": 410,
      "max_ms": 3241,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 181
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 483,
      "median_ms": 434,
      "min_ms": 303,
      "max_ms": 955,
      "ocr_runs": 28,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 199
    }
  }
}
```
