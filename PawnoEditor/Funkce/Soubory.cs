using System;
using System.IO;

namespace PawnoEditor.Funkce
{
    class Soubory
    {
        public static void ZmenRadekVSouboru(string soubor, string hledanyText, string nahrazeni)
        {
            var radky = File.ReadAllLines(soubor);

            for (int i = 0; i < radky.Length; i++)
            {
                if (radky[i].IndexOf(hledanyText) > -1)
                {
                    radky[i] = nahrazeni;
                    break;
                }
            }

            File.WriteAllLines(soubor, radky);
        }
    }
}
