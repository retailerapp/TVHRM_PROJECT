using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
	public partial class ucModuleLabel : UserControl
	{
		string strModule_Name = string.Empty;
		string strModule_NameE = string.Empty;
		string strModule_NameO = string.Empty;

		public ucModuleLabel()
		{
			InitializeComponent();
		}

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);

			if (this.FindForm() == null)
				return;

			Form frm = this.FindForm();

			if (frm.GetType().Name != "frmMain")
				return;

			int iModule_ID = ((frmMain)this.FindForm()).iModule_ID;

			DataTable dtModule = Epoint.Systems.Data.SQLExec.ExecuteReturnDt("SELECT * FROM SYSMODULE WHERE Module_ID = " + iModule_ID.ToString());

			if (dtModule.Rows.Count > 0)
			{
				strModule_Name = (string)dtModule.Rows[0]["Module_Name"];
				strModule_NameE = (string)dtModule.Rows[0]["Module_NameE"];

				if (dtModule.Columns.Contains("Module_NameO"))
					strModule_NameO = (string)dtModule.Rows[0]["Module_NameO"];
			}

			if (Elements.Element.sysLanguage == enuLanguageType.English)
				this.lblControl1.Text = strModule_NameE;
			else if (Elements.Element.sysLanguage == enuLanguageType.Other)
				this.lblControl1.Text = strModule_NameO;
			else
				this.lblControl1.Text = strModule_Name;
		}
	}
}
