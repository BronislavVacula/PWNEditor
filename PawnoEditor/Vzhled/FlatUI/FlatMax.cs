using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    public class FlatMax : Control
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

            if (FindForm().WindowState == FormWindowState.Maximized)
                FindForm().WindowState = FormWindowState.Normal;
            else if (FindForm().WindowState == FormWindowState.Normal)
                FindForm().WindowState = FormWindowState.Maximized;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Size = new Size(18, 18);
        }

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

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            Rectangle Base = new Rectangle(0, 0, Width, Height);

            var _with4 = G;
            _with4.SmoothingMode = SmoothingMode.HighQuality;
            _with4.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with4.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with4.Clear(BackColor);

            _with4.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base
            
            if (FindForm().WindowState == FormWindowState.Maximized) //-- Maximize
                _with4.DrawString("1", Font, new SolidBrush(TextColor), new Rectangle(1, 1, Width, Height), 
                    Helpers.Main.CenterSF);
            else if (FindForm().WindowState == FormWindowState.Normal)
                _with4.DrawString("2", Font, new SolidBrush(TextColor), new Rectangle(1, 1, Width, Height), 
                    Helpers.Main.CenterSF);

            //-- Hover/down
            if(State == Helpers.MouseState.Over)
                _with4.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), Base);
            else if(State == Helpers.MouseState.Down)
                _with4.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Base);

            base.OnPaint(e);

            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}