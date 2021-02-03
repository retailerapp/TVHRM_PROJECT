namespace Epoint.Controllers
{
    partial class frmDeleteVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteVoucher));
            this.btOk = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.tabControl1 = new Epoint.Systems.Controls.tabControl();
            this.tabPageDeleteVoucher = new System.Windows.Forms.TabPage();
            this.btMa_Ct = new Epoint.Systems.Controls.btControl();
            this.lblMa_Ct = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Ct = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.txtNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.tabPageDeleteList = new System.Windows.Forms.TabPage();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.tabPageDeleteDuDau = new System.Windows.Forms.TabPage();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.cboDuDau = new System.Windows.Forms.ComboBox();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.tabPageDeleteConditional = new System.Windows.Forms.TabPage();
            this.rtbConditional = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageDeleteVoucher.SuspendLayout();
            this.tabPageDeleteList.SuspendLayout();
            this.tabPageDeleteDuDau.SuspendLayout();
            this.tabPageDeleteConditional.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.Blue;
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(787, 486);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(79, 33);
            this.btOk.TabIndex = 5;
            this.btOk.Tag = "ACCEPT";
            this.btOk.Text = "&Đồng ý";
            this.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Blue;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(870, 486);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(79, 33);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageDeleteVoucher);
            this.tabControl1.Controls.Add(this.tabPageDeleteList);
            this.tabControl1.Controls.Add(this.tabPageDeleteDuDau);
            this.tabControl1.Controls.Add(this.tabPageDeleteConditional);
            this.tabControl1.Location = new System.Drawing.Point(7, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(942, 471);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPageDeleteVoucher
            // 
            this.tabPageDeleteVoucher.Controls.Add(this.btMa_Ct);
            this.tabPageDeleteVoucher.Controls.Add(this.lblMa_Ct);
            this.tabPageDeleteVoucher.Controls.Add(this.txtMa_Ct);
            this.tabPageDeleteVoucher.Controls.Add(this.lblControl2);
            this.tabPageDeleteVoucher.Controls.Add(this.lblControl1);
            this.tabPageDeleteVoucher.Controls.Add(this.txtNgay_Ct1);
            this.tabPageDeleteVoucher.Controls.Add(this.txtNgay_Ct2);
            this.tabPageDeleteVoucher.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeleteVoucher.Name = "tabPageDeleteVoucher";
            this.tabPageDeleteVoucher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeleteVoucher.Size = new System.Drawing.Size(934, 445);
            this.tabPageDeleteVoucher.TabIndex = 0;
            this.tabPageDeleteVoucher.Tag = "Delete_Voucher";
            this.tabPageDeleteVoucher.Text = "Xóa dữ liệu chứng từ";
            this.tabPageDeleteVoucher.UseVisualStyleBackColor = true;
            // 
            // btMa_Ct
            // 
            this.btMa_Ct.Location = new System.Drawing.Point(331, 57);
            this.btMa_Ct.Name = "btMa_Ct";
            this.btMa_Ct.Size = new System.Drawing.Size(27, 22);
            this.btMa_Ct.TabIndex = 151;
            this.btMa_Ct.TabStop = false;
            this.btMa_Ct.Text = "...";
            this.btMa_Ct.UseVisualStyleBackColor = true;
            // 
            // lblMa_Ct
            // 
            this.lblMa_Ct.AutoEllipsis = true;
            this.lblMa_Ct.AutoSize = true;
            this.lblMa_Ct.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Ct.Location = new System.Drawing.Point(26, 61);
            this.lblMa_Ct.Name = "lblMa_Ct";
            this.lblMa_Ct.Size = new System.Drawing.Size(35, 13);
            this.lblMa_Ct.TabIndex = 150;
            this.lblMa_Ct.Tag = "Ma_Ct";
            this.lblMa_Ct.Text = "Mã Ct";
            this.lblMa_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ct
            // 
            this.txtMa_Ct.bEnabled = true;
            this.txtMa_Ct.bIsLookup = false;
            this.txtMa_Ct.bReadOnly = false;
            this.txtMa_Ct.bRequire = false;
            this.txtMa_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ct.KeyFilter = "";
            this.txtMa_Ct.Location = new System.Drawing.Point(92, 58);
            this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct.MaxLength = 20;
            this.txtMa_Ct.Name = "txtMa_Ct";
            this.txtMa_Ct.Size = new System.Drawing.Size(235, 20);
            this.txtMa_Ct.TabIndex = 149;
            this.txtMa_Ct.UseAutoFilter = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(181, 32);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(53, 13);
            this.lblControl2.TabIndex = 148;
            this.lblControl2.Tag = "Den_Ngay";
            this.lblControl2.Text = "Đến ngày";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(26, 32);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(46, 13);
            this.lblControl1.TabIndex = 147;
            this.lblControl1.Tag = "Ngay_Ct1";
            this.lblControl1.Text = "Từ ngày";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNgay_Ct1
            // 
            this.txtNgay_Ct1.bAllowEmpty = true;
            this.txtNgay_Ct1.bRequire = false;
            this.txtNgay_Ct1.bSelectOnFocus = true;
            this.txtNgay_Ct1.bShowDateTimePicker = true;
            this.txtNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct1.Location = new System.Drawing.Point(92, 29);
            this.txtNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct1.Mask = "00/00/0000";
            this.txtNgay_Ct1.Name = "txtNgay_Ct1";
            this.txtNgay_Ct1.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct1.TabIndex = 145;
            this.txtNgay_Ct1.Tag = "Ngay_Ct1";
            // 
            // txtNgay_Ct2
            // 
            this.txtNgay_Ct2.bAllowEmpty = true;
            this.txtNgay_Ct2.bRequire = false;
            this.txtNgay_Ct2.bSelectOnFocus = true;
            this.txtNgay_Ct2.bShowDateTimePicker = true;
            this.txtNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct2.Location = new System.Drawing.Point(253, 29);
            this.txtNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct2.Mask = "00/00/0000";
            this.txtNgay_Ct2.Name = "txtNgay_Ct2";
            this.txtNgay_Ct2.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct2.TabIndex = 146;
            this.txtNgay_Ct2.Tag = "Ngay_Ct2";
            // 
            // tabPageDeleteList
            // 
            this.tabPageDeleteList.Controls.Add(this.cboDanhMuc);
            this.tabPageDeleteList.Controls.Add(this.lblControl3);
            this.tabPageDeleteList.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeleteList.Name = "tabPageDeleteList";
            this.tabPageDeleteList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeleteList.Size = new System.Drawing.Size(934, 445);
            this.tabPageDeleteList.TabIndex = 2;
            this.tabPageDeleteList.Tag = "Delete_List";
            this.tabPageDeleteList.Text = "Xóa dữ liệu danh mục";
            this.tabPageDeleteList.UseVisualStyleBackColor = true;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(93, 41);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(315, 21);
            this.cboDanhMuc.TabIndex = 154;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(30, 44);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(56, 13);
            this.lblControl3.TabIndex = 153;
            this.lblControl3.Tag = "List";
            this.lblControl3.Text = "Danh mục";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageDeleteDuDau
            // 
            this.tabPageDeleteDuDau.Controls.Add(this.cboNam);
            this.tabPageDeleteDuDau.Controls.Add(this.lblControl5);
            this.tabPageDeleteDuDau.Controls.Add(this.cboDuDau);
            this.tabPageDeleteDuDau.Controls.Add(this.lblControl4);
            this.tabPageDeleteDuDau.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeleteDuDau.Name = "tabPageDeleteDuDau";
            this.tabPageDeleteDuDau.Size = new System.Drawing.Size(934, 445);
            this.tabPageDeleteDuDau.TabIndex = 3;
            this.tabPageDeleteDuDau.Tag = "Delete_DuDau";
            this.tabPageDeleteDuDau.Text = "Xóa số dư đầu";
            this.tabPageDeleteDuDau.UseVisualStyleBackColor = true;
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(103, 28);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(88, 21);
            this.cboNam.TabIndex = 0;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Location = new System.Drawing.Point(31, 31);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(29, 13);
            this.lblControl5.TabIndex = 157;
            this.lblControl5.Tag = "Nam";
            this.lblControl5.Text = "Năm";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDuDau
            // 
            this.cboDuDau.FormattingEnabled = true;
            this.cboDuDau.Location = new System.Drawing.Point(103, 58);
            this.cboDuDau.Name = "cboDuDau";
            this.cboDuDau.Size = new System.Drawing.Size(315, 21);
            this.cboDuDau.TabIndex = 1;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(31, 61);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(71, 13);
            this.lblControl4.TabIndex = 155;
            this.lblControl4.Tag = "Du_Dau";
            this.lblControl4.Text = "Số dư đầu kỳ";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageDeleteConditional
            // 
            this.tabPageDeleteConditional.Controls.Add(this.rtbConditional);
            this.tabPageDeleteConditional.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeleteConditional.Name = "tabPageDeleteConditional";
            this.tabPageDeleteConditional.Size = new System.Drawing.Size(934, 445);
            this.tabPageDeleteConditional.TabIndex = 4;
            this.tabPageDeleteConditional.Tag = "Delete_Conditional";
            this.tabPageDeleteConditional.Text = "Xóa theo điều kiện";
            this.tabPageDeleteConditional.UseVisualStyleBackColor = true;
            // 
            // rtbConditional
            // 
            this.rtbConditional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConditional.Location = new System.Drawing.Point(20, 15);
            this.rtbConditional.Name = "rtbConditional";
            this.rtbConditional.Size = new System.Drawing.Size(894, 411);
            this.rtbConditional.TabIndex = 0;
            this.rtbConditional.Text = "";
            // 
            // frmDeleteVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(957, 529);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmDeleteVoucher";
            this.Tag = "frmDeleteVoucher";
            this.Text = "frmDeleteVoucher";
            this.tabControl1.ResumeLayout(false);
            this.tabPageDeleteVoucher.ResumeLayout(false);
            this.tabPageDeleteVoucher.PerformLayout();
            this.tabPageDeleteList.ResumeLayout(false);
            this.tabPageDeleteList.PerformLayout();
            this.tabPageDeleteDuDau.ResumeLayout(false);
            this.tabPageDeleteDuDau.PerformLayout();
            this.tabPageDeleteConditional.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.btControl btOk;
        private Epoint.Systems.Controls.btControl btCancel;
        private Systems.Controls.tabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDeleteVoucher;
        private System.Windows.Forms.TabPage tabPageDeleteList;
        private Systems.Controls.btControl btMa_Ct;
        private Systems.Controls.lblControl lblMa_Ct;
        private Systems.Controls.txtTextBox txtMa_Ct;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.txtDateTime txtNgay_Ct1;
        private Systems.Controls.txtDateTime txtNgay_Ct2;
        private System.Windows.Forms.TabPage tabPageDeleteDuDau;
        private System.Windows.Forms.TabPage tabPageDeleteConditional;
        private System.Windows.Forms.RichTextBox rtbConditional;
        private Systems.Controls.lblControl lblControl3;
        public System.Windows.Forms.ComboBox cboDanhMuc;
        public System.Windows.Forms.ComboBox cboNam;
        private Systems.Controls.lblControl lblControl5;
        public System.Windows.Forms.ComboBox cboDuDau;
        private Systems.Controls.lblControl lblControl4;
	}
}