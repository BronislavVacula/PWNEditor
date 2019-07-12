using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    [DefaultEvent("CheckedChanged")]
    public class FlatCheckBox : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;
        private bool _Checked;

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            Invalidate();
        }

        public bool Checked
        {
            get => _Checked;
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnClick(EventArgs e)
        {
            _Checked = !_Checked;
            CheckedChanged?.Invoke(this);
            base.OnClick(e);
        }

        [Flags()]
        public enum _Options
        {
            Style1, Style2
        }

        [Category("Options")]
        public Enums.CheckBoxStyles Options { get; set; }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 22;
        }

        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(45, 47, 49);

        [Category("Colors")]
        public Color BorderColor { get; set; } = Helpers.FlatColors.Instance().Flat;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = Helpers.MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = Helpers.MouseState.None;
            Invalidate();
        }

        private readonly Color _TextColor = Color.FromArgb(243, 243, 243);

        public FlatCheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            BackColor = Color.FromArgb(60, 70, 73);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10);
            Size = new Size(112, 22);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);

            int W = Width - 1, H = Height - 1;

            Rectangle Base = new Rectangle(0, 2, Height - 5, Height - 5);

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(BackColor);

            switch (Options)
            {
                case Enums.CheckBoxStyles.Style1:
                    graphics.FillRectangle(new SolidBrush(BaseColor), Base);

                    if (State == Helpers.MouseState.Over || State == Helpers.MouseState.Down)
                        graphics.DrawRectangle(new Pen(BorderColor), Base);

                    if (Checked)
                        graphics.DrawString("ü", new Font("Wingdings", 18), new SolidBrush(BorderColor),
                             new Rectangle(5, 7, H - 9, H - 9), Helpers.Main.CenterSF);

                    if (Enabled == false)
                    {
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), Base);
                        graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(140, 142, 143)),
                            new Rectangle(20, 2, W, H), Helpers.Main.NearSF);
                    }

                    graphics.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(20, 2, W, H), Helpers.Main.NearSF);
                    break;
                case Enums.CheckBoxStyles.Style2:
                    graphics.FillRectangle(new SolidBrush(BaseColor), Base);

                    if (State == Helpers.MouseState.Over || State == Helpers.MouseState.Down)
                    {
                        graphics.DrawRectangle(new Pen(BorderColor), Base);
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(118, 213, 170)), Base);
                    }

                    if (Checked)
                        graphics.DrawString("ü", new Font("Wingdings", 18), new SolidBrush(BorderColor),
                            new Rectangle(5, 7, H - 9, H - 9), Helpers.Main.CenterSF);

                    if (Enabled == false)
                    {
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), Base);
                        graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(48, 119, 91)),
                            new Rectangle(20, 2, W, H), Helpers.Main.NearSF);
                    }

                    graphics.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(20, 2, W, H), Helpers.Main.NearSF);
                    break;
            }

            base.OnPaint(e);

            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}