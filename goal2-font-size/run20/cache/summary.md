# goal2-font-size cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 39 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 788 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1190 | 2 | 0 | yes | 9 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 654 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 1530 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 740 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 730 | 3 | 0 | yes | 9 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 442 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 690 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 299 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 541 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 757 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 387 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 393 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 1235 | 3 | 0 | yes | 9 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2413 | 1 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 1062 | 1 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 521 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 568 | 1 | 0 | yes | 13 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 855 | 2 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 542 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 319 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 815 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 464 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 461 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 698 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 401 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 454 | 1 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 879 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 398 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 633 | 1 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |

```json
{
  "label": "goal2-font-size cache scenario",
  "all": {
    "n": 31,
    "missing": 2,
    "mean_ms": 706,
    "median_ms": 633,
    "min_ms": 39,
    "max_ms": 2413,
    "ocr_runs": 57,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 343
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 810,
    "median_ms": 740,
    "min_ms": 39,
    "max_ms": 1530,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 676,
    "median_ms": 542,
    "min_ms": 299,
    "max_ms": 2413,
    "ocr_runs": 39,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 273
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 694,
      "median_ms": 690,
      "min_ms": 39,
      "max_ms": 1530,
      "ocr_runs": 32,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 163
    },
    "s2": {
      "n": 16,
      "missing": 1,
      "mean_ms": 718,
      "median_ms": 555,
      "min_ms": 319,
      "max_ms": 2413,
      "ocr_runs": 25,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 180
    }
  }
}
```
