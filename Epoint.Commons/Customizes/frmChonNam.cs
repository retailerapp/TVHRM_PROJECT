using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Systems.Customizes
{
	public partial class frmChonNam : Epoint.Systems.Customizes.frmEdit
	{
		BindingSource bdsNam = new BindingSource();
		DataTable dtNam;

		public frmChonNam()
		{
			InitializeComponent();

			lvNam.MouseDoubleClick += new MouseEventHandler(lvNam_MouseDoubleClick);
			lvNam.KeyDown += new KeyEventHandler(lvNam_KeyDown);
			btAccept1.Click += new EventHandler(btAccept1_Click);
		}

		public void Load()
		{
			this.Build();
			this.FillData();

			foreach (ListViewItem lvi in lvNam.Items)
			{
				if (lvi.Text == Element.sysWorkingYear.ToString().Trim())
				{
					lvi.Selected = true;
					lvNam.MoveDataSourceToCurrentRow();
				
					break;
				}
			}

			this.BindingLanguage();

			this.ShowDialog();
		}

		void Build()
		{
			lvNam.BuildListView("Nam:150");
		}

		void FillData()
		{
			dtNam = SQLExec.ExecuteReturnDt("SELECT * FROM SYSNam WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' ORDER BY Nam");

			bdsNam.DataSource = dtNam;
			lvNam.DataSource = bdsNam;
		}

		void SelectNam()
		{
            frmMain frmMain = (frmMain)Elements.Element.frmMain;

            Commons.Common.CloseAllForm(frmMain);

			lvNam.MoveDataSourceToCurrentRow();

			DataRow drCurrent = ((DataRowView)bdsNam.Current).Row;

			int iNam = Convert.ToInt32(drCurrent["Nam"]);

			if (chkPartitionChange.Checked)
			{
				if (Commons.Common.SelectPartition(iNam))
				{
					Commons.Common.ShowPartition();
					Commons.Common.SetSysWorkingYear(iNam);
				}
				else
				{
					Commons.EpointMessage.MsgCancel("Cannot change partition data " + iNam.ToString());
					return;
				}
			}
			else
				Commons.Common.SetSysWorkingYear(iNam);

			this.Close();
		}

		void lvNam_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.SelectNam();
		}

		void lvNam_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				this.SelectNam();
		}

		void btAccept1_Click(object sender, EventArgs e)
		{
			this.SelectNam();
		}
	}
}
