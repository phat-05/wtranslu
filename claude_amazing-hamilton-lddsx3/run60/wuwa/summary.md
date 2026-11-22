# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3333 | 3 | 1 |  | 9 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 2040 | 3 | 0 | yes | 16 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1342 | 3 | 1 |  | 13 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1530 | 5 | 0 | yes | 14 | Then we leave now. Stay close to me. |
| s1 | 4 | 2660 | 6 | 0 | yes | 11 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1351 | 5 | 0 | yes | 14 | I can hear an echo of something old beneath the ci |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 6,
    "missing": 0,
    "mean_ms": 2043,
    "median_ms": 1785,
    "min_ms": 1342,
    "max_ms": 3333,
    "ocr_runs": 25,
    "translation_requests": 2,
    "from_cache": 4,
    "image_cache_hits": 77
  },
  "first_time_lines": {
    "n": 5,
    "missing": 0,
    "mean_ms": 2181,
    "median_ms": 2040,
    "min_ms": 1342,
    "max_ms": 3333,
    "ocr_runs": 20,
    "translation_requests": 2,
    "from_cache": 3,
    "image_cache_hits": 63
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1351,
    "median_ms": 1351,
    "min_ms": 1351,
    "max_ms": 1351,
    "ocr_runs": 5,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 14
  },
  "per_session": {
    "s1": {
      "n": 6,
      "missing": 0,
      "mean_ms": 2043,
      "median_ms": 1785,
      "min_ms": 1342,
      "max_ms": 3333,
      "ocr_runs": 25,
      "translation_requests": 2,
      "from_cache": 4,
      "image_cache_hits": 77
    }
  }
}
```
