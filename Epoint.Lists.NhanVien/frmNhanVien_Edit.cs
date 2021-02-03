using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Systems.Elements;

namespace Epoint.Lists
{
	public partial class frmNhanVien_Edit : Epoint.Lists.frmEdit
	{	

		#region Phuong thuc

		public frmNhanVien_Edit()
		{
			InitializeComponent();

			txtMa_Bp.Enter += new EventHandler(txtMa_Bp_Enter);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Ca.Validating += new CancelEventHandler(txtMa_Ca_Validating);
            txtMa_Dt_Tu.Validating += new CancelEventHandler(txtMa_Dt_Tu_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //New: khi them moi thi khong can ke thua
            if (enuNew_Edit != enuEdit.New)
                Common.ScaterMemvar(this, ref drEdit);

            //Edit: Disable Ma_CbNv
            if (enuNew_Edit == enuEdit.Edit)
                txtMa_CbNv.Enabled = false;
						
			BindingLanguage();
            LoadDicName();

			this.ShowDialog();
		}

		public void LoadDicName()
		{
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("LIBOPHAN", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
				dicName.Add(lbtTen_Bp.Name, lbtTen_Bp.Text);
			}
			else
				lbtTen_Bp.Text = string.Empty;

            if (txtMa_Ca.Text.Trim() != string.Empty)
            {
                lbtTen_Ca.Text = DataTool.SQLGetNameByCode("LICA", "Ma_Ca", "Ten_Ca", txtMa_Ca.Text.Trim());
                dicName.Add(lbtTen_Ca.Name, lbtTen_Ca.Text);
            }
            else
                lbtTen_Ca.Text = string.Empty;
            
            if (txtMa_Dt_Tu.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_Tu.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt_Tu.Text.Trim());
                dicName.Add(lbtTen_Dt_Tu.Name, lbtTen_Dt_Tu.Text);
            }
            else
                lbtTen_Dt_Tu.Text = string.Empty;
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}			

			if (txtTen_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_CbNv") + " " +
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

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LINHANVIEN", ref drEdit))
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
            //        DataToolSync1.SQLUpdate(enuNew_Edit, "LINHANVIEN", ref drEdit);
            //    }
            //}
            ////----------------------

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //{
            //    DataTool.SQLChangeID("MA_CBNV", drEdit);

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
            //            DataToolSync1.SQLChangeID("MA_CBNV", drEdit);
            //        }
            //    }
            //    //----------------------

            //}

			return true;
		}

		#endregion 

		#region Su kien

		private void txtMa_Bp_Enter(object sender, EventArgs e)
		{
			lbtTen_Bp.Text = dicName.GetValue(lbtTen_Bp.Name);
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

            //frmBoPhan frmLookup = new frmBoPhan();
			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{				
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTen_Bp.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}

			dicName.SetValue(lbtTen_Bp.Name, lbtTen_Bp.Text);
		}

        void txtMa_Ca_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Ca.Text.Trim();
            bool bRequire = false;

            //frmCa frmLookup = new frmCa();
            DataRow drLookup = Lookup.ShowLookup("Ma_Ca", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                lbtTen_Ca.Text = string.Empty;
            }
            else
            {
                txtMa_Ca.Text = ((string)drLookup["Ma_Ca"]).Trim();
                lbtTen_Ca.Text = ((string)drLookup["Ten_Ca"]).Trim();
            }

            dicName.SetValue(lbtTen_Ca.Name, lbtTen_Ca.Text);
        }

        void txtMa_Dt_Tu_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Tu.Text.Trim();
            bool bRequire = false;

            //frmDoiTuong frmLookup = new frmDoiTuong();
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                lbtTen_Dt_Tu.Text = string.Empty;                
            }
            else
            {
                txtMa_Dt_Tu.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt_Tu.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }

            dicName.SetValue(lbtTen_Dt_Tu.Name, lbtTen_Dt_Tu.Text);
        }

		#endregion
	}
}