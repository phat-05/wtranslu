using System.Drawing.Drawing2D;

namespace MockGame;

/// <summary>
/// A screen laid out like Wuthering Waves, to test the app's Wuthering Waves preset: the speaker's
/// name and the line centred at the bottom over a dark band, the line typing out letter by letter;
/// answer choices stacked on the right; the player's UID in the bottom-right corner and a place
/// name on the minimap at the top left, both always on screen (and not to be translated in
/// dialogue mode). Proportions follow the game at 16:9.
/// </summary>
internal static class WuwaScene
{
    public const string Uid = "UID: 801234567";
    public const string MinimapLabel = "Jinzhou City";
    private const int TypeOutMsPerChar = 18;

    public static void Draw(Graphics g, Rectangle client, Step? step, long msIntoStep)
    {
        int w = client.Width, h = client.Height;

        // Minimap with a place name (top left; not in menus), UID (bottom right): always there
        if (step?.Style != "wuwa_menu")
        {
            using (var map = new SolidBrush(Color.FromArgb(150, 10, 20, 30)))
                g.FillEllipse(map, 18, 18, 120, 120);
            var label = Styles.All["minimap"];
            using (var labelFont = Styles.MakeFont(label))
            using (var labelBrush = new SolidBrush(label.Fill))
                g.DrawString(MinimapLabel, labelFont, labelBrush, 30, 142);
        }
        var uid = Styles.All["uid"];
        using (var uidFont = Styles.MakeFont(uid))
        using (var uidBrush = new SolidBrush(uid.Fill))
        {
            SizeF size = g.MeasureString(Uid, uidFont);
            g.DrawString(Uid, uidFont, uidBrush, w - size.Width - 10, h - size.Height - 3);
        }

        if (step == null)
            return;
        if (step.Style == "wuwa")
            DrawDialogue(g, w, h, step, msIntoStep);
        else if (step.Style == "wuwa_choices")
            DrawChoices(g, w, h, step);
        else if (step.Style == "wuwa_menu")
            DrawMenu(g, w, h, step);
    }

    /// <summary>
    /// The Terminal menu: a grid of icons with their names (the step's text, " / " between them),
    /// and on the left the player's level and the day's activities with Go / Claim buttons, numbers
    /// on their own (46, 3175/12000), as in the game.
    /// </summary>
    private static void DrawMenu(Graphics g, int w, int h, Step step)
    {
        using (var dim = new SolidBrush(Color.FromArgb(215, 12, 14, 20)))
            g.FillRectangle(dim, 0, 0, w, h);
        var header = Styles.All["wuwa_menu_header"];
        var label = Styles.All["wuwa_menu_label"];
        using var headerFont = Styles.MakeFont(header);
        using var labelFont = Styles.MakeFont(label);
        using var headerBrush = new SolidBrush(header.Fill);
        using var labelBrush = new SolidBrush(label.Fill);
        using var dimText = new SolidBrush(Color.FromArgb(0xA8, 0xA8, 0xA8));
        using var icon = new SolidBrush(Color.FromArgb(255, 48, 52, 62));
        using var gold = new SolidBrush(Color.FromArgb(0xE8, 0xC7, 0x7A));
        using var button = new SolidBrush(Color.FromArgb(255, 0xD9, 0xC0, 0x7E));
        using var buttonText = new SolidBrush(Color.FromArgb(0x20, 0x1C, 0x14));

        g.DrawString("Terminal", headerFont, headerBrush, w * 0.03f, h * 0.04f);

        // Left: the player's level and the day's activities
        float x = w * 0.04f, y = h * 0.17f;
        g.DrawString("Union Level", labelFont, dimText, x, y);
        g.DrawString("46", headerFont, gold, x + 150, y - 6);
        y += 34;
        g.DrawString("Union EXP", labelFont, dimText, x, y);
        g.DrawString("3175/12000", labelFont, labelBrush, x + 150, y);
        y += 52;
        g.DrawString("Resets after 11h 59m", labelFont, dimText, x, y);
        y += 36;
        foreach (var (task, action) in new[] { ("Log in to the game", "Claim"), ("Complete 1 Daily Quest", "Go") })
        {
            g.DrawString(task, labelFont, labelBrush, x, y + 6);
            g.FillRectangle(button, x + 236, y, 68, 30);
            var centre = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString(action, labelFont, buttonText, new RectangleF(x + 236, y + 6, 68, 24), centre);
            y += 46;
        }

        // Right: the menu's icons, four to a row, each name centred under its icon
        string[] names = step.Text.Split(" / ");
        float gridX = w * 0.40f, gridY = h * 0.16f, cellW = w * 0.14f, cellH = h * 0.25f;
        var middle = new StringFormat { Alignment = StringAlignment.Center };
        for (int i = 0; i < names.Length; i++)
        {
            float cx = gridX + i % 4 * cellW, cy = gridY + i / 4 * cellH;
            g.FillRectangle(icon, cx + (cellW - 56) / 2, cy, 56, 56);
            // A long name wraps onto a second line under its icon, as in the game
            g.DrawString(names[i], labelFont, labelBrush, new RectangleF(cx + 6, cy + 66, cellW - 12, 44), middle);
        }
    }

    private static void DrawDialogue(Graphics g, int w, int h, Step step, long msIntoStep)
    {
        // Dark band fading in from above
        var band = new Rectangle(0, (int)(h * 0.70), w, (int)(h * 0.30));
        using (var fade = new LinearGradientBrush(band, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(190, 0, 0, 0), LinearGradientMode.Vertical))
            g.FillRectangle(fade, band);

        var center = new StringFormat { Alignment = StringAlignment.Center };
        var speaker = Styles.All["wuwa_speaker"];
        using (var nameFont = Styles.MakeFont(speaker))
        using (var nameBrush = new SolidBrush(speaker.Fill))
            g.DrawString(step.Speaker, nameFont, nameBrush, new RectangleF(0, h * 0.755f, w, 40), center);

        // The line types out letter by letter
        string text = step.PlainText;
        int shown = (int)Math.Min(text.Length, msIntoStep / TypeOutMsPerChar);
        var dialogue = Styles.All["wuwa_dialogue"];
        using var textFont = Styles.MakeFont(dialogue);
        using var shadow = new SolidBrush(Color.FromArgb(150, 0, 0, 0));
        using var fill = new SolidBrush(dialogue.Fill);
        var area = new RectangleF(w * 0.16f, h * 0.815f, w * 0.68f, h * 0.14f);
        g.DrawString(text[..shown], textFont, shadow, new RectangleF(area.X + 1, area.Y + 1, area.Width, area.Height), center);
        g.DrawString(text[..shown], textFont, fill, area, center);
    }

    private static void DrawChoices(Graphics g, int w, int h, Step step)
    {
        var spec = Styles.All["wuwa_choice"];
        using var font = Styles.MakeFont(spec);
        using var fill = new SolidBrush(spec.Fill);
        using var box = new SolidBrush(Color.FromArgb(170, 15, 15, 20));
        using var edge = new Pen(Color.FromArgb(120, 230, 210, 160), 1);
        float x = w * 0.62f, y = h * 0.42f, bw = w * 0.30f, bh = 36;
        foreach (string choice in step.Text.Split(" / "))
        {
            g.FillRectangle(box, x, y, bw, bh);
            g.DrawRectangle(edge, x, y, bw, bh);
            g.DrawString(choice, font, fill, x + 14, y + 8);
            y += bh + 10;
        }
    }
}
