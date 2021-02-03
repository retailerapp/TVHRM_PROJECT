namespace Epoint.Controllers
{
	partial class frmCheckData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckData));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Kiểm tra dữ liệu đầu kỳ");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Kiểm tra chứng từ phát sinh");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Đối chiếu logic dữ liệu");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new Epoint.Systems.Controls.tabControl();
            this.pageDkl = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btRun = new Epoint.Systems.Controls.btControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dteNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.lblNgay_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.lblNgay_Ct2 = new Epoint.Systems.Controls.lblControl();
            this.pageCheckDataLogic = new System.Windows.Forms.TabPage();
            this.dgvCheckDataLogic = new Epoint.Systems.Controls.dgvControl();
            this.pageCheckResult = new System.Windows.Forms.TabPage();
            this.dgvCheckData = new Epoint.Systems.Controls.dgvControl();
            this.tabControl1.SuspendLayout();
            this.pageDkl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pageCheckDataLogic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckDataLogic)).BeginInit();
            this.pageCheckResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckData)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageDkl);
            this.tabControl1.Controls.Add(this.pageCheckDataLogic);
            this.tabControl1.Controls.Add(this.pageCheckResult);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 470);
            this.tabControl1.TabIndex = 0;
            // 
            // pageDkl
            // 
            this.pageDkl.Controls.Add(this.groupBox1);
            this.pageDkl.Location = new System.Drawing.Point(4, 22);
            this.pageDkl.Name = "pageDkl";
            this.pageDkl.Padding = new System.Windows.Forms.Padding(3);
            this.pageDkl.Size = new System.Drawing.Size(669, 444);
            this.pageDkl.TabIndex = 0;
            this.pageDkl.Tag = "Filter_Condition";
            this.pageDkl.Text = "Điều kiện lọc";
            this.pageDkl.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btRun);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.dteNgay_Ct2);
            this.groupBox1.Controls.Add(this.lblNgay_Ct1);
            this.groupBox1.Controls.Add(this.dteNgay_Ct1);
            this.groupBox1.Controls.Add(this.lblNgay_Ct2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(54, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 327);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "Check_data";
            this.groupBox1.Text = "Kiểm tra dữ liệu";
            // 
            // btRun
            // 
            this.btRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRun.Image = ((System.Drawing.Image)(resources.GetObject("btRun.Image")));
            this.btRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRun.Location = new System.Drawing.Point(167, 269);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(86, 31);
            this.btRun.TabIndex = 79;
            this.btRun.Tag = "THUC_HIEN";
            this.btRun.Text = "&Thực hiện";
            this.btRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRun.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            listViewItem1.Tag = "Check_Opening";
            listViewItem2.Checked = true;
            listViewItem2.StateImageIndex = 1;
            listViewItem2.Tag = "Check_Arising_Amount";
            listViewItem3.Checked = true;
            listViewItem3.StateImageIndex = 1;
            listViewItem3.Tag = "Check_Data_Logic";
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.Location = new System.Drawing.Point(34, 84);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(219, 159);
            this.listView1.TabIndex = 78;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dữ liệu kiểm tra";
            this.columnHeader1.Width = 213;
            // 
            // dteNgay_Ct2
            // 
            this.dteNgay_Ct2.bAllowEmpty = true;
            this.dteNgay_Ct2.bRequire = false;
            this.dteNgay_Ct2.bSelectOnFocus = false;
            this.dteNgay_Ct2.bShowDateTimePicker = true;
            this.dteNgay_Ct2.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Ct2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct2.Location = new System.Drawing.Point(93, 50);
            this.dteNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct2.Mask = "00/00/0000";
            this.dteNgay_Ct2.Name = "dteNgay_Ct2";
            this.dteNgay_Ct2.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct2.TabIndex = 75;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay_Ct1.Location = new System.Drawing.Point(34, 30);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(46, 13);
            this.lblNgay_Ct1.TabIndex = 76;
            this.lblNgay_Ct1.Tag = "Ngay_Ct1";
            this.lblNgay_Ct1.Text = "Từ ngày";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Ct1
            // 
            this.dteNgay_Ct1.bAllowEmpty = true;
            this.dteNgay_Ct1.bRequire = false;
            this.dteNgay_Ct1.bSelectOnFocus = false;
            this.dteNgay_Ct1.bShowDateTimePicker = true;
            this.dteNgay_Ct1.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ct1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Ct1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ct1.Location = new System.Drawing.Point(93, 26);
            this.dteNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ct1.Mask = "00/00/0000";
            this.dteNgay_Ct1.Name = "dteNgay_Ct1";
            this.dteNgay_Ct1.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ct1.TabIndex = 74;
            // 
            // lblNgay_Ct2
            // 
            this.lblNgay_Ct2.AutoEllipsis = true;
            this.lblNgay_Ct2.AutoSize = true;
            this.lblNgay_Ct2.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay_Ct2.Location = new System.Drawing.Point(34, 53);
            this.lblNgay_Ct2.Name = "lblNgay_Ct2";
            this.lblNgay_Ct2.Size = new System.Drawing.Size(53, 13);
            this.lblNgay_Ct2.TabIndex = 77;
            this.lblNgay_Ct2.Tag = "Ngay_Ct2";
            this.lblNgay_Ct2.Text = "Đến ngày";
            this.lblNgay_Ct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pageCheckDataLogic
            // 
            this.pageCheckDataLogic.Controls.Add(this.dgvCheckDataLogic);
            this.pageCheckDataLogic.Location = new System.Drawing.Point(4, 22);
            this.pageCheckDataLogic.Name = "pageCheckDataLogic";
            this.pageCheckDataLogic.Padding = new System.Windows.Forms.Padding(3);
            this.pageCheckDataLogic.Size = new System.Drawing.Size(669, 444);
            this.pageCheckDataLogic.TabIndex = 2;
            this.pageCheckDataLogic.Tag = "CheckLogic_Register";
            this.pageCheckDataLogic.Text = "Khai báo đối chiếu logic dữ liệu";
            this.pageCheckDataLogic.UseVisualStyleBackColor = true;
            // 
            // dgvCheckDataLogic
            // 
            this.dgvCheckDataLogic.AllowUserToAddRows = false;
            this.dgvCheckDataLogic.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCheckDataLogic.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCheckDataLogic.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckDataLogic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCheckDataLogic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckDataLogic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckDataLogic.EnableHeadersVisualStyles = false;
            this.dgvCheckDataLogic.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCheckDataLogic.Location = new System.Drawing.Point(3, 3);
            this.dgvCheckDataLogic.MultiSelect = false;
            this.dgvCheckDataLogic.Name = "dgvCheckDataLogic";
            this.dgvCheckDataLogic.ReadOnly = true;
            this.dgvCheckDataLogic.Size = new System.Drawing.Size(663, 438);
            this.dgvCheckDataLogic.strZone = "";
            this.dgvCheckDataLogic.TabIndex = 3;
            // 
            // pageCheckResult
            // 
            this.pageCheckResult.Controls.Add(this.dgvCheckData);
            this.pageCheckResult.Location = new System.Drawing.Point(4, 22);
            this.pageCheckResult.Name = "pageCheckResult";
            this.pageCheckResult.Padding = new System.Windows.Forms.Padding(3);
            this.pageCheckResult.Size = new System.Drawing.Size(669, 444);
            this.pageCheckResult.TabIndex = 1;
            this.pageCheckResult.Tag = "Check_Result";
            this.pageCheckResult.Text = "Kết quả kiểm tra dữ liệu";
            this.pageCheckResult.UseVisualStyleBackColor = true;
            // 
            // dgvCheckData
            // 
            this.dgvCheckData.AllowUserToAddRows = false;
            this.dgvCheckData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCheckData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCheckData.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCheckData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckData.EnableHeadersVisualStyles = false;
            this.dgvCheckData.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCheckData.Location = new System.Drawing.Point(3, 3);
            this.dgvCheckData.MultiSelect = false;
            this.dgvCheckData.Name = "dgvCheckData";
            this.dgvCheckData.ReadOnly = true;
            this.dgvCheckData.Size = new System.Drawing.Size(663, 438);
            this.dgvCheckData.strZone = "";
            this.dgvCheckData.TabIndex = 2;
            // 
            // frmCheckData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 476);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmCheckData";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmCheckData";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.pageDkl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pageCheckDataLogic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckDataLogic)).EndInit();
            this.pageCheckResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckData)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.tabControl tabControl1;
		private System.Windows.Forms.TabPage pageDkl;
		private System.Windows.Forms.TabPage pageCheckResult;
		public Epoint.Systems.Controls.txtDateTime dteNgay_Ct2;
		private Epoint.Systems.Controls.lblControl lblNgay_Ct1;
		public Epoint.Systems.Controls.txtDateTime dteNgay_Ct1;
		private Epoint.Systems.Controls.lblControl lblNgay_Ct2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private Epoint.Systems.Controls.btControl btRun;
		private Epoint.Systems.Controls.dgvControl dgvCheckData;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage pageCheckDataLogic;
		private Epoint.Systems.Controls.dgvControl dgvCheckDataLogic;
	}
}