namespace Epoint.Controllers
{
    partial class frmGroup_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroup_Edit));
            this.txtMember_Name = new Epoint.Systems.Controls.txtTextBox();
            this.label1 = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.txtMember_ID = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // txtMember_Name
            // 
            this.txtMember_Name.bEnabled = true;
            this.txtMember_Name.bIsLookup = false;
            this.txtMember_Name.bReadOnly = false;
            this.txtMember_Name.bRequire = false;
            this.txtMember_Name.KeyFilter = "";
            this.txtMember_Name.Location = new System.Drawing.Point(129, 53);
            this.txtMember_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMember_Name.Name = "txtMember_Name";
            this.txtMember_Name.Size = new System.Drawing.Size(305, 20);
            this.txtMember_Name.TabIndex = 1;
            this.txtMember_Name.UseAutoFilter = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 15;
            this.label1.Tag = "Group_Name";
            this.label1.Text = "Tên nhóm người dùng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(265, 97);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 2;
            // 
            // txtMember_ID
            // 
            this.txtMember_ID.bEnabled = true;
            this.txtMember_ID.bIsLookup = false;
            this.txtMember_ID.bReadOnly = false;
            this.txtMember_ID.bRequire = false;
            this.txtMember_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMember_ID.KeyFilter = "";
            this.txtMember_ID.Location = new System.Drawing.Point(129, 29);
            this.txtMember_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMember_ID.Name = "txtMember_ID";
            this.txtMember_ID.Size = new System.Drawing.Size(138, 20);
            this.txtMember_ID.TabIndex = 0;
            this.txtMember_ID.UseAutoFilter = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 20;
            this.label2.Tag = "Group_ID";
            this.label2.Text = "Mã nhóm người dùng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmGroup_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 145);
            this.Controls.Add(this.txtMember_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.txtMember_Name);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGroup_Edit";
            this.Tag = "frmGroup_Edit";
            this.Text = "frmGroup_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private Epoint.Systems.Controls.txtTextBox txtMember_Name;
		private Epoint.Systems.Controls.lblControl label1;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.txtTextBox txtMember_ID;
		private Epoint.Systems.Controls.lblControl label2;
    }
}