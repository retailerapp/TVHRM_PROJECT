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
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmDmDvCs_Edit : Epoint.Systems.Customizes.frmEdit
	{
        #region Phuong thuc

		public frmDmDvCs_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
			this.BindingLanguage();
			this.ShowDialog();
		}		

		private bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_DvCs.Text.Trim() == string.Empty)
            {
				MessageBox.Show(" Mã đơn vị cơ sở không được rỗng ");
                return false;
            }			

			if (txtTen_DvCs.Text.Trim() == string.Empty)
			{
				MessageBox.Show(" Tên đơn vị cơ sở không được rỗng ");
				return false;
			}

			if (txtMa_Data.Text.Trim() == string.Empty)
			{
				MessageBox.Show(" Mã data không được rỗng ");
				return false;
			}

            return bvalid;
        }

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu vao CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSDMDVCS", ref drEdit))
				return false;

			return true;
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