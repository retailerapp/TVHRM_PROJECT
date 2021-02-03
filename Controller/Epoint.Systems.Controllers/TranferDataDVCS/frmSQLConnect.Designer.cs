namespace Epoint.Controllers
{
	partial class frmSQLConnect
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
            this.chkAuthentication = new Epoint.Systems.Controls.chkControl();
            this.label1 = new Epoint.Systems.Controls.lblControl();
            this.txtServerName = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtUser = new Epoint.Systems.Controls.txtTextBox();
            this.txtPassword = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAuthentication
            // 
            this.chkAuthentication.AutoSize = true;
            this.chkAuthentication.Location = new System.Drawing.Point(113, 55);
            this.chkAuthentication.Name = "chkAuthentication";
            this.chkAuthentication.Size = new System.Drawing.Size(187, 17);
            this.chkAuthentication.TabIndex = 0;
            this.chkAuthentication.Text = "Windows xác thực/ SQL xác thực";
            this.chkAuthentication.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Máy chủ kết nối";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtServerName
            // 
            this.txtServerName.bEnabled = true;
            this.txtServerName.bIsLookup = false;
            this.txtServerName.bReadOnly = false;
            this.txtServerName.bRequire = false;
            this.txtServerName.KeyFilter = "";
            this.txtServerName.Location = new System.Drawing.Point(113, 25);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.ReadOnly = true;
            this.txtServerName.Size = new System.Drawing.Size(420, 20);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.TabStop = false;
            this.txtServerName.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(363, 161);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(168, 33);
            this.btgAccept.TabIndex = 3;
            // 
            // txtUser
            // 
            this.txtUser.bEnabled = true;
            this.txtUser.bIsLookup = false;
            this.txtUser.bReadOnly = false;
            this.txtUser.bRequire = false;
            this.txtUser.KeyFilter = "";
            this.txtUser.Location = new System.Drawing.Point(145, 25);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(213, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.UseAutoFilter = false;
            // 
            // txtPassword
            // 
            this.txtPassword.bEnabled = true;
            this.txtPassword.bIsLookup = false;
            this.txtPassword.bReadOnly = false;
            this.txtPassword.bRequire = false;
            this.txtPassword.KeyFilter = "";
            this.txtPassword.Location = new System.Drawing.Point(145, 51);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '|';
            this.txtPassword.Size = new System.Drawing.Size(213, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseAutoFilter = false;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tài khoản SQL xác thực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mật khẩu SQL xác thực";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Location = new System.Drawing.Point(94, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // frmSQLConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 206);
            this.Controls.Add(this.chkAuthentication);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerName);
            this.Name = "frmSQLConnect";
            this.Text = "frmSQLConnect";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.lblControl label1;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		public Epoint.Systems.Controls.txtTextBox txtServerName;
		public Epoint.Systems.Controls.chkControl chkAuthentication;
		public Epoint.Systems.Controls.txtTextBox txtUser;
		public Epoint.Systems.Controls.txtTextBox txtPassword;
	}
}