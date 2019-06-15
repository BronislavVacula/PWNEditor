using System;

namespace PawnoEditor.Funkce.Parsovani
{
    class HledaniFunkce
    {
        public Komponenty.PTextEdit Editor { get; set; }

        private int NajdiFunkci(string funkce)
        {
            return Editor.SearchInTarget(funkce);
        }

        private int NajdiNajblizsiSlozenouZavorku(int startPozice)
        {
            int nalezenaPozice = -1;

            while(Editor.SearchInTarget("{") > -1)
            {
                if(Editor.TargetEnd > startPozice)
                {
                    nalezenaPozice = Editor.TargetEnd;
                    break;
                }
            }

            return nalezenaPozice;
        }

        public void VlozScriptDoFunkce(string funkce, string script)
        {
            var poziceFunkce = NajdiFunkci(funkce);
            if (poziceFunkce == -1) return;

            var poziceZavorky = NajdiNajblizsiSlozenouZavorku(poziceFunkce);
            if (poziceZavorky == -1) return;

            Editor.InsertText(poziceZavorky + 1, script);
        }
    }
}
