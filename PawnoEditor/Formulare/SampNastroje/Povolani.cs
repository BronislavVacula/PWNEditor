using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PawnoEditor.Formulare.SampNastroje
{
    public partial class Povolani : Form
    {
        Hlavni hl_form;

        public Povolani(Hlavni formular)
        {
            InitializeComponent();

            hl_form = formular;
        }

        private bool TextObsahujeCislo(object text)
        {
            return int.TryParse(text.ToString(), out int n);
        }

        private bool TextObsahujeDouble(object text)
        {
            return double.TryParse(text.ToString(), out double n);
        }

        private bool ZkontrolujVsechnyID(string[] rozdelene)
        {
            for (int i = 0; i < rozdelene.Count(); i++)
                if (!TextObsahujeDouble(rozdelene[i])) return false;

            return true;
        }

        private bool SpawnPoziceValidni(object pozice)
        {
            var rozdelene = pozice.ToString().Split(Convert.ToChar(";"));

            if (rozdelene.Count() < 3) return false;
            return ZkontrolujVsechnyID(rozdelene);
        }

        private bool ObsahujeID(object pozice)
        {
            if (TextObsahujeCislo(pozice)) return true;

            string pozice_txt = pozice.ToString();
            if (pozice_txt.IndexOf(";") < 0) return false;

            var rozdelene = pozice.ToString().Split(Convert.ToChar(";"));
            return ZkontrolujVsechnyID(rozdelene);
        }

        private void zrusitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void generovatBtn_Click(object sender, EventArgs e)
        {
            if (!SpravneVyplnene()) return;

            MessageBox.Show("vše ok");
        }

        private bool SpravneVyplnene()
        {
            foreach (DataGridViewRow radek in dataGridView1.Rows)
            {
                //Kontrola nulového (nevyplněného) řádku

                //Kontrola vyplněnosti položek
                if (!TextObsahujeCislo(radek.Cells["ID"].Value)) return false;
                if (!SpawnPoziceValidni(radek.Cells["Spawn"].Value)) return false;
                if (!TextObsahujeCislo(radek.Cells["PlatOD"].Value)) return false;
                if (!TextObsahujeCislo(radek.Cells["PlatDO"].Value)) return false;
                if (!ObsahujeID(radek.Cells["Zbrane"].Value)) return false;
                if (!ObsahujeID(radek.Cells["Skiny"].Value)) return false;
            }

            return true;
        }
    }
}
