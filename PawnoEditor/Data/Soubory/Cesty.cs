using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Data.Soubory
{
    class Cesty
    {
        public string app_slozka { get; } = "";

        public Cesty()
        {
            app_slozka = Path.GetDirectoryName(Application.ExecutablePath);
        }

        public string Obrazky()
        {
            return $"{app_slozka}\\Obrazky\\";
        }

        public string Includy()
        {
            return $"{app_slozka}\\include\\";
        }

        public string Pickupy()
        {
            return $"{app_slozka}\\Obrazky\\Pickupy\\";
        }

        public string Skiny()
        {
            return $"{app_slozka}\\Obrazky\\Skiny\\";
        }

        public string Sablona(string nazev)
        {
            return $"{app_slozka}\\Templaty\\{nazev}.pe";
        }
    }
}