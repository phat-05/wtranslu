"""
Regenerates the text-shape fixtures used by ShapeTests.cs: lines of real, anti-aliased text in
regular / bold / italic fonts, outlined, with a vertical gradient, in two colours.

Each fixture is <name>.bgra.gz: int32 width, int32 height (little endian), then width*height BGRA
pixels. shape/fixtures.json lists the text box (ink bounds plus OCR-like padding), the font size
and what the shape analyser must find.

Needs Pillow, numpy and the Liberation and Crosextra (Carlito, Caladea) fonts:
  python make_shape_fixtures.py
"""
import gzip
import json
import os
import struct

import numpy as np
from PIL import Image, ImageDraw, ImageFont

FONTS = "/usr/share/fonts/truetype/"
OUT = os.path.join(os.path.dirname(os.path.abspath(__file__)), "shape")

NAVY, WHITE, PARCHMENT, BROWN = (18, 24, 48), (255, 255, 255), (240, 232, 214), (60, 40, 20)
LINE = "Find the red key before the tide turns, Captain."


def font(path, px):
    return ImageFont.truetype(FONTS + path, px)


def canvas(f, lines, bg):
    w = int(max(f.getlength(t) for t in lines)) + 40
    h = int(f.size * 1.25 * len(lines)) + 30
    if isinstance(bg[0], int):
        return Image.new("RGB", (w, h), bg)
    # vertical sky gradient
    im = Image.new("RGB", (w, h))
    a, b = np.array(bg[0], float), np.array(bg[1], float)
    arr = np.zeros((h, w, 3))
    for y in range(h):
        arr[y, :, :] = a + (b - a) * y / (h - 1)
    return Image.fromarray(arr.astype(np.uint8))


def save(name, im, bg, px, lines, expect, text=""):
    arr = np.asarray(im).astype(np.int32)
    bgarr = np.asarray(canvas_like(im, bg)).astype(np.int32)
    ink = np.abs(arr - bgarr).sum(2) > 30
    ys, xs = np.nonzero(ink)
    pad = max(2, round(px * 0.1))
    box = [int(xs.min()) - pad, int(ys.min()) - pad, int(xs.max() - xs.min() + 1 + 2 * pad), int(ys.max() - ys.min() + 1 + 2 * pad)]
    h, w = arr.shape[:2]
    bgra = np.zeros((h, w, 4), np.uint8)
    bgra[:, :, 0], bgra[:, :, 1], bgra[:, :, 2], bgra[:, :, 3] = arr[:, :, 2], arr[:, :, 1], arr[:, :, 0], 255
    with gzip.GzipFile(os.path.join(OUT, name + ".bgra.gz"), "wb", mtime=0) as fz:
        fz.write(struct.pack("<ii", w, h) + bgra.tobytes())
    im.save(os.path.join(OUT, "preview", name + ".png"))
    return {"name": name, "box": box, "font_px": px, "lines": lines, "text": text, **expect}


_bg_cache = {}


def canvas_like(im, bg):
    if isinstance(bg[0], int):
        return Image.new("RGB", im.size, bg)
    return canvas_sized(im.size, bg)


def canvas_sized(size, bg):
    w, h = size
    a, b = np.array(bg[0], float), np.array(bg[1], float)
    arr = np.zeros((h, w, 3))
    for y in range(h):
        arr[y, :, :] = a + (b - a) * y / (h - 1)
    return Image.fromarray(arr.astype(np.uint8))


def plain(name, path, px, fg, bg, expect, text=LINE, stroke=0, stroke_fill=None, shadow=None):
    f = font(path, px)
    im = canvas(f, [text], bg)
    if shadow:
        # (dx, dy, colour, alpha) drawn under the text, as GDI+ games draw a drop shadow
        dx, dy, colour, alpha = shadow
        layer = Image.new("L", im.size, 0)
        ImageDraw.Draw(layer).text((20 + dx, 15 + dy), text, font=f, fill=alpha)
        im = Image.composite(Image.new("RGB", im.size, colour), im, layer)
    ImageDraw.Draw(im).text((20 + stroke, 15), text, font=f, fill=fg, stroke_width=stroke, stroke_fill=stroke_fill)
    return save(name, im, bg, px, 1, expect, text)


