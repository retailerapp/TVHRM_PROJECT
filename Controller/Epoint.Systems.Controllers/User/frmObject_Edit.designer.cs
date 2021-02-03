namespace Epoint.Controllers
{
	partial class frmObject_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObject_Edit));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.enuObject_Type = new Epoint.Systems.Controls.txtEnum();
            this.lblObject_Type = new Epoint.Systems.Controls.lblControl();
            this.lblObject_Name = new Epoint.Systems.Controls.lblControl();
            this.txtObject_Name = new Epoint.Systems.Controls.txtTextBox();
            this.lblColumn_ID = new Epoint.Systems.Controls.lblControl();
            this.txtObject_ID = new Epoint.Systems.Controls.txtTextBox();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(314, 118);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 33);
            this.btgAccept.TabIndex = 4;
            // 
            // enuObject_Type
            // 
            this.enuObject_Type.bEnabled = true;
            this.enuObject_Type.bIsLookup = false;
            this.enuObject_Type.bReadOnly = false;
            this.enuObject_Type.bRequire = false;
            this.enuObject_Type.InputMask = "MODULE,SYSTEM,DATA,EXEC,REPORT";
            this.enuObject_Type.KeyFilter = "";
            this.enuObject_Type.Location = new System.Drawing.Point(134, 68);
            this.enuObject_Type.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.enuObject_Type.Name = "enuObject_Type";
            this.enuObject_Type.Size = new System.Drawing.Size(80, 20);
            this.enuObject_Type.TabIndex = 2;
            this.enuObject_Type.UseAutoFilter = false;
            // 
            // lblObject_Type
            // 
            this.lblObject_Type.AutoEllipsis = true;
            this.lblObject_Type.AutoSize = true;
            this.lblObject_Type.BackColor = System.Drawing.Color.Transparent;
            this.lblObject_Type.Location = new System.Drawing.Point(33, 72);
            this.lblObject_Type.Name = "lblObject_Type";
            this.lblObject_Type.Size = new System.Drawing.Size(59, 13);
            this.lblObject_Type.TabIndex = 14;
            this.lblObject_Type.Tag = "Object_Type";
            this.lblObject_Type.Text = "Loại object";
            this.lblObject_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblObject_Name
            // 
            this.lblObject_Name.AutoEllipsis = true;
            this.lblObject_Name.AutoSize = true;
            this.lblObject_Name.BackColor = System.Drawing.Color.Transparent;
            this.lblObject_Name.Location = new System.Drawing.Point(33, 47);
            this.lblObject_Name.Name = "lblObject_Name";
            this.lblObject_Name.Size = new System.Drawing.Size(58, 13);
            this.lblObject_Name.TabIndex = 11;
            this.lblObject_Name.Tag = "Object_Name";
            this.lblObject_Name.Text = "Tên object";
            this.lblObject_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObject_Name
            // 
            this.txtObject_Name.bEnabled = true;
            this.txtObject_Name.bIsLookup = false;
            this.txtObject_Name.bReadOnly = false;
            this.txtObject_Name.bRequire = false;
            this.txtObject_Name.KeyFilter = "";
            this.txtObject_Name.Location = new System.Drawing.Point(134, 44);
            this.txtObject_Name.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtObject_Name.Name = "txtObject_Name";
            this.txtObject_Name.Size = new System.Drawing.Size(339, 20);
            this.txtObject_Name.TabIndex = 1;
            this.txtObject_Name.Tag = "";
            this.txtObject_Name.UseAutoFilter = false;
            // 
            // lblColumn_ID
            // 
            this.lblColumn_ID.AutoEllipsis = true;
            this.lblColumn_ID.AutoSize = true;
            this.lblColumn_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblColumn_ID.Location = new System.Drawing.Point(33, 22);
            this.lblColumn_ID.Name = "lblColumn_ID";
            this.lblColumn_ID.Size = new System.Drawing.Size(54, 13);
            this.lblColumn_ID.TabIndex = 10;
            this.lblColumn_ID.Tag = "Object_ID";
            this.lblColumn_ID.Text = "Mã object";
            this.lblColumn_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObject_ID
            // 
            this.txtObject_ID.bEnabled = true;
            this.txtObject_ID.bIsLookup = false;
            this.txtObject_ID.bReadOnly = false;
            this.txtObject_ID.bRequire = false;
            this.txtObject_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObject_ID.KeyFilter = "";
            this.txtObject_ID.Location = new System.Drawing.Point(134, 20);
            this.txtObject_ID.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtObject_ID.Name = "txtObject_ID";
            this.txtObject_ID.Size = new System.Drawing.Size(124, 20);
            this.txtObject_ID.TabIndex = 0;
            this.txtObject_ID.Tag = "";
            this.txtObject_ID.UseAutoFilter = false;
            // 
            // frmObject_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 172);
            this.Controls.Add(this.enuObject_Type);
            this.Controls.Add(this.lblObject_Type);
            this.Controls.Add(this.lblObject_Name);
            this.Controls.Add(this.txtObject_Name);
            this.Controls.Add(this.lblColumn_ID);
            this.Controls.Add(this.txtObject_ID);
            this.Controls.Add(this.btgAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmObject_Edit";
            this.Object_ID = "DMTYGIA";
            this.Tag = "frmDmTyGia_Edit";
            this.Text = "frmDmTyGia_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.txtEnum enuObject_Type;
		private Epoint.Systems.Controls.lblControl lblObject_Type;
		private Epoint.Systems.Controls.lblControl lblObject_Name;
		private Epoint.Systems.Controls.txtTextBox txtObject_Name;
		private Epoint.Systems.Controls.lblControl lblColumn_ID;
		private Epoint.Systems.Controls.txtTextBox txtObject_ID;

	}
}