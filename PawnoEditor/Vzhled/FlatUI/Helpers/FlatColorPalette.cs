using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI.Helpers
{
    public class FlatColorPalette : Control
    {
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Size = new Size(180, 80);
        }

        private readonly Color[] colors = new Color[] {
            Color.FromArgb(220, 85, 96), //Red
            Color.FromArgb(10, 154, 157), //Cyan
            Color.FromArgb(0, 128, 255), //Blue
            Color.FromArgb(35, 168, 109), //LimeGreen
            Color.FromArgb(253, 181, 63), //Orange
            Color.FromArgb(155, 88, 181), //Purple
            Color.FromArgb(45, 47, 49), //Black
            Color.FromArgb(63, 70, 73), //Gray
            Color.FromArgb(243, 243, 243) //White
        };  

        public FlatColorPalette()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            
            Size = new Size(160, 80);
            Font = new Font("Segoe UI", 12);
            BackColor = Color.FromArgb(60, 70, 73);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            var _with6 = G;
            _with6.SmoothingMode = SmoothingMode.HighQuality;
            _with6.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with6.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with6.Clear(BackColor);

            //-- Colors 
            for (int i = 0; i < colors.Length; i++)
                _with6.FillRectangle(new SolidBrush(colors[i]), new Rectangle(i * 20, 0, 20, 40));

            //-- Text
            _with6.DrawString("Color Palette", Font, 
                new SolidBrush(Color.FromArgb(243, 243, 243)),  //White color
                new Rectangle(0, 22, Width - 1, Height - 1), Main.CenterSF);

            base.OnPaint(e);

            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}