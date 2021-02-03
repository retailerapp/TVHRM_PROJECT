namespace Epoint.Systems.Customizes
{
    partial class frmFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboValue = new Epoint.Systems.Controls.cboControl();
            this.cboFuntion = new Epoint.Systems.Controls.cboControl();
            this.cboCompare = new Epoint.Systems.Controls.cboControl();
            this.cboOperator = new Epoint.Systems.Controls.cboControl();
            this.cboLogical = new Epoint.Systems.Controls.cboControl();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.cboColumnList = new Epoint.Systems.Controls.cboControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.lblControl7 = new Epoint.Systems.Controls.lblControl();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.txtExpr = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.btRun = new Epoint.Systems.Controls.btControl();
            this.btExit = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboValue);
            this.groupBox1.Controls.Add(this.cboFuntion);
            this.groupBox1.Controls.Add(this.cboCompare);
            this.groupBox1.Controls.Add(this.cboOperator);
            this.groupBox1.Controls.Add(this.cboLogical);
            this.groupBox1.Controls.Add(this.lblControl3);
            this.groupBox1.Controls.Add(this.cboColumnList);
            this.groupBox1.Controls.Add(this.lblControl2);
            this.groupBox1.Controls.Add(this.lblControl1);
            this.groupBox1.Controls.Add(this.lblControl6);
            this.groupBox1.Controls.Add(this.lblControl7);
            this.groupBox1.Controls.Add(this.lblControl5);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 115);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Công thức";
            // 
            // cboValue
            // 
            this.cboValue.FormattingEnabled = true;
            this.cboValue.InitValue = null;
            this.cboValue.Location = new System.Drawing.Point(225, 40);
            this.cboValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboValue.Name = "cboValue";
            this.cboValue.Size = new System.Drawing.Size(116, 21);
            this.cboValue.strValueList = null;
            this.cboValue.TabIndex = 5;
            this.cboValue.UpperCase = false;
            this.cboValue.UseAutoComplete = false;
            this.cboValue.UseBindingValue = false;
            // 
            // cboFuntion
            // 
            this.cboFuntion.FormattingEnabled = true;
            this.cboFuntion.InitValue = null;
            this.cboFuntion.Items.AddRange(new object[] {
            "LEN()",
            "IIF(expr, truepart, falsepart)",
            "TRIM()",
            "SUBSTRING(expression, start, length)",
            "ABS()",
            "AVG()",
            "MAX()",
            "MIN()",
            "SUM()",
            "COUNT()"});
            this.cboFuntion.Location = new System.Drawing.Point(225, 81);
            this.cboFuntion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboFuntion.Name = "cboFuntion";
            this.cboFuntion.Size = new System.Drawing.Size(116, 21);
            this.cboFuntion.strValueList = null;
            this.cboFuntion.TabIndex = 11;
            this.cboFuntion.UpperCase = false;
            this.cboFuntion.UseAutoComplete = false;
            this.cboFuntion.UseBindingValue = false;
            // 
            // cboCompare
            // 
            this.cboCompare.FormattingEnabled = true;
            this.cboCompare.InitValue = null;
            this.cboCompare.Items.AddRange(new object[] {
            "<",
            ">",
            "=",
            "<>",
            "<=",
            ">=",
            "IN()",
            "LIKE",
            "NOTLIKE"});
            this.cboCompare.Location = new System.Drawing.Point(123, 40);
            this.cboCompare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboCompare.Name = "cboCompare";
            this.cboCompare.Size = new System.Drawing.Size(95, 21);
            this.cboCompare.strValueList = null;
            this.cboCompare.TabIndex = 3;
            this.cboCompare.UpperCase = false;
            this.cboCompare.UseAutoComplete = false;
            this.cboCompare.UseBindingValue = false;
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.InitValue = null;
            this.cboOperator.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/",
            "%"});
            this.cboOperator.Location = new System.Drawing.Point(123, 81);
            this.cboOperator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(95, 21);
            this.cboOperator.strValueList = null;
            this.cboOperator.TabIndex = 9;
            this.cboOperator.UpperCase = false;
            this.cboOperator.UseAutoComplete = false;
            this.cboOperator.UseBindingValue = false;
            // 
            // cboLogical
            // 
            this.cboLogical.FormattingEnabled = true;
            this.cboLogical.InitValue = null;
            this.cboLogical.Items.AddRange(new object[] {
            "()",
            "AND",
            "OR",
            "NOT"});
            this.cboLogical.Location = new System.Drawing.Point(10, 81);
            this.cboLogical.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboLogical.Name = "cboLogical";
            this.cboLogical.Size = new System.Drawing.Size(107, 21);
            this.cboLogical.strValueList = null;
            this.cboLogical.TabIndex = 7;
            this.cboLogical.UpperCase = false;
            this.cboLogical.UseAutoComplete = false;
            this.cboLogical.UseBindingValue = false;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.Location = new System.Drawing.Point(260, 64);
            this.lblControl3.Margin = new System.Windows.Forms.Padding(0);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(29, 13);
            this.lblControl3.TabIndex = 10;
            this.lblControl3.Tag = "Search_What";
            this.lblControl3.Text = "&Hàm";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboColumnList
            // 
            this.cboColumnList.FormattingEnabled = true;
            this.cboColumnList.InitValue = null;
            this.cboColumnList.Items.AddRange(new object[] {
            "()",
            "AND",
            "OR",
            "NOT"});
            this.cboColumnList.Location = new System.Drawing.Point(10, 40);
            this.cboColumnList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboColumnList.Name = "cboColumnList";
            this.cboColumnList.Size = new System.Drawing.Size(107, 21);
            this.cboColumnList.strValueList = null;
            this.cboColumnList.TabIndex = 1;
            this.cboColumnList.UpperCase = false;
            this.cboColumnList.UseAutoComplete = false;
            this.cboColumnList.UseBindingValue = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(141, 64);
            this.lblControl2.Margin = new System.Windows.Forms.Padding(0);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(56, 13);
            this.lblControl2.TabIndex = 8;
            this.lblControl2.Tag = "";
            this.lblControl2.Text = "Phép t&oán";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(18, 64);
            this.lblControl1.Margin = new System.Windows.Forms.Padding(0);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(69, 13);
            this.lblControl1.TabIndex = 6;
            this.lblControl1.Tag = "";
            this.lblControl1.Text = "Phép &Logical";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.Location = new System.Drawing.Point(136, 21);
            this.lblControl6.Margin = new System.Windows.Forms.Padding(0);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(72, 13);
            this.lblControl6.TabIndex = 2;
            this.lblControl6.Tag = "";
            this.lblControl6.Text = "Phép &so sánh";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl7
            // 
            this.lblControl7.AutoEllipsis = true;
            this.lblControl7.AutoSize = true;
            this.lblControl7.BackColor = System.Drawing.Color.Transparent;
            this.lblControl7.Location = new System.Drawing.Point(260, 21);
            this.lblControl7.Margin = new System.Windows.Forms.Padding(0);
            this.lblControl7.Name = "lblControl7";
            this.lblControl7.Size = new System.Drawing.Size(34, 13);
            this.lblControl7.TabIndex = 4;
            this.lblControl7.Tag = "";
            this.lblControl7.Text = "&Giá trị";
            this.lblControl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.Location = new System.Drawing.Point(10, 21);
            this.lblControl5.Margin = new System.Windows.Forms.Padding(0);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(92, 13);
            this.lblControl5.TabIndex = 0;
            this.lblControl5.Tag = "";
            this.lblControl5.Text = "&Trường lọc dữ liệu";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtExpr
            // 
            this.txtExpr.bEnabled = true;
            this.txtExpr.bIsLookup = false;
            this.txtExpr.bReadOnly = false;
            this.txtExpr.bRequire = false;
            this.txtExpr.KeyFilter = "";
            this.txtExpr.Location = new System.Drawing.Point(12, 27);
            this.txtExpr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtExpr.Multiline = true;
            this.txtExpr.Name = "txtExpr";
            this.txtExpr.Size = new System.Drawing.Size(362, 58);
            this.txtExpr.TabIndex = 1;
            this.txtExpr.UseAutoFilter = false;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(9, 9);
            this.lblControl4.Margin = new System.Windows.Forms.Padding(0);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(116, 13);
            this.lblControl4.TabIndex = 0;
            this.lblControl4.Tag = "";
            this.lblControl4.Text = "&Biểu thức điều kiện lọc";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(212, 225);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(78, 23);
            this.btRun.TabIndex = 4;
            this.btRun.Text = "Thực hiệ&n";
            this.btRun.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(296, 225);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(78, 23);
            this.btExit.TabIndex = 5;
            this.btExit.Text = "&Quay ra";
            this.btExit.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(12, 225);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(102, 23);
            this.btCancel.TabIndex = 3;
            this.btCancel.TabStop = false;
            this.btCancel.Text = "Hủ&y điều kiện lọc";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 260);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.txtExpr);
            this.Controls.Add(this.lblControl4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilter";
            this.Text = "frmFilter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.GroupBox groupBox1;
        public Epoint.Systems.Controls.lblControl lblControl2;
        public Epoint.Systems.Controls.lblControl lblControl1;
        private Epoint.Systems.Controls.txtTextBox txtExpr;
        public Epoint.Systems.Controls.lblControl lblControl3;
		public Epoint.Systems.Controls.lblControl lblControl4;
        public Epoint.Systems.Controls.lblControl lblControl5;
        public Epoint.Systems.Controls.lblControl lblControl6;
		public Epoint.Systems.Controls.lblControl lblControl7;
        private Epoint.Systems.Controls.cboControl cboCompare;
		private Epoint.Systems.Controls.cboControl cboValue;
		private Epoint.Systems.Controls.cboControl cboOperator;
		private Epoint.Systems.Controls.cboControl cboLogical;
		private Epoint.Systems.Controls.cboControl cboFuntion;
		private Epoint.Systems.Controls.btControl btRun;
		private Epoint.Systems.Controls.btControl btExit;
		private Epoint.Systems.Controls.cboControl cboColumnList;
		private Epoint.Systems.Controls.btControl btCancel;
    }
}