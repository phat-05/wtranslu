# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 275 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 743 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 758 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 704 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 671 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 645 | 3 | 0 | yes | 10 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 612 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 620 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 418 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 446 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 714 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 742 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 570 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 567 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 569 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1689 | 1 | 0 | yes | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 614 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 719 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 591 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 356 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 374 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 670 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 461 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 452 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 442 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 678 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 664 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 444 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 429 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 441 | 1 | 0 | yes | 14 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 712 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 606,
    "median_ms": 612,
    "min_ms": 275,
    "max_ms": 1689,
    "ocr_runs": 60,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 368
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 630,
    "median_ms": 671,
    "min_ms": 275,
    "max_ms": 758,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 77
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 599,
    "median_ms": 570,
    "min_ms": 356,
    "max_ms": 1689,
    "ocr_runs": 42,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 291
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 604,
      "median_ms": 620,
      "min_ms": 275,
      "max_ms": 758,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 174
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 608,
      "median_ms": 526,
      "min_ms": 356,
      "max_ms": 1689,
      "ocr_runs": 27,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 194
    }
  }
}
```
