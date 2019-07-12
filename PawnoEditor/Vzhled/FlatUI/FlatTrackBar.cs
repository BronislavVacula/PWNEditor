using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    [DefaultEvent("Scroll")]
    public class FlatTrackBar : Control
    {
        private bool Bool;

        public Enums.FlatTrackBarStyle Style { get; set; } = Enums.FlatTrackBarStyle.Knob;

        #region Colors

        [Category("Colors")]
        public Color TrackColor { get; set; } = Helpers.FlatColors.Instance().Flat;

        [Category("Colors")]
        public Color HatchColor { get; set; } = Color.FromArgb(23, 148, 92);

        private readonly Color BaseColor = Color.FromArgb(45, 47, 49);
        private readonly Color SliderColor = Color.FromArgb(25, 27, 29);

        #endregion

        public bool ShowValue { get; set; } = false;

        public FlatTrackBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Height = 18;

            BackColor = Color.FromArgb(60, 70, 73);
        }

        #region Mouse events

        private int CalcRectangleXPosition() => Convert.ToInt32((_Value - _Minimum) / (float)(_Maximum - _Minimum) * (Width - 11));

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
                Bool = new Rectangle(CalcRectangleXPosition(), 0, 10, 20).Contains(e.Location);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Bool && e.X > -1 && e.X < (Width + 1))
                Value = _Minimum + Convert.ToInt32((_Maximum - _Minimum) * (e.X / (float)Width));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Bool = false;
        }

        #endregion

        public event ScrollEventHandler Scroll;
        public delegate void ScrollEventHandler(object sender);

        private int _Minimum;
        public int Minimum
        {
            get => 0;
            set
            {
                _Minimum = value;

                if (value > _Value) _Value = value;
                if (value > _Maximum) _Maximum = value;

                Invalidate();
            }
        }

        private int _Maximum = 10;
        public int Maximum
        {
            get => _Maximum;
            set
            {
                _Maximum = value;

                if (value < _Value) _Value = value;
                if (value < _Minimum) _Minimum = value;

                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get => _Value;
            set
            {
                if (value == _Value) return;

                _Value = value;
                Invalidate();
                Scroll?.Invoke(this);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Subtract && Value != 0)
                Value -= 1;
            else if (e.KeyCode == Keys.Add && Value != _Maximum)
                Value += 1;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 23;
        }

        #region Paint event

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var bitmap = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.InitializeFlatGraphics(BackColor);

                    var xPosition = CalcRectangleXPosition();
                    var Track = new Rectangle(xPosition, 0, 10, 20);
                    var knobRectangle = new Rectangle(xPosition, 4, 11, 14);

                    Rectangle baseRectangle = new Rectangle(1, 6, Width - 3, 8);
                    GraphicsPath baseGraphicsPath = new GraphicsPath();
                    baseGraphicsPath.AddRectangle(baseRectangle);

                    graphics.SetClip(baseGraphicsPath);
                    graphics.FillRectangle(new SolidBrush(BaseColor), new Rectangle(0, 7, Width - 1, 8));
                    graphics.FillRectangle(new SolidBrush(TrackColor), new Rectangle(0, 7, Track.X + Track.Width, 8));
                    graphics.ResetClip();

                    HatchBrush hatchBrush = new HatchBrush(HatchStyle.Plaid, HatchColor, TrackColor);
                    graphics.FillRectangle(hatchBrush, new Rectangle(-10, 7, Track.X + Track.Width, 8));

                    graphics.DrawSlider(Style, Style == Enums.FlatTrackBarStyle.Slider ? Track : knobRectangle, SliderColor);

                    if (ShowValue)
                    {
                        graphics.DrawString(Value.ToString(), new Font("Segoe UI", 8), Brushes.White,
                            new Rectangle(1, 6, Width - 1, Height - 1),
                            new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far });
                    }

                    base.OnPaint(e);

                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
                }
            }
        }

        #endregion
    }
}