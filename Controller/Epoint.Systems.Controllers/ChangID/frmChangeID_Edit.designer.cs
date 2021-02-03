namespace Epoint.Controllers
{
	partial class frmChangeID_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeID_Edit));
            this.txtTable_Name = new Epoint.Systems.Controls.txtTextBox();
            this.lblColumn_ID = new Epoint.Systems.Controls.lblControl();
            this.lblCaption_Default = new Epoint.Systems.Controls.lblControl();
            this.txtColumn_ID = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.txtColumn_Type = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtDescription = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.chkIs_Customize = new Epoint.Systems.Controls.chkControl();
            this.SuspendLayout();
            // 
            // txtTable_Name
            // 
            this.txtTable_Name.bEnabled = true;
            this.txtTable_Name.bIsLookup = false;
            this.txtTable_Name.bReadOnly = false;
            this.txtTable_Name.bRequire = false;
            this.txtTable_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTable_Name.KeyFilter = "";
            this.txtTable_Name.Location = new System.Drawing.Point(133, 67);
            this.txtTable_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTable_Name.Name = "txtTable_Name";
            this.txtTable_Name.Size = new System.Drawing.Size(124, 20);
            this.txtTable_Name.TabIndex = 2;
            this.txtTable_Name.UseAutoFilter = false;
            // 
            // lblColumn_ID
            // 
            this.lblColumn_ID.AutoEllipsis = true;
            this.lblColumn_ID.AutoSize = true;
            this.lblColumn_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblColumn_ID.Location = new System.Drawing.Point(32, 70);
            this.lblColumn_ID.Name = "lblColumn_ID";
            this.lblColumn_ID.Size = new System.Drawing.Size(87, 13);
            this.lblColumn_ID.TabIndex = 1;
            this.lblColumn_ID.Tag = "Table_Name";
            this.lblColumn_ID.Text = "Tên bảng dữ liệu";
            this.lblColumn_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCaption_Default
            // 
            this.lblCaption_Default.AutoEllipsis = true;
            this.lblCaption_Default.AutoSize = true;
            this.lblCaption_Default.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption_Default.Location = new System.Drawing.Point(32, 93);
            this.lblCaption_Default.Name = "lblCaption_Default";
            this.lblCaption_Default.Size = new System.Drawing.Size(95, 13);
            this.lblCaption_Default.TabIndex = 3;
            this.lblCaption_Default.Tag = "Column_ID";
            this.lblCaption_Default.Text = "Tên cột tương ứng";
            this.lblCaption_Default.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtColumn_ID
            // 
            this.txtColumn_ID.bEnabled = true;
            this.txtColumn_ID.bIsLookup = false;
            this.txtColumn_ID.bReadOnly = false;
            this.txtColumn_ID.bRequire = false;
            this.txtColumn_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColumn_ID.KeyFilter = "";
            this.txtColumn_ID.Location = new System.Drawing.Point(133, 90);
            this.txtColumn_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtColumn_ID.Name = "txtColumn_ID";
            this.txtColumn_ID.Size = new System.Drawing.Size(124, 20);
            this.txtColumn_ID.TabIndex = 3;
            this.txtColumn_ID.UseAutoFilter = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(32, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 16;
            this.label2.Tag = "Object_Type";
            this.label2.Text = "Loại mã";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtColumn_Type
            // 
            this.txtColumn_Type.bEnabled = true;
            this.txtColumn_Type.bIsLookup = false;
            this.txtColumn_Type.bReadOnly = false;
            this.txtColumn_Type.bRequire = false;
            this.txtColumn_Type.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColumn_Type.KeyFilter = "";
            this.txtColumn_Type.Location = new System.Drawing.Point(133, 21);
            this.txtColumn_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtColumn_Type.Name = "txtColumn_Type";
            this.txtColumn_Type.Size = new System.Drawing.Size(124, 20);
            this.txtColumn_Type.TabIndex = 0;
            this.txtColumn_Type.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(338, 131);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.bEnabled = true;
            this.txtDescription.bIsLookup = false;
            this.txtDescription.bReadOnly = false;
            this.txtDescription.bRequire = false;
            this.txtDescription.KeyFilter = "";
            this.txtDescription.Location = new System.Drawing.Point(133, 44);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(374, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(32, 47);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(48, 13);
            this.lblControl1.TabIndex = 3;
            this.lblControl1.Tag = "Description";
            this.lblControl1.Text = "Diễn giải";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIs_Customize
            // 
            this.chkIs_Customize.AutoSize = true;
            this.chkIs_Customize.Location = new System.Drawing.Point(133, 118);
            this.chkIs_Customize.Name = "chkIs_Customize";
            this.chkIs_Customize.Size = new System.Drawing.Size(122, 17);
            this.chkIs_Customize.TabIndex = 4;
            this.chkIs_Customize.Tag = "Data_Customize";
            this.chkIs_Customize.Text = "Là dữ liệu customize";
            this.chkIs_Customize.UseVisualStyleBackColor = true;
            // 
            // frmChangeID_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 178);
            this.Controls.Add(this.chkIs_Customize);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtColumn_Type);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblCaption_Default);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtColumn_ID);
            this.Controls.Add(this.lblColumn_ID);
            this.Controls.Add(this.txtTable_Name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangeID_Edit";
            this.Tag = "frmChangeID, ESC";
            this.Text = "frmChangeID";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtTable_Name;
		private Epoint.Systems.Controls.lblControl lblColumn_ID;
		private Epoint.Systems.Controls.lblControl lblCaption_Default;
		private Epoint.Systems.Controls.txtTextBox txtColumn_ID;
		private Epoint.Systems.Controls.lblControl label2;
		private Epoint.Systems.Controls.txtTextBox txtColumn_Type;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.txtTextBox txtDescription;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.chkControl chkIs_Customize;
	}
}