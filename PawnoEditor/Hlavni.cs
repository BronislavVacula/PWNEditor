using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using PawnoEditor.Data.Soubory;

namespace PawnoEditor
{
    public partial class Hlavni : Form
    {
        Funkce.FileManager fm = new Funkce.FileManager();
        Cesty cesty = new Cesty();
        Funkce.Konzole prikazovaKonzole;

        Data.Nastaveni nastaveniProgramu = new Data.Nastaveni();

        public Hlavni()
        {
            InitializeComponent();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                fm.VypisNazvyObrazku(cesty.VratCestu(Cesty.CESTY_DRUHY.Pickupy), plistBox2);
                fm.VypisNazvyObrazku(cesty.VratCestu(Cesty.CESTY_DRUHY.Skiny), plistBox1);
            }).Start();
            
            new Funkce.Parsovani.ParsujSoubory(cesty.VratCestu(Cesty.CESTY_DRUHY.Includy), treeView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pTabs1.ActiveColor = Color.FromArgb(26, 25, 25);

            new Funkce.XML().NactiNastaveni(nastaveniProgramu);
        }

        private void Hlavni_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Funkce.XML().UlozNastaveni(nastaveniProgramu);
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

            soubor_otevreni.Dispose();
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
                pictureBox2.Image = Image.FromFile(cesty.VratCestu(Cesty.CESTY_DRUHY.Skiny) + plistBox1.SelectedItem.ToString() + ".png");
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

        private void ZobrazChyby(string kompilovanySoubor, List<string> chyby)
        {
            foreach(var chyba in chyby)
            {
                if (chyba == null || chyba == "") continue;

                var rozdeleni = Regex.Split(chyba, ": ");
                if (rozdeleni[0].IndexOf("(") < 0) continue;

                var cisloChybovehoRadku = rozdeleni[0].Split(Convert.ToChar("("), Convert.ToChar(")"))[1];

                var polozka = listView1.Items.Add((listView1.Items.Count + 1).ToString());
                polozka.SubItems.Add(kompilovanySoubor);
                polozka.SubItems.Add(cisloChybovehoRadku);
                polozka.SubItems.Add(rozdeleni[1] + " - " + rozdeleni[2]);
            }
        }

        private void ZkompilujSoubor(Komponenty.PTab zalozka)
        {
            if (!zalozka.BylSouborUlozeny())
            {
                new Dialogy.Zprava("Mód není uložení!");
                return;
            }

            var aktualniSoubor = pTabs1.VybranaZalozka.Soubor;

            Funkce.Kompilace kompilace = new Funkce.Kompilace(aktualniSoubor);

            if (kompilace.Kompiluj() == false) ZobrazChyby(aktualniSoubor, kompilace.Chyby);
            else KompilaceUspesna(aktualniSoubor);
        }

        public void KompilaceDokoncena(object sender, Eventy.KompilaceDokoncenaArgs e)
        {
            if (e.statusKompilace == Eventy.KompilaceDokoncenaArgs.STATUS.Uspesna)
                KompilaceUspesna(e.kompilovanySoubor);
            else
                ZobrazChyby(e.kompilovanySoubor, e.Chyby);
        }

        private void KompilaceUspesna(string aktualniSoubor)
        {
            var polozka = listView1.Items.Add((listView1.Items.Count + 1).ToString());
            polozka.SubItems.Add(aktualniSoubor);
            polozka.SubItems.Add("0");
            polozka.SubItems.Add("Soubor byl úspěšně zkompilován!");
        }

        private void zkompilovatKódToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (!pTabs1.ObsahujeZalozky()) return;

            ZkompilujSoubor(pTabs1.VybranaZalozka);
        }

        private void zkompilovatVšeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pTabs1.TabCount == 0) return;

            foreach (var zalozka in pTabs1.TabPages)
                ZkompilujSoubor(zalozka as Komponenty.PTab);
        }

        private void zkompilovatASpustitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (pTabs1.TabCount == 0) return;

            ZkompilujSoubor(pTabs1.VybranaZalozka);
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

        private void flatTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prikazovaKonzole == null)
                prikazovaKonzole = new Funkce.Konzole();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            if(flatTextBox1.Text.Length > 0 && prikazovaKonzole != null)
                prikazovaKonzole.SpustPrikaz(flatTextBox1.Text);
        }

        private void KonzolovyPrikazVykonan(object sender, Eventy.KonzolovyPrikazVykonanArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Length == 0 ? e.zprava : richTextBox1.Text + e.zprava;

            if (richTextBox1.Text.Length == 0)
                richTextBox1.Text = e.zprava;
            else richTextBox1.Text += e.zprava;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) return;
            if (treeView1.SelectedNode.Level == 0) return;

            if(nastaveniProgramu.ZpusobVkladaniScriptu == Data.Nastaveni.VKLADANI_SCRIPTU_Z_PANELU.SchrankaWindows)
                Clipboard.SetText(treeView1.SelectedNode.Text);
            else
                pTabs1.VybranaZalozka?.Editor.InsertText(pTabs1.VybranaZalozka.Editor.CurrentPosition, treeView1.SelectedNode.Text);
        }


        /// <summary>
        /// Po dvojkliku na chybu v listViewu přejde na chybový řádek v text. editoru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            var listViewSoubor = listView1.SelectedItems[0].SubItems[1].Text;
            var radekSChybou = Convert.ToInt32(listView1.SelectedItems[0].SubItems[2].Text);

            foreach(var zalozka in pTabs1.TabPages)
            {
                var pTab = zalozka as Komponenty.PTab;

                if (Path.GetFileName(listViewSoubor) == Path.GetFileName(pTab.Soubor))
                {
                    pTabs1.SelectedTab = pTab;
                    pTab.Editor.GotoPosition(pTab.Editor.Lines[radekSChybou].Position);
                    break;
                }
            }
        }
    }
}
