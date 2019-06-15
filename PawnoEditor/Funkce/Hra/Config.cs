using System;
using System.IO;

namespace PawnoEditor.Funkce.Hra
{
    class Config
    {
       readonly Data.Soubory.Cesty cesty = new Data.Soubory.Cesty();

       public void ZmenMod(string amxCesta)
       {
            var vyslednaCesta = ZkopirujModDoSlozkyServeru(amxCesta);

            ZmenNazevModuVConfigu(vyslednaCesta);
       }

        private string ZkopirujModDoSlozkyServeru(string amxCesta)
        {
            if (!File.Exists(amxCesta)) return null;

            var vyslednaCesta = Path.Combine(cesty.Server(), "\\gamemodes\\", Path.GetFileName(amxCesta));
            File.Copy(amxCesta, vyslednaCesta);

            return vyslednaCesta;
        } 

        private void ZmenNazevModuVConfigu(string soubor)
        {
            if (soubor == null) return;

            var configCesta = Path.Combine(new Data.Soubory.Cesty().Server(), "server.cfg");

            Soubory.ZmenRadekVSouboru(configCesta, "gamemode0", 
                $"gamemode0 {Path.GetFileNameWithoutExtension(soubor)} 1");
        }
    }
}
