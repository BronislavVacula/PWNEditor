using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawnoEditor.Eventy
{
    public class KonzolovyPrikazVykonanArgs : EventArgs
    {
        public string zprava;

        public KonzolovyPrikazVykonanArgs(string zpravaZKonzole)
        {
            zprava = zpravaZKonzole;
        }

        public delegate void KonzolovyPrikazVykonanEvent(object sender, KonzolovyPrikazVykonanArgs e);
    }
}
