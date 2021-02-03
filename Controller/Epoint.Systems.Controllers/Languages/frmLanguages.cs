using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmLanguages : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

		private DataRow drCurrent;
		private DataTable dtLanguages;
		private bdsControl bdsLanguages = new bdsControl();
		private tlControl tlLanguages = new tlControl();

		#endregion

		#region Contructor

		public frmLanguages()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(KeyDownEvent);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData
		private void Build()
		{
			tlLanguages.KeyFieldName = "LANGUAGE_ID";
			tlLanguages.ParentFieldName = "LANGUAGE_PARENT";
			tlLanguages.Dock = DockStyle.Fill;

			tlLanguages.strZone = "LANGUAGES";
			tlLanguages.BuildTreeList(this.isLookup);

			this.Controls.Add(tlLanguages);
		}

		private void FillData()
		{
			dtLanguages = DataTool.SQLGetDataTable("SYSLANGUAGE", null, null, null);
			bdsLanguages.DataSource = dtLanguages;

			//Uy quyen cho lop co so tim kiem
			bdsSearch = bdsLanguages;

			tlLanguages.DataSource = bdsLanguages;
			bdsLanguages.Position = 0;

			tlLanguages.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlLanguages.strZone + "'");
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{

			if (bdsLanguages.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsLanguages.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsLanguages.Current).Row, ref drCurrent);
			else
				drCurrent = dtLanguages.NewRow();


			frmLanguages_Edit frmEdit = new frmLanguages_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsLanguages.Position >= 0)
						dtLanguages.ImportRow(drCurrent);
					else
						dtLanguages.Rows.Add(drCurrent);

					bdsLanguages.Position = bdsLanguages.Find("LANGUAGE_ID", drCurrent["LANGUAGE_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsLanguages.Current).Row);

				dtLanguages.AcceptChanges();
			}
			else
				dtLanguages.RejectChanges();

		}

		public override void Delete()
		{
			if (bdsLanguages.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsLanguages.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("SYSLANGUAGE", drCurrent))
			{
				bdsLanguages.RemoveAt(bdsLanguages.Position);
				dtLanguages.AcceptChanges();
			}
		}

		#endregion

		#region Su kien

		private void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Delete();
					break;
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			Languages.FillLanguages();
		}

		#endregion
	}
}