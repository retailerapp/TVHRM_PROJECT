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

namespace Epoint.Controllers
{
	public partial class frmZones_Edit : Epoint.Systems.Customizes.frmEdit
	{
		public frmZones_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			//this.Text = enuNew_Edit == enuEdit.New ? "Add Column" : "Edit Column";

			Common.ScaterMemvar(this, ref drEdit);

            this.BindingLanguage();
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			if (txtZone.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgCancel("Vùng chứa cột không được rỗng");
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu vao CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSZONE", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Zone", drEdit);

			return true;
		}

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
	}
}