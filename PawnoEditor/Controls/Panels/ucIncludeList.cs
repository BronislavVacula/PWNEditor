using Base.Classes;
using Base.EventHandlers;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Controls.Panels
{
    public partial class ucIncludeList : UserControl
    {
        #region Properties and fields
        /// <summary>
        /// The resolver
        /// </summary>
        private readonly IncludeResolver resolver = new IncludeResolver();
        #endregion

        #region Events
        /// <summary>
        /// Occurs when [insert include request].
        /// </summary>
        public event InsertIncludeRequestEventHandler InsertIncludeRequest = null;

        /// <summary>
        /// Called when [insert include request].
        /// </summary>
        /// <param name="include">The include.</param>
        protected void OnInsertIncludeRequest(string include)
        {
            InsertIncludeRequest?.Invoke(this, new InsertIncludeRequestEventArgs(include));
        }

        /// <summary>
        /// Delegate for [insert include request].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="InsertIncludeRequestEventArgs"/> instance containing the event data.</param>
        public delegate void InsertIncludeRequestEventHandler(object sender, InsertIncludeRequestEventArgs e);
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ucIncludeList"/> class.
        /// </summary>
        public ucIncludeList()
        {
            InitializeComponent();
            RefreshIncludeList();
        }

        /// <summary>
        /// Initializes the include list.
        /// </summary>
        private void RefreshIncludeList()
        {
            if (includes.Nodes.Count > 0)
            {
                includes.Nodes.Clear();
            }

            resolver.Resolve(includes, Path.GetDirectoryName(Application.ExecutablePath) + "\\Includes\\");
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Handles the DoubleClick event of the includes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void includes_DoubleClick(object sender, System.EventArgs e)
        {
            if (includes.SelectedNode != null && includes.SelectedNode.Parent.Text != "root")
            {
                if (includes.SelectedNode.Text.Length > 1)
                {
                    OnInsertIncludeRequest(includes.SelectedNode.Text);
                }
            }
        }
        #endregion
    }
}
