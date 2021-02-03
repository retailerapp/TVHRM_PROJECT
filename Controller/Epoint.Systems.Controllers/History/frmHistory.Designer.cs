namespace Epoint.Controllers
{
	partial class frmHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistory));
            this.tabControl1 = new Epoint.Systems.Controls.tabControl();
            this.pageHistoryVoucher = new System.Windows.Forms.TabPage();
            this.dgvHistoryVoucher = new Epoint.Systems.Controls.dgvControl();
            this.pageHistoryOther = new System.Windows.Forms.TabPage();
            this.dgvHistoryOther = new Epoint.Systems.Controls.dgvControl();
            this.lblNgay_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.lblNgay_Ct2 = new Epoint.Systems.Controls.lblControl();
            this.txtMember_ID = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.dteNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.btRun = new Epoint.Systems.Controls.btControl();
            this.btDelete = new Epoint.Systems.Controls.btControl();
            this.lbtData_Type = new Epoint.Systems.Controls.lblControl();
            this.enuData_Type = new Epoint.Systems.Controls.txtEnum();
            this.lblData_Type = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Ct = new Epoint.Systems.Controls.txtTextLookup();
            this.lblMa_Ct = new Epoint.Systems.Controls.lblControl();
            this.tabControl1.SuspendLayout();
            this.pageHistoryVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryVoucher)).BeginInit();
            this.pageHistoryOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryOther)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.pageHistoryVoucher);
            this.tabControl1.Controls.Add(this.pageHistoryOther);
            this.tabControl1.Location = new System.Drawing.Point(2, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 492);
            this.tabControl1.TabIndex = 5;
            // 
            // pageHistoryVoucher
            // 
            this.pageHistoryVoucher.Controls.Add(this.dgvHistoryVoucher);
            this.pageHistoryVoucher.Location = new System.Drawing.Point(4, 22);
            this.pageHistoryVoucher.Name = "pageHistoryVoucher";
            this.pageHistoryVoucher.Size = new System.Drawing.Size(779, 466);
            this.pageHistoryVoucher.TabIndex = 2;
            this.pageHistoryVoucher.Tag = "History_Voucher";
            this.pageHistoryVoucher.Text = "Lịch sử dữ liệu chứng từ";
            this.pageHistoryVoucher.UseVisualStyleBackColor = true;
            // 
            // dgvHistoryVoucher
            // 
            this.dgvHistoryVoucher.AllowUserToAddRows = false;
            this.dgvHistoryVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHistoryVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistoryVoucher.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistoryVoucher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistoryVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistoryVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistoryVoucher.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistoryVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoryVoucher.EnableHeadersVisualStyles = false;
            this.dgvHistoryVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvHistoryVoucher.Location = new System.Drawing.Point(0, 0);
            this.dgvHistoryVoucher.MultiSelect = false;
            this.dgvHistoryVoucher.Name = "dgvHistoryVoucher";
            this.dgvHistoryVoucher.ReadOnly = true;
            this.dgvHistoryVoucher.Size = new System.Drawing.Size(779, 466);
            this.dgvHistoryVoucher.strZone = "";
            this.dgvHistoryVoucher.TabIndex = 6;
            // 
            // pageHistoryOther
            // 
            this.pageHistoryOther.Controls.Add(this.dgvHistoryOther);
            this.pageHistoryOther.Location = new System.Drawing.Point(4, 22);
            this.pageHistoryOther.Name = "pageHistoryOther";
            this.pageHistoryOther.Size = new System.Drawing.Size(779, 466);
            this.pageHistoryOther.TabIndex = 1;
            this.pageHistoryOther.Tag = "History_Other";
            this.pageHistoryOther.Text = "Lịch sử dữ liệu khác";
            this.pageHistoryOther.UseVisualStyleBackColor = true;
            // 
            // dgvHistoryOther
            // 
            this.dgvHistoryOther.AllowUserToAddRows = false;
            this.dgvHistoryOther.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHistoryOther.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistoryOther.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistoryOther.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistoryOther.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistoryOther.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistoryOther.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHistoryOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoryOther.EnableHeadersVisualStyles = false;
            this.dgvHistoryOther.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvHistoryOther.Location = new System.Drawing.Point(0, 0);
            this.dgvHistoryOther.MultiSelect = false;
            this.dgvHistoryOther.Name = "dgvHistoryOther";
            this.dgvHistoryOther.ReadOnly = true;
            this.dgvHistoryOther.Size = new System.Drawing.Size(778, 475);
            this.dgvHistoryOther.strZone = "";
            this.dgvHistoryOther.TabIndex = 7;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct1.Location = new System.Drawing.Point(15, 18);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct1.TabIndex = 76;
            this.lblNgay_Ct1.Tag = "Ngay_Ct1";
            this.lblNgay_Ct1.Text = "Từ ngày";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Ct2
            // 
            this.lblNgay_Ct2.AutoEllipsis = true;
            this.lblNgay_Ct2.AutoSize = true;
            this.lblNgay_Ct2.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct2.Location = new System.Drawing.Point(15, 42);
            this.lblNgay_Ct2.Name = "lblNgay_Ct2";
            this.lblNgay_Ct2.Size = new System.Drawing.Size(53, 13);
            this.lblNgay_Ct2.TabIndex = 77;
            this.lblNgay_Ct2.Tag = "Ngay_Ct2";
            this.lblNgay_Ct2.Text = "Đến ngày";
            this.lblNgay_Ct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMember_ID
            // 
            this.txtMember_ID.bEnabled = true;
            this.txtMember_ID.bIsLookup = false;
            this.txtMember_ID.bReadOnly = false;
            this.txtMember_ID.bRequire = false;
            this.txtMember_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMember_ID.KeyFilter = "";
            this.txtMember_ID.Location = new System.Drawing.Point(494, 15);
            this.txtMember_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMember_ID.Name = "txtMember_ID";
            this.txtMember_ID.Size = new System.Drawing.Size(92, 20);
            this.txtMember_ID.TabIndex = 4;
            this.txtMember_ID.UseAutoFilter = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(411, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 79;
            this.label2.Tag = "User_ID";
            this.label2.Text = "Mã người dùng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bRequire = false;
            this.dteNgay_Ct2.bSelectOnFocus = true;
            this.dteNgay_Ct2.bShowDateTimePicker = true;
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(78, 39);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(78, 20);
            this.dteNgay_Ct2.TabIndex = 1;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bRequire = false;
            this.dteNgay_Ct1.bSelectOnFocus = true;
            this.dteNgay_Ct1.bShowDateTimePicker = true;
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(78, 15);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(78, 20);
            this.dteNgay_Ct1.TabIndex = 0;
            // 
            // btRun
            // 
            this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRun.Image = ((System.Drawing.Image)(resources.GetObject("btRun.Image")));
            this.btRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRun.Location = new System.Drawing.Point(586, 24);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(82, 38);
            this.btRun.TabIndex = 5;
            this.btRun.Tag = "View";
            this.btRun.Text = "Xem";
            this.btRun.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.Image = ((System.Drawing.Image)(resources.GetObject("btDelete.Image")));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.Location = new System.Drawing.Point(672, 24);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(113, 38);
            this.btDelete.TabIndex = 6;
            this.btDelete.Tag = "History_Delete";
            this.btDelete.Text = "Xóa lịch sử";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // lbtData_Type
            // 
            this.lbtData_Type.AutoEllipsis = true;
            this.lbtData_Type.AutoSize = true;
            this.lbtData_Type.BackColor = System.Drawing.Color.Transparent;
            this.lbtData_Type.ForeColor = System.Drawing.Color.Blue;
            this.lbtData_Type.Location = new System.Drawing.Point(296, 43);
            this.lbtData_Type.Name = "lbtData_Type";
            this.lbtData_Type.Size = new System.Drawing.Size(262, 13);
            this.lbtData_Type.TabIndex = 81;
            this.lbtData_Type.Tag = "History_Type";
            this.lbtData_Type.Text = "1-Dữ liệu thêm mới, 2-Dữ liệu đã sửa, 3-Dữ liệu đã xóa";
            this.lbtData_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuData_Type
            // 
            this.enuData_Type.bEnabled = true;
            this.enuData_Type.bIsLookup = false;
            this.enuData_Type.bReadOnly = false;
            this.enuData_Type.bRequire = false;
            this.enuData_Type.InputMask = "1,2,3";
            this.enuData_Type.KeyFilter = "";
            this.enuData_Type.Location = new System.Drawing.Point(261, 39);
            this.enuData_Type.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.enuData_Type.Name = "enuData_Type";
            this.enuData_Type.Size = new System.Drawing.Size(29, 20);
            this.enuData_Type.TabIndex = 3;
            this.enuData_Type.Text = "3";
            this.enuData_Type.UseAutoFilter = false;
            // 
            // lblData_Type
            // 
            this.lblData_Type.AutoEllipsis = true;
            this.lblData_Type.AutoSize = true;
            this.lblData_Type.BackColor = System.Drawing.Color.Transparent;
            this.lblData_Type.Location = new System.Drawing.Point(186, 42);
            this.lblData_Type.Name = "lblData_Type";
            this.lblData_Type.Size = new System.Drawing.Size(61, 13);
            this.lblData_Type.TabIndex = 82;
            this.lblData_Type.Tag = "Data_Type";
            this.lblData_Type.Text = "Loại dữ liệu";
            this.lblData_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ct
            // 
            this.txtMa_Ct.bEnabled = true;
            this.txtMa_Ct.bIsLookup = false;
            this.txtMa_Ct.bReadOnly = false;
            this.txtMa_Ct.bRequire = false;
            this.txtMa_Ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ct.ColumnsView = null;
            this.txtMa_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Ct.KeyFilter = "Ma_Ct";
            this.txtMa_Ct.Location = new System.Drawing.Point(261, 15);
            this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct.Name = "txtMa_Ct";
            this.txtMa_Ct.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Ct.TabIndex = 2;
            this.txtMa_Ct.UseAutoFilter = true;
            // 
            // lblMa_Ct
            // 
            this.lblMa_Ct.AutoEllipsis = true;
            this.lblMa_Ct.AutoSize = true;
            this.lblMa_Ct.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa_Ct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMa_Ct.Location = new System.Drawing.Point(186, 18);
            this.lblMa_Ct.Name = "lblMa_Ct";
            this.lblMa_Ct.Size = new System.Drawing.Size(67, 13);
            this.lblMa_Ct.TabIndex = 84;
            this.lblMa_Ct.Tag = "Ma_Ct";
            this.lblMa_Ct.Text = "Mã chứng từ";
            this.lblMa_Ct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.txtMa_Ct);
            this.Controls.Add(this.lblMa_Ct);
            this.Controls.Add(this.lbtData_Type);
            this.Controls.Add(this.enuData_Type);
            this.Controls.Add(this.lblData_Type);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.dteNgay_Ct2);
            this.Controls.Add(this.dteNgay_Ct1);
            this.Controls.Add(this.txtMember_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblNgay_Ct1);
            this.Controls.Add(this.lblNgay_Ct2);
            this.Name = "frmHistory";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmHistory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.pageHistoryVoucher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryVoucher)).EndInit();
            this.pageHistoryOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryOther)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.tabControl tabControl1;
        private System.Windows.Forms.TabPage pageHistoryOther;
        private Epoint.Systems.Controls.lblControl lblNgay_Ct1;
        private Epoint.Systems.Controls.lblControl lblNgay_Ct2;
		private Epoint.Systems.Controls.txtTextBox txtMember_ID;
        private Epoint.Systems.Controls.lblControl label2;
        private Systems.Controls.txtDateTime dteNgay_Ct2;
        private Systems.Controls.txtDateTime dteNgay_Ct1;
        private Systems.Controls.btControl btRun;
        private Systems.Controls.btControl btDelete;
        private System.Windows.Forms.TabPage pageHistoryVoucher;
        private Systems.Controls.dgvControl dgvHistoryVoucher;
        private Systems.Controls.dgvControl dgvHistoryOther;
        private Systems.Controls.lblControl lbtData_Type;
        private Systems.Controls.txtEnum enuData_Type;
        private Systems.Controls.lblControl lblData_Type;
        private Systems.Controls.txtTextLookup txtMa_Ct;
        private Systems.Controls.lblControl lblMa_Ct;
	}
}