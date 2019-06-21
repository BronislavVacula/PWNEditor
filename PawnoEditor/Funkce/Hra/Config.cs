using System;
using System.IO;
using PawnoEditor.Data.Soubory;

namespace PawnoEditor.Funkce.Hra
{
    class Config
    {
       readonly Cesty cesty = new Cesty();

       public void ZmenMod(string amxCesta)
       {
            var vyslednaCesta = ZkopirujModDoSlozkyServeru(amxCesta);

            ZmenNazevModuVConfigu(vyslednaCesta);
       }

        private string ZkopirujModDoSlozkyServeru(string amxCesta)
        {
            if (!File.Exists(amxCesta)) return null;

            var vyslednaCesta = Path.Combine(cesty.VratCestu(Cesty.CESTY_DRUHY.SAMPServer),
                "\\gamemodes\\", Path.GetFileName(amxCesta));
            File.Copy(amxCesta, vyslednaCesta);

            return vyslednaCesta;
        } 

        private void ZmenNazevModuVConfigu(string soubor)
        {
            if (soubor == null) return;

            var configCesta = Path.Combine(cesty.VratCestu(Cesty.CESTY_DRUHY.SAMPServer), "server.cfg");

            Soubory.ZmenRadekVSouboru(configCesta, "gamemode0", 
                $"gamemode0 {Path.GetFileNameWithoutExtension(soubor)} 1");
        }
    }
}
