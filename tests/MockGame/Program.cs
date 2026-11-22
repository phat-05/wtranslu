using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MockGame;

/// <summary>
/// A stand-in "game" for end-to-end tests of RST: a scene with an animated background, a chapter
/// title in big letters and a dialogue box whose lines change on a timer, like a visual novel.
/// Lines repeat (menus, recurring dialogue) so caches can be measured, and a line can colour single
/// words with {#RRGGBB:word} markup. Each change of text is logged with a UTC millisecond timestamp
/// so the time until RST shows the translation can be computed.
///
/// Usage: MockGame.exe --script script.txt --log events.csv [--animate] [--cycles N] [--truth styles.json]
/// Script lines: durationMs|style|speaker|text   (style: a key of Styles.All, or "title" to change the
/// chapter title; # = comment). --truth writes how every style is drawn, for fidelity scoring.
/// </summary>
internal static class Program
{
    public static string WindowTitle = "MockGame Dialogue Test";
    // "wuwa": a scene laid out like Wuthering Waves (subtitles at the bottom, choices on the right,
    // UID in the corner); otherwise the visual-novel scene
    public static string Layout = "";

    [STAThread]
    private static void Main(string[] args)
    {
        string? script = null, log = null, truth = null;
        bool animate = false;
        int cycles = 1;
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--script": script = args[++i]; break;
                case "--log": log = args[++i]; break;
                case "--animate": animate = true; break;
                case "--cycles": cycles = int.Parse(args[++i], CultureInfo.InvariantCulture); break;
                case "--truth": truth = args[++i]; break;
                case "--title": WindowTitle = args[++i]; break;
                case "--layout": Layout = args[++i]; break;
            }
        }

        if (truth != null)
            Styles.WriteTruth(truth);
        var steps = Step.Load(script);
        ApplicationConfiguration.Initialize();
        Application.Run(new GameForm(steps, log, animate, cycles));
    }
}

internal sealed record Step(int DurationMs, string Style, string Speaker, string Text)
{
    public static List<Step> Load(string? path)
    {
        string[] lines = path != null && File.Exists(path)
            ? File.ReadAllLines(path, Encoding.UTF8)
            : DefaultScript.Split('\n');
        var steps = new List<Step>();
        foreach (string raw in lines)
        {
            string line = raw.TrimEnd('\r');
            if (line.Length == 0 || line.StartsWith('#'))
                continue;
            string[] parts = line.Split('|', 4);
            if (parts.Length < 4)
                continue;
            steps.Add(new Step(int.Parse(parts[0], CultureInfo.InvariantCulture), parts[1].Trim(), parts[2].Trim(), parts[3].Trim()));
        }
        return steps;
    }

    // Plain text without colour markup
    public string PlainText => Regex.Replace(Text, @"\{#[0-9A-Fa-f]{6}:([^}]*)\}", "$1");

    private const string DefaultScript =
        "4000|dialogue|Captain Mira|Welcome aboard. The harbor has been quiet for days.\n" +
        "4000|dialogue|Old Fisherman|Nobody sails at night anymore. The fog is too thick.\n" +
        "4000|dialogue|Captain Mira|Welcome aboard. The harbor has been quiet for days.\n";
}

internal sealed class GameForm : Form
{
    private readonly List<Step> _steps;
    private readonly string? _logPath;
    private readonly bool _animate;
    private readonly int _cycles;
    private readonly System.Windows.Forms.Timer _frameTimer = new() { Interval = 33 };
    private readonly Stopwatch _clock = Stopwatch.StartNew();
    private int _index = -1;
    private int _cycle;
    private long _stepEndsAt;
    private long _stepStartedAt;
    private string _chapter = "Chapter 1: The Old Harbor";

    public GameForm(List<Step> steps, string? logPath, bool animate, int cycles)
    {
        _steps = steps;
        _logPath = logPath;
        _animate = animate;
        _cycles = cycles;
        Text = Program.WindowTitle;
        ClientSize = new Size(960, 560);
        StartPosition = FormStartPosition.Manual;
        Location = new Point(0, 0);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        DoubleBuffered = true;
        BackColor = Color.Black;

        if (_logPath != null)
            File.WriteAllText(_logPath, "utc_ms,step,cycle,style,speaker,text\n");

        _frameTimer.Tick += (_, _) => OnFrame();
        Shown += (_, _) =>
        {
            // Leave RST a moment to attach before the first line
            _stepEndsAt = _clock.ElapsedMilliseconds + 6000;
            _frameTimer.Start();
        };
    }

    private Step? Current => _index >= 0 && _index < _steps.Count ? _steps[_index] : null;

