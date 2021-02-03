namespace Epoint.Modules.KPI
{
	partial class frmKPIRank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKPIRank));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboApplyFor = new Epoint.Systems.Controls.cboMultiControl();
            this.lblMa_Bp = new Epoint.Systems.Controls.lblControl();
            this.lbtTen_Bp = new Epoint.Systems.Controls.lbtControl();
            this.btImport = new Epoint.Systems.Controls.btControl();
            this.btnSendMail = new Epoint.Systems.Controls.btControl();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "posted");
            this.imageList1.Images.SetKeyName(1, "delete");
            this.imageList1.Images.SetKeyName(2, "calc");
            this.imageList1.Images.SetKeyName(3, "add");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 481);
            this.panel1.TabIndex = 2;
            // 
            // cboApplyFor
            // 
            this.cboApplyFor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboApplyFor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboApplyFor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboApplyFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboApplyFor.InitValue = null;
            this.cboApplyFor.Location = new System.Drawing.Point(91, 6);
            this.cboApplyFor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboApplyFor.MaxLength = 20;
            this.cboApplyFor.Name = "cboApplyFor";
            this.cboApplyFor.Size = new System.Drawing.Size(116, 21);
            this.cboApplyFor.strValueList = null;
            this.cboApplyFor.TabIndex = 1;
            this.cboApplyFor.UpperCase = false;
            this.cboApplyFor.UseAutoComplete = false;
            this.cboApplyFor.UseBindingValue = false;
            // 
            // lblMa_Bp
            // 
            this.lblMa_Bp.AutoEllipsis = true;
            this.lblMa_Bp.AutoSize = true;
            this.lblMa_Bp.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa_Bp.ForeColor = System.Drawing.Color.Blue;
            this.lblMa_Bp.Location = new System.Drawing.Point(12, 9);
            this.lblMa_Bp.Name = "lblMa_Bp";
            this.lblMa_Bp.Size = new System.Drawing.Size(79, 13);
            this.lblMa_Bp.TabIndex = 65;
            this.lblMa_Bp.Tag = "";
            this.lblMa_Bp.Text = "Áp dụng cho";
            this.lblMa_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtTen_Bp
            // 
            this.lbtTen_Bp.AutoEllipsis = true;
            this.lbtTen_Bp.AutoSize = true;
            this.lbtTen_Bp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtTen_Bp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Bp.Location = new System.Drawing.Point(212, 9);
            this.lbtTen_Bp.Name = "lbtTen_Bp";
            this.lbtTen_Bp.Size = new System.Drawing.Size(80, 13);
            this.lbtTen_Bp.TabIndex = 65;
            this.lbtTen_Bp.Tag = "";
            this.lbtTen_Bp.Text = "Tên Bộ phận";
            this.lbtTen_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImport.ForeColor = System.Drawing.Color.Blue;
            this.btImport.Image = ((System.Drawing.Image)(resources.GetObject("btImport.Image")));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.Location = new System.Drawing.Point(507, 526);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(136, 30);
            this.btImport.TabIndex = 7;
            this.btImport.Tag = "Import";
            this.btImport.Text = "&Lấy dữ liệu";
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btnSendMail
            // 
            this.btnSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.ForeColor = System.Drawing.Color.Blue;
            this.btnSendMail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendMail.Image")));
            this.btnSendMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendMail.Location = new System.Drawing.Point(649, 526);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(135, 30);
            this.btnSendMail.TabIndex = 6;
            this.btnSendMail.Tag = "Send_Mail";
            this.btnSendMail.Text = "Gửi Email";
            this.btnSendMail.UseVisualStyleBackColor = true;
            // 
            // frmKPIRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.cboApplyFor);
            this.Controls.Add(this.lbtTen_Bp);
            this.Controls.Add(this.lblMa_Bp);
            this.Controls.Add(this.panel1);
            this.Name = "frmKPIRank";
            this.Tag = "frmBangLuong";
            this.Text = "frmBangLuong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private Epoint.Systems.Controls.cboMultiControl cboApplyFor;
		private Epoint.Systems.Controls.lblControl lblMa_Bp;
        private Epoint.Systems.Controls.lbtControl lbtTen_Bp;
        private System.Windows.Forms.ImageList imageList1;
        private Systems.Controls.btControl btImport;
        private Systems.Controls.btControl btnSendMail;
	}
}