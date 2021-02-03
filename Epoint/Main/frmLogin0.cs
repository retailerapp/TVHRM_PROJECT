using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;

using System.Globalization;
using System.Threading;
using System.Resources;
using System.Reflection;


namespace Epoint
{
    public partial class frmLogin0 : Epoint.Systems.Customizes.frmEdit
    {
        public string strUserId = string.Empty;
        string strUserPass = string.Empty;
        int iFailNumber = 0;

        public frmLogin0()
        {
            InitializeComponent();

            this.Text = "Epoint Software";
            this.BindingLanguage();

            try
            {
                txtMember_ID.Text = Epoint.Systems.Commons.Common.GetBufferValue("USERLOGIN");

            }
            catch { }

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        new void BindingLanguage()
        {
            string strDefault_Language = "V";
            strDefault_Language = DataTool.SQLGetNameByCode("SYSPARAMETER", "Parameter_ID", "Parameter_Value", "DEFAULT_LANGUAGE");


            //if (System.IO.File.Exists("Epointconfig.xml"))
            //{
            //    System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            //    xmldoc.Load("Epointconfig.xml");

            //    if (xmldoc.DocumentElement.InnerXml.Contains("<StartLanguage>"))
            //        strDefault_Language = xmldoc.DocumentElement["StartLanguage"].InnerText;
            //}

            if (strDefault_Language != null)
            {
                lblLogin_Name.Text = strDefault_Language == "E" ? "&User name" : "&Tên đăng nhập";
                lblPassword.Text = strDefault_Language == "E" ? "&Password" : "&Mật khẩu";
                btgAccept.btAccept.Text = strDefault_Language == "E" ? "&Accept" : "Đồ&ng ý";
                btgAccept.btCancel.Text = strDefault_Language == "E" ? "&Cancel" : "&Hủy bỏ";
            }
        }

        bool CheckLogin()
        {
            strUserId = txtMember_ID.Text.Trim();
            strUserPass = txtPassword.Text.Trim();

            return Epoint.Systems.Commons.EpointMethod.CheckLogin(strUserId, strUserPass);
        }
        
        void btCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
                isAccept = true;
                //try
                //{
                Epoint.Systems.Commons.Common.SetBufferValueNotCheck("USERLOGIN", txtMember_ID.Text);
                //}
                //catch { }

                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập không hợp lệ");
                this.txtPassword.Focus();
                iFailNumber++;
            }

            if (iFailNumber == 5)
            {
                MessageBox.Show("Đăng nhập sai 5 lần");
                isAccept = false;
                this.Close();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.TopMost = false;
            this.txtMember_ID.Focus();
            if (this.txtMember_ID.Text != "")
                this.txtPassword.Focus();
            this.Activate();
        }


    }
}