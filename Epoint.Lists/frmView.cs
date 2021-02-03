﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data.OleDb;
using System.Reflection;

using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Elements;
using System.Data.OleDb;


namespace Epoint.Lists
{
	public partial class frmView : Epoint.Systems.Customizes.frmView
	{
        public string strTableName = string.Empty;
        public string strCode = string.Empty;
        public string strName = string.Empty;
        public Hashtable htHistory = new Hashtable();

        public frmView()
		{
			InitializeComponent();

            //Thong: History
            htHistory["MEMBER_ID"] = Element.sysUser_Id;
            htHistory["NGAY_UPDATE"] = DateTime.Now;
            htHistory["MA_DVCS"] = Element.sysMa_DvCs;

            this.btImport.Click += new EventHandler(btImport_Click);
            this.btExport.Click += new EventHandler(btExport_Click);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);
		}
        

        void btPrint_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btPreview_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F8)
        //    {
        //        //Kiem tra Permission
        //        if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
        //            this.Delete();
        //        else
        //            Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));

        //        return;
        //    }
        //    else
        //    {
        //        base.OnKeyDown(e);
        //    }
        //}
        public void UpdateHistory()
        {
            SQLExec.Execute("sp_UpdateHistoryOther", htHistory, CommandType.StoredProcedure);

            if (htHistory.ContainsKey("UPDATE_TYPE"))
                htHistory.Remove("UPDATE_TYPE");

            if (htHistory.ContainsKey("CODE_OLD"))
                htHistory.Remove("CODE_OLD");

            if (htHistory.ContainsKey("NAME_OLD"))
                htHistory.Remove("NAME_OLD");
        }
        public virtual void Import_Excel()
        {
            OpenFileDialog ofdlg = new OpenFileDialog();

            ofdlg.DefaultExt = "xls";
            ofdlg.Filter = "*.xls|*.xls";

            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;


            //            string probeConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0; +
            //            string probeConnStr = @"Provider=Microsoft.Jet.OLEDB.4.0;
            //						Data Source= " + ofdlg.FileName + ";" +
            //                        "Extended Properties=\"Excel 8.0;HDR=YES\"";


            String probeConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                 "Data Source=" + ofdlg.FileName + ";Extended Properties=Excel 8.0;";
            using (OleDbConnection probeConn = new OleDbConnection(probeConnStr))
            {
                probeConn.Open();
                string probe = "SELECT * FROM [Sheet1$] " + //Sheet1$A1:A65536
                                "Where " + strCode + " IS NOT NULL AND " + strName + " IS NOT NULL";

                using (OleDbDataAdapter oleDbDapter = new OleDbDataAdapter(probe, probeConn))
                {
                    DataTable tbExcel = new DataTable();
                    oleDbDapter.Fill(tbExcel);

                    DataTable dtStruct = DataTool.SQLGetDataTable(strTableName, "TOP 0 * ", " 0 = 1", null);
                    DataTable dtStruct2 = dtStruct.Clone();
                    DataRow drNewRow = dtStruct.NewRow();
                    dtStruct.Rows.Add(drNewRow);

                    foreach (DataColumn dc in dtStruct2.Columns)
                        if (dc.DataType.ToString() == "System.Byte[]")
                        {
                            dtStruct.Columns.Remove(dc.ColumnName);
                            dtStruct.AcceptChanges();
                        }


                    //if (drNewRow.Table.Columns.Contains("Hinh"))
                    //{
                    //    drNewRow.Table.Columns.Remove("Hinh");
                    //    drNewRow.Table.AcceptChanges();
                    //}

                    Common.SetDefaultDataRow(ref drNewRow);

                    string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên mẫu tin đã tồn tại không ?" : "Do you want to override exists data ?");
                    bool bIs_Overide = Common.MsgYes_No(strMsg);

                    foreach (DataRow drExcel in tbExcel.Rows)
                    {
                        Common.CopyDataRow(drExcel, drNewRow);
                        drNewRow.AcceptChanges();

                        if (bIs_Overide && DataTool.SQLCheckExist(strTableName, strCode, (string)drExcel[strCode]))
                            DataTool.SQLUpdate(enuEdit.Edit, strTableName, ref drNewRow);
                        else
                            DataTool.SQLUpdate(enuEdit.New, strTableName, ref drNewRow);
                    }
                }
            }

            Type type = this.GetType();
            type.InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);

            Common.MsgOk(Languages.GetLanguage("End_Process"));
        }

        public virtual void Import_Excel_ODBC()
        {
            txtTextBox txttemp = new txtTextBox();
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "xls files (*.xls)|*.xls";
            ofdlg.RestoreDirectory = true;
            //ofdlg.DefaultExt = "xls";
            //ofdlg.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";

            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;
            else
                txttemp.Text = ofdlg.FileName;

            //Get Enviroment OS
            //string strPath_OS = @"C:\Windows\SysWow64";
            //string probeConnStr = string.Empty;
            
//            if (Directory.Exists(strPath_OS)) //Window 64 bit
//            {
//                probeConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;
//						Data Source= " + ofdlg.FileName + ";" +
//                            "Extended Properties=\"Excel 8.0;HDR=YES\"";
//            }
//            else
//            {
//                probeConnStr = @"Provider=Microsoft.Jet.OLEDB.4.0;
//						Data Source= " + ofdlg.FileName + ";" +
//                            "Extended Properties=\"Excel 8.0;HDR=YES\"";
//            }
            
            string strConnectString =
                   "Driver={Microsoft Excel Driver (*.xls)};DBQ=" + txttemp.Text;


            OdbcConnection odbcConn = new OdbcConnection(strConnectString);
            odbcConn.Open();


            OdbcCommand odbcComm = new OdbcCommand();
            odbcComm.Connection = odbcConn;

            try
            {
                OdbcDataAdapter odbcDA;
                DataTable tbExcel = new DataTable();
                odbcComm.CommandText = "SELECT * FROM [Sheet1$] WHERE 0 = 1" + "Where " + strCode + " IS NOT NULL AND " + strName + " IS NOT NULL";
                odbcDA = new OdbcDataAdapter(odbcComm);

                odbcDA = new OdbcDataAdapter(odbcComm);
                odbcDA.Fill(tbExcel);

                DataTable dtStruct = DataTool.SQLGetDataTable(strTableName, "TOP 0 * ", " 0 = 1", null);
                DataTable dtStruct2 = dtStruct.Clone();
                DataRow drNewRow = dtStruct.NewRow();
                dtStruct.Rows.Add(drNewRow);

                foreach (DataColumn dc in dtStruct2.Columns)
                    if (dc.DataType.ToString() == "System.Byte[]")
                    {
                        dtStruct.Columns.Remove(dc.ColumnName);
                        dtStruct.AcceptChanges();
                    }


                //if (drNewRow.Table.Columns.Contains("Hinh"))
                //{
                //    drNewRow.Table.Columns.Remove("Hinh");
                //    drNewRow.Table.AcceptChanges();
                //}

                Common.SetDefaultDataRow(ref drNewRow);

                string strMsg = (Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn ghi đè lên mẫu tin đã tồn tại không ?" : "Do you want to override exists data ?");
                bool bIs_Overwrite = Common.MsgYes_No(strMsg);

                foreach (DataRow drExcel in tbExcel.Rows)
                {
                    Common.CopyDataRow(drExcel, drNewRow);
                    drNewRow.AcceptChanges();

                    if (bIs_Overwrite)
                    {
                        DataTool.SQLDelete(strTableName, drNewRow);
                        DataTool.SQLUpdate(enuEdit.New, strTableName, ref drNewRow);
                    }
                    else
                    {
                        if (DataTool.SQLCheckExist(strTableName, strCode, (string)drExcel[strCode]))
                            continue;
                        else
                            DataTool.SQLUpdate(enuEdit.New, strTableName, ref drNewRow);
                    }

                    //if (bIs_Overwrite && DataTool.SQLCheckExist(strTableName, strCode, (string)drExcel[strCode]))
                    //    DataTool.SQLUpdate(enuEdit.Edit, strTableName, ref drNewRow);
                    //else
                    //    DataTool.SQLUpdate(enuEdit.New, strTableName, ref drNewRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi import file " + ofdlg.FileName + ex.Message);
            }           

            Type type = this.GetType();
            type.InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
            Common.MsgOk(Languages.GetLanguage("End_Process"));
        }
        public void Export_Excel()
        {
            string strTable = SQLExec.ExecuteReturnValue("SELECT File_Import FROM SYSDMTABLE WHERE Table_Name0 = '" + strTableName + "'").ToString();
            DataTable dtResource = SQLExec.ExecuteReturnDt("SELECT * FROM SYSResources WHERE Catalog = '" + strTable + "'");
            DataRow drResource;
            if (dtResource.Rows.Count > 0)
            {
                drResource = dtResource.Rows[0];
                object objFile = Resource.LoadResource(drResource["File_Id"].ToString());               

            }
        }
        
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                //Kiem tra Permission
                if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
                    this.Delete();
                else
                    Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));

                return;
            }
            //else if (e.Control && e.KeyCode == Keys.F10)
            //    Export_Excel();
            else if (e.KeyCode == Keys.F10 && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New) && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
                Import_Excel();

            //Xóa hết dữ liệu phục vụ import từ excel
            else if (e.Control && e.Alt && e.Shift && e.KeyCode == Keys.D && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New) && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit) && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                string mess = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc xóa hết?" : "Are you sure delete all?";
                if (Common.MsgYes_No(mess, "N"))
                    if (strTableName != "")
                    {
                        if (SQLExec.Execute("DELETE FROM " + strTableName + " WHERE Ma_Data = '" + Element.sysMa_Data + "'"))
                        {
                            Type type = this.GetType();
                            type.InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
                            Common.MsgOk(Languages.GetLanguage("End_Process"));
                        }
                    }

                    else if (SQLExec.Execute("DELETE FROM GLTHANHTOAN" + " WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Nam = " + Element.sysWorkingYear))
                    {
                        Type type = this.GetType();
                        type.InvokeMember("FillData", BindingFlags.InvokeMethod, null, this, null);
                        Common.MsgOk(Languages.GetLanguage("End_Process"));
                    }
            }

            else
            {
                base.OnKeyDown(e);
            }
        }

        public static string GetColumnZone(string strZone)
        {
            string strSelect = @"DECLARE @_ColumnList VARCHAR(MAX)
									SET @_ColumnList = ''
									SELECT @_ColumnList = @_ColumnList + Column_Id + ',' FROM SYSCOLUMN WHERE ZONE = '" + strZone + @"'
									SET @_ColumnList = LEFT(@_ColumnList, LEN(@_ColumnList) - 1)
									SELECT ISNULL(@_ColumnList, '')";

            return (string)SQLExec.ExecuteReturnValue(strSelect);
        }


        public string GetAutoCode(string strCurrentCode)
        {
            return (string)SQLExec.ExecuteReturnValue("sp_GetAutoCode '" + strCurrentCode + "', '" + strCode + "'");
        }

        public void ExportList(object ExportControl, string strTitle)
        {
            Common.Export(ExportControl, strTitle, string.Empty);
        }
        public virtual void ExportExcel()
        {

        }
        public virtual void RefeshData()
        {

        }
        void btImport_Click(object sender, EventArgs e)
        {
            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New) && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
                Import_Excel();
        }
        void btExport_Click(object sender, EventArgs e)
        {
            ExportExcel();
        } void btRefresh_Click(object sender, EventArgs e)
        {
            RefeshData();
        }   
    }
}
