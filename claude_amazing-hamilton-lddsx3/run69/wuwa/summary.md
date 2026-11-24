# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2934 | 1 | 0 | yes | 3 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1852 | 2 | 0 | yes | 3 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 2073 | 3 | 1 |  | 1 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1502 | 1 | 0 | yes | 5 | Then we leave now. Stay close to me. |
| s1 | 4 | 2274 | 3 | 0 | yes | 1 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1938 | 3 | 0 | yes | 1 | I can hear an echo of something old beneath the ci |
| s1 | 6 | 1761 | 2 | 0 | yes | 0 | Events / Store / Pioneer Podcast / Convene / Reson |
| s1 | 7 | 2195 | 1 | 0 | yes | 1 |  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 2066,
    "median_ms": 2006,
    "min_ms": 1502,
    "max_ms": 2934,
    "ocr_runs": 16,
    "translation_requests": 1,
    "from_cache": 7,
    "image_cache_hits": 15
  },
  "first_time_lines": {
    "n": 7,
    "missing": 0,
    "mean_ms": 2084,
    "median_ms": 2073,
    "min_ms": 1502,
    "max_ms": 2934,
    "ocr_runs": 13,
    "translation_requests": 1,
    "from_cache": 6,
    "image_cache_hits": 14
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1938,
    "median_ms": 1938,
    "min_ms": 1938,
    "max_ms": 1938,
    "ocr_runs": 3,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 1
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 2066,
      "median_ms": 2006,
      "min_ms": 1502,
      "max_ms": 2934,
      "ocr_runs": 16,
      "translation_requests": 1,
      "from_cache": 7,
      "image_cache_hits": 15
    }
  }
}
```
