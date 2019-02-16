using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var seznam_funkci = new PNativeFunkce(soubor).Seznam();

            ulozeni.Nodes.Add(NovaLVPolozka(soubor, seznam_funkci));
        }

        private TreeNode NovaLVPolozka(string soubor, List<string> seznam_funkci)
        {
            TreeNode polozka = new TreeNode(Path.GetFileName(soubor));

            foreach(var funkce in seznam_funkci)
                polozka.Nodes.Add(funkce);

            return polozka;
        }
    }
}
