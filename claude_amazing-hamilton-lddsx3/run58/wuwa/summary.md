# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3770 | 2 | 0 | yes | 7 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 2680 | 4 | 0 | yes | 11 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1357 | 3 | 1 |  | 12 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 2190 | 4 | 0 | yes | 12 | Then we leave now. Stay close to me. |
| s1 | 4 | 1575 | 4 | 0 | yes | 12 | I can hear an echo of something old beneath the ci |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 5,
    "missing": 0,
    "mean_ms": 2314,
    "median_ms": 2190,
    "min_ms": 1357,
    "max_ms": 3770,
    "ocr_runs": 17,
    "translation_requests": 1,
    "from_cache": 4,
    "image_cache_hits": 54
  },
  "first_time_lines": {
    "n": 4,
    "missing": 0,
    "mean_ms": 2499,
    "median_ms": 2435,
    "min_ms": 1357,
    "max_ms": 3770,
    "ocr_runs": 13,
    "translation_requests": 1,
    "from_cache": 3,
    "image_cache_hits": 42
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1575,
    "median_ms": 1575,
    "min_ms": 1575,
    "max_ms": 1575,
    "ocr_runs": 4,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 12
  },
  "per_session": {
    "s1": {
      "n": 5,
      "missing": 0,
      "mean_ms": 2314,
      "median_ms": 2190,
      "min_ms": 1357,
      "max_ms": 3770,
      "ocr_runs": 17,
      "translation_requests": 1,
      "from_cache": 4,
      "image_cache_hits": 54
    }
  }
}
```
