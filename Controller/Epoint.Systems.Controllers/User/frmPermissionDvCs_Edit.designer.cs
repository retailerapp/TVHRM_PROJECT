namespace Epoint.Controllers
{
	partial class frmPermissionDvCs_Edit
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
            this.txtMa_DvCs = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.lbtTen_DvCs = new Epoint.Systems.Controls.lbtControl();
            this.chkAllow_Access = new Epoint.Systems.Controls.chkControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            // txtMa_DvCs
            // 
            this.txtMa_DvCs.bEnabled = true;
            this.txtMa_DvCs.bIsLookup = false;
            this.txtMa_DvCs.bReadOnly = false;
            this.txtMa_DvCs.bRequire = false;
            this.txtMa_DvCs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa_DvCs.KeyFilter = "";
            this.txtMa_DvCs.Location = new System.Drawing.Point(131, 20);
            this.txtMa_DvCs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMa_DvCs.Name = "txtMa_DvCs";
            this.txtMa_DvCs.Size = new System.Drawing.Size(129, 20);
            this.txtMa_DvCs.TabIndex = 1;
            this.txtMa_DvCs.UseAutoFilter = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(52, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "Tk";
            this.label2.Text = "Mã đơn vị Cs";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(315, 144);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(171, 33);
            this.btgAccept.TabIndex = 5;
            // 
            // lbtTen_DvCs
            // 
            this.lbtTen_DvCs.AutoEllipsis = true;
            this.lbtTen_DvCs.AutoSize = true;
            this.lbtTen_DvCs.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbtTen_DvCs.Location = new System.Drawing.Point(266, 23);
            this.lbtTen_DvCs.Name = "lbtTen_DvCs";
            this.lbtTen_DvCs.Size = new System.Drawing.Size(133, 13);
            this.lbtTen_DvCs.TabIndex = 2;
            this.lbtTen_DvCs.Tag = "";
            this.lbtTen_DvCs.Text = "Tên đối tượng phân quyền";
            this.lbtTen_DvCs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAllow_Access
            // 
            this.chkAllow_Access.AutoSize = true;
            this.chkAllow_Access.Checked = true;
            this.chkAllow_Access.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllow_Access.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllow_Access.Location = new System.Drawing.Point(62, 33);
            this.chkAllow_Access.Name = "chkAllow_Access";
            this.chkAllow_Access.Size = new System.Drawing.Size(142, 17);
            this.chkAllow_Access.TabIndex = 4;
            this.chkAllow_Access.Tag = "Allow_Access";
            this.chkAllow_Access.Text = "Được phép xem truy cập";
            this.chkAllow_Access.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllow_Access);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(54, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phân quyền";
            // 
            // frmPermissionDvCs_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 194);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.txtMa_DvCs);
            this.Controls.Add(this.lbtTen_DvCs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTen_Nh_Dt);
            this.Controls.Add(this.lbDm_Nh_Dt);
            this.Name = "frmPermissionDvCs_Edit";
            this.Text = "frmPermission_Edit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Epoint.Systems.Controls.lblControl lbTen_Nh_Dt;
		private Epoint.Systems.Controls.lblControl lbDm_Nh_Dt;
		private Epoint.Systems.Controls.txtTextBox txtMa_DvCs;
		private Epoint.Systems.Controls.lblControl label2;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.lbtControl lbtTen_DvCs;
		public Epoint.Systems.Controls.chkControl chkAllow_Access;
		private System.Windows.Forms.GroupBox groupBox1;
    }
}