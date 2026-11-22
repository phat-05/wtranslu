# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3578 | 2 | 0 | yes | 8 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1932 | 5 | 1 |  | 12 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1231 | 3 | 1 |  | 14 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 2553 | 5 | 1 |  | 12 | Then we leave now. Stay close to me. |
| s1 | 4 | 464 | 3 | 0 | yes | 15 | I can hear an echo of something old beneath the ci |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 1952,
    "median_ms": 1932,
    "min_ms": 464,
    "max_ms": 3578,
    "ocr_runs": 18,
    "translation_requests": 3,
    "from_cache": 2,
    "image_cache_hits": 61
  },
  "first_time_lines": {
    "n": 4,
    "missing": 0,
    "mean_ms": 2324,
    "median_ms": 2242,
    "min_ms": 1231,
    "max_ms": 3578,
    "ocr_runs": 15,
    "translation_requests": 3,
    "from_cache": 1,
    "image_cache_hits": 46
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 464,
    "median_ms": 464,
    "min_ms": 464,
    "max_ms": 464,
    "ocr_runs": 3,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 15
  },
  "per_session": {
    "s1": {
      "n": 5,
      "missing": 0,
      "mean_ms": 1952,
      "median_ms": 1932,
      "min_ms": 464,
      "max_ms": 3578,
      "ocr_runs": 18,
      "translation_requests": 3,
      "from_cache": 2,
      "image_cache_hits": 61
    }
  }
}
```
