using System;
using System.Drawing;

namespace PawnoEditor.Funkce.Barvy
{
    class Prevod
    {
        public static string NaHex(Color barva)
        {
            return "#" + barva.R.ToString("X2") + barva.G.ToString("X2") + barva.B.ToString("X2");
        }

        public static Color IntRGBNaBarvu(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}
