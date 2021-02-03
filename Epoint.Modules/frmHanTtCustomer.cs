using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using System.Data.SqlClient;

namespace Epoint.Modules
{
    public partial class frmHanTtCustomer : Epoint.Systems.Customizes.frmView
    {
        //DataTable dtThanhToan;
        DataTable dtCtHanTt;

        //BindingSource bdsThanhToan = new BindingSource();
        BindingSource bdsHanTt = new BindingSource();

        frmVoucher_Edit frmEditCt;
        frmHanTt_Filter frmFilter = new frmHanTt_Filter();
        string strStt = string.Empty;
        string strStt_Pt = string.Empty;
        string strSo_Ct_New = string.Empty;


        DateTime dtNgay_Ct = DateTime.MinValue;
        DateTime dtNgay_Ct_Hd = DateTime.Now;
        #region Contructor

        public frmHanTtCustomer()
        {
            InitializeComponent();


            this.dgvHanTt0.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvHanTt0_CellMouseClick);
            this.dgvHanTt0.CellBeginEdit += new DataGridViewCellCancelEventHandler(dgvHanTt0_CellBeginEdit);
            this.dgvHanTt0.CellEndEdit += new DataGridViewCellEventHandler(dgvHanTt0_CellEndEdit);
            this.dgvHanTt0.GotFocus += new EventHandler(dgvHanTt0_GotFocus);

            this.btSave.Click += new EventHandler(btSave_Click);
            this.btPreview.Click += new EventHandler(btPreview_Click);
            this.btThanhToan_Auto.Click += new EventHandler(btThanhToan_Auto_Click);
            this.btThanhtoan.Click += new EventHandler(btThanhtoan_Click);

        }



        new public void Load()
        {
            Build();

            BindingLanguage();

            if (this.frmEditCt == null)
                this.Show();
            else
                this.ShowDialog();
        }

        public void Load(DateTime dtNgay_Ct, string strTk, string strMa_Dt, string strStt, string strMa_Ct)
        {
            this.strStt = strStt;
            this.txtTk.Text = strTk;
            this.txtMa_Dt.Text = strMa_Dt;
            this.Load();
        }

        #endregion

        #region Method

        private void Build()
        {
            dgvHanTt0.ReadOnly = false;
            dgvHanTt0.strZone = "HANTT00";
            dgvHanTt0.BuildGridView();

            
            foreach (DataGridViewColumn dgvc in dgvHanTt0.Columns)
            {
                if (dgvc.Name == "TIEN_TT1" || dgvc.Name == "TIEN_TT_NT1" || dgvc.Name == "THANH_TOAN")
                    dgvc.ReadOnly = false;
                else
                    dgvc.ReadOnly = true;
            }

            dteNgay_Ct_TT.Text = Library.DateToStr(DateTime.Now);
            dteNgay_Ct1.Text = Library.DateToStr(DateTime.Now);
            dteNgay_Ct2.Text = Library.DateToStr(DateTime.Now);

        }
        private void FillHanTt()
        {
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("NGAY_CT1", Library.StrToDate(dteNgay_Ct1.Text));
            htSQLPara.Add("NGAY_CT2", Library.StrToDate(dteNgay_Ct2.Text));
            htSQLPara.Add("TK", "1311");
            htSQLPara.Add("MA_DT", txtMa_Dt.Text);
            htSQLPara.Add("MA_CBNV_BH", txtMa_CbNV_BH.Text);
            htSQLPara.Add("MA_CBNV_GH", txtMa_CbNV_GH.Text);
            htSQLPara.Add("STT_PT", "");
            htSQLPara.Add("MA_DVCS", Element.sysMa_DvCs);
            this.dtCtHanTt = SQLExec.ExecuteReturnDt("[sp_AR_GetHanTt]", htSQLPara, CommandType.StoredProcedure);
            if (!this.dtCtHanTt.Columns.Contains("Modify"))
            {
                this.dtCtHanTt.Columns.Add(new DataColumn("Modify", typeof(bool)));
                this.dtCtHanTt.Columns["Modify"].DefaultValue = false;
            }
            this.bdsHanTt.DataSource = this.dtCtHanTt;
            this.dgvHanTt0.DataSource = this.bdsHanTt;

            this.Tinh_Tong();

        }

