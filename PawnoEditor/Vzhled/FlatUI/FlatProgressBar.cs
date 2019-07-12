using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatProgressBar : Control
    {
        private int _Value = 0;
        private int _Maximum = 100;

        public bool Pattern { get; set; } = true;
        public bool ShowBalloon { get; set; } = true;
        public bool PercentSign { get; set; } = false;

        [Category("Colors")]
        public Color ProgressColor { get; set; } = Helpers.FlatColors.Instance().Flat;

        [Category("Colors")]
        public Color DarkerProgress { get; set; } = Color.FromArgb(23, 148, 92);

        private Color _BaseColor = Color.FromArgb(45, 47, 49);

        public FlatProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            BackColor = Color.FromArgb(60, 70, 73);
            Height = 42;
        }

        [Category("Control")]
        public int Maximum
        {
            get => _Maximum;
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
            get => _Value;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);
            int W = Width - 1, H = Height - 1;

            Rectangle Base = new Rectangle(0, 24, W, H);
            GraphicsPath GP = new GraphicsPath();

            graphics.InitializeFlatGraphics(BackColor);

            //-- Progress Value
            float percent = _Value / ((float)_Maximum);
            int iValue = (int)(percent * Width);

            switch (Value)
            {
                case 0:
                    graphics.FillRectangle(new SolidBrush(_BaseColor), Base); //-- Base
                    graphics.FillRectangle(new SolidBrush(ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1)); //--Progress
                    break;
                case 100:
                    graphics.FillRectangle(new SolidBrush(_BaseColor), Base); //-- Base
                    graphics.FillRectangle(new SolidBrush(ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1)); //--Progress
                    break;
                default:
                    graphics.FillRectangle(new SolidBrush(_BaseColor), Base); //-- Base
                    GP.AddRectangle(new Rectangle(0, 24, iValue - 1, H - 1));
                    graphics.FillPath(new SolidBrush(ProgressColor), GP); //--Progress

                    if (Pattern)
                    {
                        HatchBrush HB = new HatchBrush(HatchStyle.Plaid, DarkerProgress, ProgressColor);
                        graphics.FillRectangle(HB, new Rectangle(0, 24, iValue - 1, H - 1));
                    }

                    if (ShowBalloon)
                    {
                        Rectangle Balloon = new Rectangle(iValue - 18, 0, 34, 16); //-- Balloon
                        var GP2 = Helpers.Main.RoundRec(Balloon, 4);
                        graphics.FillPath(new SolidBrush(_BaseColor), GP2);

                        //-- Arrow
                        graphics.DrawArrow(iValue - 9, 16, true, _BaseColor);

                        //-- Value > You can add "%" > value & "%"
                        string text = PercentSign ? Value.ToString() + "%" : Value.ToString();
                        int wOffset = PercentSign ? iValue - 15 : iValue - 11;

                        graphics.DrawString(text, new Font("Segoe UI", 10), new SolidBrush(ProgressColor),
                            new Rectangle(wOffset, -2, W, H), Helpers.Main.NearSF);
                    }
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