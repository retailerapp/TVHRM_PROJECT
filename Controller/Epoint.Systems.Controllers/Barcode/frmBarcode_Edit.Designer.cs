namespace Epoint.Controllers
{
    partial class frmBarcode_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarcode_Edit));
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblTk = new Epoint.Systems.Controls.lblControl();
            this.txtMa_Vt = new Epoint.Systems.Controls.txtTextBox();
            this.lblDien_Giai = new Epoint.Systems.Controls.lblControl();
            this.txtTen_Vt2 = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtTen_Vt = new Epoint.Systems.Controls.txtTextBox();
            this.picBarCode = new System.Windows.Forms.PictureBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnViewBarcode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numGia_Ban = new Epoint.Systems.Controls.numControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.btnPrintBarcode128 = new System.Windows.Forms.Button();
            this.btnPreviewBarcode128 = new System.Windows.Forms.Button();
            this.btnViewBarcode128 = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.txtMa_Code = new Epoint.Systems.Controls.txtTextBox();
            this.btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBarCode)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(12, 308);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 6;
            this.btgAccept.Visible = false;
            // 
            // lblTk
            // 
            this.lblTk.AutoEllipsis = true;
            this.lblTk.AutoSize = true;
            this.lblTk.BackColor = System.Drawing.Color.Transparent;
            this.lblTk.Location = new System.Drawing.Point(20, 28);
            this.lblTk.Name = "lblTk";
            this.lblTk.Size = new System.Drawing.Size(34, 13);
            this.lblTk.TabIndex = 60;
            this.lblTk.Tag = "Ma_Vt";
            this.lblTk.Text = "Mã vt";
            this.lblTk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_Vt
            // 
            this.txtMa_Vt.bEnabled = true;
            this.txtMa_Vt.bIsLookup = false;
            this.txtMa_Vt.bReadOnly = false;
            this.txtMa_Vt.bRequire = false;
            this.txtMa_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_Vt.KeyFilter = "";
            this.txtMa_Vt.Location = new System.Drawing.Point(125, 25);
            this.txtMa_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Vt.MaxLength = 20;
            this.txtMa_Vt.Name = "txtMa_Vt";
            this.txtMa_Vt.ReadOnly = true;
            this.txtMa_Vt.Size = new System.Drawing.Size(213, 20);
            this.txtMa_Vt.TabIndex = 0;
            this.txtMa_Vt.UseAutoFilter = false;
            // 
            // lblDien_Giai
            // 
            this.lblDien_Giai.AutoEllipsis = true;
            this.lblDien_Giai.AutoSize = true;
            this.lblDien_Giai.BackColor = System.Drawing.Color.Transparent;
            this.lblDien_Giai.Location = new System.Drawing.Point(20, 74);
            this.lblDien_Giai.Name = "lblDien_Giai";
            this.lblDien_Giai.Size = new System.Drawing.Size(75, 13);
            this.lblDien_Giai.TabIndex = 60;
            this.lblDien_Giai.Tag = "Ten_Vt2";
            this.lblDien_Giai.Text = "Tên Vt rút gọn";
            this.lblDien_Giai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Vt2
            // 
            this.txtTen_Vt2.bEnabled = true;
            this.txtTen_Vt2.bIsLookup = false;
            this.txtTen_Vt2.bReadOnly = false;
            this.txtTen_Vt2.bRequire = false;
            this.txtTen_Vt2.KeyFilter = "";
            this.txtTen_Vt2.Location = new System.Drawing.Point(125, 71);
            this.txtTen_Vt2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Vt2.MaxLength = 200;
            this.txtTen_Vt2.Name = "txtTen_Vt2";
            this.txtTen_Vt2.Size = new System.Drawing.Size(395, 20);
            this.txtTen_Vt2.TabIndex = 2;
            this.txtTen_Vt2.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(20, 50);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(38, 13);
            this.lblControl1.TabIndex = 60;
            this.lblControl1.Tag = "Ten_Vt";
            this.lblControl1.Text = "Tên vt";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen_Vt
            // 
            this.txtTen_Vt.bEnabled = true;
            this.txtTen_Vt.bIsLookup = false;
            this.txtTen_Vt.bReadOnly = false;
            this.txtTen_Vt.bRequire = false;
            this.txtTen_Vt.KeyFilter = "";
            this.txtTen_Vt.Location = new System.Drawing.Point(125, 47);
            this.txtTen_Vt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTen_Vt.MaxLength = 200;
            this.txtTen_Vt.Name = "txtTen_Vt";
            this.txtTen_Vt.Size = new System.Drawing.Size(395, 20);
            this.txtTen_Vt.TabIndex = 1;
            this.txtTen_Vt.UseAutoFilter = false;
            // 
            // picBarCode
            // 
            this.picBarCode.Location = new System.Drawing.Point(9, 18);
            this.picBarCode.Name = "picBarCode";
            this.picBarCode.Size = new System.Drawing.Size(129, 96);
            this.picBarCode.TabIndex = 61;
            this.picBarCode.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(10, 267);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(108, 38);
            this.btnPrint.TabIndex = 62;
            this.btnPrint.Tag = "PrintBarCode";
            this.btnPrint.Text = "In Barcode 13";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            // 
            // btnViewBarcode
            // 
            this.btnViewBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnViewBarcode.Image")));
            this.btnViewBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewBarcode.Location = new System.Drawing.Point(123, 267);
            this.btnViewBarcode.Name = "btnViewBarcode";
            this.btnViewBarcode.Size = new System.Drawing.Size(118, 38);
            this.btnViewBarcode.TabIndex = 62;
            this.btnViewBarcode.Tag = "ViewBarCode";
            this.btnViewBarcode.Text = "Tạo mã vạch 13";
            this.btnViewBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewBarcode.UseVisualStyleBackColor = true;
            this.btnViewBarcode.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picBarCode);
            this.groupBox1.Location = new System.Drawing.Point(290, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 124);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode";
            // 
            // numGia_Ban
            // 
            this.numGia_Ban.bEnabled = true;
            this.numGia_Ban.bFormat = true;
            this.numGia_Ban.bIsLookup = false;
            this.numGia_Ban.bReadOnly = false;
            this.numGia_Ban.bRequire = false;
            this.numGia_Ban.KeyFilter = "";
            this.numGia_Ban.Location = new System.Drawing.Point(125, 96);
            this.numGia_Ban.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numGia_Ban.Name = "numGia_Ban";
            this.numGia_Ban.Scale = 2;
            this.numGia_Ban.Size = new System.Drawing.Size(213, 20);
            this.numGia_Ban.TabIndex = 4;
            this.numGia_Ban.Text = "0.00";
            this.numGia_Ban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGia_Ban.UseAutoFilter = false;
            this.numGia_Ban.Value = 0D;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(20, 99);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(44, 13);
            this.lblControl2.TabIndex = 65;
            this.lblControl2.Tag = "Gia_Ban";
            this.lblControl2.Text = "Giá bán";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrintBarcode128
            // 
            this.btnPrintBarcode128.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintBarcode128.Image")));
            this.btnPrintBarcode128.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintBarcode128.Location = new System.Drawing.Point(247, 267);
            this.btnPrintBarcode128.Name = "btnPrintBarcode128";
            this.btnPrintBarcode128.Size = new System.Drawing.Size(128, 38);
            this.btnPrintBarcode128.TabIndex = 62;
            this.btnPrintBarcode128.Tag = "In_Barcode";
            this.btnPrintBarcode128.Text = "In Barcode 128";
            this.btnPrintBarcode128.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintBarcode128.UseVisualStyleBackColor = true;
            this.btnPrintBarcode128.Visible = false;
            // 
            // btnPreviewBarcode128
            // 
            this.btnPreviewBarcode128.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewBarcode128.Image")));
            this.btnPreviewBarcode128.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreviewBarcode128.Location = new System.Drawing.Point(187, 308);
            this.btnPreviewBarcode128.Name = "btnPreviewBarcode128";
            this.btnPreviewBarcode128.Size = new System.Drawing.Size(128, 33);
            this.btnPreviewBarcode128.TabIndex = 62;
            this.btnPreviewBarcode128.Tag = "Preview_Barcode";
            this.btnPreviewBarcode128.Text = "Xem trước trang in";
            this.btnPreviewBarcode128.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreviewBarcode128.UseVisualStyleBackColor = true;
            this.btnPreviewBarcode128.Visible = false;
            // 
            // btnViewBarcode128
            // 
            this.btnViewBarcode128.Image = ((System.Drawing.Image)(resources.GetObject("btnViewBarcode128.Image")));
            this.btnViewBarcode128.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewBarcode128.Location = new System.Drawing.Point(167, 169);
            this.btnViewBarcode128.Name = "btnViewBarcode128";
            this.btnViewBarcode128.Size = new System.Drawing.Size(112, 37);
            this.btnViewBarcode128.TabIndex = 62;
            this.btnViewBarcode128.Tag = "Create_Barcode";
            this.btnViewBarcode128.Text = "Tạo mã vạch";
            this.btnViewBarcode128.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewBarcode128.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(167, 212);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(112, 37);
            this.btSave.TabIndex = 66;
            this.btSave.Tag = "Save_Barcode";
            this.btSave.Text = "Lưu mã vạch";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // txtMa_Code
            // 
            this.txtMa_Code.bEnabled = true;
            this.txtMa_Code.bIsLookup = false;
            this.txtMa_Code.bReadOnly = false;
            this.txtMa_Code.bRequire = false;
            this.txtMa_Code.KeyFilter = "";
            this.txtMa_Code.Location = new System.Drawing.Point(125, 118);
            this.txtMa_Code.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_Code.MaxLength = 200;
            this.txtMa_Code.Name = "txtMa_Code";
            this.txtMa_Code.Size = new System.Drawing.Size(395, 20);
            this.txtMa_Code.TabIndex = 67;
            this.txtMa_Code.UseAutoFilter = false;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.ForeColor = System.Drawing.Color.Blue;
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(443, 297);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(78, 33);
            this.btClose.TabIndex = 68;
            this.btClose.Tag = "Exit";
            this.btClose.Text = "Thoát";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // frmBarcode_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 355);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.txtMa_Code);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.numGia_Ban);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnViewBarcode128);
            this.Controls.Add(this.btnPreviewBarcode128);
            this.Controls.Add(this.btnViewBarcode);
            this.Controls.Add(this.btnPrintBarcode128);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtTen_Vt);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtTen_Vt2);
            this.Controls.Add(this.lblDien_Giai);
            this.Controls.Add(this.txtMa_Vt);
            this.Controls.Add(this.lblTk);
            this.Controls.Add(this.btgAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBarcode_Edit";
            this.Tag = "Barcode,ESC";
            this.Text = "frmBarcode";
            ((System.ComponentModel.ISupportInitialize)(this.picBarCode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.lblControl lblTk;
		private Epoint.Systems.Controls.txtTextBox txtMa_Vt;
		private Epoint.Systems.Controls.lblControl lblDien_Giai;
        private Epoint.Systems.Controls.txtTextBox txtTen_Vt2;
        private Systems.Controls.lblControl lblControl1;
        private Systems.Controls.txtTextBox txtTen_Vt;
        private System.Windows.Forms.PictureBox picBarCode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnViewBarcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private Systems.Controls.numControl numGia_Ban;
        private Systems.Controls.lblControl lblControl2;
        private System.Windows.Forms.Button btnPrintBarcode128;
        private System.Windows.Forms.Button btnPreviewBarcode128;
        private System.Windows.Forms.Button btnViewBarcode128;
        private System.Windows.Forms.Button btSave;
        private Systems.Controls.txtTextBox txtMa_Code;
        private System.Windows.Forms.Button btClose;
	}
}