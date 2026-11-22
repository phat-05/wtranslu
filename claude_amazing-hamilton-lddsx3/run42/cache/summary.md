# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3825 | 1 | 0 | yes | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1843 | 2 | 1 |  | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 1692 | 3 | 0 | yes | 9 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1349 | 2 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 1629 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 2092 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1627 | 2 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 1321 | 3 | 0 | yes | 9 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 527 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 837 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 473 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 442 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 671 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 341 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 356 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 868 | 1 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 0 | 1506 | 1 | 1 |  | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 599 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 756 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 448 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 466 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 752 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 373 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 378 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 881 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 498 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 515 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 705 | 1 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 350 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 356 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 620 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 852 | 2 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 1,
    "mean_ms": 936,
    "median_ms": 688,
    "min_ms": 341,
    "max_ms": 3825,
    "ocr_runs": 57,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 350
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1922,
    "median_ms": 1660,
    "min_ms": 1321,
    "max_ms": 3825,
    "ocr_runs": 18,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 71
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 607,
    "median_ms": 521,
    "min_ms": 341,
    "max_ms": 1506,
    "ocr_runs": 39,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 279
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 1,
      "mean_ms": 1243,
      "median_ms": 1094,
      "min_ms": 341,
      "max_ms": 3825,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 166
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 628,
      "median_ms": 557,
      "min_ms": 350,
      "max_ms": 1506,
      "ocr_runs": 26,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 184
    }
  }
}
```
