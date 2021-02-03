using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
	public partial class frmObject : Epoint.Systems.Customizes.frmView
	{
		DataTable dtObject;
		BindingSource bdsObject = new BindingSource();
		dgvControl dgvObject = new dgvControl();

		DataRow drCurrent;

		public frmObject()
		{
			InitializeComponent();
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		void Build()
		{
			dgvObject.strZone = "OBJECT";
			dgvObject.Dock = DockStyle.Fill;
			dgvObject.BuildGridView();

			this.Controls.Add(dgvObject);
		}

		void FillData()
		{
			dtObject = DataTool.SQLGetDataTable("SYSObject", "", "", "Object_ID");

			bdsObject.DataSource = dtObject;
			dgvObject.DataSource = bdsObject;

			bdsSearch = bdsObject;
			this.ExportControl = dgvObject;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsObject.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsObject.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsObject.Current).Row, ref drCurrent);
			else
				drCurrent = dtObject.NewRow();

			frmObject_Edit frm = new frmObject_Edit();
			frm.Load(enuNew_Edit, ref drCurrent);

			//Accept
			if (frm.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsObject.Position >= 0)
						dtObject.ImportRow(drCurrent);
					else
						dtObject.Rows.Add(drCurrent);

					bdsObject.Position = bdsObject.Find("Object_ID", drCurrent["Object_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsObject.Current).Row);

				dtObject.AcceptChanges();
			}
			else
				dtObject.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsObject.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsObject.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("SYSObject", drCurrent))
			{
				bdsObject.RemoveAt(bdsObject.Position);
				dtObject.AcceptChanges();
			}	
		}
	}
}
