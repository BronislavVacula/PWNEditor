using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FlatUI.Extensions;

namespace FlatUI
{
    public class FlatListBox : Control
    {
        private ListBox withEventsField_ListBx = new ListBox();
        private ListBox ListBx
        {
            get { return withEventsField_ListBx; }
            set
            {
                if (withEventsField_ListBx != null) withEventsField_ListBx.DrawItem -= Drawitem;

                withEventsField_ListBx = value;

                if (withEventsField_ListBx != null) withEventsField_ListBx.DrawItem += Drawitem;
            }
        }

        private string[] _items = { "" };

        [Category("Options")]
        public string[] Items
        {
            get => _items;
            set
            {
                _items = value;
                ListBx.Items.Clear();
                ListBx.Items.AddRange(value);
                Invalidate();
            }
        }

        public Color SelectedColor { get; set; } = Helpers.FlatColors.Instance().Flat;
        public string SelectedItem { get => ListBx.SelectedItem.ToString(); }
        public int SelectedIndex {  get => ListBx.SelectedIndex; }

        public void Clear() => ListBx.Items.Clear();

        public void ClearSelected()
        {
            for (int i = (ListBx.SelectedItems.Count - 1); i >= 0; i += -1)
                ListBx.Items.Remove(ListBx.SelectedItems[i]);
        }

        public void Drawitem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            if (e.State.ToString().IndexOf("Selected,") >= 0)
                e.Graphics.FillRectangle(new SolidBrush(SelectedColor), rect);
            else
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 53, 55)), rect);

            e.Graphics.DrawString(" " + ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8), Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
            e.Graphics.Dispose();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!Controls.Contains(ListBx)) Controls.Add(ListBx);
        }

        public void AddRange(object[] items)
        {
            ListBx.Items.Remove("");
            ListBx.Items.AddRange(items);
        }

        public void AddItem(object item)
        {
            ListBx.Items.Remove("");
            ListBx.Items.Add(item);
        }

        private Color BaseColor = Color.FromArgb(45, 47, 49);

        public FlatListBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            ListBx.DrawMode = DrawMode.OwnerDrawFixed;
            ListBx.ScrollAlwaysVisible = false;
            ListBx.HorizontalScrollbar = false;
            ListBx.BorderStyle = BorderStyle.None;
            ListBx.BackColor = BaseColor;
            ListBx.ForeColor = Color.White;
            ListBx.Location = new Point(3, 3);
            ListBx.Font = new Font("Segoe UI", 8);
            ListBx.ItemHeight = 20;
            ListBx.Items.Clear();
            ListBx.IntegralHeight = false;

            Size = new Size(131, 101);
            BackColor = BaseColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(B);

            Rectangle Base = new Rectangle(0, 0, Width, Height);

            graphics.InitializeFlatGraphics(BackColor);

            ListBx.Size = new Size(Width - 6, Height - 2);

            graphics.FillRectangle(new SolidBrush(BaseColor), Base);

            base.OnPaint(e);

            graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}