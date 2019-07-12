using System;
using System.Windows.Forms;
using PawnoEditor.Data.SAMPNastroje;
using PawnoEditor.Funkce.Rozsireni;

namespace PawnoEditor.Formulare.SampNastroje
{
    public partial class Mapa : Form
    {
        DMapa.Akce aktualni_akce = DMapa.Akce.NovySpawn;
        Data.Soubory.Cesty cesty = new Data.Soubory.Cesty();

        public Mapa()
        {
            InitializeComponent();

            mapa_obr.Load($"{cesty.VratCestu(Data.Soubory.Cesty.CESTY_DRUHY.Obrazky)}radar.JPG");
        }

        private void mapa_obr_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            DMapa.Souradnice vybrana_pozice = SouradniceVybranePozice(e);

            switch (aktualni_akce)
            {
                case DMapa.Akce.NovySpawn:
                    richTextBox1.PridejRadek($"SetPlayerPos(playerid, {vybrana_pozice.X}, {vybrana_pozice.Y}, {vybrana_pozice.Z});");
                    break;

                case DMapa.Akce.NovyPickup:
                    break;
            }
        }

        private DMapa.Souradnice SouradniceVybranePozice(MouseEventArgs e)
        {
            return new DMapa.Souradnice()
            {
                X = (e.X - 320) * 9.375f,
                Y = (e.Y - 320) * 9.375f * -1,
                Z = 0
            };
        }
    }
}
