using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    public class FlatStickyButton : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;

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

        private bool[] GetConnectedSides()
        {
            bool[] Bool = new bool[4] { false, false, false, false };

            foreach (Control B in Parent.Controls)
            {
                if (B is FlatStickyButton)
                {
                    if (object.ReferenceEquals(B, this) || !Rect.IntersectsWith(Rect)) continue;
                    double A = (Math.Atan2(Left - B.Left, Top - B.Top) * 2 / Math.PI);
                    if (A / 1 == A) Bool[(int)A + 1] = true;
                }
            }

            return Bool;
        }

        private Rectangle Rect
        {
            get { return new Rectangle(Left, Top, Width, Height); }
        }

        [Category("Colors")]
        public Color BaseColor { get; set; } = Helpers.Main.FlatColor;

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
            this.UpdateColors();

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            int W = Width, H = Height;

            GraphicsPath GP = new GraphicsPath();

            bool[] GCS = GetConnectedSides();

            GraphicsPath RoundedBase = Helpers.Main.RoundRect(0, 0, W, H, 0.3, 
                !(GCS[2] || GCS[1]), !(GCS[1] || GCS[0]), !(GCS[3] || GCS[0]), !(GCS[3] || GCS[2]));
            Rectangle Base = new Rectangle(0, 0, W, H);

            var _with17 = G;
            _with17.SmoothingMode = SmoothingMode.HighQuality;
            _with17.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with17.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with17.Clear(BackColor);

            switch (State)
            {
                case Helpers.MouseState.None:
                    if (Rounded)
                    {
                        GP = RoundedBase;
                        _with17.FillPath(new SolidBrush(BaseColor), GP); //-- Base
                        _with17.DrawString(Text, Font, new SolidBrush(TextColor), Base, 
                            Helpers.Main.CenterSF); //-- Text
                    }
                    else
                    {
                        _with17.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base
                        _with17.DrawString(Text, Font, new SolidBrush(TextColor), Base, 
                            Helpers.Main.CenterSF);
                    }
                    break;
                case Helpers.MouseState.Over:
                    if (Rounded)
                    {
                        GP = RoundedBase; //-- Base
                        _with17.FillPath(new SolidBrush(BaseColor), GP);
                        _with17.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), GP);
                        _with17.DrawString(Text, Font, new SolidBrush(TextColor), Base, 
                            Helpers.Main.CenterSF); //-- Text
                    }
                    else
                    {
                        _with17.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base
                        _with17.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), Base);
                        _with17.DrawString(Text, Font, new SolidBrush(TextColor), Base, 
                            Helpers.Main.CenterSF); //-- Text
                    }
                    break;
                case Helpers.MouseState.Down:
                    if (Rounded)
                    {
                        GP = RoundedBase;
                        _with17.FillPath(new SolidBrush(BaseColor), GP); //-- Base
                        _with17.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), GP);
                        _with17.DrawString(Text, Font, new SolidBrush(TextColor), Base, 
                            Helpers.Main.CenterSF); //-- Text
                    }
                    else
                    {
                        _with17.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base
                        _with17.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), Base);
                        _with17.DrawString(Text, Font, new SolidBrush(TextColor), Base, 
                            Helpers.Main.CenterSF); //-- Text
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