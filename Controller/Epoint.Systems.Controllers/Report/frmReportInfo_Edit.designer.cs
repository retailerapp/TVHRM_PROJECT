namespace Epoint.Controllers
{
	partial class frmReportInfo_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportInfo_Edit));
            this.lblColumn_ID = new Epoint.Systems.Controls.lblControl();
            this.lblCaption_Default = new Epoint.Systems.Controls.lblControl();
            this.txtDescription = new Epoint.Systems.Controls.txtTextBox();
            this.lblWidth_Default = new Epoint.Systems.Controls.lblControl();
            this.numWidth = new Epoint.Systems.Controls.numControl();
            this.lblColumn_Type = new Epoint.Systems.Controls.lblControl();
            this.lblScale = new Epoint.Systems.Controls.lblControl();
            this.enuType = new Epoint.Systems.Controls.txtEnum();
            this.lbtColumn_Type = new Epoint.Systems.Controls.lblControl();
            this.ChkResizable = new Epoint.Systems.Controls.chkControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.numScale = new Epoint.Systems.Controls.numControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.enuVnd_Nt = new Epoint.Systems.Controls.txtEnum();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.cboColumn_ID = new Epoint.Systems.Controls.cboMultiControl();
            this.chkVisible = new Epoint.Systems.Controls.chkControl();
            this.lblReport_ID = new Epoint.Systems.Controls.lblControl();
            this.txtReport_ID = new Epoint.Systems.Controls.txtTextBox();
            this.chkIs_Customize = new Epoint.Systems.Controls.chkControl();
            this.SuspendLayout();
            // 
            // lblColumn_ID
            // 
            this.lblColumn_ID.AutoEllipsis = true;
            this.lblColumn_ID.AutoSize = true;
            this.lblColumn_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblColumn_ID.Location = new System.Drawing.Point(29, 45);
            this.lblColumn_ID.Name = "lblColumn_ID";
            this.lblColumn_ID.Size = new System.Drawing.Size(44, 13);
            this.lblColumn_ID.TabIndex = 1;
            this.lblColumn_ID.Tag = "Column_ID";
            this.lblColumn_ID.Text = "Tên cột";
            this.lblColumn_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCaption_Default
            // 
            this.lblCaption_Default.AutoEllipsis = true;
            this.lblCaption_Default.AutoSize = true;
            this.lblCaption_Default.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption_Default.Location = new System.Drawing.Point(29, 69);
            this.lblCaption_Default.Name = "lblCaption_Default";
            this.lblCaption_Default.Size = new System.Drawing.Size(48, 13);
            this.lblCaption_Default.TabIndex = 3;
            this.lblCaption_Default.Tag = "Description";
            this.lblCaption_Default.Text = "Diễn giải";
            this.lblCaption_Default.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.bEnabled = true;
            this.txtDescription.bIsLookup = false;
            this.txtDescription.bReadOnly = false;
            this.txtDescription.bRequire = false;
            this.txtDescription.KeyFilter = "";
            this.txtDescription.Location = new System.Drawing.Point(135, 66);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(395, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.UseAutoFilter = false;
            // 
            // lblWidth_Default
            // 
            this.lblWidth_Default.AutoEllipsis = true;
            this.lblWidth_Default.AutoSize = true;
            this.lblWidth_Default.BackColor = System.Drawing.Color.Transparent;
            this.lblWidth_Default.Location = new System.Drawing.Point(29, 115);
            this.lblWidth_Default.Name = "lblWidth_Default";
            this.lblWidth_Default.Size = new System.Drawing.Size(45, 13);
            this.lblWidth_Default.TabIndex = 4;
            this.lblWidth_Default.Tag = "Width";
            this.lblWidth_Default.Text = "Độ rộng";
            this.lblWidth_Default.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numWidth
            // 
            this.numWidth.bEnabled = true;
            this.numWidth.bFormat = true;
            this.numWidth.bIsLookup = false;
            this.numWidth.bReadOnly = false;
            this.numWidth.bRequire = false;
            this.numWidth.KeyFilter = "";
            this.numWidth.Location = new System.Drawing.Point(135, 112);
            this.numWidth.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numWidth.Name = "numWidth";
            this.numWidth.Scale = 0;
            this.numWidth.Size = new System.Drawing.Size(39, 20);
            this.numWidth.TabIndex = 4;
            this.numWidth.Text = "0";
            this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWidth.UseAutoFilter = false;
            this.numWidth.Value = 0D;
            // 
            // lblColumn_Type
            // 
            this.lblColumn_Type.AutoEllipsis = true;
            this.lblColumn_Type.AutoSize = true;
            this.lblColumn_Type.BackColor = System.Drawing.Color.Transparent;
            this.lblColumn_Type.Location = new System.Drawing.Point(29, 138);
            this.lblColumn_Type.Name = "lblColumn_Type";
            this.lblColumn_Type.Size = new System.Drawing.Size(62, 13);
            this.lblColumn_Type.TabIndex = 7;
            this.lblColumn_Type.Tag = "TYPE_CONTROL";
            this.lblColumn_Type.Text = "Loại control";
            this.lblColumn_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScale
            // 
            this.lblScale.AutoEllipsis = true;
            this.lblScale.AutoSize = true;
            this.lblScale.BackColor = System.Drawing.Color.Transparent;
            this.lblScale.Location = new System.Drawing.Point(29, 184);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(34, 13);
            this.lblScale.TabIndex = 12;
            this.lblScale.Tag = "Scale";
            this.lblScale.Text = "Scale";
            this.lblScale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuType
            // 
            this.enuType.bEnabled = true;
            this.enuType.bIsLookup = false;
            this.enuType.bReadOnly = false;
            this.enuType.bRequire = false;
            this.enuType.InputMask = "T,N,C,K,B,D";
            this.enuType.KeyFilter = "";
            this.enuType.Location = new System.Drawing.Point(135, 135);
            this.enuType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.enuType.Name = "enuType";
            this.enuType.Size = new System.Drawing.Size(39, 20);
            this.enuType.TabIndex = 5;
            this.enuType.UseAutoFilter = false;
            // 
            // lbtColumn_Type
            // 
            this.lbtColumn_Type.AutoEllipsis = true;
            this.lbtColumn_Type.AutoSize = true;
            this.lbtColumn_Type.BackColor = System.Drawing.Color.Transparent;
            this.lbtColumn_Type.ForeColor = System.Drawing.Color.Blue;
            this.lbtColumn_Type.Location = new System.Drawing.Point(176, 137);
            this.lbtColumn_Type.Name = "lbtColumn_Type";
            this.lbtColumn_Type.Size = new System.Drawing.Size(354, 13);
            this.lbtColumn_Type.TabIndex = 6;
            this.lbtColumn_Type.Text = "T-TextBox, N-Numeric, K-CheckBox, C-ComboBox, B-Botton, D-DateTime";
            this.lbtColumn_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChkResizable
            // 
            this.ChkResizable.AutoSize = true;
            this.ChkResizable.Checked = true;
            this.ChkResizable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkResizable.Location = new System.Drawing.Point(135, 215);
            this.ChkResizable.Name = "ChkResizable";
            this.ChkResizable.Size = new System.Drawing.Size(120, 17);
            this.ChkResizable.TabIndex = 10;
            this.ChkResizable.Tag = "Resizable";
            this.ChkResizable.Text = "Cho phép cột resize";
            this.ChkResizable.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(366, 277);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 13;
            // 
            // numScale
            // 
            this.numScale.bEnabled = true;
            this.numScale.bFormat = true;
            this.numScale.bIsLookup = false;
            this.numScale.bReadOnly = false;
            this.numScale.bRequire = false;
            this.numScale.KeyFilter = "";
            this.numScale.Location = new System.Drawing.Point(135, 181);
            this.numScale.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numScale.Name = "numScale";
            this.numScale.Scale = 0;
            this.numScale.Size = new System.Drawing.Size(39, 20);
            this.numScale.TabIndex = 9;
            this.numScale.Text = "0";
            this.numScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numScale.UseAutoFilter = false;
            this.numScale.Value = 0D;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(29, 22);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(38, 13);
            this.lblControl1.TabIndex = 4;
            this.lblControl1.Tag = "Stt";
            this.lblControl1.Text = "Thứ tự";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numStt
            // 
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(135, 19);
            this.numStt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(39, 20);
            this.numStt.TabIndex = 0;
            this.numStt.Text = "0";
            this.numStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStt.UseAutoFilter = false;
            this.numStt.Value = 0D;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(29, 161);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(101, 13);
            this.lblControl2.TabIndex = 7;
            this.lblControl2.Tag = "Loai_Tien";
            this.lblControl2.Text = "Hiện theo đồng tiền";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuVnd_Nt
            // 
            this.enuVnd_Nt.bEnabled = true;
            this.enuVnd_Nt.bIsLookup = false;
            this.enuVnd_Nt.bReadOnly = false;
            this.enuVnd_Nt.bRequire = false;
            this.enuVnd_Nt.InputMask = "1,2,3";
            this.enuVnd_Nt.KeyFilter = "";
            this.enuVnd_Nt.Location = new System.Drawing.Point(135, 158);
            this.enuVnd_Nt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.enuVnd_Nt.Name = "enuVnd_Nt";
            this.enuVnd_Nt.Size = new System.Drawing.Size(39, 20);
            this.enuVnd_Nt.TabIndex = 7;
            this.enuVnd_Nt.UseAutoFilter = false;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.ForeColor = System.Drawing.Color.Blue;
            this.lblControl3.Location = new System.Drawing.Point(179, 161);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(213, 13);
            this.lblControl3.TabIndex = 8;
            this.lblControl3.Tag = "enuVnd_Nt";
            this.lblControl3.Text = "1-Đồng việt nam, 2-Đồng ngoại tệ, 3-Tất cả";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboColumn_ID
            // 
            this.cboColumn_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboColumn_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboColumn_ID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboColumn_ID.FormattingEnabled = true;
            this.cboColumn_ID.InitValue = null;
            this.cboColumn_ID.Location = new System.Drawing.Point(135, 42);
            this.cboColumn_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboColumn_ID.Name = "cboColumn_ID";
            this.cboColumn_ID.Size = new System.Drawing.Size(121, 21);
            this.cboColumn_ID.strValueList = null;
            this.cboColumn_ID.TabIndex = 1;
            this.cboColumn_ID.UseAutoComplete = false;
            this.cboColumn_ID.UseBindingValue = false;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(135, 234);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(56, 17);
            this.chkVisible.TabIndex = 11;
            this.chkVisible.Tag = "Visible";
            this.chkVisible.Text = "Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // lblReport_ID
            // 
            this.lblReport_ID.AutoEllipsis = true;
            this.lblReport_ID.AutoSize = true;
            this.lblReport_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblReport_ID.Location = new System.Drawing.Point(29, 92);
            this.lblReport_ID.Name = "lblReport_ID";
            this.lblReport_ID.Size = new System.Drawing.Size(53, 13);
            this.lblReport_ID.TabIndex = 76;
            this.lblReport_ID.Tag = "Report_ID";
            this.lblReport_ID.Text = "Report ID";
            this.lblReport_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReport_ID
            // 
            this.txtReport_ID.bEnabled = true;
            this.txtReport_ID.bIsLookup = false;
            this.txtReport_ID.bReadOnly = false;
            this.txtReport_ID.bRequire = false;
            this.txtReport_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReport_ID.KeyFilter = "";
            this.txtReport_ID.Location = new System.Drawing.Point(135, 89);
            this.txtReport_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtReport_ID.Name = "txtReport_ID";
            this.txtReport_ID.Size = new System.Drawing.Size(120, 20);
            this.txtReport_ID.TabIndex = 3;
            this.txtReport_ID.UseAutoFilter = false;
            // 
            // chkIs_Customize
            // 
            this.chkIs_Customize.AutoSize = true;
            this.chkIs_Customize.Location = new System.Drawing.Point(135, 254);
            this.chkIs_Customize.Name = "chkIs_Customize";
            this.chkIs_Customize.Size = new System.Drawing.Size(122, 17);
            this.chkIs_Customize.TabIndex = 12;
            this.chkIs_Customize.Tag = "Module_Customize";
            this.chkIs_Customize.Text = "Là dữ liệu customize";
            this.chkIs_Customize.UseVisualStyleBackColor = true;
            // 
            // frmReportInfo_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 327);
            this.Controls.Add(this.chkIs_Customize);
            this.Controls.Add(this.lblReport_ID);
            this.Controls.Add(this.txtReport_ID);
            this.Controls.Add(this.cboColumn_ID);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.ChkResizable);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.enuVnd_Nt);
            this.Controls.Add(this.lbtColumn_Type);
            this.Controls.Add(this.enuType);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.lblColumn_Type);
            this.Controls.Add(this.numScale);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.numStt);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.lblWidth_Default);
            this.Controls.Add(this.lblCaption_Default);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblColumn_ID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportInfo_Edit";
            this.Tag = "ReportInfo";
            this.Text = "ReportInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.lblControl lblColumn_ID;
		private Epoint.Systems.Controls.lblControl lblCaption_Default;
		private Epoint.Systems.Controls.txtTextBox txtDescription;
		private Epoint.Systems.Controls.lblControl lblWidth_Default;
		private Epoint.Systems.Controls.numControl numWidth;
		private Epoint.Systems.Controls.lblControl lblColumn_Type;
		private Epoint.Systems.Controls.lblControl lblScale;
		private Epoint.Systems.Controls.txtEnum enuType;
		private Epoint.Systems.Controls.lblControl lbtColumn_Type;
		private Epoint.Systems.Controls.chkControl ChkResizable;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.numControl numScale;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.numControl numStt;
		private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.txtEnum enuVnd_Nt;
		private Epoint.Systems.Controls.lblControl lblControl3;
		private Epoint.Systems.Controls.cboMultiControl cboColumn_ID;
		private Epoint.Systems.Controls.chkControl chkVisible;
		private Epoint.Systems.Controls.lblControl lblReport_ID;
		private Epoint.Systems.Controls.txtTextBox txtReport_ID;
		private Epoint.Systems.Controls.chkControl chkIs_Customize;
	}
}