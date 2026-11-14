# fix-wgc-latest-frame cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | None | 3 | 0 |  | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 340 | 7 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 840 | 8 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 1249 | 9 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 1088 | 8 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 910 | 8 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 792 | 9 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 1093 | 8 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 913 | 8 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 773 | 9 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 1556 | 8 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 898 | 9 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 1170 | 8 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 987 | 8 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 857 | 8 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 1016 | 8 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s1 | 1 | None | 0 | 0 |  | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 0 | 2776 | 4 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 657 | 7 | 1 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 1459 | 8 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 943 | 8 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 828 | 9 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 1110 | 8 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 959 | 8 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 1195 | 9 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 1015 | 8 | 0 | yes | 0 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 857 | 9 | 0 | yes | 0 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 1143 | 8 | 0 | yes | 0 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 944 | 8 | 0 | yes | 0 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 752 | 9 | 0 | yes | 0 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 999 | 8 | 0 | yes | 0 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 830 | 9 | 0 | yes | 0 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 1066 | 8 | 0 | yes | 0 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "fix-wgc-latest-frame cache scenario",
  "all": {
    "n": 31,
    "missing": 2,
    "mean_ms": 1033,
    "median_ms": 959,
    "min_ms": 340,
    "max_ms": 2776,
    "ocr_runs": 254,
    "translation_requests": 1,
    "from_cache": 31,
    "image_cache_hits": 0
  },
  "first_time_lines": {
    "n": 7,
    "missing": 1,
    "mean_ms": 902,
    "median_ms": 910,
    "min_ms": 340,
    "max_ms": 1249,
    "ocr_runs": 60,
    "translation_requests": 0,
    "from_cache": 7,
    "image_cache_hits": 0
  },
  "repeated_lines": {
    "n": 24,
    "missing": 1,
    "mean_ms": 1071,
    "median_ms": 973,
    "min_ms": 657,
    "max_ms": 2776,
    "ocr_runs": 194,
    "translation_requests": 1,
    "from_cache": 24,
    "image_cache_hits": 0
  },
  "per_session": {
    "s1": {
      "n": 15,
      "missing": 2,
      "mean_ms": 965,
      "median_ms": 913,
      "min_ms": 340,
      "max_ms": 1556,
      "ocr_runs": 126,
      "translation_requests": 0,
      "from_cache": 15,
      "image_cache_hits": 0
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 1096,
      "median_ms": 979,
      "min_ms": 657,
      "max_ms": 2776,
      "ocr_runs": 128,
      "translation_requests": 1,
      "from_cache": 16,
      "image_cache_hits": 0
    }
  }
}
```
