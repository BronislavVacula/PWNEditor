using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace PawnoEditor.Komponenty
{
    public class PTabs : FlatUI.FlatTabControl
    {
        public AutocompleteMenuNS.AutocompleteMenu AutoCompleteMenu { get; set; }
        public ContextMenuStrip ZalozkyMenu { get; set; } = null;

        private PTab NovaTabZalozka()
        {
            PTab zalozka = new PTab() { Text = "Nová záložka", ContextMenuStrip = ZalozkyMenu };
            TabPages.Add(zalozka);

            return zalozka;
        }

        public bool JeSouborOtevreny(string otevirany_soubor)
        {
            if (otevirany_soubor == "") return false;

           foreach(var zalozka in TabPages)
                if ((zalozka as PTab).Soubor == otevirany_soubor) return true;

            return false;
        }

        private PTextEdit NovyEditor(PTab zalozka)
        {
            return new PTextEdit()
            {
                Parent = zalozka,
                AutoComplete = AutoCompleteMenu,
                Dock = DockStyle.Fill,
                Visible = true
            };
        }

        private void UpravVelikostZalozek()
        {
            if(TabCount > 0) ItemSize = new Size(100, 25);
        }

        public void PridejZalozky(string[] soubory)
        {
            foreach (string soubor in soubory)
                PridejZalozku(soubor);
        }

        public void PridejZalozku(string soubor = "")
        {
            if (JeSouborOtevreny(soubor)) return;

            PTab zalozka = NovaTabZalozka();
            var editor = NovyEditor(zalozka);
            zalozka.Tag = editor;
            zalozka.OtevriSoubor(soubor);

            UpravVelikostZalozek();

            if (soubor == "") editor.OtevriSablonu();
        }

        public void ZavriAktualniZalozku()
        {
            ZavriZalozku(SelectedTab);
        }

        public void ZavriZalozku(TabPage zalozka)
        {
            if (TabCount > 0)
            {
                (zalozka as PTab).Editor.Dispose();
                TabPages.Remove(zalozka);
            }
        }

        public void ZavriVsechnyZalozky()
        {
            foreach (TabPage zalozka in TabPages)
                if(zalozka != null) ZavriZalozku(zalozka);
        }

        public PTab VybranaZalozka { get { return (SelectedTab as PTab); } }
    }
}
