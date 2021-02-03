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
	public partial class frmReport : Epoint.Systems.Customizes.frmView
	{
		
		#region Khai bao bien

		private DataTable dtReport;
		private DataTable dtReportFilter;
		private DataTable dtReportDetail;
		private DataTable dtReportInfo;

		private DataRow drCurrent;
		private BindingSource bdsReport = new BindingSource();
		private BindingSource bdsReportFilter = new BindingSource();
		private BindingSource bdsReportDetail = new BindingSource();
		private BindingSource bdsReportInfo = new BindingSource();
		//private tlControl tlReport0 = new tlControl();

		#endregion

		#region Contructor

		public frmReport()
		{
			InitializeComponent();

			bdsReport.PositionChanged += new EventHandler(bdsReport_PositionChanged);
            this.dgvReportFilter.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvReportFilter_CellMouseDoubleClick);
            this.dgvReportInfo.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvReportInfo_CellMouseDoubleClick);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			//Report
			tlReport.KeyFieldName = "REPORT_ID";
			tlReport.ParentFieldName = "REPORT_PARENT";

			tlReport.strZone = "REPORT";
			tlReport.BuildTreeList(false);

			//ReportFilter
			dgvReportFilter.strZone = "REPORTFILTER";
			dgvReportFilter.BuildGridView();

			//ReportInfo
			dgvReportInfo.strZone = "REPORTINFO";
			dgvReportInfo.BuildGridView();

			//ReportDetail
			dgvReportDetail.strZone = "REPORTDETAIL";
			dgvReportDetail.BuildGridView();
		}

		private void FillData()
		{
			//Report
			dtReport = DataTool.SQLGetDataTable("SYSREPORT", "*", null, "Stt");
			dtReportFilter = DataTool.SQLGetDataTable("SYSREPORTFILTER", "*", null, "Report_ID,Col,Row,Filter_ID");
			dtReportInfo = DataTool.SQLGetDataTable("SYSREPORTINFO", "*", null, "Report_ID,Stt,Column_ID");
			dtReportDetail = DataTool.SQLGetDataTable("SYSREPORTDETAIL", "*", null, "");

			bdsReport.DataSource = dtReport;
			tlReport.DataSource = bdsReport;
			bdsReport.Position = 0;

			//ReportFilter
			bdsReportFilter.DataSource = dtReportFilter;
			dgvReportFilter.DataSource = bdsReportFilter;

			//ReportInfo
			bdsReportInfo.DataSource = dtReportInfo;
			dgvReportInfo.DataSource = bdsReportInfo;

			//ReportDetail
			bdsReportDetail.DataSource = dtReportDetail;
			dgvReportDetail.DataSource = bdsReportDetail;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsReport;
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (dgvReportFilter.Focused)
			{
				Edit_ReportFilter(enuNew_Edit);
				return;
			}

			if (dgvReportInfo.Focused)
			{
				Edit_ReportInfo(enuNew_Edit);
				return;
			}

			if (dgvReportDetail.Focused)
			{
				Edit_ReportDetail(enuNew_Edit);
				return;
			}

			if (bdsReport.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsReport.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsReport.Current).Row, ref drCurrent);
			else
				drCurrent = dtReport.NewRow();

			frmReport_Edit frmEdit = new frmReport_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{		

				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsReport.Position >= 0)
						dtReport.ImportRow(drCurrent);
					else
						dtReport.Rows.Add(drCurrent);

					bdsReport.Position = bdsReport.Find("REPORT_ID", drCurrent["REPORT_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsReport.Current).Row);

				dtReport.AcceptChanges();
			}
			else
				dtReport.RejectChanges();
		}

		public void Edit_ReportFilter(enuEdit enuNew_Edit)
		{
			if (bdsReportFilter.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsReportFilter.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsReportFilter.Current).Row, ref drCurrent);
			else
				drCurrent = dtReportFilter.NewRow();

			drCurrent["Report_ID"] = (string)((DataRowView)bdsReport.Current).Row["Report_ID"];

			frmReportFilter_Edit frmEdit = new frmReportFilter_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsReportFilter.Position >= 0)
						dtReportFilter.ImportRow(drCurrent);
					else
						dtReportFilter.Rows.Add(drCurrent);

					bdsReportFilter.Position = bdsReportFilter.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsReportFilter.Current).Row);

				dtReportFilter.AcceptChanges();
			}
			else
				dtReportFilter.RejectChanges();
		}

		public void Edit_ReportInfo(enuEdit enuNew_Edit)
		{
			if (bdsReportInfo.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsReportInfo.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsReportInfo.Current).Row, ref drCurrent);
			else
				drCurrent = dtReportInfo.NewRow();

			string strReport_ID = (string)((DataRowView)bdsReport.Current).Row["Report_ID"];
			drCurrent["Report_ID"] = strReport_ID;

			if (enuNew_Edit == enuEdit.New)
				drCurrent["Stt"] = Convert.ToInt32(Common.MaxDCValue(dtReportInfo.Select("Report_ID = '" + strReport_ID + "'"), "Stt")) + 1;			

			frmReportInfo_Edit frmEdit = new frmReportInfo_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsReportInfo.Position >= 0)
						dtReportInfo.ImportRow(drCurrent);
					else
						dtReportInfo.Rows.Add(drCurrent);

					bdsReportInfo.Position = bdsReportInfo.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsReportInfo.Current).Row);

				dtReportInfo.AcceptChanges();
			}
			else
				dtReportInfo.RejectChanges();
		}

		public void Edit_ReportDetail(enuEdit enuNew_Edit)
		{
			if (bdsReportDetail.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsReportDetail.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsReportDetail.Current).Row, ref drCurrent);
			else
				drCurrent = dtReportDetail.NewRow();

			drCurrent["Report_ID"] = (string)((DataRowView)bdsReport.Current).Row["Report_ID"];			

			frmReportDetail_Edit frmEdit = new frmReportDetail_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsReportDetail.Position >= 0)
						dtReportDetail.ImportRow(drCurrent);
					else
						dtReportDetail.Rows.Add(drCurrent);

					bdsReportDetail.Position = bdsReportDetail.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsReportDetail.Current).Row);

				dtReportDetail.AcceptChanges();
			}
			else
				dtReportDetail.RejectChanges();
		}

		public override void Delete()
		{
			if (dgvReportFilter.Focused)
			{
				Delete_ReportFilter();
				return;
			}

			if (dgvReportInfo.Focused)
			{
				Delete_ReportInfo();
				return;
			}

			if (dgvReportDetail.Focused)
			{
				Delete_ReportDetail();
				return;
			}

			if (bdsReport.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsReport.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strExec =
				"DELETE FROM SYSReportFilter WHERE Report_ID = '" + (string)drCurrent["Report_ID"] + "' " + "\n" +
				"DELETE FROM SYSReportInfo WHERE Report_ID = '" + (string)drCurrent["Report_ID"] + "' " + "\n" +
				"DELETE FROM SYSReportDetail WHERE Report_ID = '" + (string)drCurrent["Report_ID"] + "' " + "\n" +
				"DELETE FROM SYSMENURP WHERE Report_ID = '" + (string)drCurrent["Report_ID"] + "' ";

			if (SQLExec.Execute(strExec)) //Xóa con rồi mới xóa cha
			{
				if (DataTool.SQLDelete("SYSREPORT", drCurrent))
				{

					bdsReport.RemoveAt(bdsReport.Position);
					dtReport.AcceptChanges();
				}
			}
		}

		public void Delete_ReportFilter()
		{
			if (bdsReportFilter.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsReportFilter.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("SYSREPORTFILTER", drCurrent))
			{
				bdsReportFilter.RemoveAt(bdsReportFilter.Position);
				dtReportFilter.AcceptChanges();
			}
		}

		public void Delete_ReportInfo()
		{
			if (bdsReportInfo.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsReportInfo.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("SYSREPORTINFO", drCurrent))
			{
				bdsReportInfo.RemoveAt(bdsReportInfo.Position);
				dtReportInfo.AcceptChanges();
			}
		}

		public void Delete_ReportDetail()
		{
			if (bdsReportDetail.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsReportDetail.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("SYSREPORTDETAIL", drCurrent))
			{
				bdsReportDetail.RemoveAt(bdsReportDetail.Position);
				dtReportDetail.AcceptChanges();
			}
		}

		void bdsReport_PositionChanged(object sender, EventArgs e)
		{
			string strReport_ID = (string)((DataRowView)bdsReport.Current).Row["Report_ID"];

			bdsReportFilter.Filter = "Report_ID = '" + strReport_ID + "'";
			bdsReportInfo.Filter = "Report_ID = '" + strReport_ID + "'";
			bdsReportDetail.Filter = "Report_ID = '" + strReport_ID + "'"; 
		}
        void dgvReportFilter_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            DataRow drCurrent;
            DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;

            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.Inlist(strColumnName, "ROW"))
            {
                drCurrent = ((DataRowView)bdsReportFilter.Current).Row;
                drCurrent["ROW"] = Convert.ToInt32(drCurrent["ROW"]) + 1;
                drCurrent.AcceptChanges();

                SQLExec.Execute("UPDATE SYSREPORTFILTER SET ROW = " + Convert.ToInt32(drCurrent["ROW"]) + " WHERE Ident00 = '" + drCurrent["Ident00"].ToString() + "' AND Report_Id = '" + drCurrent["Report_Id"].ToString() + "' ");
            }
        }
        void dgvReportInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            DataRow drCurrent;
            DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.Inlist(strColumnName, "STT"))
            {
                drCurrent = ((DataRowView)bdsReportInfo.Current).Row;
                drCurrent["STT"] = Convert.ToInt32(drCurrent["STT"]) + 1;
                drCurrent.AcceptChanges();

                SQLExec.Execute("UPDATE SYSREPORTINFO SET STT = " + Convert.ToInt32(drCurrent["STT"]) + " WHERE Ident00 = '" + drCurrent["Ident00"].ToString() + "'  AND Report_Id = '" + drCurrent["Report_Id"].ToString() + "'  ");
            }
        }
		#endregion
	}
}
