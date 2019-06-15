using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Data.Soubory
{
    class Cesty
    {
        public string App_slozka { get; } = "";

        public Cesty()
        {
            App_slozka = Path.GetDirectoryName(Application.ExecutablePath);
        }

        public string Obrazky()
        {
            return $"{App_slozka}\\Obrazky\\";
        }

        public string Includy()
        {
            return $"{App_slozka}\\include\\";
        }

        public string Pickupy()
        {
            return $"{App_slozka}\\Obrazky\\Pickupy\\";
        }

        public string Skiny()
        {
            return $"{App_slozka}\\Obrazky\\Skiny\\";
        }

        public string Server()
        {
            return $"{App_slozka}\\SAMPServer\\";
        }

        public string Sablona(string nazev)
        {
            return $"{App_slozka}\\Templaty\\{nazev}.pe";
        }
    }
}