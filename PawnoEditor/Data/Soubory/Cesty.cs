using System;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Data.Soubory
{
    public class Cesty
    {
        public enum CESTY_DRUHY
        {
            Obrazky = 0,
            Includy = 1,
            Pickupy = 2,
            Skiny = 3,
            SAMPServer = 4
        }

        private readonly string[] UmisteniVeSlozceSProjektem =
        {
            "Obrazky\\",
            "include\\",
            "Obrazky\\Pickupy\\",
            "Obrazky\\Skiny\\",
            "SAMPServer\\"
        };

        public string App_slozka { get; } = Path.GetDirectoryName(Application.ExecutablePath);

        public string VratCestu(CESTY_DRUHY druhCesty)
        {
            return Path.Combine(App_slozka, UmisteniVeSlozceSProjektem[(int)druhCesty]);
        }

        public string Sablona(string nazev)
        {
            return $"{App_slozka}\\Templaty\\{nazev}.pe";
        }
    }
}