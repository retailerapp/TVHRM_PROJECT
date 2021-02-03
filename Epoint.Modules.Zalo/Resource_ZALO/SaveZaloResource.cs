using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using System.IO;

namespace Epoint.Modules.Zalo
{
    public class SaveZaloResource
    {
        private static string strTableName = "ZALORESOURCES";

        public static DataTable SaveZaloResoure(int Ident00, string strFile_ID, string strFile_Name, string strMa_Nhom, string strCatalog, string strFile_Type, string strFile_Tag, object objFile_Content, DateTime dteNgay_Ky, string strNguoi_Ky, bool bDuyet, string strDescription, string strZaloLink, string strMa_Kv_List, string strMa_BP_List, string strTag_List)
        {
            DataTable dtUpdate;
            //string str;
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("IDENT00", Ident00);
            htSQLPara.Add("FILE_ID", strFile_ID);
            htSQLPara.Add("FILE_NAME", strFile_Name);
            htSQLPara.Add("MA_NHOM", strMa_Nhom);
            htSQLPara.Add("CATALOG", strCatalog);
            htSQLPara.Add("DESCRIPTION", strDescription);
            htSQLPara.Add("FILE_TYPE", strFile_Type);
            htSQLPara.Add("FILE_TAG", strFile_Tag);
            htSQLPara.Add("FILE_CONTENT", (objFile_Content == null) ? new byte[0] : ((byte[])objFile_Content));
            htSQLPara.Add("NGAY_KY", dteNgay_Ky);
            htSQLPara.Add("NGUOI_KY", strNguoi_Ky);
            htSQLPara.Add("DUYET", bDuyet);
            htSQLPara.Add("ZALOLINK", strZaloLink);
            htSQLPara.Add("MA_KV_LIST", strMa_Kv_List);
            htSQLPara.Add("MA_BP_LIST", strMa_BP_List  );
            htSQLPara.Add("TAG_LIST", strTag_List);
            dtUpdate = SQLExec.ExecuteReturnDt("SP_HRM_SaveZaloResource", htSQLPara, CommandType.StoredProcedure);
            if (dtUpdate.Rows.Count > 0)
            {
                Ident00 = Convert.ToInt32(dtUpdate.Rows[0]["Ident00"]);
                string str = "UPDATE " + strTableName + " SET File_Content = @File_Content WHERE Ident00 ="+ @Ident00;
                SQLExec.Execute(str, htSQLPara, CommandType.Text);
            }
            
            return dtUpdate;
         
        }
        public static bool Save(int Ident00,string strFile_ID, string strFile_Name, string strMa_Nhom, string strCatalog, string strFile_Type, string strFile_Tag, object objFile_Content, DateTime dteNgay_Ky, string strNguoi_Ky, bool bDuyet)
        {
            string str;
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("FILE_ID", strFile_ID);
            htSQLPara.Add("FILE_NAME", strFile_Name);
            htSQLPara.Add("MA_NHOM", strMa_Nhom);
            htSQLPara.Add("CATALOG", strCatalog);
            htSQLPara.Add("FILE_TYPE", strFile_Type);
            htSQLPara.Add("FILE_TAG", strFile_Tag);
            htSQLPara.Add("FILE_CONTENT", (objFile_Content == null) ? new byte[0] : ((byte[])objFile_Content));
            htSQLPara.Add("NGAY_KY", dteNgay_Ky);
            htSQLPara.Add("NGUOI_KY", strNguoi_Ky);
            htSQLPara.Add("DUYET", bDuyet);

            if (DataTool.SQLCheckExist(strTableName, new string[] { "Ident00" }, new object[] { Ident00 }))
            {
                str = "UPDATE " + strTableName + " SET File_Content = @File_Content WHERE Ident00 = @Ident00";                
            }
            else
            {
                str = "INSERT INTO " + strTableName + " (File_Id, File_Name, Ma_Nhom, Catalog, File_Type, File_Tag, File_Content, Ngay_Ky, Nguoi_Ky, Duyet)" +
                        " VALUES (@File_Id, @File_Name, @Ma_Nhom, @Catalog, @File_Type,@FILE_TAG, @File_Content, @Ngay_Ky, @Nguoi_Ky, @Duyet)";                
            }

            return SQLExec.Execute(str, htSQLPara, CommandType.Text);
        }

        //Save Image
        public static bool SaveImage(int Ident00, string strFile_ID, string strFile_Name, string strMa_Nhom, string strCatalog, string strFile_Type, string strFile_Tag, PictureBox img, DateTime dteNgay_Ky, string strNguoi_Ky, bool bDuyet)
        {
            string str;
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("IDENT00", Ident00);
            htSQLPara.Add("FILE_ID", strFile_ID);
            htSQLPara.Add("FILE_NAME", strFile_Name);
            htSQLPara.Add("MA_NHOM", strMa_Nhom);
            htSQLPara.Add("CATALOG", strCatalog);
            htSQLPara.Add("FILE_TYPE", strFile_Type);
            htSQLPara.Add("FILE_TAG", strFile_Tag);
            htSQLPara.Add("FILE_CONTENT", (img.Image != null) ? ((byte[])TypeDescriptor.GetConverter(img.Image).ConvertTo(img.Image, typeof(byte[]))) : new byte[] { });
            htSQLPara.Add("NGAY_KY", dteNgay_Ky);
            htSQLPara.Add("NGUOI_KY", strNguoi_Ky);
            htSQLPara.Add("DUYET", bDuyet);

            if (DataTool.SQLCheckExist(strTableName, new string[] { "Ident00" }, new object[] { Ident00 }))
            {
                str = "UPDATE " + strTableName + " SET File_Content = @File_Content WHERE File_Id = @File_Id";
            }
            else
            {
                str = "INSERT INTO " + strTableName + " (File_Id, File_Name, Ma_Nhom, Catalog, File_Type, File_Tag, File_Content, Ngay_Ky, Nguoi_Ky, Duyet)" +
                        " VALUES (@File_Id, @File_Name, @Ma_Nhom, @Catalog, @File_Type, @File_Tag, @File_Content, @Ngay_Ky, @Nguoi_Ky, @Duyet)";
            }

            return SQLExec.Execute(str, htSQLPara, CommandType.Text);
        }

        //Load attach file
        public static object LoadResource(int Ident00)
        {
            if (Ident00 != 0)
            {
                Hashtable htSQLPara = new Hashtable();
                htSQLPara.Add("IDENT00", Ident00);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM "+strTableName+" WHERE Ident00 = @Ident00 ", htSQLPara, CommandType.Text);
                if (((obj2 != null) && (obj2 != DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return obj2;
                }
            }
            return null;
        }
        public static Boolean LoadResourceImage(string FileName, object obj2)
        {
            if (((obj2 != null) && (obj2 != DBNull.Value)) && (((byte[])obj2).Length > 0))
            {
                Bitmap bm = new Bitmap(Image.FromStream(new MemoryStream((byte[])obj2)));
                FileStream stream = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite);
                stream.Write((byte[])obj2, 0, ((byte[])obj2).Length);
                stream.Close();
                return true;
            }
            return false;
        }   
    }
}
