using Syncfusion.Windows.Forms.Tools;
using System.Xml.Serialization;

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
        [XmlIgnore()]
        public TreeNodeAdv Node { get; set; }
    }
}
