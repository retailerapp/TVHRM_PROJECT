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
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmDmTable : Epoint.Systems.Customizes.frmView
	{
		
		#region Khai bao bien

		private DataTable dtDmTable;
		private DataRow drCurrent;
		private BindingSource bdsDmTable = new BindingSource();
		private tlControl tlDmTable = new tlControl();

		#endregion

		#region Contructor

		public frmDmTable()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(KeyDownEvent);
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			tlDmTable.KeyFieldName = "TABLE_NAME";
			tlDmTable.ParentFieldName = "TABLE_TYPE";
			tlDmTable.Dock = DockStyle.Fill;

			tlDmTable.strZone = "DMTABLE";
			tlDmTable.BuildTreeList(false);

			this.Controls.Add(tlDmTable);
		}

		private void FillData()
		{
			dtDmTable = DataTool.SQLGetDataTable("SYSDMTABLE", "*", null, "Table_Name");

			bdsDmTable.DataSource = dtDmTable;
			tlDmTable.DataSource = bdsDmTable;

			bdsDmTable.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmTable;
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmTable.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmTable.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmTable.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmTable.NewRow();

			frmDmTable_Edit frmEdit = new frmDmTable_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmTable.Position >= 0)
						dtDmTable.ImportRow(drCurrent);
					else
						dtDmTable.Rows.Add(drCurrent);

					bdsDmTable.Position = bdsDmTable.Find("TABLE_NAME", drCurrent["TABLE_NAME"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmTable.Current).Row);

				dtDmTable.AcceptChanges();
			}
			else
				dtDmTable.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmTable.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmTable.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("Sure_Delete")))
				return;				
			
			if (DataTool.SQLDelete("SYSDMTABLE", drCurrent))
			{
				bdsDmTable.RemoveAt(bdsDmTable.Position);
				dtDmTable.AcceptChanges();
			}
		}

		#endregion
		
		#region Su kien

		private void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Delete();
					break;
			}
		}

		#endregion
	}
}
