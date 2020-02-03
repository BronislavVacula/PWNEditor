using System.Drawing;

namespace Base.Helpers
{
    public class ColorHelper
    {
        /// <summary>
        /// Converts to hexadecimal.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static string ConvertToHex(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        /// <summary>
        /// Converts the color of the RGB to.
        /// </summary>
        /// <param name="rgb">The RGB.</param>
        /// <returns></returns>
        public static Color ConvertRgbToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}
