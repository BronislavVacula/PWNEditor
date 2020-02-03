using System;
using System.Collections.Generic;

namespace Base.Entities
{
    public class ServerConfig
    {
        #region Properties and fields
        /// <summary>
        /// Gets or sets the echo.
        /// </summary>
        /// <value>
        /// The echo.
        /// </value>
        public string Echo { get; set; } = "Executing Server Config...";

        /// <summary>
        /// Gets or sets a value indicating whether [lan mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [lan mode]; otherwise, <c>false</c>.
        /// </value>
        public bool LanMode { get; set; } = false;

        /// <summary>
        /// Gets or sets the rcon password.
        /// </summary>
        /// <value>
        /// The rcon password.
        /// </value>
        public string Rcon_password { get; set; } = "testing";

        /// <summary>
        /// Gets or sets the maximum players.
        /// </summary>
        /// <value>
        /// The maximum players.
        /// </value>
        public int MaxPlayers { get; set; } = 50;

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; set; } = 7777;

        /// <summary>
        /// Gets or sets the hostname.
        /// </summary>
        /// <value>
        /// The hostname.
        /// </value>
        public string Hostname { get; set; } = "SA-MP 0.3 Server";

        /// <summary>
        /// Gets or sets the gamemode.
        /// </summary>
        /// <value>
        /// The gamemode.
        /// </value>
        public string Gamemode0 { get; set; }

        /// <summary>
        /// Gets or sets the filterscripts.
        /// </summary>
        /// <value>
        /// The filterscripts.
        /// </value>
        public List<string> Filterscripts { get; set; } = new List<string>()
        {
            { "gl_actions" },
            { "gl_realtime" },
            { "gl_property" },
            { "gl_mapicon" },
            { "ls_elevator" },
            { "attachments" },
            { "skinchanger" },
            { "vspawner" },
            { "ls_mall" },
            { "ls_beachside" },
        };

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ServerConfig"/> is announce.
        /// </summary>
        /// <value>
        ///   <c>true</c> if announce; otherwise, <c>false</c>.
        /// </value>
        public bool Announce { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether [chat logging].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [chat logging]; otherwise, <c>false</c>.
        /// </value>
        public bool ChatLogging { get; set; } = false;

        /// <summary>
        /// Gets or sets the web URL.
        /// </summary>
        /// <value>
        /// The web URL.
        /// </value>
        public string WebURL { get; set; } = "www.sa-mp.com";

        /// <summary>
        /// Gets or sets the on foot rate.
        /// </summary>
        /// <value>
        /// The on foot rate.
        /// </value>
        public int OnFoot_Rate { get; set; } = 40;

        /// <summary>
        /// Gets or sets the in car rate.
        /// </summary>
        /// <value>
        /// The in car rate.
        /// </value>
        public int InCar_Rate { get; set; } = 40;

        /// <summary>
        /// Gets or sets the weapon rate.
        /// </summary>
        /// <value>
        /// The weapon rate.
        /// </value>
        public int Weapon_Rate { get; set; } = 40;

        /// <summary>
        /// Gets or sets the stream distance.
        /// </summary>
        /// <value>
        /// The stream distance.
        /// </value>
        public int Stream_Distance { get; set; } = 300;

        /// <summary>
        /// Gets or sets the stream rate.
        /// </summary>
        /// <value>
        /// The stream rate.
        /// </value>
        public int Stream_Rate { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the maximum NPC.
        /// </summary>
        /// <value>
        /// The maximum NPC.
        /// </value>
        public int MaxNPC { get; set; } = 0;

        /// <summary>
        /// Gets or sets the log time format.
        /// </summary>
        /// <value>
        /// The log time format.
        /// </value>
        public string LogTimeFormat { get; set; } = "[%H:%M:%S]";

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language { get; set; } = "English";
        #endregion

        #region Methods
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string result = "";
            var properties = typeof(ServerConfig).GetProperties();
            bool isFirst = true;

            foreach(var property in properties)
            {
                if (!isFirst)
                    result += Environment.NewLine;

                if(property.PropertyType == typeof(string) || property.PropertyType == typeof(int))
                {
                    result += property.Name.ToLower() + " " + property.GetValue(this).ToString();
                }
                else if(property.PropertyType == typeof(bool))
                {
                    result += property.Name.ToLower() + " " + Convert.ToInt32(property.GetValue(this));
                }
                else if(property.PropertyType == typeof(List<string>))
                {
                    List<string> values = property.GetValue(this) as List<string>;

                    result += property.Name.ToLower() + " " + string.Join(" ", values.ToArray());
                }

                isFirst = false;
            }

            return result;
        }
        #endregion
    }
}
