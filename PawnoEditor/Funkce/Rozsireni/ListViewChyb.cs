using System;
using System.Windows.Forms;

namespace PawnoEditor.Funkce.Rozsireni
{
    public static class ListViewChyb
    {
        public static ListView PridejInformaciOKompilaci(this ListView listView, string kompilovanySoubor, string chyba, string radek = "0")
        {
            var polozka = listView.Items.Add((listView.Items.Count + 1).ToString());
            polozka.SubItems.Add(kompilovanySoubor);
            polozka.SubItems.Add(radek);
            polozka.SubItems.Add(chyba);

            return listView;
        }
    }
}
