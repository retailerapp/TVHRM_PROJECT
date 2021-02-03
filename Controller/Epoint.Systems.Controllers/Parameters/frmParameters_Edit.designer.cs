namespace Epoint.Controllers
{
	partial class frmParameters_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParameters_Edit));
            this.txtParameter_ID = new Epoint.Systems.Controls.txtTextBox();
            this.lblParameter_ID = new Epoint.Systems.Controls.lblControl();
            this.lblParameter_Value = new Epoint.Systems.Controls.lblControl();
            this.txtParameter_Value = new Epoint.Systems.Controls.txtTextBox();
            this.lblParameter_Desc = new Epoint.Systems.Controls.lblControl();
            this.txtParameter_Desc = new Epoint.Systems.Controls.txtTextBox();
            this.lblParameter_Type = new Epoint.Systems.Controls.lblControl();
            this.lblModule_Id = new Epoint.Systems.Controls.lblControl();
            this.chkVisible = new Epoint.Systems.Controls.chkControl();
            this.txtParameter_Type = new Epoint.Systems.Controls.txtEnum();
            this.numModule_Id = new Epoint.Systems.Controls.numControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblParameter_Id_Parent = new Epoint.Systems.Controls.lblControl();
            this.txtParameter_Id_Parent = new Epoint.Systems.Controls.txtTextBox();
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // txtParameter_ID
            // 
            this.txtParameter_ID.bEnabled = true;
            this.txtParameter_ID.bIsLookup = false;
            this.txtParameter_ID.bReadOnly = false;
            this.txtParameter_ID.bRequire = false;
            this.txtParameter_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParameter_ID.KeyFilter = "";
            this.txtParameter_ID.Location = new System.Drawing.Point(127, 47);
            this.txtParameter_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtParameter_ID.Name = "txtParameter_ID";
            this.txtParameter_ID.Size = new System.Drawing.Size(138, 20);
            this.txtParameter_ID.TabIndex = 1;
            this.txtParameter_ID.UseAutoFilter = false;
            // 
            // lblParameter_ID
            // 
            this.lblParameter_ID.AutoEllipsis = true;
            this.lblParameter_ID.AutoSize = true;
            this.lblParameter_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblParameter_ID.Location = new System.Drawing.Point(28, 50);
            this.lblParameter_ID.Name = "lblParameter_ID";
            this.lblParameter_ID.Size = new System.Drawing.Size(62, 13);
            this.lblParameter_ID.TabIndex = 2;
            this.lblParameter_ID.Tag = "Parameter_ID";
            this.lblParameter_ID.Text = "Mã tham số";
            this.lblParameter_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblParameter_Value
            // 
            this.lblParameter_Value.AutoEllipsis = true;
            this.lblParameter_Value.AutoSize = true;
            this.lblParameter_Value.BackColor = System.Drawing.Color.Transparent;
            this.lblParameter_Value.Location = new System.Drawing.Point(28, 74);
            this.lblParameter_Value.Name = "lblParameter_Value";
            this.lblParameter_Value.Size = new System.Drawing.Size(74, 13);
            this.lblParameter_Value.TabIndex = 4;
            this.lblParameter_Value.Tag = "Parameter_Value";
            this.lblParameter_Value.Text = "Giá trị tham số";
            this.lblParameter_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParameter_Value
            // 
            this.txtParameter_Value.bEnabled = true;
            this.txtParameter_Value.bIsLookup = false;
            this.txtParameter_Value.bReadOnly = false;
            this.txtParameter_Value.bRequire = false;
            this.txtParameter_Value.KeyFilter = "";
            this.txtParameter_Value.Location = new System.Drawing.Point(127, 71);
            this.txtParameter_Value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtParameter_Value.Multiline = true;
            this.txtParameter_Value.Name = "txtParameter_Value";
            this.txtParameter_Value.Size = new System.Drawing.Size(328, 112);
            this.txtParameter_Value.TabIndex = 2;
            this.txtParameter_Value.UseAutoFilter = false;
            // 
            // lblParameter_Desc
            // 
            this.lblParameter_Desc.AutoEllipsis = true;
            this.lblParameter_Desc.AutoSize = true;
            this.lblParameter_Desc.BackColor = System.Drawing.Color.Transparent;
            this.lblParameter_Desc.Location = new System.Drawing.Point(28, 188);
            this.lblParameter_Desc.Name = "lblParameter_Desc";
            this.lblParameter_Desc.Size = new System.Drawing.Size(48, 13);
            this.lblParameter_Desc.TabIndex = 6;
            this.lblParameter_Desc.Tag = "Description";
            this.lblParameter_Desc.Text = "Diễn giải";
            this.lblParameter_Desc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParameter_Desc
            // 
            this.txtParameter_Desc.bEnabled = true;
            this.txtParameter_Desc.bIsLookup = false;
            this.txtParameter_Desc.bReadOnly = false;
            this.txtParameter_Desc.bRequire = false;
            this.txtParameter_Desc.KeyFilter = "";
            this.txtParameter_Desc.Location = new System.Drawing.Point(127, 185);
            this.txtParameter_Desc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtParameter_Desc.Name = "txtParameter_Desc";
            this.txtParameter_Desc.Size = new System.Drawing.Size(328, 20);
            this.txtParameter_Desc.TabIndex = 3;
            this.txtParameter_Desc.UseAutoFilter = false;
            // 
            // lblParameter_Type
            // 
            this.lblParameter_Type.AutoEllipsis = true;
            this.lblParameter_Type.AutoSize = true;
            this.lblParameter_Type.BackColor = System.Drawing.Color.Transparent;
            this.lblParameter_Type.Location = new System.Drawing.Point(28, 212);
            this.lblParameter_Type.Name = "lblParameter_Type";
            this.lblParameter_Type.Size = new System.Drawing.Size(62, 13);
            this.lblParameter_Type.TabIndex = 8;
            this.lblParameter_Type.Tag = "Data_Type";
            this.lblParameter_Type.Text = "Kiểu dữ liệu";
            this.lblParameter_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModule_Id
            // 
            this.lblModule_Id.AutoEllipsis = true;
            this.lblModule_Id.AutoSize = true;
            this.lblModule_Id.BackColor = System.Drawing.Color.Transparent;
            this.lblModule_Id.Location = new System.Drawing.Point(28, 236);
            this.lblModule_Id.Name = "lblModule_Id";
            this.lblModule_Id.Size = new System.Drawing.Size(47, 13);
            this.lblModule_Id.TabIndex = 12;
            this.lblModule_Id.Tag = "Module_ID";
            this.lblModule_Id.Text = "Phân hệ";
            this.lblModule_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(127, 284);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(95, 17);
            this.chkVisible.TabIndex = 7;
            this.chkVisible.Tag = "Visible";
            this.chkVisible.Text = "Hidden/Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // txtParameter_Type
            // 
            this.txtParameter_Type.bEnabled = true;
            this.txtParameter_Type.bIsLookup = false;
            this.txtParameter_Type.bReadOnly = false;
            this.txtParameter_Type.bRequire = false;
            this.txtParameter_Type.InputMask = "S,N";
            this.txtParameter_Type.KeyFilter = "";
            this.txtParameter_Type.Location = new System.Drawing.Point(127, 209);
            this.txtParameter_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtParameter_Type.Name = "txtParameter_Type";
            this.txtParameter_Type.Size = new System.Drawing.Size(39, 20);
            this.txtParameter_Type.TabIndex = 4;
            this.txtParameter_Type.UseAutoFilter = false;
            // 
            // numModule_Id
            // 
            this.numModule_Id.bEnabled = true;
            this.numModule_Id.bFormat = true;
            this.numModule_Id.bIsLookup = false;
            this.numModule_Id.bReadOnly = false;
            this.numModule_Id.bRequire = false;
            this.numModule_Id.KeyFilter = "";
            this.numModule_Id.Location = new System.Drawing.Point(127, 233);
            this.numModule_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numModule_Id.Name = "numModule_Id";
            this.numModule_Id.Scale = 0;
            this.numModule_Id.Size = new System.Drawing.Size(39, 20);
            this.numModule_Id.TabIndex = 5;
            this.numModule_Id.Text = "0";
            this.numModule_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numModule_Id.UseAutoFilter = false;
            this.numModule_Id.Value = 0D;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(287, 364);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 17;
            // 
            // lblParameter_Id_Parent
            // 
            this.lblParameter_Id_Parent.AutoEllipsis = true;
            this.lblParameter_Id_Parent.AutoSize = true;
            this.lblParameter_Id_Parent.BackColor = System.Drawing.Color.Transparent;
            this.lblParameter_Id_Parent.Location = new System.Drawing.Point(28, 260);
            this.lblParameter_Id_Parent.Name = "lblParameter_Id_Parent";
            this.lblParameter_Id_Parent.Size = new System.Drawing.Size(55, 13);
            this.lblParameter_Id_Parent.TabIndex = 19;
            this.lblParameter_Id_Parent.Tag = "Menu_Parent";
            this.lblParameter_Id_Parent.Text = "Menu cha";
            this.lblParameter_Id_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParameter_Id_Parent
            // 
            this.txtParameter_Id_Parent.bEnabled = true;
            this.txtParameter_Id_Parent.bIsLookup = false;
            this.txtParameter_Id_Parent.bReadOnly = false;
            this.txtParameter_Id_Parent.bRequire = false;
            this.txtParameter_Id_Parent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParameter_Id_Parent.KeyFilter = "";
            this.txtParameter_Id_Parent.Location = new System.Drawing.Point(127, 257);
            this.txtParameter_Id_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtParameter_Id_Parent.Name = "txtParameter_Id_Parent";
            this.txtParameter_Id_Parent.Size = new System.Drawing.Size(138, 20);
            this.txtParameter_Id_Parent.TabIndex = 6;
            this.txtParameter_Id_Parent.UseAutoFilter = false;
            // 
            // numStt
            // 
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(127, 22);
            this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(39, 20);
            this.numStt.TabIndex = 0;
            this.numStt.Text = "0";
            this.numStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStt.UseAutoFilter = false;
            this.numStt.Value = 0D;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(28, 25);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(20, 13);
            this.lblControl1.TabIndex = 21;
            this.lblControl1.Tag = "Stt";
            this.lblControl1.Text = "Stt";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmParameters_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 419);
            this.Controls.Add(this.numStt);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtParameter_Id_Parent);
            this.Controls.Add(this.lblParameter_Id_Parent);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.numModule_Id);
            this.Controls.Add(this.txtParameter_Type);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.lblModule_Id);
            this.Controls.Add(this.lblParameter_Type);
            this.Controls.Add(this.lblParameter_Desc);
            this.Controls.Add(this.txtParameter_Desc);
            this.Controls.Add(this.lblParameter_Value);
            this.Controls.Add(this.txtParameter_Value);
            this.Controls.Add(this.lblParameter_ID);
            this.Controls.Add(this.txtParameter_ID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmParameters_Edit";
            this.Tag = "frmParameters, ESC";
            this.Text = "frmParameters";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtParameter_ID;
		private Epoint.Systems.Controls.lblControl lblParameter_ID;
		private Epoint.Systems.Controls.lblControl lblParameter_Value;
		private Epoint.Systems.Controls.txtTextBox txtParameter_Value;
		private Epoint.Systems.Controls.lblControl lblParameter_Desc;
		private Epoint.Systems.Controls.txtTextBox txtParameter_Desc;
		private Epoint.Systems.Controls.lblControl lblParameter_Type;
		private Epoint.Systems.Controls.lblControl lblModule_Id;
		private Epoint.Systems.Controls.chkControl chkVisible;
		private Epoint.Systems.Controls.txtEnum txtParameter_Type;
        private Epoint.Systems.Controls.numControl numModule_Id;
        private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Systems.Controls.lblControl lblParameter_Id_Parent;
        private Systems.Controls.txtTextBox txtParameter_Id_Parent;
        private Systems.Controls.numControl numStt;
        private Systems.Controls.lblControl lblControl1;
	}
}