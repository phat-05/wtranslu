"""
End-to-end run of RST against MockGame on Windows (used by CI, also runnable by hand).

For each session: start MockGame (logs when each line appears), start RST in automation mode
(it selects the MockGame window, shows the overlay and starts translating, and logs pipeline
stages to a CSV), take a screenshot of the game window a few seconds after each line appears,
then stop both. Several sessions in a row show what survives an app restart (persistent cache).

Then every line is matched with the first "Translation shown" event after it:
latency = time translation shown - time line appeared on screen.

Usage:
  python run_e2e.py --rst app\\rst.exe --mock tests\\MockGame\\bin\\Release\\net9.0-windows\\MockGame.exe
                    --script tests\\e2e\\scenarios\\cache.txt --out evidence\\run --sessions 2 --label baseline
"""
import argparse
import csv
import json
import os
import shutil
import statistics
import subprocess
import sys
import threading
import time

WINDOW_TITLE = "MockGame Dialogue Test"
SHOWN_STAGE = "5. Translation shown"


def read_csv(path):
    if not os.path.exists(path):
        return []
    with open(path, newline="", encoding="utf-8") as f:
        return list(csv.reader(f))


def screenshot_loop(events_path, out_dir, prefix, stop, delay_ms):
    """Screenshot the game area delay_ms after every new line logged by MockGame."""
    import mss
    from PIL import Image

    seen = 0
    pending = []
    with mss.mss() as sct:
        while not stop.is_set():
            rows = read_csv(events_path)[1:]
            for row in rows[seen:]:
                if row and row[1] != "-1":
                    pending.append((int(row[0]) + delay_ms, int(row[1]), int(row[2])))
            seen = len(rows)
            now = int(time.time() * 1000)
            for item in [p for p in pending if p[0] <= now]:
                pending.remove(item)
                _, step, cycle = item
                shot = sct.grab({"left": 0, "top": 0, "width": 980, "height": 610})
                img = Image.frombytes("RGB", shot.size, shot.rgb)
                img.save(os.path.join(out_dir, f"{prefix}_c{cycle}_step{step:02d}.jpg"), quality=85)
            time.sleep(0.05)


def kill(proc):
    if proc and proc.poll() is None:
        subprocess.run(["taskkill", "/PID", str(proc.pid), "/T", "/F"], capture_output=True)


def run_session(args, index):
    prefix = f"s{index}"
    events = os.path.abspath(os.path.join(args.out, f"{prefix}_mock_events.csv"))
    metrics = os.path.abspath(os.path.join(args.out, f"{prefix}_rst_metrics.csv"))
    console = os.path.abspath(os.path.join(args.out, f"{prefix}_rst_console.txt"))
    for p in (events, metrics):
        if os.path.exists(p):
            os.remove(p)

    env = dict(os.environ)
    env["RST_AUTOMATION_WINDOW"] = args.window
    env["RST_METRICS_FILE"] = metrics
    env["RST_AUTOMATION_CONFIG"] = args.config
    for pair in args.env:
        key, _, value = pair.partition("=")
        env[key] = value
    if args.dump_styles:
        # The pixels of every analysed text box, to tune the style analysers offline
        env["RST_STYLE_DUMP_DIR"] = os.path.abspath(os.path.join(args.out, "style_dump"))

    mock_exe = args.mock
    if args.mock_as:
        # The mock under another executable name (a game's process name); its DLL stays beside it
        mock_exe = os.path.join(os.path.dirname(os.path.abspath(args.mock)), args.mock_as)
        shutil.copyfile(os.path.abspath(args.mock), mock_exe)
    mock = subprocess.Popen([mock_exe, "--script", os.path.abspath(args.script), "--log", events,
                             "--animate", "--cycles", str(args.cycles),
                             "--truth", os.path.abspath(os.path.join(args.out, "styles.json"))] + args.mock_arg)
    time.sleep(2)
    rst_dir = os.path.dirname(os.path.abspath(args.rst))
    with open(console, "w", encoding="utf-8", errors="replace") as console_file:
        rst = subprocess.Popen([os.path.abspath(args.rst)], cwd=rst_dir, env=env,
                               stdout=console_file, stderr=subprocess.STDOUT)
        stop = threading.Event()
        shooter = threading.Thread(target=screenshot_loop,
                                   args=(events, args.out, prefix, stop, args.shot_delay), daemon=True)
        shooter.start()
        try:
            mock.wait(timeout=args.timeout)
        except subprocess.TimeoutExpired:
            kill(mock)
        time.sleep(4)  # let RST finish writing (cache files, metrics)
        stop.set()
        shooter.join(timeout=5)
        crashed = rst.poll() is not None
        if crashed:
            print(f"RST EXITED during the session (exit code {rst.returncode})", flush=True)
        # Ask RST to close like a user would, then make sure it is gone
        subprocess.run(["taskkill", "/PID", str(rst.pid)], capture_output=True)
        try:
            rst.wait(timeout=8)
        except subprocess.TimeoutExpired:
            kill(rst)
    results = analyse(events, metrics, prefix)
    for r in results:
        r["rst_crashed"] = crashed
    return results


