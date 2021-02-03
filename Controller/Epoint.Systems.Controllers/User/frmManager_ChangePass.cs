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
	public partial class frmManager_ChangePass : Epoint.Systems.Customizes.frmEdit
	{
		public frmManager_ChangePass()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
		}

		public void Load(ref DataRow drEdit)
		{
			this.drEdit = drEdit;

            string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Đổi mật khẩu: " : "Change Password: ";
            this.Text = strMsg + drEdit["Member_ID"].ToString() + " - " + drEdit["Member_Name"].ToString();

			txtPassword.Text = string.Empty;
			txtPassword_Re.Text = string.Empty;

            this.BindingLanguage();
			this.ShowDialog();
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
				"	WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "'";

			if (!SQLExec.Execute(strSQLExec, ht, CommandType.Text))
				return false;

			return true;
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
                this.Close();
                //if (Common.MsgOk(EpointMessage.GetMessage("CHANGEPASS")))
                //{   
                //    Application.Restart(); //Doi pass xong phai khoi dong lai chuong trinh
                //}
            }
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
	}
}