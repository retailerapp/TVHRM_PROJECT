namespace Epoint.Modules.HRM
{
    partial class frmQLF_Edit 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLF_Edit));
            this.dteNgay_Dat = new Epoint.Systems.Controls.txtDateTime();
            this.lbtTen_CbNv = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblNgay_Begin = new Epoint.Systems.Controls.lblControl();
            this.lblMa_CbNv = new Epoint.Systems.Controls.lblControl();
            this.txtMa_CbNv = new Epoint.Systems.Controls.txtTextLookup();
            this.txtQUALIFY_ID = new Epoint.Systems.Controls.txtTextLookup();
            this.lblMa_Pl = new Epoint.Systems.Controls.lblControl();
            this.lblTen_Pl = new Epoint.Systems.Controls.lblControl();
            this.txtQUALIFY_Name = new Epoint.Systems.Controls.txtTextBox();
            this.SuspendLayout();
            // 
            // dteNgay_Dat
            // 
            this.dteNgay_Dat.bAllowEmpty = true;
            this.dteNgay_Dat.bRequire = false;
            this.dteNgay_Dat.bSelectOnFocus = false;
            this.dteNgay_Dat.bShowDateTimePicker = true;
            this.dteNgay_Dat.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Dat.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Dat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Dat.Location = new System.Drawing.Point(133, 101);
            this.dteNgay_Dat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dteNgay_Dat.Mask = "00/00/0000";
            this.dteNgay_Dat.Name = "dteNgay_Dat";
            this.dteNgay_Dat.Size = new System.Drawing.Size(74, 20);
            this.dteNgay_Dat.TabIndex = 4;
            // 
            // lbtTen_CbNv
            // 
            this.lbtTen_CbNv.AutoEllipsis = true;
            this.lbtTen_CbNv.AutoSize = true;
            this.lbtTen_CbNv.BackColor = System.Drawing.Color.Transparent;
            this.lbtTen_CbNv.ForeColor = System.Drawing.Color.Blue;
            this.lbtTen_CbNv.Location = new System.Drawing.Point(302, 33);
            this.lbtTen_CbNv.Name = "lbtTen_CbNv";
            this.lbtTen_CbNv.Size = new System.Drawing.Size(59, 13);
            this.lbtTen_CbNv.TabIndex = 128;
            this.lbtTen_CbNv.Text = "Ten_CbNv";
            this.lbtTen_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(378, 150);
            this.btgAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 11;
            // 
            // lblNgay_Begin
            // 
            this.lblNgay_Begin.AutoEllipsis = true;
            this.lblNgay_Begin.AutoSize = true;
            this.lblNgay_Begin.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay_Begin.Location = new System.Drawing.Point(24, 104);
            this.lblNgay_Begin.Name = "lblNgay_Begin";
            this.lblNgay_Begin.Size = new System.Drawing.Size(72, 13);
            this.lblNgay_Begin.TabIndex = 125;
            this.lblNgay_Begin.Tag = "Ngay_Begin";
            this.lblNgay_Begin.Text = "Ngày bắt đầu";
            this.lblNgay_Begin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMa_CbNv
            // 
            this.lblMa_CbNv.AutoEllipsis = true;
            this.lblMa_CbNv.AutoSize = true;
            this.lblMa_CbNv.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_CbNv.Location = new System.Drawing.Point(24, 33);
            this.lblMa_CbNv.Name = "lblMa_CbNv";
            this.lblMa_CbNv.Size = new System.Drawing.Size(72, 13);
            this.lblMa_CbNv.TabIndex = 120;
            this.lblMa_CbNv.Tag = "Ma_CbNv";
            this.lblMa_CbNv.Text = "Mã nhân viên";
            this.lblMa_CbNv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMa_CbNv
            // 
            this.txtMa_CbNv.bEnabled = true;
            this.txtMa_CbNv.bIsLookup = false;
            this.txtMa_CbNv.bReadOnly = false;
            this.txtMa_CbNv.bRequire = false;
            this.txtMa_CbNv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_CbNv.ColumnsView = null;
            this.txtMa_CbNv.CtrlDepend = null;
            this.txtMa_CbNv.KeyFilter = "Ma_CbNv";
            this.txtMa_CbNv.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtMa_CbNv.ListFilter = new string[0];
            this.txtMa_CbNv.Location = new System.Drawing.Point(133, 30);
            this.txtMa_CbNv.LookupKeyFilter = "";
            this.txtMa_CbNv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_CbNv.Name = "txtMa_CbNv";
            this.txtMa_CbNv.Size = new System.Drawing.Size(164, 20);
            this.txtMa_CbNv.TabIndex = 0;
            this.txtMa_CbNv.UseAutoFilter = true;
            // 
            // txtQUALIFY_ID
            // 
            this.txtQUALIFY_ID.bEnabled = true;
            this.txtQUALIFY_ID.bIsLookup = false;
            this.txtQUALIFY_ID.bReadOnly = false;
            this.txtQUALIFY_ID.bRequire = false;
            this.txtQUALIFY_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQUALIFY_ID.ColumnsView = null;
            this.txtQUALIFY_ID.CtrlDepend = null;
            this.txtQUALIFY_ID.KeyFilter = "QUALIFY_ID";
            this.txtQUALIFY_ID.ListControlFilter = new System.Windows.Forms.Control[0];
            this.txtQUALIFY_ID.ListFilter = new string[0];
            this.txtQUALIFY_ID.Location = new System.Drawing.Point(133, 53);
            this.txtQUALIFY_ID.LookupKeyFilter = "";
            this.txtQUALIFY_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtQUALIFY_ID.Name = "txtQUALIFY_ID";
            this.txtQUALIFY_ID.Size = new System.Drawing.Size(164, 20);
            this.txtQUALIFY_ID.TabIndex = 1;
            this.txtQUALIFY_ID.UseAutoFilter = false;
            // 
            // lblMa_Pl
            // 
            this.lblMa_Pl.AutoEllipsis = true;
            this.lblMa_Pl.AutoSize = true;
            this.lblMa_Pl.BackColor = System.Drawing.Color.Transparent;
            this.lblMa_Pl.Location = new System.Drawing.Point(24, 56);
            this.lblMa_Pl.Name = "lblMa_Pl";
            this.lblMa_Pl.Size = new System.Drawing.Size(45, 13);
            this.lblMa_Pl.TabIndex = 142;
            this.lblMa_Pl.Tag = "";
            this.lblMa_Pl.Text = "Mã QLF";
            this.lblMa_Pl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTen_Pl
            // 
            this.lblTen_Pl.AutoEllipsis = true;
            this.lblTen_Pl.AutoSize = true;
            this.lblTen_Pl.BackColor = System.Drawing.Color.Transparent;
            this.lblTen_Pl.Location = new System.Drawing.Point(24, 79);
            this.lblTen_Pl.Name = "lblTen_Pl";
            this.lblTen_Pl.Size = new System.Drawing.Size(26, 13);
            this.lblTen_Pl.TabIndex = 144;
            this.lblTen_Pl.Tag = "";
            this.lblTen_Pl.Text = "Tên";
            this.lblTen_Pl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQUALIFY_Name
            // 
            this.txtQUALIFY_Name.bEnabled = true;
            this.txtQUALIFY_Name.bIsLookup = false;
            this.txtQUALIFY_Name.bReadOnly = false;
            this.txtQUALIFY_Name.bRequire = false;
            this.txtQUALIFY_Name.KeyFilter = "";
            this.txtQUALIFY_Name.Location = new System.Drawing.Point(133, 76);
            this.txtQUALIFY_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtQUALIFY_Name.Name = "txtQUALIFY_Name";
            this.txtQUALIFY_Name.Size = new System.Drawing.Size(415, 20);
            this.txtQUALIFY_Name.TabIndex = 2;
            this.txtQUALIFY_Name.UseAutoFilter = false;
            // 
            // frmQLF_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 197);
            this.Controls.Add(this.lblTen_Pl);
            this.Controls.Add(this.txtQUALIFY_Name);
            this.Controls.Add(this.txtQUALIFY_ID);
            this.Controls.Add(this.lblMa_Pl);
            this.Controls.Add(this.txtMa_CbNv);
            this.Controls.Add(this.dteNgay_Dat);
            this.Controls.Add(this.lbtTen_CbNv);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblNgay_Begin);
            this.Controls.Add(this.lblMa_CbNv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQLF_Edit";
            this.Text = "frmQLF_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Epoint.Systems.Controls.txtDateTime dteNgay_Dat;
		private Epoint.Systems.Controls.lblControl lbtTen_CbNv;
        public Epoint.Systems.Customizes.btgAccept btgAccept;
        private Epoint.Systems.Controls.lblControl lblNgay_Begin;
        private Epoint.Systems.Controls.lblControl lblMa_CbNv;
        private Systems.Controls.txtTextLookup txtMa_CbNv;
        private Systems.Controls.txtTextLookup txtQUALIFY_ID;
        private Systems.Controls.lblControl lblMa_Pl;
        private Systems.Controls.lblControl lblTen_Pl;
        private Systems.Controls.txtTextBox txtQUALIFY_Name;

	}
}