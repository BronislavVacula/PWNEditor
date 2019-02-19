using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Cyotek.Windows.Forms;

namespace PawnoEditor
{
    public partial class Hlavni : Form
    {
        Funkce.FileManager fm = new Funkce.FileManager();
        Data.Soubory.Cesty cesty = new Data.Soubory.Cesty();

        public Hlavni()
        {
            InitializeComponent();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                fm.NactiObrazky(cesty.Pickupy(), plistBox2);
                fm.NactiObrazky(cesty.Skiny(), plistBox1);
            }).Start();

            new Funkce.Parsovani.ParsujSoubory(cesty.Includy(), treeView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pTabs1.ActiveColor = Color.FromArgb(26, 25, 25);
        }

        private void formSkin1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Y < 35 && e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
                else WindowState = FormWindowState.Maximized;
            }
        }

        #region Menu - Soubor

        private void nováZáložkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pTabs1.PridejZalozku("");
        }

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialogy.OtevreniSouboru soubor_otevreni = new Dialogy.OtevreniSouboru();

            if (soubor_otevreni.ShowDialog() == DialogResult.OK)
                pTabs1.PridejZalozku(soubor_otevreni.Soubor);
        }

        private void zavřítZáložkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pTabs1.ZavriAktualniZalozku();
        }

        private void zavřítVšeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pTabs1.ZavriVsechnyZalozky();
        }

        private void Ulozeni(Komponenty.PTab zalozka)
        {
            if (zalozka.Soubor != "") zalozka.UlozZmeny();
            else zalozka.UlozNovySoubor();
        }

        private void uložiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.TabCount > 0) Ulozeni(pTabs1.SelectedTab as Komponenty.PTab);
        }

        private void uložitVšeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var zalozka in pTabs1.TabPages)
                Ulozeni(zalozka as Komponenty.PTab);
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Menu - Upravit

        private void plistBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (plistBox1.SelectedItems.Count > 0)
                pictureBox2.Image = Image.FromFile(cesty.Skiny() + plistBox1.SelectedItem.ToString() + ".png");
        }

        private void zpěvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.TabCount > 0)
                pTabs1.VybranaZalozka.Editor.Undo();
        }

        private void vpředToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.TabCount > 0)
                pTabs1.VybranaZalozka.Editor.Redo();
        }

        private void vyjmoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.TabCount > 0)
                pTabs1.VybranaZalozka.Editor.Cut();
        }

        private void kopírovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.TabCount > 0)
                pTabs1.VybranaZalozka.Editor.Copy();
        }

        private void vložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.TabCount > 0)
                pTabs1.VybranaZalozka.Editor.Paste();
        }

        private void vybratVšeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.TabCount > 0)
                pTabs1.VybranaZalozka.Editor.SelectAll();
        }

        #endregion

        #region Menu - Zobrazit

        private void UpravViditelnost(ToolStripMenuItem menu_polozka, Control komponenta)
        {
            menu_polozka.Checked = !menu_polozka.Checked;
            komponenta.Visible = menu_polozka.Checked;
        }

        private void pravýPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpravViditelnost(pravýPanelToolStripMenuItem, flatTabControl1);

            if (flatTabControl1.Visible)
                panel1.Size = new Size(panel1.Width - flatTabControl1.Width, panel1.Height);
            else
                panel1.Size = new Size(panel1.Width + flatTabControl1.Width, panel1.Height);
        }

        private void spodníPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpravViditelnost(spodníPanelToolStripMenuItem, flatTabControl2);

            if (flatTabControl2.Visible)
                pTabs1.Size = new Size(pTabs1.Width, pTabs1.Height - flatTabControl2.Height);
            else
                pTabs1.Size = new Size(pTabs1.Width, pTabs1.Height + flatTabControl2.Height);
        }

        #endregion

        #region Menu - Sestavit

        private void zkompilovatKódToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.VybranaZalozka.Soubor == "") return;

            Funkce.Kompilace kompilace = new Funkce.Kompilace() { Soubor = pTabs1.VybranaZalozka.Soubor };
            kompilace.Kompiluj();

            listView1.Items.Clear();
        }

        #endregion

        #region Menu - SAMP Nástroje

        private void výběrBarvyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dialog = new ColorPickerDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
                Clipboard.SetText(Funkce.Barvy.Prevod.NaHex(dialog.Color));
        }

        private void mapyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Formulare.SampNastroje.Mapa().Show();
        }

        private void povoláníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Formulare.SampNastroje.Povolani(this).Show();
        }

        #endregion

        #region Menu - Nápověda

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Formulare.OProgramu().ShowDialog();
        }

        #endregion
    }
}
