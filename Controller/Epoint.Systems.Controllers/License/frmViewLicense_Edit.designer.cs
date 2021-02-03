namespace Epoint.Controllers
{
    partial class frmViewLicense_Edit
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
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.txtTen_Dvcs = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.chkActive = new Epoint.Systems.Controls.chkControl();
            this.lblCusID = new Epoint.Systems.Controls.lblControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblSize = new Epoint.Systems.Controls.lbtControl();
            this.txtCustID = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Dvcs = new Epoint.Systems.Controls.txtTextBox();
            this.txtKey_log = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.txtKey_Module = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.txtPC_Name = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.txtMessage = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.txtServer_Name = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.txtDatabase_Name = new Epoint.Systems.Controls.txtTextBox();
            this.lblDatabase_Name = new Epoint.Systems.Controls.lblControl();
            this.chkIsUpdate = new Epoint.Systems.Controls.chkControl();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(28, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 16;
            this.label2.Tag = "Ma_Dvcs";
            this.label2.Text = "Mã Dvcs";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Dvcs
            // 
            this.txtTen_Dvcs.bEnabled = true;
            this.txtTen_Dvcs.bIsLookup = false;
            this.txtTen_Dvcs.bReadOnly = false;
            this.txtTen_Dvcs.bRequire = false;
            this.txtTen_Dvcs.KeyFilter = "";
            this.txtTen_Dvcs.Location = new System.Drawing.Point(129, 136);
            this.txtTen_Dvcs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Dvcs.Name = "txtTen_Dvcs";
            this.txtTen_Dvcs.Size = new System.Drawing.Size(349, 20);
            this.txtTen_Dvcs.TabIndex = 0;
            this.txtTen_Dvcs.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(470, 356);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 33);
            this.btgAccept.TabIndex = 7;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(129, 320);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(77, 17);
            this.chkActive.TabIndex = 6;
            this.chkActive.Tag = "Active";
            this.chkActive.Text = "Hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblCusID
            // 
            this.lblCusID.AutoEllipsis = true;
            this.lblCusID.AutoSize = true;
            this.lblCusID.BackColor = System.Drawing.Color.Transparent;
            this.lblCusID.Location = new System.Drawing.Point(28, 21);
            this.lblCusID.Name = "lblCusID";
            this.lblCusID.Size = new System.Drawing.Size(83, 13);
            this.lblCusID.TabIndex = 3;
            this.lblCusID.Tag = "Cust_ID";
            this.lblCusID.Text = "Mã Khách hàng";
            this.lblCusID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.ForeColor = System.Drawing.Color.Blue;
            this.lblSize.Location = new System.Drawing.Point(483, 62);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(0, 13);
            this.lblSize.TabIndex = 20;
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustID
            // 
            this.txtCustID.bEnabled = true;
            this.txtCustID.bIsLookup = false;
            this.txtCustID.bReadOnly = false;
            this.txtCustID.bRequire = false;
            this.txtCustID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustID.Enabled = false;
            this.txtCustID.KeyFilter = "";
            this.txtCustID.Location = new System.Drawing.Point(129, 14);
            this.txtCustID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.Size = new System.Drawing.Size(174, 20);
            this.txtCustID.TabIndex = 0;
            this.txtCustID.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(28, 145);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(54, 13);
            this.lblControl1.TabIndex = 16;
            this.lblControl1.Tag = "Ten_Dvcs";
            this.lblControl1.Text = "Tên Dvcs";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Dvcs
            // 
            this.txtMa_Dvcs.bEnabled = true;
            this.txtMa_Dvcs.bIsLookup = false;
            this.txtMa_Dvcs.bReadOnly = false;
            this.txtMa_Dvcs.bRequire = false;
            this.txtMa_Dvcs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Dvcs.Enabled = false;
            this.txtMa_Dvcs.KeyFilter = "";
            this.txtMa_Dvcs.Location = new System.Drawing.Point(129, 112);
            this.txtMa_Dvcs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Dvcs.Name = "txtMa_Dvcs";
            this.txtMa_Dvcs.Size = new System.Drawing.Size(174, 20);
            this.txtMa_Dvcs.TabIndex = 2;
            this.txtMa_Dvcs.UseAutoFilter = false;
            // 
            // txtKey_log
            // 
            this.txtKey_log.bEnabled = true;
            this.txtKey_log.bIsLookup = false;
            this.txtKey_log.bReadOnly = false;
            this.txtKey_log.bRequire = false;
            this.txtKey_log.KeyFilter = "";
            this.txtKey_log.Location = new System.Drawing.Point(129, 161);
            this.txtKey_log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtKey_log.Name = "txtKey_log";
            this.txtKey_log.Size = new System.Drawing.Size(349, 20);
            this.txtKey_log.TabIndex = 3;
            this.txtKey_log.UseAutoFilter = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(28, 167);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(46, 13);
            this.lblControl2.TabIndex = 16;
            this.lblControl2.Tag = "Key_Log";
            this.lblControl2.Text = "Key Log";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKey_Module
            // 
            this.txtKey_Module.bEnabled = true;
            this.txtKey_Module.bIsLookup = false;
            this.txtKey_Module.bReadOnly = false;
            this.txtKey_Module.bRequire = false;
            this.txtKey_Module.KeyFilter = "";
            this.txtKey_Module.Location = new System.Drawing.Point(129, 186);
            this.txtKey_Module.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtKey_Module.Name = "txtKey_Module";
            this.txtKey_Module.Size = new System.Drawing.Size(349, 20);
            this.txtKey_Module.TabIndex = 4;
            this.txtKey_Module.UseAutoFilter = false;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(28, 192);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(63, 13);
            this.lblControl3.TabIndex = 16;
            this.lblControl3.Tag = "Key_Module";
            this.lblControl3.Text = "Key Module";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPC_Name
            // 
            this.txtPC_Name.bEnabled = true;
            this.txtPC_Name.bIsLookup = false;
            this.txtPC_Name.bReadOnly = false;
            this.txtPC_Name.bRequire = false;
            this.txtPC_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPC_Name.Enabled = false;
            this.txtPC_Name.KeyFilter = "";
            this.txtPC_Name.Location = new System.Drawing.Point(129, 37);
            this.txtPC_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPC_Name.Name = "txtPC_Name";
            this.txtPC_Name.Size = new System.Drawing.Size(349, 20);
            this.txtPC_Name.TabIndex = 1;
            this.txtPC_Name.UseAutoFilter = false;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(26, 43);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(89, 13);
            this.lblControl4.TabIndex = 16;
            this.lblControl4.Tag = "PC_Name";
            this.lblControl4.Text = "Tên máy sử dụng";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMessage
            // 
            this.txtMessage.bEnabled = true;
            this.txtMessage.bIsLookup = false;
            this.txtMessage.bReadOnly = false;
            this.txtMessage.bRequire = false;
            this.txtMessage.KeyFilter = "";
            this.txtMessage.Location = new System.Drawing.Point(129, 211);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(349, 104);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.UseAutoFilter = false;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Location = new System.Drawing.Point(28, 217);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(49, 13);
            this.lblControl5.TabIndex = 16;
            this.lblControl5.Tag = "Message";
            this.lblControl5.Text = "Tin nhắn";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtServer_Name
            // 
            this.txtServer_Name.bEnabled = true;
            this.txtServer_Name.bIsLookup = false;
            this.txtServer_Name.bReadOnly = false;
            this.txtServer_Name.bRequire = false;
            this.txtServer_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServer_Name.Enabled = false;
            this.txtServer_Name.KeyFilter = "";
            this.txtServer_Name.Location = new System.Drawing.Point(129, 62);
            this.txtServer_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtServer_Name.Name = "txtServer_Name";
            this.txtServer_Name.Size = new System.Drawing.Size(174, 20);
            this.txtServer_Name.TabIndex = 1;
            this.txtServer_Name.UseAutoFilter = false;
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.Location = new System.Drawing.Point(26, 68);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(69, 13);
            this.lblControl6.TabIndex = 16;
            this.lblControl6.Tag = "Server_Name";
            this.lblControl6.Text = "Tên máy chủ";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDatabase_Name
            // 
            this.txtDatabase_Name.bEnabled = true;
            this.txtDatabase_Name.bIsLookup = false;
            this.txtDatabase_Name.bReadOnly = false;
            this.txtDatabase_Name.bRequire = false;
            this.txtDatabase_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDatabase_Name.Enabled = false;
            this.txtDatabase_Name.KeyFilter = "";
            this.txtDatabase_Name.Location = new System.Drawing.Point(129, 87);
            this.txtDatabase_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDatabase_Name.Name = "txtDatabase_Name";
            this.txtDatabase_Name.Size = new System.Drawing.Size(174, 20);
            this.txtDatabase_Name.TabIndex = 1;
            this.txtDatabase_Name.UseAutoFilter = false;
            // 
            // lblDatabase_Name
            // 
            this.lblDatabase_Name.AutoEllipsis = true;
            this.lblDatabase_Name.AutoSize = true;
            this.lblDatabase_Name.BackColor = System.Drawing.Color.Transparent;
            this.lblDatabase_Name.Location = new System.Drawing.Point(26, 93);
            this.lblDatabase_Name.Name = "lblDatabase_Name";
            this.lblDatabase_Name.Size = new System.Drawing.Size(89, 13);
            this.lblDatabase_Name.TabIndex = 16;
            this.lblDatabase_Name.Tag = "Database_Name";
            this.lblDatabase_Name.Text = "Tên cơ sở dữ liệu";
            this.lblDatabase_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIsUpdate
            // 
            this.chkIsUpdate.AutoSize = true;
            this.chkIsUpdate.Location = new System.Drawing.Point(129, 343);
            this.chkIsUpdate.Name = "chkIsUpdate";
            this.chkIsUpdate.Size = new System.Drawing.Size(69, 17);
            this.chkIsUpdate.TabIndex = 6;
            this.chkIsUpdate.Tag = "Update";
            this.chkIsUpdate.Text = "Cập nhật";
            this.chkIsUpdate.UseVisualStyleBackColor = true;
            // 
            // frmViewLicense_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 407);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.chkIsUpdate);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblControl5);
            this.Controls.Add(this.lblDatabase_Name);
            this.Controls.Add(this.lblControl6);
            this.Controls.Add(this.lblControl4);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustID);
            this.Controls.Add(this.txtMa_Dvcs);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtDatabase_Name);
            this.Controls.Add(this.txtServer_Name);
            this.Controls.Add(this.txtPC_Name);
            this.Controls.Add(this.txtKey_Module);
            this.Controls.Add(this.txtKey_log);
            this.Controls.Add(this.txtTen_Dvcs);
            this.Controls.Add(this.lblCusID);
            this.Name = "frmViewLicense_Edit";
            this.Tag = "frmViewLicense, ESC";
            this.Text = "frmViewLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.lblControl label2;
		private Epoint.Systems.Controls.txtTextBox txtTen_Dvcs;
        private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Epoint.Systems.Controls.chkControl chkActive;
        private Systems.Controls.lblControl lblCusID;
        private System.Windows.Forms.ImageList imageList1;
        private Systems.Controls.lbtControl lblSize;
        private Systems.Controls.txtTextBox txtCustID;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.txtTextBox txtMa_Dvcs;
        private Systems.Controls.txtTextBox txtKey_log;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.txtTextBox txtKey_Module;
        private Systems.Controls.lblControl lblControl3;
        private Systems.Controls.txtTextBox txtPC_Name;
        private Systems.Controls.lblControl lblControl4;
        private Systems.Controls.txtTextBox txtMessage;
        private Systems.Controls.lblControl lblControl5;
        private Systems.Controls.txtTextBox txtServer_Name;
        private Systems.Controls.lblControl lblControl6;
        private Systems.Controls.txtTextBox txtDatabase_Name;
        private Systems.Controls.lblControl lblDatabase_Name;
        private Systems.Controls.chkControl chkIsUpdate;
	}
}