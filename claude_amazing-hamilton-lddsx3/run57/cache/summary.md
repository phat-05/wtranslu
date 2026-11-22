# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 425 | 2 | 1 | yes | 8 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 819 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 851 | 3 | 0 | yes | 8 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 766 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 821 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1865 | 2 | 1 |  | 9 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 955 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 938 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 378 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 424 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 728 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 416 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 398 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 881 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 512 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1635 | 1 | 1 |  | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 534 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 919 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 369 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 431 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 832 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 547 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 551 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 846 | 2 | 0 | yes | 10 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 369 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 686 | 1 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 381 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 369 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 635 | 1 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 338 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 400 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 678,
    "median_ms": 551,
    "min_ms": 338,
    "max_ms": 1865,
    "ocr_runs": 57,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 344
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 929,
    "median_ms": 821,
    "min_ms": 425,
    "max_ms": 1865,
    "ocr_runs": 17,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 69
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 605,
    "median_ms": 523,
    "min_ms": 338,
    "max_ms": 1635,
    "ocr_runs": 40,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 275
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 745,
      "median_ms": 766,
      "min_ms": 378,
      "max_ms": 1865,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 162
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 615,
      "median_ms": 540,
      "min_ms": 338,
      "max_ms": 1635,
      "ocr_runs": 26,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 182
    }
  }
}
```
