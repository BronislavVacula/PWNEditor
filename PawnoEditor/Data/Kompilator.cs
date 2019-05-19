using System;
using System.IO;

namespace PawnoEditor.Data
{
    public class Kompilator
    {
        public string Pawncc { get; set; } = Path.Combine(new Soubory.Cesty().App_slozka, "pawncc.exe");
        public string Includy { get; set; } = Path.Combine(new Soubory.Cesty().App_slozka, "/include");
        public string WorkingDirectory { get; set; } = "";

        public string Argumenty()
        {
            return $"-Dpath={WorkingDirectory}";
        }
    }
}
