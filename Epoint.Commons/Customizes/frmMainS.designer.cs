namespace Epoint.Systems.Customizes
{
    partial class frmMainS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainS));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.pnlScreen = new System.Windows.Forms.Panel();
            this.pnlCenter = new Epoint.Systems.Customizes.pnlCenter();
            this.pnlLeftScreen = new Epoint.Systems.Customizes.pnlLeftScreen();
            this.toolStripContainer.SuspendLayout();
            this.pnlScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.AllowDrop = true;
            this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripContainer.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(792, 25);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            this.toolStripContainer.Size = new System.Drawing.Size(792, 50);
            this.toolStripContainer.TabIndex = 10;
            this.toolStripContainer.TabStop = false;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // pnlScreen
            // 
            this.pnlScreen.BackColor = System.Drawing.SystemColors.Window;
            this.pnlScreen.Controls.Add(this.pnlCenter);
            this.pnlScreen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlScreen.Location = new System.Drawing.Point(0, 56);
            this.pnlScreen.Name = "pnlScreen";
            this.pnlScreen.Size = new System.Drawing.Size(792, 510);
            this.pnlScreen.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlCenter.BackgroundImage")));
            this.pnlCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(792, 510);
            this.pnlCenter.TabIndex = 0;
            // 
            // pnlLeftScreen
            // 
            this.pnlLeftScreen.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftScreen.Name = "pnlLeftScreen";
            this.pnlLeftScreen.Size = new System.Drawing.Size(200, 100);
            this.pnlLeftScreen.TabIndex = 0;
            // 
            // frmMainS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.pnlScreen);
            this.Controls.Add(this.toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainS";
            this.Text = "frmMain";
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.pnlScreen.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ToolStripContainer toolStripContainer;
		public System.Windows.Forms.Panel pnlScreen;
        public Epoint.Systems.Customizes.pnlLeftScreen pnlLeftScreen;
        public pnlCenter pnlCenter;
	}
}