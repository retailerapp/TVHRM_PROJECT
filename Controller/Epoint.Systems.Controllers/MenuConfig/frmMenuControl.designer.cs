namespace Epoint.Controllers
{
    partial class frmMenuControl
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
			this.tactrlModMenu = new Epoint.Systems.Controls.tabControl();
			this.tapgModule = new System.Windows.Forms.TabPage();
			this.tapgMenu = new System.Windows.Forms.TabPage();

			this.tactrlModMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tactrlModMenu
			// 
			this.tactrlModMenu.Controls.Add(this.tapgModule);
			this.tactrlModMenu.Controls.Add(this.tapgMenu);
			this.tactrlModMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tactrlModMenu.Location = new System.Drawing.Point(0, 0);
			this.tactrlModMenu.Name = "tactrlModMenu";
			this.tactrlModMenu.SelectedIndex = 0;
			this.tactrlModMenu.Size = new System.Drawing.Size(792, 569);
			this.tactrlModMenu.TabIndex = 0;
			this.tactrlModMenu.Tag = "Menu_Control";
			// 
			// tapgModule
			// 
			this.tapgModule.Location = new System.Drawing.Point(4, 22);
			this.tapgModule.Name = "tapgModule";
			this.tapgModule.Padding = new System.Windows.Forms.Padding(3);
			this.tapgModule.Size = new System.Drawing.Size(784, 543);
			this.tapgModule.TabIndex = 0;
			this.tapgModule.Tag = "Module_Control";
			this.tapgModule.Text = "Điều khiển Module";
			this.tapgModule.UseVisualStyleBackColor = true;
			// 
			// tapgMenu
			// 
			this.tapgMenu.Location = new System.Drawing.Point(4, 22);
			this.tapgMenu.Name = "tapgMenu";
			this.tapgMenu.Padding = new System.Windows.Forms.Padding(3);
			this.tapgMenu.Size = new System.Drawing.Size(784, 543);
			this.tapgMenu.TabIndex = 1;
			this.tapgMenu.Tag = "Menu_Control";
			this.tapgMenu.Text = "Điều khiển Menu";
			this.tapgMenu.UseVisualStyleBackColor = true;
			// 
			// frmMenuControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 569);
			this.Controls.Add(this.tactrlModMenu);
			this.Name = "frmMenuControl";
			this.Text = "frmMenuControl";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMenuControl_KeyDown);

			this.tactrlModMenu.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private Epoint.Systems.Controls.tabControl tactrlModMenu;
        private System.Windows.Forms.TabPage tapgModule;
		private System.Windows.Forms.TabPage tapgMenu;
		private Epoint.Systems.Controls.tlControl tlMenu;
    }
}