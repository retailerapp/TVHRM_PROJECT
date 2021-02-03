namespace Epoint.Systems.Customizes
{
	partial class frmChonNam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonNam));
            this.lvNam = new Epoint.Systems.Controls.lvControl();
            this.chkPartitionChange = new Epoint.Systems.Controls.chkControl();
            this.btAccept1 = new Epoint.Systems.Customizes.btAccept();
            this.SuspendLayout();
            // 
            // lvNam
            // 
            this.lvNam.DataSource = null;
            this.lvNam.FullRowSelect = true;
            this.lvNam.GridLines = true;
            this.lvNam.HideSelection = false;
            this.lvNam.Location = new System.Drawing.Point(7, 12);
            this.lvNam.MultiSelect = false;
            this.lvNam.Name = "lvNam";
            this.lvNam.Size = new System.Drawing.Size(348, 218);
            this.lvNam.strZone = "";
            this.lvNam.TabIndex = 0;
            this.lvNam.UseCompatibleStateImageBehavior = false;
            this.lvNam.View = System.Windows.Forms.View.Details;
            // 
            // chkPartitionChange
            // 
            this.chkPartitionChange.AutoSize = true;
            this.chkPartitionChange.Location = new System.Drawing.Point(12, 276);
            this.chkPartitionChange.Name = "chkPartitionChange";
            this.chkPartitionChange.Size = new System.Drawing.Size(123, 17);
            this.chkPartitionChange.TabIndex = 1;
            this.chkPartitionChange.Text = "&Chuyển vùng dữ liệu";
            this.chkPartitionChange.UseVisualStyleBackColor = true;
            this.chkPartitionChange.Visible = false;
            // 
            // btAccept1
            // 
            this.btAccept1.Image = global::Epoint.Systems.Commons.Properties.Resources.accepted1;
            this.btAccept1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAccept1.Location = new System.Drawing.Point(279, 234);
            this.btAccept1.Name = "btAccept1";
            this.btAccept1.Size = new System.Drawing.Size(77, 33);
            this.btAccept1.TabIndex = 2;
            this.btAccept1.Tag = "Accept";
            this.btAccept1.Text = "Đồng ý";
            this.btAccept1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAccept1.UseVisualStyleBackColor = true;
            // 
            // frmChonNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 269);
            this.Controls.Add(this.btAccept1);
            this.Controls.Add(this.chkPartitionChange);
            this.Controls.Add(this.lvNam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonNam";
            this.Tag = "WORKING_YEAR";
            this.Text = "frmChonNam";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.lvControl lvNam;
		private Epoint.Systems.Controls.chkControl chkPartitionChange;
		private btAccept btAccept1;
	}
}