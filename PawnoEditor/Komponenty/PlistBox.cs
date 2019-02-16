using System;
using System.Drawing;
using System.Windows.Forms;

namespace PawnoEditor.Komponenty
{
    class PlistBox : ListBox
    {
        public PlistBox()
        {
            BorderStyle = BorderStyle.None;

            BackColor = Color.FromArgb(45, 47, 49);
            ForeColor = Color.White;

            Font = new Font("Segoe UI", 10);
        }
    }
}
