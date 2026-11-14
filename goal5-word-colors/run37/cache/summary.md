# goal5-word-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 224 | 2 | 2 |  | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 692 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 683 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 721 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 627 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1365 | 3 | 1 |  | 10 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 750 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 447 | 1 | 0 | yes | 14 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 702 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 423 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 382 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 349 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 519 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 510 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 493 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1769 | 1 | 1 |  | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 362 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 622 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 809 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 372 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 358 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 355 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 600 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 399 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 384 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 351 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 540 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 718 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 428 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 402 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 352 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 571,
    "median_ms": 493,
    "min_ms": 224,
    "max_ms": 1769,
    "ocr_runs": 61,
    "translation_requests": 4,
    "from_cache": 28,
    "image_cache_hits": 374
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 723,
    "median_ms": 692,
    "min_ms": 224,
    "max_ms": 1365,
    "ocr_runs": 19,
    "translation_requests": 3,
    "from_cache": 5,
    "image_cache_hits": 77
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 527,
    "median_ms": 426,
    "min_ms": 349,
    "max_ms": 1769,
    "ocr_runs": 42,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 297
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 592,
      "median_ms": 519,
      "min_ms": 224,
      "max_ms": 1365,
      "ocr_runs": 33,
      "translation_requests": 3,
      "from_cache": 13,
      "image_cache_hits": 178
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 551,
      "median_ms": 400,
      "min_ms": 351,
      "max_ms": 1769,
      "ocr_runs": 28,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 196
    }
  }
}
```
