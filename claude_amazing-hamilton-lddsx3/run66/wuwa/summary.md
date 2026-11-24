# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3003 | 1 | 0 | yes | 3 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1870 | 2 | 0 | yes | 3 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 2103 | 2 | 1 |  | 2 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1804 | 2 | 1 |  | 4 | Then we leave now. Stay close to me. |
| s1 | 4 | 2324 | 3 | 0 | yes | 1 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1680 | 3 | 0 | yes | 1 | I can hear an echo of something old beneath the ci |
| s1 | 6 | 1560 | 2 | 0 | yes | 0 | Events / Store / Pioneer Podcast / Convene / Reson |
| s1 | 7 | 2322 | 1 | 1 |  | 1 |  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 2083,
    "median_ms": 1986,
    "min_ms": 1560,
    "max_ms": 3003,
    "ocr_runs": 16,
    "translation_requests": 3,
    "from_cache": 5,
    "image_cache_hits": 15
  },
  "first_time_lines": {
    "n": 7,
    "missing": 0,
    "mean_ms": 2141,
    "median_ms": 2103,
    "min_ms": 1560,
    "max_ms": 3003,
    "ocr_runs": 13,
    "translation_requests": 3,
    "from_cache": 4,
    "image_cache_hits": 14
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1680,
    "median_ms": 1680,
    "min_ms": 1680,
    "max_ms": 1680,
    "ocr_runs": 3,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 1
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 2083,
      "median_ms": 1986,
      "min_ms": 1560,
      "max_ms": 3003,
      "ocr_runs": 16,
      "translation_requests": 3,
      "from_cache": 5,
      "image_cache_hits": 15
    }
  }
}
```
