using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace FlatUI.Extensions
{
    public static class GraphicsExt
    {
        public static Graphics InitializeFlatGraphics(this Graphics G, Color backgroundColor)
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.Clear(backgroundColor);

            return G;
        }

        public static Graphics DrawArrow(this Graphics graphics, int x, int y, bool flip, Color colorOfArrow)
        {
            var graphicsPath = Helpers.Main.DrawArrow(x, y, flip);
            graphics.FillPath(new SolidBrush(colorOfArrow), graphicsPath);

            return graphics;
        }
    }
}
