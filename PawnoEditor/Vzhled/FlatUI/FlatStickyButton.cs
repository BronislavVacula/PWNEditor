using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatStickyButton : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;

        private void ChangeMouseState(Helpers.MouseState newState)
        {
            State = newState;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ChangeMouseState(Helpers.MouseState.Down);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ChangeMouseState(Helpers.MouseState.Over);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            ChangeMouseState(Helpers.MouseState.Over);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ChangeMouseState(Helpers.MouseState.None);
        }

        private bool[] GetConnectedSides()
        {
            bool[] Bool = new bool[4] { false, false, false, false };

            foreach (Control B in Parent.Controls)
            {
                if (B is FlatStickyButton)
                {
                    if (ReferenceEquals(B, this) || !Rect.IntersectsWith(Rect)) continue;
                    double A = (Math.Atan2(Left - B.Left, Top - B.Top) * 2 / Math.PI);
                    if (A / 1 == A) Bool[(int)A + 1] = true;
                }
            }

            return Bool;
        }

        private Rectangle Rect => new Rectangle(Left, Top, Width, Height);

        [Category("Colors")]
        public Color BaseColor { get; set; } = Helpers.FlatColors.Instance().Flat;

        [Category("Colors")]
        public Color TextColor { get; set; } = Color.FromArgb(243, 243, 243);

        [Category("Options")]
        public bool Rounded { get; set; } = false;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        public FlatStickyButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            Size = new Size(106, 32);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 12);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);

            GraphicsPath GP = new GraphicsPath();

            bool[] GCS = GetConnectedSides();

            GraphicsPath RoundedBase = Helpers.Main.RoundRect(0, 0, Width, Height, 0.3,
                !(GCS[2] || GCS[1]), !(GCS[1] || GCS[0]), !(GCS[3] || GCS[0]), !(GCS[3] || GCS[2]));
            Rectangle Base = new Rectangle(0, 0, Width, Height);

            graphics.InitializeFlatGraphics(BackColor);

            switch (State)
            {
                case Helpers.MouseState.None:
                    if (Rounded)
                        DrawRoundedButton(graphics, Base, Color.White, null, false);
                    else
                        DrawNormalButton(graphics, Base, Color.White, false);
                    break;
                case Helpers.MouseState.Over:
                    if (Rounded)
                        DrawRoundedButton(graphics, Base, Color.White, RoundedBase);
                    else
                        DrawNormalButton(graphics, Base, Color.White);
                    break;
                case Helpers.MouseState.Down:
                    if (Rounded)
                        DrawRoundedButton(graphics, Base, Color.Black, RoundedBase);
                    else
                        DrawNormalButton(graphics, Base, Color.Black);
                    break;
            }

            base.OnPaint(e);
            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        private void DrawRoundedButton(Graphics graphics, Rectangle rect, Color filledColor, GraphicsPath graphicsPath, bool multiRec = true)
        {
            graphics.FillPath(new SolidBrush(BaseColor), graphicsPath);
            if (multiRec) graphics.FillPath(new SolidBrush(Color.FromArgb(20, filledColor)), graphicsPath);
            graphics.DrawString(Text, Font, new SolidBrush(TextColor), rect, Helpers.Main.CenterSF);
        }
        private void DrawNormalButton(Graphics graphics, Rectangle rect, Color filledColor, bool multiRec = true)
        {
            graphics.FillRectangle(new SolidBrush(BaseColor), rect);
            if (multiRec) graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, filledColor)), rect);
            graphics.DrawString(Text, Font, new SolidBrush(TextColor), rect, Helpers.Main.CenterSF);
        }
    }
}