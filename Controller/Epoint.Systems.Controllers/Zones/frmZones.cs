using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmZones : Epoint.Systems.Customizes.frmView
	{		
		#region Khai bao bien

		private DataTable dtZone;
		private DataTable dtColumns;
		private DataRow drCurrent;
		
		private BindingSource bdsZone = new BindingSource();
		private BindingSource bdsColumns = new BindingSource();		

		#endregion

		#region Contructor

		public frmZones()
		{
			InitializeComponent();

			bdsZone.PositionChanged += new EventHandler(bdsZone_PositionChanged);
            this.dgvColumns.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvColumns_CellMouseDoubleClick);
		}

        
		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			Zones.FillZones();
		}

		#endregion

		#region Build, FillData
		private void Build()
		{			
			tlZone.KeyFieldName = "ZONE";
			tlZone.ParentFieldName = "ZONE_PARENT";
			tlZone.strZone = "ZONES";
			tlZone.BuildTreeList(false);

			//Columns
			dgvColumns.strZone = "COLUMNS";
			dgvColumns.BuildGridView();	
		}

		private void FillData()
		{
			dtZone = DataTool.SQLGetDataTable("SYSZONE", "*", null, "Zone");
			dtColumns = DataTool.SQLGetDataTable("SYSCOLUMN", "*", null, "Zone,Stt,Column_ID");

			bdsZone.DataSource = dtZone;
			bdsColumns.DataSource = dtColumns;
			
			tlZone.DataSource = bdsZone;
			bdsZone.Position = 0;
			dgvColumns.DataSource = bdsColumns;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsZone;

			tlZone.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlZone.strZone + "'");
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (dgvColumns.Focused)
			{
				Edit_Columns(enuNew_Edit);
				return;
			}

			if (bdsZone.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsZone.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsZone.Current).Row, ref drCurrent);
			else
				drCurrent = dtZone.NewRow();

			frmZones_Edit frmEdit = new frmZones_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsZone.Position >= 0)
						dtZone.ImportRow(drCurrent);
					else
						dtZone.Rows.Add(drCurrent);

					bdsZone.Position = bdsZone.Find("ZONE", drCurrent["ZONE"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsZone.Current).Row);

				dtZone.AcceptChanges();
			}
			else
				dtZone.RejectChanges();
		}

		public void Edit_Columns(enuEdit enuNew_Edit)
		{
			if (bdsColumns.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsColumns.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsColumns.Current).Row, ref drCurrent);
			else
				drCurrent = dtColumns.NewRow();

			string strZone = (string)((DataRowView)bdsZone.Current).Row["Zone"];
			drCurrent["Zone"] = strZone;

			if (enuNew_Edit == enuEdit.New)			
				drCurrent["Stt"] = Convert.ToInt32(Common.MaxDCValue(dtColumns.Select("Zone = '" + strZone + "'"), "Stt")) + 1;			

			frmColumn_Edit frmEdit = new frmColumn_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsColumns.Position >= 0)
						dtColumns.ImportRow(drCurrent);
					else
						dtColumns.Rows.Add(drCurrent);

					bdsColumns.Position = bdsColumns.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsColumns.Current).Row);

				dtColumns.AcceptChanges();
			}
			else
				dtColumns.RejectChanges();
		}

		public override void Delete()
		{
			if (dgvColumns.Focused)
			{
				Delete_Columns();
				return;
			}

			if (bdsZone.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsZone.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;				
			
			if (DataTool.SQLDelete("SYSZONE", drCurrent))
			{
				bdsZone.RemoveAt(bdsZone.Position);
				dtZone.AcceptChanges();
			}
		}

		public void Delete_Columns()
		{
			if (bdsColumns.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsColumns.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("SYSCOLUMN", drCurrent))
			{
				bdsColumns.RemoveAt(bdsColumns.Position);
				dtColumns.AcceptChanges();
			}
		}

		#endregion
		
		#region Su kien

		void bdsZone_PositionChanged(object sender, EventArgs e)
		{
			string strZone = (string)((DataRowView)bdsZone.Current).Row["Zone"];

			bdsColumns.Filter = "Zone = '" + strZone + "'";
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);

			Zones.FillZones();
			Columns.FillColumns();
		}
        void dgvColumns_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            DataRow drCurrent;
            DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.Inlist(strColumnName, "STT"))
            {
                drCurrent = ((DataRowView)bdsColumns.Current).Row;
                drCurrent["STT"] = Convert.ToInt32(drCurrent["STT"]) + 1;
                drCurrent.AcceptChanges();

                SQLExec.Execute("UPDATE SYSCOLUMN SET STT = " + Convert.ToInt32(drCurrent["STT"]) + " WHERE Ident00 = '" + drCurrent["Ident00"].ToString() + "'  AND Zone = '" + drCurrent["Zone"].ToString() + "'  ");
            }

        }		

		#endregion
	}
}
