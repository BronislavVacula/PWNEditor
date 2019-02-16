using System;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Dialogy
{
    public partial class OtevreniSouboru : Form
    {
        private Funkce.FileManager fm = new Funkce.FileManager();
        public string Soubor { get; set; } = "";

        public OtevreniSouboru(string cesta = "")
        {
            InitializeComponent();

            if (cesta == "") cesta = Path.GetPathRoot(Environment.SystemDirectory);

            flatComboBox1.Items.AddRange(fm.SeznamDisku());
            flatComboBox1.SelectedIndex = 0;
        }

        private void ObsahSlozky(string cesta)
        {
            listView1.Items.Clear();

            VypisSeznamSlozek(cesta);
            VypisSeznamSouboru(cesta);

            flatTextBox1.Text = cesta;
        }

        private void VypisSeznamSouboru(string cesta)
        {
            foreach (var soubor in fm.SeznamSouboruVeSlozce(cesta))
                PridejSoubor(soubor);
        }

        private void VypisSeznamSlozek(string cesta)
        {
            foreach (var slozka in fm.SeznamSlozekVeSlozce(cesta))
                PridejSlozku(slozka);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 0) return;
            if (listView1.SelectedItems[0].ImageIndex == 0)
            {
                VyberSoubor();
                ZavriOkno(DialogResult.OK);
                return;
            }

            ObsahSlozky(listView1.SelectedItems[0].Tag.ToString());
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1) return;

            if (listView1.SelectedItems[0].ImageIndex == 0)
                VyberSoubor();
        }

        private void VyberSoubor()
        {
            Soubor = listView1.SelectedItems[0].Tag.ToString();
        }

        private void PridejSoubor(string soubor)
        {
            ListViewItem lv_soubor = LVPolozka(soubor, Path.GetFileName(soubor));
            lv_soubor.SubItems.Add(Path.GetExtension(soubor));
            lv_soubor.SubItems.Add(new FileInfo(soubor).Length.ToString());

            listView1.Items.Add(lv_soubor);
        }

        private void PridejSlozku(string slozka)
        {
            ListViewItem lv_slozka = LVPolozka(slozka, new DirectoryInfo(slozka).Name, 1);
            lv_slozka.SubItems.Add("-");
            lv_slozka.SubItems.Add("-");

            listView1.Items.Add(lv_slozka);
        }

        private ListViewItem LVPolozka(string cesta, string nazev, int obrazek = 0)
        {
            return new ListViewItem(Path.GetFileName(nazev))
            {
                ImageIndex = obrazek,
                Tag = cesta
            };
        }

        private void flatTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ObsahSlozky(flatTextBox1.Text);
        }

        private void ZavriOkno(DialogResult vysledek)
        {
            DialogResult = vysledek;
            Close();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            ZavriOkno(DialogResult.Cancel);
        }

        private void flatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObsahSlozky(flatComboBox1.Text);
        }
    }
}
