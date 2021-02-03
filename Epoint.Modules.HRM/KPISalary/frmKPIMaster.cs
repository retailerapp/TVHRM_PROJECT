using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using System.Collections;
using System.Data.SqlClient;
using Epoint.Systems.Elements;

namespace Epoint.Modules.KPI
{
    public partial class frmKPIMaster : Epoint.Systems.Customizes.frmView
    {

        string strKPIID = String.Empty;
        string strStt = String.Empty;
        DataTable dtImport;
        string strError = string.Empty;


        DataSet dsKPI;

        DataTable dtKPIHeader;
        BindingSource bdsKPIHeader = new BindingSource();
        DataRow drCurrentKPIHeader;

        DataTable dtKPIDetail;
        BindingSource bdsKPIDetail = new BindingSource();
        DataRow drCurrentKPIDetail;

        public frmKPIMaster()
        {
            InitializeComponent();

            bdsKPIHeader.PositionChanged += new EventHandler(bdsDiscountProg_PositionChanged);
            this.btFillterData.Click += new EventHandler(btFillData_Click);
            this.btImport.Click += new EventHandler(btImport_Click);
        }



        public override void Load()
        {
            this.Build();
            this.FillData();

            this.Show();
        }

        private void Build()
        {
            dgvKPIHeader.strZone = "KPIHEADER";
            dgvKPIHeader.BuildGridView(this.isLookup);
            ExportControl = dtKPIHeader;         


            dgvKPIDetail.strZone = "KPIDETAIL";
            dgvKPIDetail.BuildGridView(this.isLookup);
            ExportControl = dtKPIDetail;
            

            dteNgay_BD.Text =Library.DateToStr( Epoint.Systems.Elements.Element.sysNgay_Ct1);
            dteNgay_Kt.Text = Library.DateToStr(Epoint.Systems.Elements.Element.sysNgay_Ct2);

            tabKPI.HideAllTabPage();
            tabKPI.ShowPageInTabControl(tpDetail);
           
        }

        private void FillData()
        {

            Hashtable htPara = new Hashtable();
            htPara["FROMDATE"] = dteNgay_BD.Text;
            htPara["TODATE"] = dteNgay_Kt.Text;

            dsKPI = SQLExec.ExecuteReturnDs("Sp_KPI_Getdata", htPara, CommandType.StoredProcedure);

            dtKPIHeader = dsKPI.Tables[0];
            bdsKPIHeader.DataSource = dtKPIHeader;
            dgvKPIHeader.DataSource = bdsKPIHeader;

            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsKPIHeader;
            ExportControl = dgvKPIHeader;

            if (bdsKPIHeader.Count >= 0)
                bdsKPIHeader.Position = 0;

            // Điêu kiện khuyến mãi

            dtKPIDetail = dsKPI.Tables[1];
            bdsKPIDetail.DataSource = dtKPIDetail;
            dgvKPIDetail.DataSource = bdsKPIDetail;
        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (dgvKPIHeader.Focused)
                EditKPIHeader(enuNew_Edit);           
        }
        private void EditKPIHeader(enuEdit enuNew_Edit)
        {
            if (bdsKPIHeader.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsKPIHeader.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsKPIHeader.Current).Row, ref drCurrentKPIHeader);
            else
                drCurrentKPIHeader = dtKPIHeader.NewRow();

            frmKPIMaster_Edit frmEdit = new frmKPIMaster_Edit();
            frmEdit.Object_ID = this.Object_ID;
            frmEdit.Load(enuNew_Edit, drCurrentKPIHeader);

            ////Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                {
                    if (bdsKPIHeader.Position >= 0)
                        dtKPIHeader.ImportRow(drCurrentKPIHeader);
                    else
                        dtKPIHeader.Rows.Add(drCurrentKPIHeader);
                    bdsKPIHeader.Position = bdsKPIHeader.Find("KPIID", drCurrentKPIHeader["KPIID"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrentKPIHeader, ((DataRowView)bdsKPIHeader.Current).Row);
                }

