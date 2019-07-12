using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatButton : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;

        [Category("Colors")]
        public Color BaseColor { get; set; } = Helpers.FlatColors.Instance().Flat;

        [Category("Colors")]
        public Color TextColor { get; set; } = Color.FromArgb(243, 243, 243);

        [Category("Options")]
        public bool Rounded { get; set; } = false;

        public FlatButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            Size = new Size(106, 32);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 12);
            Cursor = Cursors.Hand;
        }

        #region Mouse states

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

        #endregion

        #region Paint event

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);
            Rectangle baseRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            graphics.InitializeFlatGraphics(BackColor);

            switch (State)
            {
                case Helpers.MouseState.None:
                    FillBaseColorPath(graphics, baseRectangle, Color.White, true);
                    break;
                case Helpers.MouseState.Over:
                    FillBaseColorPath(graphics, baseRectangle, Color.White);
                    break;
                case Helpers.MouseState.Down:
                    FillBaseColorPath(graphics, baseRectangle, Color.Black);
                    break;
            }

            graphics.DrawString(Text, Font, new SolidBrush(TextColor), baseRectangle, Helpers.Main.CenterSF);

            base.OnPaint(e);

            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        private void FillBaseColorPath(Graphics graphics, Rectangle baseRectangle, Color secondBrushColor, bool noEffect = false) //136
        {
            if (Rounded) FillPaths(graphics, baseRectangle, secondBrushColor, noEffect);
            else FillRectangles(graphics, baseRectangle, secondBrushColor, noEffect);
        }

        private void FillPaths(Graphics graphics, Rectangle baseRectangle, Color secondBrushColor, bool noEffect)
        {
            graphics.FillPath(new SolidBrush(BaseColor), Helpers.Main.RoundRec(baseRectangle, 6));
            if (!noEffect) graphics.FillPath(new SolidBrush(Color.FromArgb(20, secondBrushColor)), Helpers.Main.RoundRec(baseRectangle, 6));
        }

        private void FillRectangles(Graphics graphics, Rectangle baseRectangle, Color secondBrushColor, bool noEffect)
        {
            graphics.FillRectangle(new SolidBrush(BaseColor), baseRectangle);
            if (!noEffect) graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, secondBrushColor)), baseRectangle);
        }

        #endregion
    }
}