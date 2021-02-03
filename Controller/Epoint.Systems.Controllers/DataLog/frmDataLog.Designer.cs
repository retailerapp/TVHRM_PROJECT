namespace Epoint.Controllers
{
	partial class frmDataLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataLog));
            this.dgvDataLog = new Epoint.Systems.Controls.dgvControl();
            this.txtNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.txtSo_Ct = new Epoint.Systems.Controls.txtTextBox();
            this.txtNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtModify_Date1 = new Epoint.Systems.Controls.txtDateTime();
            this.txtModify_Date2 = new Epoint.Systems.Controls.txtDateTime();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStt = new Epoint.Systems.Controls.txtTextBox();
            this.txtMember_ID = new Epoint.Systems.Controls.txtTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btDeleteAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataLog)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDataLog
            // 
            this.dgvDataLog.AllowUserToAddRows = false;
            this.dgvDataLog.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDataLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataLog.EnableHeadersVisualStyles = false;
            this.dgvDataLog.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDataLog.Location = new System.Drawing.Point(6, 125);
            this.dgvDataLog.MultiSelect = false;
            this.dgvDataLog.Name = "dgvDataLog";
            this.dgvDataLog.ReadOnly = true;
            this.dgvDataLog.Size = new System.Drawing.Size(774, 429);
            this.dgvDataLog.strZone = "";
            this.dgvDataLog.TabIndex = 4;
            // 
            // txtNgay_Ct1
            // 
            this.txtNgay_Ct1.bAllowEmpty = true;
            this.txtNgay_Ct1.bRequire = false;
            this.txtNgay_Ct1.bSelectOnFocus = true;
            this.txtNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct1.Location = new System.Drawing.Point(114, 16);
            this.txtNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct1.Mask = "00/00/0000";
            this.txtNgay_Ct1.Name = "txtNgay_Ct1";
            this.txtNgay_Ct1.Size = new System.Drawing.Size(75, 20);
            this.txtNgay_Ct1.TabIndex = 0;
            // 
            // txtSo_Ct
            // 
            this.txtSo_Ct.bEnabled = true;
            this.txtSo_Ct.bIsLookup = false;
            this.txtSo_Ct.bReadOnly = false;
            this.txtSo_Ct.bRequire = false;
            this.txtSo_Ct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo_Ct.KeyFilter = "";
            this.txtSo_Ct.Location = new System.Drawing.Point(114, 62);
            this.txtSo_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Ct.Name = "txtSo_Ct";
            this.txtSo_Ct.Size = new System.Drawing.Size(114, 20);
            this.txtSo_Ct.TabIndex = 2;
            this.txtSo_Ct.UseAutoFilter = false;
            // 
            // txtNgay_Ct2
            // 
            this.txtNgay_Ct2.bAllowEmpty = true;
            this.txtNgay_Ct2.bRequire = false;
            this.txtNgay_Ct2.bSelectOnFocus = true;
            this.txtNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtNgay_Ct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtNgay_Ct2.Location = new System.Drawing.Point(114, 39);
            this.txtNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct2.Mask = "00/00/0000";
            this.txtNgay_Ct2.Name = "txtNgay_Ct2";
            this.txtNgay_Ct2.Size = new System.Drawing.Size(75, 20);
            this.txtNgay_Ct2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Tag = "Ngay_Ct1";
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Tag = "Ngay_Ct2";
            this.label2.Text = "Đến ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtModify_Date1);
            this.groupBox1.Controls.Add(this.txtModify_Date2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStt);
            this.groupBox1.Controls.Add(this.txtMember_ID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(297, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc các nhật ký sửa đổi";
            // 
            // txtModify_Date1
            // 
            this.txtModify_Date1.bAllowEmpty = true;
            this.txtModify_Date1.bRequire = false;
            this.txtModify_Date1.bSelectOnFocus = true;
            this.txtModify_Date1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtModify_Date1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModify_Date1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtModify_Date1.Location = new System.Drawing.Point(111, 21);
            this.txtModify_Date1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtModify_Date1.Mask = "00/00/0000";
            this.txtModify_Date1.Name = "txtModify_Date1";
            this.txtModify_Date1.Size = new System.Drawing.Size(75, 20);
            this.txtModify_Date1.TabIndex = 0;
            // 
            // txtModify_Date2
            // 
            this.txtModify_Date2.bAllowEmpty = true;
            this.txtModify_Date2.bRequire = false;
            this.txtModify_Date2.bSelectOnFocus = true;
            this.txtModify_Date2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtModify_Date2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModify_Date2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtModify_Date2.Location = new System.Drawing.Point(111, 44);
            this.txtModify_Date2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtModify_Date2.Mask = "00/00/0000";
            this.txtModify_Date2.Name = "txtModify_Date2";
            this.txtModify_Date2.Size = new System.Drawing.Size(75, 20);
            this.txtModify_Date2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(211, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 2;
            this.label7.Tag = "";
            this.label7.Text = "Mã khóa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(211, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 2;
            this.label6.Tag = "";
            this.label6.Text = "Người sửa đổi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.Tag = "Ngay_Ct1";
            this.label4.Text = "Từ ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Tag = "Ngay_Ct2";
            this.label5.Text = "Đến ngày";
            // 
            // txtStt
            // 
            this.txtStt.bEnabled = true;
            this.txtStt.bIsLookup = false;
            this.txtStt.bReadOnly = false;
            this.txtStt.bRequire = false;
            this.txtStt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStt.KeyFilter = "";
            this.txtStt.Location = new System.Drawing.Point(307, 44);
            this.txtStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtStt.Name = "txtStt";
            this.txtStt.Size = new System.Drawing.Size(114, 20);
            this.txtStt.TabIndex = 3;
            this.txtStt.UseAutoFilter = false;
            // 
            // txtMember_ID
            // 
            this.txtMember_ID.bEnabled = true;
            this.txtMember_ID.bIsLookup = false;
            this.txtMember_ID.bReadOnly = false;
            this.txtMember_ID.bRequire = false;
            this.txtMember_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMember_ID.KeyFilter = "";
            this.txtMember_ID.Location = new System.Drawing.Point(307, 21);
            this.txtMember_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMember_ID.Name = "txtMember_ID";
            this.txtMember_ID.Size = new System.Drawing.Size(114, 20);
            this.txtMember_ID.TabIndex = 2;
            this.txtMember_ID.UseAutoFilter = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNgay_Ct1);
            this.groupBox2.Controls.Add(this.txtNgay_Ct2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSo_Ct);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 90);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc các dữ liệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Tag = "So_Ct";
            this.label3.Text = "Số chứng từ";
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRefresh.Location = new System.Drawing.Point(553, 92);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(101, 29);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Tag = "";
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            // 
            // btDeleteAll
            // 
            this.btDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("btDeleteAll.Image")));
            this.btDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeleteAll.Location = new System.Drawing.Point(663, 92);
            this.btDeleteAll.Name = "btDeleteAll";
            this.btDeleteAll.Size = new System.Drawing.Size(113, 29);
            this.btDeleteAll.TabIndex = 3;
            this.btDeleteAll.Tag = "";
            this.btDeleteAll.Text = "Xóa toàn bộ";
            this.btDeleteAll.UseVisualStyleBackColor = true;
            // 
            // frmDataLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btDeleteAll);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDataLog);
            this.Name = "frmDataLog";
            this.Tag = "frmDataLog,F2,F3,F8,ESC";
            this.Text = "frmDataLog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataLog)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.dgvControl dgvDataLog;
		private Epoint.Systems.Controls.txtDateTime txtNgay_Ct1;
		private Epoint.Systems.Controls.txtTextBox txtSo_Ct;
		private Epoint.Systems.Controls.txtDateTime txtNgay_Ct2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private Epoint.Systems.Controls.txtDateTime txtModify_Date1;
		private Epoint.Systems.Controls.txtDateTime txtModify_Date2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Epoint.Systems.Controls.txtTextBox txtMember_ID;
		private System.Windows.Forms.Button btRefresh;
		private System.Windows.Forms.Button btDeleteAll;
		private System.Windows.Forms.Label label7;
		private Epoint.Systems.Controls.txtTextBox txtStt;
	}
}