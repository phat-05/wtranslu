# goal1-translation-cache cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3672 | 1 | 0 | yes | 2 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 702 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 952 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 655 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 861 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 571 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 556 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 502 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 504 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 458 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 630 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 428 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 423 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 356 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 561 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 552 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1701 | 1 | 0 | yes | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 429 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 666 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 897 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 451 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 383 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 412 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 690 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 485 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 490 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 442 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 626 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 620 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 350 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 325 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 313 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal1-translation-cache cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 677,
    "median_ms": 528,
    "min_ms": 313,
    "max_ms": 3672,
    "ocr_runs": 60,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 375
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1059,
    "median_ms": 678,
    "min_ms": 502,
    "max_ms": 3672,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 79
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 550,
    "median_ms": 472,
    "min_ms": 313,
    "max_ms": 1701,
    "ocr_runs": 41,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 296
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 774,
      "median_ms": 558,
      "min_ms": 356,
      "max_ms": 3672,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 179
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 580,
      "median_ms": 468,
      "min_ms": 313,
      "max_ms": 1701,
      "ocr_runs": 27,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 196
    }
  }
}
```
