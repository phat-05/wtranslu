using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace RSTGameTranslation
{
    /// <summary>
    /// When the player last did something: a key, a mouse button, the mouse wheel, or a gamepad
    /// button (see GamepadShortcuts). Mouse movement alone does not count. Known games refresh their
    /// translation only after such input (see MainWindow.KnownGames.cs), so the overlay stays still
    /// over animated menus instead of being re-read every few seconds.
    ///
    /// Read by polling on a background thread (GetLastInputInfo, the cursor position and the mouse
    /// buttons every 30 ms), not with a low-level mouse hook, which would run on the UI thread and
    /// could make the game's mouse stutter while the UI thread is busy.
    /// </summary>
    public static class InputActivity
    {
        // Refresh window after an input: the game needs a moment to change screens, then a little
        // longer for menus that slide or fade in
        public const int RefreshDelayMs = 300;
        public const int RefreshWindowMs = 2200;
        // Text that changed in that window (a line typing out, a list sliding in) is read on until it
        // settles, up to this long after the input
        public const int MaxRefreshMs = 8000;

        private static long _lastInputTick = Environment.TickCount64;
        private static CancellationTokenSource? _cts;

        public static long LastInputTick => Interlocked.Read(ref _lastInputTick);

        /// <summary>The player did something now (also used to refresh right away, e.g. on start).</summary>
        public static void Touch() => Interlocked.Exchange(ref _lastInputTick, Environment.TickCount64);

        // Gamepad buttons count too while watching (GamepadShortcuts polls the controllers then)
        public static volatile bool Watching;

        /// <summary>
        /// Whether the screen should be read now: shortly after the player's last input, or a little
        /// longer while the text read then is still changing (textSettling).
        /// </summary>
        public static bool IsRefreshDue(bool textSettling = false)
        {
            long since = Environment.TickCount64 - LastInputTick;
            return since >= RefreshDelayMs && (since <= RefreshWindowMs || textSettling && since <= MaxRefreshMs);
        }

        public static void Start()
        {
            if (_cts != null)
                return;
            Watching = true;
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            Task.Run(async () =>
            {
                uint lastInfo = 0;
                POINT lastCursor = default;
                bool[] buttonDown = new bool[MouseButtons.Length];
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        var info = new LASTINPUTINFO { cbSize = (uint)Marshal.SizeOf<LASTINPUTINFO>() };
                        GetCursorPos(out POINT cursor);
                        bool clicked = false;
                        for (int i = 0; i < MouseButtons.Length; i++)
                        {
                            bool down = (GetAsyncKeyState(MouseButtons[i]) & 0x8000) != 0;
                            if (down && !buttonDown[i])
                                clicked = true;
                            buttonDown[i] = down;
                        }
                        if (GetLastInputInfo(ref info))
                        {
                            // Input happened with the cursor still: a key, or the wheel
                            bool other = lastInfo != 0 && info.dwTime != lastInfo &&
                                         cursor.X == lastCursor.X && cursor.Y == lastCursor.Y;
                            if (clicked || other)
                                Touch();
                            lastInfo = info.dwTime;
                        }
                        else if (clicked)
                        {
                            Touch();
                        }
                        lastCursor = cursor;
                        await Task.Delay(30, token);
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Input watching stopped: {ex.Message}");
                }
            }, token);
        }

        public static void Stop()
        {
            Watching = false;
            _cts?.Cancel();
            _cts = null;
        }

        // Left, right, middle, X1, X2
        private static readonly int[] MouseButtons = { 0x01, 0x02, 0x04, 0x05, 0x06 };

        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
    }
}
