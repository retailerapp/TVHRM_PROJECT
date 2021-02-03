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
	public partial class frmReportFilter_Edit : Epoint.Systems.Customizes.frmEdit
	{
		DataTable dtReportFilter;

		#region Phuong thuc
		public frmReportFilter_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.cboFilter_ID.TextChanged += new EventHandler(cboFilter_ID_TextChanged);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + ", " + this.Tag;

			if (enuNew_Edit == enuEdit.New)
			{
				drEdit["Table_Lookup"] = string.Empty;
				drEdit["Column_Lookup"] = string.Empty;
				drEdit["LookupKeyFilter"] = string.Empty;
				drEdit["LookupKeyValid"] = string.Empty;
				drEdit["Require"] = false;
			}

			Common.ScaterMemvar(this, ref drEdit);

			this.Build();

            this.BindingLanguage();
			this.ShowDialog();
		}

		private void Build()
		{
			cboFilter_ID.lstItem.Size = new Size(500, 300);
			cboFilter_ID.lstItem.strZone = "CBOFILTER_ID";
			cboFilter_ID.lstItem.BuildListView("Filter_ID, Filter_Label, Filter_Name, Type, InputMask, Width, Table_Lookup, Column_Lookup, LookupKeyFilter, LookupKeyValid, Require");
			cboFilter_ID.lstItem.Columns["Type"].Width = 0;
			cboFilter_ID.lstItem.Columns["InputMask"].Width = 0;
			cboFilter_ID.lstItem.Columns["Width"].Width = 0;
			cboFilter_ID.lstItem.Columns["Table_Lookup"].Width = 0;
			cboFilter_ID.lstItem.Columns["Column_Lookup"].Width = 0;
			cboFilter_ID.lstItem.Columns["LookupKeyFilter"].Width = 0;
			cboFilter_ID.lstItem.Columns["LookupKeyValid"].Width = 0;
			cboFilter_ID.lstItem.Columns["Require"].Width = 0;

			dtReportFilter = DataTool.SQLGetDataTable("SYSReportFilter", "", "Filter_ID <> ''", "Filter_ID");
			cboFilter_ID.lstItem.DataSource = dtReportFilter;
		}

		private bool FormCheckValid()
		{
			if (txtReport_ID.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgCancel("Report_Id không được rỗng");
				return false;
			}

			if (cboFilter_ID.Text.Trim() == string.Empty)
			{
				EpointMessage.MsgCancel("Filter_ID không được rỗng");
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "SYSREPORTFILTER", ref drEdit))
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

		void cboFilter_ID_TextChanged(object sender, EventArgs e)
		{
			if (cboFilter_ID.lviItem != null)
			{
				this.txtFilter_Label.Text = cboFilter_ID.lviItem.SubItems["Filter_Label"].Text;
				this.txtFilter_Name.Text = cboFilter_ID.lviItem.SubItems["Filter_Name"].Text;
				this.txtType.Text = cboFilter_ID.lviItem.SubItems["Type"].Text;
				this.txtInputMask.Text = cboFilter_ID.lviItem.SubItems["InputMask"].Text;
				this.numWidth.Value = Convert.ToInt32(cboFilter_ID.lviItem.SubItems["Width"].Text);
				//this.numColCustom.Value = Convert.ToInt32(cboFilter_ID.lviItem.SubItems["ColCustom"]);
				//this.numScale.Value = Convert.ToInt32(cboColumn_ID.lviItem.SubItems["Scale"].Text);
				this.txtTable_Lookup.Text = cboFilter_ID.lviItem.SubItems["Table_Lookup"].Text;
				this.txtColumn_Lookup.Text = cboFilter_ID.lviItem.SubItems["Column_Lookup"].Text;
				this.txtLookupKeyFilter.Text = cboFilter_ID.lviItem.SubItems["LookupKeyFilter"].Text;
				this.txtLookupKeyValid.Text = cboFilter_ID.lviItem.SubItems["LookupKeyValid"].Text;

				this.chkRequire.Checked = cboFilter_ID.lviItem.SubItems["Require"].Text == "false" ? false : true;
			}
		}

		#endregion		
        
	}
}