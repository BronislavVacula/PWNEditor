using System.Drawing;

namespace Base.Helpers
{
    public class ColorHelper
    {
        /// <summary>
        /// Converts to hexadecimal.
        /// </summary>
        /// <param name="barva">The barva.</param>
        /// <returns></returns>
        public static string ConvertToHex(Color barva)
        {
            return "#" + barva.R.ToString("X2") + barva.G.ToString("X2") + barva.B.ToString("X2");
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