        private void SaveToHanTt(string strTk, string strMa_Dt, double dbTien_Tt, double dbTien_Tt_Nt, string strNo_Co, bool bIs_UngTruoc)
        {

        }


        private void Auto_Ticked()
        {
            DataRow row = ((DataRowView)this.bdsHanTt.Current).Row;
            DataGridViewCell currentCell = this.dgvHanTt0.CurrentCell;
            string strExpr = currentCell.OwningColumn.Name.ToUpper();
            if (!currentCell.ReadOnly && Common.Inlist(strExpr, "THANH_TOAN"))
            {

                bool bThanhToan = !((bool)currentCell.EditedFormattedValue);
                if (bThanhToan)
                {
                    double dbTien_Tt_Allow;
                    double dbTien_Tt_Nt_Allow;
                    double dbTien_Tt1;
                    double dbTien_Tt_Nt1;
                    double dbTien_PT = 0, dbTien_PT_Nt = 0;

                    double dbTien_No1 = Convert.ToDouble(row["Tien_No1"]);
                    double dbTien_No_Nt1 = Convert.ToDouble(row["Tien_No_Nt1"]);
                    double dbTy_Gia_Hd = Convert.ToDouble(row["Ty_Gia_HD"]);
                    double dbTTien_Tt1 = Common.SumDCValue(this.dtCtHanTt, "Tien_Tt1", "");
                    double dbTTien_Tt_Nt1 = Common.SumDCValue(this.dtCtHanTt, "Tien_Tt_Nt1", "");

                    dbTien_Tt1 = dbTien_No1;
                    dbTien_Tt_Nt1 = dbTien_No_Nt1;

                    if (!((Math.Abs(dbTien_Tt1) + Math.Abs(dbTien_Tt_Nt1)) == 0.0))
                    {
                        row["Tien_Tt1"] = dbTien_Tt1;
                        row["Tien_Tt_Nt1"] = dbTien_Tt_Nt1;
                        row["Ngay_Ct_TT"] = dteNgay_Ct_TT.Text;
                        row["Stt_PT"] = strStt_Pt;
                        row["LastModify_Log"] = Common.GetCurrent_Log();
                        row["Thanh_Toan"] = bThanhToan;
                        row["Modify"] = true;
                        this.btSave.Enabled = true;
                    }
                }
                else
                {
                    row["Tien_Tt1"] = 0;
                    row["Tien_Tt_Nt1"] = 0;
                    row["Ngay_Ct_TT"] = Element.sysNgay_Min;
                    row["LastModify_Log"] = string.Empty;
                    row["Thanh_Toan"] = bThanhToan;
                    row["Modify"] = true;
                    this.btSave.Enabled = true;
                }

                row.AcceptChanges();
                this.dgvHanTt0.EndEdit();
                this.Tinh_Tong();
            }
        }


