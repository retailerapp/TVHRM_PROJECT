using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using System.Threading;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using System.Reflection;
using System.Data.SqlClient;

namespace Epoint.Systems.Customizes
{
    public partial class ucWTable : UserControl
    {
        // Fields
        public static BindingSource bdsCongNo = new BindingSource();
        public static BindingSource bdsTaiKhoan = new BindingSource();
        private dgvControl dgvCongNo;
        private dgvControl dgvTaiKhoan;
        public static DataTable dtCongNo;
        public static DataTable dtDoanhThu;
        public static DataTable dtDoanhThuChiPhi;
        public static DataTable dtTaiKhoan;
        private static bool Is_LoadCongNo = false;
        private bool Is_LoadDesktop;
        private static bool Is_LoadDoanhThu = false;
        private static bool Is_LoadDoanhThuChiPhi = false;
        private static bool Is_LoadTaiKhoan = false;
        private bool Is_ViewCongNo;
        private bool Is_ViewDoanhThu;
        private bool Is_ViewDoanhThuChiPhi;
        private bool Is_ViewTaiKhoan;

        private static rptDoanhThu rptDoanhThu = new rptDoanhThu();
        //private static rptDoanhThuChiPhi rptDoanhThuChiPhi = new rptDoanhThuChiPhi();
        private static rtpDTCP rptDoanhThuChiPhi = new rtpDTCP();

        private static Thread threadCongNo = new Thread(new ThreadStart(ucWTable.LoadCongNo));
        private static Thread threadDoanhThu = new Thread(new ThreadStart(ucWTable.LoadDoanhThu));
        private static Thread threadDoanhThuChiPhi = new Thread(new ThreadStart(ucWTable.LoadDoanhThuChiPhi));
        private static Thread threadTaiKhoan = new Thread(new ThreadStart(ucWTable.LoadTaiKhoan));
        private System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
        private DataDynamics.ActiveReports.Viewer.Viewer viewDoanhThu;
        private DataDynamics.ActiveReports.Viewer.Viewer viewDoanhThuChiPhi;
        private static float viewDoanhThuChiPhiHeight = 0f;
        private static float viewDoanhThuChiPhiWidth = 0f;
        private static float viewDoanhThuHeight = 0f;
        private static float viewDoanhThuWidth = 0f;


        static ucWTable()
        {
            bdsCongNo = new BindingSource();
            bdsTaiKhoan = new BindingSource();
            rptDoanhThuChiPhi = new rtpDTCP();
            rptDoanhThu = new rptDoanhThu();
            viewDoanhThuChiPhiHeight = 0f;
            viewDoanhThuChiPhiWidth = 0f;
            viewDoanhThuHeight = 0f;
            viewDoanhThuWidth = 0f;
            Is_LoadDoanhThuChiPhi = false;
            Is_LoadDoanhThu = false;
            Is_LoadCongNo = false;
            Is_LoadTaiKhoan = false;
            //threadCongNo = new Thread(new ThreadStart(ucWTable.LoadCongNo));
            //threadTaiKhoan = new Thread(new ThreadStart(ucWTable.LoadTaiKhoan));
            //threadDoanhThuChiPhi = new Thread(new ThreadStart(ucWTable.LoadDoanhThuChiPhi));
            //threadDoanhThu = new Thread(new ThreadStart(ucWTable.LoadDoanhThu));
        }
        public ucWTable()
        {
            this.InitializeComponent();
            threadCongNo = new Thread(new ThreadStart(ucWTable.LoadCongNo));
            threadTaiKhoan = new Thread(new ThreadStart(ucWTable.LoadTaiKhoan));
            threadDoanhThuChiPhi = new Thread(new ThreadStart(ucWTable.LoadDoanhThuChiPhi));
            threadDoanhThu = new Thread(new ThreadStart(ucWTable.LoadDoanhThu));
            //base.Resize += new EventHandler(this.ucDesktop_Resize);
            this.dgvCongNo.DoubleClick += new EventHandler(this.dgvCongNo_DoubleClick);
            this.dgvCongNo.KeyDown += new KeyEventHandler(this.dgvCongNo_KeyDown);
        }




