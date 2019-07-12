using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatComboBox : ComboBox
    {
        public Helpers.MouseState State = Helpers.MouseState.None;

        private Color _BaseColor = Color.FromArgb(25, 27, 29);
        private Color _BGColor = Color.FromArgb(45, 47, 49);

        [Category("Colors")]
        public Color HoverColor { get; set; } = Color.FromArgb(35, 168, 109);

        public FlatComboBox()
        {
            DrawItem += DrawItem_;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;

            Font = new Font("Segoe UI", 8, FontStyle.Regular);
            BackColor = Color.FromArgb(45, 45, 48);
            ForeColor = Color.White;
            Cursor = Cursors.Hand;

            SetStartIndex(0);
            ItemHeight = 18;
        }

        private void ChangeState(Helpers.MouseState newState)
        {
            State = newState;
            Invalidate();
        }

        #region Mouse events

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ChangeState(Helpers.MouseState.Down);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ChangeState(Helpers.MouseState.Over);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            ChangeState(Helpers.MouseState.Over);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ChangeState(Helpers.MouseState.None);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Invalidate();

            if (e.X < Width - 41) Cursor = Cursors.IBeam;
            else Cursor = Cursors.Hand;
        }

        #endregion

        private void SetStartIndex(int value)
        {
            try { base.SelectedIndex = value; }
            catch { }

            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Height = 18;
        }

        #region Paint and draw events

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            Invalidate();

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) Invalidate();
        }

        public void DrawItem_(Object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(HoverColor), e.Bounds); //-- Selected item
            else e.Graphics.FillRectangle(new SolidBrush(_BaseColor), e.Bounds); //-- Not Selected

            //-- Text
            e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), new Font("Segoe UI", 8),
                Brushes.White, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));

            e.Graphics.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var bitmap = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.InitializeFlatGraphics(Color.FromArgb(45, 45, 48));

                    graphics.FillRectangle(new SolidBrush(_BGColor), new Rectangle(0, 0, Width, Height));
                    DrawComboBoxButton(graphics);
                    DrawLines(graphics);
                    graphics.DrawString(Text, Font, Brushes.White, new Point(4, 6), Helpers.Main.NearSF);

                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
                }
            }
        }

        private void DrawComboBoxButton(Graphics graphics)
        {
            Rectangle buttonRectangle = new Rectangle(Convert.ToInt32(Width - 40), 0, Width, Height);

            GraphicsPath buttonGraphicsPath = new GraphicsPath();
            buttonGraphicsPath.AddRectangle(buttonRectangle);

            graphics.SetClip(buttonGraphicsPath);
            graphics.FillRectangle(new SolidBrush(_BaseColor), buttonRectangle);
            graphics.ResetClip();
        }

        private void DrawLines(Graphics graphics)
        {
            for (int i = 1; i <= 3; i++)
                graphics.DrawLine(Pens.White, Width - 10, 6 * i, Width - 30, 6 * i);
        }

        #endregion
    }
}
