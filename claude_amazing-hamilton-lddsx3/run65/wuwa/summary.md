# claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario

| session | step | latency ms | OCR runs | requests | text cache | image hits | text |
|---|---|---|---|---|---|---|---|
| s1 | 0 | 2567 | 1 | 0 | yes | 4 | The Resonators gathered at the edge of Jinzhou bef |
| s1 | 1 | 1993 | 3 | 1 |  | 2 | I can hear an echo of something old beneath the ci |
| s1 | 2 | 1720 | 2 | 1 |  | 4 | Let's go together. / I'll go alone. / Tell me more |
| s1 | 3 | 1188 | 2 | 0 | yes | 4 | Then we leave now. Stay close to me. |
| s1 | 4 | 2022 | 3 | 1 |  | 2 | Rover, the Tacet Discord is heading for Jinzhou. Y |
| s1 | 5 | 1951 | 4 | 0 | yes | 1 | I can hear an echo of something old beneath the ci |
| s1 | 6 | 1303 | 1 | 0 | yes | 1 | Events / Store / Pioneer Podcast / Convene / Reson |

```json
{
  "label": "claude/amazing-hamilton-lddsx3 Wuthering Waves-like scenario",
  "all": {
    "n": 7,
    "missing": 0,
    "mean_ms": 1821,
    "median_ms": 1951,
    "min_ms": 1188,
    "max_ms": 2567,
    "ocr_runs": 16,
    "translation_requests": 3,
    "from_cache": 4,
    "image_cache_hits": 18
  },
  "first_time_lines": {
    "n": 6,
    "missing": 0,
    "mean_ms": 1799,
    "median_ms": 1856,
    "min_ms": 1188,
    "max_ms": 2567,
    "ocr_runs": 12,
    "translation_requests": 3,
    "from_cache": 3,
    "image_cache_hits": 17
  },
  "repeated_lines": {
    "n": 1,
    "missing": 0,
    "mean_ms": 1951,
    "median_ms": 1951,
    "min_ms": 1951,
    "max_ms": 1951,
    "ocr_runs": 4,
    "translation_requests": 0,
    "from_cache": 1,
    "image_cache_hits": 1
  },
  "per_session": {
    "s1": {
      "n": 7,
      "missing": 0,
      "mean_ms": 1821,
      "median_ms": 1951,
      "min_ms": 1188,
      "max_ms": 2567,
      "ocr_runs": 16,
      "translation_requests": 3,
      "from_cache": 4,
      "image_cache_hits": 18
    }
  }
}
```
