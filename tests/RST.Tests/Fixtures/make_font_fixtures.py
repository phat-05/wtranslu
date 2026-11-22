"""
Regenerates the font-matching fixtures used by FontMatchTests.cs: one line of text drawn in a
"game" font, and the same text in the candidate fonts (Liberation Sans / Serif / Mono, the
metric twins of Arial / Times New Roman / Courier New). The game fonts are other families of each
kind, as a game's own font is never one of the candidates.

Each image is <name>.cov.gz: int32 width, int32 height (little endian), then one byte of coverage
(0-255) per pixel. fonts/fixtures.json lists the games and the kind of font each one uses.
  python make_font_fixtures.py
"""
import gzip
import json
import os
import struct

import numpy as np
from PIL import Image, ImageDraw, ImageFont

FONTS = "/usr/share/fonts/truetype/"
OUT = os.path.join(os.path.dirname(os.path.abspath(__file__)), "fonts")
TEXT = "Find the red key before the tide turns."
PX = 26
CANDIDATES = {"sans": "liberation/LiberationSans-Regular.ttf", "serif": "liberation/LiberationSerif-Regular.ttf",
              "mono": "liberation/LiberationMono-Regular.ttf"}
GAMES = [("serif", "freefont/FreeSerif.ttf"), ("serif", "crosextra/Caladea-Regular.ttf"),
         ("sans", "dejavu/DejaVuSans.ttf"), ("sans", "freefont/FreeSans.ttf"), ("sans", "crosextra/Carlito-Regular.ttf"),
         ("mono", "dejavu/DejaVuSansMono.ttf"), ("mono", "jetbrains-mono/JetBrainsMono-Regular.ttf")]


def save(name, path):
    f = ImageFont.truetype(FONTS + path, PX)
    w, h = int(f.getlength(TEXT)) + 16, int(PX * 1.6)
    im = Image.new("L", (w, h), 0)
    ImageDraw.Draw(im).text((8, int(PX * 0.2)), TEXT, font=f, fill=255)
    with gzip.open(os.path.join(OUT, name + ".cov.gz"), "wb") as fz:
        fz.write(struct.pack("<ii", w, h) + np.asarray(im, np.uint8).tobytes())


def main():
    os.makedirs(OUT, exist_ok=True)
    for kind, path in CANDIDATES.items():
        save("candidate_" + kind, path)
    games = []
    for kind, path in GAMES:
        name = "game_" + os.path.splitext(os.path.basename(path))[0]
        save(name, path)
        games.append({"name": name, "kind": kind})
    json.dump(games, open(os.path.join(OUT, "fixtures.json"), "w"), indent=1)
    print(f"{len(games)} games, {len(CANDIDATES)} candidates written to {OUT}")


if __name__ == "__main__":
    main()
