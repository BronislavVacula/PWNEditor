using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PawnoEditor.Funkce
{
    class FileManager
    {
        public string[] SeznamSouboruVeSlozce(string slozka)
        {
            return Directory.GetFiles(slozka, "*", SearchOption.TopDirectoryOnly);
        }

        public string[] SeznamSlozekVeSlozce(string slozka)
        {
            return Directory.GetDirectories(slozka, "*", SearchOption.TopDirectoryOnly);
        }

        public void NactiObrazky(string cesta, Komponenty.PlistBox umisteni)
        {
            if (!Directory.Exists(cesta)) return;

            umisteni.Items.Clear();
            umisteni.Items.AddRange(VsechnyObrazky(cesta));
        }

        public string[] VsechnyObrazky(string cesta)
        {
            return NazvyObrazkuZCesty(SeznamSouboruVeSlozce(cesta)).ToArray();
        }

        private IEnumerable<string> NazvyObrazkuZCesty(string[] soubory)
        {
            return from obrazek in soubory select Path.GetFileNameWithoutExtension(obrazek);
        }

        public string[] SeznamDisku()
        {
            return (from disk in DriveInfo.GetDrives() select disk.RootDirectory.FullName).ToArray();
        }
    }
}