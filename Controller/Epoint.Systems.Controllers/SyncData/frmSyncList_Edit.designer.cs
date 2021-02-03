namespace Epoint.Controllers
{
    partial class frmSyncList_Edit
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
            this.txtUnique_Key = new Epoint.Systems.Controls.txtTextBox();
            this.lblColumn_ID = new Epoint.Systems.Controls.lblControl();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.txtTable_Name = new Epoint.Systems.Controls.txtTextBox();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtDescription = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.txtFilter_Key = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.lbtColumn_Type = new Epoint.Systems.Controls.lblControl();
            this.enuData_Type = new Epoint.Systems.Controls.txtEnum();
            this.lblTable_Type = new Epoint.Systems.Controls.lblControl();
            this.lblControl3 = new Epoint.Systems.Controls.lblControl();
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.lbStt = new Epoint.Systems.Controls.lblControl();
            this.chkIs_Send = new Epoint.Systems.Controls.chkControl();
            this.txtTable_Delete = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl4 = new Epoint.Systems.Controls.lblControl();
            this.lblControl5 = new Epoint.Systems.Controls.lblControl();
            this.txtTable_Sub = new Epoint.Systems.Controls.txtTextBox();
            this.lblControl6 = new Epoint.Systems.Controls.lblControl();
            this.lblControl7 = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // txtUnique_Key
            // 
            this.txtUnique_Key.bEnabled = true;
            this.txtUnique_Key.bIsLookup = false;
            this.txtUnique_Key.bReadOnly = false;
            this.txtUnique_Key.bRequire = false;
            this.txtUnique_Key.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnique_Key.KeyFilter = "";
            this.txtUnique_Key.Location = new System.Drawing.Point(133, 86);
            this.txtUnique_Key.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtUnique_Key.Name = "txtUnique_Key";
            this.txtUnique_Key.Size = new System.Drawing.Size(227, 20);
            this.txtUnique_Key.TabIndex = 3;
            this.txtUnique_Key.UseAutoFilter = false;
            // 
            // lblColumn_ID
            // 
            this.lblColumn_ID.AutoEllipsis = true;
            this.lblColumn_ID.AutoSize = true;
            this.lblColumn_ID.BackColor = System.Drawing.Color.Transparent;
            this.lblColumn_ID.Location = new System.Drawing.Point(29, 89);
            this.lblColumn_ID.Name = "lblColumn_ID";
            this.lblColumn_ID.Size = new System.Drawing.Size(32, 13);
            this.lblColumn_ID.TabIndex = 1;
            this.lblColumn_ID.Tag = "";
            this.lblColumn_ID.Text = "Khóa";
            this.lblColumn_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(29, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 16;
            this.label2.Tag = "Column_Type";
            this.label2.Text = "Tên bảng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTable_Name
            // 
            this.txtTable_Name.bEnabled = true;
            this.txtTable_Name.bIsLookup = false;
            this.txtTable_Name.bReadOnly = false;
            this.txtTable_Name.bRequire = false;
            this.txtTable_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTable_Name.KeyFilter = "";
            this.txtTable_Name.Location = new System.Drawing.Point(133, 40);
            this.txtTable_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTable_Name.Name = "txtTable_Name";
            this.txtTable_Name.Size = new System.Drawing.Size(227, 20);
            this.txtTable_Name.TabIndex = 1;
            this.txtTable_Name.UseAutoFilter = false;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(360, 244);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.bEnabled = true;
            this.txtDescription.bIsLookup = false;
            this.txtDescription.bReadOnly = false;
            this.txtDescription.bRequire = false;
            this.txtDescription.KeyFilter = "";
            this.txtDescription.Location = new System.Drawing.Point(133, 63);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(386, 20);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.UseAutoFilter = false;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(29, 66);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(48, 13);
            this.lblControl1.TabIndex = 3;
            this.lblControl1.Tag = "Description";
            this.lblControl1.Text = "Diễn giải";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFilter_Key
            // 
            this.txtFilter_Key.bEnabled = true;
            this.txtFilter_Key.bIsLookup = false;
            this.txtFilter_Key.bReadOnly = false;
            this.txtFilter_Key.bRequire = false;
            this.txtFilter_Key.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilter_Key.KeyFilter = "";
            this.txtFilter_Key.Location = new System.Drawing.Point(133, 109);
            this.txtFilter_Key.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtFilter_Key.Name = "txtFilter_Key";
            this.txtFilter_Key.Size = new System.Drawing.Size(386, 20);
            this.txtFilter_Key.TabIndex = 4;
            this.txtFilter_Key.UseAutoFilter = false;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(29, 112);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(59, 13);
            this.lblControl2.TabIndex = 1;
            this.lblControl2.Tag = "";
            this.lblControl2.Text = "Lọc dữ liệu";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtColumn_Type
            // 
            this.lbtColumn_Type.AutoEllipsis = true;
            this.lbtColumn_Type.AutoSize = true;
            this.lbtColumn_Type.BackColor = System.Drawing.Color.Transparent;
            this.lbtColumn_Type.ForeColor = System.Drawing.Color.Blue;
            this.lbtColumn_Type.Location = new System.Drawing.Point(241, 181);
            this.lbtColumn_Type.Name = "lbtColumn_Type";
            this.lbtColumn_Type.Size = new System.Drawing.Size(212, 13);
            this.lbtColumn_Type.TabIndex = 9;
            this.lbtColumn_Type.Text = "1-Chứng từ, 2-Danh mục, 3-Tài sản cố định";
            this.lbtColumn_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuData_Type
            // 
            this.enuData_Type.bEnabled = true;
            this.enuData_Type.bIsLookup = false;
            this.enuData_Type.bReadOnly = false;
            this.enuData_Type.bRequire = false;
            this.enuData_Type.InputMask = "1,2,3";
            this.enuData_Type.KeyFilter = "";
            this.enuData_Type.Location = new System.Drawing.Point(133, 178);
            this.enuData_Type.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.enuData_Type.Name = "enuData_Type";
            this.enuData_Type.Size = new System.Drawing.Size(42, 20);
            this.enuData_Type.TabIndex = 7;
            this.enuData_Type.Text = "2";
            this.enuData_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.enuData_Type.UseAutoFilter = false;
            // 
            // lblTable_Type
            // 
            this.lblTable_Type.AutoEllipsis = true;
            this.lblTable_Type.AutoSize = true;
            this.lblTable_Type.BackColor = System.Drawing.Color.Transparent;
            this.lblTable_Type.Location = new System.Drawing.Point(29, 182);
            this.lblTable_Type.Name = "lblTable_Type";
            this.lblTable_Type.Size = new System.Drawing.Size(61, 13);
            this.lblTable_Type.TabIndex = 19;
            this.lblTable_Type.Tag = "Data_Type";
            this.lblTable_Type.Text = "Loại dữ liệu";
            this.lblTable_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl3
            // 
            this.lblControl3.AutoEllipsis = true;
            this.lblControl3.AutoSize = true;
            this.lblControl3.BackColor = System.Drawing.Color.Transparent;
            this.lblControl3.ForeColor = System.Drawing.Color.Blue;
            this.lblControl3.Location = new System.Drawing.Point(364, 90);
            this.lblControl3.Name = "lblControl3";
            this.lblControl3.Size = new System.Drawing.Size(126, 13);
            this.lblControl3.TabIndex = 4;
            this.lblControl3.Text = "(Trường dữ liệu UNIQUE)";
            this.lblControl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numStt
            // 
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(133, 17);
            this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(42, 20);
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
            this.lbStt.Location = new System.Drawing.Point(29, 20);
            this.lbStt.Name = "lbStt";
            this.lbStt.Size = new System.Drawing.Size(50, 13);
            this.lbStt.TabIndex = 21;
            this.lbStt.Text = "Số thứ tự";
            this.lbStt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIs_Send
            // 
            this.chkIs_Send.AutoSize = true;
            this.chkIs_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIs_Send.ForeColor = System.Drawing.Color.Blue;
            this.chkIs_Send.Location = new System.Drawing.Point(132, 209);
            this.chkIs_Send.Name = "chkIs_Send";
            this.chkIs_Send.Size = new System.Drawing.Size(50, 17);
            this.chkIs_Send.TabIndex = 8;
            this.chkIs_Send.Text = "Sync";
            this.chkIs_Send.UseVisualStyleBackColor = true;
            // 
            // txtTable_Delete
            // 
            this.txtTable_Delete.bEnabled = true;
            this.txtTable_Delete.bIsLookup = false;
            this.txtTable_Delete.bReadOnly = false;
            this.txtTable_Delete.bRequire = false;
            this.txtTable_Delete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTable_Delete.KeyFilter = "";
            this.txtTable_Delete.Location = new System.Drawing.Point(133, 132);
            this.txtTable_Delete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTable_Delete.Name = "txtTable_Delete";
            this.txtTable_Delete.Size = new System.Drawing.Size(227, 20);
            this.txtTable_Delete.TabIndex = 5;
            this.txtTable_Delete.UseAutoFilter = false;
            // 
            // lblControl4
            // 
            this.lblControl4.AutoEllipsis = true;
            this.lblControl4.AutoSize = true;
            this.lblControl4.BackColor = System.Drawing.Color.Transparent;
            this.lblControl4.Location = new System.Drawing.Point(29, 135);
            this.lblControl4.Name = "lblControl4";
            this.lblControl4.Size = new System.Drawing.Size(102, 13);
            this.lblControl4.TabIndex = 16;
            this.lblControl4.Tag = "";
            this.lblControl4.Text = "Xóa bảng dữ liệu cũ";
            this.lblControl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl5
            // 
            this.lblControl5.AutoEllipsis = true;
            this.lblControl5.AutoSize = true;
            this.lblControl5.BackColor = System.Drawing.Color.Transparent;
            this.lblControl5.ForeColor = System.Drawing.Color.Blue;
            this.lblControl5.Location = new System.Drawing.Point(364, 135);
            this.lblControl5.Name = "lblControl5";
            this.lblControl5.Size = new System.Drawing.Size(89, 13);
            this.lblControl5.TabIndex = 7;
            this.lblControl5.Text = "(Khi nhận dữ liệu)";
            this.lblControl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTable_Sub
            // 
            this.txtTable_Sub.bEnabled = true;
            this.txtTable_Sub.bIsLookup = false;
            this.txtTable_Sub.bReadOnly = false;
            this.txtTable_Sub.bRequire = false;
            this.txtTable_Sub.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTable_Sub.KeyFilter = "";
            this.txtTable_Sub.Location = new System.Drawing.Point(133, 155);
            this.txtTable_Sub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTable_Sub.Name = "txtTable_Sub";
            this.txtTable_Sub.Size = new System.Drawing.Size(227, 20);
            this.txtTable_Sub.TabIndex = 6;
            this.txtTable_Sub.UseAutoFilter = false;
            // 
            // lblControl6
            // 
            this.lblControl6.AutoEllipsis = true;
            this.lblControl6.AutoSize = true;
            this.lblControl6.BackColor = System.Drawing.Color.Transparent;
            this.lblControl6.Location = new System.Drawing.Point(29, 158);
            this.lblControl6.Name = "lblControl6";
            this.lblControl6.Size = new System.Drawing.Size(96, 13);
            this.lblControl6.TabIndex = 16;
            this.lblControl6.Tag = "";
            this.lblControl6.Text = "Bảng nhóm đi kèm";
            this.lblControl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblControl7
            // 
            this.lblControl7.AutoEllipsis = true;
            this.lblControl7.AutoSize = true;
            this.lblControl7.BackColor = System.Drawing.Color.Transparent;
            this.lblControl7.ForeColor = System.Drawing.Color.Blue;
            this.lblControl7.Location = new System.Drawing.Point(364, 158);
            this.lblControl7.Name = "lblControl7";
            this.lblControl7.Size = new System.Drawing.Size(89, 13);
            this.lblControl7.TabIndex = 7;
            this.lblControl7.Text = "(Khi nhận dữ liệu)";
            this.lblControl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSyncList_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 297);
            this.Controls.Add(this.chkIs_Send);
            this.Controls.Add(this.numStt);
            this.Controls.Add(this.lbStt);
            this.Controls.Add(this.lblControl7);
            this.Controls.Add(this.lblControl5);
            this.Controls.Add(this.lblControl3);
            this.Controls.Add(this.lbtColumn_Type);
            this.Controls.Add(this.enuData_Type);
            this.Controls.Add(this.lblTable_Type);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lblControl6);
            this.Controls.Add(this.lblControl4);
            this.Controls.Add(this.txtTable_Sub);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTable_Delete);
            this.Controls.Add(this.txtTable_Name);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.lblColumn_ID);
            this.Controls.Add(this.txtFilter_Key);
            this.Controls.Add(this.txtUnique_Key);
            this.Name = "frmSyncList_Edit";
            this.Tag = "frmTranferData, ESC";
            this.Text = "frmTranferData";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.txtTextBox txtUnique_Key;
		private Epoint.Systems.Controls.lblControl lblColumn_ID;
		private Epoint.Systems.Controls.lblControl label2;
		private Epoint.Systems.Controls.txtTextBox txtTable_Name;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.txtTextBox txtDescription;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.txtTextBox txtFilter_Key;
		private Epoint.Systems.Controls.lblControl lblControl2;
		private Epoint.Systems.Controls.lblControl lbtColumn_Type;
		private Epoint.Systems.Controls.txtEnum enuData_Type;
		private Epoint.Systems.Controls.lblControl lblTable_Type;
		private Epoint.Systems.Controls.lblControl lblControl3;
		private Epoint.Systems.Controls.numControl numStt;
		private Epoint.Systems.Controls.lblControl lbStt;
		private Epoint.Systems.Controls.chkControl chkIs_Send;
		private Epoint.Systems.Controls.txtTextBox txtTable_Delete;
		private Epoint.Systems.Controls.lblControl lblControl4;
		private Epoint.Systems.Controls.lblControl lblControl5;
        private Systems.Controls.txtTextBox txtTable_Sub;
        private Systems.Controls.lblControl lblControl6;
        private Systems.Controls.lblControl lblControl7;
	}
}