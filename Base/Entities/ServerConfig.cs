using System;
using System.Collections.Generic;

namespace Base.Entities
{
    public class ServerConfig : SettingsEntities.SampServer
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
        /// Gets or sets the log time format.
        /// </summary>
        /// <value>
        /// The log time format.
        /// </value>
        public string LogTimeFormat { get; set; } = "[%H:%M:%S]";
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
