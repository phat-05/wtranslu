# goal1-translation-cache cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3712 | 1 | 0 | yes | 5 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 2953 | 3 | 1 |  | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 1226 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 2083 | 3 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 1954 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 2306 | 2 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 1802 | 3 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 2179 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 1429 | 3 | 0 | yes | 10 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 966 | 2 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 946 | 1 | 0 | yes | 13 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 1344 | 3 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 1055 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 1281 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 1038 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 475 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 1207 | 2 | 0 | yes | 10 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 995 | 3 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1396 | 2 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 1380 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 1044 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 1246 | 3 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 1188 | 3 | 0 | yes | 10 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 1089 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 1223 | 3 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 753 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 1214 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 1364 | 3 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 1007 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 1219 | 3 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 990 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 431 | 2 | 0 | yes | 11 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal1-translation-cache cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 1390,
    "median_ms": 1221,
    "min_ms": 431,
    "max_ms": 3712,
    "ocr_runs": 77,
    "translation_requests": 1,
    "from_cache": 31,
    "image_cache_hits": 352
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 2277,
    "median_ms": 2131,
    "min_ms": 1226,
    "max_ms": 3712,
    "ocr_runs": 19,
    "translation_requests": 1,
    "from_cache": 7,
    "image_cache_hits": 82
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 1095,
    "median_ms": 1138,
    "min_ms": 431,
    "max_ms": 1429,
    "ocr_runs": 58,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 270
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 1672,
      "median_ms": 1386,
      "min_ms": 475,
      "max_ms": 3712,
      "ocr_runs": 38,
      "translation_requests": 1,
      "from_cache": 15,
      "image_cache_hits": 173
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 1109,
      "median_ms": 1198,
      "min_ms": 431,
      "max_ms": 1396,
      "ocr_runs": 39,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 179
    }
  }
}
```
