using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FlatUI.Extensions
{
    public static class TrackBarSlider
    {
        public static Graphics DrawSlider(this Graphics graphics, Enums.FlatTrackBarStyle sliderStyle, Rectangle sliderRectangle, Color sliderColor)
        {
            GraphicsPath sliderGraphicPath = new GraphicsPath();

            if (sliderStyle == Enums.FlatTrackBarStyle.Slider) sliderGraphicPath.AddRectangle(sliderRectangle);
            else if (sliderStyle == Enums.FlatTrackBarStyle.Knob) sliderGraphicPath.AddEllipse(sliderRectangle);

            graphics.FillPath(new SolidBrush(sliderColor), sliderGraphicPath);

            return graphics;
        }
    }
}
