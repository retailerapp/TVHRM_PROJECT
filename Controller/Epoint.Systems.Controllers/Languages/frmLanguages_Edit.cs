using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmLanguages_Edit : Epoint.Systems.Customizes.frmEdit
	{
		#region Phuong thuc

		public frmLanguages_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.BindingLanguage();
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtLanguage_ID.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgOk("Mã ngôn ngữ không được rỗng");
				return false;
			}

			return bvalid;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSLANGUAGE", ref drEdit))
				return false;

			return true;
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