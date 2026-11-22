# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2677 | 3 | 1 |  | 9 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1631 | 6 | 0 | yes | 12 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1475 | 3 | 1 |  | 15 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 2250 | 5 | 1 |  | 13 | Then we leave now. Stay close to me. |
| s1 | 4 | 2774 | 6 | 0 | yes | 12 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1546 | 3 | 0 | yes | 16 | I can hear an echo of something old beneath the ci |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 2059,
    "median_ms": 1940,
    "min_ms": 1475,
    "max_ms": 2774,
    "ocr_runs": 26,
    "translation_requests": 3,
    "from_cache": 3,
    "image_cache_hits": 77
  },
  "first_time_lines": {
    "n": 5,
    "missing": 0,
    "mean_ms": 2161,
    "median_ms": 2250,
    "min_ms": 1475,
    "max_ms": 2774,
    "ocr_runs": 23,
    "translation_requests": 3,
    "from_cache": 2,
    "image_cache_hits": 61
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1546,
    "median_ms": 1546,
    "min_ms": 1546,
    "max_ms": 1546,
    "ocr_runs": 3,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 16
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 2059,
      "median_ms": 1940,
      "min_ms": 1475,
      "max_ms": 2774,
      "ocr_runs": 26,
      "translation_requests": 3,
      "from_cache": 3,
      "image_cache_hits": 77
    }
  }
}
```