def analyse(events_path, metrics_path, prefix):
    lines = [r for r in read_csv(events_path)[1:] if r and r[1] != "-1"]
    end_rows = [r for r in read_csv(events_path)[1:] if r and r[1] == "-1"]
    metrics = [(int(r[0]), r[1], r[2] if len(r) > 2 else "") for r in read_csv(metrics_path) if r]
    results = []
    for i, row in enumerate(lines):
        t0 = int(row[0])
        t1 = int(lines[i + 1][0]) if i + 1 < len(lines) else (int(end_rows[0][0]) if end_rows else t0 + 10_000)
        window = [m for m in metrics if t0 <= m[0] < t1]
        shown = [m for m in window if m[1] == SHOWN_STAGE]
        results.append({
            "session": prefix,
            "step": int(row[1]),
            "cycle": int(row[2]),
            "text": row[5],
            "latency_ms": (shown[0][0] - t0) if shown else None,
            "ocr_runs": sum(1 for m in window if m[1] == "ocr_start"),
            "translation_requests": sum(1 for m in window if m[1] == "3. Translation request"),
            "served_from_cache": any(m[1] == "3. Translation served from cache" for m in window),
            "image_cache_hits": sum(1 for m in window if m[1].startswith("0. Image cache hit")),
        })
    return results


def summarise(label, results):
    def stats(rows):
        vals = [r["latency_ms"] for r in rows if r["latency_ms"] is not None]
        if not vals:
            return {"n": 0}
        return {
            "n": len(vals),
            "missing": sum(1 for r in rows if r["latency_ms"] is None),
            "mean_ms": round(statistics.mean(vals)),
            "median_ms": round(statistics.median(vals)),
            "min_ms": min(vals),
            "max_ms": max(vals),
            "ocr_runs": sum(r["ocr_runs"] for r in rows),
            "translation_requests": sum(r["translation_requests"] for r in rows),
            "from_cache": sum(1 for r in rows if r["served_from_cache"]),
            "image_cache_hits": sum(r["image_cache_hits"] for r in rows),
        }

    seen = set()
    first, repeat = [], []
    groups = {}
    for r in results:
        key = (r["session"], r["text"])
        (repeat if r["text"] in seen else first).append(r)
        seen.add(r["text"])
        groups.setdefault(r["session"], []).append(r)
    return {
        "label": label,
        "all": stats(results),
        "first_time_lines": stats(first),
        "repeated_lines": stats(repeat),
        "per_session": {s: stats(rows) for s, rows in groups.items()},
    }


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--rst", required=True)
    ap.add_argument("--mock", required=True)
    ap.add_argument("--script", required=True)
    ap.add_argument("--out", required=True)
    ap.add_argument("--label", default="run")
    ap.add_argument("--sessions", type=int, default=2)
    ap.add_argument("--cycles", type=int, default=1)
    ap.add_argument("--shot-delay", type=int, default=3000)
    ap.add_argument("--timeout", type=int, default=600)
    ap.add_argument("--config", default="source_language=en;target_language=vi;ocr_method=OneOCR;translation_service=Google Translate")
    ap.add_argument("--fresh", action="store_true", help="delete RST cache folder before the first session")
    ap.add_argument("--dump-styles", action="store_true", help="save the pixels of every analysed text box (style_dump/)")
    ap.add_argument("--window", default=WINDOW_TITLE, help="window RST selects; @known = RST must find a game it knows by itself")
    ap.add_argument("--mock-as", default="", help="run the mock under this executable name (e.g. Client-Win64-Shipping.exe)")
    ap.add_argument("--mock-arg", action="append", default=[], help="extra MockGame argument (repeatable)")
    ap.add_argument("--env", action="append", default=[], help="extra KEY=VALUE environment variable for RST (repeatable)")
    args = ap.parse_args()

    os.makedirs(args.out, exist_ok=True)
    if args.fresh:
        cache_dir = os.path.join(os.path.dirname(os.path.abspath(args.rst)), "Cache")
        shutil.rmtree(cache_dir, ignore_errors=True)

    results = []
    for i in range(1, args.sessions + 1):
        print(f"== session {i}", flush=True)
        results.extend(run_session(args, i))

    summary = summarise(args.label, results)
    with open(os.path.join(args.out, "results.json"), "w", encoding="utf-8") as f:
        json.dump({"summary": summary, "lines": results}, f, ensure_ascii=False, indent=2)

    with open(os.path.join(args.out, "summary.md"), "w", encoding="utf-8") as f:
        f.write(f"# {args.label}\n\n")
        f.write("| session | step | latency ms | OCR runs | requests | text cache | image hits | text |\n|---|---|---|---|---|---|---|---|\n")
        for r in results:
            f.write(f"| {r['session']} | {r['step']} | {r['latency_ms']} | {r['ocr_runs']} | {r['translation_requests']} | "
                    f"{'yes' if r['served_from_cache'] else ''} | {r['image_cache_hits']} | {r['text'][:50]} |\n")
        f.write("\n```json\n" + json.dumps(summary, indent=2) + "\n```\n")
    print(json.dumps(summary, indent=2))
    # How close the overlay came to the original text (style scenarios)
    truth = os.path.join(args.out, "styles.json")
    if os.path.exists(truth):
        try:
            import fidelity
            fidelity.main(args.out, truth, args.label)
        except Exception as ex:  # scoring must not hide the run's own result
            print(f"fidelity scoring failed: {ex}")
    if any(r.get("rst_crashed") for r in results):
        print("FAIL: RST exited before the end of a session")
        return 1
    return 0


if __name__ == "__main__":
    sys.exit(main())
