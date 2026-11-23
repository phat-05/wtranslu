using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Media;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Color = System.Windows.Media.Color;
using Cursors = System.Windows.Input.Cursors;
using Clipboard = System.Windows.Forms.Clipboard;
using Point = System.Windows.Point;
using Size = System.Windows.Size;
using FontFamily = System.Windows.Media.FontFamily;

namespace RSTGameTranslation
{
    public struct TranslationAreaInfo
    {
        public Rect Bounds { get; set; }
        public int ScreenIndex { get; set; }
        public double DpiScaleX { get; set; }
        public double DpiScaleY { get; set; }
        // Windows device name of the screen ("\\.\DISPLAY2"). Unlike the index it survives monitors
        // being plugged in or reordered; empty in areas saved by older versions.
        public string ScreenDevice { get; set; }

        public TranslationAreaInfo(Rect bounds, int screenIndex, double dpiScaleX, double dpiScaleY, string screenDevice = "")
        {
            Bounds = bounds;
            ScreenIndex = screenIndex;
            DpiScaleX = dpiScaleX;
            DpiScaleY = dpiScaleY;
            ScreenDevice = screenDevice;
        }
        
        public double X => Bounds.X;
        public double Y => Bounds.Y;
        public double Width => Bounds.Width;
        public double Height => Bounds.Height;
    }
    
    public class TextObject
    {
        // Properties
        public string Text { get; set; }
        public string ID { get; set; } = Guid.NewGuid().ToString();  // Initialize with a unique ID
        // The translation as shown in the chat box, history, clipboard: colour tags removed. A translation
        // with colour tags (see SetColorSpans) keeps them in TranslatedMarkup for the overlay.
        public string TextTranslated
        {
            get => _textTranslated;
            set
            {
                value ??= string.Empty;
                if (RSTGameTranslation.Layout.ColorMarkup.HasTags(value))
                {
                    TranslatedMarkup = value;
                    _textTranslated = RSTGameTranslation.Layout.ColorMarkup.Strip(value);
                }
                else
                {
                    _textTranslated = value;
                    // A translator that dropped (or never got) the tags: names and numbers kept word for
                    // word can still be coloured
                    string tagged = ColorSpans != null && value.Length > 0
                        ? RSTGameTranslation.Layout.ColorMarkup.TagVerbatim(value, ColorSpans)
                        : value;
                    TranslatedMarkup = tagged != value ? tagged : null;
                }
            }
        }
        private string _textTranslated = string.Empty;

        // Source text with colour tags around words the game drew in another colour (null = none)
        public string? TaggedText { get; private set; }
        public IReadOnlyList<RSTGameTranslation.Layout.ColorSpan>? ColorSpans { get; private set; }
        // Translation with colour tags, for colouring words on the overlay (null = one colour)
        public string? TranslatedMarkup { get; private set; }
        // What the cache keys on and what is sent to the translator: the tagged text when there is one
        public string CacheKey => TaggedText ?? Text;
        // What the cache stores: the tagged translation when there is one, so colours come back from it
        public string TranslationForCache => TranslatedMarkup ?? _textTranslated;

