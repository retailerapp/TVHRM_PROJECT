using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
	public partial class frmDmCk_Edit : Epoint.Systems.Customizes.frmEdit
	{

		#region Phuong thuc

		public frmDmCk_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
		}        

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

            //Hien thi thong tin
            txtMa_DvCs.Text = Element.sysMa_DvCs.ToString();

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            //Ten_DvCs
            if (txtMa_DvCs.Text.Trim() != string.Empty)
            {
                lbtTen_DvCs.Text = DataTool.SQLGetNameByCode("SYSDMDVCS", "Ma_DvCs", "Ten_DvCs", txtMa_DvCs.Text.Trim());
                dicName.SetValue(lbtTen_DvCs.Name, lbtTen_DvCs.Text);
            }
            else
                lbtTen_DvCs.Text = string.Empty;

            //Ten_Ct
            if (txtMa_Ct.Text.Trim() != string.Empty)
            {
                txtTen_Ct.Text = DataTool.SQLGetNameByCode("SYSDMCT", "Ma_Ct", "Ten_Ct", txtMa_Ct.Text.Trim());
                dicName.SetValue(txtTen_Ct.Name, txtTen_Ct.Text);
            }
            else
                lbtTen_DvCs.Text = string.Empty;
		}
        void txtMa_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Ct.Text.Trim();
            bool bRequire = false;

            frmQuickLookup frmLookup = new frmQuickLookup("SYSDMCT", "DMCT");
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSDMCT", "Ma_Ct", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
                txtMa_Ct.Text = string.Empty;
            else
            {
                txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
                txtTen_Ct.Text = drLookup["Ten_Ct"].ToString();
            }

        }
		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSDMCK", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Ma_Ct", drEdit);

			return true;
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Ct.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgOk(Languages.GetLanguage("Ma_Ct") + " " +
								Languages.GetLanguage("Not_Null"));
				return false;
			}			
			return bvalid;
		}

		#endregion

		#region Su kien

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		#endregion

	}
}