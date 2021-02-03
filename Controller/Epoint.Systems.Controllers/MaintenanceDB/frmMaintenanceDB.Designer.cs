namespace Epoint.Controllers
{
	partial class frmMaintenanceDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintenanceDB));
            this.tabCheckDB = new Epoint.Systems.Controls.tabControl();
            this.tpBackup = new System.Windows.Forms.TabPage();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblBackupPath = new Epoint.Systems.Controls.lblControl();
            this.txtBackupPath = new Epoint.Systems.Controls.txtTextBox();
            this.tpRestore = new System.Windows.Forms.TabPage();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.btRestorePath = new Epoint.Systems.Controls.btControl();
            this.lblBackupFileList = new Epoint.Systems.Controls.lblControl();
            this.lblRestorePath = new Epoint.Systems.Controls.lblControl();
            this.txtRestorePath = new Epoint.Systems.Controls.txtTextBox();
            this.cboBackupFileList = new Epoint.Systems.Controls.cboMultiControl();
            this.tpCheckDB = new System.Windows.Forms.TabPage();
            this.grbCHECKDB = new Epoint.Systems.Controls.grbControl();
            this.rdbRepairAllowDataLost = new Epoint.Systems.Controls.rdbControl();
            this.rdbRepairRebuild = new Epoint.Systems.Controls.rdbControl();
            this.rdbRepairFast = new Epoint.Systems.Controls.rdbControl();
            this.rdbNomal = new Epoint.Systems.Controls.rdbControl();
            this.tpAutoBackup = new System.Windows.Forms.TabPage();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCN = new System.Windows.Forms.CheckBox();
            this.chkThu7 = new System.Windows.Forms.CheckBox();
            this.chkThu6 = new System.Windows.Forms.CheckBox();
            this.chkThu5 = new System.Windows.Forms.CheckBox();
            this.chkThu4 = new System.Windows.Forms.CheckBox();
            this.chkThu3 = new System.Windows.Forms.CheckBox();
            this.chkThu2 = new System.Windows.Forms.CheckBox();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.txtAutoBackupPath = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btContinue = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.btShrinkDB = new Epoint.Systems.Controls.btControl();
            this.tabCheckDB.SuspendLayout();
            this.tpBackup.SuspendLayout();
            this.tpRestore.SuspendLayout();
            this.tpCheckDB.SuspendLayout();
            this.grbCHECKDB.SuspendLayout();
            this.tpAutoBackup.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCheckDB
            // 
            this.tabCheckDB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCheckDB.Controls.Add(this.tpBackup);
            this.tabCheckDB.Controls.Add(this.tpRestore);
            this.tabCheckDB.Controls.Add(this.tpCheckDB);
            this.tabCheckDB.Controls.Add(this.tpAutoBackup);
            this.tabCheckDB.Controls.Add(this.tabPage7);
            this.tabCheckDB.Location = new System.Drawing.Point(10, 12);
            this.tabCheckDB.Multiline = true;
            this.tabCheckDB.Name = "tabCheckDB";
            this.tabCheckDB.SelectedIndex = 0;
            this.tabCheckDB.Size = new System.Drawing.Size(609, 226);
            this.tabCheckDB.TabIndex = 0;
            // 
            // tpBackup
            // 
            this.tpBackup.Controls.Add(this.lblControl1);
            this.tpBackup.Controls.Add(this.lblBackupPath);
            this.tpBackup.Controls.Add(this.txtBackupPath);
            this.tpBackup.Location = new System.Drawing.Point(4, 22);
            this.tpBackup.Name = "tpBackup";
            this.tpBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tpBackup.Size = new System.Drawing.Size(601, 200);
            this.tpBackup.TabIndex = 0;
            this.tpBackup.Tag = "Backup";
            this.tpBackup.Text = "Sao lưu dữ liệu";
            this.tpBackup.UseVisualStyleBackColor = true;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(27, 50);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(80, 13);
            this.lblControl1.TabIndex = 58;
            this.lblControl1.Tag = "ON_SERVER";
            this.lblControl1.Text = "( trên máy chủ )";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoEllipsis = true;
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupPath.Location = new System.Drawing.Point(19, 34);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(97, 13);
            this.lblBackupPath.TabIndex = 58;
            this.lblBackupPath.Tag = "Backup_Path";
            this.lblBackupPath.Text = "Đường dẫn sao lưu";
            this.lblBackupPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.bEnabled = true;
            this.txtBackupPath.bIsLookup = false;
            this.txtBackupPath.bReadOnly = false;
            this.txtBackupPath.bRequire = false;
            this.txtBackupPath.KeyFilter = "";
            this.txtBackupPath.Location = new System.Drawing.Point(121, 32);
            this.txtBackupPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(456, 20);
            this.txtBackupPath.TabIndex = 57;
            this.txtBackupPath.UseAutoFilter = false;
            // 
            // tpRestore
            // 
            this.tpRestore.Controls.Add(this.lblControl2);
            this.tpRestore.Controls.Add(this.btRestorePath);
            this.tpRestore.Controls.Add(this.lblBackupFileList);
            this.tpRestore.Controls.Add(this.lblRestorePath);
            this.tpRestore.Controls.Add(this.txtRestorePath);
            this.tpRestore.Controls.Add(this.cboBackupFileList);
            this.tpRestore.Location = new System.Drawing.Point(4, 22);
            this.tpRestore.Name = "tpRestore";
            this.tpRestore.Padding = new System.Windows.Forms.Padding(3);
            this.tpRestore.Size = new System.Drawing.Size(601, 200);
            this.tpRestore.TabIndex = 1;
            this.tpRestore.Tag = "Restore";
            this.tpRestore.Text = "Phục hồi dữ liệu";
            this.tpRestore.UseVisualStyleBackColor = true;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(23, 72);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(80, 13);
            this.lblControl2.TabIndex = 64;
            this.lblControl2.Tag = "ON_SERVER";
            this.lblControl2.Text = "( trên máy chủ )";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRestorePath
            // 
            this.btRestorePath.Image = ((System.Drawing.Image)(resources.GetObject("btRestorePath.Image")));
            this.btRestorePath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRestorePath.Location = new System.Drawing.Point(549, 54);
            this.btRestorePath.Name = "btRestorePath";
            this.btRestorePath.Size = new System.Drawing.Size(37, 22);
            this.btRestorePath.TabIndex = 61;
            this.btRestorePath.Tag = "";
            this.btRestorePath.Text = "...";
            this.btRestorePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRestorePath.UseVisualStyleBackColor = true;
            // 
            // lblBackupFileList
            // 
            this.lblBackupFileList.AutoEllipsis = true;
            this.lblBackupFileList.AutoSize = true;
            this.lblBackupFileList.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupFileList.Location = new System.Drawing.Point(16, 28);
            this.lblBackupFileList.Name = "lblBackupFileList";
            this.lblBackupFileList.Size = new System.Drawing.Size(112, 13);
            this.lblBackupFileList.TabIndex = 63;
            this.lblBackupFileList.Tag = "BackupFileList";
            this.lblBackupFileList.Text = "Danh sách file sao lưu";
            this.lblBackupFileList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRestorePath
            // 
            this.lblRestorePath.AutoEllipsis = true;
            this.lblRestorePath.BackColor = System.Drawing.Color.Transparent;
            this.lblRestorePath.Location = new System.Drawing.Point(16, 56);
            this.lblRestorePath.Name = "lblRestorePath";
            this.lblRestorePath.Size = new System.Drawing.Size(107, 16);
            this.lblRestorePath.TabIndex = 62;
            this.lblRestorePath.Tag = "Restore_Path";
            this.lblRestorePath.Text = "Đường dẫn phục hồi";
            this.lblRestorePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.bEnabled = true;
            this.txtRestorePath.bIsLookup = false;
            this.txtRestorePath.bReadOnly = false;
            this.txtRestorePath.bRequire = false;
            this.txtRestorePath.KeyFilter = "";
            this.txtRestorePath.Location = new System.Drawing.Point(128, 55);
            this.txtRestorePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.Size = new System.Drawing.Size(418, 20);
            this.txtRestorePath.TabIndex = 60;
            this.txtRestorePath.UseAutoFilter = false;
            // 
            // cboBackupFileList
            // 
            this.cboBackupFileList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBackupFileList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboBackupFileList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboBackupFileList.FormattingEnabled = true;
            this.cboBackupFileList.InitValue = null;
            this.cboBackupFileList.Location = new System.Drawing.Point(129, 25);
            this.cboBackupFileList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboBackupFileList.Name = "cboBackupFileList";
            this.cboBackupFileList.Size = new System.Drawing.Size(455, 21);
            this.cboBackupFileList.strValueList = null;
            this.cboBackupFileList.TabIndex = 59;
            this.cboBackupFileList.UseAutoComplete = false;
            this.cboBackupFileList.UseBindingValue = false;
            // 
            // tpCheckDB
            // 
            this.tpCheckDB.Controls.Add(this.grbCHECKDB);
            this.tpCheckDB.Location = new System.Drawing.Point(4, 22);
            this.tpCheckDB.Name = "tpCheckDB";
            this.tpCheckDB.Size = new System.Drawing.Size(601, 200);
            this.tpCheckDB.TabIndex = 3;
            this.tpCheckDB.Tag = "Check_Database";
            this.tpCheckDB.Text = "Kiểm tra, sửa lỗi CSDL";
            this.tpCheckDB.UseVisualStyleBackColor = true;
            // 
            // grbCHECKDB
            // 
            this.grbCHECKDB.Controls.Add(this.rdbRepairAllowDataLost);
            this.grbCHECKDB.Controls.Add(this.rdbRepairRebuild);
            this.grbCHECKDB.Controls.Add(this.rdbRepairFast);
            this.grbCHECKDB.Controls.Add(this.rdbNomal);
            this.grbCHECKDB.Location = new System.Drawing.Point(47, 23);
            this.grbCHECKDB.Name = "grbCHECKDB";
            this.grbCHECKDB.Size = new System.Drawing.Size(328, 125);
            this.grbCHECKDB.TabIndex = 0;
            this.grbCHECKDB.TabStop = false;
            this.grbCHECKDB.Tag = "Check_Database_Type";
            this.grbCHECKDB.Text = "Chọn loại kiểm tra CSDL";
            // 
            // rdbRepairAllowDataLost
            // 
            this.rdbRepairAllowDataLost.AutoSize = true;
            this.rdbRepairAllowDataLost.Location = new System.Drawing.Point(24, 88);
            this.rdbRepairAllowDataLost.Name = "rdbRepairAllowDataLost";
            this.rdbRepairAllowDataLost.Size = new System.Drawing.Size(126, 17);
            this.rdbRepairAllowDataLost.TabIndex = 0;
            this.rdbRepairAllowDataLost.TabStop = true;
            this.rdbRepairAllowDataLost.Text = "Repair allow data lost";
            this.rdbRepairAllowDataLost.UnChecked = true;
            this.rdbRepairAllowDataLost.UseVisualStyleBackColor = true;
            // 
            // rdbRepairRebuild
            // 
            this.rdbRepairRebuild.AutoSize = true;
            this.rdbRepairRebuild.Location = new System.Drawing.Point(24, 65);
            this.rdbRepairRebuild.Name = "rdbRepairRebuild";
            this.rdbRepairRebuild.Size = new System.Drawing.Size(90, 17);
            this.rdbRepairRebuild.TabIndex = 0;
            this.rdbRepairRebuild.TabStop = true;
            this.rdbRepairRebuild.Text = "Repair rebuild";
            this.rdbRepairRebuild.UnChecked = true;
            this.rdbRepairRebuild.UseVisualStyleBackColor = true;
            // 
            // rdbRepairFast
            // 
            this.rdbRepairFast.AutoSize = true;
            this.rdbRepairFast.Location = new System.Drawing.Point(24, 42);
            this.rdbRepairFast.Name = "rdbRepairFast";
            this.rdbRepairFast.Size = new System.Drawing.Size(76, 17);
            this.rdbRepairFast.TabIndex = 0;
            this.rdbRepairFast.TabStop = true;
            this.rdbRepairFast.Text = "Repair fast";
            this.rdbRepairFast.UnChecked = true;
            this.rdbRepairFast.UseVisualStyleBackColor = true;
            // 
            // rdbNomal
            // 
            this.rdbNomal.AutoSize = true;
            this.rdbNomal.Checked = true;
            this.rdbNomal.Location = new System.Drawing.Point(24, 19);
            this.rdbNomal.Name = "rdbNomal";
            this.rdbNomal.Size = new System.Drawing.Size(58, 17);
            this.rdbNomal.TabIndex = 0;
            this.rdbNomal.TabStop = true;
            this.rdbNomal.Text = "Normal";
            this.rdbNomal.UnChecked = false;
            this.rdbNomal.UseVisualStyleBackColor = true;
            // 
            // tpAutoBackup
            // 
            this.tpAutoBackup.Controls.Add(this.lblControl4);
            this.tpAutoBackup.Controls.Add(this.label4);
            this.tpAutoBackup.Controls.Add(this.label3);
            this.tpAutoBackup.Controls.Add(this.chkCN);
            this.tpAutoBackup.Controls.Add(this.chkThu7);
            this.tpAutoBackup.Controls.Add(this.chkThu6);
            this.tpAutoBackup.Controls.Add(this.chkThu5);
            this.tpAutoBackup.Controls.Add(this.chkThu4);
            this.tpAutoBackup.Controls.Add(this.chkThu3);
            this.tpAutoBackup.Controls.Add(this.chkThu2);
            this.tpAutoBackup.Controls.Add(this.txtTime);
            this.tpAutoBackup.Controls.Add(this.lblControl3);
            this.tpAutoBackup.Controls.Add(this.txtAutoBackupPath);
            this.tpAutoBackup.Controls.Add(this.label2);
            this.tpAutoBackup.Controls.Add(this.label1);
            this.tpAutoBackup.Location = new System.Drawing.Point(4, 22);
            this.tpAutoBackup.Name = "tpAutoBackup";
            this.tpAutoBackup.Size = new System.Drawing.Size(601, 200);
            this.tpAutoBackup.TabIndex = 5;
            this.tpAutoBackup.Tag = "Auto_Backup_Config";
            this.tpAutoBackup.Text = "Cấu hình tự động backup dữ liệu";
            this.tpAutoBackup.UseVisualStyleBackColor = true;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(26, 38);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(80, 13);
            this.lblControl4.TabIndex = 65;
            this.lblControl4.Tag = "ON_SERVER";
            this.lblControl4.Text = "( trên máy chủ )";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(19, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(560, 2);
            this.label4.TabIndex = 64;
            this.label4.Text = "label3";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(20, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(560, 2);
            this.label3.TabIndex = 64;
            this.label3.Text = "label3";
            // 
            // chkCN
            // 
            this.chkCN.AutoSize = true;
            this.chkCN.Location = new System.Drawing.Point(447, 82);
            this.chkCN.Name = "chkCN";
            this.chkCN.Size = new System.Drawing.Size(69, 17);
            this.chkCN.TabIndex = 7;
            this.chkCN.Tag = "SunDay";
            this.chkCN.Text = "Chủ nhật";
            this.chkCN.UseVisualStyleBackColor = true;
            // 
            // chkThu7
            // 
            this.chkThu7.AutoSize = true;
            this.chkThu7.Location = new System.Drawing.Point(343, 109);
            this.chkThu7.Name = "chkThu7";
            this.chkThu7.Size = new System.Drawing.Size(54, 17);
            this.chkThu7.TabIndex = 6;
            this.chkThu7.Tag = "Saturday";
            this.chkThu7.Text = "Thứ 7";
            this.chkThu7.UseVisualStyleBackColor = true;
            // 
            // chkThu6
            // 
            this.chkThu6.AutoSize = true;
            this.chkThu6.Location = new System.Drawing.Point(343, 82);
            this.chkThu6.Name = "chkThu6";
            this.chkThu6.Size = new System.Drawing.Size(54, 17);
            this.chkThu6.TabIndex = 5;
            this.chkThu6.Tag = "FriDay";
            this.chkThu6.Text = "Thứ 6";
            this.chkThu6.UseVisualStyleBackColor = true;
            // 
            // chkThu5
            // 
            this.chkThu5.AutoSize = true;
            this.chkThu5.Location = new System.Drawing.Point(234, 109);
            this.chkThu5.Name = "chkThu5";
            this.chkThu5.Size = new System.Drawing.Size(54, 17);
            this.chkThu5.TabIndex = 4;
            this.chkThu5.Tag = "ThursDay";
            this.chkThu5.Text = "Thứ 5";
            this.chkThu5.UseVisualStyleBackColor = true;
            // 
            // chkThu4
            // 
            this.chkThu4.AutoSize = true;
            this.chkThu4.Location = new System.Drawing.Point(234, 82);
            this.chkThu4.Name = "chkThu4";
            this.chkThu4.Size = new System.Drawing.Size(54, 17);
            this.chkThu4.TabIndex = 3;
            this.chkThu4.Tag = "WednesDay";
            this.chkThu4.Text = "Thứ 4";
            this.chkThu4.UseVisualStyleBackColor = true;
            // 
            // chkThu3
            // 
            this.chkThu3.AutoSize = true;
            this.chkThu3.Location = new System.Drawing.Point(125, 109);
            this.chkThu3.Name = "chkThu3";
            this.chkThu3.Size = new System.Drawing.Size(54, 17);
            this.chkThu3.TabIndex = 2;
            this.chkThu3.Tag = "TuesDay";
            this.chkThu3.Text = "Thứ 3";
            this.chkThu3.UseVisualStyleBackColor = true;
            // 
            // chkThu2
            // 
            this.chkThu2.AutoSize = true;
            this.chkThu2.Location = new System.Drawing.Point(125, 82);
            this.chkThu2.Name = "chkThu2";
            this.chkThu2.Size = new System.Drawing.Size(54, 17);
            this.chkThu2.TabIndex = 1;
            this.chkThu2.Tag = "Monday";
            this.chkThu2.Text = "Thứ 2";
            this.chkThu2.UseVisualStyleBackColor = true;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(125, 142);
            this.txtTime.Mask = "00:00:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(56, 20);
            this.txtTime.TabIndex = 8;
            this.txtTime.ValidatingType = typeof(System.DateTime);
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(17, 18);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(99, 20);
            this.lblControl3.TabIndex = 61;
            this.lblControl3.Tag = "Backup_Path";
            this.lblControl3.Text = "Đường dẫn backup";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAutoBackupPath
            // 
            this.txtAutoBackupPath.bEnabled = true;
            this.txtAutoBackupPath.bIsLookup = false;
            this.txtAutoBackupPath.bReadOnly = false;
            this.txtAutoBackupPath.bRequire = false;
            this.txtAutoBackupPath.KeyFilter = "";
            this.txtAutoBackupPath.Location = new System.Drawing.Point(125, 25);
            this.txtAutoBackupPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtAutoBackupPath.Name = "txtAutoBackupPath";
            this.txtAutoBackupPath.Size = new System.Drawing.Size(456, 20);
            this.txtAutoBackupPath.TabIndex = 0;
            this.txtAutoBackupPath.UseAutoFilter = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "Backup_Time";
            this.label2.Text = "Giờ backup CSDL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Backup_Date";
            this.label1.Text = "Ngày backup CSDL";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.btContinue);
            this.tabPage7.Controls.Add(this.btPause);
            this.tabPage7.Controls.Add(this.btStop);
            this.tabPage7.Controls.Add(this.btStart);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(601, 200);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Tag = "Service_Control";
            this.tabPage7.Text = "Quản lý Service";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // btContinue
            // 
            this.btContinue.Image = ((System.Drawing.Image)(resources.GetObject("btContinue.Image")));
            this.btContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btContinue.Location = new System.Drawing.Point(327, 24);
            this.btContinue.Name = "btContinue";
            this.btContinue.Size = new System.Drawing.Size(82, 50);
            this.btContinue.TabIndex = 3;
            this.btContinue.Text = "&Continue";
            this.btContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btContinue.UseVisualStyleBackColor = true;
            // 
            // btPause
            // 
            this.btPause.Image = ((System.Drawing.Image)(resources.GetObject("btPause.Image")));
            this.btPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPause.Location = new System.Drawing.Point(232, 24);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(82, 50);
            this.btPause.TabIndex = 2;
            this.btPause.Text = "&Pause";
            this.btPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPause.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            this.btStop.Image = ((System.Drawing.Image)(resources.GetObject("btStop.Image")));
            this.btStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btStop.Location = new System.Drawing.Point(137, 24);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(82, 50);
            this.btStop.TabIndex = 1;
            this.btStop.Text = "S&top";
            this.btStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btStop.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            this.btStart.Image = ((System.Drawing.Image)(resources.GetObject("btStart.Image")));
            this.btStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btStart.Location = new System.Drawing.Point(42, 24);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(82, 50);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "&Start";
            this.btStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btStart.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(448, 249);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 8;
            // 
            // btShrinkDB
            // 
            this.btShrinkDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btShrinkDB.Image = ((System.Drawing.Image)(resources.GetObject("btShrinkDB.Image")));
            this.btShrinkDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btShrinkDB.Location = new System.Drawing.Point(11, 249);
            this.btShrinkDB.Name = "btShrinkDB";
            this.btShrinkDB.Size = new System.Drawing.Size(86, 34);
            this.btShrinkDB.TabIndex = 9;
            this.btShrinkDB.Tag = "ZIP_DATA";
            this.btShrinkDB.Text = "Nén dữ liệu";
            this.btShrinkDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btShrinkDB.UseVisualStyleBackColor = true;
            // 
            // frmMaintenanceDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 294);
            this.Controls.Add(this.btShrinkDB);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.tabCheckDB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaintenanceDB";
            this.Text = "frmMaintenance";
            this.tabCheckDB.ResumeLayout(false);
            this.tpBackup.ResumeLayout(false);
            this.tpBackup.PerformLayout();
            this.tpRestore.ResumeLayout(false);
            this.tpRestore.PerformLayout();
            this.tpCheckDB.ResumeLayout(false);
            this.grbCHECKDB.ResumeLayout(false);
            this.grbCHECKDB.PerformLayout();
            this.tpAutoBackup.ResumeLayout(false);
            this.tpAutoBackup.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.tabControl tabCheckDB;
		private System.Windows.Forms.TabPage tpBackup;
		private System.Windows.Forms.TabPage tpRestore;
        private System.Windows.Forms.TabPage tpCheckDB;
		private System.Windows.Forms.TabPage tpAutoBackup;
		private System.Windows.Forms.TabPage tabPage7;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.lblControl lblBackupPath;
		private Epoint.Systems.Controls.txtTextBox txtBackupPath;
		private System.Windows.Forms.Button btContinue;
		private System.Windows.Forms.Button btPause;
		private System.Windows.Forms.Button btStop;
		private System.Windows.Forms.Button btStart;
		private Epoint.Systems.Controls.grbControl grbCHECKDB;
		private Epoint.Systems.Controls.rdbControl rdbNomal;
		private Epoint.Systems.Controls.rdbControl rdbRepairAllowDataLost;
		private Epoint.Systems.Controls.rdbControl rdbRepairRebuild;
		private Epoint.Systems.Controls.rdbControl rdbRepairFast;
        private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.btControl btRestorePath;
		private Epoint.Systems.Controls.lblControl lblBackupFileList;
		private Epoint.Systems.Controls.lblControl lblRestorePath;
		private Epoint.Systems.Controls.txtTextBox txtRestorePath;
		private Epoint.Systems.Controls.cboMultiControl cboBackupFileList;
		private System.Windows.Forms.Label label1;
        private Epoint.Systems.Controls.lblControl lblControl3;
        private Epoint.Systems.Controls.txtTextBox txtAutoBackupPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkThu7;
        private System.Windows.Forms.CheckBox chkThu6;
        private System.Windows.Forms.CheckBox chkThu5;
        private System.Windows.Forms.CheckBox chkThu4;
        private System.Windows.Forms.CheckBox chkThu3;
        private System.Windows.Forms.CheckBox chkThu2;
        private System.Windows.Forms.MaskedTextBox txtTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkCN;
		private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.btControl btShrinkDB;
        private Systems.Controls.lblControl lblControl4;

	}
}