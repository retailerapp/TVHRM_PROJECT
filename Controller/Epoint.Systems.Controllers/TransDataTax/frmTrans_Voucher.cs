using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using System.Collections;

namespace Epoint.Controllers
{
    public partial class frmTrans_Voucher : Epoint.Systems.Customizes.frmView
    {
        string strMa_Ct;
        public frmTrans_Voucher()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);
            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            btMa_Ct.Click += new EventHandler(btMa_Ct_Click);
            chkAll.Click += new EventHandler(chkAll_Click);
        }



        void chkAll_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                //txtMa_Ct_List.Enabled = false;
                //txtMa_Ct_List.Text = "ALL";
            }
            else
            {
                //txtMa_Ct_List.Enabled = true;
                //txtMa_Ct_List.Text = "";
            }
        }

        new public void Load()
        {

            //txtMa_Ct_List.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            this.txtNgay_Ct1.Text = Element.sysNgay_Ct1.ToString();
            this.txtNgay_Ct2.Text = Element.sysNgay_Ct2.ToString();

            this.BindingLanguage();
            this.Show();
        }
        public override void EpointRelease()
        {
            //string strServerSource = Parameters.GetParaValue("SERVER_SOURCE").ToString();
            //Object strDBSource = Parameters.GetParaValue("DATABASE_SOURCE");
            string strDBSource = Element.sysDatabaseName.ToString();
            //string strServerDest = Parameters.GetParaValue("SERVER_DEST").ToString();
            //Object strDBSource = Element.sysDatabaseName;
            string strDBDest = Parameters.GetParaValue("DATABASE_DEST").ToString();

            DateTime dteNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
            DateTime dteNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);
            string strMa_Ct_List = txtMa_Ct.Text;

            if (!Common.CheckDataLocked(dteNgay_Ct1) || !Common.CheckDataLocked(dteNgay_Ct2))
            {
                //Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị !");
                EpointProcessBox.AddMessage("Dữ liệu đã khóa, liên hệ với nhà quản trị !");
                return;
            }
            Hashtable ht = new Hashtable();
            //ht["SERVERSOURCE"] = strServerSource;
            //ht["SERVERDEST"] = strServerDest;
            ht["NGAY_CT1"] = dteNgay_Ct1;
            ht["NGAY_CT2"] = dteNgay_Ct2;
            ht["DBSOURCE"] = strDBSource;
            ht["DBDEST"] = strDBDest;
            ht["NAM"] = Element.sysWorkingYear;
            ht["MA_CT_LIST"] = strMa_Ct_List;
            ht["MA_DVCS"] = Element.sysMa_DvCs.ToString();

            try
            {
                Common.ShowStatus(Languages.GetLanguage("In_Process"));
                if (chkAll.Checked)
                {
                    EpointProcessBox.AddMessage("Đang chuyển số liệu chứng từ ");
                    SQLExec.Execute("sp_DuyetCt", ht, CommandType.StoredProcedure);
                }
                if (chkDanhMuc.Checked)
                {
                    EpointProcessBox.AddMessage("Đang chuyển danh mục ");
                    SQLExec.Execute("sp_Tranfer_DanhMuc", ht, CommandType.StoredProcedure);
                }
                if (chkDuDau.Checked)
                {
                    EpointProcessBox.AddMessage("Đang chuyển số dư đầu  ");
                    SQLExec.Execute("sp_Tranfer_DuDau", ht, CommandType.StoredProcedure);
                }
                if (chkTaiSan.Checked)
                {
                    EpointProcessBox.AddMessage("Đang chuyển chứng từ tài sản ");
                    SQLExec.Execute("sp_Tranfer_TaiSan", ht, CommandType.StoredProcedure);
                }
                //lock (this)
                //{
                //    if (chkDanhMuc.Checked)
                //    {
                //        string[] strArrPara = new string[] { "@ServerSource", "@ServerDest", "@DBSource", "@DBDest", "@Ma_DvCs" };
                //        object[] objArrPara = new object[] { strServerSource, strServerDest, strDBSource, strDBDest, Element.sysMa_DvCs };
                //        SQLExec.Execute("sp_Tranfer_DanhMuc", strArrPara, objArrPara, CommandType.StoredProcedure);
                //    }

                //}
                Element.sysNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
                Element.sysNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);
                EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
                //EpointMessage.MsgOk(Languages.GetLanguage("End_Process"));
                //Common.EndShowStatus();
            }
            catch (Exception)
            {
                //Common.MsgOk("Không tìm thấy Database cần chuyển đến !");
                EpointProcessBox.AddMessage("Không tìm thấy Database cần chuyển đến !");
            }
        }
        void btOk_Click(object sender, EventArgs e)
        {

            EpointProcessBox.Show(this);
            //this.Close();            
            Common.CloseCurrentForm();
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Common.CloseCurrentForm();
        }
        void txtMa_Ct_Validating(object sender, CancelEventArgs e)
        {

        }
        void btMa_Ct_Click(object sender, EventArgs e)
        {
            string strValue = txtMa_Ct.Text.Trim();
            bool bRequire = false;

            //frmQuickLookup frmLookup = new frmQuickLookup("SYSDMCT", "DMCT", true);
            //DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSDMCT", "Ma_Ct", "", true, "");
            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Ct", "", true, "", "");
            if (drLookup == null)
                txtMa_Ct.Text = string.Empty;
            else
            {
                txtMa_Ct.Text = drLookup["MuiltiSelectValue"].ToString();
            }
        }
    }
}
