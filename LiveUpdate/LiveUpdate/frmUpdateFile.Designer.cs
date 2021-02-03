namespace AutoMail
{
    partial class frmUpdateFile
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		
		

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateFile));
            this.btOk = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.picProgress = new System.Windows.Forms.PictureBox();
            this.lblNote = new Epoint.Systems.Controls.lblControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.Blue;
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(497, 224);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(76, 33);
            this.btOk.TabIndex = 4;
            this.btOk.Tag = "";
            this.btOk.Text = "Accept";
            this.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Blue;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(579, 224);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(76, 33);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "";
            this.btCancel.Text = "Cancel";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // picProgress
            // 
            this.picProgress.Image = ((System.Drawing.Image)(resources.GetObject("picProgress.Image")));
            this.picProgress.Location = new System.Drawing.Point(0, -1);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(662, 214);
            this.picProgress.TabIndex = 9;
            this.picProgress.TabStop = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoEllipsis = true;
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Location = new System.Drawing.Point(143, 74);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(406, 13);
            this.lblNote.TabIndex = 11;
            this.lblNote.Tag = "";
            this.lblNote.Text = "Click \'Accept\' to update the latest version. Click \'Cancel\' to stop the update pr" +
    "ocess !";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AutoMail";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // frmUpdateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(664, 266);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.picProgress);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmUpdateFile";
            this.Tag = "";
            this.Text = "Update Version";
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.btControl btOk;
        private Epoint.Systems.Controls.btControl btCancel;
        private System.Windows.Forms.PictureBox picProgress;
        private Epoint.Systems.Controls.lblControl lblNote;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	}
}