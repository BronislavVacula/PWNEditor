using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;
using Syncfusion.Windows.Forms.Tools;

namespace PawnoEditor.Controls.Panels
{
    public partial class ucSkinList : UserControl
    {
        #region Properties and fields
        /// <summary>
        /// The skin directory
        /// </summary>
        private readonly string skinDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Images\\Skins\\";
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ucSkinList"/> class.
        /// </summary>
        public ucSkinList()
        {
            InitializeComponent();
            LoadContent();
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        private void LoadContent()
        {
            var files = Directory.GetFiles(skinDirectory);

            skins.Nodes.AddRange((from skin in files select new TreeNodeAdv(Path.GetFileNameWithoutExtension(skin))).ToArray());

            SelectFirstNode();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Selects the first node.
        /// </summary>
        private void SelectFirstNode()
        {
            if (skins.Nodes.Count > 0)
            {
                skins.SelectedNode = skins.Nodes[0];
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
            if (skins.SelectedNode != null)
            {
                skinImage.Image = Image.FromFile(skinDirectory + "\\" + skins.SelectedNode.Text + ".jpg");
            }
        }
        #endregion
    }
}
