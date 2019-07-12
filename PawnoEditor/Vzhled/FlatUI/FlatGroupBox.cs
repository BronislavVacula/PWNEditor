using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatGroupBox : ContainerControl
    {
        public bool ShowText { get; set; } = true;
        public bool Border { get; set; } = false;
        public Pen BorderColor { get; set; } = Pens.White;

        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(60, 70, 73);
        private readonly Color TextColor = Helpers.FlatColors.Instance().Flat;

        public FlatGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            BackColor = Color.Transparent;
            Size = new Size(240, 180);
            Font = new Font("Segoe ui", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var bitmap = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Rectangle baseRectangle = new Rectangle(8, 8, Width - 17, Height - 17);

                    graphics.InitializeFlatGraphics(BackColor);

                    var GP = Helpers.Main.RoundRec(baseRectangle, 8);  //-- Base
                    graphics.FillPath(new SolidBrush(BaseColor), GP);  //-- Base

                    graphics.DrawArrow(28, 2, false, BaseColor);
                    graphics.DrawArrow(28, 8, true, Color.FromArgb(60, 70, 73));

                    ShowTextIfIsEnabled(graphics, Width - 1, Height - 1);

                    if (Border) graphics.DrawRectangle(Pens.LightSlateGray, new Rectangle(1, 1, Width - 1, Height - 1));

                    base.OnPaint(e);

                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
                }
            }
        }

        private void ShowTextIfIsEnabled(Graphics graphics, int width, int height)
        {
            if (ShowText)
                graphics.DrawString(Text, Font, new SolidBrush(TextColor), new Rectangle(16, 16, width, height), Helpers.Main.NearSF);
        }
    }
}