        public void Load()
        {
            this.Build();
            this.time.Interval = 100;
            this.time.Start();
            this.time.Tick += new EventHandler(this.time_Tick);
            base.Show();
            viewDoanhThuChiPhiHeight = this.viewDoanhThuChiPhi.Height - 1;
            viewDoanhThuChiPhiWidth = this.viewDoanhThuChiPhi.Width;
            viewDoanhThuHeight = this.viewDoanhThu.Height - 15;
            viewDoanhThuWidth = this.viewDoanhThu.Width;
            threadTaiKhoan.Start();
            threadCongNo.Start();
            threadDoanhThuChiPhi.Start();
            threadDoanhThu.Start();
        }

        private void time_Tick(object sender, EventArgs e)
        {
            if (!this.Is_LoadDesktop)
            {
                this.FillData();
            }
        }





        public void Build()
        {
            this.dgvCongNo.ReadOnly = true;
            this.dgvCongNo.strZone = "NHACCONGNO";
            this.dgvCongNo.BuildGridView(false);
            this.dgvCongNo.ResizeGridView();
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.strZone = "DULIEUTONGHOP";
            this.dgvTaiKhoan.BuildGridView(false);
            this.dgvTaiKhoan.ResizeGridView(0x5f);
        }





        public void FillData()
        {
            if (!this.Is_ViewDoanhThu && Is_LoadDoanhThu)
            {
                this.viewDoanhThu.HorizontalScroll.Visible = false;
                this.viewDoanhThu.VerticalScroll.Visible = false;
                this.viewDoanhThu.Document = rptDoanhThu.Document;
                this.Is_ViewDoanhThu = true;
            }
            if (!this.Is_ViewDoanhThuChiPhi && Is_LoadDoanhThuChiPhi)
            {
                this.viewDoanhThuChiPhi.Document = rptDoanhThuChiPhi.Document;
                this.Is_ViewDoanhThuChiPhi = true;
            }
            if (!this.Is_ViewCongNo && Is_LoadCongNo)
            {
                bdsCongNo.DataSource = dtCongNo;
                this.dgvCongNo.DataSource = bdsCongNo;
                this.Is_ViewCongNo = true;
            }
            if (!this.Is_ViewTaiKhoan && Is_LoadTaiKhoan)
            {
                bdsTaiKhoan.DataSource = dtTaiKhoan;
                this.dgvTaiKhoan.DataSource = bdsTaiKhoan;
                this.Is_ViewTaiKhoan = true;
            }
            if ((this.Is_ViewCongNo && this.Is_ViewDoanhThuChiPhi) && (this.Is_ViewDoanhThu && this.Is_ViewTaiKhoan))
            {
                this.Is_LoadDesktop = true;
                this.time.Stop();
            }
        }

        private static void LoadDoanhThu()
        {
            //Library.StrToDate("01/01/" + DateTime.Now.Year);
            //DateTime now = DateTime.Now;
            //dtDoanhThu = new DataTable();
            //dtDoanhThu = SQLExec.ExecuteReturnDt(string.Concat(new object[] { "SET DATEFORMAT DMY EXEC sp_rptDKST02 '01/01/", DateTime.Now.Year, "','", now.Day, "/", now.Month, "/", now.Year, "', 1, 'V', ", Element.sysMa_DvCs }));

            SqlConnection newSQLConnection = SQLExec.GetNewSQLConnection();
            SqlCommand selectCommand = new SqlCommand
            {
                Connection = newSQLConnection
            };
            Library.StrToDate("01/01/" + DateTime.Now.Year);
            DateTime now = DateTime.Now;
            selectCommand.CommandText = string.Concat(new object[] { "SET DATEFORMAT DMY EXEC sp_rptDKST02 '01/01/", DateTime.Now.Year, "','", now.Day, "/", now.Month, "/", now.Year, "', 1, 'V', ", Element.sysMa_DvCs });
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            dtDoanhThu = new DataTable();
            adapter.Fill(dtDoanhThu);
            rptDoanhThu.fHeight = viewDoanhThuHeight;
            rptDoanhThu.fWidth = viewDoanhThuWidth;
            rptDoanhThu.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
            rptDoanhThu.Load(dtDoanhThu);
            try
            {
                rptDoanhThu.Run();
            }
            catch (Exception)
            {
                rptDoanhThu.Run();
            }
            Is_LoadDoanhThu = true;
            threadDoanhThu.Abort();


        }

