using Syncfusion.Windows.Forms.Tools;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PawnoEditor.Komponenty
{
    public class TabControlEx : TabControlAdv
    {
        #region Properties and fields
        /// <summary>
        /// Gets or sets the automatic complete menu.
        /// </summary>
        /// <value>
        /// The automatic complete menu.
        /// </value>
        public AutocompleteMenuNS.AutocompleteMenu AutoCompleteMenu { get; set; }

        /// <summary>
        /// Gets or sets the bookmarks menu.
        /// </summary>
        /// <value>
        /// The bookmarks menu.
        /// </value>
        public ContextMenuStrip BookmarksMenu { get; set; } = null;
        #endregion

        #region Methods
        /// <summary>
        /// Creates new editor.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void NewDocument(string filePath)
        {
            var editor = new ScintillaEx()
            {
                Parent = CreateBookMark(filePath),
                AutoComplete = AutoCompleteMenu,
                Dock = DockStyle.Fill,
            };

            editor.OpenFile(filePath);
        }

        /// <summary>
        /// Creates the book mark.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private TabPage CreateBookMark(string filePath)
        {
            TabPage bookmark = new TabPage(Path.GetFileName(filePath));
            TabPages.Add(bookmark);

            return bookmark;
        }

        /// <summary>
        /// Determines whether [is file already opened] [the specified file path].
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        ///   <c>true</c> if [is file already opened] [the specified file path]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFileAlreadyOpened(string filePath)
        {
            if (Base.Helpers.Paths.Instance.IsFileTemplate(filePath))
            {
                return false;
            }

            if(TabPages.Count > 0)
            {
                foreach(TabPage tabPage in TabPages)
                {
                    if(tabPage.Controls.Count > 0 && tabPage.Controls[0] is ScintillaEx editor)
                    {
                        if(editor.OpenedFile == filePath)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Updates the size of the item.
        /// </summary>
        public void UpdateItemSize()
        {
            if(TabCount > 0) 
                ItemSize = new Size(100, 25);
        }

        /// <summary>
        /// Closes the bookmark.
        /// </summary>
        /// <param name="tabPage">The tab page.</param>
        public void CloseBookmark(TabPage tabPage)
        {
            if (tabPage.Controls.Count > 0 && tabPage.Controls[0] is ScintillaEx editor)
            {
                editor.Dispose();
            }

            TabPages.Remove(tabPage);
        }

        /// <summary>
        /// Closes all bookmarks.
        /// </summary>
        public void CloseAllBookmarks()
        {
            foreach (TabPage tabPage in TabPages)
            {
                if(tabPage.Controls.Count > 0 && tabPage.Controls[0] is ScintillaEx editor)
                {
                    editor.Dispose();
                }
            }

            RemoveAll();
        }
        #endregion
    }
}
