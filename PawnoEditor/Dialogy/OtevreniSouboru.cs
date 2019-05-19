using System;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Dialogy
{
    public partial class OtevreniSouboru : Form
    {
        private Funkce.FileManager fm = new Funkce.FileManager();
        private Funkce.Dialog dialog = new Funkce.Dialog();

        public string Soubor { get; set; } = "";

        public OtevreniSouboru(string cesta = "")
        {
            InitializeComponent();
            NastavDialog();

            if (cesta == "") cesta = Path.GetPathRoot(Environment.SystemDirectory);

            dialog.PridejSeznamDisku(flatComboBox1);
        }

        private void NastavDialog()
        {
            dialog.FM = fm;
            dialog.FTB_cesta = flatTextBox1;
            dialog.LV_ulozeni = listView1;
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

            dialog.ObsahSlozky(listView1.SelectedItems[0].Tag.ToString());
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

        private void flatTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dialog.ObsahSlozky(flatTextBox1.Text);
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
            dialog.ObsahSlozky(flatComboBox1.Text);
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            ZavriOkno(Soubor == "" ? DialogResult.Cancel : DialogResult.OK);
        }
    }
}
