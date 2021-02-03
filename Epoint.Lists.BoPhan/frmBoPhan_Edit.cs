using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Lists
{
    public partial class frmBoPhan_Edit : Epoint.Lists.frmEdit
	{
        #region Phuong thuc

		public frmBoPhan_Edit()
		{
			InitializeComponent();

			txtMa_Bp_Cha.Enter += new EventHandler(txtMa_Bp_Cha_Enter);
			txtMa_Bp_Cha.Validating += new CancelEventHandler(txtMa_Bp_Cha_Validating);
            txtTk_Cp.Validating += new CancelEventHandler(txtTk_Cp_Validating);
		}
		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //New: khi them moi thi khong can ke thua
            if (enuNew_Edit != enuEdit.New)
                Common.ScaterMemvar(this, ref drEdit);

            //Edit: Disable Ma_Bp
            if (enuNew_Edit == enuEdit.Edit)
                txtMa_Bp.Enabled = false;

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{

			if (txtMa_Bp_Cha.Text.Trim() != string.Empty)
			{
				lbtTen_Bp_Cha.Text = DataTool.SQLGetNameByCode("LIBOPHAN", "Ma_Bp", "Ten_Bp", txtMa_Bp_Cha.Text.Trim());
				dicName.Add(lbtTen_Bp_Cha.Name, lbtTen_Bp_Cha.Text);
			}
			else
				lbtTen_Bp_Cha.Text = string.Empty;

		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Bp.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Bp") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtTen_Bp.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Bp") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}			

            if (txtMa_Bp.Text.Trim() == txtMa_Bp_Cha.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Bp_Cha") + " " +
							  Languages.GetLanguage("Invalid"));
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "LIBOPHAN", ref drEdit))
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
            //        DataToolSync1.SQLUpdate(enuNew_Edit, "LIBOPHAN", ref drEdit);
            //    }
            //}
            ////----------------------

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //{
            //    DataTool.SQLChangeID("MA_BP", drEdit);

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
            //            DataToolSync1.SQLChangeID("MA_BP", drEdit);
            //        }
            //    }
            //    //----------------------
            //}

			return true;
		}
        #endregion

        #region Su kien

		private void txtMa_Bp_Cha_Enter(object sender, EventArgs e)
		{
			lbtTen_Bp_Cha.Text = dicName.GetValue(lbtTen_Bp_Cha.Name);
		}

		void txtMa_Bp_Cha_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp_Cha.Text.Trim();
			bool bRequire = false;

			frmBoPhan frmLookup = new frmBoPhan();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIBOPHAN", "Ma_Bp", strValue, bRequire, "Nh_Cuoi = 0");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp_Cha.Text = string.Empty;
				lbtTen_Bp_Cha.Text = string.Empty;
			}
			else
			{
				txtMa_Bp_Cha.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTen_Bp_Cha.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}

			dicName.SetValue(lbtTen_Bp_Cha.Name, lbtTen_Bp_Cha.Text);
		}

        void txtTk_Cp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Cp.Text.Trim();
            bool bRequire = false;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
            DataRow drLookup = Lookup.ShowLookup( "Tk", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_Cp.Text = string.Empty;
                lbtTk_Cp.Text = string.Empty;
            }
            else
            {
                txtTk_Cp.Text = ((string)drLookup["Tk"]).Trim();
                lbtTk_Cp.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }

            dicName.SetValue(lbtTk_Cp.Name, lbtTk_Cp.Text);
        }
        #endregion 
	}
}