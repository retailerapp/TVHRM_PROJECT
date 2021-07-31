using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Runtime.InteropServices;
using Epoint.Systems;
using Epoint.Systems.Data;

namespace Epoint.Systems.Elements
{
    public class Collection
    {
        public static Dictionary<string, LanguageInfo> Languages = new Dictionary<string, LanguageInfo>();

        public static DataTable Columns = new DataTable();

        public static DataTable Zones = new DataTable();

        public static Dictionary<string, Form> Working_Module_Form = new Dictionary<string, Form>();

        public static Dictionary<string, object> Parameters = new Dictionary<string, object>();

        public const string DecryptConnectionString = "qwertyuiopasdfghjklzxcvbnm";

        public const string DecryptEpointString = "Epoint@@software";

        public const string AppConfigFile = @"\Epoint.exe.config";

        public const string LiveUpdateFile = @"\\LiveUpdate.exe";

        public const string SqlSrcript = @"\\SQLScript";

        public const string SqlSrcriptBackup = @"\\SQLScript\\Backup";

        public const string PackageUpdate = @"\\PackageUpdate";

        public const string PackageUpdateBackup = @"\\PackageUpdate\\Backup";

    }

    public static class Core
    {

        public static string Curency()
        {
            string strCurency = string.Empty;
            strCurency = License.Curency();
            //strCurency = License.License.Curency();
            return strCurency;
        }
        public static string Ten_Dvcs(string strMa_Dvi)
        {
            string strTen_Dvcs = string.Empty;
            if (Is_Ma_Dvcs_Valid(strMa_Dvi))
            {
                strTen_Dvcs = License.Ten_Dvcs(strMa_Dvi);
            }
            return strTen_Dvcs;
        }
        public static string ConnectionString()
        {
            //return License.ConnectingSring();
            //string strfile = Application.StartupPath + "\\EpointConfig.epoint";
            string strConnection = string.Empty;
            string strfile = Application.StartupPath + "\\" + Element.sysConfigFile;
            if (!File.Exists(strfile))
                MessageBox.Show("File config doesn't exist!");
            using (StreamReader sr = new StreamReader(strfile))
            {
                string strConnect = sr.ReadToEnd();
                try
                {
                    strConnection = License.DecryptString(strConnect, Collection.DecryptConnectionString);
                    DataTool.sysConnectionString = strConnection;
                    DataElement.sysConnectionString = strConnection;
                    DataElement.sysConnectionStringEncrypt = strConnect;
                    return strConnection;
                }
                catch
                {
                    MessageBox.Show("Config database error!");
                    Application.Exit();
                    return string.Empty;
                }
            }
        }
        public static string ConnectionString(string strConnectionString)
        {
            string strConnection = string.Empty;
            try
            {
                strConnection = License.DecryptString(strConnectionString, Collection.DecryptConnectionString);
                DataTool.sysConnectionString = strConnection;
                DataElement.sysConnectionString = strConnection;
                DataElement.sysConnectionStringEncrypt = strConnectionString;
                return strConnection;
            }
            catch
            {
                MessageBox.Show("Config database error!");
                return string.Empty;
            }
        }
        public static string ConnectionStringSync1()
        {

            string strfile = Application.StartupPath + "\\" + Element.sysConfigFile;
            if (!File.Exists(strfile))
                MessageBox.Show("Config database error!");
            using (StreamReader sr = new StreamReader(strfile))
            {
                string strConnect = sr.ReadToEnd();
                //return strConnect;
                try
                {
                    return License.DecryptString(strConnect, Collection.DecryptConnectionString);
                }
                catch
                {
                    MessageBox.Show("Config database error!");
                    return string.Empty;
                }
            }
        }
        public static string ConnectionStringSync2()
        {

            string strfile = Application.StartupPath + "\\" + Element.sysConfigFile;
            if (!File.Exists(strfile))
                MessageBox.Show("Config database error!");
            using (StreamReader sr = new StreamReader(strfile))
            {
                string strConnect = sr.ReadToEnd();
                //return strConnect;
                try
                {
                    return License.DecryptString(strConnect, Collection.DecryptConnectionString);
                }
                catch
                {
                    MessageBox.Show("Config database error!");
                    return string.Empty;
                }
            }
        }
        public static string ConnectionStringUpdate()
        {

            string strfile = Application.StartupPath + "\\" + Element.sysConfigFileUpdate;
            if (!File.Exists(strfile))
            {
                return Core.ConnectionString();
            }
            using (StreamReader sr = new StreamReader(strfile))
            {
                string strConnect = sr.ReadToEnd();
                try
                {
                    return License.DecryptString(strConnect, Collection.DecryptConnectionString);
                }
                catch
                {
                    return Core.ConnectionString();
                }
            }
        }
        public static bool Is_Valid(string strMa_Dvi)
        {
            bool bIs_Valid = false;

            return bIs_Valid;
        }

        public static bool Is_Module_Valid(int iModule)
        {
            //return bIs_Module_Valid;
            return License.Module(iModule);
            //return true;
        }

        public static bool Is_Ma_Dvcs_Valid(string strMa_DvCs)
        {
            string strKey = string.Empty, strKey_log = string.Empty, strKey_Lics = string.Empty;
            DataTable dtDmDvCs = new DataTable();
            dtDmDvCs = SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMDVCS WHERE Ma_DvCs = '" + strMa_DvCs + "'");


            if (dtDmDvCs.Rows.Count > 0)
            {
                strKey_Lics = dtDmDvCs.Rows[0]["Key_Log"].ToString();

                if (dtDmDvCs.Columns.Contains("Date_Lics"))
                {
                    strKey = strMa_DvCs + dtDmDvCs.Rows[0]["Key_DVCS"].ToString() + dtDmDvCs.Rows[0]["Key_Module"].ToString() + ":" + dtDmDvCs.Rows[0]["Date_Lics"].ToString();
                }
                else
                {
                    strKey = strMa_DvCs + dtDmDvCs.Rows[0]["Key_DVCS"].ToString() + dtDmDvCs.Rows[0]["Key_Module"].ToString() + ":-1";

                }

                strKey_log = License.Encrypt(License.Encrypt(strKey));

                if (strKey_log == strKey_Lics)
                {
                    return true;
                }

            }
            return false;
        }

        public static string Encrypt(string strText)
        {
            return License.EncryptString(strText, Collection.DecryptEpointString);
        }
        public static string Decrypt(string strText)
        {
            return License.DecryptString(strText, Collection.DecryptEpointString);
        }

        // public int UpdateserverLicence(string Ma_Dvcs, string BranchID, string Key_Log, string Key_Module, string PC_Name)
        //{
        //    return License.License.UpdateserverLicence(Ma_Dvcs, BranchID, Key_Log, Key_Module, PC_Name);
        // }
    }
}
