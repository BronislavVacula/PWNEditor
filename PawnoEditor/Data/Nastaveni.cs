using System;
using System.Collections.Generic;
using PawnoEditor.Data.NastaveniPolozky;

namespace PawnoEditor.Data
{
    public class Nastaveni
    {
        public enum VKLADANI_SCRIPTU_Z_PANELU
        {
            SchrankaWindows,
            Editor
        }

        public bool AutomatickeUkladani { get; set; } = false;
        public bool AutomatickaKompilace { get; set; } = false;
        public VKLADANI_SCRIPTU_Z_PANELU ZpusobVkladaniScriptu = VKLADANI_SCRIPTU_Z_PANELU.SchrankaWindows;

        public TextovyEditor Editor { get; set; } = new TextovyEditor();
        public ZvyrazneniSyntaxe SyntaxeEditoru { get; set; } = new ZvyrazneniSyntaxe();
        public Kompilator Kompilator { get; set; } = new Kompilator();
    }
}
