using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmUser_ChangePass : Epoint.Systems.Customizes.frmView
    {
        DataRow drUser;
		public frmUser_ChangePass()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
		}

		public void Load()
		{
            DataTable dtUser = SQLExec.ExecuteReturnDt("SELECT Member_ID, Member_Name FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'");

            foreach (DataRow drUser0 in dtUser.Rows)
            {
                drUser = drUser0;
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Đổi mật khẩu: " : "Change Password: ";
                this.Text = strMsg + drUser["Member_ID"].ToString() + " - " + drUser["Member_Name"].ToString();                
            }

			txtPassword.Text = string.Empty;
			txtPassword_Re.Text = string.Empty;

            this.BindingLanguage();
			this.Show();
		}

		void LoadDicName()
		{

		}

		private bool FormCheckValid()
		{
			if (this.txtPassword.Text.Trim() != this.txtPassword_Re.Text.Trim())
			{
				//MessageBox.Show("Xác nhận lại mật khẩu không đúng");
                MessageBox.Show(Languages.GetLanguage("CONFIRM_PASSWORD_TITLE"));                
				return false;
			}
			return true;
		}

		private bool Save()
		{
			if (!this.FormCheckValid())
				return false;

			System.Collections.Hashtable ht = new System.Collections.Hashtable();
			ht.Add("PASSWORD", txtPassword.Text.Trim());

			string strSQLExec =
				"UPDATE SYSMember SET " +
				"		CheckPass = dbo.fn_Encrypt(@Password)" +
				"	WHERE Member_ID = '" + (string)drUser["Member_ID"] + "'";

			if (!SQLExec.Execute(strSQLExec, ht, CommandType.Text))
				return false;

			return true;
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{   
                if (Common.MsgOk(EpointMessage.GetMessage("CHANGEPASS")))
                {
                    Application.Restart(); //Doi pass xong phai khoi dong lai chuong trinh
                }                
            }
		}

		private void btCancel_Click(object sender, EventArgs e)
		{	
			this.Close();
		}
	}
}