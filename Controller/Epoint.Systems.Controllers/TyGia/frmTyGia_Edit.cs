using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmTyGia_Edit : Epoint.Systems.Customizes.frmEdit
	{
        #region Phuong thuc

		public frmTyGia_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;

			this.Text = enuNew_Edit == enuEdit.New ? "Them moi ty gia" : "Sua ty gia";

			Common.ScaterMemvar(this, ref drEdit);

			string strMa_Tte_List = (string)SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSParameter WHERE Parameter_ID = 'MA_TTE_LIST'");
			enuMa_Tte.InputMask = strMa_Tte_List.Replace(" ", "");

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
		}

		public bool FormCheckValid()
        {
            bool bvalid = true ;
            if (enuMa_Tte.Text.Trim() == string.Empty)
            {
				EpointMessage.MsgOk(Languages.GetLanguage("Ma_Tte") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			
            return bvalid;
        }

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSTyGia", ref drEdit))
				return false;

			return true;
		}

        #endregion

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
	}
}