using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatMax : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;

        public Color BaseColor { get; set; } = Color.FromArgb(45, 47, 49);
        public Color TextColor { get; set; } = Color.FromArgb(243, 243, 243);

        public FlatMax()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BackColor = Color.White;
            Size = new Size(18, 18);
            Font = new Font("Marlett", 12);
        }

        #region Mouse events

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = Helpers.MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = Helpers.MouseState.None;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            var parentForm = FindForm();

            if (parentForm.WindowState == FormWindowState.Maximized)
                parentForm.WindowState = FormWindowState.Normal;
            else if (parentForm.WindowState == FormWindowState.Normal)
                parentForm.WindowState = FormWindowState.Maximized;
        }

        #endregion

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Size = new Size(18, 18);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);

            Rectangle Base = new Rectangle(0, 0, Width, Height);

            graphics.InitializeFlatGraphics(BackColor);
            graphics.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base

            if (FindForm().WindowState == FormWindowState.Maximized)
                graphics.DrawString("1", Font, new SolidBrush(TextColor), new Rectangle(1, 1, Width, Height), Helpers.Main.CenterSF);
            else if (FindForm().WindowState == FormWindowState.Normal)
                graphics.DrawString("2", Font, new SolidBrush(TextColor), new Rectangle(1, 1, Width, Height), Helpers.Main.CenterSF);

            //-- Hover/down
            if (State == Helpers.MouseState.Over)
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), Base);
            else if (State == Helpers.MouseState.Down)
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Base);

            base.OnPaint(e);

            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}