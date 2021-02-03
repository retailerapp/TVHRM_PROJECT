namespace Epoint.Controllers
{
    partial class frmModule_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModule_Edit));
            this.lbModule_Id = new Epoint.Systems.Controls.lblControl();
            this.lbModule_Name = new Epoint.Systems.Controls.lblControl();
            this.lbMa_Nh_Dt_Cha = new Epoint.Systems.Controls.lblControl();
            this.txtModule_Name = new Epoint.Systems.Controls.txtTextBox();
            this.lbTen_Module_Parent = new Epoint.Systems.Controls.lblControl();
            this.lbModule_NameE = new Epoint.Systems.Controls.lblControl();
            this.txtModule_NameE = new Epoint.Systems.Controls.txtTextBox();
            this.label1 = new Epoint.Systems.Controls.lblControl();
            this.txtPicture = new Epoint.Systems.Controls.txtTextBox();
            this.label2 = new Epoint.Systems.Controls.lblControl();
            this.txtModule_Method = new Epoint.Systems.Controls.txtTextBox();
            this.label3 = new Epoint.Systems.Controls.lblControl();
            this.txtModule_Para = new Epoint.Systems.Controls.txtTextBox();
            this.label4 = new Epoint.Systems.Controls.lblControl();
            this.numModule_Parent = new Epoint.Systems.Controls.numControl();
            this.numModule_Id = new Epoint.Systems.Controls.numControl();
            this.numStt = new Epoint.Systems.Controls.numControl();
            this.chkIs_Module = new Epoint.Systems.Controls.chkControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.chkShow_On_Main = new Epoint.Systems.Controls.chkControl();
            this.chkIs_Customize = new Epoint.Systems.Controls.chkControl();
            this.lblControl1 = new Epoint.Systems.Controls.lblControl();
            this.lbtObject_Name = new Epoint.Systems.Controls.lbtControl();
            this.txtModule_NameO = new Epoint.Systems.Controls.txtTextBox();
            this.lblModule_NameO = new Epoint.Systems.Controls.lblControl();
            this.txtObject_ID = new Epoint.Systems.Controls.txtTextLookup();
            this.SuspendLayout();
            // 
            // lbModule_Id
            // 
            this.lbModule_Id.AutoEllipsis = true;
            this.lbModule_Id.AutoSize = true;
            this.lbModule_Id.BackColor = System.Drawing.Color.Transparent;
            this.lbModule_Id.Location = new System.Drawing.Point(41, 25);
            this.lbModule_Id.Name = "lbModule_Id";
            this.lbModule_Id.Size = new System.Drawing.Size(54, 13);
            this.lbModule_Id.TabIndex = 0;
            this.lbModule_Id.Tag = "Module_Id";
            this.lbModule_Id.Text = "Module Id";
            this.lbModule_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbModule_Name
            // 
            this.lbModule_Name.AutoEllipsis = true;
            this.lbModule_Name.AutoSize = true;
            this.lbModule_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbModule_Name.Location = new System.Drawing.Point(41, 48);
            this.lbModule_Name.Name = "lbModule_Name";
            this.lbModule_Name.Size = new System.Drawing.Size(63, 13);
            this.lbModule_Name.TabIndex = 0;
            this.lbModule_Name.Tag = "Module_Name";
            this.lbModule_Name.Text = "Tên module";
            this.lbModule_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMa_Nh_Dt_Cha
            // 
            this.lbMa_Nh_Dt_Cha.AutoEllipsis = true;
            this.lbMa_Nh_Dt_Cha.AutoSize = true;
            this.lbMa_Nh_Dt_Cha.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Nh_Dt_Cha.Location = new System.Drawing.Point(41, 117);
            this.lbMa_Nh_Dt_Cha.Name = "lbMa_Nh_Dt_Cha";
            this.lbMa_Nh_Dt_Cha.Size = new System.Drawing.Size(63, 13);
            this.lbMa_Nh_Dt_Cha.TabIndex = 0;
            this.lbMa_Nh_Dt_Cha.Tag = "Module_Parent";
            this.lbMa_Nh_Dt_Cha.Text = "Module cha";
            this.lbMa_Nh_Dt_Cha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModule_Name
            // 
            this.txtModule_Name.bEnabled = true;
            this.txtModule_Name.bIsLookup = false;
            this.txtModule_Name.bReadOnly = false;
            this.txtModule_Name.bRequire = false;
            this.txtModule_Name.KeyFilter = "";
            this.txtModule_Name.Location = new System.Drawing.Point(158, 45);
            this.txtModule_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtModule_Name.Name = "txtModule_Name";
            this.txtModule_Name.Size = new System.Drawing.Size(375, 20);
            this.txtModule_Name.TabIndex = 2;
            this.txtModule_Name.UseAutoFilter = false;
            // 
            // lbTen_Module_Parent
            // 
            this.lbTen_Module_Parent.AutoEllipsis = true;
            this.lbTen_Module_Parent.AutoSize = true;
            this.lbTen_Module_Parent.BackColor = System.Drawing.Color.Transparent;
            this.lbTen_Module_Parent.ForeColor = System.Drawing.Color.Blue;
            this.lbTen_Module_Parent.Location = new System.Drawing.Point(216, 117);
            this.lbTen_Module_Parent.Name = "lbTen_Module_Parent";
            this.lbTen_Module_Parent.Size = new System.Drawing.Size(84, 13);
            this.lbTen_Module_Parent.TabIndex = 5;
            this.lbTen_Module_Parent.Text = "Tên module cha";
            this.lbTen_Module_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbModule_NameE
            // 
            this.lbModule_NameE.AutoEllipsis = true;
            this.lbModule_NameE.AutoSize = true;
            this.lbModule_NameE.BackColor = System.Drawing.Color.Transparent;
            this.lbModule_NameE.Location = new System.Drawing.Point(41, 71);
            this.lbModule_NameE.Name = "lbModule_NameE";
            this.lbModule_NameE.Size = new System.Drawing.Size(73, 13);
            this.lbModule_NameE.TabIndex = 0;
            this.lbModule_NameE.Tag = "Module_Name_En";
            this.lbModule_NameE.Text = "Tên tiếng anh";
            this.lbModule_NameE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModule_NameE
            // 
            this.txtModule_NameE.bEnabled = true;
            this.txtModule_NameE.bIsLookup = false;
            this.txtModule_NameE.bReadOnly = false;
            this.txtModule_NameE.bRequire = false;
            this.txtModule_NameE.KeyFilter = "";
            this.txtModule_NameE.Location = new System.Drawing.Point(158, 68);
            this.txtModule_NameE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtModule_NameE.Name = "txtModule_NameE";
            this.txtModule_NameE.Size = new System.Drawing.Size(375, 20);
            this.txtModule_NameE.TabIndex = 3;
            this.txtModule_NameE.UseAutoFilter = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(41, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "File_Image";
            this.label1.Text = "File hình ảnh";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPicture
            // 
            this.txtPicture.bEnabled = true;
            this.txtPicture.bIsLookup = false;
            this.txtPicture.bReadOnly = false;
            this.txtPicture.bRequire = false;
            this.txtPicture.KeyFilter = "";
            this.txtPicture.Location = new System.Drawing.Point(158, 137);
            this.txtPicture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.Size = new System.Drawing.Size(375, 20);
            this.txtPicture.TabIndex = 6;
            this.txtPicture.UseAutoFilter = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(41, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "MODULE_METHOD";
            this.label2.Text = "Phương thức gọi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModule_Method
            // 
            this.txtModule_Method.bEnabled = true;
            this.txtModule_Method.bIsLookup = false;
            this.txtModule_Method.bReadOnly = false;
            this.txtModule_Method.bRequire = false;
            this.txtModule_Method.KeyFilter = "";
            this.txtModule_Method.Location = new System.Drawing.Point(158, 160);
            this.txtModule_Method.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtModule_Method.Name = "txtModule_Method";
            this.txtModule_Method.Size = new System.Drawing.Size(375, 20);
            this.txtModule_Method.TabIndex = 7;
            this.txtModule_Method.UseAutoFilter = false;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(41, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Tag = "Module_Para";
            this.label3.Text = "Các tham số";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModule_Para
            // 
            this.txtModule_Para.bEnabled = true;
            this.txtModule_Para.bIsLookup = false;
            this.txtModule_Para.bReadOnly = false;
            this.txtModule_Para.bRequire = false;
            this.txtModule_Para.KeyFilter = "";
            this.txtModule_Para.Location = new System.Drawing.Point(158, 183);
            this.txtModule_Para.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtModule_Para.Name = "txtModule_Para";
            this.txtModule_Para.Size = new System.Drawing.Size(375, 20);
            this.txtModule_Para.TabIndex = 8;
            this.txtModule_Para.UseAutoFilter = false;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(401, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Tag = "Stt";
            this.label4.Text = "Số thứ tự";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numModule_Parent
            // 
            this.numModule_Parent.bEnabled = true;
            this.numModule_Parent.bFormat = true;
            this.numModule_Parent.bIsLookup = false;
            this.numModule_Parent.bReadOnly = false;
            this.numModule_Parent.bRequire = false;
            this.numModule_Parent.KeyFilter = "";
            this.numModule_Parent.Location = new System.Drawing.Point(158, 114);
            this.numModule_Parent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numModule_Parent.Name = "numModule_Parent";
            this.numModule_Parent.Scale = 0;
            this.numModule_Parent.Size = new System.Drawing.Size(53, 20);
            this.numModule_Parent.TabIndex = 5;
            this.numModule_Parent.Text = "0";
            this.numModule_Parent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numModule_Parent.UseAutoFilter = false;
            this.numModule_Parent.Value = 0D;
            // 
            // numModule_Id
            // 
            this.numModule_Id.bEnabled = true;
            this.numModule_Id.bFormat = true;
            this.numModule_Id.bIsLookup = false;
            this.numModule_Id.bReadOnly = false;
            this.numModule_Id.bRequire = false;
            this.numModule_Id.KeyFilter = "";
            this.numModule_Id.Location = new System.Drawing.Point(158, 22);
            this.numModule_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numModule_Id.Name = "numModule_Id";
            this.numModule_Id.Scale = 0;
            this.numModule_Id.Size = new System.Drawing.Size(53, 20);
            this.numModule_Id.TabIndex = 0;
            this.numModule_Id.Text = "0";
            this.numModule_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numModule_Id.UseAutoFilter = false;
            this.numModule_Id.Value = 0D;
            // 
            // numStt
            // 
            this.numStt.bEnabled = true;
            this.numStt.bFormat = true;
            this.numStt.bIsLookup = false;
            this.numStt.bReadOnly = false;
            this.numStt.bRequire = false;
            this.numStt.KeyFilter = "";
            this.numStt.Location = new System.Drawing.Point(458, 22);
            this.numStt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numStt.Name = "numStt";
            this.numStt.Scale = 0;
            this.numStt.Size = new System.Drawing.Size(75, 20);
            this.numStt.TabIndex = 1;
            this.numStt.Text = "0";
            this.numStt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStt.UseAutoFilter = false;
            this.numStt.Value = 0D;
            // 
            // chkIs_Module
            // 
            this.chkIs_Module.AutoSize = true;
            this.chkIs_Module.Location = new System.Drawing.Point(158, 234);
            this.chkIs_Module.Name = "chkIs_Module";
            this.chkIs_Module.Size = new System.Drawing.Size(104, 17);
            this.chkIs_Module.TabIndex = 10;
            this.chkIs_Module.Tag = "Module_Visible";
            this.chkIs_Module.Text = "Hiển thị phân hệ";
            this.chkIs_Module.UseVisualStyleBackColor = true;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(368, 310);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 13;
            // 
            // chkShow_On_Main
            // 
            this.chkShow_On_Main.AutoSize = true;
            this.chkShow_On_Main.Location = new System.Drawing.Point(158, 256);
            this.chkShow_On_Main.Name = "chkShow_On_Main";
            this.chkShow_On_Main.Size = new System.Drawing.Size(137, 17);
            this.chkShow_On_Main.TabIndex = 11;
            this.chkShow_On_Main.Tag = "Show_On_Main";
            this.chkShow_On_Main.Text = "Hiện thị trong form main";
            this.chkShow_On_Main.UseVisualStyleBackColor = true;
            // 
            // chkIs_Customize
            // 
            this.chkIs_Customize.AutoSize = true;
            this.chkIs_Customize.Location = new System.Drawing.Point(158, 278);
            this.chkIs_Customize.Name = "chkIs_Customize";
            this.chkIs_Customize.Size = new System.Drawing.Size(122, 17);
            this.chkIs_Customize.TabIndex = 12;
            this.chkIs_Customize.Tag = "Module_Customize";
            this.chkIs_Customize.Text = "Là dữ liệu customize";
            this.chkIs_Customize.UseVisualStyleBackColor = true;
            // 
            // lblControl1
            // 
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = System.Drawing.Color.Transparent;
            this.lblControl1.Location = new System.Drawing.Point(41, 209);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(112, 13);
            this.lblControl1.TabIndex = 0;
            this.lblControl1.Tag = "Module_Object";
            this.lblControl1.Text = "Đối tượng phân quyền";
            this.lblControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbtObject_Name
            // 
            this.lbtObject_Name.AutoEllipsis = true;
            this.lbtObject_Name.AutoSize = true;
            this.lbtObject_Name.ForeColor = System.Drawing.Color.Blue;
            this.lbtObject_Name.Location = new System.Drawing.Point(300, 210);
            this.lbtObject_Name.Name = "lbtObject_Name";
            this.lbtObject_Name.Size = new System.Drawing.Size(133, 13);
            this.lbtObject_Name.TabIndex = 14;
            this.lbtObject_Name.Text = "Tên đối tượng phân quyền";
            this.lbtObject_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModule_NameO
            // 
            this.txtModule_NameO.bEnabled = true;
            this.txtModule_NameO.bIsLookup = false;
            this.txtModule_NameO.bReadOnly = false;
            this.txtModule_NameO.bRequire = false;
            this.txtModule_NameO.KeyFilter = "";
            this.txtModule_NameO.Location = new System.Drawing.Point(158, 91);
            this.txtModule_NameO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtModule_NameO.Name = "txtModule_NameO";
            this.txtModule_NameO.Size = new System.Drawing.Size(375, 20);
            this.txtModule_NameO.TabIndex = 4;
            this.txtModule_NameO.UseAutoFilter = false;
            // 
            // lblModule_NameO
            // 
            this.lblModule_NameO.AutoEllipsis = true;
            this.lblModule_NameO.AutoSize = true;
            this.lblModule_NameO.BackColor = System.Drawing.Color.Transparent;
            this.lblModule_NameO.Location = new System.Drawing.Point(41, 94);
            this.lblModule_NameO.Name = "lblModule_NameO";
            this.lblModule_NameO.Size = new System.Drawing.Size(79, 13);
            this.lblModule_NameO.TabIndex = 15;
            this.lblModule_NameO.Tag = "Module_Name_Other";
            this.lblModule_NameO.Text = "Tên tiếng khác";
            this.lblModule_NameO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtObject_ID.Location = new System.Drawing.Point(158, 206);
            this.txtObject_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtObject_ID.Name = "txtObject_ID";
            this.txtObject_ID.Size = new System.Drawing.Size(137, 20);
            this.txtObject_ID.TabIndex = 9;
            this.txtObject_ID.UseAutoFilter = true;
            // 
            // frmModule_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 360);
            this.Controls.Add(this.txtObject_ID);
            this.Controls.Add(this.txtModule_NameO);
            this.Controls.Add(this.lblModule_NameO);
            this.Controls.Add(this.lbtObject_Name);
            this.Controls.Add(this.chkIs_Customize);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.chkShow_On_Main);
            this.Controls.Add(this.chkIs_Module);
            this.Controls.Add(this.numModule_Id);
            this.Controls.Add(this.numStt);
            this.Controls.Add(this.numModule_Parent);
            this.Controls.Add(this.lbTen_Module_Parent);
            this.Controls.Add(this.txtModule_NameE);
            this.Controls.Add(this.txtModule_Para);
            this.Controls.Add(this.txtModule_Method);
            this.Controls.Add(this.txtPicture);
            this.Controls.Add(this.txtModule_Name);
            this.Controls.Add(this.lblControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbModule_NameE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbMa_Nh_Dt_Cha);
            this.Controls.Add(this.lbModule_Name);
            this.Controls.Add(this.lbModule_Id);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModule_Edit";
            this.Tag = "frmModule";
            this.Text = "frmModule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Epoint.Systems.Controls.lblControl lbModule_Id;
        private Epoint.Systems.Controls.lblControl lbModule_Name;
        private Epoint.Systems.Controls.lblControl lbMa_Nh_Dt_Cha;
		private Epoint.Systems.Controls.txtTextBox txtModule_Name;
        private Epoint.Systems.Controls.lblControl lbTen_Module_Parent;
        private Epoint.Systems.Controls.lblControl lbModule_NameE;
        private Epoint.Systems.Controls.txtTextBox txtModule_NameE;
        private Epoint.Systems.Controls.lblControl label1;
        private Epoint.Systems.Controls.txtTextBox txtPicture;
        private Epoint.Systems.Controls.lblControl label2;
        private Epoint.Systems.Controls.txtTextBox txtModule_Method;
        private Epoint.Systems.Controls.lblControl label3;
        private Epoint.Systems.Controls.txtTextBox txtModule_Para;
		private Epoint.Systems.Controls.lblControl label4;
		private Epoint.Systems.Controls.numControl numModule_Parent;
		private Epoint.Systems.Controls.numControl numModule_Id;
		private Epoint.Systems.Controls.numControl numStt;
		private Epoint.Systems.Controls.chkControl chkIs_Module;
		private Epoint.Systems.Customizes.btgAccept btgAccept;
		private Epoint.Systems.Controls.chkControl chkShow_On_Main;
		private Epoint.Systems.Controls.chkControl chkIs_Customize;
        private Epoint.Systems.Controls.lblControl lblControl1;
		private Epoint.Systems.Controls.lbtControl lbtObject_Name;
        private Systems.Controls.txtTextBox txtModule_NameO;
        private Systems.Controls.lblControl lblModule_NameO;
        private Systems.Controls.txtTextLookup txtObject_ID;
        
        
    }
}