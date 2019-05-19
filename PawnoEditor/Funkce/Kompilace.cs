using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace PawnoEditor.Funkce
{
    class Kompilace
    {
        Process komp_process;
        public Data.Kompilator KompilatorNastaveni { get; set; } = new Data.Kompilator();

        public string Soubor { get; set; }
        public List<string> Chyby { get; set; } = new List<string>();

        public Kompilace(string cestaSouboru)
        {
            Soubor = cestaSouboru;
            KompilatorNastaveni.WorkingDirectory = Path.GetDirectoryName(Soubor);

            komp_process = new Process
            {
                StartInfo =
                    {
                        FileName = KompilatorNastaveni.Pawncc,
                        WorkingDirectory = KompilatorNastaveni.WorkingDirectory,
                        Arguments = Soubor + " " + KompilatorNastaveni.Argumenty(),
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        Verb = "runas"
                    }
            };
        }

        private bool ZiskejChyby()
        {
            try
            {
                if (komp_process.StandardOutput.ReadToEnd().IndexOf("Error") < 0) return false;

                try
                {
                    var kompilatorVysledek = komp_process.StandardError.ReadToEnd();
                    kompilatorVysledek = new Data.Preklad().PrelozTextDoCestiny(kompilatorVysledek);

                    Chyby = kompilatorVysledek.Split(Convert.ToChar("\n")).ToList(); 
                }
                catch { }

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool Kompiluj()
        {
            komp_process.Start();
            komp_process.WaitForExit();

            return !ZiskejChyby(); 
        }

        public string VyslednySoubor()
        {
            return $"{Path.GetDirectoryName(Soubor)}\\{Path.GetFileNameWithoutExtension(Soubor)}.amx";
        }
    }
}
