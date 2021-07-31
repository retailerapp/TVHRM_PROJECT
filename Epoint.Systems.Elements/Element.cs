using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Epoint.Systems.Elements
{
    public class Element
    {
        private static SqlConnection Connection = new SqlConnection();
        private static SqlConnection ConnectionUpdate = new SqlConnection();

        private static bool is_Running = false;
        private static bool is_Server = true;
        private static bool is_CheckRunLics = true;
        private static bool is_CheckRunLiveUpdate = false;
        private static bool is_FrmEditRunning = false;
        private static bool is_ShowConfig = false;
        private static string User_Id;
        private static bool Is_Admin;
        private static string Ma_DvCs;
        private static string Ma_Data;
        private static bool Tong_Hop;
        private static DateTime DateTime_Log;
        private static int Th_Bd_Ht;
        private static int WorkingYear;
        private static int iReminder_count;
        private static enuLanguageType Language;
        private static DateTime Ngay_Ct;
        private static DateTime Ngay_Ct1;
        private static DateTime Ngay_Ct2;
        private static Timer Timer = new Timer();
        private static Form frmcalc;
        private static Form frmsearch;
        private static Form frmmain;
        private static Form frmactivemain;
        private static bool Run_Service = true;
        private static string Dia_Chi_Dv; //Thêm Địa chỉ cho từng đơn vị
        private static object ActiveReport = null; // plan Load sẵn ActiveReport khi khởi động chương trình, để in báo cáo cho nhanh
        private static bool TextToolStrip;
        private static string REPORTPATH;
        private static string ConfigFile;
        private static string ConfigFileUpdate;

        //private static string ZaloCodeID;
        //private static string ZaloOfficialID;
        //private static string ZaloSeccretKey;
        //private static string ZaloAccessToken;
        //private static string LinkInfo;

        private static ImageList _ImageList = new ImageList
        {
            ColorDepth = ColorDepth.Depth32Bit,
            ImageSize = new System.Drawing.Size(16, 16)
        };


        public static string sysMa_DvCs
        {
            set { Ma_DvCs = value; }
            get { return Ma_DvCs; }
        }

        public static bool Is_Running
        {
            set
            {
                is_Running = value;
            }
            get
            {
                return is_Running;
            }
        }
        public static bool Is_CheckRunLics
        {
            set
            {
                is_CheckRunLics = value;
            }
            get
            {
                return is_CheckRunLics;
            }
        }
        public static bool Is_CheckRunLiveUpdate
        {
            set
            {
                is_CheckRunLiveUpdate = value;
            }
            get
            {
                return is_CheckRunLiveUpdate;
            }
        }
        public static bool Is_Server
        {
            set
            {
                is_Server = value;
            }
            get
            {
                return is_Server;
            }
        }
        public static bool Is_FrmEditRunning
        {
            set
            {
                is_FrmEditRunning = value;
            }
            get
            {
                return is_FrmEditRunning;
            }
        }
        public static bool Is_ShowConfig
        {
            set
            {
                is_ShowConfig = value;
            }
            get
            {
                return is_ShowConfig;
            }
        }
        public static SqlConnection sysConnection
        {
            set
            {
                Connection = value;
            }
            get
            {
                return Connection;
            }
        }
        public static SqlConnection sysConnectionUpdate
        {
            set
            {
                Connection = value;
            }
            get
            {
                return Connection;
            }
        }
        public static DateTime sysNgay_Min
        {
            get
            {
                return DateTime.Parse("01/01/1900");
            }
        }

        public static DateTime sysNgay_Max
        {
            get
            {
                return DateTime.Parse("31/12/3000");
            }
        }

        public static int sysWorkingYear
        {
            set
            {
                WorkingYear = value;
            }
            get
            {
                return WorkingYear;
            }
        }
        public static int Reminder_count
        {
            set
            {
                iReminder_count = value;
            }
            get
            {
                return iReminder_count;
            }
        }
        public static string sysDatabaseName
        {
            get
            {
                return sysConnection.Database;
            }
        }

        public static int sysTh_Bd_Ht
        {
            set
            {
                Th_Bd_Ht = value;
            }
            get
            {
                return Th_Bd_Ht;
            }
        }

        public static DateTime sysNgay_Begin
        {

            get
            {
                return DateTime.Parse("01/01/" + WorkingYear);
            }
        }

        public static DateTime sysNgay_End
        {
            get
            {
                return DateTime.Parse("31/12/" + WorkingYear);
            }
        }

        public static string sysUser_Id
        {
            set
            {
                User_Id = value;
            }

            get
            {
                return User_Id;
            }
        }

        public static bool sysIs_Admin
        {
            set
            {
                Is_Admin = value;
            }

            get
            {
                return Is_Admin;
            }
        }

        public static string sysMa_Data
        {
            set
            {
                Ma_Data = value;
            }
            get
            {
                return Ma_Data;
            }

        }

        public static bool sysTong_Hop
        {
            set
            {
                Tong_Hop = value;
            }
            get
            {
                return Tong_Hop;
            }

        }

        public static enuLanguageType sysLanguage
        {
            set
            {
                Language = value;
            }
            get
            {
                return Language;
            }
        }

        public static DateTime sysDateTime_Log
        {
            set
            {
                DateTime_Log = value;
            }
            get
            {
                return DateTime_Log;
            }
        }
        public static DateTime sysNgay_Ct
        {
            set
            {
                Ngay_Ct = value;
            }
            get
            {
                if (Ngay_Ct == null || Ngay_Ct < sysNgay_Min)
                    return DateTime.Today;
                else
                    return Ngay_Ct;
            }
        }
        public static DateTime sysNgay_Ct1
        {
            set
            {
                Ngay_Ct1 = value;
            }
            get
            {
                if (Ngay_Ct1 == null || Ngay_Ct1 < sysNgay_Min)
                    return DateTime.Today;
                else
                    return Ngay_Ct1;
            }
        }

        public static DateTime sysNgay_Ct2
        {
            set
            {
                Ngay_Ct2 = value;
            }
            get
            {
                if (Ngay_Ct2 == null || Ngay_Ct2 < sysNgay_Min)
                    return DateTime.Today;
                else
                    return Ngay_Ct2;
            }
        }

        public static Timer sysTimer
        {
            get { return Timer; }
        }

        public static Form frmCalc
        {
            set
            {
                frmcalc = value;
            }
            get
            {
                return frmcalc;
            }
        }

        public static Form frmSearch
        {
            set
            {
                frmsearch = value;
            }
            get
            {
                return frmsearch;
            }
        }

        public static Form frmMain
        {
            set
            {
                frmmain = value;
            }
            get
            {
                return frmmain;
            }
        }

        public static Form frmActiveMain
        {
            set
            {
                if (value != frmactivemain)
                {
                    Form frmHide = frmactivemain;

                    frmactivemain = value;

                    if (frmactivemain != null)
                    {
                        frmactivemain.WindowState = FormWindowState.Maximized;
                        frmactivemain.ShowInTaskbar = true;

                        if (!frmactivemain.Visible)
                            frmactivemain.Visible = true;

                        frmactivemain.Activate();
                    }

                    if (frmHide != null)
                        frmHide.Hide();
                }
            }
            get
            {
                return frmactivemain;
            }
        }

        public static bool sysRun_Service
        {
            set
            {
                Run_Service = value;
            }
            get
            {
                return Run_Service;
            }
        }


        public static string sysTen_DvCs
        {
            get
            {
                return Core.Ten_Dvcs(sysMa_DvCs);
            }
        }

        public static string sysTen_Dvi
        {
            get { return sysTen_DvCs; }
        }

        public static string sysMa_Tte
        {
            get { return Core.Curency(); }
        }

        public static string sysDia_Chi_Dv
        {
            set
            {
                Dia_Chi_Dv = value;
            }
            get
            {
                return Dia_Chi_Dv;
            }
        }
        public static string sysREPORTPATH
        {
            set
            {
                REPORTPATH = value;
            }
            get
            {
                return REPORTPATH;
            }
        }
        public static string sysConfigFile
        {
            set
            {
                ConfigFile = value;
            }
            get
            {
                return ConfigFile;
            }
        }
        public static string sysConfigFileUpdate
        {
            set
            {
                ConfigFileUpdate = value;
            }
            get
            {
                return ConfigFileUpdate;
            }
        }
        public static object sysActiveReport
        {
            set
            {
                ActiveReport = value;
            }
            get
            {
                return ActiveReport;
            }
        }

        public static bool sysTextToolStrip
        {
            set
            {
                TextToolStrip = value;
            }
            get
            {
                return TextToolStrip;
            }
        }
        public static ImageList sysImageList
        {
            set
            {
                _ImageList = value;
            }
            get
            {
                return _ImageList;
            }
        }
        //public static string sysZaloOfficialID
        //{
        //    set
        //    {
        //        ZaloOfficialID = value;
        //    }
        //    get
        //    {
        //        return ZaloOfficialID;
        //    }
        //}
        //public static string sysZaloCodeID
        //{
        //    set
        //    {
        //        ZaloCodeID = value;
        //    }
        //    get
        //    {
        //        return ZaloCodeID;
        //    }
        //}
        //public static string sysZaloSeccretKey
        //{
        //    set
        //    {
        //        ZaloSeccretKey = value;
        //    }
        //    get
        //    {
        //        return ZaloSeccretKey;
        //    }
        //}
        //public static string sysZaloAccessToken
        //{
        //    set
        //    {
        //        ZaloAccessToken = value;
        //    }
        //    get
        //    {
        //        return ZaloAccessToken;
        //    }
        //}
        //public static string sysLinkInfo
        //{
        //    set
        //    {
        //        LinkInfo = value;
        //    }
        //    get
        //    {
        //        return LinkInfo;
        //    }
        //}
    }
    
}
