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
using Epoint.Systems.Customizes;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmUser_Edit : Epoint.Systems.Customizes.frmEdit
	{
		public frmUser_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);

            this.btMember_Access.Click += new EventHandler(btMember_Access_Click);
            this.btMember_ID_Allow.Click += new EventHandler(btMember_ID_Allow_Click);

			txtMa_CbNv.Validating += new CancelEventHandler(txtMa_CbNv_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_DvCs_Default.Validating += new CancelEventHandler(txtMa_DvCs_Default_Validating);
            //txtLanguage_Default.Validating += new CancelEventHandler(txtLanguage_Default_Validating);
		}

        void btMember_Access_Click(object sender, EventArgs e)
        {
            string strValue = txtMember_Access.Text.Trim();

            string strMember_ID_Old = txtMember_Access.Text.Trim();

            DataRow drLookup = Lookup.ShowMultiLookup("Member_ID", "", true, "Member_Type='U'", "");
            if (drLookup != null)
            {
                if (strMember_ID_Old != "")
                    txtMember_Access.Text = strMember_ID_Old + "," + drLookup["MuiltiSelectValue"].ToString();
                if (strMember_ID_Old == "")
                    txtMember_Access.Text = strMember_ID_Old + drLookup["MuiltiSelectValue"].ToString();            
            }

        }

        void btMember_ID_Allow_Click(object sender, EventArgs e)
        {
            string strValue = txtMember_Access.Text.Trim();

            string strMember_ID_Old = txtMember_ID_Allow.Text.Trim();

            DataRow drLookup = Lookup.ShowMultiLookup("Member_ID", "Member_Type='U'", true, "", "");
            if (drLookup != null)
            {
                if (strMember_ID_Old != "")
                    txtMember_ID_Allow.Text = strMember_ID_Old + "," + drLookup["MuiltiSelectValue"].ToString();
                if(strMember_ID_Old == "")
                    txtMember_ID_Allow.Text = strMember_ID_Old + drLookup["MuiltiSelectValue"].ToString();
            }
        }

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
		{
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;

            string strMsg_Add = Element.sysLanguage == enuLanguageType.Vietnamese ? "Thêm mới người sử dụng" : "Add new user";
            string strMsg_Edit = Element.sysLanguage == enuLanguageType.Vietnamese ? "Sửa người sử dụng" : "Edit user";
            this.Text = (enuNew_Edit == enuEdit.New) ? strMsg_Add : strMsg_Edit;

			Common.ScaterMemvar(this, ref drEdit);

			if (enuNew_Edit == enuEdit.New)
			{
				txtPassword.Text = string.Empty;
				txtPassword_Re.Text = string.Empty;

				txtPassword.ReadOnly = false;
				txtPassword_Re.ReadOnly = false;
			}
			else
			{
				txtPassword.ReadOnly = true;
				txtPassword_Re.ReadOnly = true;

				enuIs_Admin.Enabled = Epoint.Systems.Elements.Element.sysIs_Admin;
				txtMember_ID_Allow.Enabled = Epoint.Systems.Elements.Element.sysIs_Admin;
				txtMa_CbNv.Enabled = Epoint.Systems.Elements.Element.sysIs_Admin;
				chkWeb_Login.Enabled = Epoint.Systems.Elements.Element.sysIs_Admin;
			}

			this.BindingLanguage();
			this.LoadDicName();

			this.ShowDialog();
		}

		void LoadDicName()
		{
            //Ma_CbNv
			if (txtMa_CbNv.Text.Trim() != string.Empty)
			{
				lbtTen_CbNv.Text = DataTool.SQLGetNameByCode("LINHANVIEN", "MA_CBNV", "TEN_CBNV", txtMa_CbNv.Text.Trim());
			}
			else
				lbtTen_CbNv.Text = string.Empty;

            //Ma_Bp
            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("LIBOPHAN", "MA_BP", "TEN_BP", txtMa_Bp.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;

            //Ma_Dvcs
            if (txtMa_DvCs_Default.Text.Trim() != string.Empty)
            {
                lbtTen_DvCs_Default.Text = DataTool.SQLGetNameByCode("SYSDMDVCS", "MA_DVCS", "TEN_DVCS", txtMa_DvCs_Default.Text.Trim());
            }
            else
                lbtTen_DvCs_Default.Text = string.Empty;

            ////Language
            //if (txtLanguage_Default.Text.Trim() != string.Empty)
            //{
            //    if (txtLanguage_Default.Text == "V")
            //        lbtTen_Language_Default.Text = "Việt Nam";
            //    if (txtLanguage_Default.Text == "E")
            //        lbtTen_Language_Default.Text = "English";
            //    if (txtLanguage_Default.Text == "O")
            //        lbtTen_Language_Default.Text = "Other";
            //}
            //else
            //    lbtTen_Language_Default.Text = string.Empty;

		}

		private bool FormCheckValid()
		{
			if (this.txtMember_ID.Text.Trim() == string.Empty)
			{				
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã người dùng không được rỗng" : "User ID is not empty";

                MessageBox.Show(strMsg);
				return false;
			}
			if (this.txtMember_Name.Text.Trim() == string.Empty)
			{
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tên người dùng không được rỗng" : "User name is not empty";

                MessageBox.Show(strMsg);
				return false;
			}
			if (enuNew_Edit == enuEdit.New)
				if (this.txtPassword.Text.Trim() != this.txtPassword_Re.Text.Trim())
				{					
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Xác nhận lại mật khẩu không đúng" : "Confirm password is incorrect";

                    MessageBox.Show(strMsg);
					return false;
				}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref this.drEdit);

			if (!this.FormCheckValid())
				return false;

			if (enuNew_Edit == enuEdit.New)
				drEdit["Locked"] = false;

			System.Collections.Hashtable ht = new System.Collections.Hashtable();
			ht.Add("MEMBER_ID", drEdit["Member_ID"]);
			ht.Add("MEMBER_NAME", drEdit["Member_Name"]);
			ht.Add("MEMBER_TYPE", drEdit["Member_Type"]);
			ht.Add("IS_ADMIN", drEdit["Is_Admin"]);
			ht.Add("LOCKED", drEdit["Locked"]);
			ht.Add("MEMBER_ID_ALLOW", drEdit["Member_ID_Allow"]);
            ht.Add("MEMBER_ACCESS", drEdit["Member_Access"]);
			ht.Add("PASSWORD", ((string)drEdit["Password"]).Trim());

			string strSQLExec = string.Empty;

			if (enuNew_Edit == enuEdit.New)
			{
				strSQLExec =
					"INSERT INTO SYSMEMBER (Member_ID, Member_Name, Member_Type, Is_Admin, Locked, Member_ID_Allow, Member_Access, CheckPass) " +
                    "	VALUES (@Member_ID, @Member_Name, @Member_Type, @Is_Admin, @Locked, @Member_ID_Allow, @Member_Access, dbo.fn_Encrypt(@Password))";
			}
			else
			{
				strSQLExec =
					"UPDATE SYSMEMBER SET " +
					"		Member_ID = @Member_ID, Member_Name = @Member_Name, Member_Type = @Member_Type, Is_Admin = @Is_Admin, " +
                    "		Locked = @Locked, Member_ID_Allow = @Member_ID_Allow, Member_Access = @Member_Access " +
					"	WHERE Member_ID = '" + (string)drEdit["Member_ID", DataRowVersion.Original] + "'";
			}

			if (!SQLExec.Execute(strSQLExec, ht, CommandType.Text))
				return false;

			//Thêm cột Ma_CbNv phục vụ cho CRM
			if (drEdit.Table.Columns.Contains("Ma_CbNv"))
			{
				strSQLExec = "UPDATE SYSMEMBER SET Ma_CbNv = '" + (string)drEdit["Ma_CbNv"] + "' WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "'";

				SQLExec.Execute(strSQLExec);
			}

            //Thêm cột Ma_Bp
            if (drEdit.Table.Columns.Contains("Ma_Bp"))
            {
                strSQLExec = "UPDATE SYSMEMBER SET Ma_Bp = '" + (string)drEdit["Ma_Bp"] + "' WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "'";

                SQLExec.Execute(strSQLExec);
            }

            //Thêm cột Ma_DvCs_Default phục vụ cho nhiều XN trực thuộc
            if (drEdit.Table.Columns.Contains("Ma_DvCs_Default"))
			{
				strSQLExec = "UPDATE SYSMEMBER SET Ma_DvCs_Default = '" + (string)drEdit["Ma_DvCs_Default"] + "' WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "'";

				SQLExec.Execute(strSQLExec);
			}
            //Thêm cột Language_Default
            if (drEdit.Table.Columns.Contains("Language_Default"))
            {
                strSQLExec = "UPDATE SYSMEMBER SET Language_Default = '" + (string)drEdit["Language_Default"] + "' WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "'";

                SQLExec.Execute(strSQLExec);
            }
			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MEMBER_ID", drEdit);

			return true;
		}

		void txtMa_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_CbNv.Text.Trim();
			bool bRequire = false;

			frmQuickLookup frmLookup = new frmQuickLookup();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LINHANVIEN", "Ma_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_CbNv.Text = string.Empty;
				lbtTen_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_CbNv.Text = drLookup["Ma_CbNv"].ToString();
				lbtTen_CbNv.Text = drLookup["Ten_CbNv"].ToString();
			}

			dicName.SetValue(lbtTen_CbNv.Name, lbtTen_CbNv.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}

        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;

            frmQuickLookup frmLookup = new frmQuickLookup();
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIBOPHAN", "Ma_Bp", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
            }

            dicName.SetValue(lbtTen_Bp.Name, lbtTen_Bp.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		private void txtMa_DvCs_Default_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_DvCs_Default.Text.Trim();
			bool bRequire = true;
			string strFilter = "Ma_Data LIKE '%'";

			frmQuickLookup frmLookup = new frmQuickLookup();
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSDMDVCS", "Ma_DvCs", strValue, bRequire, strFilter);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_DvCs_Default.Text = string.Empty;
				lbtTen_DvCs_Default.Text = string.Empty;
			}
			else
			{
				txtMa_DvCs_Default.Text = drLookup["Ma_DvCs"].ToString();
				lbtTen_DvCs_Default.Text = drLookup["Ten_DvCs"].ToString();
			}
		}

        //private void txtLanguage_Default_Validating(object sender, CancelEventArgs e)
        //{
        //    //Language
        //    if (txtLanguage_Default.Text.Trim() != string.Empty)
        //    {
        //        if (txtLanguage_Default.Text == "V")
        //            lbtTen_Language_Default.Text = "Việt Nam";
        //        if (txtLanguage_Default.Text == "E")
        //            lbtTen_Language_Default.Text = "English";
        //        if (txtLanguage_Default.Text == "O")
        //            lbtTen_Language_Default.Text = "Other";
        //    }
        //    else
        //        lbtTen_Language_Default.Text = string.Empty;
        //}
        
	}
}