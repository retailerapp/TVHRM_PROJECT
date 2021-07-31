namespace Epoint
{
	partial class frmLogin_New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin_New));
            this.txtMember_ID = new Epoint.Systems.Controls.txtTextBox();
            this.txtPassword = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblInfo = new Epoint.Systems.Controls.lblControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lineControl1 = new Epoint.Systems.Controls.lineControl();
            this.lineControl2 = new Epoint.Systems.Controls.lineControl();
            this.pictureepoint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureepoint)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMember_ID
            // 
            this.txtMember_ID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtMember_ID.bEnabled = true;
            this.txtMember_ID.bIsLookup = false;
            this.txtMember_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMember_ID.bReadOnly = false;
            this.txtMember_ID.bRequire = false;
            this.txtMember_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMember_ID.KeyFilter = "";
            this.txtMember_ID.Location = new System.Drawing.Point(444, 153);
            this.txtMember_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMember_ID.Name = "txtMember_ID";
            this.txtMember_ID.Size = new System.Drawing.Size(225, 13);
            this.txtMember_ID.TabIndex = 0;
            this.txtMember_ID.UseAutoFilter = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPassword.bEnabled = true;
            this.txtPassword.bIsLookup = false;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.bReadOnly = false;
            this.txtPassword.bRequire = false;
            this.txtPassword.KeyFilter = "";
            this.txtPassword.Location = new System.Drawing.Point(444, 182);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(225, 13);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(434, 355);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(179, 29);
            this.btgAccept.TabIndex = 3;
            this.btgAccept.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point(339, 379);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Tag = "";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(402, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(402, 179);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // btOk
            // 
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.White;
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(440, 208);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(109, 41);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "OK";
            this.btOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.White;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(555, 208);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(110, 41);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "CANCEL";
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // lineControl1
            // 
            this.lineControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineControl1.AutoEllipsis = true;
            this.lineControl1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lineControl1.Location = new System.Drawing.Point(440, 173);
            this.lineControl1.Name = "lineControl1";
            this.lineControl1.Size = new System.Drawing.Size(226, 1);
            this.lineControl1.TabIndex = 110;
            this.lineControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineControl2
            // 
            this.lineControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineControl2.AutoEllipsis = true;
            this.lineControl2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lineControl2.Location = new System.Drawing.Point(440, 201);
            this.lineControl2.Name = "lineControl2";
            this.lineControl2.Size = new System.Drawing.Size(226, 1);
            this.lineControl2.TabIndex = 110;
            this.lineControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureepoint
            // 
            this.pictureepoint.BackColor = System.Drawing.Color.White;
            this.pictureepoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureepoint.Image = ((System.Drawing.Image)(resources.GetObject("pictureepoint.Image")));
            this.pictureepoint.Location = new System.Drawing.Point(0, -2);
            this.pictureepoint.Name = "pictureepoint";
            this.pictureepoint.Size = new System.Drawing.Size(396, 399);
            this.pictureepoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureepoint.TabIndex = 7;
            this.pictureepoint.TabStop = false;
            // 
            // frmLogin_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(711, 396);
            this.Controls.Add(this.lineControl2);
            this.Controls.Add(this.lineControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pictureepoint);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.txtMember_ID);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin_New";
            this.ShowInTaskbar = true;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureepoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        private Epoint.Systems.Controls.txtTextBox txtMember_ID;
        private Epoint.Systems.Controls.txtTextBox txtPassword;
        private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Systems.Controls.lblControl lblInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        public Systems.Controls.lineControl lineControl1;
        public Systems.Controls.lineControl lineControl2;
        private System.Windows.Forms.PictureBox pictureepoint;
    }
}