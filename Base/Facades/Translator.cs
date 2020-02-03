using System.Xml;
using System.Windows.Forms;
using System;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Base.Facades
{
    public class Translator
    {
        #region Singleton
        /// <summary>
        /// The instance
        /// </summary>
        private static Translator mInstance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Translator Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new Translator();

                return mInstance;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Translator"/> class from being created.
        /// </summary>
        private Translator() { }
        #endregion

        #region Methods
        /// <summary>
        /// Translates the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public string TranslateText(string text)
        {
            return text;
        }

        /// <summary>
        /// Translates the control.
        /// </summary>
        /// <param name="control">The control.</param>
        public void TranslateControl(Control control)
        {

        }

        /// <summary>
        /// Translates the controls.
        /// </summary>
        /// <param name="Controls">The controls.</param>
        public void TranslateControls(Control.ControlCollection Controls)
        {
            foreach(Control control in Controls)
            {
                TranslateControl(control);
            }
        }
        #endregion
    }
}