        private static void LoadDoanhThuChiPhi()
        {

            //Library.StrToDate("01/01/" + DateTime.Now.Year);
            //DateTime now = DateTime.Now;
            //dtDoanhThuChiPhi = SQLExec.ExecuteReturnDt(string.Concat(new object[] { "SET DATEFORMAT DMY EXEC sp_rptDKST01 '01/01/", DateTime.Now.Year, "','", now.Day, "/", now.Month, "/", now.Year, "', 1, 'V', ", Element.sysMa_DvCs }));

            //dtDoanhThuChiPhi = new DataTable();

            SqlConnection newSQLConnection = SQLExec.GetNewSQLConnection();
            SqlCommand selectCommand = new SqlCommand
            {
                Connection = newSQLConnection
            };
            Library.StrToDate("01/01/" + DateTime.Now.Year);
            DateTime now = DateTime.Now;
            selectCommand.CommandText = string.Concat(new object[] { "SET DATEFORMAT DMY EXEC sp_rptDKST01 '01/01/", DateTime.Now.Year, "','", now.Day, "/", now.Month, "/", now.Year, "', 1, 'V', ", Element.sysMa_DvCs });
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            dtDoanhThuChiPhi = new DataTable();
            adapter.Fill(dtDoanhThuChiPhi);
            rptDoanhThuChiPhi.fHeight = viewDoanhThuChiPhiHeight;
            rptDoanhThuChiPhi.fWidth = viewDoanhThuChiPhiWidth;
            rptDoanhThuChiPhi.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");
            rptDoanhThuChiPhi.Load(dtDoanhThuChiPhi);
            try
            {
                rptDoanhThuChiPhi.Run();
            }
            catch (Exception)
            {
                rptDoanhThuChiPhi.Run();
            }
            Is_LoadDoanhThuChiPhi = true;
            threadDoanhThuChiPhi.Abort();
        }
        private static void LoadTaiKhoan()
        {

            SqlConnection newSQLConnection = SQLExec.GetNewSQLConnection();
            SqlCommand selectCommand = new SqlCommand
            {
                Connection = newSQLConnection,
                CommandText = "sp_ViewReminderTaiKhoan " + Element.sysMa_DvCs
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            dtTaiKhoan = new DataTable();
            adapter.Fill(dtTaiKhoan);
            Is_LoadTaiKhoan = true;
            threadTaiKhoan.Abort();

        }

        private static void LoadCongNo()
        {
            SqlConnection newSQLConnection = SQLExec.GetNewSQLConnection();
            SqlCommand selectCommand = new SqlCommand
            {
                Connection = newSQLConnection,
                CommandText = "sp_ViewReminderHanTt 'V'," + Element.sysMa_DvCs
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            dtCongNo = new DataTable();
            adapter.Fill(dtCongNo);
            Is_LoadCongNo = true;
            threadCongNo.Abort();

        }

        private void Edit()
        {
            if ((bdsCongNo.Position >= 0) && (dtCongNo.Columns.Contains("Stt") && dtCongNo.Columns.Contains("Ma_Ct")))
            {
                DataRow row = ((DataRowView)bdsCongNo.Current).Row;
                if ((((string)row["Stt"]).Trim() != string.Empty) && (((string)row["Ma_Ct"]).Trim() != string.Empty))
                {
                    string str = (string)DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", (string)row["Ma_Ct"])["Edit_Voucher_Method"];
                    string[] strArray = str.Split(new char[] { ':' });
                    if (strArray.Length != 3)
                    {
                        Common.MsgCancel("Định dạng MethodName = " + str + " kh\x00f4ng đ\x00fang");
                    }
                    else
                    {
                        string assemblyString = string.Empty;
                        string name = string.Empty;
                        assemblyString = strArray[0];
                        name = "Epoint." + strArray[1];
                        Type type = Assembly.Load(assemblyString).GetType(name);
                        Form target = (Form)Activator.CreateInstance(type);
                        object[] objArray2 = new object[3];
                        objArray2[0] = enuEdit.Edit;
                        objArray2[1] = row;
                        object[] args = objArray2;
                        type.InvokeMember(strArray[2], BindingFlags.InvokeMethod, null, target, args);
                    }
                }
            }
        }

 

 


        private void dgvCongNo_DoubleClick(object sender, EventArgs e)
        {
            this.Edit();
        }



        private void dgvCongNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                this.Edit();
            }
        }

 

 


        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

        }
    }
}
