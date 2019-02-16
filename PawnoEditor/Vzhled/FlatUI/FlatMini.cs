using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    public class FlatMini : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;
        private int x;

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
            x = e.X;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if(FindForm().WindowState == FormWindowState.Normal)
                FindForm().WindowState = FormWindowState.Minimized;
            else if(FindForm().WindowState == FormWindowState.Maximized)
                FindForm().WindowState = FormWindowState.Minimized;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(18, 18);
        }

        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(45, 47, 49);

        [Category("Colors")]
        public Color TextColor { get; set; } = Color.FromArgb(243, 243, 243);

        public FlatMini()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BackColor = Color.White;
            Size = new Size(18, 18);
            Font = new Font("Marlett", 12);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            Rectangle Base = new Rectangle(0, 0, Width, Height);

            var _with5 = G;
            _with5.SmoothingMode = SmoothingMode.HighQuality;
            _with5.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with5.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with5.Clear(BackColor);

            _with5.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base
            _with5.DrawString("0", Font, new SolidBrush(TextColor), new Rectangle(2, 1, Width, Height), 
                Helpers.Main.CenterSF); //-- Minimize

            //-- Hover/down
            if (State == Helpers.MouseState.Over)
                _with5.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), Base);
            else if(State == Helpers.MouseState.Down)
                _with5.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Base);

            base.OnPaint(e);

            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}