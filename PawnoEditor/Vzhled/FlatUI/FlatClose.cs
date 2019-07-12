using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatClose : Control
    {
        private Helpers.MouseState State = Helpers.MouseState.None;

        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(168, 35, 35);

        [Category("Colors")]
        public Color TextColor { get; set; } = Color.FromArgb(243, 243, 243);

        public FlatClose()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BackColor = Color.White;
            Size = new Size(18, 18);
            Font = new Font("Marlett", 10);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(18, 18);
        }

        #region Mouse events

        private void ChangeState(Helpers.MouseState newState)
        {
            State = newState;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            ChangeState(Helpers.MouseState.Over);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ChangeState(Helpers.MouseState.Down);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ChangeState(Helpers.MouseState.None);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ChangeState(Helpers.MouseState.Over);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            (Parent.Parent as Form).Close();
        }

        #endregion

        #region Paint event

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var bitmap = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Rectangle baseRectangle = new Rectangle(0, 0, Width, Height);

                    graphics.InitializeFlatGraphics(BackColor);
                    graphics.FillRectangle(new SolidBrush(BaseColor), baseRectangle);
                    graphics.DrawString("r", Font, new SolidBrush(TextColor), new Rectangle(0, 0, Width, Height), Helpers.Main.CenterSF);

                    switch (State)
                    {
                        case Helpers.MouseState.Over:
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), baseRectangle);
                            break;

                        case Helpers.MouseState.Down:
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), baseRectangle);
                            break;
                    }

                    base.OnPaint(e);

                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
                }
            }
        }

        #endregion
    }
}