using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatTreeView : TreeView
    {
        public TreeNodeStates State;

        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _LineColor = Color.FromArgb(25, 27, 29);

        public FlatTreeView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            BackColor = _BaseColor;
            ForeColor = Color.White;
            LineColor = _LineColor;
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }

        private void DrawNodeItem(DrawTreeNodeEventArgs e, Rectangle itemBounds, Brush rectangleBrush, Brush stringBrush)
        {
            e.Graphics.FillRectangle(rectangleBrush, itemBounds);
            e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8), stringBrush,
                new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), Helpers.Main.NearSF);
            Invalidate();
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            try
            {
                Rectangle Bounds = new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height);

                switch (State)
                {
                    case TreeNodeStates.Default:
                        DrawNodeItem(e, Bounds, Brushes.Red, Brushes.LimeGreen);
                        break;
                    case TreeNodeStates.Checked:
                    case TreeNodeStates.Selected:
                        DrawNodeItem(e, Bounds, Brushes.Green, Brushes.Black);
                        break;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            base.OnDrawNode(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var bitmap = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.InitializeFlatGraphics(BackColor);

                    graphics.FillRectangle(new SolidBrush(_BaseColor), new Rectangle(0, 0, Width, Height));
                    graphics.DrawString(Text, new Font("Segoe UI", 8), Brushes.Black,
                        new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), Helpers.Main.NearSF);

                    base.OnPaint(e);

                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
                }
            }
        }
    }
}