using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Text;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;
using System.IO;
using System.Data.OleDb;
namespace Epoint.Modules
{
    public class VoucherSync1
    {   
        //SQLUpdateCt
        public static bool SQLUpdateCt(frmVoucher_Edit frmEditCt)
        {
            string sSYNC_MA_DVCS = Convert.ToString(Parameters.GetParaValue("SYNC_MA_DVCS"));

            SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                        
            SqlCommand sqlCom = sqlCon.CreateCommand();

            SqlTransaction sqlTran = sqlCom.Connection.BeginTransaction("Update_Voucher_Tran");

            sqlCom.Transaction = sqlTran;

            DataRow drEditPhSync = frmEditCt.drEditPh;
            DataTable dtEditCtSync = frmEditCt.dtEditCt;

            string strKey = string.Empty;
            string strTable_Ph = (string)frmEditCt.drDmCt["Table_Ph"];
            string sp_UpdatePh = (string)frmEditCt.drDmCt["sp_UpdatePh"];
            string strStt = (string)drEditPhSync["Stt"];
            string strMa_Ct = (string)drEditPhSync["Ma_Ct"];

            //Chuyển đổi Ma_Dvcs-------------
            drEditPhSync["Ma_DvCs"] = sSYNC_MA_DVCS;
            foreach (DataRow drEditCt in dtEditCtSync.Rows)
            {
                drEditCt["Ma_DvCs"] = sSYNC_MA_DVCS;
            }
            dtEditCtSync.AcceptChanges();
            //-----------------

            #region UpdatePh
            if (drEditPhSync != null)
            {//Có nhiều trường hợp cập nhật CT mà không cần cập nhật PH(VD: frmEditLR)

                sqlCom.CommandText = sp_UpdatePh;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.Parameters.Clear();

                strKey = "Object_id = Object_id('" + sp_UpdatePh + "')";
                DataTable dtUpdatePh_Para = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

                sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)frmEditCt.enuNew_Edit);
                Common.SetDefaultDataRow(ref drEditPhSync);

                foreach (DataRow drPara in dtUpdatePh_Para.Rows)
                {
                    string strColumnName = ((string)drPara["Name"]).Replace("@", "");

                    if (!drEditPhSync.Table.Columns.Contains(strColumnName))
                        continue;

                    sqlCom.Parameters.AddWithValue("@" + strColumnName, drEditPhSync[strColumnName]);
                }

                try
                {
                    sqlCom.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlTran.Rollback();
                    return false;
                }
            }
            #endregion

            #region UpdateCt
            if (!UpdateCt(frmEditCt, sqlCom, dtEditCtSync))
                return false;

            //UpdateCtLR
            if (Common.Inlist(frmEditCt.strMa_Ct, "LR,TR"))
            {
                if (!UpdateCt(frmEditCt, sqlCom, ((IEditCtLR)frmEditCt).dtEdiCtLR, "sp_UpdateIN_LR", "INLAPRAP"))
                    return false;
            }

            #endregion

            #region UpdateLSX
            if (frmEditCt.dtCtVt != null)
                if (!UpdateCtSX(frmEditCt, sqlCom, frmEditCt.dtCtVt))
                    return false;
            #endregion
            //#region UpdateQueue

            //if (!Voucher.UpdateQueue(sqlCom, drEditPhSync))
            //    return false;

            //#endregion

            #region UpdateHanTt0
            if (!UpdateHanTt(frmEditCt, sqlCom))
                return false;
            #endregion

            #region History
            if (frmEditCt.enuNew_Edit == enuEdit.Edit)
                if (!History(frmEditCt, sqlCom))
                    return false;
            #endregion

            //Luu So_Ct
            string strLoai_Ma_Ct = ((DateTime)drEditPhSync["Ngay_Ct"]).Month.ToString().Trim();
            string[] strParaName = new string[] { "Ma_Ct", "Loai_Ma_Ct", "Ngay_Ct", "So_Ct" };
            object[] objParaValue = new object[] { frmEditCt.strMa_Ct, strLoai_Ma_Ct, drEditPhSync["Ngay_Ct"], drEditPhSync["So_Ct"] };
            SQLExecSync1.Execute("Sp_Luu_So_Ct", strParaName, objParaValue, CommandType.StoredProcedure);

            //Update_dsVoucher(frmEditCt);
            sqlTran.Commit();

