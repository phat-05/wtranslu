# goal3-colors cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3710 | 1 | 0 | yes | 2 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 891 | 2 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 753 | 3 | 0 | yes | 9 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 913 | 2 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 895 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 1272 | 3 | 0 | yes | 9 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 815 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 841 | 3 | 0 | yes | 8 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 359 | 1 | 0 | yes | 13 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 716 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 416 | 2 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 463 | 1 | 0 | yes | 13 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 685 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 400 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 399 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 904 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1340 | 1 | 0 | yes | 9 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 521 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1163 | 2 | 0 | yes | 9 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 549 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 534 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 829 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 485 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 449 | 1 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 737 | 2 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 381 | 2 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 353 | 1 | 0 | yes | 14 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 829 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 475 | 2 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 475 | 1 | 0 | yes | 13 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 775 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 447 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal3-colors cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 774,
    "median_ms": 700,
    "min_ms": 353,
    "max_ms": 3710,
    "ocr_runs": 58,
    "translation_requests": 0,
    "from_cache": 32,
    "image_cache_hits": 347
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1261,
    "median_ms": 893,
    "min_ms": 753,
    "max_ms": 3710,
    "ocr_runs": 18,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 70
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 612,
    "median_ms": 503,
    "min_ms": 353,
    "max_ms": 1340,
    "ocr_runs": 40,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 277
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 902,
      "median_ms": 784,
      "min_ms": 359,
      "max_ms": 3710,
      "ocr_runs": 31,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 164
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 646,
      "median_ms": 528,
      "min_ms": 353,
      "max_ms": 1340,
      "ocr_runs": 27,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 183
    }
  }
}
```
