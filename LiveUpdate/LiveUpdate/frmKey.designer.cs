namespace AutoMail
{
	partial class frmKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKey));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblLogin_Name = new Epoint.Systems.Controls.lblControl();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(417, 308);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "\nThêm mới: F2\n\nSửa: F3\n\nXóa: F8\n\nXem trước khi in: Ctrl + F7 \n\nIn: F7\n\nGộp mã: F6" +
    "\n\nThanh toán: F10\n\nKết chuyển số dư cuối kỳ: F11\n\nMáy tính: F5\n\nLọc chứng từ: F9" +
    "\n\n\n\n\n";
            // 
            // lblLogin_Name
            // 
            this.lblLogin_Name.AutoEllipsis = true;
            this.lblLogin_Name.AutoSize = true;
            this.lblLogin_Name.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin_Name.ForeColor = System.Drawing.Color.Navy;
            this.lblLogin_Name.Location = new System.Drawing.Point(168, 9);
            this.lblLogin_Name.Name = "lblLogin_Name";
            this.lblLogin_Name.Size = new System.Drawing.Size(143, 17);
            this.lblLogin_Name.TabIndex = 4;
            this.lblLogin_Name.Tag = "Login_Name";
            this.lblLogin_Name.Text = "Danh mục phím tắt";
            this.lblLogin_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(113, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // frmKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(441, 364);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblLogin_Name);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimizeBox = false;
            this.Name = "frmKey";
            this.ShowInTaskbar = true;
            this.Tag = "Key_Shortcut";
            this.Text = "Phím tắt";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private Epoint.Systems.Controls.lblControl lblLogin_Name;
        private System.Windows.Forms.PictureBox pictureBox3;

    }
}