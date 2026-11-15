# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 401 | 2 | 1 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 626 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 566 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 565 | 3 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 780 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1511 | 3 | 1 |  | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 670 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 620 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 661 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 384 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 562 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 497 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 689 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 857 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 366 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1935 | 1 | 1 |  | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 579 | 1 | 0 | yes | 14 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 569 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 333 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 578 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 529 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 444 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 651 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 431 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 434 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 411 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 597 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 519 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 317 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 544 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 488 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 617,
    "median_ms": 565,
    "min_ms": 317,
    "max_ms": 1935,
    "ocr_runs": 61,
    "translation_requests": 3,
    "from_cache": 29,
    "image_cache_hits": 373
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 731,
    "median_ms": 626,
    "min_ms": 401,
    "max_ms": 1511,
    "ocr_runs": 19,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 77
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 583,
    "median_ms": 536,
    "min_ms": 317,
    "max_ms": 1935,
    "ocr_runs": 42,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 296
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 650,
      "median_ms": 620,
      "min_ms": 366,
      "max_ms": 1511,
      "ocr_runs": 33,
      "translation_requests": 2,
      "from_cache": 14,
      "image_cache_hits": 177
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 585,
      "median_ms": 524,
      "min_ms": 317,
      "max_ms": 1935,
      "ocr_runs": 28,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 196
    }
  }
}
```
