﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Elements;

namespace Epoint.Lists
{
    public partial class frmDoiTuongNh_Edit : Epoint.Lists.frmEdit
    {
        #region Phuong thuc
        private string strCode = string.Empty;

		public frmDoiTuongNh_Edit()
		{
			InitializeComponent();

			txtMa_Nh_Dt_Cha.Enter += new System.EventHandler(txtMa_Nh_Dt_Cha_Enter);
			txtMa_Nh_Dt_Cha.Validating += new CancelEventHandler(txtMa_Nh_Dt_Cha_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //New: khi them moi thi khong can ke thua
            if (enuNew_Edit != enuEdit.New)
                Common.ScaterMemvar(this, ref drEdit);
            
            this.strCode = txtMa_Nh_Dt.Text;

            //Edit: Disable Ma_Nh_Dt
            if (enuNew_Edit == enuEdit.Edit)
                txtMa_Nh_Dt.Enabled = false;

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
        }

		private void LoadDicName()
		{
			if (txtMa_Nh_Dt_Cha.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Dt_Cha.Text = DataTool.SQLGetNameByCode("LIDOITUONGNH", "Ma_Nh_Dt", "Ten_Nh_Dt", txtMa_Nh_Dt_Cha.Text.Trim());
				dicName.Add(lbtTen_Nh_Dt_Cha.Name, lbtTen_Nh_Dt_Cha.Text);
			}
			else
				lbtTen_Nh_Dt_Cha.Text = string.Empty;
		}
        
		public override bool FormCheckValid()
        {
            bool bvalid = true ;

            if (txtMa_Nh_Dt.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Dt") + " " +
								Languages.GetLanguage("Not_Null"));
				return false;

            }			

			if (txtTen_Nh_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Nh_Dt") + " " +
								Languages.GetLanguage("Not_Null"));
				return false;

			}

            if (txtMa_Nh_Dt.Text.Trim() == txtMa_Nh_Dt_Cha.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Dt_Cha") + " " +
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

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LIDOITUONGNH", ref drEdit))
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
            //        DataToolSync1.SQLUpdate(enuNew_Edit, "LIDOITUONGNH", ref drEdit);
            //    }
            //}
            ////----------------------

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit && this.strCode != txtMa_Nh_Dt.Text)
            //{
            //    DataTool.SQLChangeID("MA_NH_DT", drEdit);

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
            //            DataToolSync1.SQLChangeID("MA_NH_DT", drEdit);
            //        }
            //    }
            //    //----------------------

            //}

			return true;
		}
        #endregion

        #region Su kien

		void txtMa_Nh_Dt_Cha_Enter(object sender, EventArgs e)
		{
			lbtTen_Nh_Dt_Cha.Text = dicName.GetValue(lbtTen_Nh_Dt_Cha.Name);
		}
		void txtMa_Nh_Dt_Cha_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Dt_Cha.Text.Trim();
			bool bRequire = false;

			frmDoiTuongNh frmLookup = new frmDoiTuongNh();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONGNH", "Ma_Nh_Dt", strValue, bRequire, "Nh_Cuoi = 0");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Dt_Cha.Text = string.Empty;
				lbtTen_Nh_Dt_Cha.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Dt_Cha.Text = ((string)drLookup["Ma_Nh_Dt"]).Trim();
				lbtTen_Nh_Dt_Cha.Text = ((string)drLookup["Ten_Nh_Dt"]).Trim();
			}

			dicName.SetValue(lbtTen_Nh_Dt_Cha.Name, lbtTen_Nh_Dt_Cha.Text);
        }

        #endregion 
    }
}