﻿using System;
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
            public Color CheckedColor { get; set; } = Helpers.FlatColors.Instance().Flat;

            [Category("Colors")]
            public Color BorderColor { get; set; } = Color.FromArgb(53, 58, 60);

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