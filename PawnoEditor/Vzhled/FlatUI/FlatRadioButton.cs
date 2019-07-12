using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    [DefaultEvent("CheckedChanged")]
    public class FlatRadioButton : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;

        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _BorderColor = Helpers.FlatColors.Instance().Flat;
        private Color _TextColor = Color.FromArgb(243, 243, 243);

        public FlatRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            Cursor = Cursors.Hand;
            Size = new Size(100, 22);
            BackColor = Color.FromArgb(60, 70, 73);
            Font = new Font("Segoe UI", 10);
        }

        private bool _Checked;
        public bool Checked
        {
            get => _Checked;
            set
            {
                _Checked = value;
                InvalidateControls();
                CheckedChanged?.Invoke(this);
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        protected override void OnClick(EventArgs e)
        {
            if (!_Checked) Checked = true;
            base.OnClick(e);
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked) return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is FlatRadioButton)
                {
                    ((FlatRadioButton)C).Checked = false;
                    Invalidate();
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InvalidateControls();
        }

        [Flags()]
        public enum _Options
        {
            Style1, Style2
        }

        [Category("Options")]
        public _Options Options { get; set; } = _Options.Style1;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 22;
        }

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

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);

            Rectangle Base = new Rectangle(0, 2, Height - 5, Height - 5);
            Rectangle Dot = new Rectangle(4, 6, Height - 13, Height - 13);

            graphics.InitializeFlatGraphics(BackColor);

            switch (Options)
            {
                case _Options.Style1:
                    graphics.FillEllipse(new SolidBrush(_BaseColor), Base);

                    switch (State)
                    {
                        case Helpers.MouseState.Over:
                        case Helpers.MouseState.Down:
                            graphics.DrawEllipse(new Pen(_BorderColor), Base);
                            break;
                    }

                    if (Checked) graphics.FillEllipse(new SolidBrush(_BorderColor), Dot);
                    break;

                case _Options.Style2:
                    graphics.FillEllipse(new SolidBrush(_BaseColor), Base); //-- Base

                    switch (State)
                    {
                        case Helpers.MouseState.Over:
                        case Helpers.MouseState.Down:
                            graphics.DrawEllipse(new Pen(_BorderColor), Base); //-- Base
                            graphics.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), Base);
                            break;
                    }

                    if (Checked) graphics.FillEllipse(new SolidBrush(_BorderColor), Dot); //-- Base
                    break;
            }

            graphics.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(20, 2, Width - 1, Height - 1), Helpers.Main.NearSF);

            base.OnPaint(e);

            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}