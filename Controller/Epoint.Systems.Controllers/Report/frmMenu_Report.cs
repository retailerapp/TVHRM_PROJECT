using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
	public partial class frmMenu_Report : Epoint.Systems.Customizes.frmView
	{
		#region Fields

		private DataRow drCurrent;
		private DataTable dtMenu;
		private BindingSource bdsMenu = new BindingSource();

		private DataTable dtMenu_Report;
		private BindingSource bdsMenu_Report = new BindingSource();

		#endregion

		#region Methods

		public frmMenu_Report()
		{
			InitializeComponent();

			this.bdsMenu.PositionChanged += new EventHandler(bdsMenu_PositionChanged);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			this.dgvMenu.strZone = "MENU_LIST";
			this.dgvMenu.BuildGridView();

			this.tlMenu_Report.strZone = "MENU_REPORT";
			this.tlMenu_Report.KeyFieldName = "REPORT_ID";
			this.tlMenu_Report.ParentFieldName = "REPORT_PARENT";

			this.tlMenu_Report.BuildTreeList();

		}

		private void FillData()
		{
			//Fill du lieu cho dgvMenu
			dtMenu = DataTool.SQLGetDataTable("SYSMENU", "", "Menu_Parent IN (150,500)", "Menu_ID");

			bdsMenu.DataSource = dtMenu;
			dgvMenu.DataSource = bdsMenu;

			//Fill du lieu cho tlModule_Report
			string strQuery =
				" SELECT SYSMENURP.*, SYSREPORT.Report_Name, SYSREPORT.Report_Parent " +
					" FROM SYSMENURP INNER JOIN SYSREPORT ON SYSMENURP.Report_ID = SYSREPORT.Report_ID";

			dtMenu_Report = SQLExec.ExecuteReturnDt(strQuery);

			bdsMenu_Report.DataSource = dtMenu_Report;
			tlMenu_Report.DataSource = bdsMenu_Report;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			int iMenu_ID = (int)(((DataRowView)bdsMenu.Current).Row["Menu_ID"]);

			//Copy hang hien tai            
			if (bdsMenu_Report.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsMenu_Report.Current).Row, ref drCurrent);
			else
				drCurrent = dtMenu_Report.NewRow();

			string strValue = string.Empty;
			bool bRequire = true;

			frmQuickLookup frmLookup = new frmQuickLookup("SYSREPORT", "REPORT",false);
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSREPORT", "REPORT_ID", strValue, bRequire, "");
            //DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSREPORT", "REPORT_ID", strValue, bRequire, "","","Stt");

			if (bRequire && drLookup == null)
			{
				dtMenu_Report.RejectChanges();
				return;
			}

			if (drLookup != null)
			{
				drCurrent["Menu_ID"] = iMenu_ID;
				drCurrent["Report_ID"] = drLookup["Report_ID"];
				drCurrent["Report_Name"] = drLookup["Report_Name"];
				drCurrent["Report_Parent"] = drLookup["Report_Parent"];

				if (DataTool.SQLUpdate(enuEdit.New, "SYSMENURP", ref drCurrent))
				{
					if (bdsMenu_Report.Position >= 0)
						dtMenu_Report.ImportRow(drCurrent);
					else
						dtMenu_Report.Rows.Add(drCurrent);


					dtMenu_Report.AcceptChanges();
				}
				else
					dtMenu_Report.RejectChanges();
			}
		}

		public override void Delete()
		{
			if (bdsMenu_Report.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsMenu_Report.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("Sure_Delete")))
				return;

			if (DataTool.SQLDelete("SYSMENURP", drCurrent))
			{
				bdsMenu_Report.RemoveAt(bdsMenu_Report.Position);
				dtMenu_Report.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void bdsMenu_PositionChanged(object sender, EventArgs e)
		{
			int iMenu_ID = (int)((DataRowView)bdsMenu.Current).Row["Menu_ID"];

			bdsMenu_Report.Filter = "Menu_ID = " + iMenu_ID.ToString();
			bdsMenu_Report.Position = 0;
		}

		#endregion
	}
}
