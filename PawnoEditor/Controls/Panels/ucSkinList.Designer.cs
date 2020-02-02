namespace PawnoEditor.Controls.Panels
{
    partial class ucSkinList
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
            this.skinImage = new System.Windows.Forms.PictureBox();
            this.skins = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            ((System.ComponentModel.ISupportInitialize)(this.skinImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skins)).BeginInit();
            this.SuspendLayout();
            // 
            // skinImage
            // 
            this.skinImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinImage.Location = new System.Drawing.Point(0, 0);
            this.skinImage.Name = "skinImage";
            this.skinImage.Size = new System.Drawing.Size(335, 112);
            this.skinImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.skinImage.TabIndex = 0;
            this.skinImage.TabStop = false;
            // 
            // skins
            // 
            treeNodeAdvStyleInfo1.CheckBoxTickThickness = 1;
            treeNodeAdvStyleInfo1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = true;
            treeNodeAdvStyleInfo1.IntermediateCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.OptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.skins.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", treeNodeAdvStyleInfo1)});
            this.skins.BeforeTouchSize = new System.Drawing.Size(335, 249);
            this.skins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skins.FullRowSelect = true;
            // 
            // 
            // 
            this.skins.HelpTextControl.BaseThemeName = null;
            this.skins.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.skins.HelpTextControl.Name = "";
            this.skins.HelpTextControl.Size = new System.Drawing.Size(392, 112);
            this.skins.HelpTextControl.TabIndex = 0;
            this.skins.HelpTextControl.Visible = true;
            this.skins.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this.skins.Location = new System.Drawing.Point(0, 112);
            this.skins.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.skins.Name = "skins";
            this.skins.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            this.skins.Size = new System.Drawing.Size(335, 249);
            this.skins.TabIndex = 1;
            this.skins.Text = "treeViewAdv1";
            this.skins.ThemeStyle.TreeNodeAdvStyle.CheckBoxTickThickness = 0;
            this.skins.ThemeStyle.TreeNodeAdvStyle.EnsureDefaultOptionedChild = true;
            // 
            // 
            // 
            this.skins.ToolTipControl.BaseThemeName = null;
            this.skins.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.skins.ToolTipControl.Name = "";
            this.skins.ToolTipControl.Size = new System.Drawing.Size(392, 112);
            this.skins.ToolTipControl.TabIndex = 0;
            this.skins.ToolTipControl.Visible = true;
            this.skins.AfterSelect += new System.EventHandler(this.skins_AfterSelect);
            // 
            // ucSkinList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skins);
            this.Controls.Add(this.skinImage);
            this.Name = "ucSkinList";
            this.Size = new System.Drawing.Size(335, 361);
            ((System.ComponentModel.ISupportInitialize)(this.skinImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox skinImage;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv skins;
    }
}
