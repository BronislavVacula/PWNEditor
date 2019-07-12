using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FormSkin : ContainerControl
    {
        private bool Cap = false;
        private Point MousePoint = new Point(0, 0);
        private readonly int MoveHeight = 50;

        #region Colors

        [Category("Colors")]
        private readonly Color TextColor = Color.FromArgb(234, 234, 234);

        [Category("Colors")]
        public Color HeaderColor { get; set; } = Color.FromArgb(45, 47, 49);

        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(60, 70, 73);

        [Category("Colors")]
        public Color BorderColor { get; set; } = Color.FromArgb(53, 58, 60);

        [Category("Colors")]
        public Color FlatColor { get; set; } = Helpers.FlatColors.Instance().Flat;

        #endregion

        [Category("Options")]
        public bool HeaderMaximize { get; set; } = false;

        public FormSkin()
        {
            MouseDoubleClick += FormSkin_MouseDoubleClick;
            DoubleBuffered = true;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 12);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.AllowTransparency = false;
            ParentForm.TransparencyKey = Color.Fuchsia;
            ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;

            Dock = DockStyle.Fill;

            Invalidate();
        }

        #region Mouse events

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MousePoint = e.Location;
            }
        }

        private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!HeaderMaximize || !CanMaximize(e)) return;

            var parentForm = FindForm();

            if (parentForm.WindowState == FormWindowState.Normal)
                ChangeWindowState(parentForm, FormWindowState.Maximized);
            else if (parentForm.WindowState == FormWindowState.Maximized)
                ChangeWindowState(parentForm, FormWindowState.Normal);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            Cap = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (Cap)
                Parent.Location = new Point(MousePosition.X - MousePoint.X, MousePosition.Y - MousePoint.Y);
        }

        private void ChangeWindowState(Form parentForm, FormWindowState newState)
        {
            parentForm.WindowState = newState;
            parentForm.Refresh();
        }

        private bool CanMaximize(MouseEventArgs e)
        {
            return e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location);
        }

        #endregion

        #region Paint event

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Bitmap B = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(B))
                {
                    Rectangle Base = new Rectangle(0, 0, Width, Height);

                    graphics.InitializeFlatGraphics(BackColor);

                    graphics.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base
                    graphics.FillRectangle(new SolidBrush(HeaderColor), new Rectangle(0, 0, Width, 50)); //-- Header

                    DrawLogo(graphics);

                    graphics.DrawRectangle(new Pen(BorderColor), Base); //-- Border

                    base.OnPaint(e);

                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImageUnscaled(B, 0, 0);
                }
            }
        }

        private void DrawLogo(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(8, 16, 4, 18));
            graphics.FillRectangle(new SolidBrush(FlatColor), 16, 16, 4, 18);
            graphics.DrawString(Text, Font, new SolidBrush(TextColor), new Rectangle(26, 15, Width, Height), Helpers.Main.NearSF);
        }

        #endregion
    }
}