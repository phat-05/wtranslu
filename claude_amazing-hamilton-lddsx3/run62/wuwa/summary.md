# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 4008 | 2 | 1 |  | 2 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1871 | 3 | 0 | yes | 2 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1896 | 2 | 1 |  | 3 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1889 | 3 | 0 | yes | 2 | Then we leave now. Stay close to me. |
| s1 | 4 | 2742 | 3 | 0 | yes | 2 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1638 | 3 | 0 | yes | 2 | I can hear an echo of something old beneath the ci |
| s1 | 6 | 2975 | 1 | 1 |  | 1 | Events / Store / Pioneer Podcast / Convene / Reson |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 7,
    "missing": 0,
    "mean_ms": 2431,
    "median_ms": 1896,
    "min_ms": 1638,
    "max_ms": 4008,
    "ocr_runs": 17,
    "translation_requests": 3,
    "from_cache": 4,
    "image_cache_hits": 14
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 2564,
    "median_ms": 2319,
    "min_ms": 1871,
    "max_ms": 4008,
    "ocr_runs": 14,
    "translation_requests": 3,
    "from_cache": 3,
    "image_cache_hits": 12
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1638,
    "median_ms": 1638,
    "min_ms": 1638,
    "max_ms": 1638,
    "ocr_runs": 3,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 2
  },
  "per_session": {
    "s1": {
      "n": 7,
      "missing": 0,
      "mean_ms": 2431,
      "median_ms": 1896,
      "min_ms": 1638,
      "max_ms": 4008,
      "ocr_runs": 17,
      "translation_requests": 3,
      "from_cache": 4,
      "image_cache_hits": 14
    }
  }
}
```