def gradient(name, path, px, top, bottom, bg, expect, text="The Lighthouse Awakens"):
    f = font(path, px)
    im = canvas(f, [text], bg)
    mask = Image.new("L", im.size, 0)
    ImageDraw.Draw(mask).text((20, 15), text, font=f, fill=255)
    asc, desc = f.getmetrics()
    w, h = im.size
    grad = np.zeros((h, w, 3))
    y0, y1 = 15 + asc * 0.2, 15 + asc * 1.0
    for y in range(h):
        t = min(1, max(0, (y - y0) / (y1 - y0)))
        grad[y, :, :] = np.array(top) + (np.array(bottom) - np.array(top)) * t
    im = Image.composite(Image.fromarray(grad.astype(np.uint8)), im, mask)
    return save(name, im, bg, px, 1, expect, text)


def two_lines(name, path, px, colours, bg, expect):
    f = font(path, px)
    texts = ["Captain Mira", "The storm is coming, hold the mast!"]
    im = canvas(f, texts, bg)
    d = ImageDraw.Draw(im)
    for i, (t, c) in enumerate(zip(texts, colours)):
        d.text((20, 15 + i * px * 1.25), t, font=f, fill=c)
    return save(name, im, bg, px, 2, expect, " ".join(texts))


def red_word(name, path, px, bg, expect):
    f = font(path, px)
    parts = [("Find the ", WHITE), ("red key", (255, 80, 80)), (" before the tide turns.", WHITE)]
    im = canvas(f, ["".join(p for p, _ in parts)], bg)
    d = ImageDraw.Draw(im)
    x = 20
    for t, c in parts:
        d.text((x, 15), t, font=f, fill=c)
        x += f.getlength(t)
    return save(name, im, bg, px, 1, expect, "".join(p for p, _ in parts))


def main():
    os.makedirs(os.path.join(OUT, "preview"), exist_ok=True)
    N = {"bold": False, "italic": False, "gradient": False}
    items = [
        plain("sans_regular", "liberation/LiberationSans-Regular.ttf", 24, WHITE, NAVY, N),
        plain("sans_bold", "liberation/LiberationSans-Bold.ttf", 24, WHITE, NAVY, {**N, "bold": True}),
        plain("sans_italic", "liberation/LiberationSans-Italic.ttf", 24, WHITE, NAVY, {**N, "italic": True}),
        plain("serif_regular_dark", "liberation/LiberationSerif-Regular.ttf", 26, BROWN, PARCHMENT, N),
        plain("serif_bold_dark", "crosextra/Caladea-Bold.ttf", 26, BROWN, PARCHMENT, {**N, "bold": True}),
        plain("serif_italic_dark", "liberation/LiberationSerif-Italic.ttf", 26, BROWN, PARCHMENT, {**N, "italic": True}),
        plain("carlito_bold_italic", "crosextra/Carlito-BoldItalic.ttf", 30, (255, 200, 60), NAVY, {**N, "bold": True, "italic": True}),
        plain("mono_regular_small", "liberation/LiberationMono-Regular.ttf", 16, WHITE, NAVY, N, text="Lv.70  776,256  2026-11-15 14:39:01 HD"),
        plain("mono_bold_small", "liberation/LiberationMono-Bold.ttf", 18, WHITE, NAVY, {**N, "bold": True}, text="Lv.70  776,256  2026-11-15 14:39:01 HD"),
        plain("outlined_bold", "liberation/LiberationSans-Bold.ttf", 30, WHITE, ((40, 60, 110), (220, 140, 90)),
              {**N, "bold": True, "effect": "Outline", "fill": "#FFFFFF"},
              text="Hold on to the mast, the storm is here!", stroke=2, stroke_fill=(0, 0, 0)),
        plain("title_shadow", "liberation/LiberationSerif-Bold.ttf", 30, (255, 214, 120), (56, 67, 108),
              {**N, "bold": True, "effect": "Shadow", "fill": "#FFD678"},
              text="Chapter 2: The Lighthouse", shadow=(3, 3, (0, 0, 0), 200)),
        gradient("gradient_serif_bold", "liberation/LiberationSerif-Bold.ttf", 36, (255, 244, 170), (225, 110, 25), NAVY,
                 {**N, "bold": True, "gradient": True, "top": "#FFF4AA", "bottom": "#E16E19"}),
        two_lines("two_lines_two_colours", "liberation/LiberationSans-Regular.ttf", 24, [(255, 200, 60), WHITE], NAVY, N),
        red_word("red_word", "liberation/LiberationSans-Regular.ttf", 26, NAVY, N),
    ]
    json.dump(items, open(os.path.join(OUT, "fixtures.json"), "w"), indent=1)
    print(f"{len(items)} fixtures written to {OUT}")


if __name__ == "__main__":
    main()
