using System;
using System.IO;
using System.Xml.Serialization;

namespace PawnoEditor.Funkce
{
    class XML
    {
        private XmlSerializer serializer;

        public XML()
        {
            serializer = new XmlSerializer(typeof(Data.Nastaveni));
        }

        private string NastaveniSoubor() => new Data.Soubory.Cesty().App_slozka + "\\Nastaveni.xml";

        public void UlozNastaveni(Data.Nastaveni nastaveni)
        {
            using (TextWriter tw = new StreamWriter(NastaveniSoubor()))
                serializer.Serialize(tw, nastaveni);
        }

        public void NactiNastaveni(Data.Nastaveni nastaveni)
        {
            if (!File.Exists(NastaveniSoubor()))
            {
                UlozNastaveni(nastaveni);
                return;
            }

            using (var sr = new StreamReader(NastaveniSoubor()))
                nastaveni = (Data.Nastaveni)serializer.Deserialize(sr);
        }
    }
}
