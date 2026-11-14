# goal5-word-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 117 | 2 | 2 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 589 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 549 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 526 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 696 | 3 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1672 | 2 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 650 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 400 | 1 | 0 | yes | 14 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 698 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 475 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 448 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 455 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 630 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 901 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 462 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1880 | 1 | 1 |  | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 547 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 589 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 423 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 461 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 430 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 743 | 1 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 760 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 542 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 507 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 524 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 749 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 523 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 474 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 477 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 741 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 633,
    "median_ms": 542,
    "min_ms": 117,
    "max_ms": 1880,
    "ocr_runs": 60,
    "translation_requests": 4,
    "from_cache": 28,
    "image_cache_hits": 371
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 686,
    "median_ms": 589,
    "min_ms": 117,
    "max_ms": 1672,
    "ocr_runs": 19,
    "translation_requests": 3,
    "from_cache": 5,
    "image_cache_hits": 77
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 618,
    "median_ms": 524,
    "min_ms": 400,
    "max_ms": 1880,
    "ocr_runs": 41,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 294
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 618,
      "median_ms": 549,
      "min_ms": 117,
      "max_ms": 1672,
      "ocr_runs": 33,
      "translation_requests": 3,
      "from_cache": 13,
      "image_cache_hits": 177
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 648,
      "median_ms": 533,
      "min_ms": 423,
      "max_ms": 1880,
      "ocr_runs": 27,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 194
    }
  }
}
```
