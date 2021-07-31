using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
    public partial class MainChart : UserControl
    {
        public MainChart()
        {
            InitializeComponent();
        }
        public void LoadChart(DataSet ds)
        {
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dtChart1 = ds.Tables[0];
                    chart1.Series[0].Points.Clear();
                    double dataPoint = 0, dataPointPer = 0, dataPointSum = Commons.Common.SumDCValue(dtChart1.Select("0=0"), "Value");
                    foreach (DataRow dr in dtChart1.Rows)
                    {

                        double.TryParse(dr["Value"].ToString(), out dataPoint);
                        dataPointPer = (dataPoint / dataPointSum);

                        chart1.Series[0].Points.AddXY(dr["Name"].ToString() + " (" + dataPointPer.ToString("0.00%") + ")", dataPoint);
                        chart1.Series[0].IsValueShownAsLabel = true;
                    }
                    //  Chart 2
                    if (ds.Tables.Count > 1)
                    {

                        dtChart1 = ds.Tables[1];
                        chartR.DataSource = dtChart1;
                        chartR.Series[0].XValueMember = "Name";
                        chartR.Series[0].YValueMembers = "Value1";
                        chartR.Series[1].XValueMember = "Name";
                        chartR.Series[1].YValueMembers = "Value2";
                        chartR.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                        chartR.ChartAreas[0].AxisX.Interval = 1;
                        chartR.Series[0].Name = "Năm Nay";
                        chartR.Series[1].Name = "Năm Trước";

                    }


                    // Chart 3
                    if (ds.Tables.Count > 2)
                    {
                        dtChart1 = ds.Tables[2];

                        chart3.DataSource = dtChart1;

                        chart3.Series[0].XValueMember = "Name";
                        chart3.Series[0].YValueMembers = "Value1";
                        chart3.Series[1].XValueMember = "Name";
                        chart3.Series[1].YValueMembers = "Value2";
                        chart3.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                        chart3.ChartAreas[0].AxisX.Interval = 1;
                        chart3.Series[0].Name = "Nam";
                        chart3.Series[1].Name = "Nữ";

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
