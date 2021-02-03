namespace Epoint.Controllers
{
	partial class frmReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlReport = new Epoint.Systems.Controls.tlControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpFilter = new System.Windows.Forms.TabPage();
            this.dgvReportFilter = new Epoint.Systems.Controls.dgvControl();
            this.tpReportInfo = new System.Windows.Forms.TabPage();
            this.dgvReportInfo = new Epoint.Systems.Controls.dgvControl();
            this.tpReportDetail = new System.Windows.Forms.TabPage();
            this.dgvReportDetail = new Epoint.Systems.Controls.dgvControl();
            ((System.ComponentModel.ISupportInitialize)(this.tlReport)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportFilter)).BeginInit();
            this.tpReportInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportInfo)).BeginInit();
            this.tpReportDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tlReport
            // 
            this.tlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlReport.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlReport.Appearance.EvenRow.Options.UseBackColor = true;
            this.tlReport.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.tlReport.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.tlReport.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tlReport.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tlReport.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow;
            this.tlReport.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.tlReport.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tlReport.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tlReport.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tlReport.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlReport.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tlReport.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Yellow;
            this.tlReport.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tlReport.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tlReport.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tlReport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.tlReport.Location = new System.Drawing.Point(3, 3);
            this.tlReport.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.tlReport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tlReport.LookAndFeel.UseWindowsXPTheme = true;
            this.tlReport.Name = "tlReport";
            this.tlReport.OptionsBehavior.AllowIncrementalSearch = true;
            this.tlReport.OptionsBehavior.AutoFocusNewNode = true;
            this.tlReport.OptionsBehavior.Editable = false;
            this.tlReport.OptionsBehavior.EnableFiltering = true;
            this.tlReport.OptionsBehavior.EnterMovesNextColumn = true;
            this.tlReport.OptionsBehavior.ImmediateEditor = false;
            this.tlReport.OptionsBehavior.UseTabKey = true;
            this.tlReport.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tlReport.OptionsView.AutoWidth = false;
            this.tlReport.OptionsView.EnableAppearanceEvenRow = true;
            this.tlReport.Size = new System.Drawing.Size(783, 279);
            this.tlReport.strZone = "";
            this.tlReport.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpFilter);
            this.tabControl1.Controls.Add(this.tpReportInfo);
            this.tabControl1.Controls.Add(this.tpReportDetail);
            this.tabControl1.Location = new System.Drawing.Point(6, 291);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 272);
            this.tabControl1.TabIndex = 1;
            // 
            // tpFilter
            // 
            this.tpFilter.Controls.Add(this.dgvReportFilter);
            this.tpFilter.Location = new System.Drawing.Point(4, 22);
            this.tpFilter.Name = "tpFilter";
            this.tpFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tpFilter.Size = new System.Drawing.Size(772, 246);
            this.tpFilter.TabIndex = 0;
            this.tpFilter.Tag = "Filter";
            this.tpFilter.Text = "Điều kiện lọc";
            this.tpFilter.UseVisualStyleBackColor = true;
            // 
            // dgvReportFilter
            // 
            this.dgvReportFilter.AllowUserToAddRows = false;
            this.dgvReportFilter.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReportFilter.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReportFilter.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReportFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportFilter.EnableHeadersVisualStyles = false;
            this.dgvReportFilter.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReportFilter.Location = new System.Drawing.Point(3, 3);
            this.dgvReportFilter.MultiSelect = false;
            this.dgvReportFilter.Name = "dgvReportFilter";
            this.dgvReportFilter.ReadOnly = true;
            this.dgvReportFilter.Size = new System.Drawing.Size(766, 240);
            this.dgvReportFilter.strZone = "";
            this.dgvReportFilter.TabIndex = 0;
            // 
            // tpReportInfo
            // 
            this.tpReportInfo.Controls.Add(this.dgvReportInfo);
            this.tpReportInfo.Location = new System.Drawing.Point(4, 22);
            this.tpReportInfo.Name = "tpReportInfo";
            this.tpReportInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpReportInfo.Size = new System.Drawing.Size(772, 246);
            this.tpReportInfo.TabIndex = 1;
            this.tpReportInfo.Tag = "ReportInfo";
            this.tpReportInfo.Text = "Thông tin report";
            this.tpReportInfo.UseVisualStyleBackColor = true;
            // 
            // dgvReportInfo
            // 
            this.dgvReportInfo.AllowUserToAddRows = false;
            this.dgvReportInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReportInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReportInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReportInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportInfo.EnableHeadersVisualStyles = false;
            this.dgvReportInfo.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReportInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvReportInfo.MultiSelect = false;
            this.dgvReportInfo.Name = "dgvReportInfo";
            this.dgvReportInfo.ReadOnly = true;
            this.dgvReportInfo.Size = new System.Drawing.Size(766, 240);
            this.dgvReportInfo.strZone = "";
            this.dgvReportInfo.TabIndex = 0;
            // 
            // tpReportDetail
            // 
            this.tpReportDetail.Controls.Add(this.dgvReportDetail);
            this.tpReportDetail.Location = new System.Drawing.Point(4, 22);
            this.tpReportDetail.Name = "tpReportDetail";
            this.tpReportDetail.Size = new System.Drawing.Size(772, 246);
            this.tpReportDetail.TabIndex = 2;
            this.tpReportDetail.Tag = "Report_Detail";
            this.tpReportDetail.Text = "Report detail";
            this.tpReportDetail.UseVisualStyleBackColor = true;
            // 
            // dgvReportDetail
            // 
            this.dgvReportDetail.AllowUserToAddRows = false;
            this.dgvReportDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReportDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReportDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReportDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportDetail.EnableHeadersVisualStyles = false;
            this.dgvReportDetail.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReportDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvReportDetail.MultiSelect = false;
            this.dgvReportDetail.Name = "dgvReportDetail";
            this.dgvReportDetail.ReadOnly = true;
            this.dgvReportDetail.Size = new System.Drawing.Size(772, 246);
            this.dgvReportDetail.strZone = "";
            this.dgvReportDetail.TabIndex = 1;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 569);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tlReport);
            this.Name = "frmReport";
            this.Tag = "frmReport, F2, F3, F8, ESC";
            this.Text = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tlReport)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportFilter)).EndInit();
            this.tpReportInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportInfo)).EndInit();
            this.tpReportDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportDetail)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.tlControl tlReport;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpFilter;
		private System.Windows.Forms.TabPage tpReportInfo;
		private Epoint.Systems.Controls.dgvControl dgvReportFilter;
		private Epoint.Systems.Controls.dgvControl dgvReportInfo;
		private System.Windows.Forms.TabPage tpReportDetail;
		private Epoint.Systems.Controls.dgvControl dgvReportDetail;



	}
}