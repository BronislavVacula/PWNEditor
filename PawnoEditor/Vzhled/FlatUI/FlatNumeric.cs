using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatNumeric : Control
    {
        private int x, y;
        public Helpers.MouseState State = Helpers.MouseState.None;
        private long _Value, _Min, _Max;
        private bool Bool;

        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(45, 47, 49);

        [Category("Colors")]
        public Color ButtonColor { get; set; } = Helpers.FlatColors.Instance().Flat;

        public FlatNumeric()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            Font = new Font("Segoe UI", 10);
            BackColor = Color.FromArgb(60, 70, 73);
            ForeColor = Color.White;

            _Min = 0;
            _Max = 9999999;
        }

        public long Value
        {
            get => _Value;
            set
            {
                if (value <= _Max & value >= _Min) _Value = value;
                Invalidate();
            }
        }

        public long Maximum
        {
            get => _Max;
            set
            {
                if (value > _Min) _Max = value;
                if (_Value > _Max) _Value = _Max;
                Invalidate();
            }
        }

        public long Minimum
        {
            get => _Min;
            set
            {
                if (value < _Max) _Min = value;
                if (_Value < _Min) _Value = Minimum;
                Invalidate();
            }
        }

        #region Mouse events

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            x = e.Location.X;
            y = e.Location.Y;

            Invalidate();

            if (e.X < Width - 23) Cursor = Cursors.IBeam;
            else Cursor = Cursors.Hand;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (x > Width - 21 && x < Width - 3)
            {
                if (y < 15)
                {
                    if ((Value + 1) <= _Max) _Value += 1;
                }
                else if ((Value - 1) >= _Min) _Value -= 1;
            }
            else
            {
                Bool = !Bool;
                Focus();
            }
            Invalidate();
        }

        #endregion

        #region Keyboard events

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (Bool) _Value = Convert.ToInt64(_Value.ToString() + e.KeyChar.ToString());
                if (_Value > _Max) _Value = _Max;

                Invalidate();
            }
            catch { }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Back) Value = 0;
        }

        #endregion

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 30;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);

            graphics.InitializeFlatGraphics(BackColor);

            //-- Base
            graphics.FillRectangle(new SolidBrush(BaseColor), new Rectangle(0, 0, Width, Height));
            graphics.FillRectangle(new SolidBrush(ButtonColor), new Rectangle(Width - 24, 0, 24, Height));

            graphics.DrawString("+", new Font("Segoe UI", 12), Brushes.White, new Point(Width - 12, 8), Helpers.Main.CenterSF); //-- Add
            graphics.DrawString("-", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.White, new Point(Width - 12, 22), Helpers.Main.CenterSF); //-- Subtract
            graphics.DrawString(Value.ToString(), Font, Brushes.White, new Rectangle(5, 1, Width, Height), new StringFormat { LineAlignment = StringAlignment.Center });

            base.OnPaint(e);

            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}