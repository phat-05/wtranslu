Text boxes as RST saw them on Windows during the CI style scenario (MockGame drawn with GDI+,
captured with Windows.Graphics.Capture, run 45), saved by RST_STYLE_DUMP_DIR. Same format as
../shape: int32 width, int32 height, then BGRA pixels, gzip. fixtures.json gives the box, the
OCR font size estimate and line count, the OCR text and what MockGame really drew (Styles.cs):
fill, effect, bold, italic, gradient and px (the game's font size; 0 = letters cut by the screen
edge, size not measurable).
