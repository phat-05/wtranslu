# goal4-game-font cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 69 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 557 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 752 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 946 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 761 | 3 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 964 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 637 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 303 | 1 | 0 | yes | 14 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 732 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 719 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 460 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 437 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 380 | 1 | 0 | yes | 14 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 582 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 331 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1749 | 1 | 0 | yes | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 537 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 546 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 369 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 353 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 346 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 557 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 575 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 319 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 323 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 552 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 554 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 312 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 509 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 503 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 446 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 554,
    "median_ms": 537,
    "min_ms": 69,
    "max_ms": 1749,
    "ocr_runs": 60,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 373
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 669,
    "median_ms": 752,
    "min_ms": 69,
    "max_ms": 964,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 77
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 521,
    "median_ms": 482,
    "min_ms": 303,
    "max_ms": 1749,
    "ocr_runs": 41,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 296
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 575,
      "median_ms": 582,
      "min_ms": 69,
      "max_ms": 964,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 178
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 534,
      "median_ms": 506,
      "min_ms": 312,
      "max_ms": 1749,
      "ocr_runs": 27,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 195
    }
  }
}
```
