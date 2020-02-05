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
        /// Initializes a new instance of the <see cref="CompilerMessageItem"/> class.
        /// </summary>
        public CompilerMessageItem() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerMessageItem" /> class.
        /// </summary>
        /// <param name="lineText">The line text.</param>
        public CompilerMessageItem(string lineText)
        {
            if (string.IsNullOrEmpty(lineText)) 
                return;

            var secondColonPosition = lineText.IndexOf(" :");

            if(secondColonPosition > -1)
            {
                LineNumber = lineText.Split('(', ')')[1];
                Text = lineText.Substring(secondColonPosition + 2);

                if (Text.StartsWith(" "))
                    Text = Text.Substring(1);
            }
        }
        #endregion
    }
}
