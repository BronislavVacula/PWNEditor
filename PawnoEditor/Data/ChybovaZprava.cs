using System;
using System.Text.RegularExpressions;

namespace PawnoEditor.Data
{
    class ChybovaZprava
    {
        public string Radek { get; set; } = "0";
        public string Text { get; set; } = "";
        public bool UspesnePrevedeno = false;

        public ChybovaZprava(string chybovaHlaska)
        {
            if (chybovaHlaska == null || chybovaHlaska == "") return;

            var rozdeleni = Regex.Split(chybovaHlaska, ": ");
            if (rozdeleni[0].IndexOf("(") < 0) return;

            Radek = ZiskejRadekNakteremJeChyba(rozdeleni);
            Text = ZiskejTextChyby(rozdeleni);

            UspesnePrevedeno = true;
        }

        private string ZiskejRadekNakteremJeChyba(string[] rozdeleni) => rozdeleni[0].Split(Convert.ToChar("("), Convert.ToChar(")"))[1];
        private string ZiskejTextChyby(string[] rozdelenyRadek) => $"{rozdelenyRadek[1]} - {rozdelenyRadek[2]}";
    }
}
