namespace Epoint.Controllers
{
	partial class frmMenu_Report
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
			this.dgvMenu = new Epoint.Systems.Controls.dgvControl();
			this.tlMenu_Report = new Epoint.Systems.Controls.tlControl();

			((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tlMenu_Report)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvMenu
			// 
			this.dgvMenu.AllowUserToAddRows = false;
			this.dgvMenu.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvMenu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.dgvMenu.BackgroundColor = System.Drawing.Color.White;
			this.dgvMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMenu.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvMenu.Location = new System.Drawing.Point(6, 6);
			this.dgvMenu.MultiSelect = false;
			this.dgvMenu.Name = "dgvMenu";
			this.dgvMenu.ReadOnly = true;
			this.dgvMenu.Size = new System.Drawing.Size(240, 554);
			this.dgvMenu.strZone = "";
			this.dgvMenu.TabIndex = 0;
			// 
			// tlMenu_Report
			// 
			this.tlMenu_Report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tlMenu_Report.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tlMenu_Report.Appearance.EvenRow.Options.UseBackColor = true;
			this.tlMenu_Report.Appearance.FocusedCell.BackColor = System.Drawing.Color.Blue;
			this.tlMenu_Report.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.tlMenu_Report.Appearance.FocusedCell.Options.UseBackColor = true;
			this.tlMenu_Report.Appearance.FocusedCell.Options.UseForeColor = true;
			this.tlMenu_Report.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow;
			this.tlMenu_Report.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
			this.tlMenu_Report.Appearance.FocusedRow.Options.UseBackColor = true;
			this.tlMenu_Report.Appearance.FocusedRow.Options.UseForeColor = true;
			this.tlMenu_Report.Appearance.HeaderPanel.Options.UseTextOptions = true;
			this.tlMenu_Report.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.tlMenu_Report.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.tlMenu_Report.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Yellow;
			this.tlMenu_Report.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
			this.tlMenu_Report.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.tlMenu_Report.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.tlMenu_Report.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.tlMenu_Report.Location = new System.Drawing.Point(252, 6);
			this.tlMenu_Report.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.tlMenu_Report.LookAndFeel.UseDefaultLookAndFeel = false;
			this.tlMenu_Report.LookAndFeel.UseWindowsXPTheme = true;
			this.tlMenu_Report.Name = "tlMenu_Report";
			this.tlMenu_Report.OptionsBehavior.AllowIncrementalSearch = true;
			this.tlMenu_Report.OptionsBehavior.AutoFocusNewNode = true;
			this.tlMenu_Report.OptionsBehavior.Editable = false;
			this.tlMenu_Report.OptionsBehavior.EnableFiltering = true;
			this.tlMenu_Report.OptionsBehavior.EnterMovesNextColumn = true;
			this.tlMenu_Report.OptionsBehavior.ImmediateEditor = false;
			this.tlMenu_Report.OptionsBehavior.UseTabKey = true;
			this.tlMenu_Report.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.tlMenu_Report.OptionsView.AutoWidth = false;
			this.tlMenu_Report.OptionsView.EnableAppearanceEvenRow = true;
			this.tlMenu_Report.Size = new System.Drawing.Size(534, 554);
			this.tlMenu_Report.strZone = "";
			this.tlMenu_Report.TabIndex = 1;
			// 
			// frmMenu_Report
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.tlMenu_Report);
			this.Controls.Add(this.dgvMenu);
			this.Name = "frmMenu_Report";
			this.Tag = "frmModule_Report";
			this.Text = "frmModule_Report";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

			((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tlMenu_Report)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.dgvControl dgvMenu;
		private Epoint.Systems.Controls.tlControl tlMenu_Report;


	}
}