# goal2-font-size cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 1 | 0 |  | 1 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 913 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 1789 | 3 | 0 | yes | 9 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 2047 | 2 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 1884 | 2 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 1471 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1751 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 1762 | 3 | 0 | yes | 9 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 521 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 746 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 437 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 442 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 704 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 362 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 349 | 1 | 0 | yes | 14 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 836 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2473 | 0 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 899 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 556 | 2 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 345 | 1 | 0 | yes | 14 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 862 | 2 | 0 | yes | 10 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 304 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 301 | 1 | 0 | yes | 14 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 840 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 442 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 431 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 710 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 329 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 299 | 2 | 0 | yes | 13 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 806 | 1 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 459 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 439 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal2-font-size cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 855,
    "median_ms": 704,
    "min_ms": 299,
    "max_ms": 2473,
    "ocr_runs": 57,
    "translation_requests": 0,
    "from_cache": 31,
    "image_cache_hits": 347
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 1660,
    "median_ms": 1762,
    "min_ms": 913,
    "max_ms": 2047,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 620,
    "median_ms": 450,
    "min_ms": 299,
    "max_ms": 2473,
    "ocr_runs": 39,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 277
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 1068,
      "median_ms": 836,
      "min_ms": 349,
      "max_ms": 2047,
      "ocr_runs": 31,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 165
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 656,
      "median_ms": 450,
      "min_ms": 299,
      "max_ms": 2473,
      "ocr_runs": 26,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 182
    }
  }
}
```
