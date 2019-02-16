using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    class FlatMenu : MenuStrip
    {
        public FlatMenu()
        {
            Renderer = new ToolStripProfessionalRenderer(new TColorTable());

            BackColor = Color.FromArgb(45, 47, 49);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 8);
        }

        public class TColorTable : ProfessionalColorTable
        {
            [Category("Colors")]
            public Color BackColor { get; set; } = Color.FromArgb(45, 47, 49);

            [Category("Colors")]
            public Color CheckedColor { get; set; } = Helpers.Main.FlatColor;

            [Category("Colors")]
            public Color BorderColor { get; set; } = Color.FromArgb(53, 58, 60);

            public override Color MenuItemSelectedGradientBegin
            {
                get { return BackColor; }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get { return BackColor; }
            }
            
            public override Color MenuItemPressedGradientBegin
            {
                get { return BackColor; }
            }

            public override Color MenuItemPressedGradientMiddle
            {
                get { return BackColor; }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return BackColor; }
            }

            public override Color ButtonCheckedGradientBegin
            {
                get { return Color.Transparent; }
            }

            public override Color ButtonCheckedGradientMiddle
            {
                get { return Color.Transparent; }
            }

            public override Color ButtonCheckedGradientEnd
            {
                get { return Color.Transparent; }
            }

            public override Color ToolStripPanelGradientBegin
            {
                get { return BackColor; }
            }

            public override Color ToolStripPanelGradientEnd
            {
                get { return BackColor; }
            }

            public override Color ButtonSelectedBorder
            {
                get { return BackColor; }
            }

            public override Color CheckBackground
            {
                get { return CheckedColor; }
            }

            public override Color CheckPressedBackground
            {
                get { return CheckedColor; }
            }

            public override Color CheckSelectedBackground
            {
                get { return CheckedColor; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return CheckedColor; }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return CheckedColor; }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return CheckedColor; }
            }

            public override Color MenuBorder
            {
                get { return BorderColor; }
            }

            public override Color MenuItemBorder
            {
                get { return BorderColor; }
            }

            public override Color MenuItemSelected
            {
                get { return CheckedColor; }
            }

            public override Color SeparatorDark
            {
                get { return BorderColor; }
            }

            public override Color ToolStripDropDownBackground
            {
                get { return BackColor; }
            }
        }
    }
}
