using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace Base.Entities.SettingsEntities
{
    public class TextEditor
    {
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
    }
}
