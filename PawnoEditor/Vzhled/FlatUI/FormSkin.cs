using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    public class FormSkin : ContainerControl
    {
        private int W, H;
        private bool Cap = false;
        private Point MousePoint = new Point(0, 0);
        private readonly int MoveHeight = 50;

        [Category("Colors")]
        private readonly Color TextColor = Color.FromArgb(234, 234, 234);

        [Category("Colors")]
        public Color HeaderColor { get; set; } = Color.FromArgb(45, 47, 49);

        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(60, 70, 73);

        [Category("Colors")]
        public Color BorderColor { get; set; } = Color.FromArgb(53, 58, 60);

        [Category("Colors")]
        public Color FlatColor { get; set; } = Helpers.Main.FlatColor;

        [Category("Options")]
        public bool HeaderMaximize { get; set; } = false;

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
            if (HeaderMaximize)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
                {
                    if (FindForm().WindowState == FormWindowState.Normal)
                    {
                        FindForm().WindowState = FormWindowState.Maximized;
                        FindForm().Refresh();
                    }
                    else if (FindForm().WindowState == FormWindowState.Maximized)
                    {
                        FindForm().WindowState = FormWindowState.Normal;
                        FindForm().Refresh();
                    }
                }
            }
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

        public FormSkin()
        {
            MouseDoubleClick += FormSkin_MouseDoubleClick;
            DoubleBuffered = true;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 12);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Header = new Rectangle(0, 0, W, 50);

            var _with2 = G;
            _with2.SmoothingMode = SmoothingMode.HighQuality;
            _with2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with2.Clear(BackColor);

            _with2.FillRectangle(new SolidBrush(BaseColor), Base); //-- Base
            _with2.FillRectangle(new SolidBrush(HeaderColor), Header); //-- Header

            //-- Logo
            _with2.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(8, 16, 4, 18));
            _with2.FillRectangle(new SolidBrush(FlatColor), 16, 16, 4, 18);
            _with2.DrawString(Text, Font, new SolidBrush(TextColor), new Rectangle(26, 15, W, H), Helpers.Main.NearSF);

            //-- Border
            _with2.DrawRectangle(new Pen(BorderColor), Base);

            base.OnPaint(e);

            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}