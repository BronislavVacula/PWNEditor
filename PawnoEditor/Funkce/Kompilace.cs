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

        public string Soubor { get; set; } = "";
        public List<string> Chyby { get; set; } = new List<string>();

        public Kompilace()
        {
            komp_process = new Process
            {
                StartInfo =
                    {
                        FileName = KompilatorNastaveni.Pawncc,
                        WorkingDirectory = KompilatorNastaveni.WorkingDirectory,
                        Arguments = KompilatorNastaveni.Argumenty,
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
                Chyby = komp_process.StandardOutput.ReadToEnd().Split(Convert.ToChar("\n")).ToList();
                return false;
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

            return ZiskejChyby();
        }

        public string VyslednySoubor()
        {
            return $"{Path.GetDirectoryName(Soubor)}\\{Path.GetFileNameWithoutExtension(Soubor)}.amx";
        }
    }
}