    private void OnFrame()
    {
        if (_clock.ElapsedMilliseconds >= _stepEndsAt)
        {
            _index++;
            if (_index >= _steps.Count)
            {
                _index = 0;
                _cycle++;
                if (_cycle >= _cycles)
                {
                    Log(-1, new Step(0, "end", "", ""));
                    Close();
                    return;
                }
            }
            var step = _steps[_index];
            if (step.Style == "title")
                _chapter = step.PlainText;
            _stepEndsAt = _clock.ElapsedMilliseconds + step.DurationMs;
            _stepStartedAt = _clock.ElapsedMilliseconds;
            // Paint now so the logged time is when the text is on screen
            Invalidate();
            Update();
            Log(_index, step);
            return;
        }
        // Lines typing out letter by letter need repainting too
        if (_animate || Program.Layout == "wuwa")
            Invalidate();
    }

    private void Log(int index, Step step)
    {
        if (_logPath == null)
            return;
        long ms = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        static string Q(string s) => "\"" + s.Replace("\"", "\"\"") + "\"";
        File.AppendAllText(_logPath, $"{ms},{index},{_cycle},{step.Style},{Q(step.Speaker)},{Q(step.PlainText)}\n");
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        DrawScene(g);
        if (Program.Layout == "wuwa")
        {
            WuwaScene.Draw(g, ClientRectangle, Current, _clock.ElapsedMilliseconds - _stepStartedAt);
            return;
        }

        var step = Current;
        // Chapter title, big and golden, at the top
        var title = Styles.All["title"];
        using (var titleFont = Styles.MakeFont(title))
        using (var shadow = new SolidBrush(Color.FromArgb(160, title.EffectColor!.Value)))
        using (var gold = new SolidBrush(title.Fill))
        {
            g.DrawString(_chapter, titleFont, shadow, 42, 32);
            g.DrawString(_chapter, titleFont, gold, 40, 30);
        }

        if (step == null)
            return;
        if (step.Style == "menu")
            DrawMenu(g, step);
        else if (step.Style == "banner")
            DrawBanner(g, step);
        else if (step.Style == "subtitle")
            DrawSubtitle(g, step);
        else if (step.Style == "hint")
            DrawHint(g, step);
        else if (step.Style == "hud")
            DrawHud(g, step);
        else if (step.Style == "gradient")
            DrawGradient(g, step);
        else if (step.Style == "centered")
            DrawCentered(g, step);
        else if (step.Style == "dialogue")
            DrawDialogue(g, step);
    }

    private void DrawScene(Graphics g)
    {
        var rect = ClientRectangle;
        using (var sky = new LinearGradientBrush(rect, Color.FromArgb(40, 60, 110), Color.FromArgb(220, 140, 90), LinearGradientMode.Vertical))
            g.FillRectangle(sky, rect);
        using (var sea = new SolidBrush(Color.FromArgb(30, 70, 100)))
            g.FillRectangle(sea, 0, 300, rect.Width, rect.Height - 300);

        // Drifting lights: the picture changes every frame, as in a real game
        double t = _animate ? _clock.ElapsedMilliseconds / 1000.0 : 0;
        for (int i = 0; i < 12; i++)
        {
            float x = (float)((i * 97 + t * (20 + i * 3)) % rect.Width);
            float y = (float)(110 + 40 * Math.Sin(t * 0.8 + i) + i * 12);
            using var light = new SolidBrush(Color.FromArgb(150, 255, 240, 200));
            g.FillEllipse(light, x, y, 6 + i % 4, 6 + i % 4);
        }
    }

    private void DrawDialogue(Graphics g, Step step)
    {
        var box = new Rectangle(30, 370, 900, 170);
        using (var fill = new SolidBrush(Color.FromArgb(235, 18, 24, 48)))
            g.FillRectangle(fill, box);
        using (var border = new Pen(Color.FromArgb(200, 170, 120), 3))
            g.DrawRectangle(border, box);

        var speaker = Styles.All["speaker"];
        using (var nameFont = Styles.MakeFont(speaker))
        using (var nameBrush = new SolidBrush(speaker.Fill))
            g.DrawString(step.Speaker, nameFont, nameBrush, box.X + 24, box.Y + 14);

        var dialogue = Styles.All["dialogue"];
        using var textFont = Styles.MakeFont(dialogue);
        DrawRichText(g, step.Text, textFont, dialogue.Fill, new RectangleF(box.X + 24, box.Y + 58, box.Width - 48, box.Height - 70));
    }

    // Big text in a condensed font (narrower letters than Arial at the same height), as game banners use
    private static void DrawBanner(Graphics g, Step step)
    {
        var spec = Styles.All["banner"];
        using var font = Styles.MakeFont(spec);
        using var shadow = new SolidBrush(Color.FromArgb(200, spec.EffectColor!.Value));
        using var fill = new SolidBrush(spec.Fill);
        g.DrawString(step.Text, font, shadow, 63, 203);
        g.DrawString(step.Text, font, fill, 60, 200);
    }

    // White subtitle with a black outline over the bright sky, as cutscene subtitles are drawn
    private static void DrawSubtitle(Graphics g, Step step)
    {
        var spec = Styles.All["subtitle"];
        using var path = new GraphicsPath();
        using var family = new FontFamily(spec.Font);
        path.AddString(step.Text, family, (int)FontStyle.Bold, spec.Px, new PointF(60, 250), StringFormat.GenericTypographic);
        using var outline = new Pen(spec.EffectColor!.Value, 5) { LineJoin = LineJoin.Round };
        using var fill = new SolidBrush(spec.Fill);
        g.DrawPath(outline, path);
        g.FillPath(fill, path);
    }

