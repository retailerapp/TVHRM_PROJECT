namespace Epoint.Controllers
{
    partial class frmTrans_DataTax
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrans_DataTax));
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
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.btShowData = new Epoint.Systems.Controls.btControl();
            this.btMa_Ct = new Epoint.Systems.Controls.btControl();
            this.lblMa_Ct = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Ct = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtNgay_Ct1 = new Epoint.Systems.Controls.txtDateTime();
            this.txtNgay_Ct2 = new Epoint.Systems.Controls.txtDateTime();
            this.dgvTransVoucher = new Epoint.Systems.Controls.dgvControl();
            this.tabPageTranList = new System.Windows.Forms.TabPage();
            this.dgvTransList = new Epoint.Systems.Controls.dgvControl();
            this.tabPageKhac = new System.Windows.Forms.TabPage();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.txtNgay_Ct01 = new Epoint.Systems.Controls.txtDateTime();
            this.txtNgay_Ct02 = new Epoint.Systems.Controls.txtDateTime();
            this.chkTaiSan = new Epoint.Systems.Controls.chkControl();
            this.chkDuDau_TonKho = new Epoint.Systems.Controls.chkControl();
            this.chkDuDau_KeToan = new Epoint.Systems.Controls.chkControl();
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
            this.tabControl1.Controls.Add(this.tabPageTranVoucher);
            this.tabControl1.Controls.Add(this.tabPageTranList);
            this.tabControl1.Controls.Add(this.tabPageKhac);
            this.tabControl1.Location = new System.Drawing.Point(7, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(942, 471);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTranVoucher
            // 
            this.tabPageTranVoucher.Controls.Add(this.lblControl5);
            this.tabPageTranVoucher.Controls.Add(this.btShowData);
            this.tabPageTranVoucher.Controls.Add(this.btMa_Ct);
            this.tabPageTranVoucher.Controls.Add(this.lblMa_Ct);
            this.tabPageTranVoucher.Controls.Add(this.txtMa_Ct);
            this.tabPageTranVoucher.Controls.Add(this.lblControl2);
            this.tabPageTranVoucher.Controls.Add(this.lblControl1);
            this.tabPageTranVoucher.Controls.Add(this.txtNgay_Ct1);
            this.tabPageTranVoucher.Controls.Add(this.txtNgay_Ct2);
            this.tabPageTranVoucher.Controls.Add(this.dgvTransVoucher);
            this.tabPageTranVoucher.Location = new System.Drawing.Point(4, 22);
            this.tabPageTranVoucher.Name = "tabPageTranVoucher";
            this.tabPageTranVoucher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTranVoucher.Size = new System.Drawing.Size(934, 445);
            this.tabPageTranVoucher.TabIndex = 0;
            this.tabPageTranVoucher.Tag = "Tranfer_Voucher";
            this.tabPageTranVoucher.Text = "Truyền dữ liệu chứng từ";
            this.tabPageTranVoucher.UseVisualStyleBackColor = true;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Location = new System.Drawing.Point(347, 11);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(439, 13);
            this.lblControl5.TabIndex = 153;
            this.lblControl5.Tag = "TransData_Note";
            this.lblControl5.Text = "Lưu ý: khi luân chuyển dữ liệu, chương trình sẽ mặc định luân chuyển nguyên chứng" +
    " từ gốc";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btShowData
            // 
            this.btShowData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btShowData.Image = ((System.Drawing.Image)(resources.GetObject("btShowData.Image")));
            this.btShowData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btShowData.Location = new System.Drawing.Point(820, 10);
            this.btShowData.Name = "btShowData";
            this.btShowData.Size = new System.Drawing.Size(108, 42);
            this.btShowData.TabIndex = 4;
            this.btShowData.Tag = "ShowVoucher";
            this.btShowData.Text = "Hiển thị dữ liệu";
            this.btShowData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btShowData.UseVisualStyleBackColor = true;
            // 
            // btMa_Ct
            // 
            this.btMa_Ct.Location = new System.Drawing.Point(373, 34);
            this.btMa_Ct.Name = "btMa_Ct";
            this.btMa_Ct.Size = new System.Drawing.Size(27, 22);
            this.btMa_Ct.TabIndex = 3;
            this.btMa_Ct.TabStop = false;
            this.btMa_Ct.Text = "...";
            this.btMa_Ct.UseVisualStyleBackColor = true;
            // 
            // lblMa_Ct
            // 
            this.lblMa_Ct.AutoEllipsis = true;
            this.lblMa_Ct.AutoSize = true;
            this.lblMa_Ct.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Ct.Location = new System.Drawing.Point(10, 38);
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
            this.txtMa_Ct.Location = new System.Drawing.Point(71, 35);
            this.txtMa_Ct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct.MaxLength = 20;
            this.txtMa_Ct.Name = "txtMa_Ct";
            this.txtMa_Ct.Size = new System.Drawing.Size(298, 20);
            this.txtMa_Ct.TabIndex = 2;
            this.txtMa_Ct.UseAutoFilter = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(160, 12);
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
            this.lblControl1.Location = new System.Drawing.Point(10, 12);
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
            this.txtNgay_Ct1.Location = new System.Drawing.Point(71, 9);
            this.txtNgay_Ct1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct1.Mask = "00/00/0000";
            this.txtNgay_Ct1.Name = "txtNgay_Ct1";
            this.txtNgay_Ct1.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct1.TabIndex = 0;
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
            this.txtNgay_Ct2.Location = new System.Drawing.Point(232, 9);
            this.txtNgay_Ct2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNgay_Ct2.Mask = "00/00/0000";
            this.txtNgay_Ct2.Name = "txtNgay_Ct2";
            this.txtNgay_Ct2.Size = new System.Drawing.Size(74, 20);
            this.txtNgay_Ct2.TabIndex = 1;
            this.txtNgay_Ct2.Tag = "Ngay_Ct2";
            // 
            // dgvTransVoucher
            // 
            this.dgvTransVoucher.AllowUserToAddRows = false;
            this.dgvTransVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTransVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvTransVoucher.EnableHeadersVisualStyles = false;
            this.dgvTransVoucher.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTransVoucher.Location = new System.Drawing.Point(6, 61);
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
            this.dgvTransVoucher.Size = new System.Drawing.Size(922, 384);
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
            this.tabPageTranList.Tag = "Tranfer_List";
            this.tabPageTranList.Text = "Truyền dữ liệu danh mục";
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
            this.tabPageKhac.Controls.Add(this.chkDuDau_KeToan);
            this.tabPageKhac.Controls.Add(this.lblControl3);
            this.tabPageKhac.Controls.Add(this.lblControl4);
            this.tabPageKhac.Controls.Add(this.txtNgay_Ct01);
            this.tabPageKhac.Controls.Add(this.txtNgay_Ct02);
            this.tabPageKhac.Controls.Add(this.chkTaiSan);
            this.tabPageKhac.Controls.Add(this.chkDuDau_TonKho);
            this.tabPageKhac.Location = new System.Drawing.Point(4, 22);
            this.tabPageKhac.Name = "tabPageKhac";
            this.tabPageKhac.Size = new System.Drawing.Size(934, 445);
            this.tabPageKhac.TabIndex = 3;
            this.tabPageKhac.Tag = "Tranfer_Other";
            this.tabPageKhac.Text = "Truyền dữ liệu khác";
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
            this.txtNgay_Ct01.TabIndex = 0;
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
            this.txtNgay_Ct02.TabIndex = 1;
            this.txtNgay_Ct02.Tag = "Ngay_Ct2";
            // 
            // chkTaiSan
            // 
            this.chkTaiSan.AutoSize = true;
            this.chkTaiSan.Location = new System.Drawing.Point(41, 158);
            this.chkTaiSan.Name = "chkTaiSan";
            this.chkTaiSan.Size = new System.Drawing.Size(169, 17);
            this.chkTaiSan.TabIndex = 4;
            this.chkTaiSan.Tag = "Trans_TaiSan";
            this.chkTaiSan.Text = "Chuyển dữ liệu tài sản cố định";
            this.chkTaiSan.UseVisualStyleBackColor = true;
            // 
            // chkDuDau_TonKho
            // 
            this.chkDuDau_TonKho.AutoSize = true;
            this.chkDuDau_TonKho.Location = new System.Drawing.Point(41, 135);
            this.chkDuDau_TonKho.Name = "chkDuDau_TonKho";
            this.chkDuDau_TonKho.Size = new System.Drawing.Size(200, 17);
            this.chkDuDau_TonKho.TabIndex = 3;
            this.chkDuDau_TonKho.Tag = "Trans_DuDau_TonKho";
            this.chkDuDau_TonKho.Text = "Chuyển dữ liệu số dư đầu kỳ tồn kho";
            this.chkDuDau_TonKho.UseVisualStyleBackColor = true;
            // 
            // chkDuDau_KeToan
            // 
            this.chkDuDau_KeToan.AutoSize = true;
            this.chkDuDau_KeToan.Location = new System.Drawing.Point(41, 112);
            this.chkDuDau_KeToan.Name = "chkDuDau_KeToan";
            this.chkDuDau_KeToan.Size = new System.Drawing.Size(208, 17);
            this.chkDuDau_KeToan.TabIndex = 2;
            this.chkDuDau_KeToan.Tag = "Trans_DuDau_KeToan";
            this.chkDuDau_KeToan.Text = "Chuyển dữ liệu số dư đầu kỳ tài khoản";
            this.chkDuDau_KeToan.UseVisualStyleBackColor = true;
            // 
            // frmTrans_DataTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(957, 529);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmTrans_DataTax";
            this.Tag = "frmTrans_Voucher";
            this.Text = "frmTrans_Voucher";
            this.tabControl1.ResumeLayout(false);
            this.tabPageTranVoucher.ResumeLayout(false);
            this.tabPageTranVoucher.PerformLayout();
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
        private Systems.Controls.btControl btMa_Ct;
        private Systems.Controls.lblControl lblMa_Ct;
        private Systems.Controls.txtTextBox txtMa_Ct;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.txtDateTime txtNgay_Ct1;
        private Systems.Controls.txtDateTime txtNgay_Ct2;
        private Systems.Controls.btControl btShowData;
        private Systems.Controls.dgvControl dgvTransList;
        private System.Windows.Forms.TabPage tabPageKhac;
        private Systems.Controls.chkControl chkTaiSan;
        private Systems.Controls.chkControl chkDuDau_TonKho;
        private Systems.Controls.lblControl lblControl3;
        private Systems.Controls.lblControl lblControl4;
        private Systems.Controls.txtDateTime txtNgay_Ct01;
        private Systems.Controls.txtDateTime txtNgay_Ct02;
        private Systems.Controls.lblControl lblControl5;
        private Systems.Controls.chkControl chkDuDau_KeToan;
    }
}