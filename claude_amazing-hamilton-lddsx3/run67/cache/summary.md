# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 452 | 2 | 0 | yes | 8 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 864 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 901 | 3 | 0 | yes | 8 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 711 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 880 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 876 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 846 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 881 | 1 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 575 | 2 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 348 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 1167 | 3 | 0 | yes | 8 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 551 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 1065 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 472 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 403 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |
| s1 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 0 | 2597 | 0 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 1144 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 666 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 635 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 856 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 516 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 527 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 786 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 459 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 437 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 846 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 489 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 427 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 870 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 490 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 789 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 2,
    "mean_ms": 759,
    "median_ms": 711,
    "min_ms": 348,
    "max_ms": 2597,
    "ocr_runs": 58,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 342
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 790,
    "median_ms": 864,
    "min_ms": 452,
    "max_ms": 901,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 750,
    "median_ms": 605,
    "min_ms": 348,
    "max_ms": 2597,
    "ocr_runs": 40,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 272
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 2,
      "mean_ms": 733,
      "median_ms": 846,
      "min_ms": 348,
      "max_ms": 1167,
      "ocr_runs": 32,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 161
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 783,
      "median_ms": 650,
      "min_ms": 427,
      "max_ms": 2597,
      "ocr_runs": 26,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 181
    }
  }
}
```
