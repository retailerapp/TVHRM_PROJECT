namespace Epoint.Lists
{
	partial class frmNhanVien_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien_Edit));
            this.txtSo_CMND = new Epoint.Systems.Controls.txtTextBox();
            this.lbSo_CMND = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Sinh = new Epoint.Systems.Controls.txtDateTime();
            this.lbNgay_Sinh = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Bp = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Bp_Cha = new Epoint.Systems.Controls.lblControl();
            this.txtEmail = new Epoint.Systems.Controls.txtTextBox();
            this.txtSo_Phone = new Epoint.Systems.Controls.txtTextBox();
            this.txtDia_Chi = new Epoint.Systems.Controls.txtTextBox();
            this.txtTen_CbNv = new Epoint.Systems.Controls.txtTextBox();
            this.txtMa_CbNv = new Epoint.Systems.Controls.txtTextBox();
            this.lbEmail = new Epoint.Systems.Controls.lblControl();
            this.lbSo_Phone = new Epoint.Systems.Controls.lblControl();
            this.lbDia_Chi = new Epoint.Systems.Controls.lblControl();
            this.lbTen_CbNv = new Epoint.Systems.Controls.lblControl();
            this.lbMa_CbNv = new Epoint.Systems.Controls.lblControl();
            this.grTitle1 = new System.Windows.Forms.GroupBox();
            this.txtMa_Dt_Tu = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Ca = new Epoint.Systems.Controls.txtTextLookup();
            this.txtMa_Bp = new Epoint.Systems.Controls.txtTextLookup();
            this.lbtTen_Ca = new Epoint.Systems.Controls.lblControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Dt_Tu = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Dt_Tu = new Epoint.Systems.Controls.lblControl();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.grTitle1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(398, 359);
            this.btgAccept.Size = new System.Drawing.Size(170, 33);
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(570, 338);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.grTitle1);
            this.Page1.Size = new System.Drawing.Size(562, 312);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(562, 312);
            // 
            // txtSo_CMND
            // 
            this.txtSo_CMND.bEnabled = true;
            this.txtSo_CMND.bIsLookup = false;
            this.txtSo_CMND.bReadOnly = false;
            this.txtSo_CMND.bRequire = false;
            this.txtSo_CMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo_CMND.KeyFilter = "";
            this.txtSo_CMND.Location = new System.Drawing.Point(128, 127);
            this.txtSo_CMND.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_CMND.MaxLength = 20;
            this.txtSo_CMND.Name = "txtSo_CMND";
            this.txtSo_CMND.Size = new System.Drawing.Size(120, 20);
            this.txtSo_CMND.TabIndex = 4;
            this.txtSo_CMND.UseAutoFilter = false;
            // 
            // lbSo_CMND
            // 
            this.lbSo_CMND.AutoEllipsis = true;
            this.lbSo_CMND.AutoSize = true;
            this.lbSo_CMND.BackColor = System.Drawing.Color.Transparent;
            this.lbSo_CMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSo_CMND.Location = new System.Drawing.Point(17, 131);
            this.lbSo_CMND.Name = "lbSo_CMND";
            this.lbSo_CMND.Size = new System.Drawing.Size(55, 13);
            this.lbSo_CMND.TabIndex = 104;
            this.lbSo_CMND.Tag = "So_CMND";
            this.lbSo_CMND.Text = "Số CMND";
            this.lbSo_CMND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Sinh
            // 
            this.dteNgay_Sinh.bAllowEmpty = true;
            this.dteNgay_Sinh.bRequire = false;
            this.dteNgay_Sinh.bSelectOnFocus = false;
            this.dteNgay_Sinh.bShowDateTimePicker = true;
            this.dteNgay_Sinh.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Sinh.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Sinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Sinh.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Sinh.Location = new System.Drawing.Point(128, 103);
            this.dteNgay_Sinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Sinh.Mask = "00/00/0000";
            this.dteNgay_Sinh.Name = "dteNgay_Sinh";
            this.dteNgay_Sinh.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Sinh.TabIndex = 3;
            // 
            // lbNgay_Sinh
            // 
            this.lbNgay_Sinh.AutoEllipsis = true;
            this.lbNgay_Sinh.AutoSize = true;
            this.lbNgay_Sinh.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Sinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgay_Sinh.Location = new System.Drawing.Point(17, 107);
            this.lbNgay_Sinh.Name = "lbNgay_Sinh";
            this.lbNgay_Sinh.Size = new System.Drawing.Size(54, 13);
            this.lbNgay_Sinh.TabIndex = 103;
            this.lbNgay_Sinh.Tag = "Ngay_Sinh";
            this.lbNgay_Sinh.Text = "Ngày sinh";
            this.lbNgay_Sinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoEllipsis = true;
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Bp.Location = new System.Drawing.Point(253, 82);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(71, 13);
            this.lbtTen_Bp.TabIndex = 102;
            this.lbtTen_Bp.Tag = "Ten_Bp";
            this.lbtTen_Bp.Text = "Tên bộ phận ";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Bp_Cha
            // 
            this.lbMa_Bp_Cha.AutoEllipsis = true;
            this.lbMa_Bp_Cha.AutoSize = true;
            this.lbMa_Bp_Cha.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Bp_Cha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa_Bp_Cha.Location = new System.Drawing.Point(17, 83);
            this.lbMa_Bp_Cha.Name = "lbMa_Bp_Cha";
            this.lbMa_Bp_Cha.Size = new System.Drawing.Size(64, 13);
            this.lbMa_Bp_Cha.TabIndex = 101;
            this.lbMa_Bp_Cha.Tag = "Ma_Bp";
            this.lbMa_Bp_Cha.Text = "Mã bộ phận";
            this.lbMa_Bp_Cha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.bEnabled = true;
            this.txtEmail.bIsLookup = false;
            this.txtEmail.bReadOnly = false;
            this.txtEmail.bRequire = false;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.KeyFilter = "";
            this.txtEmail.Location = new System.Drawing.Point(128, 199);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(375, 20);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.UseAutoFilter = false;
            // 
            // txtSo_Phone
            // 
            this.txtSo_Phone.bEnabled = true;
            this.txtSo_Phone.bIsLookup = false;
            this.txtSo_Phone.bReadOnly = false;
            this.txtSo_Phone.bRequire = false;
            this.txtSo_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo_Phone.KeyFilter = "";
            this.txtSo_Phone.Location = new System.Drawing.Point(128, 151);
            this.txtSo_Phone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtSo_Phone.MaxLength = 20;
            this.txtSo_Phone.Name = "txtSo_Phone";
            this.txtSo_Phone.Size = new System.Drawing.Size(120, 20);
            this.txtSo_Phone.TabIndex = 5;
            this.txtSo_Phone.UseAutoFilter = false;
            // 
            // txtDia_Chi
            // 
            this.txtDia_Chi.bEnabled = true;
            this.txtDia_Chi.bIsLookup = false;
            this.txtDia_Chi.bReadOnly = false;
            this.txtDia_Chi.bRequire = false;
            this.txtDia_Chi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDia_Chi.KeyFilter = "";
            this.txtDia_Chi.Location = new System.Drawing.Point(128, 175);
            this.txtDia_Chi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDia_Chi.MaxLength = 100;
            this.txtDia_Chi.Name = "txtDia_Chi";
            this.txtDia_Chi.Size = new System.Drawing.Size(375, 20);
            this.txtDia_Chi.TabIndex = 6;
            this.txtDia_Chi.UseAutoFilter = false;
            // 
            // txtTen_CbNv
            // 
            this.txtTen_CbNv.bEnabled = true;
            this.txtTen_CbNv.bIsLookup = false;
            this.txtTen_CbNv.bReadOnly = false;
            this.txtTen_CbNv.bRequire = false;
            this.txtTen_CbNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_CbNv.KeyFilter = "";
            this.txtTen_CbNv.Location = new System.Drawing.Point(128, 55);
            this.txtTen_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_CbNv.MaxLength = 100;
            this.txtTen_CbNv.Name = "txtTen_CbNv";
            this.txtTen_CbNv.Size = new System.Drawing.Size(375, 20);
            this.txtTen_CbNv.TabIndex = 1;
            this.txtTen_CbNv.UseAutoFilter = false;
            // 
            // txtMa_CbNv
            // 
            this.txtMa_CbNv.bEnabled = true;
            this.txtMa_CbNv.bIsLookup = false;
            this.txtMa_CbNv.bReadOnly = false;
            this.txtMa_CbNv.bRequire = false;
            this.txtMa_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CbNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_CbNv.KeyFilter = "";
            this.txtMa_CbNv.Location = new System.Drawing.Point(128, 31);
            this.txtMa_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CbNv.MaxLength = 20;
            this.txtMa_CbNv.Name = "txtMa_CbNv";
            this.txtMa_CbNv.Size = new System.Drawing.Size(120, 20);
            this.txtMa_CbNv.TabIndex = 0;
            this.txtMa_CbNv.UseAutoFilter = false;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoEllipsis = true;
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(17, 203);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(32, 13);
            this.lbEmail.TabIndex = 99;
            this.lbEmail.Tag = "Email";
            this.lbEmail.Text = "Email";
            this.lbEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSo_Phone
            // 
            this.lbSo_Phone.AutoEllipsis = true;
            this.lbSo_Phone.AutoSize = true;
            this.lbSo_Phone.BackColor = System.Drawing.Color.Transparent;
            this.lbSo_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSo_Phone.Location = new System.Drawing.Point(17, 155);
            this.lbSo_Phone.Name = "lbSo_Phone";
            this.lbSo_Phone.Size = new System.Drawing.Size(70, 13);
            this.lbSo_Phone.TabIndex = 100;
            this.lbSo_Phone.Tag = "So_Phone";
            this.lbSo_Phone.Text = "Số điện thoại";
            this.lbSo_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDia_Chi
            // 
            this.lbDia_Chi.AutoEllipsis = true;
            this.lbDia_Chi.AutoSize = true;
            this.lbDia_Chi.BackColor = System.Drawing.Color.Transparent;
            this.lbDia_Chi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDia_Chi.Location = new System.Drawing.Point(17, 179);
            this.lbDia_Chi.Name = "lbDia_Chi";
            this.lbDia_Chi.Size = new System.Drawing.Size(40, 13);
            this.lbDia_Chi.TabIndex = 98;
            this.lbDia_Chi.Tag = "Dia_Chi";
            this.lbDia_Chi.Text = "Địa chỉ";
            this.lbDia_Chi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTen_CbNv
            // 
            this.lbTen_CbNv.AutoEllipsis = true;
            this.lbTen_CbNv.AutoSize = true;
            this.lbTen_CbNv.BackColor = System.Drawing.Color.Transparent;
            this.lbTen_CbNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen_CbNv.Location = new System.Drawing.Point(17, 59);
            this.lbTen_CbNv.Name = "lbTen_CbNv";
            this.lbTen_CbNv.Size = new System.Drawing.Size(76, 13);
            this.lbTen_CbNv.TabIndex = 97;
            this.lbTen_CbNv.Tag = "Ten_CbNv";
            this.lbTen_CbNv.Text = "Tên nhân viên";
            this.lbTen_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_CbNv
            // 
            this.lbMa_CbNv.AutoEllipsis = true;
            this.lbMa_CbNv.AutoSize = true;
            this.lbMa_CbNv.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_CbNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa_CbNv.Location = new System.Drawing.Point(17, 35);
            this.lbMa_CbNv.Name = "lbMa_CbNv";
            this.lbMa_CbNv.Size = new System.Drawing.Size(72, 13);
            this.lbMa_CbNv.TabIndex = 96;
            this.lbMa_CbNv.Tag = "Ma_CbNv";
            this.lbMa_CbNv.Text = "Mã nhân viên";
            this.lbMa_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grTitle1
            // 
            this.grTitle1.Controls.Add(this.txtMa_Dt_Tu);
            this.grTitle1.Controls.Add(this.txtMa_Ca);
            this.grTitle1.Controls.Add(this.txtMa_Bp);
            this.grTitle1.Controls.Add(this.lbtTen_Ca);
            this.grTitle1.Controls.Add(this.lblControl2);
            this.grTitle1.Controls.Add(this.lbtTen_Dt_Tu);
            this.grTitle1.Controls.Add(this.lbMa_Dt_Tu);
            this.grTitle1.Controls.Add(this.txtEmail);
            this.grTitle1.Controls.Add(this.txtSo_CMND);
            this.grTitle1.Controls.Add(this.lbMa_CbNv);
            this.grTitle1.Controls.Add(this.lbSo_CMND);
            this.grTitle1.Controls.Add(this.lbTen_CbNv);
            this.grTitle1.Controls.Add(this.dteNgay_Sinh);
            this.grTitle1.Controls.Add(this.lbDia_Chi);
            this.grTitle1.Controls.Add(this.lbNgay_Sinh);
            this.grTitle1.Controls.Add(this.lbSo_Phone);
            this.grTitle1.Controls.Add(this.lbtTen_Bp);
            this.grTitle1.Controls.Add(this.lbEmail);
            this.grTitle1.Controls.Add(this.txtMa_CbNv);
            this.grTitle1.Controls.Add(this.lbMa_Bp_Cha);
            this.grTitle1.Controls.Add(this.txtTen_CbNv);
            this.grTitle1.Controls.Add(this.txtDia_Chi);
            this.grTitle1.Controls.Add(this.txtSo_Phone);
            this.grTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTitle1.Location = new System.Drawing.Point(17, 11);
            this.grTitle1.Name = "grTitle1";
            this.grTitle1.Size = new System.Drawing.Size(525, 286);
            this.grTitle1.TabIndex = 0;
            this.grTitle1.TabStop = false;
            this.grTitle1.Tag = "Staff";
            this.grTitle1.Text = "Cán bộ nhân viên";
            // 
            // txtMa_Dt_Tu
            // 
            this.txtMa_Dt_Tu.bEnabled = true;
            this.txtMa_Dt_Tu.bIsLookup = false;
            this.txtMa_Dt_Tu.bReadOnly = false;
            this.txtMa_Dt_Tu.bRequire = false;
            this.txtMa_Dt_Tu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dt_Tu.ColumnsView = null;
            this.txtMa_Dt_Tu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Dt_Tu.KeyFilter = "Ma_Dt";
            this.txtMa_Dt_Tu.Location = new System.Drawing.Point(128, 247);
            this.txtMa_Dt_Tu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dt_Tu.Name = "txtMa_Dt_Tu";
            this.txtMa_Dt_Tu.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Dt_Tu.TabIndex = 9;
            this.txtMa_Dt_Tu.UseAutoFilter = true;
            // 
            // txtMa_Ca
            // 
            this.txtMa_Ca.bEnabled = true;
            this.txtMa_Ca.bIsLookup = false;
            this.txtMa_Ca.bReadOnly = false;
            this.txtMa_Ca.bRequire = false;
            this.txtMa_Ca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Ca.ColumnsView = null;
            this.txtMa_Ca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Ca.KeyFilter = "Ma_Ca";
            this.txtMa_Ca.Location = new System.Drawing.Point(128, 223);
            this.txtMa_Ca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ca.Name = "txtMa_Ca";
            this.txtMa_Ca.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Ca.TabIndex = 8;
            this.txtMa_Ca.UseAutoFilter = true;
            // 
            // txtMa_Bp
            // 
            this.txtMa_Bp.bEnabled = true;
            this.txtMa_Bp.bIsLookup = false;
            this.txtMa_Bp.bReadOnly = false;
            this.txtMa_Bp.bRequire = false;
            this.txtMa_Bp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Bp.ColumnsView = null;
            this.txtMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa_Bp.KeyFilter = "Ma_Bp";
            this.txtMa_Bp.Location = new System.Drawing.Point(128, 79);
            this.txtMa_Bp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Bp.Name = "txtMa_Bp";
            this.txtMa_Bp.Size = new System.Drawing.Size(120, 20);
            this.txtMa_Bp.TabIndex = 2;
            this.txtMa_Bp.UseAutoFilter = true;
            // 
            // lbtTen_Ca
            // 
            this.lbtTen_Ca.AutoEllipsis = true;
            this.lbtTen_Ca.AutoSize = true;
            this.lbtTen_Ca.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Ca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Ca.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Ca.Location = new System.Drawing.Point(253, 226);
            this.lbtTen_Ca.Name = "lbtTen_Ca";
            this.lbtTen_Ca.Size = new System.Drawing.Size(41, 13);
            this.lbtTen_Ca.TabIndex = 110;
            this.lbtTen_Ca.Tag = "Ten_Ca";
            this.lbtTen_Ca.Text = "Tên ca";
            this.lbtTen_Ca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl2.Location = new System.Drawing.Point(17, 227);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(37, 13);
            this.lblControl2.TabIndex = 109;
            this.lblControl2.Tag = "MA_CA";
            this.lblControl2.Text = "Mã ca";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Dt_Tu
            // 
            this.lbtTen_Dt_Tu.AutoEllipsis = true;
            this.lbtTen_Dt_Tu.AutoSize = true;
            this.lbtTen_Dt_Tu.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_Dt_Tu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Dt_Tu.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_Dt_Tu.Location = new System.Drawing.Point(253, 250);
            this.lbtTen_Dt_Tu.Name = "lbtTen_Dt_Tu";
            this.lbtTen_Dt_Tu.Size = new System.Drawing.Size(115, 13);
            this.lbtTen_Dt_Tu.TabIndex = 107;
            this.lbtTen_Dt_Tu.Tag = "Ten_Dt";
            this.lbtTen_Dt_Tu.Text = "Tên đối tượng tạm ứng";
            this.lbtTen_Dt_Tu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Dt_Tu
            // 
            this.lbMa_Dt_Tu.AutoEllipsis = true;
            this.lbMa_Dt_Tu.AutoSize = true;
            this.lbMa_Dt_Tu.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Dt_Tu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMa_Dt_Tu.Location = new System.Drawing.Point(17, 251);
            this.lbMa_Dt_Tu.Name = "lbMa_Dt_Tu";
            this.lbMa_Dt_Tu.Size = new System.Drawing.Size(94, 13);
            this.lbMa_Dt_Tu.TabIndex = 106;
            this.lbMa_Dt_Tu.Tag = "MA_DT_TU";
            this.lbMa_Dt_Tu.Text = "Đối tượng tạm ứng";
            this.lbMa_Dt_Tu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmNhanVien_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 404);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhanVien_Edit";
            this.Object_ID = "LINHANVIEN";
            this.Tag = "ESC";
            this.Text = "frmNhanVien";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            this.grTitle1.ResumeLayout(false);
            this.grTitle1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtSo_CMND;
		private Epoint.Systems.Controls.lblControl lbSo_CMND;
		private Epoint.Systems.Controls.txtDateTime dteNgay_Sinh;
		private Epoint.Systems.Controls.lblControl lbNgay_Sinh;
        private Epoint.Systems.Controls.lblControl lbtTen_Bp;
		private Epoint.Systems.Controls.lblControl lbMa_Bp_Cha;
		private Epoint.Systems.Controls.txtTextBox txtEmail;
		private Epoint.Systems.Controls.txtTextBox txtSo_Phone;
		private Epoint.Systems.Controls.txtTextBox txtDia_Chi;
		private Epoint.Systems.Controls.txtTextBox txtTen_CbNv;
		private Epoint.Systems.Controls.txtTextBox txtMa_CbNv;
		private Epoint.Systems.Controls.lblControl lbEmail;
		private Epoint.Systems.Controls.lblControl lbSo_Phone;
		private Epoint.Systems.Controls.lblControl lbDia_Chi;
		private Epoint.Systems.Controls.lblControl lbTen_CbNv;
		private Epoint.Systems.Controls.lblControl lbMa_CbNv;
        private System.Windows.Forms.GroupBox grTitle1;
        private Systems.Controls.lblControl lbMa_Dt_Tu;
        private Systems.Controls.lblControl lbtTen_Dt_Tu;
        private Systems.Controls.lblControl lbtTen_Ca;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.txtTextLookup txtMa_Dt_Tu;
        private Systems.Controls.txtTextLookup txtMa_Ca;
        private Systems.Controls.txtTextLookup txtMa_Bp;
	}
}