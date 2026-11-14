# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 3 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 169 | 10 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 322 | 11 | 1 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 2043 | 10 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 1512 | 11 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 1713 | 11 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 2163 | 11 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 2049 | 11 | 1 |  | 0 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 1276 | 11 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 1241 | 11 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 1253 | 11 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 1240 | 11 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 1321 | 11 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 1564 | 11 | 1 |  | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 1404 | 11 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 1475 | 11 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2284 | 8 | 1 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 373 | 10 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1313 | 11 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 1325 | 11 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 1441 | 11 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 1466 | 11 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 1470 | 11 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 1438 | 11 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 1426 | 11 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 1445 | 11 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 397 | 11 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 1490 | 11 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 1542 | 11 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 1573 | 10 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 1264 | 11 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 1296 | 11 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 31,
    "missing": 1,
    "mean_ms": 1364,
    "median_ms": 1438,
    "min_ms": 169,
    "max_ms": 2284,
    "ocr_runs": 337,
    "translation_requests": 4,
    "from_cache": 29,
    "image_cache_hits": 0
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 1424,
    "median_ms": 1713,
    "min_ms": 169,
    "max_ms": 2163,
    "ocr_runs": 78,
    "translation_requests": 2,
    "from_cache": 6,
    "image_cache_hits": 0
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 1347,
    "median_ms": 1415,
    "min_ms": 373,
    "max_ms": 2284,
    "ocr_runs": 259,
    "translation_requests": 2,
    "from_cache": 23,
    "image_cache_hits": 0
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 1,
      "mean_ms": 1383,
      "median_ms": 1404,
      "min_ms": 169,
      "max_ms": 2163,
      "ocr_runs": 166,
      "translation_requests": 3,
      "from_cache": 13,
      "image_cache_hits": 0
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 1346,
      "median_ms": 1440,
      "min_ms": 373,
      "max_ms": 2284,
      "ocr_runs": 171,
      "translation_requests": 1,
      "from_cache": 16,
      "image_cache_hits": 0
    }
  }
}
```