        public void SetColorSpans(string taggedText, IReadOnlyList<RSTGameTranslation.Layout.ColorSpan> spans)
        {
            TaggedText = taggedText;
            ColorSpans = spans;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public SolidColorBrush TextColor { get; set; }
        public SolidColorBrush BackgroundColor { get; set; }
        public UIElement? UIElement { get; set; }
        public TextBlock TextBlock { get; private set; } = null!;  // Will be initialized in CreateUIElement
        public Border Border { get; private set; } = new Border();  // Initialize with a new Border
        public System.Windows.FlowDirection FlowDirection { get; set; } = System.Windows.FlowDirection.LeftToRight;
        // Store the original capture position
        public double CaptureX { get; set; }
        public double CaptureY { get; set; }

        // Width the translation may wrap at; the overlay layout pass widens it into free space
        public double LayoutWidth { get; private set; }
        // Lowest font size allowed, as a fraction of the estimated source font size
        public double MinSourceSizeRatio { get; private set; } = DefaultMinSourceSizeRatio;
        // Whether the text fit the original box height at the chosen font size
        public bool TextFitsBox { get; private set; } = true;
        // The game's font size (DIPs) estimated from the OCR line heights; 0 = unknown, then it is
        // estimated from what fits in the box
        public double SourceFontSize { get; set; }
        // Lines the game text had: the translation may use as many lines of its own line height, even
        // when the OCR boxes (which hug the letters) are a little shorter than that
        public int SourceLineCount { get; set; } = 1;
        // How the game aligned this text: centred (lines sharing their middle) or right-aligned (sharing
        // their right edge, or against the right side of the screen). The translation keeps the same
        // middle or right edge. Set from the OCR lines of a block; the overlay layout pass may also set it.
        private TextAlignment _sourceAlignment = TextAlignment.Left;
        public TextAlignment SourceAlignment
        {
            get => _sourceAlignment;
            set
            {
                _sourceAlignment = value;
                if (TextBlock != null)
                    TextBlock.TextAlignment = value;
            }
        }
        public bool SourceCentered => _sourceAlignment == TextAlignment.Center;
        public bool SourceRightAligned => _sourceAlignment == TextAlignment.Right;

        // Feather width (DIPs) of the background edge when overlay colors are sampled automatically
        private const double SoftEdgeRadius = 6;
        // Glow around translated text drawn directly on the erased background
        private const double TextHaloRadius = 6;
        private System.Windows.Shapes.Rectangle? _softBackground;
        // The game's outline or drop shadow, drawn around the translation like the original (null = none)
        private RSTGameTranslation.Layout.TextStyle? _gameTextStyle;

        // The installed font that looks most like the game's (FontMatching), null = the usual font
        private string? _matchedFont;
        public string? MatchedFont
        {
            get => _matchedFont;
            set
            {
                _matchedFont = value;
                if (TextBlock != null)
                    TextBlock.FontFamily = ResolveFontFamily();
            }
        }

        // Horizontal scale of the text (below 1: condensed like the game's font, see FontMatching)
        public double MatchedScaleX { get; set; } = 1;

        private FontFamily ResolveFontFamily() =>
            _matchedFont != null ? FontMatching.Family(_matchedFont) : GameFonts.Resolve();

        public void SetTextEffect(RSTGameTranslation.Layout.TextStyle style)
        {
            _gameTextStyle = style;
            if (TextBlock != null)
                ApplyGameShape(TextBlock);
        }

        // Bold, italic and a vertical gradient fill like the game's letters (read from its pixels)
        private void ApplyGameShape(TextBlock textBlock)
        {
            var shape = _gameTextStyle?.Shape;
            textBlock.FontWeight = shape?.Bold == true ? FontWeights.Bold : FontWeights.Normal;
            textBlock.FontStyle = shape?.Italic == true ? FontStyles.Italic : FontStyles.Normal;
            if (shape?.GradientTop is RSTGameTranslation.Layout.Rgb top && shape.GradientBottom is RSTGameTranslation.Layout.Rgb bottom)
                textBlock.Foreground = LineGradient(top, bottom, textBlock.FontSize * LineHeightRatio);
        }

        // A gradient repeated on every line (a block of several lines is coloured line by line, as the
        // game colours each of its lines): top colour at the top of the letters, bottom colour at the bottom
        private static LinearGradientBrush LineGradient(RSTGameTranslation.Layout.Rgb top, RSTGameTranslation.Layout.Rgb bottom, double lineHeight)
        {
            var brush = new LinearGradientBrush
            {
                MappingMode = BrushMappingMode.Absolute,
                SpreadMethod = GradientSpreadMethod.Repeat,
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, Math.Max(1, lineHeight)),
            };
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(top.R, top.G, top.B), 0.15));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(bottom.R, bottom.G, bottom.B), 0.9));
            return brush;
        }

        // Fallback chain used when no language font override is set
        private const string DefaultFontFamily = "Arial, Noto Sans SC, Noto Sans JP, Noto Sans, Noto Sans KR, Noto Sans Devanagari, MS Gothic, Malgun Gothic, Yu Gothic, Microsoft YaHei, Arial Unicode MS";

        // Audio player for click sound
        private static SoundPlayer? _soundPlayer;

        // Constructor with default parameters
        public TextObject(
            string text = "New text added!",
            double x = 0,
            double y = 0,
            double width = 0,
            double height = 0,
            SolidColorBrush? textColor = null,
            SolidColorBrush? backgroundColor = null,
            double captureX = 0,
            double captureY = 0)
        {
            Text = text;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            TextColor = textColor ?? new SolidColorBrush(ConfigManager.Instance.GetOverlayTextColor());
            BackgroundColor = backgroundColor ?? new SolidColorBrush(ConfigManager.Instance.GetOverlayBackgroundColor()); // Half-transparent black
            CaptureX = captureX;
            CaptureY = captureY;

            // Initialize sound player if not already initialized
            _soundPlayer ??= new SoundPlayer();

            // Create the UI element that will be added to the overlay
            //UIElement = CreateUIElement();
        }

        // Create a UI element with the current properties
        // Public so it can be used by MonitorWindow
        public UIElement CreateUIElement(bool useRelativePosition = true)
        {
            // Create a border for the background
            Border = new Border()
            {
                Background = BackgroundColor,
                BorderThickness = new Thickness(0),
                CornerRadius = new CornerRadius(2),
                Padding = new Thickness(0, 0, 0, 0),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Cursor = Cursors.Hand  // Change cursor to hand to indicate clickable
            };
            
            // Position based on useRelativePosition parameter
            if (useRelativePosition)
            {
                // Use Margin for positioning in the parent container
                Border.Margin = new Thickness(X, Y, 0, 0);
            }
            if(ConfigManager.Instance.IsLanguageFontOverrideEnabled())
            {
                TextBlock = new TextBlock()
                {
                    Text = this.Text,
                    Foreground = this.TextColor,
                    FontWeight = FontWeights.Normal,
                    FontSize = 24, // Increased from 18 to 24 for better initial size
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Left, // Changed from Justify for better readability of merged blocks
                    FontStretch = FontStretches.Normal, // Changed from Expanded for better readability
                    FontFamily = ResolveFontFamily(),
                    Margin = new Thickness(0), // Increased margin for better text display
                    TextTrimming = TextTrimming.None
                };
            }
            else
            {
                // Create the text block with adjusted properties for better horizontal fill
                TextBlock = new TextBlock()
                {
                    Text = this.Text,
                    Foreground = this.TextColor,
                    FontWeight = FontWeights.Normal,
                    FontSize = 24, // Increased from 18 to 24 for better initial size
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Left, // Changed from Justify for better readability of merged blocks
                    FontStretch = FontStretches.Normal, // Changed from Expanded for better readability
                    FontFamily = ResolveFontFamily(),
                    Margin = new Thickness(0), // Increased margin for better text display
                    TextTrimming = TextTrimming.None
                };
            }
            

            ResetLayout();
            ApplyBoxConstraints();

            // Background layer under the text, so its edges can be feathered without blurring the text
            _softBackground = new System.Windows.Shapes.Rectangle
            {
                // Extend past the box by the blur radius so the box itself stays fully covered
                Margin = new Thickness(-SoftEdgeRadius),
                Effect = new System.Windows.Media.Effects.BlurEffect { Radius = SoftEdgeRadius },
                IsHitTestVisible = false
            };
            var layers = new Grid();
            layers.Children.Add(_softBackground);
            layers.Children.Add(CreateOutlineLayer());
            layers.Children.Add(TextBlock);
            Border.Child = layers;
            ApplyBackground();

            // Add click event handler
            // Border.MouseLeftButtonDown += Border_MouseLeftButtonDown;
            
            // Add context menu for right-click options
            // Border.ContextMenu = CreateContextMenu();

            // Scale font if needed after rendering
            Border.Loaded += (s, e) => AdjustFontSize(Border, TextBlock);

            return Border;
        }

        // Update the UI element with current properties
        public void UpdateUIElement()
        {
            // Check if we need to run on the UI thread
            if (!System.Windows.Application.Current.Dispatcher.CheckAccess())
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() => UpdateUIElement());
                return;
            }

            //if TextBox is null, create a new one
            if (TextBlock == null)
            {
                CreateUIElement();
            }


            if (TextBlock != null && Border != null)
            {
                if (this.TextTranslated != null && this.TextTranslated.Length > 0)
                {
                    // Use translated text if available; tagged words in the colours the game used
                    if (TranslatedMarkup != null && ColorSpans != null)
                        SetColouredText(TextBlock, TranslatedMarkup, ColorSpans, Shown);
                    else
                        TextBlock.Text = Shown(this.TextTranslated);
                    SyncOutlineText();
                    TextBlock.FlowDirection = FlowDirection;
                }
                // else
                // {
                //     // Use original text
                //     TextBlock.Text = this.Text;
                // }
                TextBlock.Foreground = this.TextColor;
                TextBlock.TextAlignment = _sourceAlignment;
                ApplyGameShape(TextBlock);
                ApplyBackground();
                // The overlay positions borders with Canvas.Left/Top; a margin would add the offset twice
                Border.Margin = new Thickness(0);
                Canvas.SetLeft(Border, X);
                Canvas.SetTop(Border, Y);

                // New text: start again from the original box; the overlay layout pass re-widens if needed
                ResetLayout();
                ApplyBoxConstraints();
                // The current game's font, else the language override, else the default chain
                TextBlock.FontFamily = ResolveFontFamily();

                // Reset font size to default and then adjust if needed
                TextBlock.FontSize = 24; // Increased from 18 to 24 for better initial size
                AdjustFontSize(Border, TextBlock);
            }
        }

        // Original background with the source text removed, placed on the overlay under all translations
        public System.Windows.Controls.Image? EraserElement { get; private set; }
        private Vector _eraserOffset;

        public void SetErasedBackground(ImageSource patch, Rect bounds)
        {
            EraserElement = new System.Windows.Controls.Image
            {
                Source = patch,
                Width = bounds.Width,
                Height = bounds.Height,
                Stretch = Stretch.Fill,
                IsHitTestVisible = false
            };
            // Relative to the text position, so it follows when text objects are shifted
            _eraserOffset = new Vector(bounds.X - X, bounds.Y - Y);
        }

        // The eraser stays over the original text even when the translation box is moved by the layout pass
        public void PositionEraser()
        {
            if (EraserElement == null)
                return;
            Canvas.SetLeft(EraserElement, X + _eraserOffset.X);
            Canvas.SetTop(EraserElement, Y + _eraserOffset.Y);
        }

        // With the original text erased, the translation needs no box: only a halo in the background
        // color keeps it legible over busy art. Otherwise sampled colors get soft edges, and a
        // user-chosen color keeps a crisp box.
        private void ApplyBackground()
        {
            bool erased = EraserElement != null;
            bool soft = !erased && _softBackground != null && ConfigManager.Instance.IsAutoSetOverlayBackground();
            Border.Background = erased || soft ? null : BackgroundColor;
            if (_softBackground != null)
            {
                _softBackground.Fill = BackgroundColor;
                _softBackground.Visibility = soft ? Visibility.Visible : Visibility.Collapsed;
            }

            ShowOutline(_gameTextStyle?.Effect == RSTGameTranslation.Layout.TextEffectKind.Outline
                ? System.Windows.Media.Color.FromRgb(_gameTextStyle.EffectColor.R, _gameTextStyle.EffectColor.G, _gameTextStyle.EffectColor.B)
                : null);
            var gameEffect = GameTextEffect();
            TextBlock.Effect = gameEffect != null
                ? gameEffect
                : erased
                ? new System.Windows.Media.Effects.DropShadowEffect
                {
                    Color = BackgroundColor.Color,
                    ShadowDepth = 0,
                    BlurRadius = TextHaloRadius,
                    Opacity = 1
                }
                : null;
        }

        // The game text's outline (a thin glow of the outline colour all around) or drop shadow (an
        // offset copy in the shadow colour); WPF text has no stroke, a tight blur-free shadow reads alike
        private System.Windows.Media.Effects.Effect? GameTextEffect()
        {
            var style = _gameTextStyle;
            if (style == null)
                return null;
            var color = System.Windows.Media.Color.FromRgb(style.EffectColor.R, style.EffectColor.G, style.EffectColor.B);
            switch (style.Effect)
            {
                case RSTGameTranslation.Layout.TextEffectKind.Outline:
                    // Drawn by the outline layer (copies of the text around it), not as an effect
                    return null;
                case RSTGameTranslation.Layout.TextEffectKind.Shadow:
                    double depth = Math.Sqrt(style.ShadowDx * style.ShadowDx + style.ShadowDy * style.ShadowDy);
                    // WPF measures the direction counter-clockwise from "right"; screen y grows downward
                    double direction = Math.Atan2(-style.ShadowDy, style.ShadowDx) * 180 / Math.PI;
                    return new System.Windows.Media.Effects.DropShadowEffect
                    {
                        Color = color,
                        ShadowDepth = Math.Max(1, depth),
                        Direction = (direction + 360) % 360,
                        BlurRadius = 1,
                        Opacity = 1
                    };
                default:
                    return null;
            }
        }

        // ---- Outline: WPF text has no stroke, so the text is drawn 8 times in the outline colour, shifted
        // around the real text, under it. The copies follow the real text's size and wrapping by binding.
        private Grid? _outlineLayer;
        // Default outline thickness (DIPs) when the game's is unknown or the outline was added for contrast
        private const double OutlineWidth = 1.5;

        private Grid CreateOutlineLayer()
        {
            _outlineLayer = new Grid { IsHitTestVisible = false, Visibility = Visibility.Collapsed };
            for (int i = 0; i < 8; i++)
            {
                double angle = i * Math.PI / 4;
                var copy = new TextBlock
                {
                    RenderTransform = new TranslateTransform(Math.Round(Math.Cos(angle) * OutlineWidth, 2), Math.Round(Math.Sin(angle) * OutlineWidth, 2))
                };
                foreach (var property in new DependencyProperty[]
                {
                    TextBlock.FontSizeProperty, TextBlock.FontFamilyProperty, TextBlock.FontWeightProperty,
                    TextBlock.FontStyleProperty, TextBlock.FontStretchProperty, TextBlock.LineHeightProperty,
                    TextBlock.LineStackingStrategyProperty, TextBlock.TextWrappingProperty, TextBlock.TextAlignmentProperty,
                    FrameworkElement.MaxWidthProperty, FrameworkElement.WidthProperty, FrameworkElement.MarginProperty,
                    FrameworkElement.FlowDirectionProperty, FrameworkElement.VerticalAlignmentProperty,
                    FrameworkElement.HorizontalAlignmentProperty, TextBlock.PaddingProperty,
                    FrameworkElement.LayoutTransformProperty
                })
                {
                    copy.SetBinding(property, new System.Windows.Data.Binding(property.Name) { Source = TextBlock, Mode = System.Windows.Data.BindingMode.OneWay });
                }
                _outlineLayer.Children.Add(copy);
            }
            return _outlineLayer;
        }

        private void SyncOutlineText()
        {
            if (_outlineLayer == null)
                return;
            string text = TextTranslated.Length > 0 ? Shown(TextTranslated) : TextBlock?.Text ?? "";
            foreach (TextBlock copy in _outlineLayer.Children)
                copy.Text = text;
        }

        private void ShowOutline(System.Windows.Media.Color? color)
        {
            if (_outlineLayer == null)
                return;
            if (color == null)
            {
                _outlineLayer.Visibility = Visibility.Collapsed;
                return;
            }
            var brush = new SolidColorBrush(color.Value);
            // As thick as the game's outline, within reason. The measure counts the outline's smoothed
            // edge and its rounded corners too: a 2 px outline measures about 3
            double width = _gameTextStyle is { OutlineWidth: > 0, EffectAdded: false } style
                ? Math.Clamp(style.OutlineWidth * 0.65, 1, 4)
                : OutlineWidth;
            int n = 0;
            foreach (TextBlock copy in _outlineLayer.Children)
            {
                copy.Foreground = brush;
                double angle = n++ * Math.PI / 4;
                copy.RenderTransform = new TranslateTransform(Math.Round(Math.Cos(angle) * width, 2), Math.Round(Math.Sin(angle) * width, 2));
            }
            SyncOutlineText();
            _outlineLayer.Visibility = Visibility.Visible;
        }

        private void ResetLayout()
        {
            LayoutWidth = Width;
            MinSourceSizeRatio = DefaultMinSourceSizeRatio;
        }

        private void ApplyBoxConstraints()
        {
            if (Width > 0)
            {
                // Cover at least the original text; wrap at the (possibly widened) layout width
                Border.MinWidth = Width;
                Border.MaxWidth = LayoutWidth + 20;
                // In the text's own (unscaled) units: a condensed text fits more per line
                TextBlock.MaxWidth = LayoutWidth / Math.Clamp(MatchedScaleX, 0.5, 1);
            }

            if (Height > 0)
            {
                // Set MinHeight to ensure background covers original area
                Border.MinHeight = Height;
                // Allow Border to grow taller if text wraps to multiple lines
                Border.MaxHeight = double.PositiveInfinity;
            }
        }

        // Re-fit the text with a wider wrap width and/or a lower minimum font size (used by the overlay layout pass)
        public void Relayout(double layoutWidth, double minSourceSizeRatio)
        {
            if (TextBlock == null) return;
            LayoutWidth = Math.Max(Width, layoutWidth);
            MinSourceSizeRatio = minSourceSizeRatio;
            ApplyBoxConstraints();
            AdjustFontSize(Border, TextBlock);
        }

        // Pieces of the translation as runs: tagged pieces in their span's colour, the rest in the text colour
        // The translation as shown: in capitals when the game wrote its text in capitals
        private string Shown(string translation) =>
            ConfigManager.Instance.IsTextStyleFromGameEnabled() ? RSTGameTranslation.Layout.TextCase.Match(Text, translation) : translation;

        private static void SetColouredText(TextBlock textBlock, string markup, IReadOnlyList<RSTGameTranslation.Layout.ColorSpan> spans,
                                            Func<string, string> shown)
        {
            textBlock.Inlines.Clear();
            foreach (var (piece, span) in RSTGameTranslation.Layout.ColorMarkup.Parse(markup))
            {
                var run = new System.Windows.Documents.Run(shown(piece));
                var colour = span == null ? null : spans.FirstOrDefault(s => s.Number == span.Value);
                if (colour != null)
                    run.Foreground = new SolidColorBrush(Color.FromRgb(colour.Color.R, colour.Color.G, colour.Color.B));
                textBlock.Inlines.Add(run);
            }
        }

        // "#RRGGBB" for a plain colour, "#top>#bottom" for a vertical gradient (for measurements)
        private static string DescribeBrush(System.Windows.Media.Brush? brush) => brush switch
        {
            SolidColorBrush solid => $"#{solid.Color.R:X2}{solid.Color.G:X2}{solid.Color.B:X2}",
            LinearGradientBrush gradient when gradient.GradientStops.Count >= 2 =>
                $"#{gradient.GradientStops[0].Color.R:X2}{gradient.GradientStops[0].Color.G:X2}{gradient.GradientStops[0].Color.B:X2}>" +
                $"#{gradient.GradientStops[^1].Color.R:X2}{gradient.GradientStops[^1].Color.G:X2}{gradient.GradientStops[^1].Color.B:X2}",
            _ => "?"
        };

        // Static cache for font size calculations
        private static readonly Dictionary<string, (double Size, bool Fits)> _fontSizeCache = new Dictionary<string, (double Size, bool Fits)>();
        public static void ClearCache()
        {
            _fontSizeCache.Clear();
        }
        
        // Line spacing as a multiple of font size; WPF's default (~1.3x) wastes space in small boxes
        private const double LineHeightRatio = 1.15;
        // The translation may shrink to this fraction of the estimated source font size, no smaller
        public const double DefaultMinSourceSizeRatio = 0.6;
        // With the game's font size known, the overlay first tries to keep at least this share of it,
        // widening into free space, before shrinking down to DefaultMinSourceSizeRatio
        public const double PreferredMinSourceSizeRatio = 0.85;
        // A short label (a button, a menu entry, an icon's name) sits among others: its translation
        // gets smaller rather than run over its neighbours
        public const double LabelMinSourceSizeRatio = 0.55;
        public const double LabelMaxWidening = 1.15;

        /// <summary>
        /// A short label: at most 4 words and 32 characters on one or two lines, and not a sentence
        /// (a short line of dialogue ends with . ! ? or holds a comma: it may still widen).
        /// </summary>
        public bool IsShortLabel =>
            SourceLineCount <= 2 && Text.Length <= 32 &&
            Text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length <= 4 &&
            Text.IndexOfAny(new[] { ',', '，', '、' }) < 0 &&
            Text.TrimEnd() is { Length: > 0 } trimmed && !".!?…。！？\"'”’".Contains(trimmed[^1]);

        private void ApplyFontSize(TextBlock textBlock, double fontSize)
        {
            textBlock.FontSize = fontSize;
            textBlock.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
            textBlock.LineHeight = fontSize * LineHeightRatio;
            // Squeezed like a condensed game font; layout (wrapping, fitting) follows the transform
            textBlock.LayoutTransform = MatchedScaleX < 0.99 ? new ScaleTransform(MatchedScaleX, 1) : Transform.Identity;
            // A per-line gradient follows the line height
            if (textBlock.Foreground is LinearGradientBrush { MappingMode: BrushMappingMode.Absolute, IsFrozen: false } gradient)
                gradient.EndPoint = new Point(0, Math.Max(1, fontSize * LineHeightRatio));
        }

        // Whether the text, wrapped at the box width, fits inside the box at this font size
        private bool FitsAt(TextBlock textBlock, double fontSize)
        {
            ApplyFontSize(textBlock, fontSize);
            textBlock.Measure(new Size(LayoutWidth, double.PositiveInfinity));
            double allowedHeight = SourceFontSize > 0
                ? Math.Max(Height, SourceLineCount * fontSize * LineHeightRatio + 0.5)
                : Height;
            return textBlock.DesiredSize.Height <= allowedHeight && textBlock.DesiredSize.Width <= LayoutWidth;
        }

        // Binary search for the largest font size in [minSize, maxSize] that fits; minSize if none does
        private double FindLargestFittingSize(TextBlock textBlock, double minSize, double maxSize)
        {
            if (FitsAt(textBlock, maxSize)) return maxSize;
            if (!FitsAt(textBlock, minSize)) return minSize;

            double fits = minSize, tooBig = maxSize;
            while (tooBig - fits > 0.5)
            {
                double mid = (fits + tooBig) / 2;
                if (FitsAt(textBlock, mid)) fits = mid;
                else tooBig = mid;
            }
            return fits;
        }

        // Size the text to fill the original text box, staying close to the game's own font size
        private void AdjustFontSize(Border border, TextBlock textBlock)
        {
            try
            {
                // Check if auto sizing is enabled
                if (!ConfigManager.Instance.IsAutoSizeTextBlocksEnabled())
                {
                    // Fixed font size; still report whether it fits so the layout pass can widen the box
                    TextFitsBox = Width <= 0 || Height <= 0 || FitsAt(textBlock, 24);
                    ApplyFontSize(textBlock, 24);
                    return;
                }
                
                // Exit early if dimensions aren't set or text is empty
                if (Width <= 0 || Height <= 0 || string.IsNullOrWhiteSpace(textBlock.Text))
                {
                    TextFitsBox = true;
                    ApplyFontSize(textBlock, 24);
                    return;
                }

                double configMin = ConfigManager.Instance.GetLanguageFontSizeMin();
                double configMax = ConfigManager.Instance.GetLanguageFontSizeMax();
                if (configMin > configMax) (configMin, configMax) = (configMax, configMin);

                // Same length doesn't mean same rendered size, so key on the actual text and font
                // With coloured words the text is in Inlines and TextBlock.Text still holds the old string
                string shownText = TranslatedMarkup ?? textBlock.Text;
                string cacheKey = $"{textBlock.FontFamily.Source}_{textBlock.FontWeight}_{textBlock.FontStyle}_{MatchedScaleX:F2}_{Width}_{LayoutWidth}_{Height}_{MinSourceSizeRatio}_{configMin}_{configMax}_{SourceFontSize}_{Text}_{shownText}";
                
                // Check cache
                if (_fontSizeCache.TryGetValue(cacheKey, out var cached))
                {
                    TextFitsBox = cached.Fits;
                    ApplyFontSize(textBlock, cached.Size);
                    return;
                }

                // The game's font size: from the height of its lines when known (independent of the
                // font's width), otherwise the largest size at which the source text fills its own box
                double sourceSize;
                if (SourceFontSize > 0)
                {
                    sourceSize = Math.Min(SourceFontSize, configMax);
                }
                else
                {
                    var sourceProbe = new TextBlock
                    {
                        Text = Text,
                        FontFamily = textBlock.FontFamily,
                        FontWeight = textBlock.FontWeight,
                        TextWrapping = TextWrapping.Wrap
                    };
                    // The source filled the original box, so measure it at the original width
                    double layoutWidth = LayoutWidth;
                    LayoutWidth = Width;
                    sourceSize = FindLargestFittingSize(sourceProbe, 1, configMax);
                    LayoutWidth = layoutWidth;
                }

                // Keep the translation readable relative to the source and no larger than it
                double minSize = Math.Min(configMax, Math.Max(configMin, sourceSize * MinSourceSizeRatio));
                double maxSize = Math.Max(minSize, Math.Min(configMax, sourceSize));

                // If even minSize overflows, the border grows downward (MinHeight + infinite MaxHeight)
                double finalSize = FindLargestFittingSize(textBlock, minSize, maxSize);
                TextFitsBox = FitsAt(textBlock, finalSize);
                textBlock.VerticalAlignment = VerticalAlignment.Stretch;
                ApplyFontSize(textBlock, finalSize);
                if (OcrTiming.Metrics.Enabled)
                {
                    OcrTiming.Metrics.Write("font_size", $"{finalSize:F1}|{sourceSize:F1}|{(SourceFontSize > 0 ? "lines" : "fit")}|{Text}|{shownText}|{textBlock.FontFamily.Source.Split(',')[0]}{(MatchedScaleX < 0.99 ? $" Condensed {MatchedScaleX:F2}" : "")}" +
                        $"|{textBlock.FontWeight}|{textBlock.FontStyle}|{DescribeBrush(textBlock.Foreground)}|{_gameTextStyle?.Effect.ToString() ?? "None"}|{textBlock.TextAlignment}" +
                        $"|{(TextFitsBox ? "fits" : "overflows")}|{Width:F0}");
                }
                
                // Cache result
                if (_fontSizeCache.Count > 100) _fontSizeCache.Clear();
                _fontSizeCache[cacheKey] = (finalSize, TextFitsBox);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AdjustFontSize: {ex.Message}");
                TextFitsBox = true;
                ApplyFontSize(textBlock, 24);
            }
        }

        // Handle click event
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                // Copy text to clipboard
                Clipboard.SetText(Text);

                // Play sound
                PlayClickSound();

                // Animate the border to provide visual feedback
                AnimateBorderOnClick(border);

                e.Handled = true;
            }
        }

        // Play a sound when clicked
        private void PlayClickSound()
        {
            // Set the sound file path
            string soundFile = "audio\\clipboard.wav";

            // Check if file exists
            if (System.IO.File.Exists(soundFile))
            {
                _soundPlayer!.SoundLocation = soundFile;
                _soundPlayer.Play();
            }
        }

        // Store original background color for each border to ensure we restore properly
        private static readonly ConditionalWeakTable<Border, SolidColorBrush> _originalBackgrounds = 
            new ConditionalWeakTable<Border, SolidColorBrush>();
            
        // Create the context menu with Copy Source, Copy Translated, Speak Source, and Learn Source options
        private ContextMenu CreateContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();
            
            // Copy Source menu item
            MenuItem copySourceMenuItem = new MenuItem();
            copySourceMenuItem.Header = "Copy Source";
            copySourceMenuItem.Click += CopySourceMenuItem_Click;
            contextMenu.Items.Add(copySourceMenuItem);
            
            // Copy Translated menu item
            MenuItem copyTranslatedMenuItem = new MenuItem();
            copyTranslatedMenuItem.Header = "Copy Translated";
            copyTranslatedMenuItem.Click += CopyTranslatedMenuItem_Click;
            contextMenu.Items.Add(copyTranslatedMenuItem);
            
            // Add a separator
            contextMenu.Items.Add(new Separator());
            
            // Learn Source menu item
            MenuItem learnSourceMenuItem = new MenuItem();
            learnSourceMenuItem.Header = "Learn Source";
            learnSourceMenuItem.Click += LearnSourceMenuItem_Click;
            contextMenu.Items.Add(learnSourceMenuItem);
            
            // Speak Source menu item
            MenuItem speakSourceMenuItem = new MenuItem();
            speakSourceMenuItem.Header = "Speak Source";
            speakSourceMenuItem.Click += SpeakSourceMenuItem_Click;
            contextMenu.Items.Add(speakSourceMenuItem);
            
            // Update menu item states when context menu is opened
            contextMenu.Opened += (s, e) => {
                copyTranslatedMenuItem.IsEnabled = !string.IsNullOrEmpty(this.TextTranslated);
            };
            
            return contextMenu;
        }
        
        // Click handler for Copy Source menu item
        private void CopySourceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(this.Text);
            PlayClickSound();
        }
        
        // Click handler for Copy Translated menu item
        private void CopyTranslatedMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextTranslated))
            {
                Clipboard.SetText(this.TextTranslated);
                PlayClickSound();
            }
        }
        
        // Click handler for Learn Source menu item
        private void LearnSourceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.Text))
                {
                    // Construct the ChatGPT URL with the selected text and instructions
                    string chatGptPrompt = $"Create a lesson to help me learn about this text and its translation: {this.Text}";
                    string encodedPrompt = System.Web.HttpUtility.UrlEncode(chatGptPrompt);
                    string chatGptUrl = $"https://chat.openai.com/?q={encodedPrompt}";
                    
                    // Open in default browser
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = chatGptUrl,
                        UseShellExecute = true
                    });
                    
                    Console.WriteLine($"Opening ChatGPT with text: {this.Text.Substring(0, Math.Min(50, this.Text.Length))}...");
                }
                else
                {
                    Console.WriteLine("No text available for Learn function");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Learn function: {ex.Message}");
            }
        }
        
        // Click handler for Speak Source menu item
        private async void SpeakSourceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.Text))
                {
                    string text = this.Text.Trim();
                    Console.WriteLine($"Speak function called with text: {text.Substring(0, Math.Min(50, text.Length))}...");
                    
                    // Check if TTS is enabled in config
                    if (ConfigManager.Instance.IsTtsEnabled())
                    {
                        string ttsService = ConfigManager.Instance.GetTtsService();
                        
                        try
                        {
                            bool success = false;
                            
                            if (ttsService == "ElevenLabs")
                            {
                                success = await ElevenLabsService.Instance.SpeakText(text);
                            }
                            else if (ttsService == "Google Cloud TTS")
                            {
                                success = await GoogleTTSService.Instance.SpeakText(text);
                            }
                            else if (ttsService == "Windows TTS")
                            {
                                success = await WindowsTTSService.Instance.SpeakText(text);
                            }
                            else if (ttsService == "Supertonic")
                            {
                                success = await SupertonicTTSService.Instance.SpeakText(text);
                            }
                            else
                            {
                                System.Windows.MessageBox.Show($"Text-to-Speech service '{ttsService}' is not supported yet.",
                                    "Unsupported Service", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }

                            if (!success)
                            {
                                System.Windows.MessageBox.Show($"Failed to generate speech using {ttsService}. Please check the API key and settings.",
                                    "Text-to-Speech Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"TTS error: {ex.Message}");
                            System.Windows.MessageBox.Show($"Text-to-Speech error: {ex.Message}", 
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Text-to-Speech is disabled in settings. Please enable it first.",
                            "TTS Disabled", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    Console.WriteLine("No text available for Speak function");
                    System.Windows.MessageBox.Show("No text available to speak.",
                        "No Text Available", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Speak function: {ex.Message}");
                System.Windows.MessageBox.Show($"Error: {ex.Message}", "Text-to-Speech Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        // Animate the border when clicked
        private void AnimateBorderOnClick(Border border)
        {
            try
            {
                // Get or store the original background color
                if (!_originalBackgrounds.TryGetValue(border, out SolidColorBrush? originalBrush))
                {
                    // Only store the original background on first click
                    originalBrush = border.Background.Clone() as SolidColorBrush;
                    if (originalBrush != null)
                    {
                        // Freeze it to ensure it doesn't change
                        originalBrush.Freeze();
                        _originalBackgrounds.Add(border, originalBrush);
                    }
                }

                // Get the color to return to (use stored value, not current which might be mid-animation)
                Color targetColor = originalBrush?.Color ?? ((SolidColorBrush)border.Background).Color;
                
                // Create a new transform for this animation
                var scaleTransform = new ScaleTransform(1.0, 1.0);
                border.RenderTransform = scaleTransform;
                border.RenderTransformOrigin = new Point(0.5, 0.5);

                // Create background color animation with proper completion action
                ColorAnimation colorAnimation = new ColorAnimation()
                {
                    From = Colors.Yellow,
                    To = targetColor,
                    Duration = TimeSpan.FromSeconds(0.3),
                    // Important: Ensure animation completes and doesn't get stuck
                    FillBehavior = FillBehavior.Stop
                };

                // Create scale animation
                DoubleAnimation scaleAnimation = new DoubleAnimation()
                {
                    From = 1.1,
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(0.2),
                    FillBehavior = FillBehavior.Stop
                };

                // Create a new brush for the animation
                SolidColorBrush animationBrush = new SolidColorBrush(Colors.Yellow);
                
                // When the color animation completes, reset to original background
                colorAnimation.Completed += (s, e) => 
                {
                    border.Background = originalBrush?.Clone() ?? new SolidColorBrush(targetColor);
                };

                // Start animations
                border.Background = animationBrush;
                animationBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
                scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Animation error: {ex.Message}");
                // In case of error, try to restore the original background
                if (_originalBackgrounds.TryGetValue(border, out SolidColorBrush? originalBrush) && originalBrush != null)
                {
                    border.Background = originalBrush.Clone();
                }
            }
        }
    }
}