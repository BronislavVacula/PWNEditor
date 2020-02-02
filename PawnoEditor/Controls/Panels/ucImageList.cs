using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;
using Syncfusion.Windows.Forms.Tools;

namespace PawnoEditor.Controls.Panels
{
    public partial class ucImageList : UserControl
    {
        #region Properties and fields
        /// <summary>
        /// The skin directory
        /// </summary>
        private readonly string imagesDirectory;
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ucImageList"/> class.
        /// </summary>
        public ucImageList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ucImageList"/> class.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        public ucImageList(string itemName) : this()
        {
            imagesDirectory = Path.GetDirectoryName(Application.ExecutablePath) + $"\\Images\\{itemName}\\";

            LoadContent();
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        private void LoadContent()
        {
            if (Directory.Exists(imagesDirectory))
            {
                var files = Directory.GetFiles(imagesDirectory);

                images.Nodes.AddRange((from file in files select new TreeNodeAdv(Path.GetFileNameWithoutExtension(file))).ToArray());

                SelectFirstNode();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Selects the first node.
        /// </summary>
        private void SelectFirstNode()
        {
            if (images.Nodes.Count > 0)
            {
                images.SelectedNode = images.Nodes[0];
            }
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Handles the AfterSelect event of the skins control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void skins_AfterSelect(object sender, EventArgs e)
        {
            if (images.SelectedNode != null)
            {
                itemImage.Image = Image.FromFile(imagesDirectory + "\\" + images.SelectedNode.Text + ".jpg");
            }
        }
        #endregion
    }
}
