using System;
using System.Drawing;
using System.Windows.Forms;

namespace Warlock.Themes.FlatUI
{
    class FlatToolStrip : ToolStrip
    {
        public Color BGColor { get; set; } = Color.FromArgb(45, 47, 49);

        public FlatToolStrip() : base()
        {
            BackColor = BGColor;
            ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
