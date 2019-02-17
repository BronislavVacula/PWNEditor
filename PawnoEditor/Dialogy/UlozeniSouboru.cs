using System;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Dialogy
{
    public partial class UlozeniSouboru : Form
    {
        private Funkce.FileManager fm = new Funkce.FileManager();
        private Funkce.Dialog dialog = new Funkce.Dialog();

        public string Soubor { get; set; } = "";

        public UlozeniSouboru(string nazev_souboru, string cesta = "")
        {
            InitializeComponent();
            NastavDialog();

            if (cesta == "") cesta = Path.GetPathRoot(Environment.SystemDirectory);
            flatTextBox2.Text = nazev_souboru;

            dialog.PridejSeznamDisku(flatComboBox1);
        }

        private void NastavDialog()
        {
            dialog.FM = fm;
            dialog.FTB_cesta = flatTextBox1;
            dialog.LV_ulozeni = listView1;
        }

        private void ZavriOkno(DialogResult vysledek)
        {
            DialogResult = vysledek;
            Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1) return;
            if (listView1.SelectedItems[0].ImageIndex == 0)
                VyberSlozku();
        }

        private void VyberSlozku()
        {
            flatTextBox1.Text = listView1.SelectedItems[0].Tag.ToString();
        }

        private void flatTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dialog.ObsahSlozky(flatTextBox1.Text);
        }

        private void flatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dialog.ObsahSlozky(flatComboBox1.Text, true);
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            Soubor = Path.Combine(flatComboBox1.Text, flatTextBox2.Text);

            ZavriOkno(DialogResult.OK);
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            ZavriOkno(DialogResult.Cancel);
        }
    }
}
