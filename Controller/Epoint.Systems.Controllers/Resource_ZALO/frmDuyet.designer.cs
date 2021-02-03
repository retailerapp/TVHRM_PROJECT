namespace Epoint.Controllers
{
	partial class frmDuyet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuyet));
            this.btSave = new Epoint.Systems.Controls.btControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.txtDuyet_Log = new Epoint.Systems.Controls.txtTextBox();
            this.chkDuyet = new Epoint.Systems.Controls.chkControl();
            this.dteNgay_Ky = new Epoint.Systems.Controls.txtDateTime();
            this.lblNgay_Ct1 = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(310, 157);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(65, 31);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(42, 78);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(73, 13);
            this.lblControl2.TabIndex = 100;
            this.lblControl2.Tag = "";
            this.lblControl2.Text = "Nhật ký duyệt";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDuyet_Log
            // 
            this.txtDuyet_Log.bEnabled = true;
            this.txtDuyet_Log.bIsLookup = false;
            this.txtDuyet_Log.bReadOnly = false;
            this.txtDuyet_Log.bRequire = false;
            this.txtDuyet_Log.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDuyet_Log.KeyFilter = "";
            this.txtDuyet_Log.Location = new System.Drawing.Point(138, 75);
            this.txtDuyet_Log.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDuyet_Log.MaxLength = 20;
            this.txtDuyet_Log.Name = "txtDuyet_Log";
            this.txtDuyet_Log.Size = new System.Drawing.Size(180, 20);
            this.txtDuyet_Log.TabIndex = 98;
            this.txtDuyet_Log.UseAutoFilter = false;
            // 
            // chkDuyet
            // 
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Location = new System.Drawing.Point(138, 31);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(103, 17);
            this.chkDuyet.TabIndex = 96;
            this.chkDuyet.Tag = "";
            this.chkDuyet.Text = "Xác nhận gửi tin";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Ky
            // 
            this.dteNgay_Ky.bAllowEmpty = true;
            this.dteNgay_Ky.bRequire = false;
            this.dteNgay_Ky.bSelectOnFocus = false;
            this.dteNgay_Ky.bShowDateTimePicker = true;
            this.dteNgay_Ky.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ky.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ky.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ky.Location = new System.Drawing.Point(138, 51);
            this.dteNgay_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ky.Mask = "00/00/0000";
            this.dteNgay_Ky.Name = "dteNgay_Ky";
            this.dteNgay_Ky.Size = new System.Drawing.Size(68, 20);
            this.dteNgay_Ky.TabIndex = 97;
            // 
            // lblNgay_Ct1
            // 
            this.lblNgay_Ct1.AutoEllipsis = true;
            this.lblNgay_Ct1.AutoSize = true;
            this.lblNgay_Ct1.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Ct1.Location = new System.Drawing.Point(42, 51);
            this.lblNgay_Ct1.Name = "lblNgay_Ct1";
            this.lblNgay_Ct1.Size = new System.Drawing.Size(63, 13);
            this.lblNgay_Ct1.TabIndex = 99;
            this.lblNgay_Ct1.Tag = "";
            this.lblNgay_Ct1.Text = "Ngày Duyệt";
            this.lblNgay_Ct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 200);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.txtDuyet_Log);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.dteNgay_Ky);
            this.Controls.Add(this.lblNgay_Ct1);
            this.Controls.Add(this.btSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuyet";
            this.Tag = "frmDuyet";
            this.Text = "Duyệt chứng từ";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.btControl btSave;
        private Systems.Controls.lblControl lblControl2;
        public Systems.Controls.txtTextBox txtDuyet_Log;
        private Systems.Controls.chkControl chkDuyet;
        public Systems.Controls.txtDateTime dteNgay_Ky;
        private Systems.Controls.lblControl lblNgay_Ct1;
	}
}