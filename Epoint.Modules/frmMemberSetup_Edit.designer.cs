namespace Epoint.Modules
{
	partial class frmMemberSetup_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMemberSetup_Edit));
            this.txtMember_Name = new Epoint.Systems.Controls.txtTextBox();
            this.txtMember_Id = new Epoint.Systems.Controls.txtTextBox();
            this.lbTen_DvCs = new Epoint.Systems.Controls.lblControl();
            this.lbMa_DvCs = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Ct_Access = new Epoint.Systems.Controls.txtTextBox();
            this.txtMa_Kho_Access = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // txtMember_Name
            // 
            this.txtMember_Name.bEnabled = true;
            this.txtMember_Name.bIsLookup = false;
            this.txtMember_Name.bReadOnly = false;
            this.txtMember_Name.bRequire = false;
            this.txtMember_Name.KeyFilter = "";
            this.txtMember_Name.Location = new System.Drawing.Point(171, 46);
            this.txtMember_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMember_Name.MaxLength = 100;
            this.txtMember_Name.Name = "txtMember_Name";
            this.txtMember_Name.Size = new System.Drawing.Size(342, 20);
            this.txtMember_Name.TabIndex = 1;
            this.txtMember_Name.UseAutoFilter = false;
            // 
            // txtMember_Id
            // 
            this.txtMember_Id.bEnabled = true;
            this.txtMember_Id.bIsLookup = false;
            this.txtMember_Id.bReadOnly = false;
            this.txtMember_Id.bRequire = false;
            this.txtMember_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMember_Id.KeyFilter = "";
            this.txtMember_Id.Location = new System.Drawing.Point(171, 23);
            this.txtMember_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMember_Id.MaxLength = 20;
            this.txtMember_Id.Name = "txtMember_Id";
            this.txtMember_Id.Size = new System.Drawing.Size(174, 20);
            this.txtMember_Id.TabIndex = 0;
            this.txtMember_Id.UseAutoFilter = false;
            // 
            // lbTen_DvCs
            // 
            this.lbTen_DvCs.AutoEllipsis = true;
            this.lbTen_DvCs.AutoSize = true;
            this.lbTen_DvCs.BackColor = System.Drawing.Color.Transparent;
            this.lbTen_DvCs.Location = new System.Drawing.Point(23, 47);
            this.lbTen_DvCs.Name = "lbTen_DvCs";
            this.lbTen_DvCs.Size = new System.Drawing.Size(82, 13);
            this.lbTen_DvCs.TabIndex = 15;
            this.lbTen_DvCs.Tag = "User_Name";
            this.lbTen_DvCs.Text = "Tên người dùng";
            this.lbTen_DvCs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_DvCs
            // 
            this.lbMa_DvCs.AutoEllipsis = true;
            this.lbMa_DvCs.AutoSize = true;
            this.lbMa_DvCs.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_DvCs.Location = new System.Drawing.Point(23, 23);
            this.lbMa_DvCs.Name = "lbMa_DvCs";
            this.lbMa_DvCs.Size = new System.Drawing.Size(78, 13);
            this.lbMa_DvCs.TabIndex = 16;
            this.lbMa_DvCs.Tag = "User_ID";
            this.lbMa_DvCs.Text = "Mã người dùng";
            this.lbMa_DvCs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(353, 131);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 8;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(23, 95);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(114, 13);
            this.lblControl1.TabIndex = 18;
            this.lblControl1.Tag = "Ma_Ct_Not_Allow";
            this.lblControl1.Text = "Cấm truy cập chứng từ";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Ct_Access
            // 
            this.txtMa_Ct_Access.bEnabled = true;
            this.txtMa_Ct_Access.bIsLookup = false;
            this.txtMa_Ct_Access.bReadOnly = false;
            this.txtMa_Ct_Access.bRequire = false;
            this.txtMa_Ct_Access.KeyFilter = "";
            this.txtMa_Ct_Access.Location = new System.Drawing.Point(171, 92);
            this.txtMa_Ct_Access.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Ct_Access.MaxLength = 20;
            this.txtMa_Ct_Access.Name = "txtMa_Ct_Access";
            this.txtMa_Ct_Access.Size = new System.Drawing.Size(174, 20);
            this.txtMa_Ct_Access.TabIndex = 3;
            this.txtMa_Ct_Access.UseAutoFilter = false;
            // 
            // txtMa_Kho_Access
            // 
            this.txtMa_Kho_Access.bEnabled = true;
            this.txtMa_Kho_Access.bIsLookup = false;
            this.txtMa_Kho_Access.bReadOnly = false;
            this.txtMa_Kho_Access.bRequire = false;
            this.txtMa_Kho_Access.KeyFilter = "";
            this.txtMa_Kho_Access.Location = new System.Drawing.Point(171, 69);
            this.txtMa_Kho_Access.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Kho_Access.MaxLength = 100;
            this.txtMa_Kho_Access.Name = "txtMa_Kho_Access";
            this.txtMa_Kho_Access.Size = new System.Drawing.Size(174, 20);
            this.txtMa_Kho_Access.TabIndex = 2;
            this.txtMa_Kho_Access.UseAutoFilter = false;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(24, 71);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(99, 13);
            this.lblControl3.TabIndex = 22;
            this.lblControl3.Tag = "";
            this.lblControl3.Text = "Truy cập chi nhánh";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMemberSetup_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 180);
            this.Controls.Add(this.txtMa_Kho_Access);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.txtMa_Ct_Access);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtMember_Name);
            this.Controls.Add(this.txtMember_Id);
            this.Controls.Add(this.lbTen_DvCs);
            this.Controls.Add(this.lbMa_DvCs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMemberSetup_Edit";
            this.Tag = "frmSetupmember";
            this.Text = "frmSetupmember";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtMember_Name;
		private Epoint.Systems.Controls.txtTextBox txtMember_Id;
		private Epoint.Systems.Controls.lblControl lbTen_DvCs;
        private Epoint.Systems.Controls.lblControl lbMa_DvCs;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.lblControl lblControl1;
        private Epoint.Systems.Controls.txtTextBox txtMa_Ct_Access;
		private Epoint.Systems.Controls.txtTextBox txtMa_Kho_Access;
        private Epoint.Systems.Controls.lblControl lblControl3;
	}
}