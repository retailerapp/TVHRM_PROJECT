namespace Epoint.Modules.KPI
{
    partial class frmKPIMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKPIMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btImport = new Epoint.Systems.Customizes.btFilter();
            this.btFillterData = new Epoint.Systems.Customizes.btPreview();
            this.lbGia = new Epoint.Systems.Controls.lblControl();
            this.dteNgay_Kt = new Epoint.Systems.Controls.dteDateTime();
            this.dteNgay_BD = new Epoint.Systems.Controls.dteDateTime();
            this.lbNgay_Ap = new Epoint.Systems.Controls.lblControl();
            this.splitConFull = new System.Windows.Forms.SplitContainer();
            this.chkIsOverride = new System.Windows.Forms.CheckBox();
            this.pnPXK = new System.Windows.Forms.Panel();
            this.dgvKPIHeader = new Epoint.Systems.Controls.dgvGridControl();
            this.tabKPI = new Epoint.Systems.Controls.tabControl();
            this.tpDetail = new System.Windows.Forms.TabPage();
            this.dgvKPIDetail = new Epoint.Systems.Controls.dgvControl();
            this.spContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBreak = new System.Windows.Forms.GroupBox();
            this.dgvDiscBreak = new Epoint.Systems.Controls.dgvControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitConFull)).BeginInit();
            this.splitConFull.Panel1.SuspendLayout();
            this.splitConFull.Panel2.SuspendLayout();
            this.splitConFull.SuspendLayout();
            this.pnPXK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPIHeader)).BeginInit();
            this.tabKPI.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPIDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spContainer2)).BeginInit();
            this.spContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscBreak)).BeginInit();
            this.SuspendLayout();
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImport.Image = ((System.Drawing.Image)(resources.GetObject("btImport.Image")));
            this.btImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImport.Location = new System.Drawing.Point(786, 3);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(119, 29);
            this.btImport.TabIndex = 73;
            this.btImport.Tag = "";
            this.btImport.Text = "&Import";
            this.btImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btImport.UseVisualStyleBackColor = true;
            // 
            // btFillterData
            // 
            this.btFillterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFillterData.Image = ((System.Drawing.Image)(resources.GetObject("btFillterData.Image")));
            this.btFillterData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFillterData.Location = new System.Drawing.Point(452, 3);
            this.btFillterData.Name = "btFillterData";
            this.btFillterData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btFillterData.Size = new System.Drawing.Size(121, 27);
            this.btFillterData.TabIndex = 72;
            this.btFillterData.Tag = "Preview";
            this.btFillterData.Text = "Lọc dữ liệu";
            this.btFillterData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFillterData.UseVisualStyleBackColor = true;
            // 
            // lbGia
            // 
            this.lbGia.AutoEllipsis = true;
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.Location = new System.Drawing.Point(220, 12);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(74, 13);
            this.lbGia.TabIndex = 71;
            this.lbGia.Tag = "Ngay_Kt";
            this.lbGia.Text = "Ngày kết thúc";
            this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dteNgay_Kt
            // 
            this.dteNgay_Kt.bAllowEmpty = true;
            this.dteNgay_Kt.bRequire = false;
            this.dteNgay_Kt.bSelectOnFocus = false;
            this.dteNgay_Kt.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteNgay_Kt.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Kt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Kt.Location = new System.Drawing.Point(325, 10);
            this.dteNgay_Kt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Kt.Mask = "00/00/0000";
            this.dteNgay_Kt.Name = "dteNgay_Kt";
            this.dteNgay_Kt.SelectedText = "";
            this.dteNgay_Kt.Size = new System.Drawing.Size(115, 20);
            this.dteNgay_Kt.TabIndex = 69;
            // 
            // dteNgay_BD
            // 
            this.dteNgay_BD.bAllowEmpty = true;
            this.dteNgay_BD.bRequire = false;
            this.dteNgay_BD.bSelectOnFocus = false;
            this.dteNgay_BD.Culture = new System.Globalization.CultureInfo("en-US");
            this.dteNgay_BD.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_BD.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_BD.Location = new System.Drawing.Point(100, 10);
            this.dteNgay_BD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_BD.Mask = "00/00/0000";
            this.dteNgay_BD.Name = "dteNgay_BD";
            this.dteNgay_BD.SelectedText = "";
            this.dteNgay_BD.Size = new System.Drawing.Size(121, 20);
            this.dteNgay_BD.TabIndex = 68;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Ap.Location = new System.Drawing.Point(12, 13);
            this.lbNgay_Ap.Name = "lbNgay_Ap";
            this.lbNgay_Ap.Size = new System.Drawing.Size(72, 13);
            this.lbNgay_Ap.TabIndex = 70;
            this.lbNgay_Ap.Tag = "Ngay_BD";
            this.lbNgay_Ap.Text = "Ngày bắt đầu";
            this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitConFull
            // 
            this.splitConFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConFull.Location = new System.Drawing.Point(0, 0);
            this.splitConFull.Name = "splitConFull";
            this.splitConFull.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitConFull.Panel1
            // 
            this.splitConFull.Panel1.Controls.Add(this.chkIsOverride);
            this.splitConFull.Panel1.Controls.Add(this.pnPXK);
            this.splitConFull.Panel1.Controls.Add(this.btImport);
            this.splitConFull.Panel1.Controls.Add(this.btFillterData);
            this.splitConFull.Panel1.Controls.Add(this.lbNgay_Ap);
            this.splitConFull.Panel1.Controls.Add(this.lbGia);
            this.splitConFull.Panel1.Controls.Add(this.dteNgay_BD);
            this.splitConFull.Panel1.Controls.Add(this.dteNgay_Kt);
            // 
            // splitConFull.Panel2
            // 
            this.splitConFull.Panel2.Controls.Add(this.tabKPI);
            this.splitConFull.Size = new System.Drawing.Size(909, 569);
            this.splitConFull.SplitterDistance = 222;
            this.splitConFull.TabIndex = 3;
            // 
            // chkIsOverride
            // 
            this.chkIsOverride.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsOverride.AutoSize = true;
            this.chkIsOverride.Checked = true;
            this.chkIsOverride.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsOverride.Location = new System.Drawing.Point(636, 13);
            this.chkIsOverride.Name = "chkIsOverride";
            this.chkIsOverride.Size = new System.Drawing.Size(144, 17);
            this.chkIsOverride.TabIndex = 76;
            this.chkIsOverride.Text = "Ghi đè lên dữ liệu có sẵn";
            this.chkIsOverride.UseVisualStyleBackColor = true;
            // 
            // pnPXK
            // 
            this.pnPXK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnPXK.Controls.Add(this.dgvKPIHeader);
            this.pnPXK.Location = new System.Drawing.Point(0, 36);
            this.pnPXK.Name = "pnPXK";
            this.pnPXK.Size = new System.Drawing.Size(906, 184);
            this.pnPXK.TabIndex = 74;
            // 
            // dgvKPIHeader
            // 
            this.dgvKPIHeader.AllowEdit = false;
            this.dgvKPIHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKPIHeader.Location = new System.Drawing.Point(0, 0);
            this.dgvKPIHeader.Name = "dgvDiscountProg";
            this.dgvKPIHeader.Size = new System.Drawing.Size(906, 184);
            this.dgvKPIHeader.strZone = "";
            this.dgvKPIHeader.TabIndex = 4;
            // 
            // tabKPI
            // 
            this.tabKPI.Controls.Add(this.tpDetail);
            this.tabKPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabKPI.Location = new System.Drawing.Point(0, 0);
            this.tabKPI.Name = "tabKPI";
            this.tabKPI.SelectedIndex = 0;
            this.tabKPI.Size = new System.Drawing.Size(909, 343);
            this.tabKPI.TabIndex = 2;
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.dgvKPIDetail);
            this.tpDetail.Location = new System.Drawing.Point(4, 22);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(901, 317);
            this.tpDetail.TabIndex = 3;
            this.tpDetail.Text = "KPI Detail";
            this.tpDetail.UseVisualStyleBackColor = true;
            // 
            // dgvKPIDetail
            // 
            this.dgvKPIDetail.AllowUserToAddRows = false;
            this.dgvKPIDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKPIDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKPIDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvKPIDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKPIDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKPIDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKPIDetail.EnableHeadersVisualStyles = false;
            this.dgvKPIDetail.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvKPIDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvKPIDetail.MultiSelect = false;
            this.dgvKPIDetail.Name = "dgvKPIDetail";
            this.dgvKPIDetail.ReadOnly = true;
            this.dgvKPIDetail.Size = new System.Drawing.Size(901, 317);
            this.dgvKPIDetail.strZone = "";
            this.dgvKPIDetail.TabIndex = 1;
            // 
            // spContainer2
            // 
            this.spContainer2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.spContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContainer2.Location = new System.Drawing.Point(0, 0);
            this.spContainer2.Name = "spContainer2";
            this.spContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.spContainer2.Size = new System.Drawing.Size(453, 246);
            this.spContainer2.SplitterDistance = 127;
            this.spContainer2.TabIndex = 4;
            // 
            // groupBreak
            // 
            this.groupBreak.BackColor = System.Drawing.SystemColors.Window;
            this.groupBreak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBreak.Location = new System.Drawing.Point(0, 0);
            this.groupBreak.Name = "groupBreak";
            this.groupBreak.Size = new System.Drawing.Size(438, 246);
            this.groupBreak.TabIndex = 1;
            this.groupBreak.TabStop = false;
            // 
            // dgvDiscBreak
            // 
            this.dgvDiscBreak.AllowUserToAddRows = false;
            this.dgvDiscBreak.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDiscBreak.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiscBreak.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiscBreak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscBreak.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiscBreak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiscBreak.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDiscBreak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiscBreak.EnableHeadersVisualStyles = false;
            this.dgvDiscBreak.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDiscBreak.Location = new System.Drawing.Point(3, 16);
            this.dgvDiscBreak.MultiSelect = false;
            this.dgvDiscBreak.Name = "dgvDiscBreak";
            this.dgvDiscBreak.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiscBreak.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDiscBreak.Size = new System.Drawing.Size(432, 227);
            this.dgvDiscBreak.strZone = "";
            this.dgvDiscBreak.TabIndex = 0;
            // 
            // frmKPIMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 569);
            this.Controls.Add(this.splitConFull);
            this.Name = "frmKPIMaster";
            this.Text = "frmDiscount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitConFull.Panel1.ResumeLayout(false);
            this.splitConFull.Panel1.PerformLayout();
            this.splitConFull.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitConFull)).EndInit();
            this.splitConFull.ResumeLayout(false);
            this.pnPXK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPIHeader)).EndInit();
            this.tabKPI.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPIDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spContainer2)).EndInit();
            this.spContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscBreak)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Systems.Controls.lblControl lbGia;
        private Systems.Controls.dteDateTime dteNgay_Kt;
        private Systems.Controls.dteDateTime dteNgay_BD;
        private Systems.Controls.lblControl lbNgay_Ap;
        private Systems.Customizes.btPreview btFillterData;
        protected Systems.Customizes.btFilter btImport;
        private System.Windows.Forms.SplitContainer splitConFull;
        private System.Windows.Forms.Panel pnPXK;
        private Systems.Controls.dgvGridControl dgvKPIHeader;
        private System.Windows.Forms.CheckBox chkIsOverride;
        private Systems.Controls.tabControl tabKPI;
        private System.Windows.Forms.TabPage tpDetail;
        private Systems.Controls.dgvControl dgvKPIDetail;
        private System.Windows.Forms.SplitContainer spContainer2;
        private System.Windows.Forms.GroupBox groupBreak;
        private Systems.Controls.dgvControl dgvDiscBreak;
    }
}