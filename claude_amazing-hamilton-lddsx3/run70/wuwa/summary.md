# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2793 | 2 | 1 |  | 3 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1868 | 2 | 0 | yes | 4 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1866 | 3 | 1 |  | 3 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1811 | 3 | 1 |  | 4 | Then we leave now. Stay close to me. |
| s1 | 4 | 1963 | 4 | 0 | yes | 2 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1593 | 4 | 0 | yes | 2 | I can hear an echo of something old beneath the ci |
| s1 | 6 | 1137 | 1 | 0 | yes | 1 | Events / Store / Pioneer Podcast / Convene / Reson |
| s1 | 7 | 1119 | 1 | 0 | yes | 1 |  |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 8,
    "missing": 0,
    "mean_ms": 1769,
    "median_ms": 1838,
    "min_ms": 1119,
    "max_ms": 2793,
    "ocr_runs": 20,
    "translation_requests": 3,
    "from_cache": 5,
    "image_cache_hits": 20
  },
  "first_time_lines": {
    "n": 7,
    "missing": 0,
    "mean_ms": 1794,
    "median_ms": 1866,
    "min_ms": 1119,
    "max_ms": 2793,
    "ocr_runs": 16,
    "translation_requests": 3,
    "from_cache": 4,
    "image_cache_hits": 18
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1593,
    "median_ms": 1593,
    "min_ms": 1593,
    "max_ms": 1593,
    "ocr_runs": 4,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 2
  },
  "per_session": {
    "s1": {
      "n": 8,
      "missing": 0,
      "mean_ms": 1769,
      "median_ms": 1838,
      "min_ms": 1119,
      "max_ms": 2793,
      "ocr_runs": 20,
      "translation_requests": 3,
      "from_cache": 5,
      "image_cache_hits": 20
    }
  }
}
```
