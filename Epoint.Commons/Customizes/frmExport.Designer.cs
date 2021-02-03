namespace Epoint.Systems.Customizes
{
	partial class frmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.txtPath = new Epoint.Systems.Controls.txtTextBox();
            this.lblPath = new Epoint.Systems.Controls.lblControl();
            this.btPath = new Epoint.Systems.Controls.btControl();
            this.chkOpenFile = new Epoint.Systems.Controls.chkControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.cboExportType = new Epoint.Systems.Controls.cboControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.enuFormatFont = new Epoint.Systems.Controls.txtEnum();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.label1 = new Epoint.Systems.Controls.lbtControl();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.bEnabled = true;
            this.txtPath.bIsLookup = false;
            this.txtPath.bReadOnly = false;
            this.txtPath.bRequire = false;
            this.txtPath.KeyFilter = "";
            this.txtPath.Location = new System.Drawing.Point(118, 51);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(312, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.UseAutoFilter = false;
            // 
            // lblPath
            // 
            this.lblPath.AutoEllipsis = true;
            this.lblPath.AutoSize = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Location = new System.Drawing.Point(15, 53);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(92, 13);
            this.lblPath.TabIndex = 2;
            this.lblPath.Tag = "Path";
            this.lblPath.Text = "Đường dẫn tập tin";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPath
            // 
            this.btPath.Location = new System.Drawing.Point(432, 50);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(29, 22);
            this.btPath.TabIndex = 2;
            this.btPath.TabStop = false;
            this.btPath.Text = "...";
            this.btPath.UseVisualStyleBackColor = true;
            // 
            // chkOpenFile
            // 
            this.chkOpenFile.AutoSize = true;
            this.chkOpenFile.Checked = true;
            this.chkOpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenFile.Location = new System.Drawing.Point(118, 98);
            this.chkOpenFile.Name = "chkOpenFile";
            this.chkOpenFile.Size = new System.Drawing.Size(135, 17);
            this.chkOpenFile.TabIndex = 4;
            this.chkOpenFile.Tag = "Open_File";
            this.chkOpenFile.Text = "Mở file sau khi kết xuất";
            this.chkOpenFile.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(280, 129);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(181, 34);
            this.btgAccept.TabIndex = 7;
            // 
            // cboExportType
            // 
            this.cboExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExportType.FormattingEnabled = true;
            this.cboExportType.InitValue = null;
            this.cboExportType.Items.AddRange(new object[] {
            "1 - Export to MS excel",
            "2 - Export to MS word",
            "3 - Export to PDF type",
            "4 - Export to HTML type",
            "5 - Export to Foxpro (.dbf)"});
            this.cboExportType.Location = new System.Drawing.Point(118, 28);
            this.cboExportType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboExportType.Name = "cboExportType";
            this.cboExportType.Size = new System.Drawing.Size(214, 21);
            this.cboExportType.strValueList = null;
            this.cboExportType.TabIndex = 0;
            this.cboExportType.UpperCase = false;
            this.cboExportType.UseAutoComplete = false;
            this.cboExportType.UseBindingValue = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(15, 31);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(97, 13);
            this.lblControl1.TabIndex = 2;
            this.lblControl1.Tag = "Format";
            this.lblControl1.Text = "Định dạng kết xuất";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuFormatFont
            // 
            this.enuFormatFont.bEnabled = true;
            this.enuFormatFont.bIsLookup = false;
            this.enuFormatFont.bReadOnly = false;
            this.enuFormatFont.bRequire = false;
            this.enuFormatFont.InputMask = "U,V,T";
            this.enuFormatFont.KeyFilter = "";
            this.enuFormatFont.Location = new System.Drawing.Point(118, 73);
            this.enuFormatFont.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.enuFormatFont.Name = "enuFormatFont";
            this.enuFormatFont.Size = new System.Drawing.Size(30, 20);
            this.enuFormatFont.TabIndex = 3;
            this.enuFormatFont.Text = "U";
            this.enuFormatFont.UseAutoFilter = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(15, 75);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(98, 13);
            this.lblControl2.TabIndex = 2;
            this.lblControl2.Tag = "Format";
            this.lblControl2.Text = "Định dạng font chữ";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(153, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "U - Unicode, V - Vni, T - TCVN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 175);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enuFormatFont);
            this.Controls.Add(this.cboExportType);
            this.Controls.Add(this.chkOpenFile);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.btPath);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.Text = "frmExport";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtPath;
		private Epoint.Systems.Controls.lblControl lblPath;
		private Epoint.Systems.Controls.btControl btPath;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		public Epoint.Systems.Controls.chkControl chkOpenFile;
		public Epoint.Systems.Controls.cboControl cboExportType;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.lbtControl label1;
		public Epoint.Systems.Controls.txtEnum enuFormatFont;
	}
}