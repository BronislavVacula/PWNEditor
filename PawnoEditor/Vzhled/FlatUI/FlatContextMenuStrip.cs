using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    public class FlatContextMenuStrip : ContextMenuStrip
    {
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public FlatContextMenuStrip() : base()
        {
            Renderer = new ToolStripProfessionalRenderer(new TColorTable());
            ShowImageMargin = false;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 8);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }

        public class TColorTable : ProfessionalColorTable
        {
            [Category("Colors")]
            public Color BackColor { get; set; } = Color.FromArgb(45, 47, 49);

            [Category("Colors")]
            public Color CheckedColor { get; set; } = Helpers.Main.FlatColor;

            [Category("Colors")]
            public Color BorderColor { get; set; } = Color.FromArgb(53, 58, 60);

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