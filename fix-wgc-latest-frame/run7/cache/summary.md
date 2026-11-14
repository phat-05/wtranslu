# fix-wgc-latest-frame cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 0 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 1671 | 7 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 1462 | 8 | 1 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1166 | 9 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 1322 | 9 | 1 | yes | 0 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 1371 | 9 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1432 | 9 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 1424 | 9 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 1485 | 9 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 1575 | 8 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 291 | 9 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 1255 | 9 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 1312 | 9 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 1888 | 9 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 1040 | 9 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 1056 | 8 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 3923 | 5 | 1 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 1205 | 9 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1792 | 9 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 1529 | 8 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 1212 | 9 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 1264 | 9 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 1401 | 9 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 1471 | 9 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 1129 | 8 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 1238 | 9 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 1324 | 9 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 1380 | 9 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 1875 | 9 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 1486 | 8 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 1123 | 9 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 1134 | 9 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "fix-wgc-latest-frame cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 1427,
    "median_ms": 1371,
    "min_ms": 291,
    "max_ms": 3923,
    "ocr_runs": 267,
    "translation_requests": 3,
    "from_cache": 30,
    "image_cache_hits": 0
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 1407,
    "median_ms": 1424,
    "min_ms": 1166,
    "max_ms": 1671,
    "ocr_runs": 60,
    "translation_requests": 2,
    "from_cache": 7,
    "image_cache_hits": 0
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 1433,
    "median_ms": 1318,
    "min_ms": 291,
    "max_ms": 3923,
    "ocr_runs": 207,
    "translation_requests": 1,
    "from_cache": 23,
    "image_cache_hits": 0
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 1317,
      "median_ms": 1371,
      "min_ms": 291,
      "max_ms": 1888,
      "ocr_runs": 130,
      "translation_requests": 2,
      "from_cache": 15,
      "image_cache_hits": 0
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 1530,
      "median_ms": 1352,
      "min_ms": 1123,
      "max_ms": 3923,
      "ocr_runs": 137,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 0
    }
  }
}
```
