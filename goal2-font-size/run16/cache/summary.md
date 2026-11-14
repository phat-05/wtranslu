# goal2-font-size cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1022 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 633 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 583 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 585 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 714 | 3 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 838 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 535 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 518 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 741 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 698 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 458 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 379 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 549 | 1 | 0 | yes | 14 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 517 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 720 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1658 | 1 | 0 | yes | 8 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 319 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 571 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 565 | 2 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 541 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 456 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 453 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 666 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 962 | 2 | 0 | yes | 12 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 421 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 314 | 2 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 454 | 2 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 675 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 660 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 428 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 406 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 614,
    "median_ms": 565,
    "min_ms": 314,
    "max_ms": 1658,
    "ocr_runs": 61,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 375
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 701,
    "median_ms": 633,
    "min_ms": 535,
    "max_ms": 1022,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 78
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 589,
    "median_ms": 530,
    "min_ms": 314,
    "max_ms": 1658,
    "ocr_runs": 42,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 297
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 633,
      "median_ms": 585,
      "min_ms": 379,
      "max_ms": 1022,
      "ocr_runs": 33,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 179
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 597,
      "median_ms": 498,
      "min_ms": 314,
      "max_ms": 1658,
      "ocr_runs": 28,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 196
    }
  }
}
```
