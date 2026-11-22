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

        // Minimap with a place name (top left), UID (bottom right): always there
        using (var map = new SolidBrush(Color.FromArgb(150, 10, 20, 30)))
            g.FillEllipse(map, 18, 18, 120, 120);
        var label = Styles.All["minimap"];
        using (var labelFont = Styles.MakeFont(label))
        using (var labelBrush = new SolidBrush(label.Fill))
            g.DrawString(MinimapLabel, labelFont, labelBrush, 30, 142);
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
