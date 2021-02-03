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
    public partial class frmEmployeeChart0 : Epoint.Systems.Customizes.frmView
    {

        DataSet dsNhanVien;
        public frmEmployeeChart0()
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
        private void BtLoadData_Click(object sender, EventArgs e)
        {
            Hashtable htParameter = new Hashtable();
            htParameter.Add("MA_KV", txtMa_Kv_List.Text);
            htParameter.Add("MA_BP", txtMa_Bp_List.Text);
            htParameter.Add("MA_VITRI", txtTag_List.Text);
            htParameter.Add("CHARTREPORT", 3);
            dsNhanVien = SQLExec.ExecuteReturnDs("HRM_GetEmployeeCount", htParameter,CommandType.StoredProcedure);

            if (dsNhanVien.Tables.Count == 0)
            {
                EpointMessage.MsgOk("Không có dữ liệu");
                return;
            }

            Tab1_Chart_PhongBan(dsNhanVien.Tables[0],"Ma_Bp");
            Tab1_Chart_Kv(dsNhanVien.Tables[0], "Ma_Loai2");

            Tab2_Chart_Vitri(dsNhanVien.Tables[0], "Ma_Vitri");
            Tab3_LoadChartGioiTinh(dsNhanVien.Tables[1], "Code");
            Tab5_LoadChartHopDong(dsNhanVien.Tables[2], "Code");
            Tab4_LoadTrinhDo(dsNhanVien.Tables[3], "Code");
        }

        private void Tab1_Chart_PhongBan(DataTable dataTable,string code)
        {
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add("Code",typeof(String));
            dtSource.Columns.Add("Value", typeof(Int32));

            var GroupData = (from b in dataTable.AsEnumerable()
                  group b by b.Field<string>(code) into g
                  let count = g.Count()
                  select new
                  {
                      Ma_Bp = g.Key,
                      Count = count,
                  }).ToList();
            foreach(var Item in GroupData)
            {
                dtSource.Rows.Add(Item.Ma_Bp, Item.Count);
            }


            ChartPhongBan.DataSource = dtSource;
            ChartPhongBan.Series[0].XValueMember = "Code";
            ChartPhongBan.Series[0].YValueMembers = "Value";
            ChartPhongBan.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            ChartPhongBan.ChartAreas[0].AxisX.Interval = 1;
        }


        private void Tab1_Chart_Kv(DataTable dataTable, string code)
        {
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add("Code", typeof(String));
            dtSource.Columns.Add("Value", typeof(Int32));

            var GroupData = (from b in dataTable.AsEnumerable()
                             group b by b.Field<string>(code) into g
                             let count = g.Count()
                             select new
                             {
                                 Ma_Bp = g.Key,
                                 Count = count,
                             }).ToList();
            foreach (var Item in GroupData)
            {
                dtSource.Rows.Add(Item.Ma_Bp, Item.Count);
            }


            chartKV.DataSource = dtSource;
            chartKV.Series[0].XValueMember = "Code";
            chartKV.Series[0].YValueMembers = "Value";
            chartKV.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            chartKV.ChartAreas[0].AxisX.Interval = 1;
        }
        private void Tab2_Chart_Vitri(DataTable dataTable, string code)
        {
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add("Code", typeof(String));
            dtSource.Columns.Add("Value", typeof(Int32));

            var GroupData = (from b in dataTable.AsEnumerable()
                             group b by b.Field<string>(code) into g
                             let count = g.Count()
                             select new
                             {
                                 Ma_Bp = g.Key,
                                 Count = count,
                             }).ToList();
            foreach (var Item in GroupData)
            {
                dtSource.Rows.Add(Item.Ma_Bp, Item.Count);
            }


            chartViTri.DataSource = dtSource;
            chartViTri.Series[0].XValueMember = "Code";
            chartViTri.Series[0].YValueMembers = "Value";
            chartViTri.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            chartViTri.ChartAreas[0].AxisX.Interval = 1;
        }
        void Tab3_LoadChartGioiTinh(DataTable dtLoad,String Code)
        {
            try
            {
                chartGioiTinh.DataSource = dtLoad;


                chartGioiTinh.Series[0].XValueMember = "Code";
                chartGioiTinh.Series[0].YValueMembers = "Nam";
                chartGioiTinh.Series[1].XValueMember = "Code";
                chartGioiTinh.Series[1].YValueMembers = "Nu";
                chartGioiTinh.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartGioiTinh.ChartAreas[0].AxisX.Interval = 1;
                chartGioiTinh.Series[1].Name = "Nữ";
                chartGioiTinh.Series[0].Name = "Nam";


            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
            }

        }

        void Tab4_LoadTrinhDo(DataTable dtLoad, String Code)
        {
            chartTrinhDo.Series.Clear();
            try
            {
                chartTrinhDo.DataSource = dtLoad;
                chartTrinhDo.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartTrinhDo.ChartAreas[0].AxisX.Interval = 1;
                //DataView view = new DataView(dtLoad);
                //DataTable dtLoaiHD = view.ToTable(true, "Loai_Hd");

                foreach (DataColumn dcr in dtLoad.Columns)
                {
                    int i = 0;
                    string S = dcr.ColumnName;
                    if (S == "MA_KV")
                        continue;
                    //double dataPointNew = 0;
                    //double.TryParse(dr["Value"].ToString(), out dataPointNew);
                    chartTrinhDo.Series.Add(S);
                    chartTrinhDo.Series[S].ChartType = SeriesChartType.StackedColumn100;
                   chartTrinhDo.Series[S].XValueMember = "MA_KV";
                    chartTrinhDo.Series[S].YValueMembers = S;
                    chartTrinhDo.Series[S].BorderWidth = 1;
                    chartTrinhDo.Series[S].MarkerSize = 3;
                    chartTrinhDo.Series[S].IsXValueIndexed = true;
                    chartTrinhDo.Series[S].IsValueShownAsLabel = true;
                    i++;

                }


            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
            }

        }
        void Tab5_LoadChartHopDong(DataTable dtLoad, String Code)
        {
            chartHopDong.Series.Clear();
            try
            {
                chartHopDong.DataSource = dtLoad;
                chartHopDong.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                chartHopDong.ChartAreas[0].AxisX.Interval = 1;
                //DataView view = new DataView(dtLoad);
                //DataTable dtLoaiHD = view.ToTable(true, "Loai_Hd");

                foreach (DataColumn   dcr in dtLoad.Columns)
                {
                    int i = 0;
                    string S = dcr.ColumnName;
                    if (S == "MA_KV")
                        continue;
                    //double dataPointNew = 0;
                    //double.TryParse(dr["Value"].ToString(), out dataPointNew);
                    chartHopDong.Series.Add(S);
                    chartHopDong.Series[S].XValueMember = "MA_KV";
                    chartHopDong.Series[S].YValueMembers = S;
                    chartHopDong.Series[S].BorderWidth = 1;
                    chartHopDong.Series[S].MarkerSize = 3;
                    chartHopDong.Series[S].IsXValueIndexed = true;
                    chartHopDong.Series[S].IsValueShownAsLabel = true;
                    i++;

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
