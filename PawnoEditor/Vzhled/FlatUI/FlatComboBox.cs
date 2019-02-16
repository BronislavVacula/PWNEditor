﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
    public class FlatComboBox : ComboBox
    {
        int W, H, x, y;
        int _StartIndex = 0;

        public Helpers.MouseState State = Helpers.MouseState.None;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = Helpers.MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = Helpers.MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = Helpers.MouseState.None;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            x = e.Location.X;
            y = e.Location.Y;

            Invalidate();

            if (e.X < Width - 41) Cursor = Cursors.IBeam;
            else Cursor = Cursors.Hand;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            Invalidate();

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Invalidate();
        }

        [Category("Colors")]
        public Color HoverColor { get; set; } = Color.FromArgb(35, 168, 109);

        private int StartIndex
        {
            get { return _StartIndex; }
            set
            {
                _StartIndex = value;

                try
                {
                    base.SelectedIndex = value;
                }
                catch { }

                Invalidate();
            }
        }

        public void DrawItem_(Object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(HoverColor), e.Bounds); //-- Selected item
            else e.Graphics.FillRectangle(new SolidBrush(_BaseColor), e.Bounds); //-- Not Selected

            //-- Text
            e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), new Font("Segoe UI", 8), 
                Brushes.White, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));

            e.Graphics.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 18;
        }

        private Color _BaseColor = Color.FromArgb(25, 27, 29);
        private Color _BGColor = Color.FromArgb(45, 47, 49);

        public FlatComboBox()
        {
            DrawItem += DrawItem_;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;

            Font = new Font("Segoe UI", 8, FontStyle.Regular);
            BackColor = Color.FromArgb(45, 45, 48);
            ForeColor = Color.White;
            Cursor = Cursors.Hand;

            StartIndex = 0;
            ItemHeight = 18;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Button = new Rectangle(Convert.ToInt32(W - 40), 0, W, H);
            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();

            var _with16 = G;
            _with16.Clear(Color.FromArgb(45, 45, 48));
            _with16.SmoothingMode = SmoothingMode.HighQuality;
            _with16.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with16.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            _with16.FillRectangle(new SolidBrush(_BGColor), Base); //-- Base

            //-- Button
            GP.Reset();
            GP.AddRectangle(Button);
            _with16.SetClip(GP);
            _with16.FillRectangle(new SolidBrush(_BaseColor), Button);
            _with16.ResetClip();

            //-- Lines
            _with16.DrawLine(Pens.White, W - 10, 6, W - 30, 6);
            _with16.DrawLine(Pens.White, W - 10, 12, W - 30, 12);
            _with16.DrawLine(Pens.White, W - 10, 18, W - 30, 18);

            //-- Text
            _with16.DrawString(Text, Font, Brushes.White, new Point(4, 6), Helpers.Main.NearSF);

            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}
