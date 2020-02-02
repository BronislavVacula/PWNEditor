using Base.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Base.Facades
{
    public class SampServer
    {
        #region Singleton
        /// <summary>
        /// The instance
        /// </summary>
        private static SampServer mInstance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static SampServer Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new SampServer();

                return mInstance;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="SampServer"/> class from being created.
        /// </summary>
        private SampServer() { }
        #endregion

        #region Properties and fields
        /// <summary>
        /// The server directories
        /// </summary>
        private readonly string[] serverDirectories = new string[] {
            "filterscripts",
            "gamemodes",
            "npcmodes",
            "scriptfiles",
        };

        /// <summary>
        /// The server files
        /// </summary>
        private readonly string[] serverFiles = new string[]
        {
            "announce.exe",
            "samp-npc.exe",
            "samp-server.exe",
            "server.cfg"
        };
        #endregion

        #region Methods
        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <param name="gamemodePath">The gamemode path.</param>
        /// <param name="serversPath">The servers path.</param>
        /// <param name="serverName">Name of the server.</param>
        public void Run(string gamemodePath, string serversPath, string serverName = null)
        {
            if (ServerExists(serversPath, serverName))
            {
                //Copy gamemode

                //Edit config

                //Run server

                //Run SA-MP
            }
        }

        /// <summary>
        /// Servers the exists.
        /// </summary>
        /// <param name="serverVersion">The server version.</param>
        /// <returns></returns>
        public bool ServerExists(string serversPath, string serverName)
        {
            return IsValidServer(serversPath + "\\" + serverName);
        }

        /// <summary>
        /// Gets the servers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetServers(string serversPath)
        {
            List<string> servers = new List<string>();

            foreach (var directory in Directory.GetDirectories(serversPath, "*", SearchOption.TopDirectoryOnly))
            {
                if(IsValidServer(directory))
                {
                    servers.Add(new DirectoryInfo(directory).Name);
                }
            }

            return servers;
        }

        /// <summary>
        /// Determines whether [is valid server] [the specified server path].
        /// </summary>
        /// <param name="serverPath">The server path.</param>
        /// <returns>
        ///   <c>true</c> if [is valid server] [the specified server path]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValidServer(string serverPath)
        {
            foreach(var directory in serverDirectories)
            {
                if (!Directory.Exists(serverPath + "\\" + directory))
                    return false;
            }

            foreach(var file in serverFiles)
            {
                if (!File.Exists(serverPath + "\\" + file))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Builds the gamemode.
        /// </summary>
        /// <param name="compilerDirectory">The compiler directory.</param>
        /// <param name="gamemodePath">The gamemode path.</param>
        /// <returns></returns>
        public List<Entities.CompilerMessageItem> BuildGamemode(string compilerDirectory, string gamemodePath)
        {
            List<Entities.CompilerMessageItem> result = new List<Entities.CompilerMessageItem>();

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = compilerDirectory + "\\pawncc.exe",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                Arguments = gamemodePath + " " +  $"-Dpath={Path.GetDirectoryName(gamemodePath)}",
                CreateNoWindow = true,
                UseShellExecute = false,
                Verb = "runas",
            };

            using (var process = Process.Start(startInfo))
            {
                process.Start();
                process.WaitForExit();

                ProcessCompilerStream(process.StandardOutput, result);
                ProcessCompilerStream(process.StandardError, result);
            }

            return result;
        }

        /// <summary>
        /// Processes the compiler stream.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="result">The result.</param>
        private void ProcessCompilerStream(StreamReader reader, List<Entities.CompilerMessageItem> result)
        {
            var readTask = reader.ReadToEndAsync();
            readTask.Wait();

            if(readTask.IsCompleted)
            {
                var compilerResult = readTask.Result.Replace("\r", "");

                if(compilerResult != null)
                {
                    string[] lines = compilerResult.Split(Convert.ToChar("\n"));

                    foreach (var line in lines)
                    {
                        if (string.IsNullOrEmpty(line) || line == " ")
                            continue;

                        var compilerItem = new Entities.CompilerMessageItem(line);

                        if (compilerItem.LineNumber != null)
                            result.Add(compilerItem);
                    }
                }
            }
        }
        #endregion
    }
}
