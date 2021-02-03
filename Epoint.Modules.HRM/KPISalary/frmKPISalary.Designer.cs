namespace Epoint.Modules.KPI
{
	partial class frmKPISalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKPISalary));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboKPI = new Epoint.Systems.Controls.cboMultiControl();
            this.lblMa_Bp = new Epoint.Systems.Controls.lblControl();
            this.lbtKPIDescr = new Epoint.Systems.Controls.lbtControl();
            this.btImport = new Epoint.Systems.Controls.btControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabKPI = new Epoint.Systems.Controls.tabControl();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.tpDetail = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.tabKPI.SuspendLayout();
            this.tpResult.SuspendLayout();
            this.tpDetail.SuspendLayout();
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 430);
            this.panel1.TabIndex = 2;
            // 
            // cboKPI
            // 
            this.cboKPI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKPI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboKPI.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboKPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKPI.InitValue = null;
            this.cboKPI.Location = new System.Drawing.Point(91, 6);
            this.cboKPI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboKPI.MaxLength = 20;
            this.cboKPI.Name = "cboKPI";
            this.cboKPI.Size = new System.Drawing.Size(187, 21);
            this.cboKPI.strValueList = null;
            this.cboKPI.TabIndex = 1;
            this.cboKPI.UpperCase = false;
            this.cboKPI.UseAutoComplete = false;
            this.cboKPI.UseBindingValue = false;
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
            this.lblMa_Bp.Size = new System.Drawing.Size(40, 13);
            this.lblMa_Bp.TabIndex = 65;
            this.lblMa_Bp.Tag = "";
            this.lblMa_Bp.Text = "KPIID";
            this.lblMa_Bp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtKPIDescr
            // 
            this.lbtKPIDescr.AutoEllipsis = true;
            this.lbtKPIDescr.AutoSize = true;
            this.lbtKPIDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtKPIDescr.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtKPIDescr.Location = new System.Drawing.Point(283, 9);
            this.lbtKPIDescr.Name = "lbtKPIDescr";
            this.lbtKPIDescr.Size = new System.Drawing.Size(57, 13);
            this.lbtKPIDescr.TabIndex = 65;
            this.lbtKPIDescr.Tag = "";
            this.lbtKPIDescr.Text = "Diễn giải";
            this.lbtKPIDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImport.ForeColor = System.Drawing.Color.Blue;
            this.btImport.Image = ((System.Drawing.Image)(resources.GetObject("btImport.Image")));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.Location = new System.Drawing.Point(644, 526);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(136, 30);
            this.btImport.TabIndex = 7;
            this.btImport.Tag = "Import";
            this.btImport.Text = "&Lấy dữ liệu";
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 494);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 71);
            this.panel2.TabIndex = 66;
            this.panel2.TabStop = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.Color.Blue;
            this.radioButton3.Location = new System.Drawing.Point(3, 50);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(99, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "TAB3";
            this.radioButton3.Text = "&3. Lương KPI";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.Blue;
            this.radioButton2.Location = new System.Drawing.Point(3, 27);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(108, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "TAB2";
            this.radioButton2.Text = "&2. Kết quả KPI";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.Blue;
            this.radioButton1.Location = new System.Drawing.Point(3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "Tab1";
            this.radioButton1.Text = "&1. Tất cả";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabKPI
            // 
            this.tabKPI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKPI.Controls.Add(this.tpResult);
            this.tabKPI.Controls.Add(this.tpDetail);
            this.tabKPI.Location = new System.Drawing.Point(6, 32);
            this.tabKPI.Name = "tabKPI";
            this.tabKPI.SelectedIndex = 0;
            this.tabKPI.Size = new System.Drawing.Size(785, 456);
            this.tabKPI.TabIndex = 67;
            // 
            // tpResult
            // 
            this.tpResult.Controls.Add(this.panel1);
            this.tpResult.Location = new System.Drawing.Point(4, 22);
            this.tpResult.Name = "tpResult";
            this.tpResult.Size = new System.Drawing.Size(777, 430);
            this.tpResult.TabIndex = 4;
            this.tpResult.Text = "KPI Result";
            this.tpResult.UseVisualStyleBackColor = true;
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.panel3);
            this.tpDetail.Location = new System.Drawing.Point(4, 22);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(777, 430);
            this.tpDetail.TabIndex = 3;
            this.tpDetail.Text = "Trọng số";
            this.tpDetail.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(777, 430);
            this.panel3.TabIndex = 3;
            // 
            // frmKPISalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tabKPI);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.cboKPI);
            this.Controls.Add(this.lbtKPIDescr);
            this.Controls.Add(this.lblMa_Bp);
            this.Name = "frmKPISalary";
            this.Tag = "frmBangLuong";
            this.Text = "frmBangLuong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabKPI.ResumeLayout(false);
            this.tpResult.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private Epoint.Systems.Controls.cboMultiControl cboKPI;
		private Epoint.Systems.Controls.lblControl lblMa_Bp;
        private Epoint.Systems.Controls.lbtControl lbtKPIDescr;
        private System.Windows.Forms.ImageList imageList1;
        private Systems.Controls.btControl btImport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private Systems.Controls.tabControl tabKPI;
        private System.Windows.Forms.TabPage tpResult;
        private System.Windows.Forms.TabPage tpDetail;
        private System.Windows.Forms.Panel panel3;
    }
}