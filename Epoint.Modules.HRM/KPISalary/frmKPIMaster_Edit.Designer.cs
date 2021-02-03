namespace Epoint.Modules.KPI
{
    partial class frmKPIMaster_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKPIMaster_Edit));
            this.dteEndDate = new Epoint.Systems.Controls.txtDateTime();
            this.dteStartDate = new Epoint.Systems.Controls.txtDateTime();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblGhi_Chu = new Epoint.Systems.Controls.lblControl();
            this.lblNgay_End = new Epoint.Systems.Controls.lblControl();
            this.lblNgay_Begin = new Epoint.Systems.Controls.lblControl();
            this.txtGhi_Chu = new Epoint.Systems.Controls.txtTextBox();
            this.lblKhoa_Hoc = new Epoint.Systems.Controls.lblControl();
            this.txtDescr = new Epoint.Systems.Controls.txtTextBox();
            this.lblMa_CbNv = new Epoint.Systems.Controls.lblControl();
            this.txtKPIId = new Epoint.Systems.Controls.txtTextLookup();
            this.SuspendLayout();
            // 
            // dteEndDate
            // 
            this.dteEndDate.bAllowEmpty = true;
            this.dteEndDate.bRequire = false;
            this.dteEndDate.bSelectOnFocus = false;
            this.dteEndDate.bShowDateTimePicker = true;
            this.dteEndDate.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteEndDate.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteEndDate.Location = new System.Drawing.Point(133, 92);
            this.dteEndDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteEndDate.Mask = "00/00/0000";
            this.dteEndDate.Name = "dteEndDate";
            this.dteEndDate.Size = new System.Drawing.Size(120, 20);
            this.dteEndDate.TabIndex = 7;
            // 
            // dteStartDate
            // 
            this.dteStartDate.bAllowEmpty = true;
            this.dteStartDate.bRequire = false;
            this.dteStartDate.bSelectOnFocus = false;
            this.dteStartDate.bShowDateTimePicker = true;
            this.dteStartDate.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteStartDate.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteStartDate.Location = new System.Drawing.Point(133, 69);
            this.dteStartDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteStartDate.Mask = "00/00/0000";
            this.dteStartDate.Name = "dteStartDate";
            this.dteStartDate.Size = new System.Drawing.Size(120, 20);
            this.dteStartDate.TabIndex = 6;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(378, 260);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 34);
            this.btgAccept.TabIndex = 9;
            // 
            // lblGhi_Chu
            // 
            this.lblGhi_Chu.AutoEllipsis = true;
            this.lblGhi_Chu.AutoSize = true;
            this.lblGhi_Chu.BackColor = System.Drawing.Color.Transparent;
            this.lblGhi_Chu.Location = new System.Drawing.Point(24, 216);
            this.lblGhi_Chu.Name = "lblGhi_Chu";
            this.lblGhi_Chu.Size = new System.Drawing.Size(44, 13);
            this.lblGhi_Chu.TabIndex = 123;
            this.lblGhi_Chu.Tag = "Ghi_Chu";
            this.lblGhi_Chu.Text = "Ghi chú";
            this.lblGhi_Chu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_End
            // 
            this.lblNgay_End.AutoEllipsis = true;
            this.lblNgay_End.AutoSize = true;
            this.lblNgay_End.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_End.Location = new System.Drawing.Point(24, 95);
            this.lblNgay_End.Name = "lblNgay_End";
            this.lblNgay_End.Size = new System.Drawing.Size(74, 13);
            this.lblNgay_End.TabIndex = 126;
            this.lblNgay_End.Tag = "Ngay_End";
            this.lblNgay_End.Text = "Ngày kết thúc";
            this.lblNgay_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgay_Begin
            // 
            this.lblNgay_Begin.AutoEllipsis = true;
            this.lblNgay_Begin.AutoSize = true;
            this.lblNgay_Begin.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Begin.Location = new System.Drawing.Point(24, 72);
            this.lblNgay_Begin.Name = "lblNgay_Begin";
            this.lblNgay_Begin.Size = new System.Drawing.Size(72, 13);
            this.lblNgay_Begin.TabIndex = 125;
            this.lblNgay_Begin.Tag = "Ngay_Begin";
            this.lblNgay_Begin.Text = "Ngày bắt đầu";
            this.lblNgay_Begin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhi_Chu
            // 
            this.txtGhi_Chu.bEnabled = true;
            this.txtGhi_Chu.bIsLookup = false;
            this.txtGhi_Chu.bReadOnly = false;
            this.txtGhi_Chu.bRequire = false;
            this.txtGhi_Chu.KeyFilter = "";
            this.txtGhi_Chu.Location = new System.Drawing.Point(133, 206);
            this.txtGhi_Chu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtGhi_Chu.Multiline = true;
            this.txtGhi_Chu.Name = "txtGhi_Chu";
            this.txtGhi_Chu.Size = new System.Drawing.Size(415, 40);
            this.txtGhi_Chu.TabIndex = 8;
            this.txtGhi_Chu.UseAutoFilter = false;
            // 
            // lblKhoa_Hoc
            // 
            this.lblKhoa_Hoc.AutoEllipsis = true;
            this.lblKhoa_Hoc.AutoSize = true;
            this.lblKhoa_Hoc.BackColor = System.Drawing.Color.Transparent;
            this.lblKhoa_Hoc.Location = new System.Drawing.Point(24, 48);
            this.lblKhoa_Hoc.Name = "lblKhoa_Hoc";
            this.lblKhoa_Hoc.Size = new System.Drawing.Size(48, 13);
            this.lblKhoa_Hoc.TabIndex = 121;
            this.lblKhoa_Hoc.Tag = "Descr";
            this.lblKhoa_Hoc.Text = "Diễn giải";
            this.lblKhoa_Hoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescr
            // 
            this.txtDescr.bEnabled = true;
            this.txtDescr.bIsLookup = false;
            this.txtDescr.bReadOnly = false;
            this.txtDescr.bRequire = false;
            this.txtDescr.KeyFilter = "";
            this.txtDescr.Location = new System.Drawing.Point(133, 45);
            this.txtDescr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(415, 20);
            this.txtDescr.TabIndex = 1;
            this.txtDescr.UseAutoFilter = false;
            // 
            // lblMa_CbNv
            // 
            this.lblMa_CbNv.AutoEllipsis = true;
            this.lblMa_CbNv.AutoSize = true;
            this.lblMa_CbNv.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_CbNv.Location = new System.Drawing.Point(24, 25);
            this.lblMa_CbNv.Name = "lblMa_CbNv";
            this.lblMa_CbNv.Size = new System.Drawing.Size(35, 13);
            this.lblMa_CbNv.TabIndex = 120;
            this.lblMa_CbNv.Tag = "KPIID";
            this.lblMa_CbNv.Text = "KPIID";
            this.lblMa_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKPIId
            // 
            this.txtKPIId.bEnabled = true;
            this.txtKPIId.bIsLookup = false;
            this.txtKPIId.bReadOnly = false;
            this.txtKPIId.bRequire = false;
            this.txtKPIId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKPIId.ColumnsView = null;
            this.txtKPIId.CtrlDepend = null;
            this.txtKPIId.KeyFilter = "Ma_CbNv";
            this.txtKPIId.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtKPIId.ListFilter = new string[0];
            this.txtKPIId.Location = new System.Drawing.Point(133, 22);
            this.txtKPIId.LookupKeyFilter = "";
            this.txtKPIId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtKPIId.Name = "txtKPIId";
            this.txtKPIId.Size = new System.Drawing.Size(120, 20);
            this.txtKPIId.TabIndex = 0;
            this.txtKPIId.UseAutoFilter = true;
            // 
            // frmKPIMaster_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 304);
            this.Controls.Add(this.txtKPIId);
            this.Controls.Add(this.dteEndDate);
            this.Controls.Add(this.dteStartDate);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblGhi_Chu);
            this.Controls.Add(this.lblNgay_End);
            this.Controls.Add(this.lblNgay_Begin);
            this.Controls.Add(this.txtGhi_Chu);
            this.Controls.Add(this.lblKhoa_Hoc);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.lblMa_CbNv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKPIMaster_Edit";
            this.Text = "frmDaoTao_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private Epoint.Systems.Controls.txtDateTime dteEndDate;
		private Epoint.Systems.Controls.txtDateTime dteStartDate;
		public Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.lblControl lblGhi_Chu;
		private Epoint.Systems.Controls.lblControl lblNgay_End;
		private Epoint.Systems.Controls.lblControl lblNgay_Begin;
		private Epoint.Systems.Controls.txtTextBox txtGhi_Chu;
		private Epoint.Systems.Controls.lblControl lblKhoa_Hoc;
		private Epoint.Systems.Controls.txtTextBox txtDescr;
        private Epoint.Systems.Controls.lblControl lblMa_CbNv;
        private Systems.Controls.txtTextLookup txtKPIId;

	}
}