                dtKPIHeader.AcceptChanges();
            }
            else
                    dtKPIHeader.RejectChanges();

            }
      
        public override void Delete()
        {
            if (dgvKPIHeader.Focused)
                DeleteKPIHeader();
                  
            else if (dgvKPIDetail.Focused)
                DeleteKPIDeail();
        }


        private void DeleteKPIHeader()
        {
            if (bdsKPIHeader.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsKPIHeader.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;


            Hashtable htPara = new Hashtable();
            htPara["KPIID"] = drCurrent["KPIID"].ToString();
            bool isCheck = Convert.ToBoolean(SQLExec.ExecuteReturnValue("sp_KPI_DeleteKPIMaster", htPara, CommandType.StoredProcedure));
            if (isCheck)
            {
                bdsKPIHeader.RemoveAt(bdsKPIHeader.Position);
                dtKPIHeader.AcceptChanges();
            }
            else
            {
                EpointMessage.MsgOk("KPI Đã được approve theo bảng lương.");
            }
        }       
        private void DeleteKPIDeail()
        {

        }
     
        #region Sự kiện

        void bdsDiscountProg_PositionChanged(object sender, EventArgs e)
        {           
            if (bdsKPIHeader.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsKPIHeader.Current).Row, ref drCurrentKPIHeader);

            this.strKPIID = drCurrentKPIHeader["KPIID"].ToString();
            bdsKPIDetail.Filter = "KPIID = '" + strKPIID + "'";
        }
        void btFillData_Click(object sender, EventArgs e)
        {
            FillData();
        }
       

        void Setdefault(ref DataTable dtExcel)
        {          
            //foreach (DataRow drEx in dtExcel.Rows)
            //{
            //    double dbFromTien = 0, dbToTien = 0, dbTien_Ck = 0, dbCk = 0;
            //    if (dtExcel.Columns.Contains("Tu_So_Tien") && !double.TryParse(drEx["Tu_So_Tien"].ToString(), out dbFromTien))
            //    {
            //        drEx["Tu_So_Tien"] = 0;
            //    }

            //    if (dtExcel.Columns.Contains("Den_So_Tien") && !double.TryParse(drEx["Den_So_Tien"].ToString(), out dbToTien))
            //    {
            //        drEx["Den_So_Tien"] = 0;
            //    }
            //    if (dtExcel.Columns.Contains("Tien_Ck") && !double.TryParse(drEx["Tien_Ck"].ToString(), out dbTien_Ck))
            //    {
            //        drEx["Tien_Ck"] = 0;
            //    }
            //    if (dtExcel.Columns.Contains("Ck") && !double.TryParse(drEx["Ck"].ToString(), out dbCk))
            //    {
            //        drEx["Ck"] = 0;
            //    }
            //    //Convert.
            //    drEx.AcceptChanges();
            //}
        }
        void CopyDataToTable(ref DataTable dtImport, DataTable dtExcel)
        {
            foreach (DataRow drExcel in dtExcel.Rows)
            {
                if (drExcel["KPIID"].ToString() != string.Empty)
                {
                    DataRow drImport = dtImport.NewRow();
                    drImport["KPIID"] = drExcel["KPIID"];
                    drImport["ObjectID"] = drExcel["SlsperID"];
                    drImport["VendorCode"] = "";
                    drImport["Descr"] = drExcel["Descr"];
                    drImport["Type"] = drExcel["Type"];
                    drImport["ItemID"] = drExcel["ItemID"];
                    drImport["ItemSize"] = drExcel["SIZE"];
                    drImport["Qty"] = drExcel["Qty"];
                    drImport["Amt"] = drExcel["Amt"];
                    drImport["ApplyFor"] = drExcel["ApplyFor"];
                    drImport["StartDate"] = drExcel["FromDate"];
                    drImport["EndDate"] = drExcel["ToDate"];
                    drImport["Workdays"] = drExcel["WorkDate"];
                    dtImport.Rows.Add(drImport);
                }

            }
        }
        void btImport_Click(object sender, EventArgs e)
        {
            strError = string.Empty;

            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
            ofdlg.RestoreDirectory = true;
            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;

            DataTable dtExcel = new DataTable();
            dtImport = SQLExec.ExecuteReturnDt("DECLARE @KPICAMPAIGN AS TVP_KPICAMPAIGN SELECT * FROM @KPICAMPAIGN");
            dtExcel = Common.ReadExcel(ofdlg.FileName);
            Setdefault(ref dtExcel);
            CopyDataToTable(ref dtImport, dtExcel);
            
            
            EpointProcessBox.Show(this);    
        }
        public virtual void Import_Excel(bool CheckAPI)
        {
            //string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên mẫu tin đã tồn tại không ?" : "Do you want to override exists data ?");
            bool Is_Avail = true;
            if (true)
            {
                SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                command.CommandText = "Sp_IF_KPICampaign";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", Element.sysUser_Id);
                command.Parameters.AddWithValue("@Is_OverWrite", chkIsOverride.Checked);
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.Structured,
                    ParameterName = "@KPICAMPAIGN",
                    TypeName = "TVP_KPICAMPAIGN",
                    Value = dtImport
                };
                command.Parameters.Add(parameter);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Is_Avail = false;
                    command.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
                   EpointProcessBox.AddMessage("Có lỗi xảy ra :" + exception.Message);
                }

            }
            //return;
            if (!Is_Avail)
                return;

            EpointProcessBox.AddMessage("Kết thúc");
        }

        
        public override void EpointRelease()
        {

            Import_Excel(true);
        
        }

        #endregion
    }
}
