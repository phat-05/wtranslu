# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3770 | 2 | 0 | yes | 7 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 2519 | 4 | 1 |  | 11 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1885 | 3 | 1 |  | 11 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 2814 | 4 | 1 |  | 12 | Then we leave now. Stay close to me. |
| s1 | 4 | 1589 | 3 | 0 | yes | 14 | I can hear an echo of something old beneath the ci |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 2515,
    "median_ms": 2519,
    "min_ms": 1589,
    "max_ms": 3770,
    "ocr_runs": 16,
    "translation_requests": 3,
    "from_cache": 2,
    "image_cache_hits": 55
  },
  "first_time_lines": {
    "n": 4,
    "missing": 0,
    "mean_ms": 2747,
    "median_ms": 2666,
    "min_ms": 1885,
    "max_ms": 3770,
    "ocr_runs": 13,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 41
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1589,
    "median_ms": 1589,
    "min_ms": 1589,
    "max_ms": 1589,
    "ocr_runs": 3,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 14
  },
  "per_session": {
    "s1": {
      "n": 5,
      "missing": 0,
      "mean_ms": 2515,
      "median_ms": 2519,
      "min_ms": 1589,
      "max_ms": 3770,
      "ocr_runs": 16,
      "translation_requests": 3,
      "from_cache": 2,
      "image_cache_hits": 55
    }
  }
}
```
