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
	public partial class frmColumn_Edit : Epoint.Systems.Customizes.frmEdit
	{
		#region Phuong thuc
		public frmColumn_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			this.cboColumn_ID.TextChanged += new EventHandler(cboColumn_ID_TextChanged);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.Build();

            this.BindingLanguage();
			this.ShowDialog();
		}

		private void Build()
		{
			cboColumn_ID.lstItem.Size = new Size(500, 300);
			cboColumn_ID.lstItem.strZone = "CBOCOLUMN_ID";
			cboColumn_ID.lstItem.BuildListView();

			DataTable dtColumns = DataTool.SQLGetDataTable("SYSCOLUMN", "", "Column_ID <> ''", "Column_ID");
			cboColumn_ID.lstItem.DataSource = dtColumns;			
		}

		private bool FormCheckValid()
		{
			if (txtZone.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgCancel("Vùng chứa cột không được rỗng");
				return false;
			}

			if (cboColumn_ID.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Column_ID, Cannot_Empty"));
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSCOLUMN", ref drEdit))
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

		void cboColumn_ID_TextChanged(object sender, EventArgs e)
		{
			if (cboColumn_ID.lviItem != null)
			{
				this.txtDescription.Text = cboColumn_ID.lviItem.SubItems["Description"].Text;
				this.numWidth.Value = Convert.ToInt32(cboColumn_ID.lviItem.SubItems["Width"].Text);
				this.numScale.Value = Convert.ToInt32(cboColumn_ID.lviItem.SubItems["Scale"].Text);
				this.enuType.Text = cboColumn_ID.lviItem.SubItems["Type"].Text.Trim();
				this.ChkResizable.Checked = cboColumn_ID.lviItem.SubItems["Resizable"].Text == "false" ? false : true;
				this.enuShow_Type.Text = cboColumn_ID.lviItem.SubItems["Show_Type"].Text.Trim();
			}
		}

		#endregion
		
	}
}