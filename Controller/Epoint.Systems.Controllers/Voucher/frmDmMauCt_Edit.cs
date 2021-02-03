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
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmDmMauCt_Edit : Epoint.Systems.Customizes.frmEdit
	{

		#region Phuong thuc

		public frmDmMauCt_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSDMMAUCT", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Ma_Ct", drEdit);

			return true;
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Ct.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgOk(Languages.GetLanguage("Ma_Ct") + " " +
								Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Mau.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgOk(Languages.GetLanguage("Ten_Ct") + " " +
								Languages.GetLanguage("Not_Null"));
				return false;
			}
            object objMa_Ct = SQLExec.ExecuteReturnValue("SELECT Ma_Ct FROM SYSDMCT WHERE '" + txtMa_Ct.Text + "' = Ma_Ct");
            if (objMa_Ct == null)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã chứng từ {" + txtMa_Ct.Text + "} không tồn tại trong Danh mục chứng từ" : "Tax Code {" + txtMa_Ct.Text + "} has existed in the Object Catalogue";
                Common.MsgCancel(strMsg);
                this.ActiveControl = txtMa_Ct;
                return false;
            }

            objMa_Ct = SQLExec.ExecuteReturnValue("SELECT Ma_Mau FROM SYSDMMAUCT WHERE '" + txtMa_Ct.Text + "' = Ma_Ct AND '" + txtMa_Mau.Text + "' = Ma_Mau");
            if (objMa_Ct != null && objMa_Ct == txtMa_Mau.Text)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã Ct {" + txtMa_Ct.Text + "} và Mã mẫu {" + txtMa_Mau.Text + "} đã tồn tại trong Danh mục chứng từ" : "Tax Code {" + txtMa_Ct.Text + "} has existed in the Object Catalogue";
                Common.MsgCancel(strMsg);
                this.ActiveControl = txtMa_Mau;
                return false;
            }
            
			return bvalid;
		}

		#endregion

		#region Su kien

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		#endregion
	}
}