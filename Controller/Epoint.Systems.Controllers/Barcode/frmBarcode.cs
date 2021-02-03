using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;
using Epoint.Systems.Controls;

namespace Epoint.Controllers
{
	public partial class frmBarcode : Epoint.Systems.Customizes.frmView
	{
		private DataTable dtVatTu;
		private BindingSource bdsVatTu = new BindingSource();
		private dgvControl dgvVatTu = new dgvControl();
		private DataRow drCurrent;

        public frmBarcode()
		{
			InitializeComponent();
            this.dgvVatTu.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvVatTu_CellMouseDoubleClick);
		}

        

		public override void Load()
		{
			this.Build();
			this.FillData();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}

		#region EnterProcess

        void dgvVatTu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            this.Edit(enuEdit.Edit);

        }

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsVatTu == null || bdsVatTu.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsVatTu.Current).Row;
			DataTable dtTemp = dtVatTu.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsVatTu.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsVatTu.Current).Row;
				this.Close();
			}
		}

		#endregion 

		private void Build()
		{
			dgvVatTu.ReadOnly = true;
			dgvVatTu.strZone = "VATTU";
			dgvVatTu.Dock = DockStyle.Fill;

			this.Controls.Add(dgvVatTu);

			dgvVatTu.BuildGridView();
		}

		private void FillData()
		{
            dtVatTu = DataTool.SQLGetDataTable("LIVATTU", null, "", "Ma_VT");

			bdsVatTu.DataSource = dtVatTu;
			dgvVatTu.DataSource = bdsVatTu;

            this.bdsSearch = bdsVatTu;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
            if (bdsVatTu.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            if (bdsVatTu.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsVatTu.Current).Row, ref drCurrent);
            else
                drCurrent = dtVatTu.NewRow();

            frmBarcode_Edit frmEdit = new frmBarcode_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);
		}

		public override void Delete()
		{
			
		}
	}
}
