using System;
using System.ComponentModel;
using System.Drawing;
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
            public Color CheckedColor { get; set; } = Helpers.FlatColors.Instance().Flat;

            [Category("Colors")]
            public Color BorderColor { get; set; } = Color.FromArgb(53, 58, 60);

            public override Color MenuItemSelectedGradientBegin => BackColor;
            public override Color MenuItemSelectedGradientEnd => BackColor;
            public override Color MenuItemPressedGradientBegin => BackColor;
            public override Color MenuItemPressedGradientMiddle => BackColor;
            public override Color MenuItemPressedGradientEnd => BackColor;

            public override Color ButtonCheckedGradientBegin => Color.Transparent;
            public override Color ButtonCheckedGradientMiddle => Color.Transparent;
            public override Color ButtonCheckedGradientEnd => Color.Transparent;

            public override Color ToolStripPanelGradientBegin => BackColor;

            public override Color ToolStripPanelGradientEnd => BackColor;

            public override Color ButtonSelectedBorder => BackColor;

            public override Color CheckBackground => CheckedColor;
            public override Color CheckPressedBackground => CheckedColor;
            public override Color CheckSelectedBackground => CheckedColor;

            public override Color ImageMarginGradientBegin => CheckedColor;
            public override Color ImageMarginGradientEnd => CheckedColor;
            public override Color ImageMarginGradientMiddle => CheckedColor;

            public override Color MenuBorder => BorderColor;
            public override Color MenuItemBorder => BorderColor;
            public override Color MenuItemSelected => CheckedColor;

            public override Color SeparatorDark => BorderColor;

            public override Color ToolStripDropDownBackground => BackColor;
        }
    }
}
