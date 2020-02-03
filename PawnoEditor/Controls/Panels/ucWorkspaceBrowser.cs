using Base.Entities;
using System.IO;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Base.EventHandlers;
using System.Linq;

namespace PawnoEditor.Controls.Panels
{
    public partial class ucWorkspaceBrowser : UserControl
    {
        #region Properties and fields
        /// <summary>
        /// The workspace
        /// </summary>
        public Workspace workspace;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when [open file request].
        /// </summary>
        public event OpenFileRequestEventHandler OpenFileRequest = null;

        /// <summary>
        /// Called when [open file request].
        /// </summary>
        /// <param name="path">The path.</param>
        protected void OnOpenFileRequest(string path)
        {
            OpenFileRequest?.Invoke(this, new OpenFileRequestEventArgs(path));
        }

        /// <summary>
        /// Delegate for [open file request].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="OpenFileRequestEventArgs"/> instance containing the event data.</param>
        public delegate void OpenFileRequestEventHandler(object sender, OpenFileRequestEventArgs e);
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

            files.Nodes.Add(new TreeNodeAdv(name));
        }

        /// <summary>
        /// Adds the file.
        /// </summary>
        /// <param name="path">The path.</param>
        public void AddFile(string path, Components.ScintillaEx editor)
        {
            if (workspace != null)
            {
                if (workspace.CanAddFile(path))
                {
                    var createdNode
                        = files.Nodes[0].Nodes.Add(new TreeNodeAdv(Path.GetFileName(path)));

                    workspace.AddFile(files.Nodes[0].Nodes[createdNode], editor.OpenedFile);

                    if (files.Nodes[0].Nodes.Count == 1)
                    {
                        files.ExpandAll();
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the workspace.
        /// </summary>
        public void ClearWorkspace()
        {
            workspace?.Clear();
            files.Nodes.Clear();
        }

        /// <summary>
        /// Loads the workspace.
        /// </summary>
        /// <param name="workspaceToLoad">The workspace to load.</param>
        public void LoadWorkspace(Workspace workspaceToLoad)
        {
            ClearWorkspace();

            workspace = workspaceToLoad;

            files.Nodes.Add(new TreeNodeAdv(workspace.Name));

            foreach(var item in workspace.Items)
            {
                var createdNodeIndex = files.Nodes[0].Nodes.Add(new TreeNodeAdv(Path.GetFileName(item.FilePath)));

                item.Node = files.Nodes[0].Nodes[createdNodeIndex];

                if (files.Nodes[0].Nodes.Count == 1)
                {
                    files.ExpandAll();
                }
            }
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Handles the DoubleClick event of the files control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void files_DoubleClick(object sender, System.EventArgs e)
        {
            if (files.SelectedNode != null)
            {
                if (files.SelectedNode.Parent.Name != "root")
                {
                    var workspaceItem = workspace.Items.FirstOrDefault(item => item.Node == files.SelectedNode);

                    if (workspaceItem != null)
                    {
                        OnOpenFileRequest(workspaceItem.FilePath);
                    }
                }
            }
        }
        #endregion
    }
}
