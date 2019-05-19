using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawnoEditor.Eventy
{
    public class KompilaceDokoncenaArgs : EventArgs
    {
        public enum STATUS
        {
            Uspesna,
            Neuspesna
        }

        public STATUS statusKompilace = STATUS.Neuspesna;
        public List<string> Chyby { get; set; } = new List<string>();
        public string kompilovanySoubor;

        public KompilaceDokoncenaArgs(string kompilovanySoubor, STATUS vysledekKompilace, List<string> chybyKompilace)
        {
            statusKompilace = vysledekKompilace;
            Chyby = chybyKompilace;
            this.kompilovanySoubor = kompilovanySoubor;
        }

        public delegate void KompilaceDokoncenaEvent(object sender, KompilaceDokoncenaArgs e);
    }
}
