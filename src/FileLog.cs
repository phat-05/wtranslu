using System;
using System.IO;
using System.Text;

namespace RSTGameTranslation
{
    /// <summary>
    /// Copies everything written to the console into logs\rst_log.txt next to rst.exe, flushed line by
    /// line, so the last lines before a crash that kills the process outright (a native crash leaves
    /// no crash_log.txt) can still be read. The file starts fresh on every launch and stops growing at
    /// MaxBytes.
    /// </summary>
    public sealed class FileLog : TextWriter
    {
        private const long MaxBytes = 20L * 1024 * 1024;

        private readonly TextWriter _inner;
        private readonly StreamWriter? _file;
        private readonly object _lock = new object();
        private long _written;

        public static string LogPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "rst_log.txt");

        private FileLog(TextWriter inner)
        {
            _inner = inner;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogPath)!);
                _file = new StreamWriter(new FileStream(LogPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite), new UTF8Encoding(false))
                {
                    AutoFlush = true
                };
                _file.WriteLine($"=== RST started {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
            }
            catch
            {
                _file = null; // no log file (read-only folder): the console still works
            }
        }

        /// <summary>A writer that writes to <paramref name="inner"/> and to the log file.</summary>
        public static TextWriter Wrap(TextWriter inner) => new FileLog(inner);

        public override Encoding Encoding => _inner.Encoding;

        public override void Write(char value)
        {
            _inner.Write(value);
            ToFile(value.ToString());
        }

        public override void Write(string? value)
        {
            _inner.Write(value);
            if (value != null)
                ToFile(value);
        }

        public override void WriteLine(string? value)
        {
            _inner.WriteLine(value);
            ToFile((value ?? "") + Environment.NewLine);
        }

        private void ToFile(string text)
        {
            if (_file == null)
                return;
            lock (_lock)
            {
                if (_written > MaxBytes)
                    return;
                try
                {
                    _file.Write(text);
                    _written += text.Length;
                }
                catch
                {
                    // Logging must never break the app
                }
            }
        }
    }
}
