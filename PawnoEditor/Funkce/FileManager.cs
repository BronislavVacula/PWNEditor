using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PawnoEditor.Funkce
{
    class FileManager
    {
        public string[] SeznamSouboruVeSlozce(string slozka) => Directory.GetFiles(slozka, "*", SearchOption.TopDirectoryOnly);

        public string[] SeznamSlozekVeSlozce(string slozka) => Directory.GetDirectories(slozka, "*", SearchOption.TopDirectoryOnly);

        public void VypisNazvyObrazku(string cesta, Komponenty.PlistBox umisteni)
        {
            if (!Directory.Exists(cesta)) return;

            umisteni.Items.Clear();
            umisteni.Items.AddRange(VsechnyObrazky(cesta));
        }

        public string[] VsechnyObrazky(string cesta) => NazvyObrazkuZCesty(SeznamSouboruVeSlozce(cesta)).ToArray();

        private IEnumerable<string> NazvyObrazkuZCesty(string[] soubory) 
            => from obrazek in soubory select Path.GetFileNameWithoutExtension(obrazek);

        public string[] SeznamDisku() => (from disk in DriveInfo.GetDrives() select disk.RootDirectory.FullName).ToArray();
    }
}