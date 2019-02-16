using System;
using System.Drawing;
using System.Windows.Forms;

namespace Warlock.Themes.FlatUI
{
    class FlatStatusStrip : StatusStrip
    {
        public Color BGColor { get; set; } = Color.FromArgb(45, 47, 49);

        public FlatStatusStrip() : base()
        {
            Font = new Font("Segoe UI", 10);
            BackColor = BGColor;
            ForeColor = Color.White;
        }
    }
}
