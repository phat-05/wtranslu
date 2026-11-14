using System;
using System.Diagnostics;
using System.IO;

namespace RSTGameTranslation
{
    /// <summary>
    /// Timestamped log lines for the screen → OCR → translation → overlay pipeline, so the console
    /// shows where the time goes for each new piece of text. OCR runs several times a second, so
    /// only frames with new text are logged; later stages show the time since that text was seen.
    /// Grep the console for "[OCR timing".
    /// When the environment variable RST_METRICS_FILE is set, every stage (and every OCR run) is
    /// also appended to that CSV file with a UTC millisecond timestamp, for latency measurements.
    /// </summary>
    public static class OcrTiming
    {
        private static readonly Stopwatch _sinceCapture = new Stopwatch();
        private static readonly Stopwatch _sinceNewText = new Stopwatch();

        // A captured frame was handed to the OCR engine (not logged: this happens every cycle)
        public static void MarkCaptureSent()
        {
            _sinceCapture.Restart();
            Metrics.Write("ocr_start", "");
        }

        // The frame was recognised by the image cache: its stored OCR result is used instead of OCR
        public static void MarkImageCacheHit(int lines)
        {
            _sinceCapture.Restart();
            Metrics.Write("0. Image cache hit", $"{lines} line(s)");
        }

        // OCR returned text that differs from what is on screen; starts the per-text timeline
        public static void NewTextDetected(string detail)
        {
            long ocrMs = _sinceCapture.IsRunning ? _sinceCapture.ElapsedMilliseconds : -1;
            _sinceNewText.Restart();
            Log("1. New text from OCR", $"OCR took {ocrMs} ms; {detail}");
        }

        public static void Log(string stage, string detail = "")
        {
            string elapsed = _sinceNewText.IsRunning ? $" +{_sinceNewText.ElapsedMilliseconds}ms" : "";
            Console.WriteLine($"[OCR timing {DateTime.Now:HH:mm:ss.fff}{elapsed}] {stage}{(detail.Length > 0 ? ": " + detail : "")}");
            Metrics.Write(stage, detail);
        }

        public static string Preview(string text, int max = 40) => AudioTiming.Preview(text, max);

        /// <summary>
        /// CSV sink for measurements: utc_ms,stage,detail. Off unless RST_METRICS_FILE is set.
        /// </summary>
        public static class Metrics
        {
            private static readonly string? _path = Environment.GetEnvironmentVariable("RST_METRICS_FILE");
            private static readonly object _lock = new object();

            public static bool Enabled => !string.IsNullOrEmpty(_path);

            public static void Write(string stage, string detail)
            {
                if (!Enabled)
                    return;
                try
                {
                    long ms = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    string line = $"{ms},{Escape(stage)},{Escape(detail)}{Environment.NewLine}";
                    lock (_lock)
                    {
                        File.AppendAllText(_path!, line);
                    }
                }
                catch
                {
                    // Measurements must never break translation
                }
            }

            private static string Escape(string value) =>
                "\"" + value.Replace("\"", "\"\"").Replace("\r", " ").Replace("\n", " ") + "\"";
        }
    }
}
