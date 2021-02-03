namespace Epoint.Controllers
{
    partial class frmMenu_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu_Edit));
            this.lbMenu_Id = new Epoint.Systems.Controls.lblControl();
            this.lbMenu_Name = new Epoint.Systems.Controls.lblControl();
            this.lbMenu_Parent = new Epoint.Systems.Controls.lblControl();
            this.txtMenu_Name = new Epoint.Systems.Controls.txtTextBox();
            this.lbMenu_NameE = new Epoint.Systems.Controls.lblControl();
            this.txtMenu_NameE = new Epoint.Systems.Controls.txtTextBox();
            this.lbPicture = new Epoint.Systems.Controls.lblControl();
            this.txtPicture = new Epoint.Systems.Controls.txtTextBox();
            this.lbMenu_Method = new Epoint.Systems.Controls.lblControl();
            this.txtMenu_Method = new Epoint.Systems.Controls.txtTextBox();
            this.lbMenu_Para = new Epoint.Systems.Controls.lblControl();
            this.txtMenu_Para = new Epoint.Systems.Controls.txtTextBox();
            this.lbStt = new Epoint.Systems.Controls.lblControl();
            this.numMenu_Id = new Epoint.Systems.Controls.numControl();
            this.numMenu_Parent = new Epoint.Systems.Controls.numControl();
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.chkShow_On_Main = new Epoint.Systems.Controls.chkControl();
            this.chkIs_Customize = new Epoint.Systems.Controls.chkControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbtObject_Name = new Epoint.Systems.Controls.lbtControl();
            this.txtObject_ID = new Epoint.Systems.Controls.txtTextLookup();
            this.SuspendLayout();
            // 
            // lbMenu_Id
            // 
            this.lbMenu_Id.AutoEllipsis = true;
            this.lbMenu_Id.AutoSize = true;
            this.lbMenu_Id.BackColor = System.Drawing.Color.Transparent;
            this.lbMenu_Id.Location = new System.Drawing.Point(36, 26);
            this.lbMenu_Id.Name = "lbMenu_Id";
            this.lbMenu_Id.Size = new System.Drawing.Size(46, 13);
            this.lbMenu_Id.TabIndex = 0;
            this.lbMenu_Id.Tag = "MENU_ID";
            this.lbMenu_Id.Text = "Menu Id";
            this.lbMenu_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMenu_Name
            // 
            this.lbMenu_Name.AutoEllipsis = true;
            this.lbMenu_Name.AutoSize = true;
            this.lbMenu_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbMenu_Name.Location = new System.Drawing.Point(36, 50);
            this.lbMenu_Name.Name = "lbMenu_Name";
            this.lbMenu_Name.Size = new System.Drawing.Size(55, 13);
            this.lbMenu_Name.TabIndex = 0;
            this.lbMenu_Name.Tag = "Menu_Name";
            this.lbMenu_Name.Text = "Tên menu";
            this.lbMenu_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMenu_Parent
            // 
            this.lbMenu_Parent.AutoEllipsis = true;
            this.lbMenu_Parent.AutoSize = true;
            this.lbMenu_Parent.BackColor = System.Drawing.Color.Transparent;
            this.lbMenu_Parent.Location = new System.Drawing.Point(36, 94);
            this.lbMenu_Parent.Name = "lbMenu_Parent";
            this.lbMenu_Parent.Size = new System.Drawing.Size(55, 13);
            this.lbMenu_Parent.TabIndex = 0;
            this.lbMenu_Parent.Tag = "Menu_Parent";
            this.lbMenu_Parent.Text = "Menu cha";
            this.lbMenu_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMenu_Name
            // 
            this.txtMenu_Name.bEnabled = true;
            this.txtMenu_Name.bIsLookup = false;
            this.txtMenu_Name.bReadOnly = false;
            this.txtMenu_Name.bRequire = false;
            this.txtMenu_Name.KeyFilter = "";
            this.txtMenu_Name.Location = new System.Drawing.Point(148, 46);
            this.txtMenu_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMenu_Name.Name = "txtMenu_Name";
            this.txtMenu_Name.Size = new System.Drawing.Size(375, 20);
            this.txtMenu_Name.TabIndex = 5;
            this.txtMenu_Name.UseAutoFilter = false;
            // 
            // lbMenu_NameE
            // 
            this.lbMenu_NameE.AutoEllipsis = true;
            this.lbMenu_NameE.AutoSize = true;
            this.lbMenu_NameE.BackColor = System.Drawing.Color.Transparent;
            this.lbMenu_NameE.Location = new System.Drawing.Point(36, 72);
            this.lbMenu_NameE.Name = "lbMenu_NameE";
            this.lbMenu_NameE.Size = new System.Drawing.Size(73, 13);
            this.lbMenu_NameE.TabIndex = 0;
            this.lbMenu_NameE.Tag = "Menu_Name_En";
            this.lbMenu_NameE.Text = "Tên tiếng anh";
            this.lbMenu_NameE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMenu_NameE
            // 
            this.txtMenu_NameE.bEnabled = true;
            this.txtMenu_NameE.bIsLookup = false;
            this.txtMenu_NameE.bReadOnly = false;
            this.txtMenu_NameE.bRequire = false;
            this.txtMenu_NameE.KeyFilter = "";
            this.txtMenu_NameE.Location = new System.Drawing.Point(148, 69);
            this.txtMenu_NameE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMenu_NameE.Name = "txtMenu_NameE";
            this.txtMenu_NameE.Size = new System.Drawing.Size(375, 20);
            this.txtMenu_NameE.TabIndex = 6;
            this.txtMenu_NameE.UseAutoFilter = false;
            // 
            // lbPicture
            // 
            this.lbPicture.AutoEllipsis = true;
            this.lbPicture.AutoSize = true;
            this.lbPicture.BackColor = System.Drawing.Color.Transparent;
            this.lbPicture.Location = new System.Drawing.Point(36, 117);
            this.lbPicture.Name = "lbPicture";
            this.lbPicture.Size = new System.Drawing.Size(67, 13);
            this.lbPicture.TabIndex = 0;
            this.lbPicture.Tag = "File_Image";
            this.lbPicture.Text = "File hình ảnh";
            this.lbPicture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPicture
            // 
            this.txtPicture.bEnabled = true;
            this.txtPicture.bIsLookup = false;
            this.txtPicture.bReadOnly = false;
            this.txtPicture.bRequire = false;
            this.txtPicture.KeyFilter = "";
            this.txtPicture.Location = new System.Drawing.Point(148, 115);
            this.txtPicture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.Size = new System.Drawing.Size(375, 20);
            this.txtPicture.TabIndex = 8;
            this.txtPicture.UseAutoFilter = false;
            // 
            // lbMenu_Method
            // 
            this.lbMenu_Method.AutoEllipsis = true;
            this.lbMenu_Method.AutoSize = true;
            this.lbMenu_Method.BackColor = System.Drawing.Color.Transparent;
            this.lbMenu_Method.Location = new System.Drawing.Point(36, 140);
            this.lbMenu_Method.Name = "lbMenu_Method";
            this.lbMenu_Method.Size = new System.Drawing.Size(85, 13);
            this.lbMenu_Method.TabIndex = 0;
            this.lbMenu_Method.Tag = "Menu_Method";
            this.lbMenu_Method.Text = "Phương thức gọi";
            this.lbMenu_Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMenu_Method
            // 
            this.txtMenu_Method.bEnabled = true;
            this.txtMenu_Method.bIsLookup = false;
            this.txtMenu_Method.bReadOnly = false;
            this.txtMenu_Method.bRequire = false;
            this.txtMenu_Method.KeyFilter = "";
            this.txtMenu_Method.Location = new System.Drawing.Point(148, 138);
            this.txtMenu_Method.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMenu_Method.Name = "txtMenu_Method";
            this.txtMenu_Method.Size = new System.Drawing.Size(375, 20);
            this.txtMenu_Method.TabIndex = 9;
            this.txtMenu_Method.UseAutoFilter = false;
            // 
            // lbMenu_Para
            // 
            this.lbMenu_Para.AutoEllipsis = true;
            this.lbMenu_Para.AutoSize = true;
            this.lbMenu_Para.BackColor = System.Drawing.Color.Transparent;
            this.lbMenu_Para.Location = new System.Drawing.Point(36, 163);
            this.lbMenu_Para.Name = "lbMenu_Para";
            this.lbMenu_Para.Size = new System.Drawing.Size(66, 13);
            this.lbMenu_Para.TabIndex = 0;
            this.lbMenu_Para.Tag = "Menu_Para";
            this.lbMenu_Para.Text = "Các tham số";
            this.lbMenu_Para.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMenu_Para
            // 
            this.txtMenu_Para.bEnabled = true;
            this.txtMenu_Para.bIsLookup = false;
            this.txtMenu_Para.bReadOnly = false;
            this.txtMenu_Para.bRequire = false;
            this.txtMenu_Para.KeyFilter = "";
            this.txtMenu_Para.Location = new System.Drawing.Point(148, 161);
            this.txtMenu_Para.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtMenu_Para.Name = "txtMenu_Para";
            this.txtMenu_Para.Size = new System.Drawing.Size(375, 20);
            this.txtMenu_Para.TabIndex = 10;
            this.txtMenu_Para.UseAutoFilter = false;
            // 
            // lbStt
            // 
            this.lbStt.AutoEllipsis = true;
            this.lbStt.AutoSize = true;
            this.lbStt.BackColor = System.Drawing.Color.Transparent;
            this.lbStt.Location = new System.Drawing.Point(394, 26);
            this.lbStt.Name = "lbStt";
            this.lbStt.Size = new System.Drawing.Size(50, 13);
            this.lbStt.TabIndex = 0;
            this.lbStt.Tag = "Stt";
            this.lbStt.Text = "Số thứ tự";
            this.lbStt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numMenu_Id
            // 
            this.numMenu_Id.bEnabled = true;
            this.numMenu_Id.bFormat = true;
            this.numMenu_Id.bIsLookup = false;
            this.numMenu_Id.bReadOnly = false;
            this.numMenu_Id.bRequire = false;
            this.numMenu_Id.KeyFilter = "";
            this.numMenu_Id.Location = new System.Drawing.Point(148, 23);
            this.numMenu_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numMenu_Id.Name = "numMenu_Id";
            this.numMenu_Id.Scale = 0;
            this.numMenu_Id.Size = new System.Drawing.Size(100, 20);
            this.numMenu_Id.TabIndex = 3;
            this.numMenu_Id.Text = "0";
            this.numMenu_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMenu_Id.UseAutoFilter = false;
            this.numMenu_Id.Value = 0D;
            // 
            // numMenu_Parent
            // 
            this.numMenu_Parent.bEnabled = true;
            this.numMenu_Parent.bFormat = true;
            this.numMenu_Parent.bIsLookup = false;
            this.numMenu_Parent.bReadOnly = false;
            this.numMenu_Parent.bRequire = false;
            this.numMenu_Parent.KeyFilter = "";
            this.numMenu_Parent.Location = new System.Drawing.Point(148, 92);
            this.numMenu_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numMenu_Parent.Name = "numMenu_Parent";
            this.numMenu_Parent.Scale = 0;
            this.numMenu_Parent.Size = new System.Drawing.Size(100, 20);
            this.numMenu_Parent.TabIndex = 7;
            this.numMenu_Parent.Text = "0";
            this.numMenu_Parent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMenu_Parent.UseAutoFilter = false;
            this.numMenu_Parent.Value = 0D;
            // 
            // numStt
            // 
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(450, 23);
            this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(73, 20);
            this.numStt.TabIndex = 4;
            this.numStt.Text = "0";
            this.numStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStt.UseAutoFilter = false;
            this.numStt.Value = 0D;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(356, 266);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(170, 33);
            this.btgAccept.TabIndex = 14;
            // 
            // chkShow_On_Main
            // 
            this.chkShow_On_Main.AutoSize = true;
            this.chkShow_On_Main.Location = new System.Drawing.Point(148, 215);
            this.chkShow_On_Main.Name = "chkShow_On_Main";
            this.chkShow_On_Main.Size = new System.Drawing.Size(137, 17);
            this.chkShow_On_Main.TabIndex = 12;
            this.chkShow_On_Main.Tag = "Show_On_Main";
            this.chkShow_On_Main.Text = "Hiện thị trong form main";
            this.chkShow_On_Main.UseVisualStyleBackColor = true;
            // 
            // chkIs_Customize
            // 
            this.chkIs_Customize.AutoSize = true;
            this.chkIs_Customize.Location = new System.Drawing.Point(148, 237);
            this.chkIs_Customize.Name = "chkIs_Customize";
            this.chkIs_Customize.Size = new System.Drawing.Size(122, 17);
            this.chkIs_Customize.TabIndex = 13;
            this.chkIs_Customize.Tag = "Menu_CUSTOMIZE";
            this.chkIs_Customize.Text = "Là dữ liệu customize";
            this.chkIs_Customize.UseVisualStyleBackColor = true;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(36, 187);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(112, 13);
            this.lblControl1.TabIndex = 11;
            this.lblControl1.Tag = "Menu_Object";
            this.lblControl1.Text = "Đối tượng phân quyền";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtObject_Name
            // 
            this.lbtObject_Name.AutoEllipsis = true;
            this.lbtObject_Name.AutoSize = true;
            this.lbtObject_Name.ForeColor = System.Drawing.Color.Blue;
            this.lbtObject_Name.Location = new System.Drawing.Point(290, 188);
            this.lbtObject_Name.Name = "lbtObject_Name";
            this.lbtObject_Name.Size = new System.Drawing.Size(133, 13);
            this.lbtObject_Name.TabIndex = 11;
            this.lbtObject_Name.Text = "Tên đối tượng phân quyền";
            this.lbtObject_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObject_ID
            // 
            this.txtObject_ID.bEnabled = true;
            this.txtObject_ID.bIsLookup = false;
            this.txtObject_ID.bReadOnly = false;
            this.txtObject_ID.bRequire = false;
            this.txtObject_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObject_ID.ColumnsView = null;
            this.txtObject_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObject_ID.KeyFilter = "Object_ID";
            this.txtObject_ID.Location = new System.Drawing.Point(148, 184);
            this.txtObject_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtObject_ID.Name = "txtObject_ID";
            this.txtObject_ID.Size = new System.Drawing.Size(137, 20);
            this.txtObject_ID.TabIndex = 11;
            this.txtObject_ID.UseAutoFilter = true;
            // 
            // frmMenu_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 315);
            this.Controls.Add(this.txtObject_ID);
            this.Controls.Add(this.lbtObject_Name);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.chkIs_Customize);
            this.Controls.Add(this.chkShow_On_Main);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.numStt);
            this.Controls.Add(this.numMenu_Parent);
            this.Controls.Add(this.numMenu_Id);
            this.Controls.Add(this.txtMenu_NameE);
            this.Controls.Add(this.txtMenu_Para);
            this.Controls.Add(this.txtMenu_Method);
            this.Controls.Add(this.txtPicture);
            this.Controls.Add(this.txtMenu_Name);
            this.Controls.Add(this.lbStt);
            this.Controls.Add(this.lbMenu_Para);
            this.Controls.Add(this.lbMenu_Method);
            this.Controls.Add(this.lbMenu_NameE);
            this.Controls.Add(this.lbPicture);
            this.Controls.Add(this.lbMenu_Parent);
            this.Controls.Add(this.lbMenu_Name);
            this.Controls.Add(this.lbMenu_Id);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu_Edit";
            this.Tag = "frmMenu";
            this.Text = "frmMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Epoint.Systems.Controls.lblControl lbMenu_Id;
        private Epoint.Systems.Controls.lblControl lbMenu_Name;
        private Epoint.Systems.Controls.lblControl lbMenu_Parent;
		private Epoint.Systems.Controls.txtTextBox txtMenu_Name;
        private Epoint.Systems.Controls.lblControl lbMenu_NameE;
        private Epoint.Systems.Controls.txtTextBox txtMenu_NameE;
        private Epoint.Systems.Controls.lblControl lbPicture;
        private Epoint.Systems.Controls.txtTextBox txtPicture;
        private Epoint.Systems.Controls.lblControl lbMenu_Method;
        private Epoint.Systems.Controls.txtTextBox txtMenu_Method;
        private Epoint.Systems.Controls.lblControl lbMenu_Para;
        private Epoint.Systems.Controls.txtTextBox txtMenu_Para;
		private Epoint.Systems.Controls.lblControl lbStt;
		private Epoint.Systems.Controls.numControl numMenu_Id;
		private Epoint.Systems.Controls.numControl numMenu_Parent;
		private Epoint.Systems.Controls.numControl numStt;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.chkControl chkShow_On_Main;
        private Epoint.Systems.Controls.chkControl chkIs_Customize;
		private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.lbtControl lbtObject_Name;
        private Systems.Controls.txtTextLookup txtObject_ID;
        
        
    }
}