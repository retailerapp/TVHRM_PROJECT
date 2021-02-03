using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmLookup : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

		private DataTable dtTableLookup;
		private DataRow drCurrent;
		private BindingSource bdsTableLookup = new BindingSource();
		private dgvControl dgvTableLookup = new dgvControl();

		#endregion 						

		#region Contructor

        public frmLookup()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(KeyDownEvent);
			this.Resize += new EventHandler(ResizeEvent);
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}
		
		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvTableLookup.Location = new Point(2, 2);
			dgvTableLookup.Size = new Size(this.Size.Width - 20, this.Size.Height - 30);
			dgvTableLookup.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			dgvTableLookup.strZone = "TABLELOOKUP";

			dgvTableLookup.BuildGridView(this.isLookup);

			this.Controls.Add(dgvTableLookup);
		}

		private void FillData()
		{
			dtTableLookup = DataTool.SQLGetDataTable("SYSLOOKUP", null, null, null);

			bdsTableLookup.DataSource = dtTableLookup;
			dgvTableLookup.DataSource = bdsTableLookup;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsTableLookup;
			bdsTableLookup.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtTableLookup.Rows.Count - 1; i++)
				if (((string)dtTableLookup.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsTableLookup.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsTableLookup.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsTableLookup.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsTableLookup.Current).Row, ref drCurrent);
			else
				drCurrent = dtTableLookup.NewRow();

            frmLookup_Edit frm = new frmLookup_Edit();
			frm.Load(enuNew_Edit, ref drCurrent);

			//Accept
			if (frm.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsTableLookup.Position >= 0)
						dtTableLookup.ImportRow(drCurrent);
					else
						dtTableLookup.Rows.Add(drCurrent);

                    bdsTableLookup.Position = bdsTableLookup.Find("COLUMNID", drCurrent["COLUMNID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsTableLookup.Current).Row);

				dtTableLookup.AcceptChanges();
			}
			else
				dtTableLookup.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsTableLookup.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsTableLookup.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("SYSLOOKUP", drCurrent))
			{
				bdsTableLookup.RemoveAt(bdsTableLookup.Position);
				dtTableLookup.AcceptChanges();
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsTableLookup == null || bdsTableLookup.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsTableLookup.Current).Row;
			DataTable dtTemp = dtTableLookup.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void  EnterProcess()
		{
			if (bdsTableLookup.Position < 0)
				return;

            //if (isLookup && EnterValid())
            //{
            //    drLookup = ((DataRowView)bdsTableLookup.Current).Row;
            //    this.Close();
            //}
            //else
            //{
            //    drCurrent = ((DataRowView)bdsTableLookup.Current).Row;

            //    frmDmSoCt frmDmSoCt = new frmDmSoCt();
            //    frmDmSoCt.MdiParent = this.MdiParent;
            //    frmDmSoCt.Load((string)drCurrent["Ma_Ct"]);
				
            //    //Lam sao dung con tro o day den khi dong form se chay tiep
            //}
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

		private void ResizeEvent(object sender, EventArgs e)
		{
			dgvTableLookup.ResizeGridView();
		}

		#endregion 
	}
}	