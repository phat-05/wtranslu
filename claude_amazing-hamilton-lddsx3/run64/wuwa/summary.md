# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3315 | 1 | 0 | yes | 3 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1926 | 2 | 1 |  | 3 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 2165 | 3 | 1 |  | 2 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1828 | 2 | 1 |  | 4 | Then we leave now. Stay close to me. |
| s1 | 4 | 3183 | 3 | 1 |  | 2 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1694 | 4 | 0 | yes | 0 | I can hear an echo of something old beneath the ci |
| s1 | 6 | 2428 | 2 | 0 | yes | 0 | Events / Store / Pioneer Podcast / Convene / Reson |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 7,
    "missing": 0,
    "mean_ms": 2363,
    "median_ms": 2165,
    "min_ms": 1694,
    "max_ms": 3315,
    "ocr_runs": 17,
    "translation_requests": 4,
    "from_cache": 3,
    "image_cache_hits": 14
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 2474,
    "median_ms": 2296,
    "min_ms": 1828,
    "max_ms": 3315,
    "ocr_runs": 13,
    "translation_requests": 4,
    "from_cache": 2,
    "image_cache_hits": 14
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1694,
    "median_ms": 1694,
    "min_ms": 1694,
    "max_ms": 1694,
    "ocr_runs": 4,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 0
  },
  "per_session": {
    "s1": {
      "n": 7,
      "missing": 0,
      "mean_ms": 2363,
      "median_ms": 2165,
      "min_ms": 1694,
      "max_ms": 3315,
      "ocr_runs": 17,
      "translation_requests": 4,
      "from_cache": 3,
      "image_cache_hits": 14
    }
  }
}
```
