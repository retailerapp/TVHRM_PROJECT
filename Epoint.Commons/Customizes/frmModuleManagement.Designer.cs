namespace Epoint.Systems.Customizes
{
	partial class frmModuleManagement
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuleManagement));
			this.lvOpeningModule = new System.Windows.Forms.ListView();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btHide = new Epoint.Systems.Controls.btControl();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// lvOpeningModule
			// 
			this.lvOpeningModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvOpeningModule.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.lvOpeningModule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lvOpeningModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvOpeningModule.FullRowSelect = true;
			this.lvOpeningModule.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvOpeningModule.Location = new System.Drawing.Point(0, 21);
			this.lvOpeningModule.Margin = new System.Windows.Forms.Padding(0);
			this.lvOpeningModule.Name = "lvOpeningModule";
			this.lvOpeningModule.Size = new System.Drawing.Size(237, 145);
			this.lvOpeningModule.SmallImageList = this.imageList1;
			this.lvOpeningModule.TabIndex = 1;
			this.lvOpeningModule.UseCompatibleStateImageBehavior = false;
			this.lvOpeningModule.View = System.Windows.Forms.View.Details;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(12, 4);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(113, 13);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Các phân hệ đang mở";
			// 
			// btHide
			// 
			this.btHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btHide.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.btHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.btHide.FlatAppearance.BorderSize = 0;
			this.btHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btHide.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btHide.ImageKey = "stop";
			this.btHide.ImageList = this.imageList1;
			this.btHide.Location = new System.Drawing.Point(208, 2);
			this.btHide.Margin = new System.Windows.Forms.Padding(0);
			this.btHide.Name = "btHide";
			this.btHide.Size = new System.Drawing.Size(20, 17);
			this.btHide.TabIndex = 2;
			this.btHide.TabStop = false;
			this.btHide.Tag = "";
			this.btHide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btHide.UseVisualStyleBackColor = true;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 224;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "OpeningModule");
			this.imageList1.Images.SetKeyName(1, "Stop");
			// 
			// frmModuleManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(237, 166);
			this.Controls.Add(this.lvOpeningModule);
			this.Controls.Add(this.btHide);
			this.Controls.Add(this.lblTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "frmModuleManagement";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmModuleManagement";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.ListView lvOpeningModule;
		private System.Windows.Forms.Label lblTitle;
		private Epoint.Systems.Controls.btControl btHide;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ImageList imageList1;

	}
}