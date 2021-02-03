using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using System.Collections;
using System.Data.SqlClient;
using Epoint.Controller;

namespace Epoint.Controllers
{
    public partial class frmChiPhiThang : Epoint.Systems.Customizes.frmView
    {
        string strMa_Ct;
        private static float viewDoanhThuHeight = 0f;
        private static float viewDoanhThuWidth = 0f;
        private static rptChiPhiThang rptDoanhThu = new rptChiPhiThang();

        public frmChiPhiThang()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);
        }

        
       

        new public void Load()
        {
            this.BindingLanguage();
            rptDoanhThu = new rptChiPhiThang();
            this.viewDoanhThu.HorizontalScroll.Visible = false;
            this.viewDoanhThu.VerticalScroll.Visible = false;
            this.viewDoanhThu.Document = rptDoanhThu.Document;
            LoadDoanhThu();
            this.Show();
        }
        private static void LoadDoanhThu()
        {
            DataTable dtDoanhThu;
            SqlConnection newSQLConnection = SQLExec.GetNewSQLConnection();
            SqlCommand selectCommand = new SqlCommand
            {
                Connection = newSQLConnection
            };
            DateTime time = Library.StrToDate("01/01/" + DateTime.Now.Year);
            DateTime now = DateTime.Now;
            selectCommand.CommandText = string.Concat(new object[] { "SET DATEFORMAT DMY EXEC sp_rptDKTHANG01 '01/01/", DateTime.Now.Year, "','", now.Day, "/", now.Month, "/", now.Year, "', 1, 'V', ", Element.sysMa_DvCs });
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
    }
}
