# goal3-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3199 | 1 | 0 | yes | 4 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 741 | 3 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 732 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 759 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 654 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 587 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 537 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 749 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 569 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 334 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 585 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 528 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 534 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 705 | 3 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 719 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 678 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1918 | 1 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 350 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 546 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 373 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 368 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 426 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 691 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 633 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 466 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 477 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 475 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 742 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 533 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 418 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 304 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 477 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 681,
    "median_ms": 558,
    "min_ms": 304,
    "max_ms": 3199,
    "ocr_runs": 61,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 374
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 995,
    "median_ms": 736,
    "min_ms": 537,
    "max_ms": 3199,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 80
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 577,
    "median_ms": 530,
    "min_ms": 304,
    "max_ms": 1918,
    "ocr_runs": 42,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 294
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 788,
      "median_ms": 666,
      "min_ms": 334,
      "max_ms": 3199,
      "ocr_runs": 34,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 179
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 575,
      "median_ms": 476,
      "min_ms": 304,
      "max_ms": 1918,
      "ocr_runs": 27,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 195
    }
  }
}
```
