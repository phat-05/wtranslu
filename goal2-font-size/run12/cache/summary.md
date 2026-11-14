# goal2-font-size cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3600 | 1 | 0 | yes | 2 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 597 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 799 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 757 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 682 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 600 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 503 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 1002 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 517 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 489 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 708 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 670 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 375 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 344 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 310 | 1 | 0 | yes | 14 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 568 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1934 | 1 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 397 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1104 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 339 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 328 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 532 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 806 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 551 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 498 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 507 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 708 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 639 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 374 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 314 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 550 | 1 | 0 | yes | 14 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 564 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 708,
    "median_ms": 558,
    "min_ms": 310,
    "max_ms": 3600,
    "ocr_runs": 61,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 374
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1068,
    "median_ms": 720,
    "min_ms": 503,
    "max_ms": 3600,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 80
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 589,
    "median_ms": 524,
    "min_ms": 310,
    "max_ms": 1934,
    "ocr_runs": 42,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 294
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 783,
      "median_ms": 598,
      "min_ms": 310,
      "max_ms": 3600,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 180
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 634,
      "median_ms": 541,
      "min_ms": 314,
      "max_ms": 1934,
      "ocr_runs": 28,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 194
    }
  }
}
```
