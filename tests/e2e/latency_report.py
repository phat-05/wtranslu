"""
Latency report from an RST metrics file, for a session on a real game.

Run RST with the environment variable RST_METRICS_FILE set (see README_vi.md), play for a while,
close RST, then:
    python latency_report.py C:\\temp\\rst_metrics.csv

For every new text RST detected it prints how long it took from the frame that showed it until the
translation was on screen, and how the translation was obtained:
    image  = recognised from its pixels by the image cache (no OCR)
    cache  = translation from the text cache (OCR ran, no translation request)
    fuzzy  = text cache, OCR read the sentence slightly differently
    net    = a translation request was sent
"""
import csv
import re
import statistics
import sys
from collections import Counter


def main(path):
    rows = [(int(r[0]), r[1], r[2] if len(r) > 2 else "") for r in csv.reader(open(path, encoding="utf-8")) if r]
    texts = []
    current = None
    for t, stage, detail in rows:
        if stage == "1. New text from OCR":
            m = re.search(r"OCR took (-?\d+) ms", detail)
            ocr_ms = int(m.group(1)) if m and int(m.group(1)) >= 0 else 0
            current = {"start": t - ocr_ms, "detail": detail, "kind": None, "shown": None,
                       "image": False, "fuzzy": False}
            # Was this frame served by the image cache? (a hit logged just before the new text)
            prev = [x for x in rows if t - 400 <= x[0] <= t and x[1].startswith("0. Image cache hit")]
            current["image"] = bool(prev)
            texts.append(current)
        elif current is None:
            continue
        elif stage == "3c. Fuzzy cache match":
            current["fuzzy"] = True
        elif stage in ("3. Translation request", "2a. Prefetch request"):
            current["kind"] = "net"
        elif stage == "3. Translation served from cache" and current["kind"] is None:
            current["kind"] = "cache"
        elif stage == "5. Translation shown" and current["shown"] is None:
            current["shown"] = t

    done = [x for x in texts if x["shown"] is not None]
    for x in done:
        if x["kind"] != "net":
            x["kind"] = "image" if x["image"] else ("fuzzy" if x["fuzzy"] else "cache")
    if not done:
        print("No translated text found in", path)
        return

    print(f"{'ms':>6}  {'how':6}  text")
    for x in done:
        text = x["detail"].split(": '", 1)[-1].rstrip("'")
        print(f"{x['shown'] - x['start']:>6}  {x['kind']:6}  {text[:60]}")

    lat = [x["shown"] - x["start"] for x in done]
    print()
    print(f"texts: {len(done)}   mean {statistics.mean(lat):.0f} ms   median {statistics.median(lat):.0f} ms   "
          f"worst {max(lat)} ms")
    for kind, n in Counter(x["kind"] for x in done).most_common():
        sub = [x["shown"] - x["start"] for x in done if x["kind"] == kind]
        print(f"  {kind:6} {n:4} texts   median {statistics.median(sub):.0f} ms")
    ocr_runs = sum(1 for r in rows if r[1] == "ocr_start")
    image_hits = sum(1 for r in rows if r[1].startswith("0. Image cache hit"))
    minutes = (rows[-1][0] - rows[0][0]) / 60000 if len(rows) > 1 else 0
    print(f"OCR runs: {ocr_runs}   frames served by the image cache: {image_hits}   over {minutes:.1f} min")


if __name__ == "__main__":
    if len(sys.argv) != 2:
        print(__doc__)
        sys.exit(1)
    main(sys.argv[1])
