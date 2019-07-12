using System;

namespace PawnoEditor.Eventy
{
    public class KonzolovyPrikazVykonanArgs : EventArgs
    {
        public string zprava;

        public KonzolovyPrikazVykonanArgs(string zpravaZKonzole)
        {
            zprava = zpravaZKonzole;
        }
    }
}
