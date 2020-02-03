using Base.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace Base.Entities
{
    public class WorkspaceItem
    {
        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>
        /// The node.
        /// </value>
        public TreeNodeAdv Node { get; set; }

        /// <summary>
        /// Gets or sets the editor.
        /// </summary>
        /// <value>
        /// The editor.
        /// </value>
        public IEditor Editor { get; set; }
    }
}
