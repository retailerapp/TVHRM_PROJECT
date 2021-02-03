namespace Epoint.Controllers
{
	partial class frmZones
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tlZone = new Epoint.Systems.Controls.tlControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpColumns = new System.Windows.Forms.TabPage();
            this.dgvColumns = new Epoint.Systems.Controls.dgvControl();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlZone)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tlZone);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Size = new System.Drawing.Size(792, 569);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.TabIndex = 0;
            // 
            // tlZone
            // 
            this.tlZone.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlZone.Appearance.EvenRow.Options.UseBackColor = true;
            this.tlZone.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.tlZone.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.tlZone.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tlZone.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tlZone.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tlZone.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlZone.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tlZone.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.tlZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlZone.Location = new System.Drawing.Point(0, 0);
            this.tlZone.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.tlZone.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tlZone.LookAndFeel.UseWindowsXPTheme = true;
            this.tlZone.Name = "tlZone";
            this.tlZone.OptionsBehavior.AllowIncrementalSearch = true;
            this.tlZone.OptionsBehavior.AutoFocusNewNode = true;
            this.tlZone.OptionsBehavior.Editable = false;
            this.tlZone.OptionsBehavior.EnableFiltering = true;
            this.tlZone.OptionsBehavior.EnterMovesNextColumn = true;
            this.tlZone.OptionsBehavior.ImmediateEditor = false;
            this.tlZone.OptionsBehavior.UseTabKey = true;
            this.tlZone.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tlZone.OptionsView.AutoWidth = false;
            this.tlZone.OptionsView.EnableAppearanceEvenRow = true;
            this.tlZone.Size = new System.Drawing.Size(792, 300);
            this.tlZone.strZone = "";
            this.tlZone.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpColumns);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(792, 265);
            this.tabControl.TabIndex = 0;
            // 
            // tpColumns
            // 
            this.tpColumns.Controls.Add(this.dgvColumns);
            this.tpColumns.Location = new System.Drawing.Point(4, 22);
            this.tpColumns.Name = "tpColumns";
            this.tpColumns.Padding = new System.Windows.Forms.Padding(3);
            this.tpColumns.Size = new System.Drawing.Size(784, 239);
            this.tpColumns.TabIndex = 0;
            this.tpColumns.Text = "Columns";
            this.tpColumns.UseVisualStyleBackColor = true;
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColumns.BackgroundColor = System.Drawing.Color.White;
            this.dgvColumns.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.EnableHeadersVisualStyles = false;
            this.dgvColumns.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvColumns.Location = new System.Drawing.Point(3, 3);
            this.dgvColumns.MultiSelect = false;
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.ReadOnly = true;
            this.dgvColumns.Size = new System.Drawing.Size(778, 233);
            this.dgvColumns.strZone = "";
            this.dgvColumns.TabIndex = 1;
            // 
            // frmZones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 569);
            this.Controls.Add(this.splitContainer);
            this.Name = "frmZones";
            this.Text = "Khai báo cột hiển thị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlZone)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tpColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private Epoint.Systems.Controls.tlControl tlZone;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tpColumns;
		private Epoint.Systems.Controls.dgvControl dgvColumns;




	}
}