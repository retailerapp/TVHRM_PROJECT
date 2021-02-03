namespace Epoint.Controllers
{
	partial class frmCheckDataLogic_Edit
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
            this.txtTk = new Epoint.Systems.Controls.txtTextBox();
            this.lblColumn_ID = new Epoint.Systems.Controls.lblControl();
            this.lblDescription = new Epoint.Systems.Controls.lblControl();
            this.txtError_Message = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.chkIs_Active = new Epoint.Systems.Controls.chkControl();
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.lbStt = new Epoint.Systems.Controls.lblControl();
            this.txtCompareTo = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lbtColumn_Type = new Epoint.Systems.Controls.lblControl();
            this.enuType = new Epoint.Systems.Controls.txtEnum();
            this.lblTable_Type = new Epoint.Systems.Controls.lblControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // txtTk
            // 
            this.txtTk.bEnabled = true;
            this.txtTk.bIsLookup = false;
            this.txtTk.bReadOnly = false;
            this.txtTk.bRequire = false;
            this.txtTk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk.KeyFilter = "";
            this.txtTk.Location = new System.Drawing.Point(133, 40);
            this.txtTk.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(124, 20);
            this.txtTk.TabIndex = 1;
            this.txtTk.Tag = "Tk";
            this.txtTk.UseAutoFilter = false;
            // 
            // lblColumn_ID
            // 
            this.lblColumn_ID.AutoEllipsis = true;
            this.lblColumn_ID.AutoSize = true;
            this.lblColumn_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblColumn_ID.Location = new System.Drawing.Point(32, 42);
            this.lblColumn_ID.Name = "lblColumn_ID";
            this.lblColumn_ID.Size = new System.Drawing.Size(55, 13);
            this.lblColumn_ID.TabIndex = 1;
            this.lblColumn_ID.Tag = "Tk";
            this.lblColumn_ID.Text = "Tài khoản";
            this.lblColumn_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(32, 91);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(48, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Tag = "Description";
            this.lblDescription.Text = "Diễn giải";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtError_Message
            // 
            this.txtError_Message.bEnabled = true;
            this.txtError_Message.bIsLookup = false;
            this.txtError_Message.bReadOnly = false;
            this.txtError_Message.bRequire = false;
            this.txtError_Message.KeyFilter = "";
            this.txtError_Message.Location = new System.Drawing.Point(133, 88);
            this.txtError_Message.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtError_Message.Name = "txtError_Message";
            this.txtError_Message.Size = new System.Drawing.Size(434, 20);
            this.txtError_Message.TabIndex = 3;
            this.txtError_Message.Tag = "Description";
            this.txtError_Message.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(406, 229);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 33);
            this.btgAccept.TabIndex = 8;
            // 
            // chkIs_Active
            // 
            this.chkIs_Active.AutoSize = true;
            this.chkIs_Active.Location = new System.Drawing.Point(133, 207);
            this.chkIs_Active.Name = "chkIs_Active";
            this.chkIs_Active.Size = new System.Drawing.Size(56, 17);
            this.chkIs_Active.TabIndex = 7;
            this.chkIs_Active.Tag = "Is_Active";
            this.chkIs_Active.Text = "Active";
            this.chkIs_Active.UseVisualStyleBackColor = true;
            // 
            // numStt
            // 
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(133, 16);
            this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(124, 20);
            this.numStt.TabIndex = 0;
            this.numStt.Text = "0";
            this.numStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStt.UseAutoFilter = false;
            this.numStt.Value = 0D;
            // 
            // lbStt
            // 
            this.lbStt.AutoEllipsis = true;
            this.lbStt.AutoSize = true;
            this.lbStt.BackColor = System.Drawing.Color.Transparent;
            this.lbStt.Location = new System.Drawing.Point(32, 19);
            this.lbStt.Name = "lbStt";
            this.lbStt.Size = new System.Drawing.Size(50, 13);
            this.lbStt.TabIndex = 8;
            this.lbStt.Text = "Số thứ tự";
            this.lbStt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompareTo
            // 
            this.txtCompareTo.bEnabled = true;
            this.txtCompareTo.bIsLookup = false;
            this.txtCompareTo.bReadOnly = false;
            this.txtCompareTo.bRequire = false;
            this.txtCompareTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompareTo.KeyFilter = "";
            this.txtCompareTo.Location = new System.Drawing.Point(133, 64);
            this.txtCompareTo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtCompareTo.Name = "txtCompareTo";
            this.txtCompareTo.Size = new System.Drawing.Size(434, 20);
            this.txtCompareTo.TabIndex = 2;
            this.txtCompareTo.Tag = "Tk";
            this.txtCompareTo.UseAutoFilter = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(32, 67);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(63, 13);
            this.lblControl2.TabIndex = 1;
            this.lblControl2.Tag = "Tk";
            this.lblControl2.Text = "So sánh với";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtColumn_Type
            // 
            this.lbtColumn_Type.AutoEllipsis = true;
            this.lbtColumn_Type.AutoSize = true;
            this.lbtColumn_Type.BackColor = System.Drawing.Color.Transparent;
            this.lbtColumn_Type.ForeColor = System.Drawing.Color.Blue;
            this.lbtColumn_Type.Location = new System.Drawing.Point(163, 116);
            this.lbtColumn_Type.Name = "lbtColumn_Type";
            this.lbtColumn_Type.Size = new System.Drawing.Size(127, 13);
            this.lbtColumn_Type.TabIndex = 5;
            this.lbtColumn_Type.Text = "1-Đối chiếu hàng tồn kho";
            this.lbtColumn_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuType
            // 
            this.enuType.bEnabled = true;
            this.enuType.bIsLookup = false;
            this.enuType.bReadOnly = false;
            this.enuType.bRequire = false;
            this.enuType.InputMask = "1,2,3";
            this.enuType.KeyFilter = "";
            this.enuType.Location = new System.Drawing.Point(133, 112);
            this.enuType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.enuType.Name = "enuType";
            this.enuType.Size = new System.Drawing.Size(24, 20);
            this.enuType.TabIndex = 4;
            this.enuType.Text = "1";
            this.enuType.UseAutoFilter = false;
            // 
            // lblTable_Type
            // 
            this.lblTable_Type.AutoEllipsis = true;
            this.lblTable_Type.AutoSize = true;
            this.lblTable_Type.BackColor = System.Drawing.Color.Transparent;
            this.lblTable_Type.Location = new System.Drawing.Point(32, 116);
            this.lblTable_Type.Name = "lblTable_Type";
            this.lblTable_Type.Size = new System.Drawing.Size(27, 13);
            this.lblTable_Type.TabIndex = 12;
            this.lblTable_Type.Tag = "Type";
            this.lblTable_Type.Text = "Loại";
            this.lblTable_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.ForeColor = System.Drawing.Color.Blue;
            this.lblControl1.Location = new System.Drawing.Point(163, 156);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(171, 13);
            this.lblControl1.TabIndex = 6;
            this.lblControl1.Text = "3-Đối chiếu chi phí SXKD dở dang";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.ForeColor = System.Drawing.Color.Blue;
            this.lblControl3.Location = new System.Drawing.Point(163, 136);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(178, 13);
            this.lblControl3.TabIndex = 13;
            this.lblControl3.Text = "2-Đối chiếu công nợ hạn thanh toán";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.ForeColor = System.Drawing.Color.Blue;
            this.lblControl4.Location = new System.Drawing.Point(163, 177);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(93, 13);
            this.lblControl4.TabIndex = 14;
            this.lblControl4.Text = "4-Đối chiếu TSCĐ";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCheckDataLogic_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 282);
            this.Controls.Add(this.lblControl4);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.lbtColumn_Type);
            this.Controls.Add(this.enuType);
            this.Controls.Add(this.lblTable_Type);
            this.Controls.Add(this.numStt);
            this.Controls.Add(this.lbStt);
            this.Controls.Add(this.chkIs_Active);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtError_Message);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblColumn_ID);
            this.Controls.Add(this.txtCompareTo);
            this.Controls.Add(this.txtTk);
            this.Name = "frmCheckDataLogic_Edit";
            this.Tag = "frmCheckData, ESC";
            this.Text = "frmCheckData";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtTk;
		private Epoint.Systems.Controls.lblControl lblColumn_ID;
		private Epoint.Systems.Controls.lblControl lblDescription;
		private Epoint.Systems.Controls.txtTextBox txtError_Message;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.chkControl chkIs_Active;
		private Epoint.Systems.Controls.numControl numStt;
		private Epoint.Systems.Controls.lblControl lbStt;
		private Epoint.Systems.Controls.txtTextBox txtCompareTo;
		private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.lblControl lbtColumn_Type;
		private Epoint.Systems.Controls.txtEnum enuType;
		private Epoint.Systems.Controls.lblControl lblTable_Type;
		private Epoint.Systems.Controls.lblControl lblControl1;
        private Systems.Controls.lblControl lblControl3;
        private Systems.Controls.lblControl lblControl4;
	}
}