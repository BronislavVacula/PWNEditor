using System;
using System.Windows.Forms;
using PawnoEditor.Data.Soubory;

namespace PawnoEditor.Funkce.Rozsireni
{
    public static class RozsireniTreeViewu
    {
        public static TreeView NactiSeznamIncludu(this TreeView mistoUlozeni)
        {
            var cesty = new Cesty();
            new Parsovani.ParsujSoubory(cesty.VratCestu(Cesty.CESTY_DRUHY.Includy), mistoUlozeni);

            return mistoUlozeni;
        }
    }
}
