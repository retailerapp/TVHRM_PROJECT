namespace Epoint.Modules.KPI
{
	partial class frmKPIType_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKPIType_Edit));
            this.txtDescr = new Epoint.Systems.Controls.txtTextBox();
            this.txtTypeID = new Epoint.Systems.Controls.txtTextBox();
            this.lblType_Name = new Epoint.Systems.Controls.lblControl();
            this.lblType_ID = new Epoint.Systems.Controls.lblControl();
            this.grTitle1 = new System.Windows.Forms.GroupBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.tabEdit.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.grTitle1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Location = new System.Drawing.Point(335, 235);
            this.btgAccept.TabIndex = 1;
            // 
            // tabEdit
            // 
            this.tabEdit.Size = new System.Drawing.Size(505, 216);
            this.tabEdit.TabIndex = 0;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.grTitle1);
            this.Page1.Size = new System.Drawing.Size(497, 190);
            // 
            // Page2
            // 
            this.Page2.Size = new System.Drawing.Size(497, 141);
            // 
            // txtDescr
            // 
            this.txtDescr.bEnabled = true;
            this.txtDescr.bIsLookup = false;
            this.txtDescr.bReadOnly = false;
            this.txtDescr.bRequire = false;
            this.txtDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescr.KeyFilter = "";
            this.txtDescr.Location = new System.Drawing.Point(101, 51);
            this.txtDescr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDescr.MaxLength = 100;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(335, 20);
            this.txtDescr.TabIndex = 2;
            this.txtDescr.UseAutoFilter = false;
            // 
            // txtTypeID
            // 
            this.txtTypeID.bEnabled = true;
            this.txtTypeID.bIsLookup = false;
            this.txtTypeID.bReadOnly = false;
            this.txtTypeID.bRequire = false;
            this.txtTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeID.KeyFilter = "";
            this.txtTypeID.Location = new System.Drawing.Point(101, 27);
            this.txtTypeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTypeID.MaxLength = 20;
            this.txtTypeID.Name = "txtTypeID";
            this.txtTypeID.Size = new System.Drawing.Size(120, 20);
            this.txtTypeID.TabIndex = 1;
            this.txtTypeID.UseAutoFilter = false;
            // 
            // lblType_Name
            // 
            this.lblType_Name.AutoEllipsis = true;
            this.lblType_Name.AutoSize = true;
            this.lblType_Name.BackColor = System.Drawing.Color.Transparent;
            this.lblType_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType_Name.Location = new System.Drawing.Point(13, 55);
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
            this.lblType_ID.Location = new System.Drawing.Point(13, 30);
            this.lblType_ID.Name = "lblType_ID";
            this.lblType_ID.Size = new System.Drawing.Size(22, 13);
            this.lblType_ID.TabIndex = 20;
            this.lblType_ID.Tag = "Type_ID";
            this.lblType_ID.Text = "Mã";
            this.lblType_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grTitle1
            // 
            this.grTitle1.Controls.Add(this.numStt);
            this.grTitle1.Controls.Add(this.txtDescr);
            this.grTitle1.Controls.Add(this.lblType_ID);
            this.grTitle1.Controls.Add(this.txtTypeID);
            this.grTitle1.Controls.Add(this.lblControl1);
            this.grTitle1.Controls.Add(this.lblType_Name);
            this.grTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTitle1.Location = new System.Drawing.Point(18, 11);
            this.grTitle1.Name = "grTitle1";
            this.grTitle1.Size = new System.Drawing.Size(462, 173);
            this.grTitle1.TabIndex = 21;
            this.grTitle1.TabStop = false;
            this.grTitle1.Tag = "Other_List";
            this.grTitle1.Text = "Khác";
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.Location = new System.Drawing.Point(13, 84);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(20, 13);
            this.lblControl1.TabIndex = 19;
            this.lblControl1.Tag = "Stt";
            this.lblControl1.Text = "Stt";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numStt
            // 
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(101, 77);
            this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt.MaxLength = 20;
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(50, 20);
            this.numStt.TabIndex = 21;
            this.numStt.Text = "0";
            this.numStt.UseAutoFilter = false;
            this.numStt.Value = 0D;
            // 
            // frmKPIType_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 278);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKPIType_Edit";
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

		private Epoint.Systems.Controls.txtTextBox txtDescr;
		private Epoint.Systems.Controls.txtTextBox txtTypeID;
		private Epoint.Systems.Controls.lblControl lblType_Name;
		private Epoint.Systems.Controls.lblControl lblType_ID;
        private System.Windows.Forms.GroupBox grTitle1;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.numControl numStt;
    }
}