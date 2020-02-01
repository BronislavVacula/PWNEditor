using System;
using System.Windows.Forms;
using Base.Classes;
using System.IO;

namespace PawnoEditor.Controls.Panels
{
    public partial class ucIncludeList : UserControl
    {
        #region Properties and fields
        /// <summary>
        /// The resolver
        /// </summary>
        IncludeResolver resolver = new IncludeResolver();
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ucIncludeList"/> class.
        /// </summary>
        public ucIncludeList()
        {
            InitializeComponent();
            InitIncludeList();
        }

        /// <summary>
        /// Initializes the include list.
        /// </summary>
        private void InitIncludeList()
        {
            resolver.Resolve(includes, Path.GetDirectoryName(Application.ExecutablePath) + "\\Includes\\");
        }
        #endregion
    }
}
