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
	public partial class frmModule_Menu : Epoint.Systems.Customizes.frmView
	{
		#region Fields

		private DataRow drCurrent;
		private DataTable dtModule;
		private BindingSource bdsModule = new BindingSource();

		private DataTable dtModule_Menu;
		private BindingSource bdsModule_Menu = new BindingSource();

		#endregion

		#region Methods

		public frmModule_Menu()
		{
			InitializeComponent();

			this.Resize += new EventHandler(frmModule_Menu_Resize);
			this.dgvModule.CellEnter += new DataGridViewCellEventHandler(dgvModule_CellEnter);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			this.dgvModule.strZone = "MODULE_LIST";
			this.dgvModule.BuildGridView();

			this.tlModule_Menu.strZone = "MODULE_MENU";
			this.tlModule_Menu.KeyFieldName = "MENU_ID";
			this.tlModule_Menu.ParentFieldName = "MENU_PARENT";

			this.tlModule_Menu.BuildTreeList();

		}

		private void FillData()
		{
			//Fill du lieu cho dgvModule
			dtModule = DataTool.SQLGetDataTable("SYSMODULE", "", "is_Module = 1", "Module_Id");

			bdsModule.DataSource = dtModule;
			dgvModule.DataSource = bdsModule;

			//Fill du lieu cho tlModule_Report
			string strQuery =
				" SELECT SYSMODULEME.*, SYSMENU.Menu_Name, SYSMENU.Menu_Parent " +
                    " FROM SYSMODULEME INNER JOIN SYSMENU ON SYSMODULEME.Menu_ID = SYSMENU.Menu_ID";

			dtModule_Menu = SQLExec.ExecuteReturnDt(strQuery);

			bdsModule_Menu.DataSource = dtModule_Menu;
			tlModule_Menu.DataSource = bdsModule_Menu;

		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (enuNew_Edit == enuEdit.Edit)
				return;

			int iModule_Id = (int)(((DataRowView)bdsModule.Current).Row["Module_Id"]);

			//Copy hang hien tai            
			if (bdsModule_Menu.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsModule_Menu.Current).Row, ref drCurrent);
			else
				drCurrent = dtModule_Menu.NewRow();

			string strValue = string.Empty;
			bool bRequire = true;

			frmQuickLookup frmLookup = new frmQuickLookup("SYSMENU", "MENU");
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSMENU", "MENU_ID", strValue, bRequire, "");            

			if (bRequire && drLookup == null)
			{
				dtModule_Menu.RejectChanges();
				return;
			}

			if (drLookup != null)
			{
				drCurrent["Module_Id"] = iModule_Id;
				drCurrent["Menu_ID"] = drLookup["Menu_ID"];
				drCurrent["Menu_Name"] = drLookup["Menu_Name"];
				drCurrent["Menu_Parent"] = drLookup["Menu_Parent"];

				if (DataTool.SQLUpdate(enuNew_Edit, "SYSMODULEME", ref drCurrent))
				{
					if (bdsModule_Menu.Position >= 0)
						dtModule_Menu.ImportRow(drCurrent);
					else
						dtModule_Menu.Rows.Add(drCurrent);


					dtModule_Menu.AcceptChanges();
				}
				else
					dtModule_Menu.RejectChanges();
			}
		}

		public override void Delete()
		{
			if (bdsModule_Menu.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsModule_Menu.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("Sure_Delete")))
				return;

			if (DataTool.SQLDelete("SYSMODULEME", drCurrent))
			{
				bdsModule_Menu.RemoveAt(bdsModule_Menu.Position);
				dtModule_Menu.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void frmModule_Menu_Resize(object sender, EventArgs e)
		{
			this.dgvModule.ResizeGridView();
			this.tlModule_Menu.ResizeTreeList();
		}

		void dgvModule_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvModule.Rows[e.RowIndex].Cells["Module_Id"].Value != null)
			{
				int iModule_Id = (int)dgvModule.Rows[e.RowIndex].Cells["Module_Id"].Value;

				bdsModule_Menu.Filter = "Module_Id = " + iModule_Id.ToString();
				bdsModule_Menu.Position = 0;
			}
		}

		#endregion
	}
}
