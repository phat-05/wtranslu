"""
How close the overlay comes to the original text, per text element of a MockGame run.

MockGame writes how it draws every style (--truth styles.json); RST logs how it drew each
translation (font_size lines of RST_METRICS_FILE). Every element on screen is matched with the
overlay drawn for it, and scored 0..1 on:

  size      overlay font size vs game font size (1 - relative error)
  color     fill colour distance (1 - RGB distance / 441)
  gradient  vertical gradient fill present iff the game used one (and roughly the same colours)
  effect    outline / shadow / none, same kind as the game
  bold      bold iff the game text is bold
  italic    italic iff the game text is italic
  font      same kind of typeface (serif, sans, mono, condensed, script)
  align     left / centred like the game

Usage: python fidelity.py <run dir with s1_mock_events.csv and s1_rst_metrics.csv> <styles.json> [label]
Writes fidelity.json and fidelity.md into the run dir and prints the summary.
"""
import csv
import json
import os
import re
import sys

FONT_CLASS = {
    "serif": ["georgia", "times", "cambria", "constantia", "palatino", "book antiqua", "garamond", "sylfaen", "noto serif"],
    "mono": ["consolas", "courier", "cascadia", "lucida console", "noto mono"],
    "condensed": ["condensed", "narrow", "bahnschrift"],
    "script": ["print", "script", "comic", "ink free", "gabriola"],
}
COMPONENTS = ["size", "color", "gradient", "effect", "bold", "italic", "font", "align"]


def font_class(name):
    n = (name or "").lower()
    for cls, keys in FONT_CLASS.items():
        if any(k in n for k in keys):
            return cls
    return "sans"


def rgb(h):
    h = h.strip().lstrip("#")
    return tuple(int(h[i:i + 2], 16) for i in (0, 2, 4)) if len(h) >= 6 else None


def dist(a, b):
    return sum((x - y) ** 2 for x, y in zip(a, b)) ** 0.5


def words(t):
    return set(re.findall(r"[a-z0-9]+", (t or "").lower()))


def similar(a, b):
    wa, wb = words(a), words(b)
    if not wa or not wb:
        return 0
    return len(wa & wb) / len(wa | wb)


def part_of(line, text):
    """Whether an overlay's source text is one of the lines of a longer text (most of its words in it)."""
    wl, wt = words(line), words(text)
    if len(wl) == 1:  # a one-word menu item: that word must be one of the text's
        return wl <= wt and len(wt) > 1
    return len(wl) >= 2 and len(wl & wt) >= 0.8 * len(wl) and len(wl) < len(wt)


def expected_elements(events):
    """(t0, t1, style, text) for every piece of text on screen during each step."""
    chapter = "Chapter 1: The Old Harbor"
    rows = [r for r in events if r and r[1] != "-1"]
    end = [int(r[0]) for r in events if r and r[1] == "-1"]
    out = []
    for i, r in enumerate(rows):
        t0 = int(r[0])
        t1 = int(rows[i + 1][0]) if i + 1 < len(rows) else (end[0] if end else t0 + 6000)
        style, speaker, text = r[3], r[4], r[5]
        if style == "title":
            chapter = text
        out.append((t0, t1, "title", chapter))
        if style == "dialogue":
            out.append((t0, t1, "speaker", speaker))
            out.append((t0, t1, "dialogue", text))
        elif style in ("menu", "centered"):
            out.append((t0, t1, style, text.replace(" / ", " ")))
        elif style != "title":
            out.append((t0, t1, style, text))
    return out


def overlay_entries(metrics):
    entries = []
    for r in metrics:
        if len(r) < 3 or r[1] != "font_size":
            continue
        p = r[2].split("|")
        if len(p) < 6:
            continue
        entries.append({
            "t": int(r[0]), "size": float(p[0]), "source": p[3], "shown": p[4], "family": p[5],
            "weight": p[6] if len(p) > 6 else "Normal", "style": p[7] if len(p) > 7 else "Normal",
            "fill": p[8] if len(p) > 8 else "", "effect": p[9] if len(p) > 9 else "None",
            "align": p[10] if len(p) > 10 else "Left",
        })
    return entries


