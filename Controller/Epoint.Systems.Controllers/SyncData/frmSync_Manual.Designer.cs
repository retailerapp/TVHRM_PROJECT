namespace Epoint.Controllers
{
    partial class frmSync_Manual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSync_Manual));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btOk = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.tabControl1 = new Epoint.Systems.Controls.tabControl();
            this.tabPageTranVoucher = new System.Windows.Forms.TabPage();
            this.dgvTransVoucher = new Epoint.Systems.Controls.dgvControl();
            this.tabPageTranList = new System.Windows.Forms.TabPage();
            this.dgvTransList = new Epoint.Systems.Controls.dgvControl();
            this.tabPageKhac = new System.Windows.Forms.TabPage();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.txtNgay_Ct01 = new Epoint.Systems.Controls.txtDateTime();
            this.txtNgay_Ct02 = new Epoint.Systems.Controls.txtDateTime();
            this.chkTaiSan = new Epoint.Systems.Controls.chkControl();
            this.chkDuDau = new Epoint.Systems.Controls.chkControl();
            this.tabControl1.SuspendLayout();
            this.tabPageTranVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransVoucher)).BeginInit();
            this.tabPageTranList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransList)).BeginInit();
            this.tabPageKhac.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.Blue;
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(786, 485);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(79, 35);
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
            this.btCancel.Location = new System.Drawing.Point(869, 485);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(79, 35);
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
            this.tabControl1.Controls.Add(this.tabPageTranVoucher);
            this.tabControl1.Controls.Add(this.tabPageTranList);
            this.tabControl1.Controls.Add(this.tabPageKhac);
            this.tabControl1.Location = new System.Drawing.Point(7, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(942, 471);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPageTranVoucher
            // 
            this.tabPageTranVoucher.Controls.Add(this.dgvTransVoucher);
            this.tabPageTranVoucher.Location = new System.Drawing.Point(4, 22);
            this.tabPageTranVoucher.Name = "tabPageTranVoucher";
            this.tabPageTranVoucher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTranVoucher.Size = new System.Drawing.Size(934, 445);
            this.tabPageTranVoucher.TabIndex = 0;
            this.tabPageTranVoucher.Tag = "";
            this.tabPageTranVoucher.Text = "Sync Voucher";
            this.tabPageTranVoucher.UseVisualStyleBackColor = true;
            // 
            // dgvTransVoucher
            // 
            this.dgvTransVoucher.AllowUserToAddRows = false;
            this.dgvTransVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTransVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransVoucher.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransVoucher.EnableHeadersVisualStyles = false;
            this.dgvTransVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTransVoucher.Location = new System.Drawing.Point(3, 3);
            this.dgvTransVoucher.MultiSelect = false;
            this.dgvTransVoucher.Name = "dgvTransVoucher";
            this.dgvTransVoucher.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransVoucher.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTransVoucher.Size = new System.Drawing.Size(928, 439);
            this.dgvTransVoucher.strZone = "";
            this.dgvTransVoucher.TabIndex = 4;
            // 
            // tabPageTranList
            // 
            this.tabPageTranList.Controls.Add(this.dgvTransList);
            this.tabPageTranList.Location = new System.Drawing.Point(4, 22);
            this.tabPageTranList.Name = "tabPageTranList";
            this.tabPageTranList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTranList.Size = new System.Drawing.Size(934, 445);
            this.tabPageTranList.TabIndex = 2;
            this.tabPageTranList.Tag = "";
            this.tabPageTranList.Text = "Sync List";
            this.tabPageTranList.UseVisualStyleBackColor = true;
            // 
            // dgvTransList
            // 
            this.dgvTransList.AllowUserToAddRows = false;
            this.dgvTransList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTransList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTransList.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTransList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransList.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTransList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransList.EnableHeadersVisualStyles = false;
            this.dgvTransList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTransList.Location = new System.Drawing.Point(3, 3);
            this.dgvTransList.MultiSelect = false;
            this.dgvTransList.Name = "dgvTransList";
            this.dgvTransList.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTransList.Size = new System.Drawing.Size(928, 439);
            this.dgvTransList.strZone = "";
            this.dgvTransList.TabIndex = 5;
            // 
            // tabPageKhac
            // 
            this.tabPageKhac.Controls.Add(this.lblControl3);
            this.tabPageKhac.Controls.Add(this.lblControl4);
            this.tabPageKhac.Controls.Add(this.txtNgay_Ct01);
            this.tabPageKhac.Controls.Add(this.txtNgay_Ct02);
            this.tabPageKhac.Controls.Add(this.chkTaiSan);
            this.tabPageKhac.Controls.Add(this.chkDuDau);
            this.tabPageKhac.Location = new System.Drawing.Point(4, 22);
            this.tabPageKhac.Name = "tabPageKhac";
            this.tabPageKhac.Size = new System.Drawing.Size(934, 445);
            this.tabPageKhac.TabIndex = 3;
            this.tabPageKhac.Tag = "";
            this.tabPageKhac.Text = "Sync Other";
            this.tabPageKhac.UseVisualStyleBackColor = true;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(31, 54);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(53, 13);
            this.lblControl3.TabIndex = 152;
            this.lblControl3.Tag = "Den_Ngay";
            this.lblControl3.Text = "Đến ngày";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(31, 28);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(46, 13);
            this.lblControl4.TabIndex = 151;
            this.lblControl4.Tag = "Ngay_Ct1";
            this.lblControl4.Text = "Từ ngày";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNgay_Ct01
            // 
            this.txtNgay_Ct01.bAllowEmpty = true;
            this.txtNgay_Ct01.bRequire = false;
            this.txtNgay_Ct01.bSelectOnFocus = true;
            this.txtNgay_Ct01.bShowDateTimePicker = true;
            this.txtNgay_Ct01.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct01.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct01.Location = new System.Drawing.Point(116, 25);
            this.txtNgay_Ct01.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct01.Mask = "00/00/0000";
            this.txtNgay_Ct01.Name = "txtNgay_Ct01";
            this.txtNgay_Ct01.Size = new System.Drawing.Size(79, 20);
            this.txtNgay_Ct01.TabIndex = 149;
            this.txtNgay_Ct01.Tag = "Ngay_Ct1";
            // 
            // txtNgay_Ct02
            // 
            this.txtNgay_Ct02.bAllowEmpty = true;
            this.txtNgay_Ct02.bRequire = false;
            this.txtNgay_Ct02.bSelectOnFocus = true;
            this.txtNgay_Ct02.bShowDateTimePicker = true;
            this.txtNgay_Ct02.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct02.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct02.Location = new System.Drawing.Point(116, 51);
            this.txtNgay_Ct02.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct02.Mask = "00/00/0000";
            this.txtNgay_Ct02.Name = "txtNgay_Ct02";
            this.txtNgay_Ct02.Size = new System.Drawing.Size(79, 20);
            this.txtNgay_Ct02.TabIndex = 150;
            this.txtNgay_Ct02.Tag = "Ngay_Ct2";
            // 
            // chkTaiSan
            // 
            this.chkTaiSan.AutoSize = true;
            this.chkTaiSan.Location = new System.Drawing.Point(34, 133);
            this.chkTaiSan.Name = "chkTaiSan";
            this.chkTaiSan.Size = new System.Drawing.Size(169, 17);
            this.chkTaiSan.TabIndex = 122;
            this.chkTaiSan.Tag = "Trans_TaiSan";
            this.chkTaiSan.Text = "Chuyển dữ liệu tài sản cố định";
            this.chkTaiSan.UseVisualStyleBackColor = true;
            // 
            // chkDuDau
            // 
            this.chkDuDau.AutoSize = true;
            this.chkDuDau.Location = new System.Drawing.Point(34, 110);
            this.chkDuDau.Name = "chkDuDau";
            this.chkDuDau.Size = new System.Drawing.Size(161, 17);
            this.chkDuDau.TabIndex = 121;
            this.chkDuDau.Tag = "Trans_DuDau";
            this.chkDuDau.Text = "Chuyển dữ liệu số dư đầu kỳ";
            this.chkDuDau.UseVisualStyleBackColor = true;
            // 
            // frmSync_Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(957, 529);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmSync_Manual";
            this.Tag = "";
            this.Text = "Sync data";
            this.tabControl1.ResumeLayout(false);
            this.tabPageTranVoucher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransVoucher)).EndInit();
            this.tabPageTranList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransList)).EndInit();
            this.tabPageKhac.ResumeLayout(false);
            this.tabPageKhac.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.btControl btOk;
        private Epoint.Systems.Controls.btControl btCancel;
        private Systems.Controls.tabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTranVoucher;
        private Systems.Controls.dgvControl dgvTransVoucher;
        private System.Windows.Forms.TabPage tabPageTranList;
        private Systems.Controls.dgvControl dgvTransList;
        private System.Windows.Forms.TabPage tabPageKhac;
        private Systems.Controls.chkControl chkTaiSan;
        private Systems.Controls.chkControl chkDuDau;
        private Systems.Controls.lblControl lblControl3;
        private Systems.Controls.lblControl lblControl4;
        private Systems.Controls.txtDateTime txtNgay_Ct01;
        private Systems.Controls.txtDateTime txtNgay_Ct02;
	}
}