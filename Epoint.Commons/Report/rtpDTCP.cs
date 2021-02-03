using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Chart;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Chart.Graphics;
using Epoint.Systems.Data;
using System.Drawing.Printing;

namespace Epoint.Systems.Customizes
{
    public partial class rtpDTCP : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataTable dtDoanhThu;
        private string strColumnName;
        private string strColumnNumDt;
        private string strColumnNumCp;
        public float fHeight = 0f;
        public float fWidth = 0f;
        public string strChart_Type = "1";
        public rtpDTCP()
        {
            InitializeComponent();
        }
        public void Load(DataTable dtDoanhThu)
        {
            this.fHeight = 600f;
            this.fWidth = 800f;

            this.strChart_Type = "1";

            this.dtDoanhThu = dtDoanhThu;
            this.strColumnName = "THANG";
            this.strColumnNumDt = "Tien_Dt";
            this.strColumnNumCp = "Tien_Cp";
            this.SetPrintSize();
            this.LoadChart();
        }

        private void LoadChart()
        {
            Series series1 = this.ChartControl1.Series[0];
            Series series2 = this.ChartControl1.Series[1];
            //series1.Type = DataDynamics.ActiveReports.Chart.ChartType.StackedBar3D;


            //series1.Type = DataDynamics.ActiveReports.Chart.ChartType.StackedBar3D;

            //series1.Type = DataDynamics.ActiveReports.Chart.ChartType.StackedBar3D;
            //series1.Properties = new DataDynamics.ActiveReports.Chart.CustomProperties(new DataDynamics.ActiveReports.Chart.KeyValuePair[] {
            //                            new DataDynamics.ActiveReports.Chart.KeyValuePair("BarType", DataDynamics.ActiveReports.Chart.BarType.Bar),
            //                            new DataDynamics.ActiveReports.Chart.KeyValuePair("HoleSize", 0.3F),
            //                            new DataDynamics.ActiveReports.Chart.KeyValuePair("Radius", 1F)});


            object obj2 = this.dtDoanhThu.Compute("SUM(" + this.strColumnNumDt + ")", "");
            double numSum = (obj2 == DBNull.Value) ? 0.0 : Convert.ToDouble(obj2);
            foreach (DataRow row in this.dtDoanhThu.Rows)
            {

                double numDt = Convert.ToDouble(row[this.strColumnNumDt]);
                double numCp = Convert.ToDouble(row[this.strColumnNumCp]);
                //string num2Format = Common.FormatNumToString(num2.ToString(), "0", ".");
                string strColumn = this.strColumnName;
                DataDynamics.ActiveReports.Chart.DataPoint point = new DataPoint("X", new DoubleArray(new double[] { numDt }), false, true, (string)row[strColumn]);
                DataDynamics.ActiveReports.Chart.DataPoint point2 = new DataPoint("X", new DoubleArray(new double[] { numCp }), false, true, (string)row[strColumn]);

                series1.Points.Add(point);
                series2.Points.Add(point2);
                Font font = new Font("Arial", 8f);
                Backdrop backdrop1 = new Backdrop();
                Backdrop backdrop2 = new Backdrop();

                DataDynamics.ActiveReports.Chart.Graphics.Line line = new DataDynamics.ActiveReports.Chart.Graphics.Line();               
                DataDynamics.ActiveReports.Chart.Graphics.Line border = new DataDynamics.ActiveReports.Chart.Graphics.Line();
                DataDynamics.ActiveReports.Chart.Graphics.Line line2 = new DataDynamics.ActiveReports.Chart.Graphics.Line();
                DataDynamics.ActiveReports.Chart.Graphics.Line border2 = new DataDynamics.ActiveReports.Chart.Graphics.Line();


                Marker marker = new Marker(8, MarkerStyle.Square, backdrop1, line, new LabelInfo(border, backdrop1, new FontInfo(Color.Black, font), numDt.ToString("#,###"), Alignment.Top));
                Marker markerCp = new Marker(8, MarkerStyle.Square, backdrop2, line2, new LabelInfo(border2, backdrop2, new FontInfo(Color.Black, font), numCp.ToString("#,###"), Alignment.Top));
                point.Marker = marker;
                point2.Marker = markerCp;
            }
        }

        private void SetPrintSize()
        {
            //float num = 100f;
            //this.chartControl1.Height = (this.fHeight / num) - 0.3f;
            //this.chartControl1.Width = (this.fWidth / num) - 0.3f;
            //this.pageHeader.Height = (this.fHeight / num) - 0.3f;
            //base.PageSettings.PaperHeight = (this.fHeight / num) - 0.2f;
            //base.PageSettings.PaperKind = PaperKind.Custom;
            //base.PageSettings.PaperName = "Custom paper";
            //base.PageSettings.PaperWidth = (this.fWidth / num) - 0.22f;
            //base.PrintWidth = (this.fWidth / num) - 0.22f;

        }

    }
}
