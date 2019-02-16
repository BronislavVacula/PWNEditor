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

        private string NastaveniSoubor()
        {
            return new Data.Soubory.Cesty().app_slozka + "\\Nastaveni.xml";
        }

        public void UlozNastaveni(Data.Nastaveni nastaveni)
        {
            using (TextWriter tw = new StreamWriter(NastaveniSoubor()))
                serializer.Serialize(tw, nastaveni);
        }

        public void NactiNastaveni(Data.Nastaveni nastaveni)
        {
            using (var sr = new StreamReader(NastaveniSoubor()))
                nastaveni = (Data.Nastaveni)serializer.Deserialize(sr);
        }
    }
}
