using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Chart;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Chart.Graphics;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using System.Collections;
using System.Data.SqlClient;

namespace Epoint.Modules.HRM
{
    public partial class frmResourceAnalysis : Epoint.Systems.Customizes.frmView
    {
        string strMa_Ct;
        DataSet dsNhanVien;
        private static float viewDoanhThuHeight = 0f;
        private static float viewDoanhThuWidth = 0f;
        private static rptResourceChart_Kv rptChar = new rptResourceChart_Kv();

        public frmResourceAnalysis()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);

            this.btMa_Kv_Tag.Click += new EventHandler(btMa_Kv_Tag_Click);
            this.btMa_Bp_Tag.Click += new EventHandler(btMa_Bp_Tag_Click);
            this.btTag_List.Click += new EventHandler(btTag_List_Click);

            this.btLoadData.Click += new EventHandler(BtLoadData_Click);
        }

        new public void Load()
        {
            this.BindingLanguage();           
            
            dteFromDate.Text = Library.DateToStr(Element.sysNgay_Begin);
            dteTodate.Text = Library.DateToStr(Element.sysNgay_End);

            LoadResourceChart();
            this.Show();
        }
        private static void LoadResourceChart()
        {
            try
            {

                rptChar.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
            }
            catch(Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
            }
        }


        void btOk_Click(object sender, EventArgs e)
        {
            Common.CloseCurrentForm();
            Application.Restart();
        }
        
        void btCancel_Click(object sender, EventArgs e)
        {
            Common.CloseCurrentForm();
        }

        private void BtLoadData_Click(object sender, EventArgs e)
        {
            
            Hashtable htParameter = new Hashtable();
            htParameter.Add("MA_KV", txtMa_Kv_List.Text);
            htParameter.Add("MA_BP", txtMa_Bp_List.Text);
            htParameter.Add("MA_VITRI", txtTag_List.Text);
            htParameter.Add("CHARTREPORT", 2);
            htParameter.Add("NGAY1", dteFromDate.Text);
            htParameter.Add("NGAY2", dteTodate.Text);

            dsNhanVien = SQLExec.ExecuteReturnDs("HRM_GetEmployeeCount", htParameter, CommandType.StoredProcedure);

            if (dsNhanVien.Tables.Count == 0)
            {
                EpointMessage.MsgOk("Không có dữ liệu");
                return;
            }
            LoadChart1(dsNhanVien.Tables[0]);
            LoadChartHd(dsNhanVien.Tables[1]);

        }
        
        void LoadChartHd(DataTable dtLoad)
        {
            chartHd.DataSource = dtLoad;
            //chartGT.Series[0].Points.DataBindXY("Gioi_Tinh", "CountGT");
            chartHd.Series[0].Points.Clear();
            foreach (DataRow dr in dtLoad.Rows)
            {
                double dataPoint = 0, dataPointPer = 0;
                double.TryParse(dr["CountHd"].ToString(), out dataPoint);

                chartHd.Series[0].Points.AddXY(dr["Label"].ToString(), dataPoint);
                chartHd.Series[0].IsValueShownAsLabel = true;
            }

        }
        /*void LoadChart2(DataTable dtLoad)
        {
            chartMa_KV.DataSource = dtLoad;
            chartMa_KV.Series.Clear();
            foreach (DataRow dr in dtLoad.Rows)
            {
                int i = 0;
                string Ma_Kv = dr["Ma_Kv"].ToString();
                double dataPointNew = 0, dataPointBreak = 0;
                double.TryParse(dr["SlNew"].ToString(), out dataPointNew);
                double.TryParse(dr["SlBreak"].ToString(), out dataPointBreak);

                chartMa_KV.Series.Add(Ma_Kv);
                chartMa_KV.Series[Ma_Kv].Points.AddXY(Ma_Kv, dataPointNew);
                chartMa_KV.Series[Ma_Kv].Points.AddXY(Ma_Kv, dataPointBreak);//+ " (" + dataPointPer.ToString("0.00%") + ")"
                chartMa_KV.Series[Ma_Kv].BorderWidth = 1;
                chartMa_KV.Series[Ma_Kv].MarkerSize = 3;
                chartMa_KV.Series[Ma_Kv].IsXValueIndexed = true;
                chartMa_KV.Series[Ma_Kv].IsValueShownAsLabel = true;
                i++;

            }
        }*/
        void LoadChart1(DataTable dtLoad)
        {
            try
            {
                ChartNVNew_Break.DataSource = dtLoad;


                ChartNVNew_Break.Series[0].XValueMember = "Ma_Kv";
                ChartNVNew_Break.Series[0].YValueMembers = "SlBreak";
                ChartNVNew_Break.Series[1].XValueMember = "Ma_Kv";
                ChartNVNew_Break.Series[1].YValueMembers = "SLNew";
                ChartNVNew_Break.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                ChartNVNew_Break.ChartAreas[0].AxisX.Interval = 1;
                ChartNVNew_Break.Series[1].Name = "Mới";
                ChartNVNew_Break.Series[0].Name = "Nghỉ";

               
            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
            }
            
        }

        void LoadChart1_Active(DataTable dtLoad)
        {
            try
            {
                rptResourceChart_NewBreak rptChar = new rptResourceChart_NewBreak();
                rptChar = new rptResourceChart_NewBreak();
                this.rptChartResoure.HorizontalScroll.Visible = false;
                this.rptChartResoure.VerticalScroll.Visible = false;
                this.rptChartResoure.Document = rptChar.Document;
                rptChar.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
                rptChar.Load(dtLoad, "Ma_KV", "SlNew");
                try
                {
                    rptChar.Run();
                }
                catch (Exception)
                {
                    rptChar.Run();
                }
            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
            }

        }

        void btTag_List_Click(object sender, EventArgs e)
        {
            bool bRequire = true; bool bIs_Overide = true;
            string strValue = txtTag_List.Text;
            DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Vitri", strValue, bRequire, "", "", "");


            if (bRequire && drLookup == null)
            {
                txtTag_List.Text = "*";
                return;
            }
            txtTag_List.Text = drLookup["MuiltiSelectValue"].ToString();
        }

        void btMa_Bp_Tag_Click(object sender, EventArgs e)
        {
            bool bRequire = true; bool bIs_Overide = true;
            string strValue = txtMa_Bp_List.Text;
            DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Bp", strValue, bRequire, "", "", "");


            if (bRequire && drLookup == null)
            {
                txtMa_Bp_List.Text = "*";
                return;
            }
            txtMa_Bp_List.Text = drLookup["MuiltiSelectValue"].ToString();
        }

        void btMa_Kv_Tag_Click(object sender, EventArgs e)

        {
            bool bRequire = true; bool bIs_Overide = true;
            string strValue = txtMa_Kv_List.Text;
            DataRow drLookup = Lookup.ShowMultiLookupNew("Ma_Kv", strValue, bRequire, "", "", "");


            if (bRequire && drLookup == null)
            {
                txtMa_Kv_List.Text = "*";
                return;
            }
            txtMa_Kv_List.Text = drLookup["MuiltiSelectValue"].ToString();
        }
    }
}
