namespace Epoint.Controllers
{
	partial class frmTrans_Voucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrans_Voucher));
            this.btOk = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.btMa_Ct = new Epoint.Systems.Controls.btControl();
            this.txtNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.txtNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.chkAll = new Epoint.Systems.Controls.chkControl();
            this.chkDuDau = new Epoint.Systems.Controls.chkControl();
            this.chkTaiSan = new Epoint.Systems.Controls.chkControl();
            this.chkDanhMuc = new Epoint.Systems.Controls.chkControl();
            this.txtMa_Ct = new Epoint.Systems.Controls.txtTextBox();
            this.lblMa_Ct = new Epoint.Systems.Controls.lblControl();
            this.grbControl1 = new Epoint.Systems.Controls.grbControl();
            this.grbControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.Blue;
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(676, 440);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(78, 34);
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
            this.btCancel.Location = new System.Drawing.Point(759, 440);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(78, 34);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btMa_Ct
            // 
            this.btMa_Ct.Location = new System.Drawing.Point(422, 78);
            this.btMa_Ct.Name = "btMa_Ct";
            this.btMa_Ct.Size = new System.Drawing.Size(27, 22);
            this.btMa_Ct.TabIndex = 144;
            this.btMa_Ct.TabStop = false;
            this.btMa_Ct.Text = "...";
            this.btMa_Ct.UseVisualStyleBackColor = true;
            // 
            // txtNgay_Ct2
            // 
            this.txtNgay_Ct2.bAllowEmpty = true;
            this.txtNgay_Ct2.bRequire = false;
            this.txtNgay_Ct2.bSelectOnFocus = true;
            this.txtNgay_Ct2.bShowDateTimePicker = true;
            this.txtNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct2.Location = new System.Drawing.Point(119, 57);
            this.txtNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct2.Mask = "00/00/0000";
            this.txtNgay_Ct2.Name = "txtNgay_Ct2";
            this.txtNgay_Ct2.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct2.TabIndex = 1;
            this.txtNgay_Ct2.Tag = "Ngay_Ct2";
            // 
            // txtNgay_Ct1
            // 
            this.txtNgay_Ct1.bAllowEmpty = true;
            this.txtNgay_Ct1.bRequire = false;
            this.txtNgay_Ct1.bSelectOnFocus = true;
            this.txtNgay_Ct1.bShowDateTimePicker = true;
            this.txtNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct1.Location = new System.Drawing.Point(119, 34);
            this.txtNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct1.Mask = "00/00/0000";
            this.txtNgay_Ct1.Name = "txtNgay_Ct1";
            this.txtNgay_Ct1.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct1.TabIndex = 0;
            this.txtNgay_Ct1.Tag = "Ngay_Ct1";
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(34, 37);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(46, 13);
            this.lblControl1.TabIndex = 2;
            this.lblControl1.Tag = "Ngay_Ct1";
            this.lblControl1.Text = "Từ ngày";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(34, 60);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(53, 13);
            this.lblControl2.TabIndex = 2;
            this.lblControl2.Tag = "Den_Ngay";
            this.lblControl2.Text = "Đến ngày";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(119, 159);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(141, 17);
            this.chkAll.TabIndex = 120;
            this.chkAll.Tag = "Trans_Voucher";
            this.chkAll.Text = "Chuyển dữ liệu chứng từ";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // chkDuDau
            // 
            this.chkDuDau.AutoSize = true;
            this.chkDuDau.Location = new System.Drawing.Point(119, 182);
            this.chkDuDau.Name = "chkDuDau";
            this.chkDuDau.Size = new System.Drawing.Size(161, 17);
            this.chkDuDau.TabIndex = 120;
            this.chkDuDau.Tag = "Trans_DuDau";
            this.chkDuDau.Text = "Chuyển dữ liệu số dự đầu kỳ";
            this.chkDuDau.UseVisualStyleBackColor = true;
            // 
            // chkTaiSan
            // 
            this.chkTaiSan.AutoSize = true;
            this.chkTaiSan.Location = new System.Drawing.Point(119, 205);
            this.chkTaiSan.Name = "chkTaiSan";
            this.chkTaiSan.Size = new System.Drawing.Size(169, 17);
            this.chkTaiSan.TabIndex = 120;
            this.chkTaiSan.Tag = "Trans_TaiSan";
            this.chkTaiSan.Text = "Chuyển dữ liệu tài sản cố định";
            this.chkTaiSan.UseVisualStyleBackColor = true;
            // 
            // chkDanhMuc
            // 
            this.chkDanhMuc.AutoSize = true;
            this.chkDanhMuc.Location = new System.Drawing.Point(119, 136);
            this.chkDanhMuc.Name = "chkDanhMuc";
            this.chkDanhMuc.Size = new System.Drawing.Size(149, 17);
            this.chkDanhMuc.TabIndex = 120;
            this.chkDanhMuc.Tag = "Trans_List";
            this.chkDanhMuc.Text = "Chuyển  dữ liệu danh mục";
            this.chkDanhMuc.UseVisualStyleBackColor = true;
            // 
            // txtMa_Ct
            // 
            this.txtMa_Ct.bEnabled = true;
            this.txtMa_Ct.bIsLookup = false;
            this.txtMa_Ct.bReadOnly = false;
            this.txtMa_Ct.bRequire = false;
            this.txtMa_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ct.KeyFilter = "";
            this.txtMa_Ct.Location = new System.Drawing.Point(119, 80);
            this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct.MaxLength = 20;
            this.txtMa_Ct.Name = "txtMa_Ct";
            this.txtMa_Ct.Size = new System.Drawing.Size(298, 20);
            this.txtMa_Ct.TabIndex = 142;
            this.txtMa_Ct.UseAutoFilter = false;
            // 
            // lblMa_Ct
            // 
            this.lblMa_Ct.AutoEllipsis = true;
            this.lblMa_Ct.AutoSize = true;
            this.lblMa_Ct.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Ct.Location = new System.Drawing.Point(34, 83);
            this.lblMa_Ct.Name = "lblMa_Ct";
            this.lblMa_Ct.Size = new System.Drawing.Size(35, 13);
            this.lblMa_Ct.TabIndex = 143;
            this.lblMa_Ct.Tag = "Ma_Ct";
            this.lblMa_Ct.Text = "Mã Ct";
            this.lblMa_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbControl1
            // 
            this.grbControl1.Controls.Add(this.chkTaiSan);
            this.grbControl1.Controls.Add(this.btMa_Ct);
            this.grbControl1.Controls.Add(this.txtNgay_Ct2);
            this.grbControl1.Controls.Add(this.lblMa_Ct);
            this.grbControl1.Controls.Add(this.txtNgay_Ct1);
            this.grbControl1.Controls.Add(this.txtMa_Ct);
            this.grbControl1.Controls.Add(this.lblControl1);
            this.grbControl1.Controls.Add(this.chkDanhMuc);
            this.grbControl1.Controls.Add(this.lblControl2);
            this.grbControl1.Controls.Add(this.chkAll);
            this.grbControl1.Controls.Add(this.chkDuDau);
            this.grbControl1.Location = new System.Drawing.Point(21, 14);
            this.grbControl1.Name = "grbControl1";
            this.grbControl1.Size = new System.Drawing.Size(504, 265);
            this.grbControl1.TabIndex = 145;
            this.grbControl1.TabStop = false;
            // 
            // frmTrans_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(860, 495);
            this.Controls.Add(this.grbControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmTrans_Voucher";
            this.Tag = "frmTrans_Voucher";
            this.Text = "frmTrans_Voucher";
            this.grbControl1.ResumeLayout(false);
            this.grbControl1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.btControl btOk;
        private Epoint.Systems.Controls.btControl btCancel;
        private Systems.Controls.btControl btMa_Ct;
        private Systems.Controls.txtDateTime txtNgay_Ct2;
        private Systems.Controls.txtDateTime txtNgay_Ct1;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.chkControl chkAll;
        private Systems.Controls.chkControl chkDuDau;
        private Systems.Controls.chkControl chkTaiSan;
        private Systems.Controls.chkControl chkDanhMuc;
        private Systems.Controls.txtTextBox txtMa_Ct;
        private Systems.Controls.lblControl lblMa_Ct;
        private Systems.Controls.grbControl grbControl1;
	}
}