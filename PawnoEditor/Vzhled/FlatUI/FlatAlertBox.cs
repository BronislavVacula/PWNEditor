using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

/// <summary>
/// How to use: FlatAlertBox.ShowControl(Kind, String, Interval)
/// </summary>
/// <remarks></remarks>
namespace FlatUI
{
    public class FlatAlertBox : Control
    {
        private string _Text;
        private Helpers.MouseState State = Helpers.MouseState.None;

        private readonly Color SuccessColor = Color.FromArgb(60, 85, 79);
        private readonly Color SuccessText = Color.FromArgb(35, 169, 110);
        private readonly Color ErrorColor = Color.FromArgb(87, 71, 71);
        private readonly Color ErrorText = Color.FromArgb(254, 142, 122);
        private readonly Color InfoColor = Color.FromArgb(70, 91, 94);
        private readonly Color InfoText = Color.FromArgb(97, 185, 186);

        public FlatAlertBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            BackColor = Color.FromArgb(60, 70, 73);
            Size = new Size(576, 42);
            Location = new Point(10, 61);
            Font = new Font("Segoe UI", 10);
            Cursor = Cursors.Hand;
        }

        #region ShowControl and TImer

        public void ShowControl(Enums.AlertBoxKind boxKind, string Str, int Interval)
        {
            Kind = boxKind;
            Text = Str;
            Visible = true;

            T = new Timer() { Interval = Interval, Enabled = true };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Visible = false;
            T.Enabled = false;
            T.Dispose();
        }

        private Timer withEventsField_T;
        private Timer T
        {
            get { return withEventsField_T; }
            set
            {
                if (withEventsField_T != null) withEventsField_T.Tick -= Timer_Tick;
                withEventsField_T = value;
                if (withEventsField_T != null) withEventsField_T.Tick += Timer_Tick;
            }

        }

        #endregion

        [Category("Options")]
        public Enums.AlertBoxKind Kind { get; set; }

        [Category("Options")]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                if (_Text != null) _Text = value;
            }
        }

        [Category("Options")]
        public new bool Visible
        {
            get => base.Visible == false;
            set => base.Visible = value;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Height = 42;
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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Visible = false;
        }

        #endregion

        #region OnPaint event

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);

            int W = Width - 1, H = Height - 1;

            Rectangle Base = new Rectangle(0, 0, W, H);

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(BackColor);

            switch (Kind)
            {
                case Enums.AlertBoxKind.Success:
                    graphics.FillRectangle(new SolidBrush(SuccessColor), Base); //-- Base

                    //-- Ellipse
                    graphics.FillEllipse(new SolidBrush(SuccessText), new Rectangle(8, 9, 24, 24));
                    graphics.FillEllipse(new SolidBrush(SuccessColor), new Rectangle(10, 11, 20, 20));

                    //-- Checked Sign
                    graphics.DrawString("ü", new Font("Wingdings", 22), new SolidBrush(SuccessText), new Rectangle(7, 7, W, H), Helpers.Main.NearSF);
                    graphics.DrawString(Text, Font, new SolidBrush(SuccessText), new Rectangle(48, 12, W, H), Helpers.Main.NearSF);

                    //-- X button
                    graphics.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 30, H - 29, 17, 17));
                    graphics.DrawString("r", new Font("Marlett", 8), new SolidBrush(SuccessColor), new Rectangle(W - 28, 16, W, H), Helpers.Main.NearSF);

                    if (State == Helpers.MouseState.Over)
                        graphics.DrawString("r", new Font("Marlett", 8),
                            new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 28, 16, W, H), Helpers.Main.NearSF);
                    break;
                case Enums.AlertBoxKind.Error:
                    graphics.FillRectangle(new SolidBrush(ErrorColor), Base); //-- Base

                    //-- Ellipse
                    graphics.FillEllipse(new SolidBrush(ErrorText), new Rectangle(8, 9, 24, 24));
                    graphics.FillEllipse(new SolidBrush(ErrorColor), new Rectangle(10, 11, 20, 20));

                    //-- X Sign
                    graphics.DrawString("r", new Font("Marlett", 16), new SolidBrush(ErrorText), new Rectangle(6, 11, W, H), Helpers.Main.NearSF);
                    graphics.DrawString(Text, Font, new SolidBrush(ErrorText), new Rectangle(48, 12, W, H), Helpers.Main.NearSF);

                    //-- X button
                    graphics.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 32, H - 29, 17, 17));
                    graphics.DrawString("r", new Font("Marlett", 8), new SolidBrush(ErrorColor), new Rectangle(W - 30, 17, W, H), Helpers.Main.NearSF);

                    if (State == Helpers.MouseState.Over)
                        graphics.DrawString("r", new Font("Marlett", 8),
                            new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 30, 15, W, H), Helpers.Main.NearSF);
                    break;
                case Enums.AlertBoxKind.Info:
                    graphics.FillRectangle(new SolidBrush(InfoColor), Base); //-- Base

                    //-- Ellipse
                    graphics.FillEllipse(new SolidBrush(InfoText), new Rectangle(8, 9, 24, 24));
                    graphics.FillEllipse(new SolidBrush(InfoColor), new Rectangle(10, 11, 20, 20));

                    //-- Info Sign
                    graphics.DrawString("¡", new Font("Segoe UI", 20, FontStyle.Bold), new SolidBrush(InfoText), new Rectangle(12, -4, W, H), Helpers.Main.NearSF);
                    graphics.DrawString(Text, Font, new SolidBrush(InfoText), new Rectangle(48, 12, W, H), Helpers.Main.NearSF);

                    //-- X button
                    graphics.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 32, H - 29, 17, 17));
                    graphics.DrawString("r", new Font("Marlett", 8), new SolidBrush(InfoColor), new Rectangle(W - 30, 17, W, H), Helpers.Main.NearSF);

                    if (State == Helpers.MouseState.Over)
                        graphics.DrawString("r", new Font("Marlett", 8),
                            new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 30, 17, W, H), Helpers.Main.NearSF);
                    break;
            }

            base.OnPaint(e);
            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion
    }
}