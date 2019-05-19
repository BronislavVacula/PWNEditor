using System;
using System.IO;
using System.Diagnostics;

namespace PawnoEditor.Funkce
{
    class Konzole
    {
        Process konzoleProcess;

        public StreamWriter Vstup { get; set; }
        public StreamReader Vystup { get; set; }
        public StreamReader Chyby { get; set; }

        public Konzole()
        {
            konzoleProcess = new Process
            {
                StartInfo =
                    {
                        FileName = "cmd.exe",
                        Arguments = "",
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        Verb = "runas"
                    }
            };

            SpustStreamovani();
        }

        private void SpustStreamovani()
        {
            konzoleProcess.Start();

            Vstup = konzoleProcess.StandardInput;
            Vystup = konzoleProcess.StandardOutput;
            Chyby = konzoleProcess.StandardError;

            konzoleProcess.WaitForExit();
        }

        public void SpustPrikaz(string prikaz)
        {
            Vstup.WriteLine($"/C {prikaz}");
        }

        public void Dispose()
        {
            Chyby.Close();
            Vstup.Close();

            konzoleProcess.Close();
            konzoleProcess.Dispose();
        }
    }
}
