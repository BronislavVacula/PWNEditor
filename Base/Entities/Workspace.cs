using Base.Interfaces;
using Syncfusion.Windows.Forms.Tools;
using System.Collections.Generic;
using System.Linq;

namespace Base.Entities
{
    public class Workspace
    {
        #region Properties and fields
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the directory.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public string Directory { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public List<WorkspaceItem> Items { get; private set; } = new List<WorkspaceItem>();
        #endregion

        #region Methods
        /// <summary>
        /// Adds the file.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <param name="node">The node.</param>
        public void AddFile(IEditor editor, TreeNodeAdv node)
        {
            Items.Add(new WorkspaceItem()
            {
                FilePath = editor.OpenedFile,
                Editor = editor,
                Node = node,
            });
        }

        /// <summary>
        /// Determines whether this instance [can add file] the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can add file] the specified file path; otherwise, <c>false</c>.
        /// </returns>
        public bool CanAddFile(string filePath)
        {
            return Items.FirstOrDefault(item => item.FilePath == filePath) == null;
        }

        /// <summary>
        /// Removes the file.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <param name="node">The node.</param>
        public void RemoveFile(IEditor editor, TreeNodeAdv node)
        {
            var foundItem = Items.FirstOrDefault(item => item.Editor == editor && item.Node == node);

            if (foundItem != null)
            {
                Items.Remove(foundItem);
            }
        }

        /// <summary>
        /// Updates the file.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <param name="oldPath">The old path.</param>
        /// <param name="newPath">The new path.</param>
        public void UpdateFile(IEditor editor, string oldPath, string newPath)
        {
            var foundItem = Items.FirstOrDefault(item => item.Editor == editor && item.FilePath == oldPath);

            if (foundItem != null)
            {
                foundItem.FilePath = newPath;
            }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            Items.Clear();
        }
        #endregion
    }
}
