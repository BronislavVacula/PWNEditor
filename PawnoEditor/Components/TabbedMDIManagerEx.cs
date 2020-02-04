using Syncfusion.Windows.Forms.Tools;
using System.ComponentModel;
using System.Windows.Forms;

namespace PawnoEditor.Components
{
    public class TabbedMDIManagerEx : TabbedMDIManager
    {
        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="TabbedMDIManagerEx"/> class.
        /// </summary>
        /// <param name="container"></param>
        public TabbedMDIManagerEx(IContainer container) : base(container)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Closes all opened tabs.
        /// </summary>
        public void CloseAllOpenedTabs()
        {
            foreach (var form in MdiChildren)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is ScintillaEx editor)
                    {
                        editor.Dispose();
                    }
                }

                form.Close();
            }
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
            foreach (var form in MdiChildren)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is ScintillaEx editor)
                    {
                        if (editor.OpenedFile == filePath)
                            return true;
                    }
                }
            }

            return false;
        }
        #endregion
    }
}
