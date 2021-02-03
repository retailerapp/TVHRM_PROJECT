namespace Epoint.Controllers
{
	partial class frmWorkingYear
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
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lblNam_Current = new Epoint.Systems.Controls.lblControl();
            this.lblNam_Next = new Epoint.Systems.Controls.lblControl();
            this.lblCreate_Nam_Next = new Epoint.Systems.Controls.lblControl();
            this.txtNam_Current = new Epoint.Systems.Controls.txtTextLookup();
            this.txtNam_Next = new Epoint.Systems.Controls.txtTextLookup();
            this.grbControl1 = new Epoint.Systems.Controls.grbControl();
            this.txtTh_Bd_Ht = new Epoint.Systems.Controls.txtTextLookup();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.grbControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(427, 187);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 33);
            this.btgAccept.TabIndex = 1;
            // 
            // lblNam_Current
            // 
            this.lblNam_Current.AutoEllipsis = true;
            this.lblNam_Current.AutoSize = true;
            this.lblNam_Current.BackColor = System.Drawing.Color.Transparent;
            this.lblNam_Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNam_Current.ForeColor = System.Drawing.Color.Blue;
            this.lblNam_Current.Location = new System.Drawing.Point(15, 31);
            this.lblNam_Current.Name = "lblNam_Current";
            this.lblNam_Current.Size = new System.Drawing.Size(108, 13);
            this.lblNam_Current.TabIndex = 59;
            this.lblNam_Current.Tag = "Nam_Current";
            this.lblNam_Current.Text = "Năm làm việc hiện tại";
            this.lblNam_Current.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNam_Next
            // 
            this.lblNam_Next.AutoEllipsis = true;
            this.lblNam_Next.AutoSize = true;
            this.lblNam_Next.BackColor = System.Drawing.Color.Transparent;
            this.lblNam_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNam_Next.ForeColor = System.Drawing.Color.Blue;
            this.lblNam_Next.Location = new System.Drawing.Point(15, 64);
            this.lblNam_Next.Name = "lblNam_Next";
            this.lblNam_Next.Size = new System.Drawing.Size(115, 13);
            this.lblNam_Next.TabIndex = 60;
            this.lblNam_Next.Tag = "Nam_Next";
            this.lblNam_Next.Text = "Năm làm việc tiếp theo";
            this.lblNam_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreate_Nam_Next
            // 
            this.lblCreate_Nam_Next.AutoEllipsis = true;
            this.lblCreate_Nam_Next.AutoSize = true;
            this.lblCreate_Nam_Next.BackColor = System.Drawing.Color.Transparent;
            this.lblCreate_Nam_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate_Nam_Next.ForeColor = System.Drawing.Color.Blue;
            this.lblCreate_Nam_Next.Location = new System.Drawing.Point(268, 63);
            this.lblCreate_Nam_Next.Name = "lblCreate_Nam_Next";
            this.lblCreate_Nam_Next.Size = new System.Drawing.Size(298, 13);
            this.lblCreate_Nam_Next.TabIndex = 62;
            this.lblCreate_Nam_Next.Tag = "";
            this.lblCreate_Nam_Next.Text = "* Để tạo năm làm việc tiếp theo. Nhấn nút Đồng ý !";
            this.lblCreate_Nam_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNam_Current
            // 
            this.txtNam_Current.bEnabled = true;
            this.txtNam_Current.bIsLookup = false;
            this.txtNam_Current.bReadOnly = false;
            this.txtNam_Current.bRequire = false;
            this.txtNam_Current.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNam_Current.ColumnsView = null;
            this.txtNam_Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam_Current.ForeColor = System.Drawing.Color.Blue;
            this.txtNam_Current.KeyFilter = "";
            this.txtNam_Current.Location = new System.Drawing.Point(177, 27);
            this.txtNam_Current.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNam_Current.Name = "txtNam_Current";
            this.txtNam_Current.Size = new System.Drawing.Size(76, 23);
            this.txtNam_Current.TabIndex = 0;
            this.txtNam_Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam_Current.UseAutoFilter = false;
            // 
            // txtNam_Next
            // 
            this.txtNam_Next.bEnabled = true;
            this.txtNam_Next.bIsLookup = false;
            this.txtNam_Next.bReadOnly = false;
            this.txtNam_Next.bRequire = false;
            this.txtNam_Next.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNam_Next.ColumnsView = null;
            this.txtNam_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam_Next.ForeColor = System.Drawing.Color.Blue;
            this.txtNam_Next.KeyFilter = "";
            this.txtNam_Next.Location = new System.Drawing.Point(177, 58);
            this.txtNam_Next.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtNam_Next.Name = "txtNam_Next";
            this.txtNam_Next.Size = new System.Drawing.Size(76, 23);
            this.txtNam_Next.TabIndex = 1;
            this.txtNam_Next.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam_Next.UseAutoFilter = false;
            // 
            // grbControl1
            // 
            this.grbControl1.Controls.Add(this.txtTh_Bd_Ht);
            this.grbControl1.Controls.Add(this.lblControl1);
            this.grbControl1.Controls.Add(this.txtNam_Next);
            this.grbControl1.Controls.Add(this.lblCreate_Nam_Next);
            this.grbControl1.Controls.Add(this.lblNam_Current);
            this.grbControl1.Controls.Add(this.txtNam_Current);
            this.grbControl1.Controls.Add(this.lblNam_Next);
            this.grbControl1.Location = new System.Drawing.Point(20, 12);
            this.grbControl1.Name = "grbControl1";
            this.grbControl1.Size = new System.Drawing.Size(581, 130);
            this.grbControl1.TabIndex = 0;
            this.grbControl1.TabStop = false;
            // 
            // txtTh_Bd_Ht
            // 
            this.txtTh_Bd_Ht.bEnabled = true;
            this.txtTh_Bd_Ht.bIsLookup = false;
            this.txtTh_Bd_Ht.bReadOnly = false;
            this.txtTh_Bd_Ht.bRequire = false;
            this.txtTh_Bd_Ht.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTh_Bd_Ht.ColumnsView = null;
            this.txtTh_Bd_Ht.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTh_Bd_Ht.ForeColor = System.Drawing.Color.Blue;
            this.txtTh_Bd_Ht.KeyFilter = "";
            this.txtTh_Bd_Ht.Location = new System.Drawing.Point(177, 89);
            this.txtTh_Bd_Ht.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTh_Bd_Ht.Name = "txtTh_Bd_Ht";
            this.txtTh_Bd_Ht.Size = new System.Drawing.Size(76, 23);
            this.txtTh_Bd_Ht.TabIndex = 2;
            this.txtTh_Bd_Ht.Text = "1";
            this.txtTh_Bd_Ht.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTh_Bd_Ht.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl1.ForeColor = System.Drawing.Color.Blue;
            this.lblControl1.Location = new System.Drawing.Point(15, 95);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(146, 13);
            this.lblControl1.TabIndex = 65;
            this.lblControl1.Tag = "Th_Bd_Ht";
            this.lblControl1.Text = "Tháng bắt đầu năm tài chính";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWorkingYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 241);
            this.Controls.Add(this.grbControl1);
            this.Controls.Add(this.btgAccept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWorkingYear";
            this.Text = "frmWorkingYear";
            this.grbControl1.ResumeLayout(false);
            this.grbControl1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private Epoint.Systems.Customizes.btgAccept btgAccept;
        private Systems.Controls.lblControl lblNam_Current;
        private Systems.Controls.lblControl lblNam_Next;
        private Systems.Controls.lblControl lblCreate_Nam_Next;
        private Systems.Controls.txtTextLookup txtNam_Current;
        private Systems.Controls.txtTextLookup txtNam_Next;
        private Systems.Controls.grbControl grbControl1;
        private Systems.Controls.txtTextLookup txtTh_Bd_Ht;
        private Systems.Controls.lblControl lblControl1;
	}
}