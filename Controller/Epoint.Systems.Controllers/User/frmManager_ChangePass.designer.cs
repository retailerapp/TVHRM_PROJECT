namespace Epoint.Controllers
{
	partial class frmManager_ChangePass
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
            this.lbTen_Nh_Dt = new Epoint.Systems.Controls.lblControl();
            this.lbDm_Nh_Dt = new Epoint.Systems.Controls.lblControl();
            this.txtPassword = new Epoint.Systems.Controls.txtTextBox();
            this.label3 = new Epoint.Systems.Controls.lblControl();
            this.label4 = new Epoint.Systems.Controls.lblControl();
            this.txtPassword_Re = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.SuspendLayout();
            // 
            // lbTen_Nh_Dt
            // 
            this.lbTen_Nh_Dt.AutoEllipsis = true;
            this.lbTen_Nh_Dt.AutoSize = true;
            this.lbTen_Nh_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lbTen_Nh_Dt.Location = new System.Drawing.Point(-97, 135);
            this.lbTen_Nh_Dt.Name = "lbTen_Nh_Dt";
            this.lbTen_Nh_Dt.Size = new System.Drawing.Size(55, 13);
            this.lbTen_Nh_Dt.TabIndex = 3;
            this.lbTen_Nh_Dt.Text = "Tên nhóm";
            this.lbTen_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDm_Nh_Dt
            // 
            this.lbDm_Nh_Dt.AutoEllipsis = true;
            this.lbDm_Nh_Dt.AutoSize = true;
            this.lbDm_Nh_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lbDm_Nh_Dt.Location = new System.Drawing.Point(-97, 113);
            this.lbDm_Nh_Dt.Name = "lbDm_Nh_Dt";
            this.lbDm_Nh_Dt.Size = new System.Drawing.Size(51, 13);
            this.lbDm_Nh_Dt.TabIndex = 4;
            this.lbDm_Nh_Dt.Text = "Mã nhóm";
            this.lbDm_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.bEnabled = true;
            this.txtPassword.bIsLookup = false;
            this.txtPassword.bReadOnly = false;
            this.txtPassword.bRequire = false;
            this.txtPassword.KeyFilter = "";
            this.txtPassword.Location = new System.Drawing.Point(149, 33);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(138, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseAutoFilter = false;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(33, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 13;
            this.label3.Tag = "Password";
            this.label3.Text = "Mật khẩu mới";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(33, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 13;
            this.label4.Tag = "Confirm_Password";
            this.label4.Text = "Nhập lại mật khẩu mới";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword_Re
            // 
            this.txtPassword_Re.bEnabled = true;
            this.txtPassword_Re.bIsLookup = false;
            this.txtPassword_Re.bReadOnly = false;
            this.txtPassword_Re.bRequire = false;
            this.txtPassword_Re.KeyFilter = "";
            this.txtPassword_Re.Location = new System.Drawing.Point(149, 57);
            this.txtPassword_Re.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPassword_Re.MaxLength = 20;
            this.txtPassword_Re.Name = "txtPassword_Re";
            this.txtPassword_Re.PasswordChar = '*';
            this.txtPassword_Re.Size = new System.Drawing.Size(138, 20);
            this.txtPassword_Re.TabIndex = 3;
            this.txtPassword_Re.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(183, 113);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 7;
            // 
            // frmManager_ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 167);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword_Re);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTen_Nh_Dt);
            this.Controls.Add(this.lbDm_Nh_Dt);
            this.Name = "frmManager_ChangePass";
            this.Tag = "frmManager_ChangePass";
            this.Text = "frmManager_ChangePass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Epoint.Systems.Controls.lblControl lbTen_Nh_Dt;
		private Epoint.Systems.Controls.lblControl lbDm_Nh_Dt;
        private Epoint.Systems.Controls.txtTextBox txtPassword;
        private Epoint.Systems.Controls.lblControl label3;
        private Epoint.Systems.Controls.lblControl label4;
        private Epoint.Systems.Controls.txtTextBox txtPassword_Re;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
    }
}