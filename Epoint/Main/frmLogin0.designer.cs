namespace Epoint
{
	partial class frmLogin0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin0));
            this.lblLogin_Name = new Epoint.Systems.Controls.lblControl();
            this.txtMember_ID = new Epoint.Systems.Controls.txtTextBox();
            this.lblPassword = new Epoint.Systems.Controls.lblControl();
            this.txtPassword = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.pnlControl2 = new System.Windows.Forms.Panel();
            this.pnlControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogin_Name
            // 
            this.lblLogin_Name.AutoEllipsis = true;
            this.lblLogin_Name.AutoSize = true;
            this.lblLogin_Name.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin_Name.ForeColor = System.Drawing.Color.Red;
            this.lblLogin_Name.Location = new System.Drawing.Point(38, 110);
            this.lblLogin_Name.Name = "lblLogin_Name";
            this.lblLogin_Name.Size = new System.Drawing.Size(81, 13);
            this.lblLogin_Name.TabIndex = 3;
            this.lblLogin_Name.Tag = "Login_Name";
            this.lblLogin_Name.Text = "&Tên đăng nhập";
            this.lblLogin_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMember_ID
            // 
            this.txtMember_ID.bEnabled = true;
            this.txtMember_ID.bIsLookup = false;
            this.txtMember_ID.bReadOnly = false;
            this.txtMember_ID.bRequire = false;
            this.txtMember_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMember_ID.KeyFilter = "";
            this.txtMember_ID.Location = new System.Drawing.Point(125, 107);
            this.txtMember_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMember_ID.Name = "txtMember_ID";
            this.txtMember_ID.Size = new System.Drawing.Size(223, 20);
            this.txtMember_ID.TabIndex = 1;
            this.txtMember_ID.UseAutoFilter = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoEllipsis = true;
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Red;
            this.lblPassword.Location = new System.Drawing.Point(38, 136);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(52, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Tag = "Password";
            this.lblPassword.Text = "&Mật khẩu";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.bEnabled = true;
            this.txtPassword.bIsLookup = false;
            this.txtPassword.bReadOnly = false;
            this.txtPassword.bRequire = false;
            this.txtPassword.KeyFilter = "";
            this.txtPassword.Location = new System.Drawing.Point(125, 136);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(223, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(225, 250);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(171, 29);
            this.btgAccept.TabIndex = 3;
            // 
            // pnlControl2
            // 
            this.pnlControl2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlControl2.BackgroundImage")));
            this.pnlControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl2.Controls.Add(this.btgAccept);
            this.pnlControl2.Controls.Add(this.lblLogin_Name);
            this.pnlControl2.Controls.Add(this.txtMember_ID);
            this.pnlControl2.Controls.Add(this.txtPassword);
            this.pnlControl2.Controls.Add(this.lblPassword);
            this.pnlControl2.Location = new System.Drawing.Point(-1, 0);
            this.pnlControl2.Name = "pnlControl2";
            this.pnlControl2.Size = new System.Drawing.Size(443, 294);
            this.pnlControl2.TabIndex = 8;
            // 
            // frmLogin0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(441, 282);
            this.Controls.Add(this.pnlControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 321);
            this.MinimizeBox = false;
            this.Name = "frmLogin0";
            this.ShowInTaskbar = true;
            this.Text = "Login";
            this.pnlControl2.ResumeLayout(false);
            this.pnlControl2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private Epoint.Systems.Controls.lblControl lblLogin_Name;
        private Epoint.Systems.Controls.txtTextBox txtMember_ID;
        private Epoint.Systems.Controls.lblControl lblPassword;
        private Epoint.Systems.Controls.txtTextBox txtPassword;
        private Epoint.Systems.Customizes.btgAccept btgAccept;
        private System.Windows.Forms.Panel pnlControl2;
	}
}