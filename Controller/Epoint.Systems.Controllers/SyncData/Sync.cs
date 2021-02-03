using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using Microsoft.Win32;

using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Controllers;

namespace Epoint.Controllers
{
    public class Sync
    {
        public static void Sync_Data()
        {
            string strMsg = string.Empty;

            //Kiểm tra xem quá trình đồng bộ có đang diễn ra.
            if ((string)SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_PROCESSING'") == "1")
            {
                //strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang diễn ra trên máy khác. Vui lòng dừng thao tác đồng bộ và chờ trong ít phút !"
                //                : "The synchronization process is taking place on another machine. Please stop synchronous operation and wait a few minutes !";
                //Common.MsgCancel(strMsg);

                return;
            }

            //Đồng bộ dữ liệu 2 chiều
            if ((string)SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'") == "1")
            {
                if ((string)SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_PROCESSING'") == "0")
                {
                    //Quá trình đồng bộ đang diễn ra, host khác không được đồng bộ
                    SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value ='1' WHERE Parameter_ID = 'SYNC_PROCESSING'");

                    Sync_Send_Data();
                    Sync_Get_Data();

                    //Quá trình đồng bộ hoàn tất, các host có thể thực hiện đồng bộ
                    SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value ='0' WHERE Parameter_ID = 'SYNC_PROCESSING'");

                    strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Đồng bộ dữ liệu thành công !" : "Sync Finish !";
                    Common.MsgCancel(strMsg);
                }
            }
            //this.Close();            
            //Common.CloseCurrentForm();
        }

        public static void Sync_Send_Data()
        {
            //Sync
            Hashtable htPara = new Hashtable();
            if (Collection.Parameters.ContainsKey("SYNC_SERVER"))
                htPara.Add("SERVER", Collection.Parameters["SYNC_SERVER"]);
            if (Collection.Parameters.ContainsKey("SYNC_DBSOURCE"))
                htPara.Add("DBSOURCE", Collection.Parameters["SYNC_DBSOURCE"]);
            if (Collection.Parameters.ContainsKey("SYNC_DBDEST"))
                htPara.Add("DBDEST", Collection.Parameters["SYNC_DBDEST"]);
            if (Collection.Parameters.ContainsKey("SYNC_USER"))
                htPara.Add("USER", Collection.Parameters["SYNC_USER"]);
            if (Collection.Parameters.ContainsKey("SYNC_PASS"))
                htPara.Add("PASS", Collection.Parameters["SYNC_PASS"]);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            //Begin Sync List
            string strSQLExec_List =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCLIST ORDER BY Stt";

            DataTable dtTranList = SQLExec.ExecuteReturnDt(strSQLExec_List);
            foreach (DataRow dr in dtTranList.Rows)
            {
                if ((bool)dr["IS_SEND"])
                {
                    htPara["TABLE_NAME"] = dr["Table_Name"].ToString();
                    htPara["NAM"] = Element.sysWorkingYear;
                    //EpointProcessBox.AddMessage("Sync List  ");
                    SQLExec.Execute("sp_Sync_Send_List", htPara, CommandType.StoredProcedure);
                }
            }

            //Begin Sync Voucher
            string strSQLExec_Voucher =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCVOUCHER ORDER BY Stt";

            DataTable dtTranVoucher = SQLExec.ExecuteReturnDt(strSQLExec_Voucher);
            foreach (DataRow dr in dtTranVoucher.Rows)
            {
                if ((bool)dr["IS_SEND"])
                {
                    htPara["MA_CT"] = dr["Ma_Ct"].ToString();
                    htPara["TABLE_NAME"] = dr["Table_Name"].ToString();
                    htPara["NAM"] = Element.sysWorkingYear;
                    //EpointProcessBox.AddMessage("Sync Voucher  ");
                    SQLExec.Execute("sp_Sync_Send_Voucher", htPara, CommandType.StoredProcedure);
                }
            }
            //EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
        }

        public static void Sync_Get_Data()
        {
            //Sync            
            Hashtable htPara = new Hashtable();
            if (Collection.Parameters.ContainsKey("SYNC_SERVER"))
                htPara.Add("SERVER", Collection.Parameters["SYNC_SERVER"]);
            if (Collection.Parameters.ContainsKey("SYNC_DBSOURCE"))
                htPara.Add("DBSOURCE", Collection.Parameters["SYNC_DBSOURCE"]);
            if (Collection.Parameters.ContainsKey("SYNC_DBDEST"))
                htPara.Add("DBDEST", Collection.Parameters["SYNC_DBDEST"]);
            if (Collection.Parameters.ContainsKey("SYNC_USER"))
                htPara.Add("USER", Collection.Parameters["SYNC_USER"]);
            if (Collection.Parameters.ContainsKey("SYNC_PASS"))
                htPara.Add("PASS", Collection.Parameters["SYNC_PASS"]);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            //Begin Sync List
            string strSQLExec_List =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCLIST ORDER BY Stt";

            DataTable dtTranList = SQLExec.ExecuteReturnDt(strSQLExec_List);
            foreach (DataRow dr in dtTranList.Rows)
            {
                if ((bool)dr["IS_SEND"])
                {
                    htPara["TABLE_NAME"] = dr["Table_Name"].ToString();
                    htPara["NAM"] = Element.sysWorkingYear;
                    //EpointProcessBox.AddMessage("Sync List  ");
                    SQLExec.Execute("sp_Sync_Get_List", htPara, CommandType.StoredProcedure);
                }
            }

            //Begin Sync Voucher
            string strSQLExec_Voucher =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCVOUCHER ORDER BY Stt";

            DataTable dtTranVoucher = SQLExec.ExecuteReturnDt(strSQLExec_Voucher);
            foreach (DataRow dr in dtTranVoucher.Rows)
            {
                if ((bool)dr["IS_SEND"])
                {
                    htPara["MA_CT"] = dr["Ma_Ct"].ToString();
                    htPara["TABLE_NAME"] = dr["Table_Name"].ToString();
                    htPara["NAM"] = Element.sysWorkingYear;
                    //EpointProcessBox.AddMessage("Sync Voucher  ");
                    SQLExec.Execute("sp_Sync_Get_Voucher", htPara, CommandType.StoredProcedure);
                }
            }
            //EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
        }
    }
}
