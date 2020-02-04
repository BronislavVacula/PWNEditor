using PawnoEditor.Templates;
using Syncfusion.Windows.Forms;
using System;
using System.Windows.Forms;

namespace PawnoEditor.Forms.Insert
{
    public partial class fmJobGenerator : fmTemplate
    {
        #region Properties and fields
        /// <summary>
        /// The editor
        /// </summary>
        private Components.ScintillaEx mEditor;

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Base.Entities.Tools.CodeGenerator.CodeGeneratorEntity Result { get; private set; }
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="fmJobGenerator"/> class.
        /// </summary>
        /// <param name="editor">The editor.</param>
        public fmJobGenerator(Components.ScintillaEx editor)
        {
            InitializeComponent();

            mEditor = editor;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validates the content.
        /// </summary>
        /// <returns></returns>
        private bool ValidateContent()
        {
            return true;
        }

        /// <summary>
        /// Generates the code.
        /// </summary>
        /// <returns></returns>
        private Base.Entities.Tools.CodeGenerator.CodeGeneratorEntity GenerateCode()
        {
            var entity = new Base.Entities.Tools.CodeGenerator.CodeGeneratorEntity();

            return entity;
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Handles the Click event of the btnConfirm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(ValidateContent())
            {
                Result = GenerateCode();

                DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}
