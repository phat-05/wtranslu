# goal5-word-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1439 | 2 | 1 |  | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 742 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 719 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 716 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 627 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1331 | 3 | 1 |  | 10 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 738 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 483 | 1 | 0 | yes | 14 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 713 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 585 | 2 | 1 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 525 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 455 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 661 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 583 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 317 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1744 | 1 | 1 |  | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 336 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 579 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 559 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 507 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 493 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 736 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 658 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 375 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 334 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 572 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 523 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 680 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 394 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 326 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 301 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 637,
    "median_ms": 579,
    "min_ms": 301,
    "max_ms": 1744,
    "ocr_runs": 61,
    "translation_requests": 4,
    "from_cache": 28,
    "image_cache_hits": 373
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 902,
    "median_ms": 738,
    "min_ms": 627,
    "max_ms": 1439,
    "ocr_runs": 19,
    "translation_requests": 2,
    "from_cache": 5,
    "image_cache_hits": 77
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 560,
    "median_ms": 524,
    "min_ms": 301,
    "max_ms": 1744,
    "ocr_runs": 42,
    "translation_requests": 2,
    "from_cache": 23,
    "image_cache_hits": 296
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 709,
      "median_ms": 661,
      "min_ms": 317,
      "max_ms": 1439,
      "ocr_runs": 33,
      "translation_requests": 3,
      "from_cache": 13,
      "image_cache_hits": 177
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 570,
      "median_ms": 515,
      "min_ms": 301,
      "max_ms": 1744,
      "ocr_runs": 28,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 196
    }
  }
}
```
