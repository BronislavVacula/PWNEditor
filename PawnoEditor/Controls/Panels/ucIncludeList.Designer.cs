namespace PawnoEditor.Controls.Panels
{
    partial class ucIncludeList
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
            this.includes = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            ((System.ComponentModel.ISupportInitialize)(this.includes)).BeginInit();
            this.SuspendLayout();
            // 
            // includes
            // 
            this.includes.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102))))));
            treeNodeAdvStyleInfo1.CheckBoxTickThickness = 1;
            treeNodeAdvStyleInfo1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = true;
            treeNodeAdvStyleInfo1.IntermediateCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.OptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            treeNodeAdvStyleInfo1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.includes.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", treeNodeAdvStyleInfo1)});
            this.includes.BeforeTouchSize = new System.Drawing.Size(234, 276);
            this.includes.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.includes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.includes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.includes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.includes.HelpTextControl.BaseThemeName = null;
            this.includes.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.includes.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.includes.HelpTextControl.Name = "";
            this.includes.HelpTextControl.Size = new System.Drawing.Size(15, 15);
            this.includes.HelpTextControl.TabIndex = 0;
            this.includes.HelpTextControl.Visible = true;
            this.includes.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this.includes.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.includes.Location = new System.Drawing.Point(0, 0);
            this.includes.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.includes.Name = "includes";
            this.includes.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(197))))));
            this.includes.SelectedNodeForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.includes.ShowFocusRect = false;
            this.includes.Size = new System.Drawing.Size(234, 276);
            this.includes.Style = Syncfusion.Windows.Forms.Tools.TreeStyle.Office2016DarkGray;
            this.includes.TabIndex = 0;
            this.includes.ThemeName = "Office2016DarkGray";
            this.includes.ThemeStyle.TreeNodeAdvStyle.CheckBoxTickThickness = 0;
            this.includes.ThemeStyle.TreeNodeAdvStyle.EnsureDefaultOptionedChild = true;
            // 
            // 
            // 
            this.includes.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.includes.ToolTipControl.BaseThemeName = null;
            this.includes.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.includes.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.includes.ToolTipControl.Name = "";
            this.includes.ToolTipControl.Size = new System.Drawing.Size(15, 15);
            this.includes.ToolTipControl.TabIndex = 0;
            this.includes.ToolTipControl.Visible = true;
            this.includes.TransparentControls = true;
            this.includes.DoubleClick += new System.EventHandler(this.includes_DoubleClick);
            // 
            // ucIncludeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.includes);
            this.Name = "ucIncludeList";
            this.Size = new System.Drawing.Size(234, 276);
            ((System.ComponentModel.ISupportInitialize)(this.includes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TreeViewAdv includes;
    }
}
