namespace Epoint.Modules
{
	partial class ucNotice
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblNotice = new Epoint.Systems.Controls.lblControl();
            this.lblRecord = new Epoint.Systems.Controls.lblControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNotice
            // 
            this.lblNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotice.AutoEllipsis = true;
            this.lblNotice.BackColor = System.Drawing.Color.Transparent;
            this.lblNotice.ForeColor = System.Drawing.Color.Blue;
            this.lblNotice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotice.Location = new System.Drawing.Point(29, 4);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(456, 23);
            this.lblNotice.TabIndex = 1;
            this.lblNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRecord
            // 
            this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecord.AutoEllipsis = true;
            this.lblRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblRecord.ForeColor = System.Drawing.Color.Blue;
            this.lblRecord.Location = new System.Drawing.Point(428, 4);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(57, 23);
            this.lblRecord.TabIndex = 2;
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRecord.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Epoint.Systems.Commons.Properties.Resources.Logfile;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ucNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.lblNotice);
            this.Name = "ucNotice";
            this.Size = new System.Drawing.Size(488, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		public Epoint.Systems.Controls.lblControl lblNotice;
		public Epoint.Systems.Controls.lblControl lblRecord;
		private System.Windows.Forms.PictureBox pictureBox1;

	}
}
