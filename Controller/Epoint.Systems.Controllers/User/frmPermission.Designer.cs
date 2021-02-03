namespace Epoint.Controllers
{
	partial class frmPermission
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAccessModule = new Epoint.Systems.Controls.rdbControl();
            this.rdbAccessDvCs = new Epoint.Systems.Controls.rdbControl();
            this.rdbAccessAccount = new Epoint.Systems.Controls.rdbControl();
            this.rbAccessSystem = new Epoint.Systems.Controls.rdbControl();
            this.rbAccessReport = new Epoint.Systems.Controls.rdbControl();
            this.rbAccessExec = new Epoint.Systems.Controls.rdbControl();
            this.rbAccessData = new Epoint.Systems.Controls.rdbControl();
            this.pnlPermission = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAccessModule);
            this.groupBox1.Controls.Add(this.rdbAccessDvCs);
            this.groupBox1.Controls.Add(this.rdbAccessAccount);
            this.groupBox1.Controls.Add(this.rbAccessSystem);
            this.groupBox1.Controls.Add(this.rbAccessReport);
            this.groupBox1.Controls.Add(this.rbAccessExec);
            this.groupBox1.Controls.Add(this.rbAccessData);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "PERMISSION_TYPE";
            this.groupBox1.Text = "Loại phân quyền";
            // 
            // rbAccessModule
            // 
            this.rbAccessModule.AutoSize = true;
            this.rbAccessModule.Checked = true;
            this.rbAccessModule.Location = new System.Drawing.Point(11, 22);
            this.rbAccessModule.Name = "rbAccessModule";
            this.rbAccessModule.Size = new System.Drawing.Size(125, 17);
            this.rbAccessModule.TabIndex = 2;
            this.rbAccessModule.TabStop = true;
            this.rbAccessModule.Tag = "ACCESSMODULE";
            this.rbAccessModule.Text = "Truy cập phân hệ";
            this.rbAccessModule.UnChecked = false;
            this.rbAccessModule.UseVisualStyleBackColor = true;
            // 
            // rdbAccessDvCs
            // 
            this.rdbAccessDvCs.AutoSize = true;
            this.rdbAccessDvCs.Location = new System.Drawing.Point(813, 22);
            this.rdbAccessDvCs.Name = "rdbAccessDvCs";
            this.rdbAccessDvCs.Size = new System.Drawing.Size(150, 17);
            this.rdbAccessDvCs.TabIndex = 1;
            this.rdbAccessDvCs.Tag = "AccessDvCs";
            this.rdbAccessDvCs.Text = "Truy cập đơn vị cở sở";
            this.rdbAccessDvCs.UnChecked = true;
            this.rdbAccessDvCs.UseVisualStyleBackColor = true;
            // 
            // rdbAccessAccount
            // 
            this.rdbAccessAccount.AutoSize = true;
            this.rdbAccessAccount.Location = new System.Drawing.Point(667, 22);
            this.rdbAccessAccount.Name = "rdbAccessAccount";
            this.rdbAccessAccount.Size = new System.Drawing.Size(132, 17);
            this.rdbAccessAccount.TabIndex = 1;
            this.rdbAccessAccount.Tag = "AccessAccount";
            this.rdbAccessAccount.Text = "Truy cập tài khoản";
            this.rdbAccessAccount.UnChecked = true;
            this.rdbAccessAccount.UseVisualStyleBackColor = true;
            // 
            // rbAccessSystem
            // 
            this.rbAccessSystem.AutoSize = true;
            this.rbAccessSystem.Location = new System.Drawing.Point(526, 22);
            this.rbAccessSystem.Name = "rbAccessSystem";
            this.rbAccessSystem.Size = new System.Drawing.Size(129, 17);
            this.rbAccessSystem.TabIndex = 1;
            this.rbAccessSystem.Tag = "AccessSystem";
            this.rbAccessSystem.Text = "Truy cập hệ thống";
            this.rbAccessSystem.UnChecked = true;
            this.rbAccessSystem.UseVisualStyleBackColor = true;
            // 
            // rbAccessReport
            // 
            this.rbAccessReport.AutoSize = true;
            this.rbAccessReport.Location = new System.Drawing.Point(388, 22);
            this.rbAccessReport.Name = "rbAccessReport";
            this.rbAccessReport.Size = new System.Drawing.Size(125, 17);
            this.rbAccessReport.TabIndex = 0;
            this.rbAccessReport.Tag = "AccessReport";
            this.rbAccessReport.Text = "Truy cập báo cáo";
            this.rbAccessReport.UnChecked = true;
            this.rbAccessReport.UseVisualStyleBackColor = true;
            // 
            // rbAccessExec
            // 
            this.rbAccessExec.AutoSize = true;
            this.rbAccessExec.Location = new System.Drawing.Point(273, 22);
            this.rbAccessExec.Name = "rbAccessExec";
            this.rbAccessExec.Size = new System.Drawing.Size(105, 17);
            this.rbAccessExec.TabIndex = 4;
            this.rbAccessExec.Tag = "AccessExec";
            this.rbAccessExec.Text = "Truy cập xử lý";
            this.rbAccessExec.UnChecked = true;
            this.rbAccessExec.UseVisualStyleBackColor = true;
            // 
            // rbAccessData
            // 
            this.rbAccessData.AutoSize = true;
            this.rbAccessData.Location = new System.Drawing.Point(147, 22);
            this.rbAccessData.Name = "rbAccessData";
            this.rbAccessData.Size = new System.Drawing.Size(117, 17);
            this.rbAccessData.TabIndex = 3;
            this.rbAccessData.Tag = "ACCESSDATA";
            this.rbAccessData.Text = "Truy cập dữ liệu";
            this.rbAccessData.UnChecked = true;
            this.rbAccessData.UseVisualStyleBackColor = true;
            // 
            // pnlPermission
            // 
            this.pnlPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPermission.Location = new System.Drawing.Point(10, 67);
            this.pnlPermission.Name = "pnlPermission";
            this.pnlPermission.Size = new System.Drawing.Size(975, 487);
            this.pnlPermission.TabIndex = 4;
            // 
            // frmPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 566);
            this.Controls.Add(this.pnlPermission);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPermission";
            this.Tag = "frmPermission";
            this.Text = "frmPermission";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBox1;
		private Epoint.Systems.Controls.rdbControl rbAccessData;
		private Epoint.Systems.Controls.rdbControl rbAccessReport;
		private Epoint.Systems.Controls.rdbControl rbAccessExec;
		private Epoint.Systems.Controls.rdbControl rbAccessModule;
		private Epoint.Systems.Controls.rdbControl rbAccessSystem;
		private Epoint.Systems.Controls.rdbControl rdbAccessAccount;
		private System.Windows.Forms.Panel pnlPermission;
        private Epoint.Systems.Controls.rdbControl rdbAccessDvCs;
	}
}