namespace Epoint.Controllers
{
	partial class frmDmTable_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmTable_Edit));
            this.txtTable_Name = new Epoint.Systems.Controls.txtTextBox();
            this.lblColumn_ID = new Epoint.Systems.Controls.lblControl();
            this.lblDescription = new Epoint.Systems.Controls.lblControl();
            this.txtDescription = new Epoint.Systems.Controls.txtTextBox();
            this.lblTable_Type = new Epoint.Systems.Controls.lblControl();
            this.enuTable_Type = new Epoint.Systems.Controls.txtEnum();
            this.lbtColumn_Type = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtTable_Name0 = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.chkIs_Updating = new System.Windows.Forms.CheckBox();
            this.chkIs_Partition = new Epoint.Systems.Controls.chkControl();
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
            this.txtTable_Name.Location = new System.Drawing.Point(133, 19);
            this.txtTable_Name.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtTable_Name.Name = "txtTable_Name";
            this.txtTable_Name.Size = new System.Drawing.Size(124, 20);
            this.txtTable_Name.TabIndex = 0;
            this.txtTable_Name.Tag = "Table_Name";
            this.txtTable_Name.UseAutoFilter = false;
            // 
            // lblColumn_ID
            // 
            this.lblColumn_ID.AutoEllipsis = true;
            this.lblColumn_ID.AutoSize = true;
            this.lblColumn_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblColumn_ID.Location = new System.Drawing.Point(32, 21);
            this.lblColumn_ID.Name = "lblColumn_ID";
            this.lblColumn_ID.Size = new System.Drawing.Size(53, 13);
            this.lblColumn_ID.TabIndex = 1;
            this.lblColumn_ID.Tag = "Table_Name";
            this.lblColumn_ID.Text = "Tên bảng";
            this.lblColumn_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(32, 45);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(48, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Tag = "Description";
            this.lblDescription.Text = "Diễn giải";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.bEnabled = true;
            this.txtDescription.bIsLookup = false;
            this.txtDescription.bReadOnly = false;
            this.txtDescription.bRequire = false;
            this.txtDescription.KeyFilter = "";
            this.txtDescription.Location = new System.Drawing.Point(133, 42);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(339, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Tag = "Description";
            this.txtDescription.UseAutoFilter = false;
            // 
            // lblTable_Type
            // 
            this.lblTable_Type.AutoEllipsis = true;
            this.lblTable_Type.AutoSize = true;
            this.lblTable_Type.BackColor = System.Drawing.Color.Transparent;
            this.lblTable_Type.Location = new System.Drawing.Point(32, 92);
            this.lblTable_Type.Name = "lblTable_Type";
            this.lblTable_Type.Size = new System.Drawing.Size(54, 13);
            this.lblTable_Type.TabIndex = 7;
            this.lblTable_Type.Tag = "Table_Type";
            this.lblTable_Type.Text = "Loại bảng";
            this.lblTable_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuTable_Type
            // 
            this.enuTable_Type.bEnabled = true;
            this.enuTable_Type.bIsLookup = false;
            this.enuTable_Type.bReadOnly = false;
            this.enuTable_Type.bRequire = false;
            this.enuTable_Type.InputMask = "SYS,LIST,DATA";
            this.enuTable_Type.KeyFilter = "";
            this.enuTable_Type.Location = new System.Drawing.Point(133, 88);
            this.enuTable_Type.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.enuTable_Type.Name = "enuTable_Type";
            this.enuTable_Type.Size = new System.Drawing.Size(39, 20);
            this.enuTable_Type.TabIndex = 3;
            this.enuTable_Type.UseAutoFilter = false;
            // 
            // lbtColumn_Type
            // 
            this.lbtColumn_Type.AutoEllipsis = true;
            this.lbtColumn_Type.AutoSize = true;
            this.lbtColumn_Type.BackColor = System.Drawing.Color.Transparent;
            this.lbtColumn_Type.ForeColor = System.Drawing.Color.Blue;
            this.lbtColumn_Type.Location = new System.Drawing.Point(176, 92);
            this.lbtColumn_Type.Name = "lbtColumn_Type";
            this.lbtColumn_Type.Size = new System.Drawing.Size(245, 13);
            this.lbtColumn_Type.TabIndex = 4;
            this.lbtColumn_Type.Text = "SYS - Hệ thống, LIST - Danh mục, DATA - Dữ liệu";
            this.lbtColumn_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(304, 164);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 7;
            // 
            // txtTable_Name0
            // 
            this.txtTable_Name0.bEnabled = true;
            this.txtTable_Name0.bIsLookup = false;
            this.txtTable_Name0.bReadOnly = false;
            this.txtTable_Name0.bRequire = false;
            this.txtTable_Name0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTable_Name0.KeyFilter = "";
            this.txtTable_Name0.Location = new System.Drawing.Point(133, 65);
            this.txtTable_Name0.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtTable_Name0.Name = "txtTable_Name0";
            this.txtTable_Name0.Size = new System.Drawing.Size(124, 20);
            this.txtTable_Name0.TabIndex = 2;
            this.txtTable_Name0.Tag = "Table_Name0";
            this.txtTable_Name0.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(32, 68);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(63, 13);
            this.lblControl1.TabIndex = 1;
            this.lblControl1.Tag = "Table_Name0";
            this.lblControl1.Text = "Tên đầy đủ";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIs_Updating
            // 
            this.chkIs_Updating.AutoSize = true;
            this.chkIs_Updating.ForeColor = System.Drawing.Color.Blue;
            this.chkIs_Updating.Location = new System.Drawing.Point(133, 118);
            this.chkIs_Updating.Name = "chkIs_Updating";
            this.chkIs_Updating.Size = new System.Drawing.Size(159, 17);
            this.chkIs_Updating.TabIndex = 5;
            this.chkIs_Updating.Text = "Ngầm định là dữ liệu update";
            this.chkIs_Updating.UseVisualStyleBackColor = true;
            // 
            // chkIs_Partition
            // 
            this.chkIs_Partition.AutoSize = true;
            this.chkIs_Partition.ForeColor = System.Drawing.Color.Blue;
            this.chkIs_Partition.Location = new System.Drawing.Point(133, 136);
            this.chkIs_Partition.Name = "chkIs_Partition";
            this.chkIs_Partition.Size = new System.Drawing.Size(126, 17);
            this.chkIs_Partition.TabIndex = 6;
            this.chkIs_Partition.Tag = "";
            this.chkIs_Partition.Text = "Là dữ liệu phân vùng";
            this.chkIs_Partition.UseVisualStyleBackColor = true;
            // 
            // frmDmTable_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 216);
            this.Controls.Add(this.chkIs_Partition);
            this.Controls.Add(this.chkIs_Updating);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lbtColumn_Type);
            this.Controls.Add(this.enuTable_Type);
            this.Controls.Add(this.lblTable_Type);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lblColumn_ID);
            this.Controls.Add(this.txtTable_Name0);
            this.Controls.Add(this.txtTable_Name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmTable_Edit";
            this.Tag = "frmDmTable, ESC";
            this.Text = "frmDmTable";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtTable_Name;
		private Epoint.Systems.Controls.lblControl lblColumn_ID;
		private Epoint.Systems.Controls.lblControl lblDescription;
		private Epoint.Systems.Controls.txtTextBox txtDescription;
		private Epoint.Systems.Controls.lblControl lblTable_Type;
		private Epoint.Systems.Controls.txtEnum enuTable_Type;
		private Epoint.Systems.Controls.lblControl lbtColumn_Type;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.txtTextBox txtTable_Name0;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private System.Windows.Forms.CheckBox chkIs_Updating;
		private Epoint.Systems.Controls.chkControl chkIs_Partition;
	}
}