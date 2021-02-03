namespace Epoint.Controllers
{
	partial class frmLocked 
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocked));
            this.lvDmNam = new Epoint.Systems.Controls.lvControl();
            this.txtTh_Bd_Ht = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.dgvLocked = new Epoint.Systems.Controls.dgvControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btSave = new Epoint.Systems.Controls.btControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkLocked_SdHanTt = new System.Windows.Forms.CheckBox();
            this.chkLocked_Sdv = new System.Windows.Forms.CheckBox();
            this.chkLocked_Sdk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocked)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDmNam
            // 
            this.lvDmNam.DataSource = null;
            this.lvDmNam.FullRowSelect = true;
            this.lvDmNam.HideSelection = false;
            this.lvDmNam.Location = new System.Drawing.Point(12, 12);
            this.lvDmNam.Name = "lvDmNam";
            this.lvDmNam.Size = new System.Drawing.Size(108, 283);
            this.lvDmNam.strZone = "";
            this.lvDmNam.TabIndex = 0;
            this.lvDmNam.UseCompatibleStateImageBehavior = false;
            this.lvDmNam.View = System.Windows.Forms.View.Details;
            // 
            // txtTh_Bd_Ht
            // 
            this.txtTh_Bd_Ht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTh_Bd_Ht.bEnabled = true;
            this.txtTh_Bd_Ht.bIsLookup = false;
            this.txtTh_Bd_Ht.bReadOnly = false;
            this.txtTh_Bd_Ht.bRequire = false;
            this.txtTh_Bd_Ht.Enabled = false;
            this.txtTh_Bd_Ht.KeyFilter = "";
            this.txtTh_Bd_Ht.Location = new System.Drawing.Point(144, 304);
            this.txtTh_Bd_Ht.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTh_Bd_Ht.Name = "txtTh_Bd_Ht";
            this.txtTh_Bd_Ht.Size = new System.Drawing.Size(33, 20);
            this.txtTh_Bd_Ht.TabIndex = 1;
            this.txtTh_Bd_Ht.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.ForeColor = System.Drawing.Color.Blue;
            this.lblControl1.Location = new System.Drawing.Point(12, 307);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(129, 13);
            this.lblControl1.TabIndex = 2;
            this.lblControl1.Tag = "Th_Bd_Ht";
            this.lblControl1.Text = "Tháng bắt đầu hạch toán";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvLocked
            // 
            this.dgvLocked.AllowUserToAddRows = false;
            this.dgvLocked.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLocked.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocked.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocked.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLocked.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocked.EnableHeadersVisualStyles = false;
            this.dgvLocked.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvLocked.Location = new System.Drawing.Point(4, 4);
            this.dgvLocked.MultiSelect = false;
            this.dgvLocked.Name = "dgvLocked";
            this.dgvLocked.ReadOnly = true;
            this.dgvLocked.RowHeadersWidth = 20;
            this.dgvLocked.Size = new System.Drawing.Size(332, 251);
            this.dgvLocked.strZone = "";
            this.dgvLocked.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "calendar.png");
            // 
            // btSave
            // 
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSave.Enabled = false;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(260, 212);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(63, 31);
            this.btSave.TabIndex = 3;
            this.btSave.Tag = "Save";
            this.btSave.Text = "&Lưu";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(126, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(347, 284);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLocked);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(339, 258);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "Lock_PhatSinh";
            this.tabPage1.Text = "Khóa số phát sinh";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkLocked_SdHanTt);
            this.tabPage2.Controls.Add(this.btSave);
            this.tabPage2.Controls.Add(this.chkLocked_Sdv);
            this.tabPage2.Controls.Add(this.chkLocked_Sdk);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(339, 258);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "Lock_SoDuDau";
            this.tabPage2.Text = "Khóa số dư đầu kỳ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkLocked_SdHanTt
            // 
            this.chkLocked_SdHanTt.AutoSize = true;
            this.chkLocked_SdHanTt.Location = new System.Drawing.Point(15, 89);
            this.chkLocked_SdHanTt.Name = "chkLocked_SdHanTt";
            this.chkLocked_SdHanTt.Size = new System.Drawing.Size(219, 17);
            this.chkLocked_SdHanTt.TabIndex = 2;
            this.chkLocked_SdHanTt.Tag = "Lock_CDHANTT";
            this.chkLocked_SdHanTt.Text = "Khóa số dư đầu công nợ hạn thanh toán";
            this.chkLocked_SdHanTt.UseVisualStyleBackColor = true;
            // 
            // chkLocked_Sdv
            // 
            this.chkLocked_Sdv.AutoSize = true;
            this.chkLocked_Sdv.Location = new System.Drawing.Point(15, 66);
            this.chkLocked_Sdv.Name = "chkLocked_Sdv";
            this.chkLocked_Sdv.Size = new System.Drawing.Size(153, 17);
            this.chkLocked_Sdv.TabIndex = 1;
            this.chkLocked_Sdv.Tag = "Lock_CDV";
            this.chkLocked_Sdv.Text = "Khóa số dư đầu kho vật tư";
            this.chkLocked_Sdv.UseVisualStyleBackColor = true;
            // 
            // chkLocked_Sdk
            // 
            this.chkLocked_Sdk.AutoSize = true;
            this.chkLocked_Sdk.Location = new System.Drawing.Point(15, 43);
            this.chkLocked_Sdk.Name = "chkLocked_Sdk";
            this.chkLocked_Sdk.Size = new System.Drawing.Size(141, 17);
            this.chkLocked_Sdk.TabIndex = 0;
            this.chkLocked_Sdk.Tag = "Lock_CDK";
            this.chkLocked_Sdk.Text = "Khóa số dư đầu kế toán";
            this.chkLocked_Sdk.UseVisualStyleBackColor = true;
            // 
            // frmLocked
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 339);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtTh_Bd_Ht);
            this.Controls.Add(this.lvDmNam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocked";
            this.Tag = "frmLocked";
            this.Text = "frmLocked";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocked)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.lvControl lvDmNam;
		private Epoint.Systems.Controls.txtTextBox txtTh_Bd_Ht;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.dgvControl dgvLocked;
		private System.Windows.Forms.ImageList imageList1;
		private Epoint.Systems.Controls.btControl btSave;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CheckBox chkLocked_Sdk;
		private System.Windows.Forms.CheckBox chkLocked_SdHanTt;
        private System.Windows.Forms.CheckBox chkLocked_Sdv;


	}
}