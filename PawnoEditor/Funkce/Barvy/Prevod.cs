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
    }
}
