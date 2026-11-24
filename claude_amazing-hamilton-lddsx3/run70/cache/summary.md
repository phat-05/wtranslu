# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3092 | 1 | 0 | yes | 4 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 548 | 3 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 476 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 631 | 3 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 623 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 493 | 3 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 652 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 672 | 3 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 422 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 448 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 444 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 460 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 468 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 532 | 3 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 533 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 558 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1230 | 1 | 0 | yes | 10 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 414 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 621 | 3 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 657 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 675 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 372 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 414 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 510 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 572 | 2 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 392 | 2 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 636 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 795 | 3 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 447 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 445 | 2 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 464 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 459 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 630,
    "median_ms": 521,
    "min_ms": 372,
    "max_ms": 3092,
    "ocr_runs": 67,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 393
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 898,
    "median_ms": 627,
    "min_ms": 476,
    "max_ms": 3092,
    "ocr_runs": 20,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 87
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 540,
    "median_ms": 466,
    "min_ms": 372,
    "max_ms": 1230,
    "ocr_runs": 47,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 306
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 691,
      "median_ms": 532,
      "min_ms": 422,
      "max_ms": 3092,
      "ocr_runs": 36,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 190
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 569,
      "median_ms": 487,
      "min_ms": 372,
      "max_ms": 1230,
      "ocr_runs": 31,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 203
    }
  }
}
```
