using System.Collections.Generic;
using System.Windows.Forms;

namespace PawnoEditor.Controls.Panels
{
    public partial class ucCompiler : UserControl
    {
        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ucCompiler"/> class.
        /// </summary>
        public ucCompiler()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Shows the errors.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public void ShowErrors(List<Base.Entities.CompilerMessageItem> errors)
        {
            gridErrors.DataSource = errors;
        }
        #endregion
    }
}
