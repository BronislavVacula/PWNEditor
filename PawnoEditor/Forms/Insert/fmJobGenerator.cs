using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PawnoEditor.Forms.Insert
{
    public partial class fmJobGenerator : MetroForm
    {
        #region Properties and fields
        /// <summary>
        /// The editor
        /// </summary>
        private Components.ScintillaEx mEditor;

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public string Result { get; private set; }
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="fmJobGenerator"/> class.
        /// </summary>
        /// <param name="editor">The editor.</param>
        public fmJobGenerator(Components.ScintillaEx editor)
        {
            InitializeComponent();

            mEditor = editor;
        }
        #endregion
    }
}
