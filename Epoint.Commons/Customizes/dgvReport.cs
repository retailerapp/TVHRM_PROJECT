using System;
using System.Globalization;
using System.Drawing;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Systems.Customizes
{
	public class dgvReport : Epoint.Systems.Controls.dgvControl
	{
		public DataRow drReport;
		public bool bVnd_Nt = true;
		public string strVnd_Nt = string.Empty;

		public dgvReport()
		{
			this.ReadOnly = false;
            //this.MultiSelect = true;
		}

		public void BuildGridViewReport()
		{
			if (strZone == string.Empty)
				return;

			string strColumnVndList = string.Empty;
			string strColumnNtList = string.Empty;
			string strColumnAllList = string.Empty;

			string strReport_ID = strZone;
			string strReport_ID_Info = (string)SQLExec.ExecuteReturnValue("SELECT Report_ID_Info FROM SYSReport WHERE Report_ID = '" + strReport_ID + "'");

			System.Collections.Hashtable htParameter = new System.Collections.Hashtable();
			htParameter.Add("REPORT_ID", strReport_ID);
			htParameter.Add("REPORT_ID_INFO", strReport_ID_Info);

			DataTable dtReportInfo = SQLExec.ExecuteReturnDt("sp_GetReportInfo", htParameter, CommandType.StoredProcedure);
			//DataTable dtReportInfo = DataTool.SQLGetDataTable("SYSREPORTINFO", "*", "(Report_ID = '" + strZone + "') AND (Visible = 1)", "Stt");

			foreach (DataRow dr in dtReportInfo.Rows)
			{
				string strColumn_ID = (string)dr["Column_ID"];

				if (strColumn_ID == string.Empty)
					continue;

				switch ((string)dr["Vnd_Nt"])
				{
					case "1": //Hien Vnd
						strColumnVndList += strColumnVndList != string.Empty ? ", " : "";
						strColumnVndList += strColumn_ID;
						break;
					case "2": //Hien Nt
						strColumnNtList += strColumnNtList != string.Empty ? ", " : "";
						strColumnNtList += strColumn_ID;
						break;
					default: //Hien tat ca
						strColumnVndList += strColumnVndList != string.Empty ? ", " : "";
						strColumnNtList += strColumnNtList != string.Empty ? ", " : "";
						strColumnVndList += strColumn_ID;
						strColumnNtList += strColumn_ID;
						break;
				}

				strColumnAllList += strColumnAllList != string.Empty ? ", " : "";
				strColumnAllList += strColumn_ID;
			}

			if (strVnd_Nt == string.Empty)
			{
				if (bVnd_Nt)
					base.BuildGridView(strColumnVndList);
				else
					base.BuildGridView(strColumnNtList);
			}
			else
			{
				if (strVnd_Nt == "0")
					base.BuildGridView(strColumnVndList);
				else if (strVnd_Nt == "1")
					base.BuildGridView(strColumnNtList);
				else
					base.BuildGridView(strColumnAllList);
			}

			this.AllowUserToOrderColumns = true;
		}

		public override string strZone
		{
			get
			{
				return base.strZone;
			}
			set
			{
				base.strZone = value;

				if (!Element.Is_Running)
					return;

				DataRow drReport = DataTool.SQLGetDataRowByID("SYSREPORT", "Report_Id", value);
				if (drReport != null)
					this.iResize_Rate = (int)drReport["Resize_Rate"];
				else
					this.iResize_Rate = 100;

				this.bSortMode = true;
				this.AllowUserToOrderColumns = true;

				this.ColumnInfos.Clear();

				string strReport_ID = (string)drReport["Report_ID"];
				string strReport_ID_Info = (string)drReport["Report_ID_Info"];

				System.Collections.Hashtable htParameter = new System.Collections.Hashtable();
				htParameter.Add("REPORT_ID", strReport_ID);
				htParameter.Add("REPORT_ID_INFO", strReport_ID_Info);

				DataTable dtReportInfo = SQLExec.ExecuteReturnDt("sp_GetReportInfo", htParameter, CommandType.StoredProcedure);
				//DataTable dtReportInfo = DataTool.SQLGetDataTable("SYSREPORTINFO", "", "Report_ID = '" + strZone + "'", "Report_ID, Stt");

				foreach (DataRow dr in dtReportInfo.Rows)
				{
					string strColumn_ID = (string)dr["Column_ID"];
					string strKey = strZone + "." + strColumn_ID;

                    //string strDescription = (string)dr["Description"];

                    string strDescription = string.Empty;
                    if (Element.sysLanguage == enuLanguageType.Vietnamese)
                        strDescription = (string)dr["Description"];
                    if (Element.sysLanguage == enuLanguageType.English)
                        strDescription = (string)dr["Description_E"];
                    if (Element.sysLanguage == enuLanguageType.Other)
                        strDescription = (string)dr["Description_O"];
                    
                    int iWidth = Convert.ToInt32(dr["Width"]);
					enuColumnType enuType = (enuColumnType)Convert.ToChar(dr["Type"]);
					int iScale = Convert.ToInt16(dr["Scale"]);
					bool bResizable = Convert.ToBoolean(dr["Resizable"]);
                    Color ColumnForeColor = (string)dr["COLOR"].ToString().Trim() == "" ? Color.Black : Color.FromName((string)dr["COLOR"].ToString().Trim());

                    ColumnInfo ColumnInfo = new ColumnInfo(strColumn_ID, strDescription, iWidth, enuType, iScale, bResizable, "3", ColumnForeColor);

					this.ColumnInfos.Add(strKey, ColumnInfo);
				}
			}
		}
	}
}
