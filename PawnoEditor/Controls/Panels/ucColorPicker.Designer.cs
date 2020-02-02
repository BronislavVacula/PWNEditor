namespace PawnoEditor.Controls.Panels
{
    partial class ucColorPicker
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
            this.txtColor = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.colorPicker = new Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtColor
            // 
            this.txtColor.BeforeTouchSize = new System.Drawing.Size(302, 20);
            this.txtColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtColor.Location = new System.Drawing.Point(0, 0);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(302, 20);
            this.txtColor.TabIndex = 0;
            // 
            // colorPicker.RecentGroup
            // 
            this.colorPicker.RecentGroup.Name = "Recent Colors";
            this.colorPicker.RecentGroup.Visible = false;
            // 
            // colorPicker.StandardGroup
            // 
            this.colorPicker.StandardGroup.Name = "Standard Colors";
            // 
            // colorPicker.ThemeGroup
            // 
            this.colorPicker.ThemeGroup.IsSubItemsVisible = true;
            this.colorPicker.ThemeGroup.Name = "Theme Colors";
            // 
            // colorPicker
            // 
            this.colorPicker.ColorItemSize = new System.Drawing.Size(13, 12);
            this.colorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPicker.Location = new System.Drawing.Point(0, 20);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(302, 337);
            this.colorPicker.TabIndex = 1;
            this.colorPicker.Text = "colorPickerUIAdv1";
            this.colorPicker.Picked += new Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv.ColorPickedEventHandler(this.colorPicker_Picked);
            // 
            // ucColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.txtColor);
            this.Name = "ucColorPicker";
            this.Size = new System.Drawing.Size(302, 357);
            ((System.ComponentModel.ISupportInitialize)(this.txtColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtColor;
        private Syncfusion.Windows.Forms.Tools.ColorPickerUIAdv colorPicker;
    }
}
