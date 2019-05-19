using System;
using System.Collections.Generic;
using System.IO;

namespace PawnoEditor.Funkce.Parsovani
{
    class PNativeFunkce
    {
        StreamReader reader;
        private string radek = "";

        public PNativeFunkce(string cesta)
        {
            reader = new StreamReader(cesta);
        }

        private bool ParsovaniZaznamu(string radek, List<string> ulozeni)
        {
            var native = radek.IndexOf("native") + 6;
            if (native < 6) return false;

            ulozeni.Add(radek.Substring(native, radek.Length - native));
            return true;
        }

        public List<string> Seznam()
        {
            List<string> funkce = new List<string>();
        
            if (reader == null) return funkce;

            while ((radek = reader.ReadLine()) != null)
                ParsovaniZaznamu(radek, funkce);

            return funkce;
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}
