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

namespace Epoint.Controllers
{
    public class SaveResource
    {
        public static bool Save(string strFile_ID, string strFile_Name, string strMa_Nhom, string strCatalog, string strFile_Type, string strFile_Tag, object objFile_Content, DateTime dteNgay_Ky, string strNguoi_Ky, bool bDuyet)
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

            if (DataTool.SQLCheckExist("SYSRESOURCES", new string[] { "File_Id" }, new object[] { strFile_ID }))
            {
                str = "UPDATE SYSRESOURCES SET File_Content = @File_Content WHERE File_Id = @File_Id";                
            }
            else
            {
                str = "INSERT INTO SYSRESOURCES (File_Id, File_Name, Ma_Nhom, Catalog, File_Type, File_Tag, File_Content, Ngay_Ky, Nguoi_Ky, Duyet)" +
                        " VALUES (@File_Id, @File_Name, @Ma_Nhom, @Catalog, @File_Type,@FILE_TAG, @File_Content, @Ngay_Ky, @Nguoi_Ky, @Duyet)";                
            }

            return SQLExec.Execute(str, htSQLPara, CommandType.Text);
        }

        //Save Image
        public static bool SaveImage(string strFile_ID, string strFile_Name, string strMa_Nhom, string strCatalog, string strFile_Type, string strFile_Tag, PictureBox img, DateTime dteNgay_Ky, string strNguoi_Ky, bool bDuyet)
        {
            string str;
            Hashtable htSQLPara = new Hashtable();
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

            if (DataTool.SQLCheckExist("SYSRESOURCES", new string[] { "File_Id" }, new object[] { strFile_ID }))
            {
                str = "UPDATE SYSRESOURCES SET File_Content = @File_Content WHERE File_Id = @File_Id";
            }
            else
            {
                str = "INSERT INTO SYSRESOURCES (File_Id, File_Name, Ma_Nhom, Catalog, File_Type, File_Tag, File_Content, Ngay_Ky, Nguoi_Ky, Duyet)" +
                        " VALUES (@File_Id, @File_Name, @Ma_Nhom, @Catalog, @File_Type, @File_Tag, @File_Content, @Ngay_Ky, @Nguoi_Ky, @Duyet)";
            }

            return SQLExec.Execute(str, htSQLPara, CommandType.Text);
        }

        //Load attach file
        public static object LoadResource(string strFile_ID)
        {
            if (strFile_ID != null)
            {
                Hashtable htSQLPara = new Hashtable();
                htSQLPara.Add("FILE_ID", strFile_ID);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM SYSResources WHERE File_Id = @File_Id ", htSQLPara, CommandType.Text);
                if (((obj2 != null) && (obj2 != DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return obj2;
                }
            }
            return null;
        }        
    }
}
