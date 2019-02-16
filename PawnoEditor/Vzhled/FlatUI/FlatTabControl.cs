using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

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
        public Color ActiveColor { get; set; } = Color.FromArgb(26, 25, 25);

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
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            var _with13 = G;
            _with13.SmoothingMode = SmoothingMode.HighQuality;
            _with13.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with13.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with13.Clear(BaseColor);

            try
            {
                if (TabCount > 0) SelectedTab.BackColor = BGColor;
            }
            catch { }

            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle Base = new Rectangle(new Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width, GetTabRect(i).Height + 2));
                Rectangle BaseSize = new Rectangle(Base.Location, new Size(Base.Width, Base.Height));

                if (i == SelectedIndex)
                {
                    _with13.FillRectangle(new SolidBrush(BaseColor), BaseSize); //-- Base
                    _with13.FillRectangle(new SolidBrush(ActiveColor), BaseSize); //-- Gradiant .fill

                    //-- ImageList
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                //-- Image
                                _with13.DrawImage(
                                    ImageList.Images[TabPages[i].ImageIndex], 
                                    new Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6)
                                );

                                //-- Text
                                _with13.DrawString("      " + TabPages[i].Text,
                                    Font, Brushes.White, BaseSize, Helpers.Main.CenterSF);
                            }
                            else _with13.DrawString(TabPages[i].Text, Font, Brushes.White, BaseSize, 
                                    Helpers.Main.CenterSF); //-- Text
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else _with13.DrawString(TabPages[i].Text, Font, Brushes.White, BaseSize, 
                            Helpers.Main.CenterSF); //-- Text
                }
                else
                {
                    //-- Base
                    _with13.FillRectangle(new SolidBrush(BaseColor), BaseSize);

                    //-- ImageList
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                //-- Image
                                _with13.DrawImage(ImageList.Images[TabPages[i].ImageIndex], 
                                    new Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6));
                                //-- Text
                                _with13.DrawString("      " + TabPages[i].Text, Font, new SolidBrush(Color.White), BaseSize, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                //-- Text
                                _with13.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.White), BaseSize, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else
                    {
                        //-- Text
                        _with13.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.White), BaseSize, 
                            new StringFormat {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                        });
                    }
                }
            }

            base.OnPaint(e);

            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}