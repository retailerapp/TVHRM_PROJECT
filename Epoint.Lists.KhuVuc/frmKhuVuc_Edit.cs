using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Lists
{
	public partial class frmKhuVuc_Edit : Epoint.Lists.frmEdit
	{

        #region Phuong thuc

		public frmKhuVuc_Edit()
		{
			InitializeComponent();

            txtMa_Kv_Cha.Validating += new CancelEventHandler(txtMa_Kv_Cha_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //New: khi them moi thi khong can ke thua
            if (enuNew_Edit != enuEdit.New)
                Common.ScaterMemvar(this, ref drEdit);

            //Edit: Disable Ma_Kv
            if (enuNew_Edit == enuEdit.Edit)
                txtMa_Kv.Enabled = false;

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Kv.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Kv") + " " +
							  Languages.GetLanguage("Not_Null"));
                
				return false;

            }			

			if (txtTen_Kv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Kv") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "LIKHUVUC", ref drEdit))
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
            //        DataToolSync1.SQLUpdate(enuNew_Edit, "LIKHUVUC", ref drEdit);
            //    }
            //}
            ////----------------------

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //{
            //    DataTool.SQLChangeID("MA_KV", drEdit);

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
            //            DataToolSync1.SQLChangeID("MA_KV", drEdit);
            //        }
            //    }
            //    //----------------------

            //}

			return true;
		}
        #endregion

        #region Su kien
        void txtMa_Kv_Cha_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kv_Cha.Text.Trim();
            bool bRequire = false;

            frmKhuVuc frmLookup = new frmKhuVuc();
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHUVUC", "Ma_Kv", strValue, bRequire, "Nh_Cuoi = 0");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Kv_Cha.Text = string.Empty;
                lbtTen_Kv_Cha.Text = string.Empty;
            }
            else
            {
                txtMa_Kv_Cha.Text = ((string)drLookup["Ma_Kv"]).Trim();
                lbtTen_Kv_Cha.Text = ((string)drLookup["Ten_Kv"]).Trim();
            }

            dicName.SetValue(lbtTen_Kv_Cha.Name, lbtTen_Kv_Cha.Text);
        }
        #endregion 

	}
}