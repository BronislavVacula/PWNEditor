using Base.Enums;

namespace Base
{
    public class Settings
    {
        #region Singleton
        /// <summary>
        /// The instance
        /// </summary>
        private static Settings mInstance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Settings Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new Settings();

                return mInstance;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Settings"/> class from being created.
        /// </summary>
        private Settings() { }
        #endregion

        #region Properties and fields
        /// <summary>
        /// Gets or sets the compiler.
        /// </summary>
        /// <value>
        /// The compiler.
        /// </value>
        public Entities.SettingsEntities.CompilerSettings Compiler { get; set; } = new Entities.SettingsEntities.CompilerSettings();

        /// <summary>
        /// Gets or sets the script insert mode.
        /// </summary>
        /// <value>
        /// The script insert mode.
        /// </value>
        public ScriptInsertMode ScriptInsertMode { get; set; } = ScriptInsertMode.ScinitillaEditor;
        #endregion
    }
}
