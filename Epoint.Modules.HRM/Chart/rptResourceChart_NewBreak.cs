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

namespace Epoint.Modules.HRM
{
    public partial class rptResourceChart_NewBreak : DataDynamics.ActiveReports.ActiveReport3
    {
        private DataTable dtDataResource;
        private string strColumnName;
        private string strColumnNum;
        public float fHeight = 0f;
        public float fWidth = 0f;
        public rptResourceChart_NewBreak()
        {
            InitializeComponent();
        }
        public void Load(DataTable dtData,string strColumnName, string  strColumnNum)
        {
            this.fHeight = 500f;
            this.fWidth = 600f;
            
            this.dtDataResource = dtData;
            this.strColumnNum = strColumnNum;
            this.strColumnName = strColumnName;
            this.SetPrintSize();
            this.LoadChart(dtData);
        }

        private void LoadChart(DataTable dtHuMan)
        {
            //DataTable dtHuMan = SQLExec.ExecuteReturnDt("EXEC sp_HRM_GetHumanValue 'KHUVUC'");
            Series seriesNew = this.chartControl1.Series[0];
            Series seriesBreak = this.chartControl1.Series[1];

            object objNew = dtHuMan.Compute("SUM(SlNew)", "");
            double numSumNew = (objNew == DBNull.Value) ? 0.0 : Convert.ToDouble(objNew);

            object objBreak = dtHuMan.Compute("SUM(SlBreak)", "");
            double numSumNBreak = (objBreak == DBNull.Value) ? 0.0 : Convert.ToDouble(objBreak);


            seriesNew.Points.Clear();
            seriesBreak.Points.Clear();
            foreach (DataRow row in dtHuMan.Rows)
            {
                double numNew = Convert.ToDouble(row["SlNew"]);
                double numBreak = Convert.ToDouble(row["SlBreak"]);
                double numPercent = numNew / numSumNew;
                //string num2Format = Common.FormatNumToString(num2.ToString(), "0", ".");
                string strColumn = strColumnName;
                DataDynamics.ActiveReports.Chart.DataPoint pointNew = new DataPoint("X", new DoubleArray(new double[] { numNew }), false, true, (string)row[strColumn]);
                DataDynamics.ActiveReports.Chart.DataPoint pointBreak = new DataPoint("X", new DoubleArray(new double[] { numBreak }), false, true, (string)row[strColumn]);

                seriesNew.Points.Add(pointNew);
                seriesBreak.Points.Add(pointBreak);

                Font font = new Font("Arial", 8f);
                Backdrop backdrop = new Backdrop();
                Backdrop backdrop0 = new Backdrop();
                Backdrop backdrop1 = new Backdrop();
                Backdrop backdrop2 = new Backdrop();
                DataDynamics.ActiveReports.Chart.Graphics.Line line = new DataDynamics.ActiveReports.Chart.Graphics.Line();                
                DataDynamics.ActiveReports.Chart.Graphics.Line border = new DataDynamics.ActiveReports.Chart.Graphics.Line();
                DataDynamics.ActiveReports.Chart.Graphics.Line line2 = new DataDynamics.ActiveReports.Chart.Graphics.Line();
                DataDynamics.ActiveReports.Chart.Graphics.Line border2 = new DataDynamics.ActiveReports.Chart.Graphics.Line();
                Marker marker1 = new Marker(5, MarkerStyle.Square, backdrop, line, new LabelInfo(border, backdrop1, new FontInfo(Color.Black, font), row[strColumn] + ":" + numNew.ToString() + "(Mới)" , Alignment.Top));
                Marker marker2 = new Marker(5, MarkerStyle.Square, backdrop, line2, new LabelInfo(border2, backdrop2, new FontInfo(Color.Black, font), row[strColumn] + " : " + numBreak.ToString() + "(Nghỉ)", Alignment.Top));
                pointNew.Marker = marker1;
                pointBreak.Marker = marker2;
            }


        }

        private void SetPrintSize()
        {
            float num = 100f;
            //this.chartControl1.Height = (this.fHeight / num) - 0.3f;
            //this.chartControl1.Width = (this.fWidth / num) - 0.3f;

            //this.chartControl2.Height = (this.fHeight / num) - 0.3f;
            //this.chartControl2.Width = (this.fWidth / num) - 0.3f;

            //this.pageHeader.Height = (this.fHeight / num) - 0.3f;
            //this.PageSettings.PaperHeight = (this.fHeight / num) - 0.2f;
            //this.PageSettings.PaperKind = PaperKind.Custom;
            //this.PageSettings.PaperName = "Printer Default";
            //this.PageSettings.PaperWidth = (this.fWidth / num) - 0.22f;
            //this.PrintWidth = (this.fWidth / num) - 0.22f;
        }

    }
}
