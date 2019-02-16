using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawnoEditor.Formulare.SampNastroje
{
    public partial class Mapa : Form
    {
        float x, y;

        public Mapa()
        {
            InitializeComponent();

            mapa_obr.Load(new Data.Soubory.Cesty().Obrazky() + "radar.JPG");
        }

        private void mapa_obr_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = (e.X - 320) * 9.375f;
                y = (e.Y - 320) * 9.375f * -1;

                flatTextBox1.Text = x.ToString() + ", " + y.ToString();
            }
        }
    }
}
