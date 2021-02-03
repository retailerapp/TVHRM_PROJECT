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

namespace Epoint.Controllers
{
	public partial class frmPermissionDvCs_Edit : Epoint.Systems.Customizes.frmEdit
    {
		public frmPermissionDvCs_Edit()
        {
            InitializeComponent();

			this.txtMa_DvCs.Validating += new CancelEventHandler(txtMa_DvCs_Validating); 

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
        }

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
        {
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.LoadDicName();

			this.ShowDialog();
		}

		void LoadDicName()
		{
			lbtTen_DvCs.Text = DataTool.SQLGetNameByCode("SYSDMDVCS", "Ma_DvCs", "Ten_DvCs", txtMa_DvCs.Text);
		}

		private bool FormCheckValid()
		{
			if (this.txtMa_DvCs.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Ma_DvCs") + " " + Languages.GetLanguage("CanNotEmpty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref this.drEdit);

			if (drEdit.Table.Columns.Contains("Ten_DvCs"))
				drEdit["Ten_DvCs"] = lbtTen_DvCs.Text;

			if (!this.FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSPermissionDvCs", ref drEdit))
				return false;

			return true;
		}

		void txtMa_DvCs_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_DvCs.Text.Trim();
			bool bRequire = true;
			string strKey = "(1 = 1)";

			//if (enuNew_Edit == enuEdit.New)
			//    strKey += " AND Ma_DvCs NOT IN (SELECT Ma_DvCs FROM SYSPermissionDvCs " +
			//        " WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "') ";

			frmQuickLookup frmLookup = new frmQuickLookup("SYSDMDVCS", "Ma_DvCs");
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSDMDVCS", "Ma_DvCs", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_DvCs.Text = string.Empty;
				lbtTen_DvCs.Text = string.Empty;
			}
			else
			{
				txtMa_DvCs.Text = ((string)drLookup["Ma_DvCs"]).Trim();
				lbtTen_DvCs.Text = ((string)drLookup["Ten_DvCs"]).Trim();
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
	}
}