        private void Save_HanTt0(string Stt_PT)
        {
            DataRow rowCtThanhtoan;
            //DataRow CurrRow = ((DataRowView)this.bdsThanhToan.Current).Row;
            //double dbTien_PT = Convert.ToDouble(CurrRow["Tien_PT"]);
            //double dbTien_Pt_Nt = Convert.ToDouble(CurrRow["Tien_PT_Nt"]);

            if (true)
            {

                DataTable dtTableSource = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Thanh_Toan FROM GLTHANHTOANCT WHERE 0 = 1");
                foreach (DataRow row2 in this.dtCtHanTt.Select(this.bdsHanTt.Filter))
                {
                    rowCtThanhtoan = dtTableSource.NewRow();
                    Common.CopyDataRow(row2, rowCtThanhtoan);

                    if ((rowCtThanhtoan["Ngay_Ct_TT"] == DBNull.Value) && (((DateTime)rowCtThanhtoan["Ngay_Ct_TT"]) == Element.sysNgay_Min))
                    {
                        rowCtThanhtoan["Ngay_Ct_TT"] = Library.StrToDate(this.dteNgay_Ct_TT.Text);
                    }
                    rowCtThanhtoan["Stt_PT"] = Stt_PT;
                    rowCtThanhtoan["Tk"] = row2["Tk"];
                    rowCtThanhtoan["Ma_Dt"] = row2["Ma_Dt"];
                    rowCtThanhtoan["Stt_HD"] = row2["Stt_HD"];
                    rowCtThanhtoan["Tien_Tt"] = row2["Tien_Tt1"];
                    rowCtThanhtoan["Tien_Tt_Nt"] = row2["Tien_Tt_Nt1"];
                    rowCtThanhtoan["Tien_CLTG"] = row2["Tien_CLTG"];
                    rowCtThanhtoan["LastModify_Log"] = row2["LastModify_Log"];
                    dtTableSource.Rows.Add(rowCtThanhtoan);
                }
                dtTableSource.AcceptChanges();
                SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                command.CommandText = "Sp_Update_CtHanTt";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Stt", "");
                command.Parameters.AddWithValue("@Ma_Ct", "PT");
                command.Parameters.AddWithValue("@Tk", "1311");
                command.Parameters.AddWithValue("@Ma_Dt", "");
                command.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
                SqlParameter parameter = new SqlParameter
                {
                    SqlDbType = SqlDbType.Structured,
                    ParameterName = "@CtHanTt",
                    TypeName = "TVP_CtHanTt",
                    Value = Voucher.GetTVPValue("GLTHANHTOANCT", "TVP_CtHanTt", dtTableSource)
                };
                command.Parameters.Add(parameter);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    command.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Có lỗi xảy ra :" + exception.Message);
                }
                this.btSave.Enabled = false;
            }
        }


        private void Tinh_Tong()
        {
            this.numTTien_Tt.Value = Common.SumDCValue(dtCtHanTt, "Tien_Tt1", "");
            this.numTTien_Tt_Nt.Value = Common.SumDCValue(dtCtHanTt, "Tien_Tt_Nt1", "");
        }

        #endregion

        #region Event

        void dgvHanTt0_GotFocus(object sender, EventArgs e)
        {
            this.ExportControl = dgvHanTt0;
            this.bdsSearch = bdsHanTt;
        }

        void dgvHanTt_GotFocus(object sender, EventArgs e)
        {

        }

        
        void dgvHanTt0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Auto_Ticked();
        }

        void dgvHanTt0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "TIEN_TT1,TIEN_TT_NT1"))
            {
                DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;

                //Không cho người này được sửa thanh toán của người khác
                if (!Element.sysIs_Admin)
                {
                    string strUser = (string)drHanTt0["LastModify_Log"];
                    if (strUser.Length > 0)
                        strUser = strUser.Substring(14);

                    if (strUser != string.Empty && strUser != Element.sysUser_Id)
                    {
                        Common.MsgCancel("Không được sửa dữ liệu do " + strUser + " đã thanh toán!");
                        this.btSave.Enabled = false;
                        e.Cancel = true;

                        return;
                    }
                }

                this.btSave.Enabled = true;
            }
        }

        void dgvHanTt0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell dgvCell = dgvHanTt0.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "TIEN_TT1,TIEN_TT_NT1"))
            {
                DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;
                drHanTt0["Modify"] = true;

                this.Tinh_Tong();
            }
        }

        void btSave_Click(object sender, EventArgs e)
        {
            //this.Save_HanTt0();
            //if (((this.frmEditCt != null)) && ((this.frmEditCt != null) && this.frmEditCt.Controls.ContainsKey("dteNgay_Ct")))
            //{
            //    this.frmEditCt.Controls["dteNgay_Ct"].Text = this.dteNgay_Ct1.Text;
            //}
            //if ((this.dtThanhToan.Rows.Count == 1) && (this.frmEditCt != null))
            //{
            //    base.Close();
            //}

        }

        private string Tao_Pt()
        {
            int Stt0 = 0;
            string strSo_Ct = string.Empty;
            string strSo_Ct_New = string.Empty;
            string strCreate_Log = string.Empty;
            string strQueryCthd = string.Empty;
            string iStt = string.Empty;

            try
            {

                #region GetNew_SoCt


                DataRow drDmct = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", "PT");
                DataRow dr = SQLExec.ExecuteReturnDt("SELECT Ma_DvCs FROM SYSDMDVCS WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' ").Rows[0];
                DateTime dteNgay_Ct_tt = Library.StrToDate(dteNgay_Ct_TT.Text);
                string strSQLExec = "SELECT So_Ct FROM GLVOUCHER WHERE Ma_DvCs = '" + Element.sysMa_DvCs
                    + "' AND Ma_Ct = 'PT' AND MONTH(Ngay_Ct) =" + dteNgay_Ct_tt.Month.ToString()
                    + " AND YEAR(Ngay_Ct) =" + dteNgay_Ct_tt.Year.ToString() + " AND So_Ct <> '' ";
                //+ " AND DAY(Ngay_Ct) =" + dteNgay_Ct1.Day.ToString() 

                DataTable dt = SQLExec.ExecuteReturnDt(strSQLExec);
                if (dt.Rows.Count > 0)
                {
                    string strSQL = "SELECT ISNULL(MAX(So_Ct),'') FROM GLVOUCHER WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = 'PT' AND MONTH(Ngay_Ct) =" + dteNgay_Ct_tt.Month.ToString() + " AND YEAR(Ngay_Ct) =" + dteNgay_Ct_tt.Year.ToString() + "";
                    strSo_Ct = SQLExec.ExecuteReturnValue(strSQL).ToString();
                    Hashtable htPara = new Hashtable();
                    htPara.Add("TABLENAME", "GLVOUCHER");
                    htPara.Add("COLUMNNAME", "So_Ct");
                    htPara.Add("CURRENTID", strSo_Ct);
                    htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = 'PT' AND MONTH(Ngay_Ct) = " + dteNgay_Ct_tt.Month + " AND YEAR(Ngay_Ct) = " + dteNgay_Ct_tt.Year + "");
                    htPara.Add("PREFIXLEN", Convert.ToInt32(drDmct["PrefixLen"]));
                    htPara.Add("SUFFIXLEN", Convert.ToInt32(drDmct["SubfixLen"]));

                    strSo_Ct_New = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                    //strSo_Ct_New = drDmct["Prefix"].ToString() + dteNgay_Ct_tt.Month.ToString("00") + dteNgay_Ct_tt.Day.ToString("00") + strSo_Ct_New.Substring(strSo_Ct_New.Length - 4, 4);
                }
                else
                    strSo_Ct_New = drDmct["Prefix"].ToString() + dteNgay_Ct_tt.Month.ToString("00") + dteNgay_Ct_tt.Day.ToString("00") + "0001";


                #endregion

                strCreate_Log = Common.GetCurrent_Log();



                bool bSttValid = false;

                while (!bSttValid)
                {
                    iStt = Common.GetNewStt("01", true);
                    string strPH = @"SELECT * FROM GLVOUCHER WHERE Stt= '" + iStt + "'";
                    DataTable dtCtph = SQLExec.ExecuteReturnDt(strPH);
                    if (dtCtph.Rows.Count > 0)
                    {
                        bSttValid = false;
                    }
                    else
                        bSttValid = true;

                }

                double dbTien0 = Convert.ToDouble(numTTien_Tt.Value);
                double dbTien3 = 0;
                //double dbTTien = dbTien0 + dbTien3;
                double dbThue = 0;
                string strQueryPh = @"
            						INSERT INTO	GLVOUCHER (Stt, Ma_Ct, Ngay_Ct, So_Ct, Ma_Dt, Dien_giai, TTien0, TTien_Nt0, TTien3, TTien_Nt3, Create_Log, Ct_Di_Kem,Is_ThanhToan, Ma_Dvcs)
            							VALUES('" + iStt + "', 'PT', '" + Library.DateToStr(dteNgay_Ct_tt) + "', '" + strSo_Ct_New + "', '"
                                      + txtMa_Dt.Text + "', N'" + txtDien_Giai.Text + "', " + dbTien0 + ", " + dbTien0 + ", " + dbTien3 + ", " + dbTien3 + ", '"
                                       + strCreate_Log + "', '',1, '" + Element.sysMa_DvCs + "')";





                foreach (DataRow drhd in dtCtHanTt.Rows)
                {

                    if ((bool)drhd["Thanh_Toan"])
                    {
                        Stt0 += 1;
                        DataRow drDt = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", drhd["Ma_Dt"].ToString());

                        strQueryCthd += @"INSERT INTO	CATIEN (Stt, Stt0, Ma_Ct, Ngay_Ct, So_Ct, Dien_Giai, Ong_Ba, Ma_Dt,Dia_Chi,
                        											Tk_No, Tk_Co, Tien_Nt9, Tien, Tien_Nt, 
                                                                    Ma_Thue, Thue_GtGt, Tien3, Tien_Nt3, Tk_No3, Tk_Co3, Ngay_Ct0, So_Ct0, So_Seri0, Ma_So_Thue, Ten_DtGtGt,
            														Ma_Dvcs, Ma_Tte, Ty_Gia)
                        							VALUES('" + iStt + "', '" + Stt0 + "', 'PT', '" + dteNgay_Ct_TT.Text + "','" + strSo_Ct_New + "', N'"
                                              + txtDien_Giai.Text + "',  N'" + drDt["Ong_Ba"] + "', '" + drhd["Ma_Dt"] + "',N'" + drDt["Dia_Chi"] + "','"
                                              + txtTk_Tt.Text + "','" + drhd["Tk"] + "', " + drhd["Tien_Tt1"] + ",  " + drhd["Tien_Tt1"] + ",  " + drhd["Tien_Tt1"]
                                              + ", '', 0, 0, 0, '', '', '', '', '', '', N'', '" + Element.sysMa_DvCs + "','VND', 1)\n";


                    }
                }
                if (numTTien_Tt.Value > 0)
                {
                    SQLExec.Execute(strQueryPh);
                    SQLExec.Execute(strQueryCthd);

                    Common.MsgOk("Chứng từ đã tạo xong Số chứng từ : " + strSo_Ct_New);
                    this.strStt_Pt = iStt;
                    this.strSo_Ct_New = strSo_Ct_New;
                    return iStt;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.ToString());
                return string.Empty;
                // throw;
            }

        }

        void btThanhToan_Auto_Click(object sender, EventArgs e)
        {

        }

        void btThanhtoan_Click(object sender, EventArgs e)
        {
            if (numTTien_Tt.Value == 0)
            {
                EpointMessage.MsgOk("Chưa chọn các chứng từ thanh toán");
                return;
            }

            if (txtDien_Giai.Text == string.Empty)
            {
                EpointMessage.MsgOk("Nhập diễn giải cho chứng từ thanh toán");
                return;
            }
            string strSttPT = Tao_Pt();
            if (strSttPT != string.Empty)
            {
                Save_HanTt0(strSttPT);
            }


            this.FillHanTt();
        }
        void btPreview_Click(object sender, EventArgs e)
        {
            this.FillHanTt();
        }

        #endregion
    }
}
