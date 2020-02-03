namespace PawnoEditor.Controls.Panels
{
    partial class ucWorkspaceBrowser
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
            this.files = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            ((System.ComponentModel.ISupportInitialize)(this.files)).BeginInit();
            this.SuspendLayout();
            // 
            // files
            // 
            treeNodeAdvStyleInfo1.CheckBoxTickThickness = 1;
            treeNodeAdvStyleInfo1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = true;
            treeNodeAdvStyleInfo1.IntermediateCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.OptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.files.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", treeNodeAdvStyleInfo1)});
            this.files.BeforeTouchSize = new System.Drawing.Size(338, 273);
            this.files.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.files.HelpTextControl.BaseThemeName = null;
            this.files.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.files.HelpTextControl.Name = "";
            this.files.HelpTextControl.Size = new System.Drawing.Size(392, 112);
            this.files.HelpTextControl.TabIndex = 0;
            this.files.HelpTextControl.Visible = true;
            this.files.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this.files.Location = new System.Drawing.Point(0, 0);
            this.files.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.files.Name = "files";
            this.files.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            this.files.Size = new System.Drawing.Size(338, 273);
            this.files.TabIndex = 0;
            this.files.Text = "treeViewAdv1";
            // 
            // 
            // 
            this.files.ToolTipControl.BaseThemeName = null;
            this.files.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.files.ToolTipControl.Name = "";
            this.files.ToolTipControl.Size = new System.Drawing.Size(392, 112);
            this.files.ToolTipControl.TabIndex = 0;
            this.files.ToolTipControl.Visible = true;
            // 
            // ucWorkspaceBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.files);
            this.Name = "ucWorkspaceBrowser";
            this.Size = new System.Drawing.Size(338, 273);
            ((System.ComponentModel.ISupportInitialize)(this.files)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TreeViewAdv files;
    }
}
