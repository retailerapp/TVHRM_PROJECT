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

namespace Epoint.Controllers
{
	public partial class frmDmDvCs_DefaultList_Edit : Epoint.Lists.frmEdit
	{		

        #region Phuong thuc

		public frmDmDvCs_DefaultList_Edit()
		{
			InitializeComponent();            
		}

        public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //New: khi them moi thi khong can ke thua
            if (enuNew_Edit != enuEdit.New)
                Common.ScaterMemvar(this, ref drEdit);

            //Edit: Disable Ma_Kho
            if (enuNew_Edit == enuEdit.Edit)
                txtMa_Dm.Enabled = false;

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
            if (txtMa_Dm.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Dm") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }			

			if (txtTen_Dm.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Dm") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSDMDVCS_DEFAULTLIST", ref drEdit))
				return false;
            
			return true;
		}
        #endregion

        #region Su kien
                
        #endregion		
	}
}