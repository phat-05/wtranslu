# goal5-word-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 1 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 33 | 2 | 1 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 794 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 534 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 946 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 687 | 3 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1636 | 2 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 677 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 430 | 1 | 0 | yes | 14 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 700 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 494 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 430 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 397 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 572 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 543 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 506 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1967 | 1 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 337 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 615 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 402 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 417 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 450 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 743 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 723 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 480 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 452 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 382 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 613 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 377 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 523 | 3 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 551 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 779 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal5-word-colors cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 619,
    "median_ms": 534,
    "min_ms": 33,
    "max_ms": 1967,
    "ocr_runs": 61,
    "translation_requests": 4,
    "from_cache": 28,
    "image_cache_hits": 371
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 758,
    "median_ms": 687,
    "min_ms": 33,
    "max_ms": 1636,
    "ocr_runs": 19,
    "translation_requests": 3,
    "from_cache": 5,
    "image_cache_hits": 77
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 578,
    "median_ms": 500,
    "min_ms": 337,
    "max_ms": 1967,
    "ocr_runs": 42,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 294
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 625,
      "median_ms": 543,
      "min_ms": 33,
      "max_ms": 1636,
      "ocr_runs": 33,
      "translation_requests": 3,
      "from_cache": 13,
      "image_cache_hits": 178
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 613,
      "median_ms": 502,
      "min_ms": 337,
      "max_ms": 1967,
      "ocr_runs": 28,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 193
    }
  }
}
```
