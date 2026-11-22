# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3962 | 1 | 0 | yes | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1653 | 2 | 1 |  | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 945 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1133 | 3 | 0 | yes | 8 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 671 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 718 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1556 | 2 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 758 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 714 | 1 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 381 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 421 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 665 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 890 | 2 | 0 | yes | 10 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 576 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 591 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 828 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2049 | 1 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 744 | 1 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 547 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 432 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 746 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 427 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 506 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 737 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 354 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 583 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 807 | 1 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 475 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 454 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 739 | 1 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 410 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 437 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 841,
    "median_ms": 692,
    "min_ms": 354,
    "max_ms": 3962,
    "ocr_runs": 57,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 346
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1424,
    "median_ms": 1039,
    "min_ms": 671,
    "max_ms": 3962,
    "ocr_runs": 18,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 646,
    "median_ms": 580,
    "min_ms": 354,
    "max_ms": 2049,
    "ocr_runs": 39,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 276
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 1029,
      "median_ms": 738,
      "min_ms": 381,
      "max_ms": 3962,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 164
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 653,
      "median_ms": 526,
      "min_ms": 354,
      "max_ms": 2049,
      "ocr_runs": 26,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 182
    }
  }
}
```
