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
	public partial class frmObject_Edit : Epoint.Systems.Customizes.frmEdit
	{
        #region Phuong thuc

		public frmObject_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
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

		public bool FormCheckValid()
		{
			if (txtObject_ID.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgOk(Languages.GetLanguage("Object_ID") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (enuObject_Type.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgOk(Languages.GetLanguage("Object_Type") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSObject", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Object_ID", drEdit);

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