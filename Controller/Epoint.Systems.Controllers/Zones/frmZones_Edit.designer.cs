namespace Epoint.Controllers
{
	partial class frmZones_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZones_Edit));
            this.label1 = new Epoint.Systems.Controls.lblControl();
            this.txtZone_Parent = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.txtZone = new Epoint.Systems.Controls.txtTextBox();
            this.chkSortable = new Epoint.Systems.Controls.chkControl();
            this.label3 = new Epoint.Systems.Controls.lblControl();
            this.txtDescription = new Epoint.Systems.Controls.txtTextBox();
            this.numResize_Rate = new Epoint.Systems.Controls.numControl();
            this.label4 = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.chkExpand = new Epoint.Systems.Controls.chkControl();
            this.chkIs_Customize = new Epoint.Systems.Controls.chkControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 12;
            this.label1.Tag = "Zone_Parent";
            this.label1.Text = "Phân nhóm vùng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtZone_Parent
            // 
            this.txtZone_Parent.bEnabled = true;
            this.txtZone_Parent.bIsLookup = false;
            this.txtZone_Parent.bReadOnly = false;
            this.txtZone_Parent.bRequire = false;
            this.txtZone_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZone_Parent.KeyFilter = "";
            this.txtZone_Parent.Location = new System.Drawing.Point(140, 67);
            this.txtZone_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtZone_Parent.Name = "txtZone_Parent";
            this.txtZone_Parent.Size = new System.Drawing.Size(124, 20);
            this.txtZone_Parent.TabIndex = 2;
            this.txtZone_Parent.UseAutoFilter = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(21, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 16;
            this.label2.Tag = "Zone";
            this.label2.Text = "Vùng hiển thị";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtZone
            // 
            this.txtZone.bEnabled = true;
            this.txtZone.bIsLookup = false;
            this.txtZone.bReadOnly = false;
            this.txtZone.bRequire = false;
            this.txtZone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZone.KeyFilter = "";
            this.txtZone.Location = new System.Drawing.Point(140, 21);
            this.txtZone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtZone.Name = "txtZone";
            this.txtZone.Size = new System.Drawing.Size(124, 20);
            this.txtZone.TabIndex = 0;
            this.txtZone.UseAutoFilter = false;
            // 
            // chkSortable
            // 
            this.chkSortable.AutoSize = true;
            this.chkSortable.Checked = true;
            this.chkSortable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSortable.Location = new System.Drawing.Point(140, 117);
            this.chkSortable.Name = "chkSortable";
            this.chkSortable.Size = new System.Drawing.Size(245, 17);
            this.chkSortable.TabIndex = 4;
            this.chkSortable.Tag = "Sortable";
            this.chkSortable.Text = "Cho phép sắp xếp lại dữ liệu trên lưới (sortable)";
            this.chkSortable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(21, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 20;
            this.label3.Tag = "Description";
            this.label3.Text = "Diễn giải";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.bEnabled = true;
            this.txtDescription.bIsLookup = false;
            this.txtDescription.bReadOnly = false;
            this.txtDescription.bRequire = false;
            this.txtDescription.KeyFilter = "";
            this.txtDescription.Location = new System.Drawing.Point(140, 44);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(378, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.UseAutoFilter = false;
            // 
            // numResize_Rate
            // 
            this.numResize_Rate.bEnabled = true;
            this.numResize_Rate.bFormat = true;
            this.numResize_Rate.bIsLookup = false;
            this.numResize_Rate.bReadOnly = false;
            this.numResize_Rate.bRequire = false;
            this.numResize_Rate.KeyFilter = "";
            this.numResize_Rate.Location = new System.Drawing.Point(140, 90);
            this.numResize_Rate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numResize_Rate.Name = "numResize_Rate";
            this.numResize_Rate.Scale = 0;
            this.numResize_Rate.Size = new System.Drawing.Size(52, 20);
            this.numResize_Rate.TabIndex = 3;
            this.numResize_Rate.Text = "0";
            this.numResize_Rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numResize_Rate.UseAutoFilter = false;
            this.numResize_Rate.Value = 0D;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(21, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 22;
            this.label4.Tag = "Resize_Rate";
            this.label4.Text = "Tỷ lệ resize cột";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(349, 190);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 7;
            // 
            // chkExpand
            // 
            this.chkExpand.AutoSize = true;
            this.chkExpand.Checked = true;
            this.chkExpand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExpand.Location = new System.Drawing.Point(140, 136);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Size = new System.Drawing.Size(62, 17);
            this.chkExpand.TabIndex = 5;
            this.chkExpand.Tag = "Expand";
            this.chkExpand.Text = "Expand";
            this.chkExpand.UseVisualStyleBackColor = true;
            // 
            // chkIs_Customize
            // 
            this.chkIs_Customize.AutoSize = true;
            this.chkIs_Customize.Location = new System.Drawing.Point(140, 155);
            this.chkIs_Customize.Name = "chkIs_Customize";
            this.chkIs_Customize.Size = new System.Drawing.Size(122, 17);
            this.chkIs_Customize.TabIndex = 6;
            this.chkIs_Customize.Tag = "DATA_CUSTOMIZE";
            this.chkIs_Customize.Text = "Là dữ liệu customize";
            this.chkIs_Customize.UseVisualStyleBackColor = true;
            // 
            // frmZones_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 236);
            this.Controls.Add(this.chkIs_Customize);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numResize_Rate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.chkExpand);
            this.Controls.Add(this.chkSortable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtZone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtZone_Parent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmZones_Edit";
            this.Tag = "FRMCOLUMNS";
            this.Text = "Khai báo cột hiển thị";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.lblControl label1;
		private Epoint.Systems.Controls.txtTextBox txtZone_Parent;
		private Epoint.Systems.Controls.lblControl label2;
		private Epoint.Systems.Controls.txtTextBox txtZone;
		private Epoint.Systems.Controls.chkControl chkSortable;
		private Epoint.Systems.Controls.lblControl label3;
		private Epoint.Systems.Controls.txtTextBox txtDescription;
		private Epoint.Systems.Controls.numControl numResize_Rate;
		private Epoint.Systems.Controls.lblControl label4;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.chkControl chkExpand;
		private Epoint.Systems.Controls.chkControl chkIs_Customize;
	}
}