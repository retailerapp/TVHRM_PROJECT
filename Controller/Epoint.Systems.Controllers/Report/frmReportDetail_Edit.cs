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
	public partial class frmReportDetail_Edit : Epoint.Systems.Customizes.frmEdit
	{
		#region Phuong thuc

		public frmReportDetail_Edit()
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
			if ((string)drEdit["Report_ID"] == string.Empty)
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Report_ID, Cannot_Empty"));
				return false;
			}

			if ((string)drEdit["Report_Detail_ID"] == string.Empty)
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Report_Detail_ID, Cannot_Empty"));
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSREPORTDETAIL", ref drEdit))
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