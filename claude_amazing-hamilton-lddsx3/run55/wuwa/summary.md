# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2654 | 3 | 1 |  | 10 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1570 | 6 | 0 | yes | 11 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1376 | 3 | 1 |  | 14 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1369 | 5 | 1 |  | 14 | Then we leave now. Stay close to me. |
| s1 | 4 | 1461 | 4 | 0 | yes | 14 | I can hear an echo of something old beneath the ci |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1686,
    "median_ms": 1461,
    "min_ms": 1369,
    "max_ms": 2654,
    "ocr_runs": 21,
    "translation_requests": 3,
    "from_cache": 2,
    "image_cache_hits": 63
  },
  "first_time_lines": {
    "n": 4,
    "missing": 0,
    "mean_ms": 1742,
    "median_ms": 1473,
    "min_ms": 1369,
    "max_ms": 2654,
    "ocr_runs": 17,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 49
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1461,
    "median_ms": 1461,
    "min_ms": 1461,
    "max_ms": 1461,
    "ocr_runs": 4,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 14
  },
  "per_session": {
    "s1": {
      "n": 5,
      "missing": 0,
      "mean_ms": 1686,
      "median_ms": 1461,
      "min_ms": 1369,
      "max_ms": 2654,
      "ocr_runs": 21,
      "translation_requests": 3,
      "from_cache": 2,
      "image_cache_hits": 63
    }
  }
}
```
