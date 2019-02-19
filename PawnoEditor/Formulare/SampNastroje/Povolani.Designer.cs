namespace PawnoEditor.Formulare.SampNastroje
{
    partial class Povolani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.formSkin1 = new FlatUI.FormSkin();
            this.zrusitBtn = new FlatUI.FlatButton();
            this.generovatBtn = new FlatUI.FlatButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flatClose1 = new FlatUI.FlatClose();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.flatNumeric1 = new FlatUI.FlatNumeric();
            this.flatLabel2 = new FlatUI.FlatLabel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spawn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zbrane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Skiny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PravidelnaVyplata = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.formSkin1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatLabel2);
            this.formSkin1.Controls.Add(this.flatNumeric1);
            this.formSkin1.Controls.Add(this.flatLabel1);
            this.formSkin1.Controls.Add(this.zrusitBtn);
            this.formSkin1.Controls.Add(this.generovatBtn);
            this.formSkin1.Controls.Add(this.dataGridView1);
            this.formSkin1.Controls.Add(this.flatClose1);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(947, 651);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Generování povolání";
            // 
            // zrusitBtn
            // 
            this.zrusitBtn.BackColor = System.Drawing.Color.Transparent;
            this.zrusitBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.zrusitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zrusitBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.zrusitBtn.Location = new System.Drawing.Point(21, 597);
            this.zrusitBtn.Name = "zrusitBtn";
            this.zrusitBtn.Rounded = false;
            this.zrusitBtn.Size = new System.Drawing.Size(106, 32);
            this.zrusitBtn.TabIndex = 3;
            this.zrusitBtn.Text = "Zrušit";
            this.zrusitBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.zrusitBtn.Click += new System.EventHandler(this.zrusitBtn_Click);
            // 
            // generovatBtn
            // 
            this.generovatBtn.BackColor = System.Drawing.Color.Transparent;
            this.generovatBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.generovatBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generovatBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.generovatBtn.Location = new System.Drawing.Point(811, 597);
            this.generovatBtn.Name = "generovatBtn";
            this.generovatBtn.Rounded = false;
            this.generovatBtn.Size = new System.Drawing.Size(106, 32);
            this.generovatBtn.TabIndex = 2;
            this.generovatBtn.Text = "Generovat";
            this.generovatBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.generovatBtn.Click += new System.EventHandler(this.generovatBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nazev,
            this.Spawn,
            this.PlatOD,
            this.PlatDO,
            this.Zbrane,
            this.Skiny,
            this.PravidelnaVyplata});
            this.dataGridView1.Location = new System.Drawing.Point(21, 128);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.Size = new System.Drawing.Size(896, 449);
            this.dataGridView1.TabIndex = 1;
            // 
            // flatClose1
            // 
            this.flatClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatClose1.BackColor = System.Drawing.Color.White;
            this.flatClose1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatClose1.Font = new System.Drawing.Font("Marlett", 10F);
            this.flatClose1.Location = new System.Drawing.Point(917, 12);
            this.flatClose1.Name = "flatClose1";
            this.flatClose1.Size = new System.Drawing.Size(18, 18);
            this.flatClose1.TabIndex = 0;
            this.flatClose1.Text = "flatClose1";
            this.flatClose1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(357, 79);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(99, 19);
            this.flatLabel1.TabIndex = 4;
            this.flatLabel1.Text = "Interval výplat:";
            // 
            // flatNumeric1
            // 
            this.flatNumeric1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.flatNumeric1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatNumeric1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatNumeric1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatNumeric1.ForeColor = System.Drawing.Color.White;
            this.flatNumeric1.Location = new System.Drawing.Point(460, 74);
            this.flatNumeric1.Maximum = ((long)(9999999));
            this.flatNumeric1.Minimum = ((long)(0));
            this.flatNumeric1.Name = "flatNumeric1";
            this.flatNumeric1.Size = new System.Drawing.Size(75, 30);
            this.flatNumeric1.TabIndex = 5;
            this.flatNumeric1.Text = "flatNumeric1";
            this.flatNumeric1.Value = ((long)(5));
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(541, 79);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(45, 19);
            this.flatLabel2.TabIndex = 6;
            this.flatLabel2.Text = "minut";
            // 
            // ID
            // 
            this.ID.HeaderText = "#";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // Nazev
            // 
            this.Nazev.HeaderText = "Název";
            this.Nazev.Name = "Nazev";
            // 
            // Spawn
            // 
            this.Spawn.HeaderText = "Spawn pozice";
            this.Spawn.Name = "Spawn";
            this.Spawn.Width = 150;
            // 
            // PlatOD
            // 
            this.PlatOD.HeaderText = "Plat OD";
            this.PlatOD.Name = "PlatOD";
            this.PlatOD.Width = 90;
            // 
            // PlatDO
            // 
            this.PlatDO.HeaderText = "Plat DO";
            this.PlatDO.Name = "PlatDO";
            this.PlatDO.Width = 90;
            // 
            // Zbrane
            // 
            this.Zbrane.HeaderText = "Zbraně";
            this.Zbrane.Name = "Zbrane";
            this.Zbrane.Width = 150;
            // 
            // Skiny
            // 
            this.Skiny.HeaderText = "Skiny";
            this.Skiny.Name = "Skiny";
            this.Skiny.Width = 140;
            // 
            // PravidelnaVyplata
            // 
            this.PravidelnaVyplata.HeaderText = "Pravidelná výplata";
            this.PravidelnaVyplata.Name = "PravidelnaVyplata";
            this.PravidelnaVyplata.Width = 83;
            // 
            // Povolani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 651);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Povolani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Povolani";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.formSkin1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUI.FormSkin formSkin1;
        private FlatUI.FlatClose flatClose1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FlatUI.FlatButton zrusitBtn;
        private FlatUI.FlatButton generovatBtn;
        private FlatUI.FlatLabel flatLabel2;
        private FlatUI.FlatNumeric flatNumeric1;
        private FlatUI.FlatLabel flatLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spawn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zbrane;
        private System.Windows.Forms.DataGridViewTextBoxColumn Skiny;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PravidelnaVyplata;
    }
}