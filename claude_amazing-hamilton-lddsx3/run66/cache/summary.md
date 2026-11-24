# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 422 | 2 | 0 | yes | 8 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 819 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 817 | 3 | 0 | yes | 8 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 893 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 872 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 912 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 809 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 784 | 1 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 475 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 456 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 644 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 867 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 800 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 740 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 366 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2626 | 0 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 1154 | 2 | 0 | yes | 9 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1001 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 719 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 356 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 551 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 796 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 494 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 421 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 861 | 1 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 553 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 492 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 697 | 1 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 875 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 517 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 417 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 749,
    "median_ms": 740,
    "min_ms": 356,
    "max_ms": 2626,
    "ocr_runs": 58,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 343
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 792,
    "median_ms": 819,
    "min_ms": 422,
    "max_ms": 912,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 736,
    "median_ms": 670,
    "min_ms": 356,
    "max_ms": 2626,
    "ocr_runs": 40,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 273
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 712,
      "median_ms": 800,
      "min_ms": 366,
      "max_ms": 912,
      "ocr_runs": 32,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 162
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 783,
      "median_ms": 625,
      "min_ms": 356,
      "max_ms": 2626,
      "ocr_runs": 26,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 181
    }
  }
}
```
