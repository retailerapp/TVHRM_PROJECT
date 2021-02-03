namespace Epoint.Controllers
{
    partial class frmResource_File_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResource_File_Edit));
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.txtFile_Name = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtFile_Id = new Epoint.Systems.Controls.txtTextBox();
            this.lblFile_ID = new Epoint.Systems.Controls.lblControl();
            this.chkOpen = new Epoint.Systems.Controls.chkControl();
            this.btUpLoad = new Epoint.Systems.Controls.btControl();
            this.btDownLoad = new Epoint.Systems.Controls.btControl();
            this.btRemove = new Epoint.Systems.Controls.btControl();
            this.lbtFile_Tag1 = new Epoint.Systems.Controls.lblControl();
            this.lbtFile_Tag = new Epoint.Systems.Controls.lbtControl();
            this.cboFile_Type = new Epoint.Systems.Controls.cboControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblSize = new Epoint.Systems.Controls.lbtControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Nhom = new Epoint.Systems.Controls.txtTextBox();
            this.chkDuyet = new Epoint.Systems.Controls.chkControl();
            this.dteNgay_Ky = new Epoint.Systems.Controls.txtDateTime();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.lblControl7 = new Epoint.Systems.Controls.lblControl();
            this.txtPhong_Lien_Quan = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl8 = new Epoint.Systems.Controls.lblControl();
            this.txtND_Chi_Dao = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Tag = "";
            this.label2.Text = "File Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFile_Name
            // 
            this.txtFile_Name.bEnabled = true;
            this.txtFile_Name.bIsLookup = false;
            this.txtFile_Name.bReadOnly = false;
            this.txtFile_Name.bRequire = false;
            this.txtFile_Name.KeyFilter = "";
            this.txtFile_Name.Location = new System.Drawing.Point(141, 70);
            this.txtFile_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Name.Name = "txtFile_Name";
            this.txtFile_Name.Size = new System.Drawing.Size(489, 20);
            this.txtFile_Name.TabIndex = 4;
            this.txtFile_Name.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(461, 304);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 34);
            this.btgAccept.TabIndex = 12;
            // 
            // txtFile_Id
            // 
            this.txtFile_Id.bEnabled = true;
            this.txtFile_Id.bIsLookup = false;
            this.txtFile_Id.bReadOnly = false;
            this.txtFile_Id.bRequire = false;
            this.txtFile_Id.KeyFilter = "";
            this.txtFile_Id.Location = new System.Drawing.Point(141, 46);
            this.txtFile_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Id.Name = "txtFile_Id";
            this.txtFile_Id.Size = new System.Drawing.Size(245, 20);
            this.txtFile_Id.TabIndex = 3;
            this.txtFile_Id.Tag = "";
            this.txtFile_Id.UseAutoFilter = false;
            // 
            // lblFile_ID
            // 
            this.lblFile_ID.AutoEllipsis = true;
            this.lblFile_ID.AutoSize = true;
            this.lblFile_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblFile_ID.Location = new System.Drawing.Point(25, 49);
            this.lblFile_ID.Name = "lblFile_ID";
            this.lblFile_ID.Size = new System.Drawing.Size(37, 13);
            this.lblFile_ID.TabIndex = 3;
            this.lblFile_ID.Tag = "";
            this.lblFile_ID.Text = "File ID";
            this.lblFile_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.ForeColor = System.Drawing.Color.Blue;
            this.chkOpen.Location = new System.Drawing.Point(310, 240);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(141, 17);
            this.chkOpen.TabIndex = 9;
            this.chkOpen.Tag = "";
            this.chkOpen.Text = "Open file after download";
            this.chkOpen.UseVisualStyleBackColor = true;
            this.chkOpen.Visible = false;
            // 
            // btUpLoad
            // 
            this.btUpLoad.Image = ((System.Drawing.Image)(resources.GetObject("btUpLoad.Image")));
            this.btUpLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpLoad.Location = new System.Drawing.Point(139, 304);
            this.btUpLoad.Name = "btUpLoad";
            this.btUpLoad.Size = new System.Drawing.Size(83, 34);
            this.btUpLoad.TabIndex = 9;
            this.btUpLoad.Tag = "";
            this.btUpLoad.Text = "Upload";
            this.btUpLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpLoad.UseVisualStyleBackColor = true;
            // 
            // btDownLoad
            // 
            this.btDownLoad.Image = ((System.Drawing.Image)(resources.GetObject("btDownLoad.Image")));
            this.btDownLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDownLoad.Location = new System.Drawing.Point(227, 304);
            this.btDownLoad.Name = "btDownLoad";
            this.btDownLoad.Size = new System.Drawing.Size(90, 34);
            this.btDownLoad.TabIndex = 10;
            this.btDownLoad.Tag = "";
            this.btDownLoad.Text = "Download";
            this.btDownLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDownLoad.UseVisualStyleBackColor = true;
            // 
            // btRemove
            // 
            this.btRemove.Image = ((System.Drawing.Image)(resources.GetObject("btRemove.Image")));
            this.btRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRemove.Location = new System.Drawing.Point(322, 304);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(91, 34);
            this.btRemove.TabIndex = 11;
            this.btRemove.Tag = "";
            this.btRemove.Text = "Select File";
            this.btRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRemove.UseVisualStyleBackColor = true;
            // 
            // lbtFile_Tag1
            // 
            this.lbtFile_Tag1.AutoEllipsis = true;
            this.lbtFile_Tag1.AutoSize = true;
            this.lbtFile_Tag1.BackColor = System.Drawing.Color.Transparent;
            this.lbtFile_Tag1.Location = new System.Drawing.Point(25, 24);
            this.lbtFile_Tag1.Name = "lbtFile_Tag1";
            this.lbtFile_Tag1.Size = new System.Drawing.Size(31, 13);
            this.lbtFile_Tag1.TabIndex = 3;
            this.lbtFile_Tag1.Tag = "";
            this.lbtFile_Tag1.Text = "Type";
            this.lbtFile_Tag1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtFile_Tag
            // 
            this.lbtFile_Tag.AutoSize = true;
            this.lbtFile_Tag.ForeColor = System.Drawing.Color.Blue;
            this.lbtFile_Tag.Location = new System.Drawing.Point(271, 25);
            this.lbtFile_Tag.Name = "lbtFile_Tag";
            this.lbtFile_Tag.Size = new System.Drawing.Size(57, 13);
            this.lbtFile_Tag.TabIndex = 20;
            this.lbtFile_Tag.Text = "Data Type";
            this.lbtFile_Tag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFile_Type
            // 
            this.cboFile_Type.AutoCompleteCustomSource.AddRange(new string[] {
            "IMG",
            "XLS",
            "DOC",
            "EXE"});
            this.cboFile_Type.FormattingEnabled = true;
            this.cboFile_Type.InitValue = null;
            this.cboFile_Type.Location = new System.Drawing.Point(141, 21);
            this.cboFile_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboFile_Type.Name = "cboFile_Type";
            this.cboFile_Type.Size = new System.Drawing.Size(125, 21);
            this.cboFile_Type.strValueList = null;
            this.cboFile_Type.TabIndex = 2;
            this.cboFile_Type.UseAutoComplete = false;
            this.cboFile_Type.UseBindingValue = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PDF");
            this.imageList1.Images.SetKeyName(1, "DOC");
            this.imageList1.Images.SetKeyName(2, "XLS");
            this.imageList1.Images.SetKeyName(3, "IMG");
            this.imageList1.Images.SetKeyName(4, "EXE.png");
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.ForeColor = System.Drawing.Color.Blue;
            this.lblSize.Location = new System.Drawing.Point(391, 50);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 20;
            this.lblSize.Text = "Size";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(25, 97);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(36, 13);
            this.lblControl1.TabIndex = 22;
            this.lblControl1.Tag = "";
            this.lblControl1.Text = "Group";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Nhom
            // 
            this.txtMa_Nhom.bEnabled = true;
            this.txtMa_Nhom.bIsLookup = false;
            this.txtMa_Nhom.bReadOnly = false;
            this.txtMa_Nhom.bRequire = false;
            this.txtMa_Nhom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Nhom.KeyFilter = "";
            this.txtMa_Nhom.Location = new System.Drawing.Point(141, 94);
            this.txtMa_Nhom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nhom.Name = "txtMa_Nhom";
            this.txtMa_Nhom.Size = new System.Drawing.Size(125, 20);
            this.txtMa_Nhom.TabIndex = 5;
            this.txtMa_Nhom.Tag = "";
            this.txtMa_Nhom.UseAutoFilter = false;
            // 
            // chkDuyet
            // 
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Checked = true;
            this.chkDuyet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDuyet.ForeColor = System.Drawing.Color.Blue;
            this.chkDuyet.Location = new System.Drawing.Point(142, 240);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(68, 17);
            this.chkDuyet.TabIndex = 10;
            this.chkDuyet.Tag = "";
            this.chkDuyet.Text = "Check in";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // dteNgay_Ky
            // 
            this.dteNgay_Ky.bAllowEmpty = true;
            this.dteNgay_Ky.bRequire = true;
            this.dteNgay_Ky.bSelectOnFocus = false;
            this.dteNgay_Ky.bShowDateTimePicker = true;
            this.dteNgay_Ky.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ky.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteNgay_Ky.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ky.Location = new System.Drawing.Point(141, 118);
            this.dteNgay_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ky.Mask = "00/00/0000";
            this.dteNgay_Ky.Name = "dteNgay_Ky";
            this.dteNgay_Ky.Size = new System.Drawing.Size(125, 20);
            this.dteNgay_Ky.TabIndex = 6;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(25, 120);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(30, 13);
            this.lblControl3.TabIndex = 25;
            this.lblControl3.Tag = "";
            this.lblControl3.Text = "Date";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl7
            // 
            this.lblControl7.AutoEllipsis = true;
            this.lblControl7.AutoSize = true;
            this.lblControl7.BackColor = System.Drawing.Color.Transparent;
            this.lblControl7.Location = new System.Drawing.Point(25, 208);
            this.lblControl7.Name = "lblControl7";
            this.lblControl7.Size = new System.Drawing.Size(62, 13);
            this.lblControl7.TabIndex = 150;
            this.lblControl7.Tag = "";
            this.lblControl7.Text = "Department";
            this.lblControl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhong_Lien_Quan
            // 
            this.txtPhong_Lien_Quan.bEnabled = true;
            this.txtPhong_Lien_Quan.bIsLookup = false;
            this.txtPhong_Lien_Quan.bReadOnly = false;
            this.txtPhong_Lien_Quan.bRequire = false;
            this.txtPhong_Lien_Quan.KeyFilter = "";
            this.txtPhong_Lien_Quan.Location = new System.Drawing.Point(142, 205);
            this.txtPhong_Lien_Quan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPhong_Lien_Quan.Name = "txtPhong_Lien_Quan";
            this.txtPhong_Lien_Quan.Size = new System.Drawing.Size(488, 20);
            this.txtPhong_Lien_Quan.TabIndex = 8;
            this.txtPhong_Lien_Quan.Tag = "";
            this.txtPhong_Lien_Quan.UseAutoFilter = false;
            // 
            // lblControl8
            // 
            this.lblControl8.AutoEllipsis = true;
            this.lblControl8.AutoSize = true;
            this.lblControl8.BackColor = System.Drawing.Color.Transparent;
            this.lblControl8.Location = new System.Drawing.Point(25, 166);
            this.lblControl8.Name = "lblControl8";
            this.lblControl8.Size = new System.Drawing.Size(44, 13);
            this.lblControl8.TabIndex = 152;
            this.lblControl8.Tag = "";
            this.lblControl8.Text = "Remark";
            this.lblControl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtND_Chi_Dao
            // 
            this.txtND_Chi_Dao.Location = new System.Drawing.Point(142, 142);
            this.txtND_Chi_Dao.Name = "txtND_Chi_Dao";
            this.txtND_Chi_Dao.Size = new System.Drawing.Size(488, 58);
            this.txtND_Chi_Dao.TabIndex = 7;
            this.txtND_Chi_Dao.Text = "";
            // 
            // frmResource_File_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 354);
            this.Controls.Add(this.txtND_Chi_Dao);
            this.Controls.Add(this.lblControl8);
            this.Controls.Add(this.lblControl7);
            this.Controls.Add(this.txtPhong_Lien_Quan);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.dteNgay_Ky);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtMa_Nhom);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lbtFile_Tag);
            this.Controls.Add(this.cboFile_Type);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btDownLoad);
            this.Controls.Add(this.btUpLoad);
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFile_Name);
            this.Controls.Add(this.lbtFile_Tag1);
            this.Controls.Add(this.lblFile_ID);
            this.Controls.Add(this.txtFile_Id);
            this.Name = "frmResource_File_Edit";
            this.Tag = "frmResource, ESC";
            this.Text = "frmResource";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.lblControl label2;
		private Epoint.Systems.Controls.txtTextBox txtFile_Name;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.txtTextBox txtFile_Id;
		private Epoint.Systems.Controls.lblControl lblFile_ID;
		private Epoint.Systems.Controls.chkControl chkOpen;
        private Systems.Controls.btControl btUpLoad;
        private Systems.Controls.btControl btDownLoad;
        private Systems.Controls.btControl btRemove;
        private Systems.Controls.lblControl lbtFile_Tag1;
        private Systems.Controls.lbtControl lbtFile_Tag;
        private Systems.Controls.cboControl cboFile_Type;
        private System.Windows.Forms.ImageList imageList1;
        private Systems.Controls.lbtControl lblSize;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.txtTextBox txtMa_Nhom;
        private Systems.Controls.chkControl chkDuyet;
        private Systems.Controls.txtDateTime dteNgay_Ky;
        private Systems.Controls.lblControl lblControl3;
        private Systems.Controls.lblControl lblControl7;
        private Systems.Controls.txtTextBox txtPhong_Lien_Quan;
        private Systems.Controls.lblControl lblControl8;
        private System.Windows.Forms.RichTextBox txtND_Chi_Dao;
	}
}