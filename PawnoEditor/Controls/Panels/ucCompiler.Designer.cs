namespace PawnoEditor.Controls.Panels
{
    partial class ucCompiler
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            this.gridErrors = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // gridErrors
            // 
            this.gridErrors.AccessibleName = "Table";
            this.gridErrors.AutoGenerateColumns = false;
            gridTextColumn1.HeaderText = "Line";
            gridTextColumn1.MappingName = "LineNumber";
            gridTextColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn2.HeaderText = "Text";
            gridTextColumn2.MappingName = "Text";
            this.gridErrors.Columns.Add(gridTextColumn1);
            this.gridErrors.Columns.Add(gridTextColumn2);
            this.gridErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridErrors.Location = new System.Drawing.Point(0, 0);
            this.gridErrors.Name = "gridErrors";
            this.gridErrors.Size = new System.Drawing.Size(549, 119);
            this.gridErrors.TabIndex = 0;
            this.gridErrors.ThemeName = "Office2016DarkGray";
            // 
            // ucCompiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridErrors);
            this.Name = "ucCompiler";
            this.Size = new System.Drawing.Size(549, 119);
            ((System.ComponentModel.ISupportInitialize)(this.gridErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid gridErrors;
    }
}
