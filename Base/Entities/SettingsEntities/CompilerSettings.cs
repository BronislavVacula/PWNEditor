namespace Base.Entities.SettingsEntities
{
    public class CompilerSettings
    {
        #region Properties and fields
        /// <summary>
        /// Gets or sets path of the pawncc.
        /// </summary>
        /// <value>
        /// The pawncc.
        /// </value>
        public string PawnccFilePath { get; set; } = "pawncc.exe";

        /// <summary>
        /// Gets or sets the include directory.
        /// </summary>
        /// <value>
        /// The include directory.
        /// </value>
        public string IncludeDirectory { get; set; } = "\\include";

        /// <summary>
        /// Gets or sets the working directory.
        /// </summary>
        /// <value>
        /// The working directory.
        /// </value>
        public string WorkingDirectory { get; set; } = "";
        #endregion

        #region Methods
        /// <summary>
        /// Converts to string (compiler arguments).
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"-Dpath={WorkingDirectory}";
        }
        #endregion
    }
}
