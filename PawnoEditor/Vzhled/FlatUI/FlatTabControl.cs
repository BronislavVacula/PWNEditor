using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatTabControl : TabControl
    {
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        [Category("Colors")]
        public Color BGColor { get; set; } = Color.FromArgb(60, 70, 73);

        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(45, 47, 49);

        [Category("Colors")]
        public Color ActiveColor { get; set; } = Helpers.FlatColors.Instance().Flat;

        public FlatTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);

            Font = new Font("Segoe UI", 10);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(120, 40);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.InitializeFlatGraphics(BaseColor);

            try
            {
                if (TabCount > 0) SelectedTab.BackColor = BGColor;
            }
            catch { }

            for (int i = 0; i <= TabCount - 1; i++)
            {
                var tabRectangle = GetTabRect(i);
                Rectangle BaseSize = new Rectangle(new Point(tabRectangle.Location.X + 2, tabRectangle.Location.Y),
                    new Size(tabRectangle.Width, tabRectangle.Height));

                graphics.FillRectangle(new SolidBrush(BaseColor), BaseSize);

                if (i == SelectedIndex)
                    graphics.FillRectangle(new SolidBrush(ActiveColor), BaseSize);

                if (ImageList != null)
                {
                    try
                    {
                        if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            DrawTabItemWithImage(graphics, BaseSize, TabPages[i]);
                        else
                            DrawTabItemText(graphics, BaseSize, TabPages[i].Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else DrawTabItemText(graphics, BaseSize, TabPages[i].Text);
            }

            base.OnPaint(e);

            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            bitmap.Dispose();
        }

        private void DrawTabItemWithImage(Graphics graphics, Rectangle rect, TabPage page)
        {
            graphics.DrawImage(ImageList.Images[page.ImageIndex], new Point(base.Location.X + 8, rect.Location.Y + 6));
            graphics.DrawString("      " + page.Text, Font, Brushes.White, rect, Helpers.Main.CenterSF);
        }

        private void DrawTabItemText(Graphics graphics, Rectangle rect, string text)
        {
            graphics.DrawString(text, Font, Brushes.White, rect, Helpers.Main.CenterSF);
        }
    }
}