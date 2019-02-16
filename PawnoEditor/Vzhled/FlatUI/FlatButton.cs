using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    public class FlatButton : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;

        [Category("Colors")]
        public Color BaseColor { get; set; } = Helpers.Main.FlatColor;

        [Category("Colors")]
        public Color TextColor { get; set; } = Color.FromArgb(243, 243, 243);

        [Category("Options")]
        public bool Rounded { get; set; } = false;

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

        public FlatButton()
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
            this.UpdateColors();

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            int W = Width - 1, H = Height - 1;

            Rectangle Base = new Rectangle(0, 0, W, H);

            var _with8 = G;
            _with8.SmoothingMode = SmoothingMode.HighQuality;
            _with8.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with8.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with8.Clear(BackColor);

            switch (State)
            {
                case Helpers.MouseState.None:
                    if (Rounded)
                    {
                        _with8.FillPath(new SolidBrush(BaseColor), Helpers.Main.RoundRec(Base, 6));
                        _with8.DrawString(Text, Font, new SolidBrush(TextColor), Base, 
                            Helpers.Main.CenterSF); //Text
                    }
                    else
                    {
                        _with8.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base
                        _with8.DrawString(Text, Font, new SolidBrush(TextColor), Base, 
                            Helpers.Main.CenterSF); //-- Text
                    }
                    break;
                case Helpers.MouseState.Over:
                    if (Rounded)
                    {
                        //-- Base
                        _with8.FillPath(new SolidBrush(BaseColor), Helpers.Main.RoundRec(Base, 6));
                        _with8.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), Helpers.Main.RoundRec(Base, 6));

                        //-- Text
                        _with8.DrawString(Text, Font, new SolidBrush(TextColor), Base, Helpers.Main.CenterSF);
                    }
                    else
                    {
                        //-- Base
                        _with8.FillRectangle(new SolidBrush(BaseColor), Base);
                        _with8.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), Base);

                        //-- Text
                        _with8.DrawString(Text, Font, new SolidBrush(TextColor), Base, Helpers.Main.CenterSF);
                    }
                    break;
                case Helpers.MouseState.Down:
                    if (Rounded)
                    {
                        //-- Base
                        _with8.FillPath(new SolidBrush(BaseColor), Helpers.Main.RoundRec(Base, 6));
                        _with8.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), Helpers.Main.RoundRec(Base, 6));

                        //-- Text
                        _with8.DrawString(Text, Font, new SolidBrush(TextColor), Base, Helpers.Main.CenterSF);
                    }
                    else
                    {
                        //-- Base
                        _with8.FillRectangle(new SolidBrush(BaseColor), Base);
                        _with8.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), Base);

                        //-- Text
                        _with8.DrawString(Text, Font, new SolidBrush(TextColor), Base, Helpers.Main.CenterSF);
                    }
                    break;
            }

            base.OnPaint(e);

            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        private void UpdateColors()
        {
            BaseColor = Helpers.Main.GetColors(this).Flat;
        }
    }
}