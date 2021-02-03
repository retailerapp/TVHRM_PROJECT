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
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
	public partial class frmChangeID : Epoint.Systems.Customizes.frmView
	{

		#region Khai bao bien

		private DataTable dtChangeID;
		private DataRow drCurrent;
		private BindingSource bdsChangeID = new BindingSource();
		private dgvControl dgvChangeID = new dgvControl();

		#endregion

		#region Contructor

		public frmChangeID()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(KeyDownEvent);
			this.dgvChangeID.Resize += new EventHandler(dgvChangeID_Resize);
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvChangeID.Dock = DockStyle.Fill;

			dgvChangeID.strZone = "CHANGEID";
			dgvChangeID.BuildGridView(false);

			this.Controls.Add(dgvChangeID);
		}

		private void FillData()
		{
			dtChangeID = DataTool.SQLGetDataTable("SYSGOPMA", "", "", "Column_Type");

			bdsChangeID.DataSource = dtChangeID;
			dgvChangeID.DataSource = bdsChangeID;
			bdsChangeID.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsChangeID;
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsChangeID.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsChangeID.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsChangeID.Current).Row, ref drCurrent);
			else
				drCurrent = dtChangeID.NewRow();

			frmChangeID_Edit frmEdit = new frmChangeID_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsChangeID.Position >= 0)
						dtChangeID.ImportRow(drCurrent);
					else
						dtChangeID.Rows.Add(drCurrent);

					bdsChangeID.Position = bdsChangeID.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsChangeID.Current).Row);

				dtChangeID.AcceptChanges();
			}
			else
				dtChangeID.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsChangeID.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsChangeID.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("SYSGOPMA", drCurrent))
			{
				bdsChangeID.RemoveAt(bdsChangeID.Position);
				dtChangeID.AcceptChanges();
			}
		}

		#endregion
		
		#region Su kien

		void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Delete();
					break;
			}
		}

		void dgvChangeID_Resize(object sender, EventArgs e)
		{
			this.dgvChangeID.ResizeGridView();
		}

		#endregion
	}
}
