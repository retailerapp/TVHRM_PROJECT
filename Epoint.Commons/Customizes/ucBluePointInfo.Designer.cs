namespace Epoint.Systems.Customizes
{
	partial class ucBluePointInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBluePointInfo));
            this.lblTen_Dvi = new Epoint.Systems.Controls.lblControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkWebsite = new System.Windows.Forms.LinkLabel();
            this.linkEmail = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTen_Dvi
            // 
            this.lblTen_Dvi.AutoEllipsis = true;
            this.lblTen_Dvi.AutoSize = true;
            this.lblTen_Dvi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen_Dvi.ForeColor = System.Drawing.Color.Blue;
            this.lblTen_Dvi.Location = new System.Drawing.Point(134, 11);
            this.lblTen_Dvi.Name = "lblTen_Dvi";
            this.lblTen_Dvi.Size = new System.Drawing.Size(170, 13);
            this.lblTen_Dvi.TabIndex = 1;
            this.lblTen_Dvi.Text = "Phần mềm kế toán BluePoint";
            this.lblTen_Dvi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // linkWebsite
            // 
            this.linkWebsite.AutoSize = true;
            this.linkWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkWebsite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkWebsite.LinkVisited = true;
            this.linkWebsite.Location = new System.Drawing.Point(137, 33);
            this.linkWebsite.Name = "linkWebsite";
            this.linkWebsite.Size = new System.Drawing.Size(0, 13);
            this.linkWebsite.TabIndex = 3;
            this.linkWebsite.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // linkEmail
            // 
            this.linkEmail.AutoSize = true;
            this.linkEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEmail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkEmail.LinkVisited = true;
            this.linkEmail.Location = new System.Drawing.Point(137, 49);
            this.linkEmail.Name = "linkEmail";
            this.linkEmail.Size = new System.Drawing.Size(0, 13);
            this.linkEmail.TabIndex = 3;
            this.linkEmail.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // ucBluePointInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.linkEmail);
            this.Controls.Add(this.linkWebsite);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTen_Dvi);
            this.Name = "ucBluePointInfo";
            this.Size = new System.Drawing.Size(325, 89);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.lblControl lblTen_Dvi;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel linkWebsite;
		private System.Windows.Forms.LinkLabel linkEmail;
	}
}
