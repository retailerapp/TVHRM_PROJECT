using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Elements;

namespace Epoint.Systems.Customizes
{
	public partial class UcTreeMain : UserControl
	{
		BindingSource bdsTreeMain = new BindingSource();
		DataTable dtTreeMain;

		public UcTreeMain()
		{
			InitializeComponent();
            this.tvMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tvMain.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(NodeMouseDoubleClickEvent);
            
			this.tvMain.KeyDown += new KeyEventHandler(KeyDownEvent);
			this.tvMain.AfterExpand += new TreeViewEventHandler(tvMain_AfterExpand);
			this.tvMain.AfterCollapse += new TreeViewEventHandler(tvMain_AfterCollapse);

			this.tvMain.BackColor = System.Drawing.Color.FromArgb(255, 216, 228, 248);

		}

		public void LoadControl()
		{
            dtTreeMain = DataTool.SQLGetDataTable("SYSModule", "*", "Show_On_Main = 1", "Stt");
            bdsTreeMain.DataSource = dtTreeMain;

            //string strQuery = "SELECT * FROM vw_Module_Menu ";

            //dtTreeMain = SQLExec.ExecuteReturnDt(strQuery);
            //bdsTreeMain.DataSource = dtTreeMain;
            //Kiểm tra Permission
            foreach (DataRow dr in dtTreeMain.Rows)
            {
                //Kiểm tra phân hệ có hợp lệ hay không
                if ((bool)dr["Is_Module"])
                    if (!Core.Is_Module_Valid((int)dr["Module_ID"]))
                    {
                        dr.Delete();
                        continue;
                    }

                if (!Common.CheckPermission((string)dr["Object_ID"], enuPermission_Type.Allow_Access))
                    dr.Delete();
            }

			this.tvMain.KeyFieldName = "Module_ID";
			this.tvMain.ParentFieldName = "Module_Parent";
			this.tvMain.DisplayFieldName = "Module_Name";
			this.tvMain.ImageFileName = "Picture";

			this.tvMain.VietNameseFieldName = "Module_Name";
			this.tvMain.EngLishFieldName= "Module_NameE";
			this.tvMain.OtherFieldName = "Module_NameO";

			this.tvMain.DataSource = bdsTreeMain;
		}

		public void LoadControl(int iModule_ID)
		{
			if (iModule_ID <= 0)
			{
				this.LoadControl();
				return;
			}

			string strQuery = "SELECT * FROM SYSMENU " +
									" WHERE (Show_On_Main = 1) AND " +
                                    " Menu_ID IN(SELECT Menu_ID FROM SYSMODULEME WHERE Module_ID = " + iModule_ID + ") " +
									" ORDER BY Stt ";

			dtTreeMain = SQLExec.ExecuteReturnDt(strQuery);
			bdsTreeMain.DataSource = dtTreeMain;

			//Kiểm tra Permission
			foreach (DataRow dr in dtTreeMain.Rows)
			{
				if (!Common.CheckPermission((string)dr["Object_ID"], enuPermission_Type.Allow_Access))
					dr.Delete();
			}

			this.tvMain.KeyFieldName = "Menu_ID";
			this.tvMain.ParentFieldName = "Menu_Parent";
			this.tvMain.DisplayFieldName = "Menu_Name";
			this.tvMain.ImageFileName = "Picture";

			this.tvMain.VietNameseFieldName = "Menu_Name";
			this.tvMain.EngLishFieldName = "Menu_NameE";
			this.tvMain.OtherFieldName = "Menu_NameO";

			this.tvMain.DataSource = bdsTreeMain;
		}

		public void RunMethod()
		{
			if (this.tvMain.SelectedNode == null)
				return;

			int iID = Convert.ToInt32(this.tvMain.SelectedNode.Name);

			frmMain frmM = (frmMain)this.FindForm();

			tsmiControl tsmi = Common.FindTsmi(frmM.msMain, iID);

			if (tsmi != null)
				Common.RunMethod(tsmi);
            //Common.RunMethod(tsmi);
		}

		public void SetProperlyHeight()
		{
			int iHeight = (tvMain.VisibleNodeCount * tvMain.ItemHeight) + 50;

			this.Height = iHeight;

			//this.tvMain.Height = iHeight;
			//this.tvMain.Width = this.Width;

			//if (iHeight > this.MaximumSize.Height)
			//{
			//    this.AutoScroll = false;
			//    this.VScroll = true;
			//    this.VerticalScroll.Enabled = true;
			//    this.VerticalScroll.Visible = true;
			//}
			//else
			//{
			//    this.AutoScroll = false;
			//    this.VerticalScroll.Visible = false;
			//}
		}

		void NodeMouseDoubleClickEvent(object sender, TreeNodeMouseClickEventArgs e)
		{
			RunMethod();
		}

		void KeyDownEvent(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				RunMethod();

				e.Handled = true;
			}
		}

		void tvMain_AfterExpand(object sender, TreeViewEventArgs e)
		{
			this.SetProperlyHeight();
		}

		void tvMain_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			this.SetProperlyHeight();
		}

		protected override void OnEnter(EventArgs e)
		{
			//base.OnEnter(e);
			this.tvMain.Focus();
		}
		protected override void OnGotFocus(EventArgs e)
		{
			//base.OnGotFocus(e);
			this.tvMain.Focus();
		}
	}
}
