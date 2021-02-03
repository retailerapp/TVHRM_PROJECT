namespace Epoint.Controllers
{
    partial class frmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroup));
            this.tvGroup = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvUser = new Epoint.Systems.Controls.lvControl();
            this.SuspendLayout();
            // 
            // tvGroup
            // 
            this.tvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvGroup.FullRowSelect = true;
            this.tvGroup.HideSelection = false;
            this.tvGroup.ImageIndex = 0;
            this.tvGroup.ImageList = this.imageList1;
            this.tvGroup.Location = new System.Drawing.Point(3, 3);
            this.tvGroup.Name = "tvGroup";
            this.tvGroup.SelectedImageIndex = 0;
            this.tvGroup.Size = new System.Drawing.Size(226, 563);
            this.tvGroup.TabIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Group");
            this.imageList1.Images.SetKeyName(1, "User");
            // 
            // lvUser
            // 
            this.lvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUser.DataSource = null;
            this.lvUser.FullRowSelect = true;
            this.lvUser.GridLines = true;
            this.lvUser.HideSelection = false;
            this.lvUser.Location = new System.Drawing.Point(232, 3);
            this.lvUser.MultiSelect = false;
            this.lvUser.Name = "lvUser";
            this.lvUser.Size = new System.Drawing.Size(557, 563);
            this.lvUser.SmallImageList = this.imageList1;
            this.lvUser.strZone = "";
            this.lvUser.TabIndex = 4;
            this.lvUser.UseCompatibleStateImageBehavior = false;
            this.lvUser.View = System.Windows.Forms.View.Details;
            // 
            // frmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 569);
            this.Controls.Add(this.lvUser);
            this.Controls.Add(this.tvGroup);
            this.Name = "frmGroup";
            this.Text = "frmGroup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.TreeView tvGroup;
		private Epoint.Systems.Controls.lvControl lvUser;
		private System.Windows.Forms.ImageList imageList1;
    }
}