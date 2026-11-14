# goal4-game-font cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1191 | 2 | 0 | yes | 9 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 763 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 813 | 3 | 0 | yes | 8 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 706 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 724 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1098 | 2 | 0 | yes | 9 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 889 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 704 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 385 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 446 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 665 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 365 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 478 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 1087 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 478 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2558 | 0 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 912 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 705 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 810 | 2 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 406 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 362 | 1 | 0 | yes | 14 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 785 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 449 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 514 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 1012 | 2 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 511 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 587 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 814 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 796 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 806 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 446 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal4-game-font cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 750,
    "median_ms": 706,
    "min_ms": 362,
    "max_ms": 2558,
    "ocr_runs": 58,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 337
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 883,
    "median_ms": 813,
    "min_ms": 706,
    "max_ms": 1191,
    "ocr_runs": 17,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 69
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 712,
    "median_ms": 626,
    "min_ms": 362,
    "max_ms": 2558,
    "ocr_runs": 41,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 268
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 719,
      "median_ms": 706,
      "min_ms": 365,
      "max_ms": 1191,
      "ocr_runs": 31,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 161
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 780,
      "median_ms": 745,
      "min_ms": 362,
      "max_ms": 2558,
      "ocr_runs": 27,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 176
    }
  }
}
```
