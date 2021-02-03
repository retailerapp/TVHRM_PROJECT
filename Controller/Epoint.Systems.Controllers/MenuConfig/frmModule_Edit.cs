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
using Epoint.Systems.Commons;
using Epoint.Systems.Data;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
	public partial class frmModule_Edit : Epoint.Systems.Customizes.frmEdit
	{

		#region Phuong thuc
		public frmModule_Edit()
		{
			InitializeComponent();

            txtObject_ID.Enter += new EventHandler(txtObject_ID_Enter);
			txtObject_ID.Validating += new CancelEventHandler(txtObject_ID_Validating);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

            this.LoadDicName();

            this.BindingLanguage();
            this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			if (numModule_Id.Text == numModule_Parent.Text)
			{
				MessageBox.Show("Module cha không hợp lệ");
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu vao CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSMODULE", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Module_ID", drEdit);

			return true;
		}

		#endregion

		#region Su kien
        void txtObject_ID_Enter(object sender, EventArgs e)
        {
            lbtObject_Name.Text = dicName.GetValue(lbtObject_Name.Name);
        }
		void txtObject_ID_Validating(object sender, CancelEventArgs e)
		{
			//Lookup User
			string strValue = txtObject_ID.Text;
			bool bRequire = true;

			frmQuickLookup frmLookup = new frmQuickLookup("SYSObject", "OBJECT");
			Lookup.ShowLookup(frmLookup, "SYSObject", "Object_ID", strValue, bRequire, "");

			if (!frmLookup.bIsEnter)
				return;

			if (frmLookup.drLookup != null)
			{
				txtObject_ID.Text = (string)frmLookup.drLookup["Object_ID"];
				lbtObject_Name.Text = (string)frmLookup.drLookup["Object_Name"];
			}

            dicName.SetValue(lbtObject_Name.Name, lbtObject_Name.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
		}
        private void LoadDicName()
        {   
            //txtObject_ID
            if (txtObject_ID.Text.Trim() != string.Empty)
            {
                lbtObject_Name.Text = DataTool.SQLGetNameByCode("SYSObject", "Object_ID", "Object_Name", txtObject_ID.Text.Trim());
                dicName.SetValue(lbtObject_Name.Name, lbtObject_Name.Text);
            }
            else
                lbtObject_Name.Text = string.Empty;
        }
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