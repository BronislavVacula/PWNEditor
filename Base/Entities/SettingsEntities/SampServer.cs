namespace Base.Entities.SettingsEntities
{
    public class SampServer
    {
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
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language { get; set; } = "English";
    }
}
