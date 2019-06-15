using System;
using System.IO;
using System.Diagnostics;

namespace PawnoEditor.Funkce.Hra
{
    class Spoustec
    {
        Process hraProcess, serverProcess;

        public Spoustec()
        {
            InitializujProcessServeru();
            InitializujHerniProcess();
        }

        private void InitializujHerniProcess()
        {
            hraProcess = new Process
            {
                StartInfo =
                    {
                        FileName = "cesta k .exe samp",
                        Arguments = "-c -h121.0.0.1 -nTest",
                        CreateNoWindow = false,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        Verb = "runas"
                    }
            };
        }

        private void InitializujProcessServeru()
        {
            serverProcess = new Process
            {
                StartInfo =
                    {
                        FileName = Path.Combine(new Data.Soubory.Cesty().Server(), "samp-server.exe"),
                        Arguments = "",
                        CreateNoWindow = false,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        Verb = "runas"
                    }
            };
        }

        public void SpustMod()
        {
            serverProcess.Start();
            hraProcess.Start();
        }

        public void Dispose()
        {
            hraProcess.Close();
            serverProcess.Close();
        }
    }
}