    // Pale hint text on a cream panel: low contrast, as greyed-out tips are
    private static void DrawHint(Graphics g, Step step)
    {
        var panel = new Rectangle(60, 230, 700, 50);
        using (var fill = new SolidBrush(Color.FromArgb(240, 232, 214)))
            g.FillRectangle(fill, panel);
        var spec = Styles.All["hint"];
        using var font = Styles.MakeFont(spec);
        using var brush = new SolidBrush(spec.Fill);
        g.DrawString(step.Text, font, brush, panel.X + 14, panel.Y + 10);
    }

    // HUD text in the bottom-right corner, touching the bottom edge of the window, as games show
    // level, coordinates or a clock there (reading pixels at that edge once crashed the overlay)
    private void DrawHud(Graphics g, Step step)
    {
        var spec = Styles.All["hud"];
        using var font = Styles.MakeFont(spec);
        using var brush = new SolidBrush(spec.Fill);
        SizeF size = g.MeasureString(step.Text, font);
        float x = ClientSize.Width - size.Width - 2, y = ClientSize.Height - size.Height + 2;
        g.DrawString(step.Text, font, brush, x, y);
    }

    // Big title with a vertical colour gradient (light gold at the top to orange at the bottom)
    private static void DrawGradient(Graphics g, Step step)
    {
        var spec = Styles.All["gradient"];
        using var font = Styles.MakeFont(spec);
        SizeF size = g.MeasureString(step.Text, font);
        var area = new RectangleF(60, 180, size.Width, size.Height);
        using var brush = new LinearGradientBrush(new RectangleF(area.X, area.Y + size.Height * 0.2f, area.Width, size.Height * 0.6f),
            spec.Fill, spec.GradientTo!.Value, LinearGradientMode.Vertical);
        g.DrawString(step.Text, font, brush, area.X, area.Y);
    }

    // Two centred lines (" / " separates them) with a soft dark shadow, as narration is shown
    private void DrawCentered(Graphics g, Step step)
    {
        var spec = Styles.All["centered"];
        using var font = Styles.MakeFont(spec);
        using var shadow = new SolidBrush(Color.FromArgb(170, spec.EffectColor!.Value));
        using var fill = new SolidBrush(spec.Fill);
        string[] lines = step.Text.Split(" / ");
        float y = 200;
        foreach (string line in lines)
        {
            SizeF size = g.MeasureString(line, font);
            float x = (ClientSize.Width - size.Width) / 2;
            g.DrawString(line, font, shadow, x + 2, y + 2);
            g.DrawString(line, font, fill, x, y);
            y += size.Height * 1.05f;
        }
    }

    private void DrawMenu(Graphics g, Step step)
    {
        // Menu entries separated by " / ", drawn as a small panel on the right in a smaller font
        string[] items = step.Text.Split(" / ");
        var panel = new Rectangle(660, 110, 270, 40 + items.Length * 34);
        using (var fill = new SolidBrush(Color.FromArgb(230, 245, 240, 225)))
            g.FillRectangle(fill, panel);
        var spec = Styles.All["menu"];
        using var font = Styles.MakeFont(spec);
        for (int i = 0; i < items.Length; i++)
            DrawRichText(g, items[i], font, spec.Fill, new RectangleF(panel.X + 20, panel.Y + 20 + i * 34, panel.Width - 30, 34));
    }

    // Word-wrapped text where {#RRGGBB:words} are drawn in that colour
    private static void DrawRichText(Graphics g, string markup, Font font, Color defaultColor, RectangleF area)
    {
        var tokens = new List<(string Word, Color Color)>();
        foreach (Match m in Regex.Matches(markup, @"\{#([0-9A-Fa-f]{6}):([^}]*)\}|([^{\s]+)"))
        {
            if (m.Groups[1].Success)
            {
                var color = ColorTranslator.FromHtml("#" + m.Groups[1].Value);
                foreach (string w in m.Groups[2].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    tokens.Add((w, color));
            }
            else
            {
                tokens.Add((m.Groups[3].Value, defaultColor));
            }
        }

        var format = StringFormat.GenericTypographic;
        float space = g.MeasureString(" ", font, PointF.Empty, StringFormat.GenericDefault).Width * 0.6f;
        float x = area.X, y = area.Y, lineHeight = font.GetHeight(g) * 1.15f;
        foreach (var (word, color) in tokens)
        {
            float width = g.MeasureString(word, font, PointF.Empty, format).Width;
            if (x > area.X && x + width > area.Right)
            {
                x = area.X;
                y += lineHeight;
            }
            using var brush = new SolidBrush(color);
            g.DrawString(word, font, brush, x, y, format);
            x += width + space;
        }
    }
}
