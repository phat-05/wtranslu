# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3334 | 1 | 0 | yes | 3 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 2064 | 3 | 1 |  | 1 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1183 | 2 | 1 |  | 3 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1585 | 2 | 0 | yes | 4 | Then we leave now. Stay close to me. |
| s1 | 4 | 2331 | 3 | 0 | yes | 1 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1709 | 3 | 0 | yes | 1 | I can hear an echo of something old beneath the ci |
| s1 | 6 | 1257 | 1 | 0 | yes | 1 | Events / Store / Pioneer Podcast / Convene / Reson |
| s1 | 7 | 2315 | 2 | 1 |  | 0 |  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1972,
    "median_ms": 1886,
    "min_ms": 1183,
    "max_ms": 3334,
    "ocr_runs": 17,
    "translation_requests": 3,
    "from_cache": 5,
    "image_cache_hits": 14
  },
  "first_time_lines": {
    "n": 7,
    "missing": 0,
    "mean_ms": 2010,
    "median_ms": 2064,
    "min_ms": 1183,
    "max_ms": 3334,
    "ocr_runs": 14,
    "translation_requests": 3,
    "from_cache": 4,
    "image_cache_hits": 13
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1709,
    "median_ms": 1709,
    "min_ms": 1709,
    "max_ms": 1709,
    "ocr_runs": 3,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 1
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 1972,
      "median_ms": 1886,
      "min_ms": 1183,
      "max_ms": 3334,
      "ocr_runs": 17,
      "translation_requests": 3,
      "from_cache": 5,
      "image_cache_hits": 14
    }
  }
}
```
