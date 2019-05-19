using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawnoEditor.Dialogy
{
    public partial class Zprava : Form
    {
        public Zprava(string text, string titulek = "Informace")
        {
            InitializeComponent();

            flatLabel1.Text = text;

            formSkin1.Text = titulek;
            Text = titulek;

            ShowDialog();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
