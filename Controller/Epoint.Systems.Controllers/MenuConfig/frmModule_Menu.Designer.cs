namespace Epoint.Controllers
{
	partial class frmModule_Menu
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
			this.dgvModule = new Epoint.Systems.Controls.dgvControl();
			this.tlModule_Menu = new Epoint.Systems.Controls.tlControl();

			((System.ComponentModel.ISupportInitialize)(this.dgvModule)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tlModule_Menu)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvModule
			// 
			this.dgvModule.AllowUserToAddRows = false;
			this.dgvModule.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgvModule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.dgvModule.BackgroundColor = System.Drawing.Color.White;
			this.dgvModule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvModule.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dgvModule.Location = new System.Drawing.Point(6, 6);
			this.dgvModule.MultiSelect = false;
			this.dgvModule.Name = "dgvModule";
			this.dgvModule.ReadOnly = true;
			this.dgvModule.Size = new System.Drawing.Size(240, 554);
			this.dgvModule.strZone = "";
			this.dgvModule.TabIndex = 0;
			// 
			// tlModule_Menu
			// 
			this.tlModule_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tlModule_Menu.Appearance.FocusedCell.BackColor = System.Drawing.Color.Blue;
			this.tlModule_Menu.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.tlModule_Menu.Appearance.FocusedCell.Options.UseBackColor = true;
			this.tlModule_Menu.Appearance.FocusedCell.Options.UseForeColor = true;
			this.tlModule_Menu.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow;
			this.tlModule_Menu.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
			this.tlModule_Menu.Appearance.FocusedRow.Options.UseBackColor = true;
			this.tlModule_Menu.Appearance.FocusedRow.Options.UseForeColor = true;
			this.tlModule_Menu.Appearance.HeaderPanel.Options.UseTextOptions = true;
			this.tlModule_Menu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.tlModule_Menu.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.tlModule_Menu.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Yellow;
			this.tlModule_Menu.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
			this.tlModule_Menu.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.tlModule_Menu.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.tlModule_Menu.Location = new System.Drawing.Point(252, 6);
			this.tlModule_Menu.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.tlModule_Menu.LookAndFeel.UseWindowsXPTheme = true;
			this.tlModule_Menu.Name = "tlModule_Menu";
			this.tlModule_Menu.OptionsBehavior.AllowIncrementalSearch = true;
			this.tlModule_Menu.OptionsBehavior.Editable = false;
			this.tlModule_Menu.OptionsBehavior.EnableFiltering = true;
			this.tlModule_Menu.OptionsBehavior.EnterMovesNextColumn = true;
			this.tlModule_Menu.OptionsBehavior.UseTabKey = true;
			this.tlModule_Menu.OptionsView.AutoWidth = false;
			this.tlModule_Menu.Size = new System.Drawing.Size(534, 554);
			this.tlModule_Menu.TabIndex = 1;
			// 
			// frmModule_Menu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.tlModule_Menu);
			this.Controls.Add(this.dgvModule);
			this.Name = "frmModule_Menu";
			this.Text = "frmModule_Report";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

			((System.ComponentModel.ISupportInitialize)(this.dgvModule)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tlModule_Menu)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.dgvControl dgvModule;
		private Epoint.Systems.Controls.tlControl tlModule_Menu;


	}
}