namespace Epoint.Systems.Customizes
{
	partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.btSearch = new Epoint.Systems.Controls.btControl();
            this.btClose = new Epoint.Systems.Controls.btControl();
            this.tabSearch = new System.Windows.Forms.TabControl();
            this.Page1 = new System.Windows.Forms.TabPage();
            this.chkMatch_Case = new Epoint.Systems.Controls.chkControl();
            this.btOption = new Epoint.Systems.Controls.btControl();
            this.gbOption = new System.Windows.Forms.GroupBox();
            this.rdbEquals = new System.Windows.Forms.RadioButton();
            this.rdbEndwith = new System.Windows.Forms.RadioButton();
            this.rdbStartwith = new System.Windows.Forms.RadioButton();
            this.rdbConstains = new System.Windows.Forms.RadioButton();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.tabSearch.SuspendLayout();
            this.Page1.SuspendLayout();
            this.gbOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearch.Location = new System.Drawing.Point(269, 256);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(81, 24);
            this.btSearch.TabIndex = 1;
            this.btSearch.Text = "&Tìm tiếp";
            this.btSearch.UseVisualStyleBackColor = true;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(354, 256);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(81, 24);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "&Đóng";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // tabSearch
            // 
            this.tabSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSearch.Controls.Add(this.Page1);
            this.tabSearch.Location = new System.Drawing.Point(8, 7);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.SelectedIndex = 0;
            this.tabSearch.Size = new System.Drawing.Size(430, 241);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.TabStop = false;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.chkMatch_Case);
            this.Page1.Controls.Add(this.btOption);
            this.Page1.Controls.Add(this.gbOption);
            this.Page1.Controls.Add(this.cboSearch);
            this.Page1.Controls.Add(this.lblControl1);
            this.Page1.Location = new System.Drawing.Point(4, 22);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(3);
            this.Page1.Size = new System.Drawing.Size(422, 215);
            this.Page1.TabIndex = 0;
            this.Page1.Tag = "Search";
            this.Page1.Text = "Search";
            this.Page1.UseVisualStyleBackColor = true;
            // 
            // chkMatch_Case
            // 
            this.chkMatch_Case.AutoSize = true;
            this.chkMatch_Case.Location = new System.Drawing.Point(56, 184);
            this.chkMatch_Case.Name = "chkMatch_Case";
            this.chkMatch_Case.Size = new System.Drawing.Size(173, 17);
            this.chkMatch_Case.TabIndex = 2;
            this.chkMatch_Case.Tag = "Match_Case";
            this.chkMatch_Case.Text = "Phân biệt chữ thường, chữ hoa";
            this.chkMatch_Case.UseVisualStyleBackColor = true;
            // 
            // btOption
            // 
            this.btOption.Location = new System.Drawing.Point(334, 43);
            this.btOption.Name = "btOption";
            this.btOption.Size = new System.Drawing.Size(74, 23);
            this.btOption.TabIndex = 2;
            this.btOption.TabStop = false;
            this.btOption.Tag = "Option";
            this.btOption.Text = "Option >>";
            this.btOption.UseVisualStyleBackColor = true;
            // 
            // gbOption
            // 
            this.gbOption.Controls.Add(this.rdbEquals);
            this.gbOption.Controls.Add(this.rdbEndwith);
            this.gbOption.Controls.Add(this.rdbStartwith);
            this.gbOption.Controls.Add(this.rdbConstains);
            this.gbOption.Location = new System.Drawing.Point(24, 59);
            this.gbOption.Name = "gbOption";
            this.gbOption.Size = new System.Drawing.Size(265, 111);
            this.gbOption.TabIndex = 1;
            this.gbOption.TabStop = false;
            this.gbOption.Text = "Option";
            this.gbOption.Visible = false;
            // 
            // rdbEquals
            // 
            this.rdbEquals.AutoSize = true;
            this.rdbEquals.Location = new System.Drawing.Point(31, 89);
            this.rdbEquals.Name = "rdbEquals";
            this.rdbEquals.Size = new System.Drawing.Size(93, 17);
            this.rdbEquals.TabIndex = 3;
            this.rdbEquals.Text = "Tìm chính xác";
            this.rdbEquals.UseVisualStyleBackColor = true;
            // 
            // rdbEndwith
            // 
            this.rdbEndwith.AutoSize = true;
            this.rdbEndwith.Location = new System.Drawing.Point(31, 66);
            this.rdbEndwith.Name = "rdbEndwith";
            this.rdbEndwith.Size = new System.Drawing.Size(82, 17);
            this.rdbEndwith.TabIndex = 2;
            this.rdbEndwith.Text = "Kết thúc với";
            this.rdbEndwith.UseVisualStyleBackColor = true;
            // 
            // rdbStartwith
            // 
            this.rdbStartwith.AutoSize = true;
            this.rdbStartwith.Location = new System.Drawing.Point(31, 43);
            this.rdbStartwith.Name = "rdbStartwith";
            this.rdbStartwith.Size = new System.Drawing.Size(80, 17);
            this.rdbStartwith.TabIndex = 1;
            this.rdbStartwith.Text = "Bắt đầu với";
            this.rdbStartwith.UseVisualStyleBackColor = true;
            // 
            // rdbConstains
            // 
            this.rdbConstains.AutoSize = true;
            this.rdbConstains.Checked = true;
            this.rdbConstains.Location = new System.Drawing.Point(31, 20);
            this.rdbConstains.Name = "rdbConstains";
            this.rdbConstains.Size = new System.Drawing.Size(65, 17);
            this.rdbConstains.TabIndex = 0;
            this.rdbConstains.TabStop = true;
            this.rdbConstains.Text = "Có trong";
            this.rdbConstains.UseVisualStyleBackColor = true;
            // 
            // cboSearch
            // 
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(78, 16);
            this.cboSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(330, 21);
            this.cboSearch.TabIndex = 0;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(21, 19);
            this.lblControl1.Margin = new System.Windows.Forms.Padding(0);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(49, 13);
            this.lblControl1.TabIndex = 0;
            this.lblControl1.Tag = "Search_What";
            this.lblControl1.Text = "Tìm kiếm";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSearch
            // 
            this.AcceptButton = this.btSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(445, 290);
            this.Controls.Add(this.tabSearch);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.TopMost = true;
            this.tabSearch.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.gbOption.ResumeLayout(false);
            this.gbOption.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		public Epoint.Systems.Controls.btControl btSearch;
		public Epoint.Systems.Controls.btControl btClose;
		public System.Windows.Forms.TabControl tabSearch;
		public System.Windows.Forms.TabPage Page1;
		public System.Windows.Forms.GroupBox gbOption;
		public System.Windows.Forms.RadioButton rdbEquals;
		public System.Windows.Forms.RadioButton rdbEndwith;
		public System.Windows.Forms.RadioButton rdbStartwith;
		public System.Windows.Forms.RadioButton rdbConstains;
		public System.Windows.Forms.ComboBox cboSearch;
		public Epoint.Systems.Controls.lblControl lblControl1;
        public Epoint.Systems.Controls.btControl btOption;
        public Epoint.Systems.Controls.chkControl chkMatch_Case;
	}
}