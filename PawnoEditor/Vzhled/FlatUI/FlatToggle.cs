using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    [DefaultEvent("CheckedChanged")]
    public class FlatToggle : Control
    {
        public Helpers.MouseState State = Helpers.MouseState.None;

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        [Flags()]
        public enum _Options
        {
            Style1, Style2, Style3, Style4, Style5
        }

        [Category("Options")]
        public _Options Options { get; set; } = _Options.Style1;

        [Category("Options")]
        public bool Checked { get; set; }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 76;
            Height = 33;
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = Helpers.MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = Helpers.MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
            CheckedChanged?.Invoke(this);
        }

        private Color BaseColor = Helpers.FlatColors.Instance().Flat;
        private Color BaseColorRed = Color.FromArgb(220, 85, 96);
        private Color BGColor = Color.FromArgb(84, 85, 86);
        private Color ToggleColor = Color.FromArgb(45, 47, 49);
        private Color TextColor = Color.FromArgb(243, 243, 243);

        public FlatToggle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(44, Height + 1);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10);
            Size = new Size(76, 33);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);
            int W = Width - 1, H = Height - 1;

            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();
            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Toggle = new Rectangle(Convert.ToInt32(W / 2), 0, 38, H);

            graphics.InitializeFlatGraphics(BackColor);

            switch (Options)
            {
                case _Options.Style1:
                    GP = Helpers.Main.RoundRec(Base, 6); //-- Base
                    GP2 = Helpers.Main.RoundRec(Toggle, 6);
                    graphics.FillPath(new SolidBrush(BGColor), GP);
                    graphics.FillPath(new SolidBrush(ToggleColor), GP2);
                    graphics.DrawString("OFF", Font, new SolidBrush(BGColor),
                        new Rectangle(19, 1, W, H), Helpers.Main.CenterSF); //-- Text

                    if (Checked)
                    {
                        GP = Helpers.Main.RoundRec(Base, 6);
                        GP2 = Helpers.Main.RoundRec(new Rectangle(Convert.ToInt32(W / 2), 0, 38, H), 6);
                        graphics.FillPath(new SolidBrush(ToggleColor), GP);
                        graphics.FillPath(new SolidBrush(BaseColor), GP2);
                        graphics.DrawString("ON", Font, new SolidBrush(BaseColor),
                            new Rectangle(8, 7, W, H), Helpers.Main.NearSF); //-- Text
                    }
                    break;
                case _Options.Style2:
                    GP = Helpers.Main.RoundRec(Base, 6); //-- Base
                    Toggle = new Rectangle(4, 4, 36, H - 8);
                    GP2 = Helpers.Main.RoundRec(Toggle, 4);
                    graphics.FillPath(new SolidBrush(BaseColorRed), GP);
                    graphics.FillPath(new SolidBrush(ToggleColor), GP2);

                    //-- Lines
                    graphics.DrawLine(new Pen(BGColor), 18, 20, 18, 12);
                    graphics.DrawLine(new Pen(BGColor), 22, 20, 22, 12);
                    graphics.DrawLine(new Pen(BGColor), 26, 20, 26, 12);
                    graphics.DrawString("r", new Font("Marlett", 8), new SolidBrush(TextColor),
                        new Rectangle(19, 2, Width, Height), Helpers.Main.CenterSF); //-- Text

                    if (Checked)
                    {
                        GP = Helpers.Main.RoundRec(Base, 6);
                        Toggle = new Rectangle(Convert.ToInt32(W / 2) - 2, 4, 36, H - 8);
                        GP2 = Helpers.Main.RoundRec(Toggle, 4);
                        graphics.FillPath(new SolidBrush(BaseColor), GP);
                        graphics.FillPath(new SolidBrush(ToggleColor), GP2);

                        //-- Lines
                        graphics.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 12, 20, Convert.ToInt32(W / 2) + 12, 12);
                        graphics.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 16, 20, Convert.ToInt32(W / 2) + 16, 12);
                        graphics.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 20, 20, Convert.ToInt32(W / 2) + 20, 12);

                        graphics.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(TextColor),
                            new Rectangle(8, 7, Width, Height), Helpers.Main.NearSF); //-- Text
                    }
                    break;
                case _Options.Style3:
                    GP = Helpers.Main.RoundRec(Base, 16); //-- Base
                    Toggle = new Rectangle(W - 28, 4, 22, H - 8);
                    GP2.AddEllipse(Toggle);
                    graphics.FillPath(new SolidBrush(ToggleColor), GP);
                    graphics.FillPath(new SolidBrush(BaseColorRed), GP2);
                    graphics.DrawString("OFF", Font, new SolidBrush(BaseColorRed), new Rectangle(-12, 2, W, H),
                        Helpers.Main.CenterSF); //-- Text

                    if (Checked)
                    {
                        GP = Helpers.Main.RoundRec(Base, 16); //-- Base
                        Toggle = new Rectangle(6, 4, 22, H - 8);
                        GP2.Reset();
                        GP2.AddEllipse(Toggle);
                        graphics.FillPath(new SolidBrush(ToggleColor), GP);
                        graphics.FillPath(new SolidBrush(BaseColor), GP2);
                        graphics.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(12, 2, W, H),
                            Helpers.Main.CenterSF); //-- Text
                    }
                    break;
                case _Options.Style4:
                    //-- TODO: New Styles
                    if (Checked)
                    {
                        //--
                    }
                    break;
                case _Options.Style5:
                    //-- TODO: New Styles
                    if (Checked)
                    {
                        //--
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