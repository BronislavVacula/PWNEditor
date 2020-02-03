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
        public void LoadIncludes(TreeViewAdv treeView, string includeDirectory)
        {
            string[] files = null;

            try
            {
                files = Directory.GetFiles(includeDirectory, "*.inc", SearchOption.AllDirectories);
            }
            catch { }

            if (files != null)
            {
                foreach (var file in files)
                {
                    var includeName = new TreeNodeAdv(Path.GetFileName(file));
                    treeView.Nodes.Add(includeName);

                    LoadMethods(includeName, file);
                }
            }
        }

        /// <summary>
        /// Resolves the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="filePath">The file path.</param>
        private void LoadMethods(TreeNodeAdv node, string filePath)
        {
            string[] lines = null;

            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch { }

            if (lines != null)
            {
                foreach (var line in lines)
                {
                    if (line.StartsWith("native "))
                    {
                        TreeNodeAdv methodName = new TreeNodeAdv(line.Replace("native ", ""));
                        node.Nodes.Add(methodName);
                    }
                }
            }
        }
    }
}
