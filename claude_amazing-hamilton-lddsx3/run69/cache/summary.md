# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 246 | 2 | 0 | yes | 9 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 899 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1189 | 3 | 0 | yes | 8 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 686 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 672 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 748 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 672 | 3 | 0 | yes | 10 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 665 | 1 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 374 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 342 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 548 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 732 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 573 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 554 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 750 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2584 | 0 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 1092 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 646 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 607 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 831 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 468 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 482 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 757 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 404 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 411 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 889 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 536 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 428 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 856 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 508 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 450 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 697,
    "median_ms": 646,
    "min_ms": 246,
    "max_ms": 2584,
    "ocr_runs": 57,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 347
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 730,
    "median_ms": 686,
    "min_ms": 246,
    "max_ms": 1189,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 687,
    "median_ms": 564,
    "min_ms": 342,
    "max_ms": 2584,
    "ocr_runs": 39,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 277
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 643,
      "median_ms": 672,
      "min_ms": 246,
      "max_ms": 1189,
      "ocr_runs": 31,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 165
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 747,
      "median_ms": 572,
      "min_ms": 404,
      "max_ms": 2584,
      "ocr_runs": 26,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 182
    }
  }
}
```
