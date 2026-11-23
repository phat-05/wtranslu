# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 3103 | 1 | 0 | yes | 2 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1891 | 2 | 0 | yes | 4 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1895 | 3 | 1 |  | 2 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1867 | 2 | 0 | yes | 4 | Then we leave now. Stay close to me. |
| s1 | 4 | 1971 | 3 | 1 |  | 2 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1993 | 5 | 0 | yes | 0 | I can hear an echo of something old beneath the ci |
| s1 | 6 | 1997 | 1 | 0 | yes | 1 | Events / Store / Pioneer Podcast / Convene / Reson |
| s1 | 1 | None | 0 | 0 |  | 0 | I can hear an echo of something old beneath the ci |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 7,
    "missing": 1,
    "mean_ms": 2102,
    "median_ms": 1971,
    "min_ms": 1867,
    "max_ms": 3103,
    "ocr_runs": 17,
    "translation_requests": 2,
    "from_cache": 5,
    "image_cache_hits": 15
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 2121,
    "median_ms": 1933,
    "min_ms": 1867,
    "max_ms": 3103,
    "ocr_runs": 12,
    "translation_requests": 2,
    "from_cache": 4,
    "image_cache_hits": 15
  },
  "repeated_lines": {
    "n": 1,
    "missing": 1,
    "mean_ms": 1993,
    "median_ms": 1993,
    "min_ms": 1993,
    "max_ms": 1993,
    "ocr_runs": 5,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 0
  },
  "per_session": {
    "s1": {
      "n": 7,
      "missing": 1,
      "mean_ms": 2102,
      "median_ms": 1971,
      "min_ms": 1867,
      "max_ms": 3103,
      "ocr_runs": 17,
      "translation_requests": 2,
      "from_cache": 5,
      "image_cache_hits": 15
    }
  }
}
```
