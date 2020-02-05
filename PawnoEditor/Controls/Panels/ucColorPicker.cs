using System.Windows.Forms;

namespace PawnoEditor.Controls.Panels
{
    public partial class ucColorPicker : UserControl
    {
        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ucColorPicker"/> class.
        /// </summary>
        public ucColorPicker()
        {
            InitializeComponent();
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Handles the Picked event of the colorPicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv.ColorPickedEventArgs"/> instance containing the event data.</param>
        private void colorPicker_Picked(object sender, Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv.ColorPickedEventArgs args)
        {
            txtColor.Text = "0x" + Base.Helpers.ColorHelper.ConvertToHex(args.Color);
        }
        #endregion
    }
}
