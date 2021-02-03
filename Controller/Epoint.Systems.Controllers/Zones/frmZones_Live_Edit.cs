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
	public partial class frmZones_Live_Edit : Epoint.Systems.Customizes.frmView
	{		
		#region Khai bao bien
		
		private DataTable dtColumns;
		private DataTable dtReportInfo;

		private BindingSource bdsColumns = new BindingSource();

		public bool bReport = false;
		public string strZone = "";
		public DataTable dtCurrent;
		public DataRow drCurrent;
		#endregion

		#region Contructor

		public frmZones_Live_Edit()
		{
			InitializeComponent();

			this.dgvColumns.CellEndEdit += new DataGridViewCellEventHandler(dgvColumns_CellEndEdit);
			this.KeyDown += new KeyEventHandler(frmZones_Live_Edit_KeyDown);
		}

		
		public void New()
		{
			if (bdsColumns.Count > 0)
				Common.CopyDataRow(((DataRowView)bdsColumns.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtColumns.NewRow();
				drCurrent["Zone"] = strZone;
			}
			
			if (bdsColumns.Count > 0)
				dtColumns.ImportRow(drCurrent);
			else
				dtColumns.Rows.Add(drCurrent);
			dtColumns.AcceptChanges();
			bdsColumns.MoveLast();
			
		}
		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			this.ShowDialog();
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
			dgvColumns.strZone = (bReport) ? "REPORTINFO" : "COLUMNS";
			dgvColumns.BuildGridView();

			dgvColumns.ReadOnly = false;
			foreach (DataGridViewColumn dgvc in dgvColumns.Columns)
			{
				switch (dgvc.Name)
				{
					case"ZONE":
					case "REPORT_ID":
					case "COLUMN_ID":
						dgvc.ReadOnly = true;
						break;
					default:
						dgvc.ReadOnly = false;
						break;
				}
			}
		}

		private void FillData()
		{
			
			dtColumns = (bReport) ? DataTool.SQLGetDataTable("SYSREPORTINFO", "*", "Report_Id='"+strZone+"'", "Report_ID,Stt,Column_ID")
								: DataTool.SQLGetDataTable("SYSCOLUMN", "*", "Zone ='" + strZone + "' ", "Zone,Stt,Column_ID");
			
			int iStt_Max = (dtColumns.Rows.Count>0)? int.Parse( dtColumns.Rows[dtColumns.Rows.Count - 1]["STT"].ToString()):0;
			if (dtCurrent != null)
			{
				foreach (DataColumn dc in dtCurrent.Columns)
				{
                    string strType = "T";
                    switch (dc.DataType.ToString())
                    {
                        case "System.Decimal":
                        case "System.Int32":
                        case "System.Int16":
                            strType = "N";
                            break;
                        case "System.DateTime":
                            strType = "D";
                            break;
                        case "System.Boolean":
                            strType = "K";
                            break;
                    }
					if (!CheckExistValueInTable(dtColumns,"Column_ID",dc.ColumnName))
					{
						DataRow drNew = dtColumns.NewRow();
						drNew["Column_ID"] = dc.ColumnName;
						if (bReport)
							drNew["Report_Id"] = strZone;
						else
							drNew["Zone"] = strZone;
						drNew["Width"] = 100;						
						drNew["Type"] = strType;
						drNew["Description"] = SQLExec.ExecuteReturnValue("SELECT Vietnamese FROM SYSLANGUAGE WHERE Language_Id='"+dc.ColumnName+"'");
						drNew["Scale"] = 0;						
						drNew["Resizable"] = 0;
						drNew["STT"] = iStt_Max+1;
						if(bReport)
							drNew["Vnd_Nt"] = 3;
						else
							drNew["Show_Type"] = 3;
						drNew["Visible"] = 0;
						drNew["Is_Customize"] = 0;
						dtColumns.Rows.Add(drNew);
						iStt_Max = iStt_Max + 1;
					}
				}
			}
			bdsColumns.DataSource = dtColumns;
			
			dgvColumns.DataSource = bdsColumns;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsColumns;

			//if (bLoadLive && !string.IsNullOrEmpty(strZone))
			//{	
			
			//    //this.tlZone.Visible = false;
			//    this.dgvColumns.Dock = DockStyle.Fill;
			//    bdsSearch = bdsColumns;
			//    this.dgvColumns.Select();
			//}
		}
		
		#endregion

		#region Update

		bool CheckExistValueInTable(DataTable dtCheck, string strColumn, string strValue)
		{
			bool bKq = false;
			foreach (DataRow dr in dtCheck.Rows)
			{
				if (dr[strColumn].ToString() == strValue)
				{
					bKq = true;
					break;
				}
			}
			return bKq;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsColumns.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsColumns.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsColumns.Current).Row, ref drCurrent);
			else
				drCurrent = dtColumns.NewRow();			

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
			

			

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;				
			
			
		}

		public void Delete_Columns()
		{
			if (bdsColumns.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsColumns.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
			string strTable = (bReport) ? "SYSREPORTINFO" : "SYSCOLUMN";
			if (DataTool.SQLDelete(strTable, drCurrent))
			{
				bdsColumns.RemoveAt(bdsColumns.Position);
				dtColumns.AcceptChanges();
			}
		}

		#endregion
		
		#region Su kien

		void dgvColumns_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
				return;
			DataGridViewRow dgvRow = this.dgvColumns.CurrentRow;
			DataGridViewCell dgvCell = this.dgvColumns.CurrentCell;
			DataRow drCurrent = ((DataRowView)bdsColumns.Current).Row;
			bool bVisible = (bool)dgvRow.Cells["Visible"].Value;
			if (bReport)
			{
				if (!DataTool.SQLCheckExist("SYSREPORTINFO", new string[] { "Report_Id", "Column_ID" }, new object[] { strZone, dgvRow.Cells["Column_ID"].Value }))
					DataTool.SQLUpdate(enuEdit.New, "SYSREPORTINFO", ref drCurrent);
				else
					DataTool.SQLUpdate(enuEdit.Edit, "SYSREPORTINFO", ref drCurrent);
				dtColumns.AcceptChanges();
			}
			else
			{
				if (!DataTool.SQLCheckExist("SYSCOLUMN", new string[] { "Zone", "Column_ID" }, new object[] { strZone, dgvRow.Cells["Column_ID"].Value }))
					DataTool.SQLUpdate(enuEdit.New, "SYSCOLUMN", ref drCurrent);
				else
					DataTool.SQLUpdate(enuEdit.Edit, "SYSCOLUMN", ref drCurrent);

				dtColumns.AcceptChanges();
			}
		}		

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);

			Zones.FillZones();
			Columns.FillColumns();
		}
		void frmZones_Live_Edit_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.N:
					if (e.Control) //Bấm Ctrl+N để thêm mới
					{
						if (!bReport)
						{
							this.New();
							this.dgvColumns.Columns["COLUMN_ID"].ReadOnly = false;
						}
					}
					break;

			}
		}
		#endregion

		
	}
}
