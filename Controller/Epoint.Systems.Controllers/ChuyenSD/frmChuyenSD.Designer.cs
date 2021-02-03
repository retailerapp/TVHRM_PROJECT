namespace Epoint.Controllers
{
	partial class frmChuyenSD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenSD));
            this.chkChuyen_Cdk = new Epoint.Systems.Controls.chkControl();
            this.chkChuyen_Cdv = new Epoint.Systems.Controls.chkControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.grbControl1 = new Epoint.Systems.Controls.grbControl();
            this.chkChuyen_SDHanTt = new Epoint.Systems.Controls.chkControl();
            this.chkChuyen_SDZ = new Epoint.Systems.Controls.chkControl();
            this.btYear = new Epoint.Systems.Controls.btControl();
            this.chkChuyen_Cdv_NTXT = new Epoint.Systems.Controls.chkControl();
            this.grbControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkChuyen_Cdk
            // 
            this.chkChuyen_Cdk.AutoSize = true;
            this.chkChuyen_Cdk.Location = new System.Drawing.Point(30, 25);
            this.chkChuyen_Cdk.Name = "chkChuyen_Cdk";
            this.chkChuyen_Cdk.Size = new System.Drawing.Size(138, 17);
            this.chkChuyen_Cdk.TabIndex = 0;
            this.chkChuyen_Cdk.Tag = "Chuyen_Cdk";
            this.chkChuyen_Cdk.Text = "&Chuyển số dư tài khoản";
            this.chkChuyen_Cdk.UseVisualStyleBackColor = true;
            // 
            // chkChuyen_Cdv
            // 
            this.chkChuyen_Cdv.AutoSize = true;
            this.chkChuyen_Cdv.Location = new System.Drawing.Point(30, 71);
            this.chkChuyen_Cdv.Name = "chkChuyen_Cdv";
            this.chkChuyen_Cdv.Size = new System.Drawing.Size(157, 17);
            this.chkChuyen_Cdv.TabIndex = 2;
            this.chkChuyen_Cdv.Tag = "Chuyen_Cdv";
            this.chkChuyen_Cdv.Text = "Ch&uyển số dư hàng tồn kho";
            this.chkChuyen_Cdv.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(336, 185);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 2;
            // 
            // grbControl1
            // 
            this.grbControl1.Controls.Add(this.chkChuyen_Cdv_NTXT);
            this.grbControl1.Controls.Add(this.chkChuyen_SDHanTt);
            this.grbControl1.Controls.Add(this.chkChuyen_Cdk);
            this.grbControl1.Controls.Add(this.chkChuyen_SDZ);
            this.grbControl1.Controls.Add(this.chkChuyen_Cdv);
            this.grbControl1.Location = new System.Drawing.Point(31, 25);
            this.grbControl1.Name = "grbControl1";
            this.grbControl1.Size = new System.Drawing.Size(319, 149);
            this.grbControl1.TabIndex = 1;
            this.grbControl1.TabStop = false;
            this.grbControl1.Tag = "Chuyen_SD";
            this.grbControl1.Text = "Chuyển số dư sang năm sau";
            // 
            // chkChuyen_SDHanTt
            // 
            this.chkChuyen_SDHanTt.AutoSize = true;
            this.chkChuyen_SDHanTt.Location = new System.Drawing.Point(30, 48);
            this.chkChuyen_SDHanTt.Name = "chkChuyen_SDHanTt";
            this.chkChuyen_SDHanTt.Size = new System.Drawing.Size(166, 17);
            this.chkChuyen_SDHanTt.TabIndex = 1;
            this.chkChuyen_SDHanTt.Tag = "Chuyen_SDHanTt";
            this.chkChuyen_SDHanTt.Text = "&Chuyển số dư hạn thanh toán";
            this.chkChuyen_SDHanTt.UseVisualStyleBackColor = true;
            // 
            // chkChuyen_SDZ
            // 
            this.chkChuyen_SDZ.AutoSize = true;
            this.chkChuyen_SDZ.Location = new System.Drawing.Point(30, 118);
            this.chkChuyen_SDZ.Name = "chkChuyen_SDZ";
            this.chkChuyen_SDZ.Size = new System.Drawing.Size(165, 17);
            this.chkChuyen_SDZ.TabIndex = 3;
            this.chkChuyen_SDZ.Tag = "Chuyen_SdZ";
            this.chkChuyen_SDZ.Text = "Chuyển số dở dang giá thành";
            this.chkChuyen_SDZ.UseVisualStyleBackColor = true;
            // 
            // btYear
            // 
            this.btYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btYear.ForeColor = System.Drawing.Color.Blue;
            this.btYear.Image = ((System.Drawing.Image)(resources.GetObject("btYear.Image")));
            this.btYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btYear.Location = new System.Drawing.Point(31, 185);
            this.btYear.Name = "btYear";
            this.btYear.Size = new System.Drawing.Size(168, 35);
            this.btYear.TabIndex = 6;
            this.btYear.Tag = "CREATE_NEW_WORKINGYEAR";
            this.btYear.Text = "Tạo năm làm việc tiếp theo";
            this.btYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btYear.UseVisualStyleBackColor = true;
            this.btYear.Visible = false;
            // 
            // chkChuyen_Cdv_NTXT
            // 
            this.chkChuyen_Cdv_NTXT.AutoSize = true;
            this.chkChuyen_Cdv_NTXT.Location = new System.Drawing.Point(30, 94);
            this.chkChuyen_Cdv_NTXT.Name = "chkChuyen_Cdv_NTXT";
            this.chkChuyen_Cdv_NTXT.Size = new System.Drawing.Size(267, 17);
            this.chkChuyen_Cdv_NTXT.TabIndex = 4;
            this.chkChuyen_Cdv_NTXT.Tag = "Chuyen_Cdv_NtXt";
            this.chkChuyen_Cdv_NTXT.Text = "Ch&uyển số dư hàng tồn kho - nhập trước xuất trước";
            this.chkChuyen_Cdv_NTXT.UseVisualStyleBackColor = true;
            // 
            // frmChuyenSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 232);
            this.Controls.Add(this.btYear);
            this.Controls.Add(this.grbControl1);
            this.Controls.Add(this.btgAccept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChuyenSD";
            this.Text = "frmChuyenSD";
            this.grbControl1.ResumeLayout(false);
            this.grbControl1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.chkControl chkChuyen_Cdk;
        private Epoint.Systems.Controls.chkControl chkChuyen_Cdv;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.grbControl grbControl1;
		private Epoint.Systems.Controls.chkControl chkChuyen_SDZ;
        private Epoint.Systems.Controls.chkControl chkChuyen_SDHanTt;
        private Systems.Controls.btControl btYear;
        private Systems.Controls.chkControl chkChuyen_Cdv_NTXT;
	}
}