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
	public partial class frmGroup_Edit : Epoint.Systems.Customizes.frmEdit
    {
		public frmGroup_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(this.btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(this.btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, ref DataRow drEdit)
        {
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			this.Text = (enuNew_Edit == enuEdit.New) ? "Thêm mới nhóm người dùng" : "Sửa nhóm người dùng";

			Common.ScaterMemvar(this, ref drEdit);

			this.LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName() { }

		private bool FormCheckValid()
		{
			if (this.txtMember_Name.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgCancel("Tên nhóm không được rỗng");
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref this.drEdit);

			if (!this.FormCheckValid())
				return false;

			if (!DataTool.SQLUpdate(base.enuNew_Edit, "SYSMEMBER", ref drEdit))                
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MEMBER_ID", drEdit);

			return true; 
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}


    }
}