using System;
using System.Collections.Generic;
using System.Text;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;

namespace Epoint.Modules
{
	public class Opening
	{
		public static bool UpdateDuDauGL(frmOpening_Edit frmEdit)
		{
			if ((string)frmEdit.drEdit["Stt"] == string.Empty)
				return false;

			if (!DataTool.SQLUpdate(frmEdit.enuNew_Edit, "GLDUDAU", ref frmEdit.drEdit))
				return false;

			//Luu vao Queue
			bool bSaveQueue = false;
			if (bSaveQueue)
			{
				string strStt = (string)frmEdit.drEdit["Stt"];
				string strSpExec = "SP_CDK_UPDATE_SOCAI '" + strStt + "'";

				if (frmEdit.enuNew_Edit == enuEdit.Edit)
				{
					SQLExec.Execute("DELETE FROM SYSQUEUE WHERE Stt = '" + strStt + "'");
				}

				Common.SQLPushQueue(SQLExec.GetSQLCommand(), strSpExec, strStt);
			}

			return true;
		}

		public static bool UpdateDuDauIN(frmOpening_Edit frmEdit)
		{
			if ((string)frmEdit.drEdit["Stt"] == string.Empty)
				return false;

			if (!DataTool.SQLUpdate(frmEdit.enuNew_Edit, "INDUDAU", ref frmEdit.drEdit))
				return false;

			//Luu vao Queue
			bool bSaveQueue = false;
			if (bSaveQueue)
			{
				string strStt = (string)frmEdit.drEdit["Stt"];
				string strSpExec = "SP_CDV_UPDATE_THEKHO '" + strStt + "'";

				if (frmEdit.enuNew_Edit == enuEdit.Edit)
				{
					SQLExec.Execute("DELETE FROM SYSQUEUE WHERE Stt = '" + strStt + "'");
				}

				Common.SQLPushQueue(SQLExec.GetSQLCommand(), strSpExec, strStt);
			}

			return true;
		}

        public static bool UpdateDuDauINNTXT(frmOpening_Edit frmEdit)
        {
            if ((string)frmEdit.drEdit["Stt"] == string.Empty)
                return false;

            if (!DataTool.SQLUpdate(frmEdit.enuNew_Edit, "INDUDAUNTXT", ref frmEdit.drEdit))
                return false;

            //Luu vao Queue
            bool bSaveQueue = false;
            if (bSaveQueue)
            {
                string strStt = (string)frmEdit.drEdit["Stt"];
                string strSpExec = "SP_CDV_UPDATE_THEKHO '" + strStt + "'";

                if (frmEdit.enuNew_Edit == enuEdit.Edit)
                {
                    SQLExec.Execute("DELETE FROM SYSQUEUE WHERE Stt = '" + strStt + "'");
                }

                Common.SQLPushQueue(SQLExec.GetSQLCommand(), strSpExec, strStt);
            }

            return true;
        }
	}
}
