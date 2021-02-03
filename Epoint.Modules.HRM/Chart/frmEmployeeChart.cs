using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;

namespace Epoint.Modules.HRM
{
    public partial class frmEmployeeChart : Epoint.Systems.Customizes.frmView
    {

        DataSet dsNhanVien;
        public frmEmployeeChart()
        {
            InitializeComponent();

            this.btMa_Kv_Tag.Click += new EventHandler(btMa_Kv_Tag_Click);
            this.btMa_Bp_Tag.Click += new EventHandler(btMa_Bp_Tag_Click);
            this.btTag_List.Click += new EventHandler(btTag_List_Click);

            this.btLoadData.Click += new EventHandler(BtLoadData_Click);
        }

        

        new public void Load()
        {
            this.BindingLanguage();
           
            this.Show();
        }
        void LoadChart1(DataTable dtLoad)
        {
            chartTuoi.DataSource = dtLoad;
            //chartGT.Series[0].Points.DataBindXY("Gioi_Tinh", "CountGT");
            chartTuoi.Series[0].Points.Clear();

            foreach (DataRow dr in dtLoad.Rows)
            {
                double dataPoint = 0,dataPointPer = 0;
                double.TryParse(dr["Count_Nv"].ToString(), out dataPoint);                 
                double.TryParse(dr["Per"].ToString(), out dataPointPer);

                chartTuoi.Series[0].Points.AddXY(dr["Tuoi"].ToString() + " (" + dataPointPer.ToString("0.00%")+ ")" , dataPoint);
                chartTuoi.Series[0].IsValueShownAsLabel = true;
                //chartGT.ChartAreas.First().AxisY.LabelStyle.Format = "0.00%";
            }

        }
        void LoadChart2(DataTable dtLoad)
        {           
            chartSLNV.DataSource = dtLoad;

            chartSLNV.Series[0].XValueMember = "Thang";
            chartSLNV.Series[0].YValueMembers = "SLPre";
            chartSLNV.Series[1].XValueMember = "Thang";
            chartSLNV.Series[1].YValueMembers = "SL";

            chartSLNV.Series[0].Name = "2019";
            chartSLNV.Series[1].Name = "2020";
            //chartSLNV.Series[0].Points.AddXY("SL", "Thang");
            //chartSLNV.Series[1].Points.AddXY("Nam", "SL");


        }
        void LoadChart3_Active(DataTable dtLoad)
        {
            try
            {
                rptResourceChart_Kv rptChar = new rptResourceChart_Kv();
                rptChar = new rptResourceChart_Kv();
                this.rptChartResoure.HorizontalScroll.Visible = false;
                this.rptChartResoure.VerticalScroll.Visible = false;
                this.rptChartResoure.Document = rptChar.Document;
                rptChar.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
                rptChar.Load(dtLoad, "ID", "Value");
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
            /*
            chartMa_KV.DataSource = dtLoad;
            
            //chartMa_KV.Series[0].IsVisibleInLegend = false;
            //chartMa_KV.Series[0].Points.Clear();
            //foreach (DataRow dr in dtLoad.Rows)
            //{
            //    double dataPoint = 0, dataPointPer = 0;
            //    double.TryParse(dr["Count_Nv"].ToString(), out dataPoint);
            //    double.TryParse(dr["Per"].ToString(), out dataPointPer);

            //    chartMa_KV.Series[0].Points.AddXY(dr["Ma_Kv"].ToString(), dataPoint);//+ " (" + dataPointPer.ToString("0.00%") + ")"
            //    chartMa_KV.Series[0].IsValueShownAsLabel = true;
            //}
            //return;

            chartMa_KV.Series.Clear();
            foreach (DataRow dr in dtLoad.Rows)
            {
                int i = 0;
                string Ma_Kv = dr["Ma_Kv"].ToString();
                double dataPoint = 0, dataPointPer = 0;
                double.TryParse(dr["Count_Nv"].ToString(), out dataPoint);
                double.TryParse(dr["Per"].ToString(), out dataPointPer);
                
                chartMa_KV.Series.Add(Ma_Kv);
                chartMa_KV.Series[Ma_Kv].Points.AddXY(Ma_Kv, dataPoint);//+ " (" + dataPointPer.ToString("0.00%") + ")"
                chartMa_KV.Series[Ma_Kv].BorderWidth = 3;
                chartMa_KV.Series[Ma_Kv].IsValueShownAsLabel = true;
                i++;

            }*/
        }
        void LoadChart3(DataTable dtLoad)
        {
           
            chartMa_KV.DataSource = dtLoad;


            chartSLNV.Series[0].XValueMember = "Ma_Kv";
            chartSLNV.Series[0].YValueMembers = "SLPre";
            chartSLNV.Series[1].XValueMember = "Ma_Kv";
            chartSLNV.Series[1].YValueMembers = "SL";

        }

        void LoadChart4(DataTable dtLoad)
        {
            chartTuoi.DataSource = dtLoad;
            //chartGT.Series[0].Points.DataBindXY("Gioi_Tinh", "CountGT");
            chartGT.Series[0].Points.Clear();
            foreach (DataRow dr in dtLoad.Rows)
            {
                double dataPoint = 0,dataPointPer = 0;
                double.TryParse(dr["Count_Nv"].ToString(), out dataPoint);                 
                double.TryParse(dr["Per"].ToString(), out dataPointPer);

                chartGT.Series[0].Points.AddXY(dr["Gioi_Tinh"].ToString() + " (" + dataPointPer.ToString("0.00%")+ ")" , dataPoint);
                chartGT.Series[0].IsValueShownAsLabel = true;
                //chartGT.ChartAreas.First().AxisY.LabelStyle.Format = "0.00%";
            }

        }

        private void BtLoadData_Click(object sender, EventArgs e)
        {
            Hashtable htParameter = new Hashtable();
            htParameter.Add("MA_KV", txtMa_Kv_List.Text);
            htParameter.Add("MA_BP", txtMa_Bp_List.Text);
            htParameter.Add("MA_VITRI", txtTag_List.Text);
            htParameter.Add("CHARTREPORT", 1);
            //htParameter.Add("KEY", "");
            //htParameter.Add("NGAY_CT", "");
            //htParameter.Add("SUFFIXLEN", "");
            dsNhanVien = SQLExec.ExecuteReturnDs("HRM_GetEmployeeCount", htParameter,CommandType.StoredProcedure);

            if (dsNhanVien.Tables.Count == 0)
            {

                EpointMessage.MsgOk("Không có dữ liệu");
                return;
            }

            LoadChart1(dsNhanVien.Tables[0]);
            LoadChart2(dsNhanVien.Tables[1]);
            LoadChart3_Active(dsNhanVien.Tables[2]);
            LoadChart4(dsNhanVien.Tables[3]);

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
