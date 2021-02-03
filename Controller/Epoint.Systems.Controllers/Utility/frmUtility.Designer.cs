namespace Epoint.Controllers
{
	partial class frmUtility
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
			this.lnkRemoteDesktop = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// lnkRemoteDesktop
			// 
			this.lnkRemoteDesktop.AutoSize = true;
			this.lnkRemoteDesktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lnkRemoteDesktop.Location = new System.Drawing.Point(43, 42);
			this.lnkRemoteDesktop.Name = "lnkRemoteDesktop";
			this.lnkRemoteDesktop.Size = new System.Drawing.Size(111, 15);
			this.lnkRemoteDesktop.TabIndex = 0;
			this.lnkRemoteDesktop.TabStop = true;
			this.lnkRemoteDesktop.Text = "Remote desktop";
			this.lnkRemoteDesktop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemoteDesktop_LinkClicked);
			// 
			// frmUtility
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 269);
			this.Controls.Add(this.lnkRemoteDesktop);
			this.Name = "frmUtility";
			this.Text = "frmUtility";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel lnkRemoteDesktop;
	}
}