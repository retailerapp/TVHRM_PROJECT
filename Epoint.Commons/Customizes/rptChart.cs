using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Windows.Forms;
using Epoint.Systems.Controls;

namespace Epoint.Systems.Customizes
{
	/// <summary>
	/// Summary description for rptFileReport.
	/// </summary>
	public partial class rptChart : DataDynamics.ActiveReports.ActiveReport3
	{
		DataTable dtChartSource;
		dgvControl dgvChartSource;

		DataRow drReport;
		DataRow drFilter;

		public DataDynamics.ActiveReports.Chart.ChartType ChartType;

		public rptChart()
		{
			InitializeComponent();
		}

		public void Load(DataRow drReport, DataRow drFilter, DataTable dtChartSource, dgvControl dgvChartSource)
		{
			this.drReport = drReport;
			this.drFilter = drFilter;
			this.dtChartSource = dtChartSource;
			this.dgvChartSource = dgvChartSource;

			if (this.BuildChart())
			{
				this.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
				this.Run();
			}
		}

		private bool BuildChart()
		{
			string strSeriesList = ((string)drReport["SeriesList"]).Replace(" ", "");
			string strColX = (string)drReport["ColX"];						

			if (!dtChartSource.Columns.Contains(strColX) || !(dtChartSource.Columns[strColX].DataType == typeof(string)))
				return false;
			
			string[] strArrSeriesList = strSeriesList.Split(',');
			Dictionary<string, string> dicSerial = new Dictionary<string, string>();
			DataTable dtChart = new DataTable();

			//Tạo cấu trúc cho htSerial và dtChart
			foreach (string strSeries in strArrSeriesList)
			{
				if (dgvChartSource.Columns.Contains(strSeries) && (dtChartSource.Columns[strSeries].DataType == typeof(System.Decimal) || dtChartSource.Columns[strSeries].DataType == typeof(double)))
				{
					dicSerial.Add(strSeries, dgvChartSource.Columns[strSeries].HeaderText);
				}
			}

			dtChart.Columns.Add("ColX", typeof(string));

			foreach (string strColY in dicSerial.Keys)
				dtChart.Columns.Add(strColY, typeof(double));

			//Bắt đầu tạo dữ liệu cho dtChart, nhóm theo cột ColX 
			foreach (DataRow drData in dtChartSource.Rows)
			{
				//if ((string)drData[strColX] == string.Empty || Convert.ToDouble(drData[strColY]) == 0)

				if ((string)drData[strColX] == string.Empty)
					continue;

				string strKey = "ColX = '" + drData[strColX].ToString() + "'";

				DataRow[] drArrCheck = dtChart.Select(strKey);
				if (drArrCheck.Length > 0)
				{
					DataRow drCheck = drArrCheck[0];

					foreach (string strColY in dicSerial.Keys)
						drCheck[strColY] = Convert.ToDouble(drCheck[strColY]) + Convert.ToDouble(drData[strColY]);
				}
				else
				{
					DataRow drNew = dtChart.NewRow();

					drNew["ColX"] = drData[strColX];
					foreach (string strColY in dicSerial.Keys)
						drNew[strColY] = drData[strColY];

					dtChart.Rows.Add(drNew);
				}
			}
			this.chartControl1.Series.Clear();
			foreach (string strColY in dicSerial.Keys)
			{

				DataDynamics.ActiveReports.Chart.Series series = new DataDynamics.ActiveReports.Chart.Series();
				this.chartControl1.Series.Add(series);
				series.LegendText = dgvChartSource.Columns[strColY].HeaderText;
				series.ValueMemberX = "ColX";
				series.ValueMembersY = strColY;
				series.Type = DataDynamics.ActiveReports.Chart.ChartType.Bar3D;

				DataDynamics.ActiveReports.Chart.Axis axisX = new DataDynamics.ActiveReports.Chart.Axis();
				axisX.Title = dgvChartSource.Columns[strColX].HeaderText;
				axisX.LabelsVisible = true;

				DataDynamics.ActiveReports.Chart.Axis axisY = new DataDynamics.ActiveReports.Chart.Axis();
				axisY.Title = dgvChartSource.Columns[strColY].HeaderText;
				axisY.LabelsVisible = true;

				//Khai báo thông tin cho trục tung, trục hoành (AxisX, AxisY)
				series.ChartArea.Axes["AxisX"].Title = dgvChartSource.Columns[strColX].HeaderText;
				series.ChartArea.Axes["AxisX"].Visible = true;
				series.ChartArea.Axes["AxisX"].LabelsVisible = true;
				series.ChartArea.Axes["AxisX"].DisplayScale = true;
				series.ChartArea.Axes["AxisX"].MajorTick.Visible = true;
				series.ChartArea.Axes["AxisX"].Scale = 1;
				series.ChartArea.Axes["AxisX"].SmartLabels = true;
				series.ChartArea.Axes["AxisX"].StaggerLabels = false;

				series.ChartArea.Axes["AxisY"].Title = dgvChartSource.Columns[strColY].HeaderText;
				series.ChartArea.Axes["AxisY"].Visible = true;
				series.ChartArea.Axes["AxisY"].LabelsVisible = true;
				series.ChartArea.Axes["AxisY"].DisplayScale = true;
				series.ChartArea.Axes["AxisY"].MajorTick.Visible = true;
				series.ChartArea.Axes["AxisY"].Scale = 1;
				series.ChartArea.Axes["AxisY"].SmartLabels = true;
				series.ChartArea.Axes["AxisY"].LabelFormat = "{0:#}";
				series.ChartArea.Axes["AxisY"].StaggerLabels = false;
			}

			this.chartControl1.DataSource = dtChart;

			this.chartControl1.Legends[0].Header.Text = "Chú thích";

			this.lblTen_Dv_Cq.Text = (string)Epoint.Systems.Librarys.Parameters.GetParaValue("TEN_DV_CQ");
			this.lblTen_Dv.Text = Epoint.Systems.Elements.Element.sysTen_Dvi.ToUpper();
            this.lblDia_Chi_Dv.Text = Epoint.Systems.Elements.Element.sysDia_Chi_Dv;

			//this.lblTitle.Text = Report.GetTitle(drFilter).ToUpper();
			//this.lblSubTitle1.Text = Report.GetSubTitle1(drReport, drFilter);
			//this.lblSubTitle2.Text = Report.GetSubTitle2(drReport, drFilter);

			return true;
		}

		public void Refresh()
		{
			foreach (DataDynamics.ActiveReports.Chart.Series series in chartControl1.Series)
				series.Type = ChartType;

			this.Run();
		}
	}
}
