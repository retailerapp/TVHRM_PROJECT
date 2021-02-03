using System.Drawing;
using System;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using Microsoft.Win32;
using Microsoft.Office;
//using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Management;

using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons.Commons;


namespace Epoint.Systems.Commons
{
    public static class Resource
    {

        public static string GetHDDSerialNumber(string drive)
        {
            //check to see if the user provided a drive letter
            //if not default it to "C"
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            
            //create our ManagementObject, passing it the drive letter to the
            //DevideID using WQL
            ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            //bind our management object
            disk.Get();
            //return the serial number
            return disk["VolumeSerialNumber"].ToString();
        }
        // Methods
        public static Image LoadImage(string strFile_ID)
        {
           if (strFile_ID != null)
            {
                Hashtable htSQLPara = new Hashtable();
                htSQLPara.Add("FILE_ID", strFile_ID);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM SYSResources WHERE File_Id = @File_Id ", htSQLPara, CommandType.Text);
                if (((obj2 != null) && (obj2 != DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return Image.FromStream(new MemoryStream((byte[])obj2));
                }
            }
            return null;
        }

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

        public static bool SaveImage(string strFile_ID, string strFile_Name, string strCatalog, string strFile_Type, string strFile_Tag, Image img)
        {
            string str;
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("FILE_ID", strFile_ID);
            htSQLPara.Add("CATALOG", strCatalog);
            htSQLPara.Add("FILE_NAME", strFile_Name);
            htSQLPara.Add("FILE_TYPE", strFile_Type);
            htSQLPara.Add("FILE_TAG", strFile_Tag);
            htSQLPara.Add("FILE_CONTENT", (img == null) ? new byte[0] : ((byte[])TypeDescriptor.GetConverter(img).ConvertTo(img, typeof(byte[]))));
            if (DataTool.SQLCheckExist("SYSResources", new string[] { "File_ID" }, new object[] { strFile_ID }))
            {
                str = "UPDATE SYSResources SET File_Content = @File_Content WHERE File_Id = @File_Id ";

            }
            else
            {
                str = "INSERT INTO SYSResources (File_Id, Catalog, File_Name, File_Type,FILE_TAG, File_Content) VALUES (@File_Id,@Catalog, @File_Name, @File_Type,@FILE_TAG, @File_Content)";
            }
            return SQLExec.Execute(str, htSQLPara, CommandType.Text);
        }

        public static bool SaveResource(string strFile_ID, string strFile_Name, string strCatalog, string strFile_Type, string strFile_Tag, object objFile_Content)
        {
            string str;
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("FILE_ID", strFile_ID);
            htSQLPara.Add("CATALOG", strCatalog);
            htSQLPara.Add("FILE_NAME", strFile_Name);
            htSQLPara.Add("FILE_TYPE", strFile_Type);
            htSQLPara.Add("FILE_TAG", strFile_Tag);
            htSQLPara.Add("FILE_CONTENT", (objFile_Content == null) ? new byte[0] : ((byte[])objFile_Content));
            if (DataTool.SQLCheckExist("SYSResources", new string[] { "File_Id" }, new object[] { strFile_ID }))
            {
                str = "UPDATE SYSResources SET File_Content = @File_Content WHERE File_Id = @File_Id";
            }
            else
            {
                str = "INSERT INTO SYSResources (File_Id, Catalog, File_Name, File_Type,FILE_TAG, File_Content) VALUES (@File_Id,@Catalog, @File_Name, @File_Type,@FILE_TAG, @File_Content)";
            }
            return SQLExec.Execute(str, htSQLPara, CommandType.Text);
        }
    }
    /*
  public static Image LoadImage(string strCatalog, string strFile_Name, string strFile_Type)
        {
            if (((strCatalog != null) && (strFile_Name != null)) && (strFile_Type != null))
            {
                Hashtable htSQLPara = new Hashtable();
                htSQLPara.Add("CATALOG", strCatalog);
                htSQLPara.Add("FILE_NAME", strFile_Name);
                htSQLPara.Add("FILE_TYPE", strFile_Type);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM SYSResources WHERE Catalog = @Catalog AND File_Name = @File_Name AND File_Type = @File_Type", htSQLPara, CommandType.Text);
                if (((obj2 != null) && (obj2 != DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return Image.FromStream(new MemoryStream((byte[])obj2));
                }
            }
            return null;
        }

        public static object LoadResource(string strCatalog, string strFile_Name, string strFile_Type)
        {
            if (((strCatalog != null) && (strFile_Name != null)) && (strFile_Type != null))
            {
                Hashtable htSQLPara = new Hashtable();
                htSQLPara.Add("CATALOG", strCatalog);
                htSQLPara.Add("FILE_NAME", strFile_Name);
                htSQLPara.Add("FILE_TYPE", strFile_Type);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM SYSResource WHERE Catalog = @Catalog AND File_Name = @File_Name AND File_Type = @File_Type", htSQLPara, CommandType.Text);
                if (((obj2 != null) && (obj2 != DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return obj2;
                }
            }
            return null;
        }

        public static bool SaveImage(string strCatalog, string strFile_Name, string strFile_Type, Image img)
        {
            string str;
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("CATALOG", strCatalog);
            htSQLPara.Add("FILE_NAME", strFile_Name);
            htSQLPara.Add("FILE_TYPE", strFile_Type);
            htSQLPara.Add("FILE_CONTENT", (img == null) ? new byte[0] : ((byte[])TypeDescriptor.GetConverter(img).ConvertTo(img, typeof(byte[]))));
            if (DataTool.SQLCheckExist("SYSResource", new string[] { "Catalog", "File_Name", "File_Type" }, new object[] { strCatalog, strFile_Name, strFile_Type }))
            {
                str = "UPDATE SYSResource SET File_Content = @File_Content WHERE Catalog = @Catalog AND File_Name = @File_Name AND File_Type = @File_Type";
            }
            else
            {
                str = "INSERT INTO SYSResource (Catalog, File_Name, File_Type, File_Content) VALUES (@Catalog, @File_Name, @File_Type, @File_Content)";
            }
            return SQLExec.Execute(str, htSQLPara, CommandType.Text);
        }

        public static bool SaveResource(string strCatalog, string strFile_Name, string strFile_Type, object objFile_Content)
        {
            string str;
            Hashtable htSQLPara = new Hashtable();
            htSQLPara.Add("CATALOG", strCatalog);
            htSQLPara.Add("FILE_NAME", strFile_Name);
            htSQLPara.Add("FILE_TYPE", strFile_Type);
            htSQLPara.Add("FILE_CONTENT", (objFile_Content == null) ? new byte[0] : ((byte[])objFile_Content));
            if (DataTool.SQLCheckExist("SYSResource", new string[] { "Catalog", "File_Name", "File_Type" }, new object[] { strCatalog, strFile_Name, strFile_Type }))
            {
                str = "UPDATE SYSResource SET File_Content = @File_Content WHERE Catalog = @Catalog AND File_Name = @File_Name AND File_Type = @File_Type";
            }
            else
            {
                str = "INSERT INTO SYSResource (Catalog, File_Name, File_Type, File_Content) VALUES (@Catalog, @File_Name, @File_Type, @File_Content)";
            }
            return SQLExec.Execute(str, htSQLPara, CommandType.Text);
        }
    }

 */

}
