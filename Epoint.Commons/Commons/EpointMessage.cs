using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;

namespace Epoint.Systems.Commons
{
    public class EpointMessage
    {
        public static string GetMessage(string strMessageID)
        {
            return GetMessage(strMessageID, (enuLanguageType)Element.sysLanguage);
        }
        public static string GetMessage(string strMessage, enuLanguageType enuLanguage)
        {
            DataTable dtMessage = DataTool.SQLGetDataTable("SYSMESSAGE", "", "MessageId = '" + strMessage + "'", "MessageId");

            if (dtMessage.Rows.Count == 0)
                return strMessage;
            if (enuLanguage == enuLanguageType.Vietnamese)
                return dtMessage.Rows[0]["Message"].ToString();
            if (enuLanguage == enuLanguageType.English)
                return dtMessage.Rows[0]["Message_E"].ToString();
            return strMessage;
        }

        /// <summary>
        /// Thông báo lựa chọn Yes_No, Yes: return true, No: return false
        /// </summary>
        /// <param name="strMsg">Chuỗi thông báo</param>
        /// <param name="strDefaultY_N">"Y" mặc định là chọn Yes, "N" mặc định là chọn No</param>
        /// <returns></returns>
        public static bool MsgYes_No(string strMsg)
        {
            if (MessageBox.Show(strMsg, "Message",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)

                return true;
            else
                return false;

        }
        public static bool MsgYes_No(string strMsg, string strDefaultY_N)
        {
            if (MessageBox.Show(strMsg, "Message",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        strDefaultY_N == "Y" ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                return true;
            else
                return false;

        }
        public static bool MsgYes_No_Cancel(string strMsg, string strDefaultY_N)
        {
            if (MessageBox.Show(strMsg, "Message",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question,
                        strDefaultY_N == "Y" ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                return true;
            else
                return false;

        }
        public static bool MsgOk(string strMsg)
        {
            MessageBox.Show(strMsg, "Message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None);

            return true;
        }

        public static bool MsgCancel(string strMsg)
        {
            MessageBox.Show(strMsg, "Message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

            return true;
        }
    }
}
