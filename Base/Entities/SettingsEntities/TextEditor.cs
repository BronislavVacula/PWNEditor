using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace Base.Entities.SettingsEntities
{
    public class TextEditor
    {
        #region Main editor styles
        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>
        /// The color of the text.
        /// </value>
        public Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>
        /// The color of the background.
        /// </value>
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the selection back ground.
        /// </summary>
        /// <value>
        /// The color of the selection back ground.
        /// </value>
        public Color SelectionBackGroundColor { get; set; }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The font.
        /// </value>
        [XmlIgnore()]
        public Font Font { get; set; } = new Font("Arial", 13f, FontStyle.Regular, GraphicsUnit.Pixel, 0, false);

        /// <summary>
        /// Gets or sets the font information.
        /// </summary>
        /// <value>
        /// The font information.
        /// </value>
        [Browsable(false)]
        public string FontInfo
        {
            get => TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(Font);
            set => Font = TypeDescriptor.GetConverter(typeof(Font)).ConvertFromInvariantString(value) as Font;
        }
        #endregion

        #region Caret
        /// <summary>
        /// Gets or sets the color of the caret text.
        /// </summary>
        /// <value>
        /// The color of the caret text.
        /// </value>
        public Color CaretForeColor { get; set; }
        #endregion

        #region Syntax
        #endregion

        #region Line number style
        /// <summary>
        /// Gets or sets the color of the line number text.
        /// </summary>
        /// <value>
        /// The color of the line number text.
        /// </value>
        public Color LineNumberForeColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the line number background.
        /// </summary>
        /// <value>
        /// The color of the line number background.
        /// </value>
        public Color LineNumberBackColor { get; set; }
        #endregion
    }
}
