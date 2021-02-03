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
	public partial class frmPermission_Edit : Epoint.Systems.Customizes.frmEdit
    {
		public frmPermission_Edit()
        {
            InitializeComponent();

			this.txtObject_ID.Validating += new CancelEventHandler(txtObject_ID_Validating); 

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
			lbtObject_Name.Text = DataTool.SQLGetNameByCode("SYSObject", "Object_ID", "Object_Name", txtObject_ID.Text);
		}

		private bool FormCheckValid()
		{
			if (this.txtObject_ID.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Object_ID") + " " + Languages.GetLanguage("CanNotEmpty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref this.drEdit);

			if (drEdit.Table.Columns.Contains("Object_Name"))
				drEdit["Object_Name"] = lbtObject_Name.Text;

			if (!this.FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSPermission", ref drEdit))
				return false;

			return true;
		}

		void txtObject_ID_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtObject_ID.Text.Trim();
			bool bRequire = true;
			string strKey = "(Object_Type = '" + (string)drEdit["Object_Type"] + "')";

			if (enuNew_Edit == enuEdit.New)
				strKey += " AND Object_ID NOT IN (SELECT Object_ID FROM SYSPermission " +
					" WHERE Member_ID = '" + (string)drEdit["Member_ID"] + "') ";

			frmQuickLookup frmLookup = new frmQuickLookup("SYSObject", "OBJECT");
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSObject", "Object_ID", strValue, bRequire, strKey, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtObject_ID.Text = string.Empty;
				lbtObject_Name.Text = string.Empty;
			}
			else
			{
				txtObject_ID.Text = ((string)drLookup["Object_ID"]).Trim();
				lbtObject_Name.Text = ((string)drLookup["Object_Name"]).Trim();
			}

			dicName[lbtObject_Name.Name] = lbtObject_Name.Text;
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