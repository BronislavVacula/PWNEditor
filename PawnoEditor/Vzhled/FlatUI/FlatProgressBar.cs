using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    public class FlatProgressBar : Control
    {
        private int _Value = 0;
        private int _Maximum = 100;

        [Category("Control")]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < _Value) _Value = value;
                _Maximum = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                    Invalidate();
                }

                _Value = value;
                Invalidate();
            }
        }

        public bool Pattern { get; set; } = true;
        public bool ShowBalloon { get; set; }  = true;
        public bool PercentSign { get; set; } = false;

        [Category("Colors")]
        public Color ProgressColor { get; set; } = Helpers.Main.FlatColor;

        [Category("Colors")]
        public Color DarkerProgress { get; set; }  = Color.FromArgb(23, 148, 92);

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 42;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Height = 42;
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }

        private Color _BaseColor = Color.FromArgb(45, 47, 49);

        public FlatProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            BackColor = Color.FromArgb(60, 70, 73);
            Height = 42;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateColors();

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            int W = Width - 1, H = Height - 1;

            Rectangle Base = new Rectangle(0, 24, W, H);
            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();
            GraphicsPath GP3 = new GraphicsPath();

            var _with15 = G;
            _with15.SmoothingMode = SmoothingMode.HighQuality;
            _with15.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with15.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with15.Clear(BackColor);

            //-- Progress Value
            float percent = ((float)_Value) / ((float)_Maximum);
            int iValue = (int)(percent * ((float)Width));

            switch (Value)
            {
                case 0:
                    _with15.FillRectangle(new SolidBrush(_BaseColor), Base); //-- Base
                    _with15.FillRectangle(new SolidBrush(ProgressColor), 
                        new Rectangle(0, 24, iValue - 1, H - 1)); //--Progress
                    break;
                case 100:
                    _with15.FillRectangle(new SolidBrush(_BaseColor), Base); //-- Base
                    _with15.FillRectangle(new SolidBrush(ProgressColor), 
                        new Rectangle(0, 24, iValue - 1, H - 1)); //--Progress
                    break;
                default:
                    _with15.FillRectangle(new SolidBrush(_BaseColor), Base); //-- Base
                    GP.AddRectangle(new Rectangle(0, 24, iValue - 1, H - 1));
                    _with15.FillPath(new SolidBrush(ProgressColor), GP); //--Progress

                    if (Pattern)
                    {
                        HatchBrush HB = new HatchBrush(HatchStyle.Plaid, DarkerProgress, ProgressColor);
                        _with15.FillRectangle(HB, new Rectangle(0, 24, iValue - 1, H - 1));
                    }

                    if (ShowBalloon)
                    {
                        Rectangle Balloon = new Rectangle(iValue - 18, 0, 34, 16); //-- Balloon
                        GP2 = Helpers.Main.RoundRec(Balloon, 4);
                        _with15.FillPath(new SolidBrush(_BaseColor), GP2);

                        //-- Arrow
                        GP3 = Helpers.Main.DrawArrow(iValue - 9, 16, true);
                        _with15.FillPath(new SolidBrush(_BaseColor), GP3);

                        //-- Value > You can add "%" > value & "%"
                        string text = (PercentSign ? Value.ToString() + "%" : Value.ToString());
                        int wOffset = (PercentSign ? iValue - 15 : iValue - 11);
                        _with15.DrawString(text, new Font("Segoe UI", 10), new SolidBrush(ProgressColor), 
                            new Rectangle(wOffset, -2, W, H), Helpers.Main.NearSF);
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
            ProgressColor = Helpers.Main.GetColors(this).Flat;
        }
    }
}