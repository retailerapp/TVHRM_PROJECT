using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Reflection;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Epoint.Systems.Data;

namespace Epoint.Systems.Elements
{
    public class License
    {
        // Fields...
        private static string _ModuleList;

        public static string ModuleList
        {
            get { return _ModuleList; }
            set
            {
                _ModuleList = value;
            }
        }

        public static string Encrypt(string text)
        {

            MD5CryptoServiceProvider _md5Hasher = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(text);
            bs = _md5Hasher.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }
        //SqlConnection GetTranferConnection()
        //{
        //    SqlConnection sqlconn = new SqlConnection();


        //    //Mở cửa sổ kết nối

        //    sqlconn.ConnectionString = ConnectingSringServer();
        //    try
        //    {
        //        if (sqlconn.State == ConnectionState.Closed)
        //            sqlconn.Open();
        //    }
        //    catch (Exception)
        //    {

        //    }

        //    return sqlconn;
        //}
        public static string ConnectingSring()
        {
            string strfile = Application.StartupPath + "\\EpointConfig.epoint";
            if (!File.Exists(strfile))
                MessageBox.Show("Config database error!");
            using (StreamReader sr = new StreamReader(strfile))
            {
                string strConnect = sr.ReadToEnd();
                //return strConnect;
                try
                {
                    return DecryptString(strConnect, "qwertyuiopasdfghjklzxcvbnm");
                }
                catch
                {
                    MessageBox.Show("Config database error!");
                    return string.Empty;
                }
            }

            /*
            string strfile = Application.StartupPath + "\\EpointConfig.xml";
            if (!File.Exists(strfile))
                MessageBox.Show("Config database error!");
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            if (File.Exists(strfile))
            {
                ds.ReadXml(strfile);
                dt = ds.Tables[0];
            }
            string strUser = DecryptString(dt.Rows[0]["User"].ToString(), "qwertyiop");
            string strPass = DecryptString(dt.Rows[0]["Password"].ToString(), "qwertyiop");
            if (dt.Columns.Contains("Sercurity"))
            {
                if (dt.Rows[0]["Sercurity"].ToString() == "1")
                {
                    return "Data Source=" + dt.Rows[0]["Server"].ToString() + ";Initial Catalog=" + dt.Rows[0]["Database"].ToString() + ";Integrated Security=True";
                }
                else
                    return "Data Source=" + dt.Rows[0]["Server"].ToString() + ";Initial Catalog=" + dt.Rows[0]["Database"].ToString() + ";Integrated Security=False;User ID=" + strUser + ";Password=" + strPass + "";
            }
            return "Data Source=" + dt.Rows[0]["Server"].ToString() + ";Initial Catalog=" + dt.Rows[0]["Database"].ToString() + ";Integrated Security=True";
             * 
             */

        //}

        //public static string ConnectingSringServer()
        //{
            //string strServerconect = Resources.Resources.stringconnect;
            //try
            //{
            //    return DecryptString(strServerconect, "qwertyuiopasdfghjklzxcvbnm");
            //}
            //catch
            //{
            //    return string.Empty;
            //}
            //string strfile = Application.StartupPath + "\\EpointServer.bin";
            //if (!File.Exists(strfile))
            //    return "Data Source= epoint.no-ip.org;Initial Catalog=EpointServer;Integrated Security=False;User ID=sa;Password=1234567890";
            //FileStream fileStream = File.OpenRead(strfile);
            //BinaryFormatter binaryFormatter = new BinaryFormatter();

            //FileStream fileStreamServer = (FileStream)binaryFormatter.Deserialize(fileStream);
            //DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            //if (File.Exists(strfile))
            //{
            //    ds.ReadXml(fileStreamServer);
            //    dt = ds.Tables[0];
            //}
            //string strUser = DecryptString(dt.Rows[0]["User"].ToString(), "qwertyiop");
            //string strPass = DecryptString(dt.Rows[0]["Password"].ToString(), "qwertyiop");
            //string strServer = DecryptString(dt.Rows[0]["Server"].ToString(), "qwertyiop");
            //string strDataBase = DecryptString(dt.Rows[0]["Database"].ToString(), "qwertyiop");

            //return "Data Source=" + strServer + ";Initial Catalog=" + strDataBase + ";Integrated Security=False;User ID=" + strUser + ";Password=" + strPass + "";
        }

        public static string Ten_Dvcs(string strMa_Dvcs)
        {
            //string ConnectingSringServer = License.ConnectingSringServer();

            DataTable dtDmDvCs = new DataTable();
            dtDmDvCs = SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMDVCS WHERE Ma_DvCs = '" + strMa_Dvcs + "'");

            ModuleList = dtDmDvCs.Rows[0]["Key_Module"].ToString();

            if (dtDmDvCs.Rows.Count > 0)
            {
                string strKey = strMa_Dvcs + dtDmDvCs.Rows[0]["Key_DVCS"].ToString() + dtDmDvCs.Rows[0]["Key_Module"].ToString();
                
                
                if (dtDmDvCs.Columns.Contains("Date_Lics"))
                {
                    strKey = strMa_Dvcs + dtDmDvCs.Rows[0]["Key_DVCS"].ToString() + dtDmDvCs.Rows[0]["Key_Module"].ToString() + ":" + dtDmDvCs.Rows[0]["Date_Lics"].ToString();
                }
                else
                {
                    strKey = strMa_Dvcs + dtDmDvCs.Rows[0]["Key_DVCS"].ToString() + dtDmDvCs.Rows[0]["Key_Module"].ToString() + ":-1";

                }
                string strKey_log = Encrypt(Encrypt(strKey));
                //strKey_log = License.Encrypt(License.Encrypt(strKey));
                if (strKey_log == dtDmDvCs.Rows[0]["Key_Log"].ToString())
                    return dtDmDvCs.Rows[0]["Key_DVCS"].ToString();
            }
            return "";
        }

