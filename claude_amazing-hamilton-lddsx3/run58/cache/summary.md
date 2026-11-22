# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 179 | 2 | 1 | yes | 9 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 812 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1266 | 3 | 0 | yes | 9 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 797 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 870 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1712 | 2 | 1 |  | 10 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 727 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 721 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 409 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 418 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 939 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 351 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 348 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 872 | 1 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 587 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2497 | 1 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 1098 | 1 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 477 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 517 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 825 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 491 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 535 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 815 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 457 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 479 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 731 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 397 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 377 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 872 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 315 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 576 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 725,
    "median_ms": 587,
    "min_ms": 179,
    "max_ms": 2497,
    "ocr_runs": 56,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 344
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 909,
    "median_ms": 812,
    "min_ms": 179,
    "max_ms": 1712,
    "ocr_runs": 17,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 671,
    "median_ms": 526,
    "min_ms": 315,
    "max_ms": 2497,
    "ocr_runs": 39,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 274
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 734,
      "median_ms": 727,
      "min_ms": 179,
      "max_ms": 1712,
      "ocr_runs": 31,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 162
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 716,
      "median_ms": 526,
      "min_ms": 315,
      "max_ms": 2497,
      "ocr_runs": 25,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 182
    }
  }
}
```
