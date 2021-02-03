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
	public partial class frmLocked_Edit : Epoint.Systems.Customizes.frmEdit
	{
		private int iNam;

		#region Phuong thuc

		public frmLocked_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit, int iNam)
		{
			this.txtNam.Text = iNam.ToString();

			this.Load(enuNew_Edit, drEdit);
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
			if (txtNgay_Locked1.IsNull)
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Ngay_Locked1") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtNgay_Locked2.IsNull)
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Ngay_Locked2") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (Convert.ToDateTime(txtNgay_Locked1.Text).Year != Convert.ToInt32(txtNam.Text) || Convert.ToDateTime(txtNgay_Locked2.Text).Year != Convert.ToInt32(txtNam.Text))
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Wrong") + " " + Languages.GetLanguage("Year"));
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

			drEdit["Ma_DvCs"] = Epoint.Systems.Elements.Element.sysMa_DvCs;

			//Luu vao CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSLOCKED", ref drEdit))
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