        public static bool Module(int iModule)
        {

            //int[] module = new int[10];
            //module[0] = 101; // CASH
            //module[1] = 501; // ASSET
            //module[2] = 201; // AR
            //module[3] = 301; // AP
            //module[4] = 401; // IN
            //module[5] = 801; // QUAN HE KHACH HANG
            //module[6] = 802; // BAO CAO QT
            //module[7] = 600; // QUAN TRI SX
            //module[8] = 601; // GIA THANH
            //module[9] = 700; // NHAN SU TIEN LUONG 
            //foreach (int i in module)
            //    if (iModule == i)
            //        return true;
            //return false;
            string[] Listmodule = _ModuleList.Split(';');
            foreach (string i in Listmodule)
                if (iModule.ToString() == i)
                    return true;
            return false;
        }
        public static string Curency()
        {
            //return Parameters.GetParaValue("").ToString();
            return DataTool.SQLGetNameByCode("SYSPARAMETER", "Parameter_ID", "Parameter_Value", "SYSMA_TTE");
            //return "";
        }
        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            // Buoc 1: Bam chuoi su dung MD5
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Cai dat bo ma hoa
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert chuoi (Message) thanh dang byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            // Step 5. Ma hoa chuoi
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Tra ve chuoi da ma hoa bang thuat toan Base64
            return Convert.ToBase64String(Results);
        }
        //Hàm giải mã chuỗi
        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            // Step 1. Bam chuoi su dung MD5
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Cai dat bo giai ma
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert chuoi (Message) thanh dang byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            // Step 5. Bat dau giai ma chuoi
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Tra ve ket qua bang dinh dang UTF8
            return UTF8.GetString(Results);
        }

        //public static int UpdateserverLicence(string Ma_Dvcs, string BranchID, string Key_Log, string Key_Module, string PC_Name)
        //{
//            /*
//                0 - Không cho phép truy xuất
//                1 - Tồn tại
//                2 - Đã insert them vào server
//                -1  Lỗi truy xuất server

//            */
//            SqlConnection sqlconn = new SqlConnection();

//            sqlconn.ConnectionString = ConnectingSringServer();
//            try
//            {
//                if (sqlconn.State == ConnectionState.Closed)
//                    sqlconn.Open();
//            }
//            catch (Exception)
//            {
//                return -1;
//            }
//            SqlCommand sqlcom = new SqlCommand();
//            SqlDataAdapter adapter = new SqlDataAdapter();
//            DataTable datatbale = new DataTable();
//            sqlcom.Connection = sqlconn;
//            sqlcom.Parameters.Clear();

//            string strsql;

//            sqlcom.Parameters.AddWithValue("MA_DVCS", Ma_Dvcs);
//            sqlcom.Parameters.AddWithValue("BRANCHID", BranchID);
//            sqlcom.Parameters.AddWithValue("KEY_LOG", Key_Log);
//            sqlcom.Parameters.AddWithValue("KEY_MODULE", Key_Module);
//            sqlcom.Parameters.AddWithValue("PC_NAME", PC_Name);

//            try
//            {
//                strsql = "SELECT * FROM SYSBRANCH WHERE MA_DVCS = @MA_DVCS AND BRANCHID = @BRANCHID AND PC_NAME = @PC_NAME";
//                sqlcom.CommandText = strsql;
//                sqlcom.CommandType = CommandType.Text;
//                adapter.SelectCommand = sqlcom;
//                adapter.Fill(datatbale);

//                if (datatbale.Rows.Count > 0)
//                {
//                    bool bActive = Convert.ToBoolean(datatbale.Rows[0]["Active"].ToString());
//                    if (bActive)
//                        return 1;
//                    else
//                    {

//                        return 0;
//                    }
//                }


//                strsql = @"INSERT INTO SYSBRANCH (MA_DVCS, BRANCHID, KEY_LOG, KEY_MODULE, PC_NAME) 
//								VALUES (@MA_DVCS, @BRANCHID, @KEY_LOG, @KEY_MODULE, @PC_NAME)";

//                sqlcom.CommandText = strsql;
//                sqlcom.ExecuteNonQuery();

//                return 2;
//            }
//            catch (Exception ex)
//            {
//                //EpointProcessBox.AddMessage("Không truyền đc dữ liệu, error: " + ex.Message);
//                return -1;
//            }

        //    return 0;

        //}


    }

}
