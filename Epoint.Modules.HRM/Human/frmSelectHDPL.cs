using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

using Epoint.Systems;
using System.Windows.Forms;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Modules.HRM
{
	public partial class frmSelectHDPL : Epoint.Systems.Customizes.frmEdit
	{
		public string FileId = string.Empty;
		public frmSelectHDPL()
		{
			InitializeComponent();          
			this.btSave.Click += new EventHandler(btSave_Click);			
		}

		public void Load()
		{		
			//this.cboFile_Type.DataSource = SQLExec.ExecuteReturnDt("SP_HRM_GetDataCombobox 'PLHOPDONGTYPE'");
			//this.cboFile_Type.DisplayMember = "Label";
			//this.cboFile_Type.ValueMember = "Code";


			DataTable dtDmHD = SQLExec.ExecuteReturnDt("SP_HRM_GetDataCombobox 'PLHOPDONGTYPE'");
			//dtDmBp.Rows.Add(new string[] { "*", "Tất cả" });

			cboFile_Id.lstItem.BuildListView("Code:200,Label:400");
			cboFile_Id.lstItem.DataSource = dtDmHD;
			cboFile_Id.lstItem.Size = new Size(320, cboFile_Id.lstItem.Items.Count * 30);
			cboFile_Id.lstItem.GridLines = true;
			btSave.Enabled = true;
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;

			this.FileId = cboFile_Id.Text;
			return true;
		}

		void chkDuyet_CheckedChanged(object sender, EventArgs e)
		{
			this.btSave.Enabled = true;
		}

		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Common.ScaterMemvar(this, ref drEdit);

			btSave.Enabled = false;
		}

		void btSave_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				this.Save();
                this.isAccept = true;
				this.Close();
			}
		}		
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

           
        }
	}
}
