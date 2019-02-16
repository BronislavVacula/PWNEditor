using System;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Funkce
{
    class Dialog
    {
        public FileManager FM { get; set; }
        public ListView LV_ulozeni { get; set; }
        public FlatUI.FlatTextBox FTB_cesta { get; set; }

        public void ObsahSlozky(string cesta, bool pouze_slozky = false)
        {
            LV_ulozeni.Items.Clear();

            VypisSeznamSlozek(cesta);
            if(!pouze_slozky) VypisSeznamSouboru(cesta);

            FTB_cesta.Text = cesta;
        }

        private void VypisSeznamSouboru(string cesta)
        {
            foreach (var soubor in FM.SeznamSouboruVeSlozce(cesta))
                PridejSoubor(soubor);
        }

        private void VypisSeznamSlozek(string cesta)
        {
            foreach (var slozka in FM.SeznamSlozekVeSlozce(cesta))
                PridejSlozku(slozka);
        }

        private void PridejSoubor(string soubor)
        {
            ListViewItem lv_soubor = LVPolozka(soubor, Path.GetFileName(soubor));
            lv_soubor.SubItems.Add(Path.GetExtension(soubor));
            lv_soubor.SubItems.Add(new FileInfo(soubor).Length.ToString());

            LV_ulozeni.Items.Add(lv_soubor);
        }

        private void PridejSlozku(string slozka)
        {
            ListViewItem lv_slozka = LVPolozka(slozka, new DirectoryInfo(slozka).Name, 1);
            lv_slozka.SubItems.Add("-");
            lv_slozka.SubItems.Add("-");

            LV_ulozeni.Items.Add(lv_slozka);
        }

        private ListViewItem LVPolozka(string cesta, string nazev, int obrazek = 0)
        {
            return new ListViewItem(Path.GetFileName(nazev))
            {
                ImageIndex = obrazek,
                Tag = cesta
            };
        }

        public void PridejSeznamDisku(FlatUI.FlatComboBox ulozeni)
        {
            ulozeni.Items.AddRange(FM.SeznamDisku());
            ulozeni.SelectedIndex = 0;
        }
    }
}
