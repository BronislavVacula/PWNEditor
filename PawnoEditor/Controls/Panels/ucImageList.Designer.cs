namespace PawnoEditor.Controls.Panels
{
    partial class ucImageList
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo treeNodeAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo();
            this.itemImage = new System.Windows.Forms.PictureBox();
            this.images = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.images)).BeginInit();
            this.SuspendLayout();
            // 
            // itemImage
            // 
            this.itemImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemImage.Location = new System.Drawing.Point(0, 0);
            this.itemImage.Name = "itemImage";
            this.itemImage.Size = new System.Drawing.Size(335, 112);
            this.itemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.itemImage.TabIndex = 0;
            this.itemImage.TabStop = false;
            // 
            // images
            // 
            treeNodeAdvStyleInfo1.CheckBoxTickThickness = 1;
            treeNodeAdvStyleInfo1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = true;
            treeNodeAdvStyleInfo1.IntermediateCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.OptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.images.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", treeNodeAdvStyleInfo1)});
            this.images.BeforeTouchSize = new System.Drawing.Size(335, 249);
            this.images.Dock = System.Windows.Forms.DockStyle.Fill;
            this.images.FullRowSelect = true;
            // 
            // 
            // 
            this.images.HelpTextControl.BaseThemeName = null;
            this.images.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.images.HelpTextControl.Name = "";
            this.images.HelpTextControl.Size = new System.Drawing.Size(392, 112);
            this.images.HelpTextControl.TabIndex = 0;
            this.images.HelpTextControl.Visible = true;
            this.images.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this.images.Location = new System.Drawing.Point(0, 112);
            this.images.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.images.Name = "images";
            this.images.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            this.images.Size = new System.Drawing.Size(335, 249);
            this.images.TabIndex = 1;
            this.images.Text = "treeViewAdv1";
            this.images.ThemeStyle.TreeNodeAdvStyle.CheckBoxTickThickness = 0;
            this.images.ThemeStyle.TreeNodeAdvStyle.EnsureDefaultOptionedChild = true;
            // 
            // 
            // 
            this.images.ToolTipControl.BaseThemeName = null;
            this.images.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.images.ToolTipControl.Name = "";
            this.images.ToolTipControl.Size = new System.Drawing.Size(392, 112);
            this.images.ToolTipControl.TabIndex = 0;
            this.images.ToolTipControl.Visible = true;
            this.images.AfterSelect += new System.EventHandler(this.skins_AfterSelect);
            // 
            // ucImageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.images);
            this.Controls.Add(this.itemImage);
            this.Name = "ucImageList";
            this.Size = new System.Drawing.Size(335, 361);
            ((System.ComponentModel.ISupportInitialize)(this.itemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.images)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox itemImage;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv images;
    }
}
