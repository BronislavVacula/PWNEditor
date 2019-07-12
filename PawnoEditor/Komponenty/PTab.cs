using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PawnoEditor.Komponenty
{
    public class PTab : TabPage
    {
        public string Soubor { get; set; } = "";
        public PTextEdit Editor { get => (Tag as PTextEdit); }

        public void OtevriSoubor(string cesta = "")
        {
            if (!JeCestaKSouboruOK(cesta)) return;

            Editor.Text = File.ReadAllText(cesta, Encoding.Default);
            Soubor = cesta;

            UpravJmenoZalozky();
        }

        public void UlozNovySoubor()
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Pawno soubor (*.pwn)|*.pwn" };

            if (sfd.ShowDialog() == DialogResult.OK)
                if (sfd.FileName != "") UlozeniSouboru(sfd.FileName);

            sfd.Dispose();
        }

        private void UlozeniSouboru(string cesta)
        {
            Soubor = cesta;

            UlozZmeny();
            UpravJmenoZalozky();
        }

        public void UlozZmeny() => File.WriteAllText(Soubor, Editor.Text);

        private void UpravJmenoZalozky() => Text = Path.GetFileName(Soubor);

        private bool JeCestaKSouboruOK(string cesta) => File.Exists(cesta) && cesta != "";

        public bool BylSouborUlozeny() => Soubor != "";
    }
}
