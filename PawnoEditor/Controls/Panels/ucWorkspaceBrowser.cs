using Base.Entities;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Controls.Panels
{
    public partial class ucWorkspaceBrowser : UserControl
    {
        #region Properties and fields
        /// <summary>
        /// The workspace
        /// </summary>
        private Workspace workspace;
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ucWorkspaceBrowser"/> class.
        /// </summary>
        public ucWorkspaceBrowser()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the workspace.
        /// </summary>
        /// <param name="name">The name.</param>
        public void CreateWorkspace(string name)
        {
            files.Nodes.Clear();

            workspace = new Workspace()
            {
                Name = name,
            };

            files.Nodes.Add(new Syncfusion.Windows.Forms.Tools.TreeNodeAdv(name));
        }

        /// <summary>
        /// Adds the file.
        /// </summary>
        /// <param name="path">The path.</param>
        public void AddFile(string path, Components.ScintillaEx editor)
        {
            if (workspace != null)
            {
                var createdNode
                    = files.Nodes[0].Nodes.Add(new Syncfusion.Windows.Forms.Tools.TreeNodeAdv(Path.GetFileName(path)));

                workspace.AddFile(editor, files.Nodes[0].Nodes[createdNode]);

                if(files.Nodes[0].Nodes.Count == 1)
                {
                    files.ExpandAll();
                }
            }
        }

        /// <summary>
        /// Deletes the workspace.
        /// </summary>
        public void ClearWorkspace()
        {
            workspace?.Clear();
        }
        #endregion

        #region Event handlers
        #endregion
    }
}
