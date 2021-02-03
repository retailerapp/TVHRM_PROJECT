namespace Epoint.Controllers
{
    partial class frmResource_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResource_Edit));
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.txtFile_Name = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtFile_Id = new Epoint.Systems.Controls.txtTextBox();
            this.lblFile_ID = new Epoint.Systems.Controls.lblControl();
            this.chkOpen = new Epoint.Systems.Controls.chkControl();
            this.btUpLoad = new Epoint.Systems.Controls.btControl();
            this.btDownLoad = new Epoint.Systems.Controls.btControl();
            this.btRemove = new Epoint.Systems.Controls.btControl();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lbtFile_Tag1 = new Epoint.Systems.Controls.lblControl();
            this.lbtFile_Tag = new Epoint.Systems.Controls.lbtControl();
            this.cboFile_Type = new Epoint.Systems.Controls.cboControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblSize = new Epoint.Systems.Controls.lbtControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Nhom = new Epoint.Systems.Controls.txtTextBox();
            this.chkDuyet = new Epoint.Systems.Controls.chkControl();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.txtNguoi_Ky = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Ky = new Epoint.Systems.Controls.txtDateTime();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(39, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 16;
            this.label2.Tag = "File_Name";
            this.label2.Text = "Tên File";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFile_Name
            // 
            this.txtFile_Name.bEnabled = true;
            this.txtFile_Name.bIsLookup = false;
            this.txtFile_Name.bReadOnly = false;
            this.txtFile_Name.bRequire = false;
            this.txtFile_Name.KeyFilter = "";
            this.txtFile_Name.Location = new System.Drawing.Point(111, 85);
            this.txtFile_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Name.Name = "txtFile_Name";
            this.txtFile_Name.Size = new System.Drawing.Size(370, 20);
            this.txtFile_Name.TabIndex = 2;
            this.txtFile_Name.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(763, 600);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 35);
            this.btgAccept.TabIndex = 12;
            // 
            // txtFile_Id
            // 
            this.txtFile_Id.bEnabled = true;
            this.txtFile_Id.bIsLookup = false;
            this.txtFile_Id.bReadOnly = false;
            this.txtFile_Id.bRequire = false;
            this.txtFile_Id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFile_Id.KeyFilter = "";
            this.txtFile_Id.Location = new System.Drawing.Point(111, 61);
            this.txtFile_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFile_Id.Name = "txtFile_Id";
            this.txtFile_Id.Size = new System.Drawing.Size(370, 20);
            this.txtFile_Id.TabIndex = 1;
            this.txtFile_Id.Tag = "";
            this.txtFile_Id.UseAutoFilter = false;
            // 
            // lblFile_ID
            // 
            this.lblFile_ID.AutoEllipsis = true;
            this.lblFile_ID.AutoSize = true;
            this.lblFile_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblFile_ID.Location = new System.Drawing.Point(39, 64);
            this.lblFile_ID.Name = "lblFile_ID";
            this.lblFile_ID.Size = new System.Drawing.Size(41, 13);
            this.lblFile_ID.TabIndex = 3;
            this.lblFile_ID.Tag = "Catalog";
            this.lblFile_ID.Text = "Mã File";
            this.lblFile_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.ForeColor = System.Drawing.Color.Blue;
            this.chkOpen.Location = new System.Drawing.Point(111, 480);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(139, 17);
            this.chkOpen.TabIndex = 7;
            this.chkOpen.Tag = "Open_File";
            this.chkOpen.Text = "Mở tập tin sau khi tải về";
            this.chkOpen.UseVisualStyleBackColor = true;
            // 
            // btUpLoad
            // 
            this.btUpLoad.Image = ((System.Drawing.Image)(resources.GetObject("btUpLoad.Image")));
            this.btUpLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpLoad.Location = new System.Drawing.Point(161, 546);
            this.btUpLoad.Name = "btUpLoad";
            this.btUpLoad.Size = new System.Drawing.Size(93, 36);
            this.btUpLoad.TabIndex = 9;
            this.btUpLoad.Tag = "";
            this.btUpLoad.Text = "Tải lên";
            this.btUpLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpLoad.UseVisualStyleBackColor = true;
            // 
            // btDownLoad
            // 
            this.btDownLoad.Image = ((System.Drawing.Image)(resources.GetObject("btDownLoad.Image")));
            this.btDownLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDownLoad.Location = new System.Drawing.Point(260, 546);
            this.btDownLoad.Name = "btDownLoad";
            this.btDownLoad.Size = new System.Drawing.Size(102, 36);
            this.btDownLoad.TabIndex = 10;
            this.btDownLoad.Tag = "DownLoad";
            this.btDownLoad.Text = "Tải về tập tin";
            this.btDownLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDownLoad.UseVisualStyleBackColor = true;
            // 
            // btRemove
            // 
            this.btRemove.Image = ((System.Drawing.Image)(resources.GetObject("btRemove.Image")));
            this.btRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRemove.Location = new System.Drawing.Point(368, 546);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(110, 36);
            this.btRemove.TabIndex = 11;
            this.btRemove.Tag = "Remove";
            this.btRemove.Text = "Chọn lại tập tin";
            this.btRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Visible = false;
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Image = ((System.Drawing.Image)(resources.GetObject("picImage.Image")));
            this.picImage.Location = new System.Drawing.Point(517, 10);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(415, 572);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 18;
            this.picImage.TabStop = false;
            // 
            // lbtFile_Tag1
            // 
            this.lbtFile_Tag1.AutoEllipsis = true;
            this.lbtFile_Tag1.AutoSize = true;
            this.lbtFile_Tag1.BackColor = System.Drawing.Color.Transparent;
            this.lbtFile_Tag1.Location = new System.Drawing.Point(39, 39);
            this.lbtFile_Tag1.Name = "lbtFile_Tag1";
            this.lbtFile_Tag1.Size = new System.Drawing.Size(61, 13);
            this.lbtFile_Tag1.TabIndex = 3;
            this.lbtFile_Tag1.Tag = "File_Tag";
            this.lbtFile_Tag1.Text = "Loại dữ liệu";
            this.lbtFile_Tag1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtFile_Tag
            // 
            this.lbtFile_Tag.AutoSize = true;
            this.lbtFile_Tag.ForeColor = System.Drawing.Color.Blue;
            this.lbtFile_Tag.Location = new System.Drawing.Point(248, 39);
            this.lbtFile_Tag.Name = "lbtFile_Tag";
            this.lbtFile_Tag.Size = new System.Drawing.Size(61, 13);
            this.lbtFile_Tag.TabIndex = 20;
            this.lbtFile_Tag.Text = "Loại dữ liêu";
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
            this.cboFile_Type.Location = new System.Drawing.Point(111, 36);
            this.cboFile_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboFile_Type.Name = "cboFile_Type";
            this.cboFile_Type.Size = new System.Drawing.Size(125, 21);
            this.cboFile_Type.strValueList = null;
            this.cboFile_Type.TabIndex = 0;
            this.cboFile_Type.UpperCase = false;
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
            this.lblSize.Location = new System.Drawing.Point(248, 65);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(0, 13);
            this.lblSize.TabIndex = 20;
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(39, 187);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(50, 13);
            this.lblControl2.TabIndex = 3;
            this.lblControl2.Tag = "Description";
            this.lblControl2.Text = "Diễn Giải";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(39, 112);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(51, 13);
            this.lblControl1.TabIndex = 22;
            this.lblControl1.Tag = "Ma_Nhom";
            this.lblControl1.Text = "Mã nhóm";
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
            this.txtMa_Nhom.Location = new System.Drawing.Point(111, 109);
            this.txtMa_Nhom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Nhom.Name = "txtMa_Nhom";
            this.txtMa_Nhom.Size = new System.Drawing.Size(370, 20);
            this.txtMa_Nhom.TabIndex = 3;
            this.txtMa_Nhom.Tag = "";
            this.txtMa_Nhom.UseAutoFilter = false;
            // 
            // chkDuyet
            // 
            this.chkDuyet.AutoSize = true;
            this.chkDuyet.Checked = true;
            this.chkDuyet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDuyet.ForeColor = System.Drawing.Color.Blue;
            this.chkDuyet.Location = new System.Drawing.Point(111, 503);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(54, 17);
            this.chkDuyet.TabIndex = 8;
            this.chkDuyet.Tag = "Duyet_File";
            this.chkDuyet.Text = "Duyệt";
            this.chkDuyet.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(111, 181);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(370, 293);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.Text = "";
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(39, 160);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(49, 13);
            this.lblControl4.TabIndex = 31;
            this.lblControl4.Tag = "";
            this.lblControl4.Text = "Người ký";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNguoi_Ky
            // 
            this.txtNguoi_Ky.bEnabled = true;
            this.txtNguoi_Ky.bIsLookup = false;
            this.txtNguoi_Ky.bReadOnly = false;
            this.txtNguoi_Ky.bRequire = false;
            this.txtNguoi_Ky.KeyFilter = "";
            this.txtNguoi_Ky.Location = new System.Drawing.Point(111, 157);
            this.txtNguoi_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNguoi_Ky.Name = "txtNguoi_Ky";
            this.txtNguoi_Ky.Size = new System.Drawing.Size(370, 20);
            this.txtNguoi_Ky.TabIndex = 5;
            this.txtNguoi_Ky.Tag = "";
            this.txtNguoi_Ky.UseAutoFilter = false;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(39, 135);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(46, 13);
            this.lblControl3.TabIndex = 30;
            this.lblControl3.Tag = "";
            this.lblControl3.Text = "Ngày ký";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dteNgay_Ky.Location = new System.Drawing.Point(111, 133);
            this.dteNgay_Ky.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ky.Mask = "00/00/0000";
            this.dteNgay_Ky.Name = "dteNgay_Ky";
            this.dteNgay_Ky.Size = new System.Drawing.Size(125, 20);
            this.dteNgay_Ky.TabIndex = 4;
            // 
            // frmResource_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 649);
            this.Controls.Add(this.lblControl4);
            this.Controls.Add(this.txtNguoi_Ky);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.dteNgay_Ky);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtMa_Nhom);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lbtFile_Tag);
            this.Controls.Add(this.cboFile_Type);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btDownLoad);
            this.Controls.Add(this.btUpLoad);
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFile_Name);
            this.Controls.Add(this.lbtFile_Tag1);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblFile_ID);
            this.Controls.Add(this.txtFile_Id);
            this.Name = "frmResource_Edit";
            this.Tag = "frmResource";
            this.Text = "Quản lý tập tin";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
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
        private System.Windows.Forms.PictureBox picImage;
        private Systems.Controls.lblControl lbtFile_Tag1;
        private Systems.Controls.lbtControl lbtFile_Tag;
        private Systems.Controls.cboControl cboFile_Type;
        private System.Windows.Forms.ImageList imageList1;
        private Systems.Controls.lbtControl lblSize;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.txtTextBox txtMa_Nhom;
        private Systems.Controls.chkControl chkDuyet;
        private System.Windows.Forms.RichTextBox txtDescription;
        private Systems.Controls.lblControl lblControl4;
        private Systems.Controls.txtTextBox txtNguoi_Ky;
        private Systems.Controls.lblControl lblControl3;
        private Systems.Controls.txtDateTime dteNgay_Ky;
	}
}