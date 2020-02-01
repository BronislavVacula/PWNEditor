using Syncfusion.Windows.Forms.Tools;
using System.IO;

namespace Base.Classes
{
    public class IncludeResolver
    {
        /// <summary>
        /// Resolves the specified tree view.
        /// </summary>
        /// <param name="treeView">The tree view.</param>
        /// <param name="includeDirectory">The include directory.</param>
        public void Resolve(TreeViewAdv treeView, string includeDirectory)
        {
            var files = Directory.GetFiles(includeDirectory, "*.inc", SearchOption.AllDirectories);

            foreach(var file in files)
            {
                TreeNodeAdv includeName = new TreeNodeAdv(Path.GetFileName(file));
                treeView.Nodes.Add(includeName);

                Resolve(includeName, file);
            }
        }

        /// <summary>
        /// Resolves the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="filePath">The file path.</param>
        private void Resolve(TreeNodeAdv node, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach(var line in lines)
            {
                if(line.StartsWith("native "))
                {
                    TreeNodeAdv methodName = new TreeNodeAdv(line.Replace("native ", ""));
                    node.Nodes.Add(methodName);
                }
            }
        }
    }
}
