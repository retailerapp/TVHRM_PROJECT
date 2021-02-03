namespace Epoint.Controllers
{
	partial class frmZones_Live_Edit
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvColumns = new Epoint.Systems.Controls.dgvControl();
			((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvColumns
			// 
			this.dgvColumns.AllowUserToAddRows = false;
			this.dgvColumns.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
			this.dgvColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			
			this.dgvColumns.BackgroundColor = System.Drawing.Color.White;
			this.dgvColumns.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvColumns.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvColumns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvColumns.EnableHeadersVisualStyles = false;
			this.dgvColumns.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(225)))));
			this.dgvColumns.Location = new System.Drawing.Point(0, 0);
			this.dgvColumns.MultiSelect = false;
			this.dgvColumns.Name = "dgvColumns";
			this.dgvColumns.ReadOnly = true;
			this.dgvColumns.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvColumns.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvColumns.Size = new System.Drawing.Size(792, 569);
			this.dgvColumns.strZone = "";
			this.dgvColumns.TabIndex = 1;
			// 
			// frmZones_Live_Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 569);
			this.Controls.Add(this.dgvColumns);
			this.Name = "frmZones_Live_Edit";
			this.Text = "Tu dien cot du lieu";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		
		private Epoint.Systems.Controls.dgvControl dgvColumns;




	}
}