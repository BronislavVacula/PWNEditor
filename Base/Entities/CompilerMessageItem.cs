using System;
using System.Text.RegularExpressions;

namespace Base.Entities
{
    public class CompilerMessageItem
    {
        #region Properties and fields
        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        /// <value>
        /// The line number.
        /// </value>
        public string LineNumber { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; } = "";

        /// <summary>
        /// The success
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; private set; } = false;
        #endregion

        #region Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerMessageItem" /> class.
        /// </summary>
        /// <param name="lineText">The line text.</param>
        public CompilerMessageItem(string lineText)
        {
            if (string.IsNullOrEmpty(lineText)) 
                return;

            string[] parameters = SplitCompilerLineIntoParameters(lineText);

            if (parameters != null && parameters.Length > 2)
            {
                if (parameters[0].IndexOf("(") > -1)
                {
                    LineNumber = parameters[0].Split(Convert.ToChar("("), Convert.ToChar(")"))[1];
                    Text = $"{parameters[1]} - {parameters[2]}";

                    Success = true;
                }
            }
        }

        /// <summary>
        /// Splits the compiler line into parameters.
        /// </summary>
        /// <returns></returns>
        private string[] SplitCompilerLineIntoParameters(string line)
        {
            try
            {
                return Regex.Split(line, ": ");
            }
            catch { return null; }
        }
        #endregion
    }
}