            return true;
        }

        public static bool UpdateCt(frmVoucher_Edit frmEditCt, SqlCommand sqlCom, DataTable dtEditCt)
        {
            string sp_UpdateCt = (string)frmEditCt.drDmCt["sp_UpdateCt"];
            string strTable_Ct = (string)frmEditCt.drDmCt["Table_Ct"];

            return UpdateCt(frmEditCt, sqlCom, dtEditCt, sp_UpdateCt, strTable_Ct);
        }

        public static bool UpdateCt(frmVoucher_Edit frmEditCt, SqlCommand sqlCom, DataTable dtEditCt, string sp_UpdateCt, string strTable_Ct)
        {            
            #region UpdateCt: Cap nhat tung dong trong dtEditCt

            DataRow drEditPhSync = frmEditCt.drEditPh;
            DataTable dtEditCtSync = frmEditCt.dtEditCt;

            int iSave_Ct_Success = 0;

            sqlCom.Parameters.Clear();

            //Xoa du lieu cu trong Chung tu
            if (frmEditCt.enuNew_Edit == enuEdit.Edit)
            {
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = "DELETE FROM " + strTable_Ct + " WHERE Stt = @Stt";
                sqlCom.Parameters.AddWithValue("@Stt", (string)drEditPhSync["Stt"]);
                try
                {
                    sqlCom.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }

            //Luu du lieu vao Ct
            sqlCom.CommandText = sp_UpdateCt;
            sqlCom.CommandType = CommandType.StoredProcedure;

            string strKey = "Object_id = Object_id('" + sp_UpdateCt + "')";
            DataTable dtUpdateCt_Para = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

            foreach (DataRow dr in dtEditCt.Rows)
            {
                //Khong luu nhung dong danh dau xoa
                if (dr.Table.Columns.Contains("Deleted") && (bool)dr["Deleted"])
                    continue;

                sqlCom.Parameters.Clear();

                DataRow drEditCt = dr;
                Common.SetDefaultDataRow(ref drEditCt);

                foreach (DataRow drPara in dtUpdateCt_Para.Rows)
                {
                    string strColumnName = ((string)drPara["Name"]).Replace("@", "");

                    if (!drEditCt.Table.Columns.Contains(strColumnName))
                        continue;

                    sqlCom.Parameters.AddWithValue("@" + strColumnName, drEditCt[strColumnName]);
                }

                try
                {
                    sqlCom.ExecuteNonQuery();
                    iSave_Ct_Success += 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }

            #endregion

            #region UpdateCt: khong thuc hien duoc dong nao -> xoa han chung tu nay
            if (iSave_Ct_Success == 0)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ không có dữ liệu. Bạn có muốn tiếp tục không ?" : "Vouchers do not have the data. Do you want to continue ?";

                if (Common.MsgYes_No(strMsg))
                {//Neu van tiep tuc luu thi xem nhu xoa chung tu nay

                    sqlCom.Transaction.Rollback();
                    SQLDeleteCt(frmEditCt.strStt, frmEditCt.strMa_Ct);
                    return true;
                }
                else
                {
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }

            return true;
            #endregion
        }

        #region UpdateLSX
        public static void UpdateLSX(frmVoucher_Edit frmEditCt, DataTable dtDinhMucVt)
        {
            if (dtDinhMucVt.Rows.Count < 0)
                return;

            foreach (DataRow dr in dtDinhMucVt.Rows)
            {
                Hashtable ht = new Hashtable();
                ht["STT"] = dr["Stt"];
                ht["NGAY_CT"] = dr["Ngay_Ct"];
                ht["MA_SO"] = dr["Ma_SO"];
                ht["MA_SP"] = dr["Ma_Sp"];
                ht["MA_VT"] = dr["Ma_Vt"];
                ht["TEN_VT"] = dr["Ten_Vt"];
                ht["DVT"] = dr["Dvt"];
                ht["SO_LUONG"] = dr["So_Luong"];
                ht["SO_LUONG_DM"] = dr["So_Luong_Dm"];
                ht["SO_LUONG_VTDC"] = dr["So_Luong_VtDc"];
                //ht["GHI_CHU_LSX"] = dr["Ghi_Chu_Lsx"];
                ht["DELETED"] = dr["Deleted"];
                ht["MA_DVCS"] = Convert.ToString(Parameters.GetParaValue("SYNC_MA_DVCS"));

                SQLExecSync1.Execute("Sp_UpdateMA_LSX", ht, CommandType.StoredProcedure);
            }
        }
        public static bool UpdateCtSX(frmVoucher_Edit frmEditCt, SqlCommand sqlCom, DataTable dtCtVt)
        {
            string sp_UpdateCt = "Sp_UpdateMA_LSX";
            string strTable_Ct = "MALSX";

            DataRow drEditPhSync = frmEditCt.drEditPh;
            DataTable dtEditCtSync = frmEditCt.dtEditCt;

            #region UpdateCt: Cap nhat tung dong trong dtEditCt

            int iSave_Ct_Success = 0;


            sqlCom.Parameters.Clear();

            //Xoa du lieu cu trong Chung tu
            if (frmEditCt.enuNew_Edit == enuEdit.Edit)
            {
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = "DELETE FROM " + strTable_Ct + " WHERE Stt = @Stt";
                sqlCom.Parameters.AddWithValue("@Stt", (string)drEditPhSync["Stt"]);
                sqlCom.Parameters.AddWithValue("@Ma_Ct", (string)drEditPhSync["Ma_Ct"]);

                try
                {
                    sqlCom.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }

            //Luu du lieu vao Ct
            sqlCom.CommandText = sp_UpdateCt;
            sqlCom.CommandType = CommandType.StoredProcedure;

            string strKey = "Object_id = Object_id('" + sp_UpdateCt + "')";
            DataTable dtUpdateCt_Para = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

            foreach (DataRow dr in dtCtVt.Rows)
            {
                //Khong luu nhung dong danh dau xoa
                if (dr.Table.Columns.Contains("Deleted") && (bool)dr["Deleted"])
                {
                    //// Xoa nhung dong de duoc danh dau Deleted tren dtEditCt.Rows
                    //foreach (DataRow drDmVt in dtCtVt.Rows)
                    //{
                    //    if ((string)drDmVt["Ma_SO"] == (string)dr["Ma_SO"] && (string)drDmVt["Ma_Sp"] == (string)dr["Ma_Vt"])
                    //        drDmVt["Deleted"] = true;
                    //}
                    //dtCtVt.AcceptChanges();
                    continue;
                }

                sqlCom.Parameters.Clear();

                DataRow drEditCt = dr;
                Common.SetDefaultDataRow(ref drEditCt);

                foreach (DataRow drPara in dtUpdateCt_Para.Rows)
                {
                    string strColumnName = ((string)drPara["Name"]).Replace("@", "");

                    if (!drEditCt.Table.Columns.Contains(strColumnName))
                        continue;

                    sqlCom.Parameters.AddWithValue("@" + strColumnName, drEditCt[strColumnName]);
                }

                try
                {
                    sqlCom.ExecuteNonQuery();
                    iSave_Ct_Success += 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }

            #endregion

            #region UpdateCt: khong thuc hien duoc dong nao -> xoa han chung tu nay
            if (iSave_Ct_Success == 0)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ không có dữ liệu. Bạn có muốn tiếp tục không ?" : "Vouchers do not have the data. Do you want to continue ?";

                if (Common.MsgYes_No(strMsg))
                {//Neu van tiep tuc luu thi xem nhu xoa chung tu nay

                    sqlCom.Transaction.Rollback();
                    SQLDeleteCt(frmEditCt.strStt, frmEditCt.strMa_Ct);
                    return true;
                }
                else
                {
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }
            return true;
            #endregion
        }
        #endregion

        public static bool UpdateHanTt(frmVoucher_Edit frmEditCt, SqlCommand sqlCom)
        {
            DataRow drEditPhSync = frmEditCt.drEditPh;
            DataTable dtEditCtSync = frmEditCt.dtEditCt;

            if (frmEditCt.dtHanTt0 == null || frmEditCt.dtHanTt0.Rows.Count <= 0)
                return true;

            string strStt = (string)drEditPhSync["Stt"];
            sqlCom.CommandText = "sp_UpdateHanTt0";
            sqlCom.CommandType = CommandType.StoredProcedure;

            string strKey = "Object_id = Object_id('sp_UpdateHanTt0')";
            DataTable dtUpdateCt_Para = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

            DataRow[] drArrHanTt0 = frmEditCt.dtHanTt0.Select();

            //Lưu xuống CSDL
            Hashtable htParameter = new Hashtable();
            htParameter.Add("STT", strStt);
            htParameter.Add("MA_CT", drEditPhSync["Ma_Ct"]);
            htParameter.Add("NGAY_CT", drEditPhSync["Ngay_Ct"]);
            htParameter.Add("SO_CT", drEditPhSync["So_Ct"]);
            htParameter.Add("DIEN_GIAI", drEditPhSync["Dien_Giai"]);
            htParameter.Add("MA_TTE", drEditPhSync["Ma_Tte"]);
            htParameter.Add("TY_GIA", drEditPhSync["Ty_Gia"]);
            htParameter.Add("TK", string.Empty);
            htParameter.Add("MA_DT", string.Empty);
            htParameter.Add("TIEN_TT", 0);
            htParameter.Add("TIEN_TT_NT", 0);
            htParameter.Add("TIEN_CLTG", 0);
            htParameter.Add("STT_HD", string.Empty);
            htParameter.Add("MA_DVCS", Convert.ToString(Parameters.GetParaValue("SYNC_MA_DVCS")));

            foreach (DataRow dr in drArrHanTt0)
            {
                if (!(bool)dr["Modify"])
                    continue;

                htParameter["TK"] = dr["Tk"];
                htParameter["MA_DT"] = dr["Ma_Dt"];
                htParameter["TIEN_TT"] = dr["Tien_Tt1"];
                htParameter["TIEN_TT_NT"] = dr["Tien_Tt_Nt1"];
                htParameter["TIEN_CLTG"] = dr["Tien_CLTG"];
                htParameter["STT_HD"] = dr["Stt"];
                htParameter["LASTMODIFY_LOG"] = dr["LastModify_Log"];

                //SQLExecSync1.Execute("sp_UpdateHanTt0", htParameter, CommandType.StoredProcedure);				

                sqlCom.Parameters.Clear();

                foreach (DataRow drPara in dtUpdateCt_Para.Rows)
                {
                    string strColumnName = ((string)drPara["Name"]).Replace("@", "");

                    if (!htParameter.Contains(strColumnName.ToUpper()))
                        continue;

                    sqlCom.Parameters.AddWithValue("@" + strColumnName, htParameter[strColumnName.ToUpper()]);
                }

                try
                {
                    sqlCom.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }

            return true;
        }

        public static bool History(frmVoucher_Edit frmEditCt, SqlCommand sqlCom)
        {
            string sSYNC_MA_DVCS = Convert.ToString(Parameters.GetParaValue("SYNC_MA_DVCS"));
            DataTable dtEditCtOrgSync = frmEditCt.dtEditCtOrg;
            DataTable dtEditCtSync = frmEditCt.dtEditCt;
            DataTable dtHistorySync = frmEditCt.dtEditCt.Clone();

            //Chuyển đổi Ma_Dvcs-------------            
            foreach (DataRow drEditCt in dtEditCtOrgSync.Rows)
            {
                drEditCt["Ma_DvCs"] = sSYNC_MA_DVCS;
            }
            dtEditCtOrgSync.AcceptChanges();

            #region dtHistory
            foreach (DataRow drEditCtOrg in dtEditCtOrgSync.Rows)
            {
                DataRow[] arrdrEditCt = dtEditCtSync.Select("Stt0 = " + drEditCtOrg["Stt0"].ToString());
                if (arrdrEditCt.Length == 0)
                {
                    dtHistorySync.ImportRow(drEditCtOrg);
                }
                else
                {
                    DataRow drEditCt = arrdrEditCt[0];
                    DataRow drHistory = dtHistorySync.NewRow();
                    Common.SetDefaultDataRow(ref drHistory);
                    drHistory["Stt"] = drEditCtOrg["Stt"];
                    drHistory["Stt0"] = drEditCtOrg["Stt0"];
                    drHistory["Ma_Ct"] = drEditCtOrg["Ma_Ct"];
                    drHistory["Ngay_Ct"] = drEditCtOrg["Ngay_Ct"];
                    drHistory["So_Ct"] = drEditCtOrg["So_Ct"];
                    drHistory["Dien_Giai"] = drEditCtOrg["Dien_Giai"];

                    bool bIs_Edit = false;
                    foreach (DataColumn dc in dtEditCtOrgSync.Columns)
                    {
                        switch (dc.DataType.ToString())
                        {
                            case "System.Boolean":
                            case "System.Byte":
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Decimal":
                            case "System.Double":
                                if (Convert.ToDouble(drEditCtOrg[dc.ColumnName]) != Convert.ToDouble(drEditCt[dc.ColumnName]))
                                {
                                    drHistory[dc.ColumnName] = drEditCtOrg[dc.ColumnName];
                                    bIs_Edit = true;
                                }
                                break;
                            case "System.String":
                                if (Convert.ToString(drEditCtOrg[dc.ColumnName]) != Convert.ToString(drEditCt[dc.ColumnName]))
                                {
                                    drHistory[dc.ColumnName] = drEditCtOrg[dc.ColumnName];
                                    bIs_Edit = true;
                                }
                                break;
                            case "System.DateTime":
                                if (drEditCtOrg[dc.ColumnName].ToString() != drEditCt[dc.ColumnName].ToString())
                                {
                                    drHistory[dc.ColumnName] = drEditCtOrg[dc.ColumnName];
                                    bIs_Edit = true;
                                }
                                break;
                        }
                    }

                    if (bIs_Edit == true)
                    {
                        dtHistorySync.Rows.Add(drHistory);
                    }
                }
            }

            dtHistorySync.AcceptChanges();
            if (dtHistorySync.Rows.Count == 0)
                return true;

            DataColumn dc2 = new DataColumn("Member_ID", typeof(string));
            dc2.DefaultValue = Element.sysUser_Id;
            dtHistorySync.Columns.Add(dc2);

            dc2 = new DataColumn("Update_Type", typeof(string));
            dc2.DefaultValue = "E";
            dtHistorySync.Columns.Add(dc2);

            dc2 = new DataColumn("Ngay_Update", typeof(DateTime));
            dc2.DefaultValue = DateTime.Now;
            dtHistorySync.Columns.Add(dc2);


            #endregion

            #region Luu du lieu vao History
            sqlCom.CommandText = "Sp_UpdateHistoryVoucher";
            sqlCom.CommandType = CommandType.StoredProcedure;

            string strKey = "Object_id = Object_id('Sp_UpdateHistoryVoucher')";
            DataTable dtUpdateCt_Para = DataTool.SQLGetDataTable("Sys.Parameters", "Name", strKey, null);

            foreach (DataRow dr in dtHistorySync.Rows)
            {
                //Khong luu nhung dong danh dau xoa
                sqlCom.Parameters.Clear();

                DataRow drEditCt = dr;
                Common.SetDefaultDataRow(ref drEditCt);

                foreach (DataRow drPara in dtUpdateCt_Para.Rows)
                {
                    string strColumnName = ((string)drPara["Name"]).Replace("@", "");

                    if (!drEditCt.Table.Columns.Contains(strColumnName))
                        continue;

                    sqlCom.Parameters.AddWithValue("@" + strColumnName, drEditCt[strColumnName]);
                }

                try
                {
                    sqlCom.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlCom.Transaction.Rollback();
                    return false;
                }
            }

            return true;
            #endregion
        }

        public static bool SQLDeleteCt(string strStt, string strMa_Ct)
        {
            DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", strMa_Ct);

            if (drDmCt == null)
                return false;

            //Kiem tra Permission
            if (!Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_Delete))
            {
                Common.MsgCancel(Languages.GetLanguage("No_Permission"));
                return false;
            }

            if (!Element.sysIs_Admin)
            {
                string strCreate_User = (string)SQLExecSync1.ExecuteReturnValue("SELECT ISNULL(MAX(Create_Log), '') FROM GLVOUCHER WHERE Stt = '" + strStt + "'");

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    string strUser_Allow = (string)SQLExecSync1.ExecuteReturnValue("SELECT Member_ID_Allow FROM SYSMEMBER WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
                    {
                        if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                        {
                            string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Không xóa được chứng từ do " + strCreate_User +
                                        " lập, liên hệ với người quản trị !" : "Do not delete vouchers from " + strCreate_User + " create, contact the administrator !";
                            Common.MsgCancel(strMsg);
                            return false;
                        }
                    }
                }
            }

            DataRow drEditPh = DataTool.SQLGetDataRowByID((string)drDmCt["Table_Ph"], "Stt", strStt);

            SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            SqlTransaction sqlTran = sqlCom.Connection.BeginTransaction("Deleting_Voucher_Tran");

            sqlCom.Transaction = sqlTran;

            string strTable_Ph = (string)drDmCt["Table_Ph"];
            string strTable_Ct = (string)drDmCt["Table_Ct"];

            //#region DeleteQueue

            //if (!Voucher.DeleteQueue(sqlCom, drEditPh))
            //{
            //    sqlTran.Rollback();
            //    return false;
            //}

            //#endregion

            #region Delete HanTt
            //Common.SQLPushQueue(sqlCom, "SP_CT_DELETE_HANTT '" + strStt + "'", strStt);
            //Không viết trong Delete_All do: khi F3 chứng từ, chương trình chay Delele_All -> sai

            sqlCom.Parameters.Clear();
            sqlCom.CommandText = "EXEC SP_CT_DELETE_HANTT @Stt";
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@Stt", strStt);

            try
            {
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                sqlTran.Rollback();
                return false;
            }
            #endregion

            #region Delete Ct

            sqlCom.Parameters.Clear();
            sqlCom.CommandText = "DELETE FROM " + strTable_Ct + " WHERE Stt = @Stt";
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@Stt", strStt);

            try
            {
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                sqlTran.Rollback();
                return false;
            }

            //DeleteCtLR
            if (Common.Inlist(strMa_Ct, "LR,TR"))
            {
                sqlCom.Parameters.Clear();
                sqlCom.CommandText = "DELETE FROM INLAPRAP WHERE Stt = @Stt";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.AddWithValue("@Stt", strStt);

                try
                {
                    sqlCom.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                    sqlTran.Rollback();
                    return false;
                }
            }
            #endregion

            #region Delete Ph

            sqlCom.CommandText = "DELETE FROM " + strTable_Ph + " WHERE Stt = @Stt";

            try
            {
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                sqlTran.Rollback();
                return false;
            }

            #endregion

            sqlTran.Commit();
            return true;
        }

        //Update_Header, Update_Detail
        public static void Update_Header(frmVoucher_Edit frmEditCt)
        {//Tao cau truc column cho dtEditPh va Copy row du lieu dau tien tu dtEditCt -> drEditPh

            DataRow drEditPhSync = frmEditCt.drEditPh;
            DataTable dtEditCtSync = frmEditCt.dtEditCt;

            Common.CopyDataColumn(dtEditCtSync, drEditPhSync.Table, (string)frmEditCt.drDmCt["Update_Header"]);

            if (frmEditCt.enuNew_Edit == enuEdit.Edit || frmEditCt.enuNew_Edit == enuEdit.Copy)
                Common.CopyDataRow(dtEditCtSync.Rows[0], drEditPhSync, (string)frmEditCt.drDmCt["Update_Header"]);
            else
            {
                Common.CopyDataRow(dtEditCtSync.Rows[0], drEditPhSync, (string)frmEditCt.drDmCt["Update_Header"]);
                Common.CopyDataRow(frmEditCt.drEdit, drEditPhSync, (string)frmEditCt.drDmCt["Carry_Header"]);

                if (frmEditCt.dtEditPh.Columns.Contains("Ma_Dt") && dtEditCtSync.Columns.Contains("Ma_Dt"))
                    dtEditCtSync.Rows[0]["Ma_Dt"] = frmEditCt.dtEditPh.Rows[0]["Ma_Dt"];

                if (frmEditCt.dtEditPh.Columns.Contains("Dien_Giai") && dtEditCtSync.Columns.Contains("Dien_Giai"))
                    dtEditCtSync.Rows[0]["Dien_Giai"] = frmEditCt.dtEditPh.Rows[0]["Dien_Giai"];
            }
        }

        //public static void Update_Detail(frmVoucher_Edit frmEditCt)
        //{// Update du lieu tu drPh xuong dtCt

        //    string strColumnList = ((string)frmEditCt.drDmCt["Update_Detail"]);

        //    Update_Detail(frmEditCt, strColumnList);
        //}

        //public static void Update_Detail(frmVoucher_Edit frmEditCt, string strColumnList)
        //{// Update du lieu tu drPh xuong dtCt theo danh sach strColumnList

        //    strColumnList = strColumnList.Replace(" ", "");
        //    Common.GatherMemvar(frmEditCt, ref drEditPhSync);

        //    foreach (DataRow dr in dtEditCtSync.Rows)
        //        Common.CopyDataRow(drEditPhSync, dr, strColumnList);
        //}

        
    }
}
