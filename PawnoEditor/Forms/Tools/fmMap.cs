using Syncfusion.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Forms.Tools
{
    public partial class fmMap : Syncfusion.Windows.Forms.Tools.RibbonForm
    {
        #region Properties and fields
        /// <summary>
        /// The editor
        /// </summary>
        private readonly Components.ScintillaEx mEditor;
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="fmMap"/> class.
        /// </summary>
        public fmMap()
        {
            InitializeComponent();
            InitMap();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="fmMap"/> class.
        /// </summary>
        /// <param name="editor">The editor.</param>
        public fmMap(Components.ScintillaEx editor) : this()
        {
            mEditor = editor;
        }

        /// <summary>
        /// Initializes the map.
        /// </summary>
        private void InitMap()
        {
            try
            {
                map.Load(Path.GetDirectoryName(Application.ExecutablePath) + Base.Constants.EditorPaths.images + "\\radar.jpg");
            }
            catch 
            {
                MessageBoxAdv.Show("Cant load map image.");
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the map cords from mouse position.
        /// </summary>
        /// <param name="mousePosition">The mouse position.</param>
        private Base.Entities.Tools.MapCords GetLocationFromMousePosition(Point mousePosition)
        {
            return new Base.Entities.Tools.MapCords()
            {
                X = (mousePosition.X - 320) * 9.375f,
                Y = (mousePosition.Y - 320) * 9.375f * -1,
                Z = 0,
            };
        }
        #endregion
    }
}
