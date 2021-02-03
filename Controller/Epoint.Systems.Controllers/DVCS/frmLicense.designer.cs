namespace Epoint.Controllers
{
    partial class frmLicense
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
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.btSendPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(350, 113);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 33);
            this.btgAccept.TabIndex = 8;
            // 
            // btSendPath
            // 
            this.btSendPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSendPath.Location = new System.Drawing.Point(525, 35);
            this.btSendPath.Name = "btSendPath";
            this.btSendPath.Size = new System.Drawing.Size(24, 22);
            this.btSendPath.TabIndex = 11;
            this.btSendPath.Text = "...";
            this.btSendPath.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Đường dẫn";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFile.Location = new System.Drawing.Point(101, 37);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(420, 20);
            this.txtFile.TabIndex = 10;
            // 
            // frmLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 170);
            this.Controls.Add(this.btSendPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btgAccept);
            this.Name = "frmLicense";
            this.Tag = "frmDmDvCs, ESC";
            this.Text = "frmDmDvCs";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Customizes.btgAccept btgAccept;
        private System.Windows.Forms.Button btSendPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
	}
}