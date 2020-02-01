namespace Base.Helpers
{
    public class CompilerTranslation
    {
        #region Properties and fields
        /// <summary>
        /// The parts en
        /// </summary>
        public string[] PartsEN =
        {
            "Error",
            "error",
            "warning",
            "unreachable code",
            "invalid expression, assumed zero",
            "function",
            "is not",
            "implemented",
            "undefined"
        };

        /// <summary>
        /// The parts cs
        /// </summary>
        public string[] PartsCS =
        {
            "Chyba",
            "chyba",
            "upozornění",
            "nedosažitelný kód",
            "neplatný výraz",
            "funkce",
            "není",
            "implementována",
            "nedefinovaná"
        };
        #endregion

        #region Methods
        /// <summary>
        /// Translates the text into the czech language.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public string TranslateText(string text)
        {
            for (int i = 0; i < PartsEN.Length; i++)
            {
                text = text.Replace(PartsEN[i], PartsCS[i]);
            }

            return text;
        }
        #endregion
    }
}
