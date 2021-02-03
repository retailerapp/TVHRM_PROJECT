using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmMenuControl : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien
		bool bIsNewModMenu = false;

		tlControl tlModule;

		DataTable dtModule;
		DataTable dtMenu;

		DataRow drModule;
		DataRow drMenu;

		BindingSource bdsModule;
		BindingSource bdsMenu;

		#endregion

		#region Cac phuong thuc

		public frmMenuControl()
		{
			InitializeComponent();
			BuildTree();
			FillTree();

			this.tapgModule.Layout += new LayoutEventHandler(tapgModule_Layout);
			this.tapgMenu.Layout += new LayoutEventHandler(tapgMenu_Layout);
		}

		void BuildTree()
		{
			tlMenu = new tlControl();
			tlModule = new tlControl();

			//tlModule

			tlModule.Name = "tlModule";
			tlModule.Dock = DockStyle.Fill;
			tlModule.KeyFieldName = "MODULE_ID";
			tlModule.ParentFieldName = "MODULE_PARENT";

			tapgModule.Controls.Add(tlModule);

			tlModule.strZone = "MODULE";
			tlModule.BuildTreeList(false);

			//tlMenu
			tlMenu.Name = "tlMenu";
			tlMenu.Dock = DockStyle.Fill;
			tlMenu.KeyFieldName = "MENU_ID";
			tlMenu.ParentFieldName = "MENU_PARENT";

			tapgMenu.Controls.Add(tlMenu);

			tlMenu.strZone = "MENU";
			tlMenu.BuildTreeList(false);
		}

		void FillTree()
		{
			dtModule = SQLExec.ExecuteReturnDt("SELECT * FROM SYSMODULE ORDER BY Stt");
			dtMenu = SQLExec.ExecuteReturnDt("SELECT * FROM SYSMENU ORDER BY Stt");

			bdsModule = new BindingSource();
			bdsModule.DataSource = dtModule;

			bdsMenu = new BindingSource();
			bdsMenu.DataSource = dtMenu;

			tlModule.DataSource = bdsModule;
			tlModule.ExpandAll();

			tlMenu.DataSource = bdsMenu;

			tlModule.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlModule.strZone + "'");
			tlMenu.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlMenu.strZone + "'");
		}

		void Module_Edit(enuEdit enuNew_Edit)
		{
			if (bdsModule.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsModule.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsModule.Current).Row, ref drModule);
			else
				drModule = dtModule.NewRow();

			frmModule_Edit frmEdit = new frmModule_Edit();
			frmEdit.Load(enuNew_Edit, drModule);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsModule.Position >= 0)
						dtModule.ImportRow(drModule);
					else
						dtModule.Rows.Add(drModule);

					bdsModule.MoveLast();
				}
				else				
					Common.CopyDataRow(drModule, ((DataRowView)bdsModule.Current).Row);				

				dtModule.AcceptChanges();
			}
			else
				dtModule.RejectChanges();
		}

		void Menu_Edit(enuEdit enuNew_Edit)
		{

			if (bdsMenu.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsMenu.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsMenu.Current).Row, ref drMenu);
			else
				drMenu = dtMenu.NewRow();

			frmMenu_Edit frmEdit = new frmMenu_Edit();
			frmEdit.Load(enuNew_Edit, drMenu);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsMenu.Position >= 0)
						dtMenu.ImportRow(drMenu);
					else
						dtMenu.Rows.Add(drMenu);

					bdsMenu.MoveLast();
				}
				else				
					Common.CopyDataRow(drMenu, ((DataRowView)bdsMenu.Current).Row);					

				dtMenu.AcceptChanges();
			}
			else
				dtMenu.RejectChanges();
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (tactrlModMenu.SelectedTab == tapgModule)
				Module_Edit(enuNew_Edit);
			else if (tactrlModMenu.SelectedTab == tapgMenu)
				Menu_Edit(enuNew_Edit);
		}

		void Module_Delete()
		{
			if (bdsModule.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsModule.Current).Row;
			if (MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;
			if (DataTool.SQLCheckExist("SYSMODULE", "Module_Parent", drCurrent["Module_Id"]))
			{
				MessageBox.Show("Module : {" + drCurrent["Module_Name"].ToString() + "}  đang có module con");
				return;
			}

			if (DataTool.SQLCheckExist("SYSMODULEME", "Module_Id", drCurrent["Module_Id"]))
			{
				MessageBox.Show("Module : {" + drCurrent["Module_Name"].ToString() + "}  đang có menu");
				return;
			}

			if (DataTool.SQLDelete("SYSMODULE", drCurrent))
			{
				bdsModule.RemoveAt(bdsModule.Position);
				dtModule.AcceptChanges();
			}
		}

		void Menu_Delete()
		{
			if (bdsMenu.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsMenu.Current).Row;
			if (MessageBox.Show("Bạn có muốn xóa không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;
			if (DataTool.SQLCheckExist("SYSMENU", "Menu_Parent", drCurrent["Menu_Id"]))
			{
				MessageBox.Show("Menu : {" + drCurrent["Menu_Name"].ToString() + "}  đang có menu con");
				return;
			}

			if (DataTool.SQLCheckExist("SYSMODULEME", "Menu_ID", drCurrent["Menu_ID"]))
			{
				if (EpointMessage.MsgYes_No("Bạn có chắc chắn xóa mục này trong SYSMODULEME không?"))
					SQLExec.Execute("DELETE FROM SYSMODULEME WHERE Menu_ID = " + (int)drCurrent["Menu_ID"]).ToString();
				else
				{
					MessageBox.Show("Menu : {" + drCurrent["Menu_Name"].ToString() + "}  đang có MODULE MENU");
					return;
				}
			}

			if (DataTool.SQLDelete("SYSMENU", drCurrent))
			{
				bdsMenu.RemoveAt(bdsMenu.Position);
				dtMenu.AcceptChanges();
			}
		}

		public override void Delete()
		{
			if (tactrlModMenu.SelectedTab == tapgModule)
				Module_Delete();
			else if (tactrlModMenu.SelectedTab == tapgMenu)
				Menu_Delete();
		}

		#endregion

		#region Su kien

		private void frmMenuControl_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Delete();
					break;
			}
		}

		void tapgModule_Layout(object sender, LayoutEventArgs e)
		{
			this.tlModule.Focus();
		}

		void tapgMenu_Layout(object sender, LayoutEventArgs e)
		{
			this.tlMenu.Focus();
		}

		#endregion
	}
}