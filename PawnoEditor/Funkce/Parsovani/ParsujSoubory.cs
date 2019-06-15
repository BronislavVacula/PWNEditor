using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Funkce.Parsovani
{
    class ParsujSoubory
    {
        FileManager fm = new FileManager();

        public ParsujSoubory(string slozka, TreeView ulozeni)
        {
            foreach (var soubor in fm.SeznamSouboruVeSlozce(slozka))
                PridejFunkceDoLV(soubor, ulozeni);
        }

        private void PridejFunkceDoLV(string soubor, TreeView ulozeni)
        {
            var nativeFunkce = new PNativeFunkce(soubor);

            ulozeni.Nodes.Add(NovaLVPolozka(soubor, nativeFunkce.Seznam()));

            nativeFunkce.Dispose();
        }

        private TreeNode NovaLVPolozka(string soubor, List<string> seznam_funkci)
        {
            var polozka = new TreeNode(Path.GetFileName(soubor));

            foreach(var funkce in seznam_funkci)
                polozka.Nodes.Add(funkce);

            return polozka;
        }
    }
}
