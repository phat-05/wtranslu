# goal1-translation-cache cache scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3133 | 1 | 0 | yes | 4 | Welcome aboard. The harbor has been quiet for days |
| s1 | 1 | 928 | 3 | 0 | yes | 10 | Nobody sails at night anymore. The fog is too thic |
| s1 | 2 | 925 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 3 | 874 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s1 | 4 | 778 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s1 | 5 | 982 | 3 | 0 | yes | 11 | Beware the lighthouse. Strange voices come from it |
| s1 | 6 | 691 | 3 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s1 | 7 | 1106 | 2 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s1 | 8 | 819 | 3 | 0 | yes | 10 | Welcome aboard. The harbor has been quiet for days |
| s1 | 9 | 99 | 2 | 0 | yes | 12 | Beware the lighthouse. Strange voices come from it |
| s1 | 10 | 788 | 3 | 0 | yes | 11 | Pay him. That map is worth far more than gold. |
| s1 | 11 | 710 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s1 | 12 | 1117 | 3 | 0 | yes | 10 | I heard the keeper vanished three winters ago. |
| s1 | 13 | 852 | 3 | 0 | yes | 11 | Then we leave at dawn. Prepare the ropes and the l |
| s1 | 14 | 1005 | 2 | 0 | yes | 12 | Stories will not stop us. Raise the anchor! |
| s1 | 15 | 739 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |
| s2 | 0 | 2131 | 2 | 0 | yes | 7 | Welcome aboard. The harbor has been quiet for days |
| s2 | 1 | 408 | 2 | 0 | yes | 11 | Nobody sails at night anymore. The fog is too thic |
| s2 | 2 | 711 | 2 | 0 | yes | 12 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 3 | 686 | 2 | 0 | yes | 12 | Captain, the merchant wants twelve gold coins for  |
| s2 | 4 | 920 | 2 | 0 | yes | 12 | Pay him. That map is worth far more than gold. |
| s2 | 5 | 872 | 3 | 0 | yes | 10 | Beware the lighthouse. Strange voices come from it |
| s2 | 6 | 868 | 2 | 0 | yes | 12 | I heard the keeper vanished three winters ago. |
| s2 | 7 | 995 | 3 | 0 | yes | 11 | Stories will not stop us. Raise the anchor! |
| s2 | 8 | 692 | 3 | 0 | yes | 11 | Welcome aboard. The harbor has been quiet for days |
| s2 | 9 | 882 | 1 | 0 | yes | 13 | Beware the lighthouse. Strange voices come from it |
| s2 | 10 | 1159 | 3 | 1 | yes | 10 | Pay him. That map is worth far more than gold. |
| s2 | 11 | 789 | 2 | 0 | yes | 12 | Nobody sails at night anymore. The fog is too thic |
| s2 | 12 | 941 | 3 | 0 | yes | 11 | I heard the keeper vanished three winters ago. |
| s2 | 13 | 882 | 3 | 0 | yes | 10 | Then we leave at dawn. Prepare the ropes and the l |
| s2 | 14 | 773 | 2 | 0 | yes | 13 | Stories will not stop us. Raise the anchor! |
| s2 | 15 | 690 | 3 | 0 | yes | 10 | Captain, the merchant wants twelve gold coins for  |

```json
{
  "label": "goal1-translation-cache cache scenario",
  "all": {
    "n": 32,
    "missing": 0,
    "mean_ms": 936,
    "median_ms": 870,
    "min_ms": 99,
    "max_ms": 3133,
    "ocr_runs": 78,
    "translation_requests": 1,
    "from_cache": 32,
    "image_cache_hits": 346
  },
  "first_time_lines": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1177,
    "median_ms": 926,
    "min_ms": 691,
    "max_ms": 3133,
    "ocr_runs": 19,
    "translation_requests": 0,
    "from_cache": 8,
    "image_cache_hits": 81
  },
  "repeated_lines": {
    "n": 24,
    "missing": 0,
    "mean_ms": 855,
    "median_ms": 836,
    "min_ms": 99,
    "max_ms": 2131,
    "ocr_runs": 59,
    "translation_requests": 1,
    "from_cache": 24,
    "image_cache_hits": 265
  },
  "per_session": {
    "s1": {
      "n": 16,
      "missing": 0,
      "mean_ms": 972,
      "median_ms": 863,
      "min_ms": 99,
      "max_ms": 3133,
      "ocr_runs": 40,
      "translation_requests": 0,
      "from_cache": 16,
      "image_cache_hits": 169
    },
    "s2": {
      "n": 16,
      "missing": 0,
      "mean_ms": 900,
      "median_ms": 870,
      "min_ms": 408,
      "max_ms": 2131,
      "ocr_runs": 38,
      "translation_requests": 1,
      "from_cache": 16,
      "image_cache_hits": 177
    }
  }
}
```
