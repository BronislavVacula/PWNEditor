using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace PawnoEditor.Data.NastaveniPolozky
{
    public class TextovyEditor
    {
        [XmlIgnore()]
        public Font FontTextu { get; set; } = new Font("Arial", 13f, FontStyle.Regular, GraphicsUnit.Pixel, 0, false);

        [Browsable(false)]
        public string FontSerialize
        {
            get => TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(FontTextu);
            set => FontTextu = TypeDescriptor.GetConverter(typeof(Font)).ConvertFromInvariantString(value) as Font;
        }
    }
}