def score(element_style, truth, o):
    t = truth[element_style]
    s = {}
    s["size"] = max(0.0, 1 - abs(o["size"] / t["px"] - 1))
    fill = o["fill"]
    grad = ">" in fill
    top = rgb(fill.split(">")[0]) if fill else None
    bottom = rgb(fill.split(">")[-1]) if fill else None
    want_top, want_bottom = rgb(t["fill"]), rgb(t["gradient_to"]) if t.get("gradient_to") else None
    if top is None:
        s["color"] = 0.0
    elif want_bottom:
        mid_game = tuple((a + b) / 2 for a, b in zip(want_top, want_bottom))
        mid_overlay = tuple((a + b) / 2 for a, b in zip(top, bottom))
        s["color"] = max(0.0, 1 - dist(mid_game, mid_overlay) / 441)
    else:
        s["color"] = max(0.0, 1 - dist(top, want_top) / 441)
    if want_bottom:
        s["gradient"] = 1.0 if grad and dist(top, want_top) < 90 and dist(bottom, want_bottom) < 90 else 0.0
    else:
        s["gradient"] = 0.0 if grad else 1.0
    s["effect"] = 1.0 if o["effect"].lower() == t["effect"].lower() else 0.0
    is_bold = o["weight"].lower() in ("bold", "semibold", "demibold", "extrabold", "ultrabold", "black", "heavy")
    s["bold"] = 1.0 if is_bold == t["bold"] else 0.0
    is_italic = o["style"].lower() in ("italic", "oblique")
    s["italic"] = 1.0 if is_italic == t["italic"] else 0.0
    s["font"] = 1.0 if font_class(o["family"]) == font_class(t["font"]) else 0.0
    s["align"] = 1.0 if o["align"].lower().startswith(t["align"][:4]) else 0.0
    return s


def main(run_dir, truth_path, label=""):
    truth = json.load(open(truth_path, encoding="utf-8"))
    events = list(csv.reader(open(os.path.join(run_dir, "s1_mock_events.csv"), encoding="utf-8")))[1:]
    metrics = list(csv.reader(open(os.path.join(run_dir, "s1_rst_metrics.csv"), encoding="utf-8")))
    entries = overlay_entries(metrics)

    rows = []
    seen = set()
    for t0, t1, style, text in expected_elements(events):
        if (style, text) in seen or style not in truth:
            continue
        in_time = [e for e in entries if t0 <= e["t"] < t1 + 1000]
        window = [e for e in in_time if similar(e["source"], text) >= 0.6]
        if window:
            parts = [window[-1]]
        else:
            # Text of several lines may be shown as one overlay per line: score each line's overlay
            latest = {}
            for e in in_time:
                if part_of(e["source"], text):
                    latest[e["source"]] = e
            parts = list(latest.values())
        if not parts:
            continue
        seen.add((style, text))
        scores = [score(style, truth, o) for o in parts]
        s = {c: sum(x[c] for x in scores) / len(scores) for c in COMPONENTS}
        rows.append({"style": style, "text": text, "overlay": parts[-1], "parts": len(parts), "scores": s,
                     "total": sum(s.values()) / len(s)})

    summary = {c: round(sum(r["scores"][c] for r in rows) / len(rows), 3) if rows else None for c in COMPONENTS}
    summary["overall"] = round(sum(r["total"] for r in rows) / len(rows), 3) if rows else None
    summary["elements"] = len(rows)
    json.dump({"label": label, "summary": summary, "rows": rows}, open(os.path.join(run_dir, "fidelity.json"), "w", encoding="utf-8"),
              ensure_ascii=False, indent=1)
    with open(os.path.join(run_dir, "fidelity.md"), "w", encoding="utf-8") as f:
        f.write(f"# Fidelity {label}\n\n| style | text | " + " | ".join(COMPONENTS) + " | total | overlay |\n|" + "---|" * (len(COMPONENTS) + 4) + "\n")
        for r in rows:
            o = r["overlay"]
            f.write(f"| {r['style']} | {r['text'][:30]} | " + " | ".join(f"{r['scores'][c]:.2f}" for c in COMPONENTS) +
                    f" | {r['total']:.2f} | {o['size']:.0f}px {o['family']} {o['weight']} {o['style']} {o['fill']} {o['effect']} {o['align']} |\n")
        f.write("\n**Mean:** " + ", ".join(f"{k} {v}" for k, v in summary.items()) + "\n")
    print(label, json.dumps(summary))
    return summary


if __name__ == "__main__":
    main(sys.argv[1], sys.argv[2], sys.argv[3] if len(sys.argv) > 3 else "")
