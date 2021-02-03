using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Elements;

namespace Epoint.Modules.KPI
{
	public partial class frmKPIType_Edit : Epoint.Lists.frmEdit
	{
		#region Phuong thuc

		public frmKPIType_Edit()
		{
			InitializeComponent();

		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //New: khi them moi thi khong can ke thua
            //if (enuNew_Edit != enuEdit.New)
            Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{

		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;			

			if (txtTypeID.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Code") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtDescr.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Descr") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			return bvalid;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "KPITYPE", ref drEdit))
				return false;

            ////Sync data-------------
            //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
            //if (Is_Sync == "1")
            //{
            //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
            //    if (sqlCon.State != ConnectionState.Open)
            //    {
            //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
            //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
            //        Common.MsgCancel(strMsg);
            //    }
            //    else
            //    {
            //        DataToolSync1.SQLUpdate(enuNew_Edit, "LIKHAC", ref drEdit);
            //    }
            //}
            ////----------------------

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //{
            //    DataTool.SQLChangeID("Type_ID", drEdit);

            //    //Sync data-------------            
            //    if (Is_Sync == "1")
            //    {
            //        SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
            //        if (sqlCon.State != ConnectionState.Open)
            //        {
            //            SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
            //            string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
            //            Common.MsgCancel(strMsg);
            //        }
            //        else
            //        {
            //            DataToolSync1.SQLChangeID("Type_ID", drEdit);
            //        }
            //    }
            //    //----------------------
            //}

			return true;
		}
		#endregion

		#region Su kien


		#endregion
	}
}