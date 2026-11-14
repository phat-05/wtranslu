# claude/amazing-hamilton-lddsx3 cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 2 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 716 | 7 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 3395 | 6 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 3118 | 7 | 1 |  | 0 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 908 | 6 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s1 | 5 | None | 7 | 1 |  | 0 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 67 | 7 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s1 | 7 | None | 6 | 1 |  | 0 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 460 | 7 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 2542 | 7 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 2160 | 6 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 2946 | 7 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 2590 | 6 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 2207 | 7 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 39 | 7 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 2581 | 6 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 3268 | 3 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 568 | 7 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 2783 | 6 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 686 | 7 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 2177 | 6 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 2382 | 7 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 3160 | 7 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 2708 | 6 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 2253 | 7 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 2435 | 7 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 252 | 6 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 2215 | 7 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 2411 | 7 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 2551 | 7 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 1061 | 5 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 2445 | 7 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s2 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 cache scenario",
  "all": {
    "n": 29,
    "missing": 4,
    "mean_ms": 1968,
    "median_ms": 2382,
    "min_ms": 39,
    "max_ms": 3395,
    "ocr_runs": 203,
    "translation_requests": 3,
    "from_cache": 28,
    "image_cache_hits": 0
  },
  "first_time_lines": {
    "n": 5,
    "missing": 3,
    "mean_ms": 1641,
    "median_ms": 908,
    "min_ms": 67,
    "max_ms": 3395,
    "ocr_runs": 48,
    "translation_requests": 3,
    "from_cache": 4,
    "image_cache_hits": 0
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 2037,
    "median_ms": 2396,
    "min_ms": 39,
    "max_ms": 3268,
    "ocr_runs": 155,
    "translation_requests": 0,
    "from_cache": 24,
    "image_cache_hits": 0
  },
  "per_session": {
    "s1": {
      "n": 13,
      "missing": 3,
      "mean_ms": 1825,
      "median_ms": 2207,
      "min_ms": 39,
      "max_ms": 3395,
      "ocr_runs": 101,
      "translation_requests": 3,
      "from_cache": 12,
      "image_cache_hits": 0
    },
    "s2": {
      "n": 16,
      "missing": 1,
      "mean_ms": 2085,
      "median_ms": 2396,
      "min_ms": 252,
      "max_ms": 3268,
      "ocr_runs": 102,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 0
    }
  }
}
```
