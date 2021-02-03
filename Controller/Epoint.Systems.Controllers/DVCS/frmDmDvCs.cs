using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmDmDvCs : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

		private DataTable dtDmDvCs;
		private DataRow drCurrent;
		private BindingSource bdsDmDvCs = new BindingSource();
		private lvControl lvDmDvCs = new lvControl();
        
		#endregion 						

		#region Contructor

		public frmDmDvCs()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(KeyDownEvent);

			this.lvDmDvCs.Resize += new EventHandler(lvDmDvCs_Resize);
			this.lvDmDvCs.MouseDoubleClick += new MouseEventHandler(lvDmDvCs_MouseDoubleClick);
		}

		void lvDmDvCs_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SetDvCs();
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			if (this.lvDmDvCs.Items.ContainsKey(Element.sysMa_DvCs))
			{
				this.lvDmDvCs.Items[Element.sysMa_DvCs].Focused = true;
				this.lvDmDvCs.Items[Element.sysMa_DvCs].Selected = true;
			}

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			lvDmDvCs.Location = new Point(3, 3);
			lvDmDvCs.Size = new Size(this.Size.Width - 12, this.Size.Height - 12);
			lvDmDvCs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lvDmDvCs.FullRowSelect = true;
			lvDmDvCs.GridLines = true;
			lvDmDvCs.HideSelection = false;

			lvDmDvCs.strZone = "DMDVCS";
			lvDmDvCs.BuildListView(this.isLookup);

			this.Controls.Add(lvDmDvCs);
		}		

		private void FillData()
		{
			dtDmDvCs = SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMDVCS ORDER BY Ma_DvCs");

			bdsDmDvCs.DataSource = dtDmDvCs;
			lvDmDvCs.DataSource = bdsDmDvCs;
			bdsDmDvCs.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmDvCs;
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (!lvDmDvCs.MoveDataSourceToCurrentRow())
				return;

			if (bdsDmDvCs.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmDvCs.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmDvCs.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmDvCs.NewRow();

			frmDmDvCs_Edit frmEdit = new frmDmDvCs_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New && bdsDmDvCs.Position < 0)
				{
					if (bdsDmDvCs.Position >= 0)
						dtDmDvCs.ImportRow(drCurrent);
					else
						dtDmDvCs.Rows.Add(drCurrent);

					bdsDmDvCs.Position = bdsDmDvCs.Find("MA_DVCS", drCurrent["MA_DVCS"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmDvCs.Current).Row);

				dtDmDvCs.AcceptChanges();

				//Cap nhat vao ListView
				lvDmDvCs.UpdateRowToListViewItem(enuNew_Edit, drCurrent);
			}
			else
				dtDmDvCs.RejectChanges();
		}

		public override void Delete()
		{
			if (!lvDmDvCs.MoveDataSourceToCurrentRow())
				return;

			if (bdsDmDvCs.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmDvCs.Current).Row;
			
			if (!EpointMessage.MsgYes_No("Bạn có muốn xóa không"))
				return;
		
			if (DataTool.SQLDelete("SYSDMDVCS", drCurrent))
			{
				bdsDmDvCs.RemoveAt(bdsDmDvCs.Position);
				dtDmDvCs.AcceptChanges();

				lvDmDvCs.RemoveCurrentListViewItem();
			}
		}

		void SetDvCs()
		{
			if (bdsDmDvCs.Position < 0)
				return;

			if (!lvDmDvCs.MoveDataSourceToCurrentRow())
				return;

			drCurrent = ((DataRowView)bdsDmDvCs.Current).Row;

			if (DataTool.SQLCheckExist("sys.Objects", "Name", "sp_CheckPermissionDvCs"))
			{

				Hashtable htPara = new Hashtable();
				htPara.Add("MEMBER_ID", Element.sysUser_Id);
				htPara.Add("MA_DVCS", (string)drCurrent["Ma_DvCs"]);

				DataTable dtPermissionDvCs = SQLExec.ExecuteReturnDt("sp_CheckPermissionDvCs", htPara, CommandType.StoredProcedure);

				if (dtPermissionDvCs.Rows.Count >= 1 && !(bool)(dtPermissionDvCs.Rows[0]["Allow_Access"]))
				{
					EpointMessage.MsgCancel("Người dùng [" + Element.sysUser_Id + "] không được truy cập đơn vị [" + (string)drCurrent["Ten_DvCs"] + "]");
					return;
				}
			}

			Common.SetSysMa_DvCs(((string)drCurrent["Ma_DvCs"]).Trim());

			this.Close();
		}

		#endregion 

		#region EnterProcess

		public override void  EnterProcess()
		{
			SetDvCs();
		}

		#endregion 		

		#region Su kien

		void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Delete();
					break;
			}
		}

		void lvDmDvCs_Resize(object sender, EventArgs e)
		{
			this.lvDmDvCs.ResizeListView();
		}

		#endregion 
	}
}
