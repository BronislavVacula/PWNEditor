using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PawnoEditor.Komponenty
{
    public class PTab : TabPage
    {
        public string Soubor { get; set; } = "";
        public PTextEdit Editor { get { return (Tag as PTextEdit); } }

        private bool JeCestaOK(string cesta)
        {
            return File.Exists(cesta) && cesta != "";
        }

        public void OtevriSoubor(string cesta = "")
        {
            if (!JeCestaOK(cesta)) return;

            Editor.Text = File.ReadAllText(cesta, Encoding.Default);

            Soubor = cesta;
            UpravJmenoZalozky();
        }

        public bool BylSouborUlozeny()
        {
            return Soubor != "";
        }

        public void UlozNovySoubor()
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Textové soubory (*.txt)|*.txt" };

            if (sfd.ShowDialog() == DialogResult.OK)
                if (sfd.FileName != "") UlozeniSouboru(sfd.FileName);
        }

        private void UlozeniSouboru(string cesta)
        {
            Soubor = cesta;

            UlozZmeny();
            UpravJmenoZalozky();
        }

        public void UlozZmeny()
        {
            File.WriteAllText(Soubor, Editor.Text);
        }

        private void UpravJmenoZalozky()
        {
            Text = Path.GetFileName(Soubor);
        }
    }
}
