using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PawnoEditor.Data.SAMPNastroje;

namespace PawnoEditor.Formulare.SampNastroje
{
    public partial class Mapa : Form
    {
        DMapa.Akce aktualni_akce = DMapa.Akce.NovySpawn;
        Data.Soubory.Cesty cesty = new Data.Soubory.Cesty();

        public Mapa()
        {
            InitializeComponent();

            mapa_obr.Load($"{cesty.Obrazky()}radar.JPG");
        }

        private void PridejRadek(RichTextBox kam, string text)
        {
            kam.Text += text + Environment.NewLine;
        }

        private void mapa_obr_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DMapa.Souradnice vybrana_pozice = new DMapa.Souradnice()
                {
                    X = (e.X - 320) * 9.375f,
                    Y = (e.Y - 320) * 9.375f * -1
                };

                switch (aktualni_akce)
                {
                    case DMapa.Akce.NovySpawn:
                        PridejRadek(richTextBox1, $"SetPlayerPos(playerid, {vybrana_pozice.X}, " +
                            $"{vybrana_pozice.Y}, {vybrana_pozice.Z});");
                        break;

                    case DMapa.Akce.NovyPickup:
                        break;
                }

            }
        }
    }
}
