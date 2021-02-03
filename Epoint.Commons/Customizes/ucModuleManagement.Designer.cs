namespace Epoint.Systems.Customizes
{
	partial class UcModuleManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcModuleManagement));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btHide = new Epoint.Systems.Controls.btControl();
            this.lvReminder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "down");
            this.imageList1.Images.SetKeyName(1, "up");
            this.imageList1.Images.SetKeyName(2, "OpeningModule");
            this.imageList1.Images.SetKeyName(3, "Write");
            this.imageList1.Images.SetKeyName(4, "cross");
            this.imageList1.Images.SetKeyName(5, "stop");
            this.imageList1.Images.SetKeyName(6, "play");
            this.imageList1.Images.SetKeyName(7, "Bullet");
            this.imageList1.Images.SetKeyName(8, "Nhac_Viec.png");
            this.imageList1.Images.SetKeyName(9, "Nhac_Viec1.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btHide);
            this.panel1.Controls.Add(this.lvReminder);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 151);
            this.panel1.TabIndex = 9;
            // 
            // btHide
            // 
            this.btHide.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btHide.FlatAppearance.BorderSize = 0;
            this.btHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHide.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btHide.ImageKey = "stop";
            this.btHide.ImageList = this.imageList1;
            this.btHide.Location = new System.Drawing.Point(3, 3);
            this.btHide.Margin = new System.Windows.Forms.Padding(0);
            this.btHide.Name = "btHide";
            this.btHide.Size = new System.Drawing.Size(20, 17);
            this.btHide.TabIndex = 9;
            this.btHide.TabStop = false;
            this.btHide.Tag = "";
            this.btHide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHide.UseVisualStyleBackColor = true;
            // 
            // lvReminder
            // 
            this.lvReminder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvReminder.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lvReminder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvReminder.FullRowSelect = true;
            this.lvReminder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvReminder.Location = new System.Drawing.Point(0, 22);
            this.lvReminder.Margin = new System.Windows.Forms.Padding(0);
            this.lvReminder.Name = "lvReminder";
            this.lvReminder.Size = new System.Drawing.Size(236, 129);
            this.lvReminder.SmallImageList = this.imageList1;
            this.lvReminder.TabIndex = 11;
            this.lvReminder.UseCompatibleStateImageBehavior = false;
            this.lvReminder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nhắc việc";
            this.columnHeader1.Width = 205;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(26, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(77, 16);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Tag = "Reminder";
            this.lblTitle.Text = "Nhắc việc";
            // 
            // UcModuleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.Controls.Add(this.panel1);
            this.Name = "UcModuleManagement";
            this.Size = new System.Drawing.Size(236, 151);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTitle;
		public Epoint.Systems.Controls.btControl btHide;
		public System.Windows.Forms.ListView lvReminder;
		public System.Windows.Forms.ColumnHeader columnHeader1;
	}
}
