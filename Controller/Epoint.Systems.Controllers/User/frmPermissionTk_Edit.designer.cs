namespace Epoint.Controllers
{
	partial class frmPermissionTk_Edit
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
            this.lbTen_Nh_Dt = new Epoint.Systems.Controls.lblControl();
            this.lbDm_Nh_Dt = new Epoint.Systems.Controls.lblControl();
            this.txtTk = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lbtTen_Tk = new Epoint.Systems.Controls.lbtControl();
            this.chkAllow_View = new Epoint.Systems.Controls.chkControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbtControl1 = new Epoint.Systems.Controls.lbtControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTen_Nh_Dt
            // 
            this.lbTen_Nh_Dt.AutoEllipsis = true;
            this.lbTen_Nh_Dt.AutoSize = true;
            this.lbTen_Nh_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lbTen_Nh_Dt.Location = new System.Drawing.Point(-97, 135);
            this.lbTen_Nh_Dt.Name = "lbTen_Nh_Dt";
            this.lbTen_Nh_Dt.Size = new System.Drawing.Size(55, 13);
            this.lbTen_Nh_Dt.TabIndex = 3;
            this.lbTen_Nh_Dt.Text = "Tên nhóm";
            this.lbTen_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDm_Nh_Dt
            // 
            this.lbDm_Nh_Dt.AutoEllipsis = true;
            this.lbDm_Nh_Dt.AutoSize = true;
            this.lbDm_Nh_Dt.BackColor = System.Drawing.Color.Transparent;
            this.lbDm_Nh_Dt.Location = new System.Drawing.Point(-97, 113);
            this.lbDm_Nh_Dt.Name = "lbDm_Nh_Dt";
            this.lbDm_Nh_Dt.Size = new System.Drawing.Size(51, 13);
            this.lbDm_Nh_Dt.TabIndex = 4;
            this.lbDm_Nh_Dt.Text = "Mã nhóm";
            this.lbDm_Nh_Dt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTk
            // 
            this.txtTk.bEnabled = true;
            this.txtTk.bIsLookup = false;
            this.txtTk.bReadOnly = false;
            this.txtTk.bRequire = false;
            this.txtTk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTk.KeyFilter = "";
            this.txtTk.Location = new System.Drawing.Point(105, 23);
            this.txtTk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(129, 20);
            this.txtTk.TabIndex = 1;
            this.txtTk.UseAutoFilter = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(45, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "Tk";
            this.label2.Text = "Tài khoản";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(321, 173);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 33);
            this.btgAccept.TabIndex = 5;
            // 
            // lbtTen_Tk
            // 
            this.lbtTen_Tk.AutoEllipsis = true;
            this.lbtTen_Tk.AutoSize = true;
            this.lbtTen_Tk.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_Tk.Location = new System.Drawing.Point(239, 26);
            this.lbtTen_Tk.Name = "lbtTen_Tk";
            this.lbtTen_Tk.Size = new System.Drawing.Size(133, 13);
            this.lbtTen_Tk.TabIndex = 2;
            this.lbtTen_Tk.Tag = "";
            this.lbtTen_Tk.Text = "Tên đối tượng phân quyền";
            this.lbtTen_Tk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAllow_View
            // 
            this.chkAllow_View.AutoSize = true;
            this.chkAllow_View.Checked = true;
            this.chkAllow_View.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllow_View.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllow_View.Location = new System.Drawing.Point(62, 30);
            this.chkAllow_View.Name = "chkAllow_View";
            this.chkAllow_View.Size = new System.Drawing.Size(101, 17);
            this.chkAllow_View.TabIndex = 4;
            this.chkAllow_View.Tag = "Allow_View";
            this.chkAllow_View.Text = "Được phép xem";
            this.chkAllow_View.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllow_View);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(48, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phân quyền";
            // 
            // lbtControl1
            // 
            this.lbtControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbtControl1.AutoEllipsis = true;
            this.lbtControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtControl1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtControl1.Location = new System.Drawing.Point(45, 130);
            this.lbtControl1.Name = "lbtControl1";
            this.lbtControl1.Size = new System.Drawing.Size(298, 43);
            this.lbtControl1.TabIndex = 2;
            this.lbtControl1.Tag = "";
            this.lbtControl1.Text = "Lưu ý: phân quyền trên tài khoản cha thì sẽ có ảnh hưởng đến các tài khoản con";
            this.lbtControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPermissionTk_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 220);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.txtTk);
            this.Controls.Add(this.lbtControl1);
            this.Controls.Add(this.lbtTen_Tk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTen_Nh_Dt);
            this.Controls.Add(this.lbDm_Nh_Dt);
            this.Name = "frmPermissionTk_Edit";
            this.Text = "frmPermission_Edit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Epoint.Systems.Controls.lblControl lbTen_Nh_Dt;
		private Epoint.Systems.Controls.lblControl lbDm_Nh_Dt;
		private Epoint.Systems.Controls.txtTextBox txtTk;
		private Epoint.Systems.Controls.lblControl label2;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.lbtControl lbtTen_Tk;
		public Epoint.Systems.Controls.chkControl chkAllow_View;
		private System.Windows.Forms.GroupBox groupBox1;
		private Epoint.Systems.Controls.lbtControl lbtControl1;
    }
}