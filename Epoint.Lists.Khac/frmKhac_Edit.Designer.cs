namespace Epoint.Lists
{
	partial class frmKhac_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhac_Edit));
            this.txtType_Name = new Epoint.Systems.Controls.txtTextBox();
            this.txtType_ID = new Epoint.Systems.Controls.txtTextBox();
            this.lblType_Name = new Epoint.Systems.Controls.lblControl();
            this.lblType_ID = new Epoint.Systems.Controls.lblControl();
            this.lblType = new Epoint.Systems.Controls.lblControl();
            this.txtType = new Epoint.Systems.Controls.txtTextBox();
            this.grTitle1 = new System.Windows.Forms.GroupBox();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.grTitle1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(335, 186);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(505, 167);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.grTitle1);
            this.Page1.Size = new System.Drawing.Size(497, 141);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(497, 141);
            // 
            // txtType_Name
            // 
            this.txtType_Name.bEnabled = true;
            this.txtType_Name.bIsLookup = false;
            this.txtType_Name.bReadOnly = false;
            this.txtType_Name.bRequire = false;
            this.txtType_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType_Name.KeyFilter = "";
            this.txtType_Name.Location = new System.Drawing.Point(103, 76);
            this.txtType_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtType_Name.MaxLength = 100;
            this.txtType_Name.Name = "txtType_Name";
            this.txtType_Name.Size = new System.Drawing.Size(335, 20);
            this.txtType_Name.TabIndex = 2;
            this.txtType_Name.UseAutoFilter = false;
            // 
            // txtType_ID
            // 
            this.txtType_ID.bEnabled = true;
            this.txtType_ID.bIsLookup = false;
            this.txtType_ID.bReadOnly = false;
            this.txtType_ID.bRequire = false;
            this.txtType_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType_ID.KeyFilter = "";
            this.txtType_ID.Location = new System.Drawing.Point(103, 52);
            this.txtType_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtType_ID.MaxLength = 20;
            this.txtType_ID.Name = "txtType_ID";
            this.txtType_ID.Size = new System.Drawing.Size(120, 20);
            this.txtType_ID.TabIndex = 1;
            this.txtType_ID.UseAutoFilter = false;
            // 
            // lblType_Name
            // 
            this.lblType_Name.AutoEllipsis = true;
            this.lblType_Name.AutoSize = true;
            this.lblType_Name.BackColor = System.Drawing.Color.Transparent;
            this.lblType_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType_Name.Location = new System.Drawing.Point(15, 80);
            this.lblType_Name.Name = "lblType_Name";
            this.lblType_Name.Size = new System.Drawing.Size(26, 13);
            this.lblType_Name.TabIndex = 19;
            this.lblType_Name.Tag = "Type_Name";
            this.lblType_Name.Text = "Tên";
            this.lblType_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblType_ID
            // 
            this.lblType_ID.AutoEllipsis = true;
            this.lblType_ID.AutoSize = true;
            this.lblType_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblType_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType_ID.Location = new System.Drawing.Point(15, 55);
            this.lblType_ID.Name = "lblType_ID";
            this.lblType_ID.Size = new System.Drawing.Size(22, 13);
            this.lblType_ID.TabIndex = 20;
            this.lblType_ID.Tag = "Type_ID";
            this.lblType_ID.Text = "Mã";
            this.lblType_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblType
            // 
            this.lblType.AutoEllipsis = true;
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(15, 31);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(77, 13);
            this.lblType.TabIndex = 20;
            this.lblType.Tag = "TYPE_LIST";
            this.lblType.Text = "Loại danh mục";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtType
            // 
            this.txtType.bEnabled = true;
            this.txtType.bIsLookup = false;
            this.txtType.bReadOnly = false;
            this.txtType.bRequire = false;
            this.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType.KeyFilter = "";
            this.txtType.Location = new System.Drawing.Point(103, 28);
            this.txtType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtType.MaxLength = 20;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(120, 20);
            this.txtType.TabIndex = 0;
            this.txtType.UseAutoFilter = false;
            // 
            // grTitle1
            // 
            this.grTitle1.Controls.Add(this.txtType_Name);
            this.grTitle1.Controls.Add(this.lblType_ID);
            this.grTitle1.Controls.Add(this.txtType);
            this.grTitle1.Controls.Add(this.lblType);
            this.grTitle1.Controls.Add(this.txtType_ID);
            this.grTitle1.Controls.Add(this.lblType_Name);
            this.grTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTitle1.Location = new System.Drawing.Point(18, 11);
            this.grTitle1.Name = "grTitle1";
            this.grTitle1.Size = new System.Drawing.Size(462, 116);
            this.grTitle1.TabIndex = 21;
            this.grTitle1.TabStop = false;
            this.grTitle1.Tag = "Other_List";
            this.grTitle1.Text = "Khác";
            // 
            // frmKhac_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 229);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKhac_Edit";
            this.Object_ID = "LIKHAC";
            this.Tag = "ESC";
            this.Text = "frmKhac";
            this.tabEdit.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            this.grTitle1.ResumeLayout(false);
            this.grTitle1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtType_Name;
		private Epoint.Systems.Controls.txtTextBox txtType_ID;
		private Epoint.Systems.Controls.lblControl lblType_Name;
		private Epoint.Systems.Controls.lblControl lblType_ID;
		private Epoint.Systems.Controls.lblControl lblType;
		public Epoint.Systems.Controls.txtTextBox txtType;
        private System.Windows.Forms.GroupBox grTitle1;

	}
}