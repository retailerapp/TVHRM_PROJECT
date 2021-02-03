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
	public partial class frmDmCt : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

		private DataTable dtDmCt;
		private DataRow drCurrent;
		private BindingSource bdsDmCt = new BindingSource();
		private dgvControl dgvDmCt = new dgvControl();

		#endregion 						

		#region Contructor

		public frmDmCt()
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
			dgvDmCt.Location = new Point(3, 3);
			dgvDmCt.Size = new Size(this.Size.Width - 22, this.Size.Height - 42);
			dgvDmCt.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			dgvDmCt.strZone = "DMCT";

			dgvDmCt.BuildGridView(this.isLookup);

			this.panel1.Controls.Add(dgvDmCt);
		}

		private void FillData()
		{
			dtDmCt = DataTool.SQLGetDataTable("SYSDMCT", null, null, null);

			bdsDmCt.DataSource = dtDmCt;
			dgvDmCt.DataSource = bdsDmCt;

			//Search
			bdsSearch = bdsDmCt;
			bdsDmCt.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmCt.Rows.Count - 1; i++)
				if (((string)dtDmCt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmCt.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmCt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCt.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCt.NewRow();

			frmDmCt_Edit frm = new frmDmCt_Edit();
			frm.Load(enuNew_Edit, ref drCurrent);

			//Accept
			if (frm.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCt.Position >= 0)
						dtDmCt.ImportRow(drCurrent);
					else
						dtDmCt.Rows.Add(drCurrent);

					bdsDmCt.Position = bdsDmCt.Find("MA_CT", drCurrent["MA_CT"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCt.Current).Row);

				dtDmCt.AcceptChanges();
			}
			else
				dtDmCt.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmCt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmCt.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("SYSDMCT", drCurrent))
			{
				bdsDmCt.RemoveAt(bdsDmCt.Position);
				dtDmCt.AcceptChanges();
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmCt == null || bdsDmCt.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmCt.Current).Row;
			DataTable dtTemp = dtDmCt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void  EnterProcess()
		{
			if (bdsDmCt.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmCt.Current).Row;
				this.Close();
			}
			else
			{
				drCurrent = ((DataRowView)bdsDmCt.Current).Row;

				frmDmSoCt frmDmSoCt = new frmDmSoCt();
				frmDmSoCt.MdiParent = this.MdiParent;
				frmDmSoCt.Load((string)drCurrent["Ma_Ct"]);
                Common.AddFormOnCurentTab(frmDmSoCt);
				
				//Lam sao dung con tro o day den khi dong form se chay tiep
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
                    return;
                
                case Keys.F12:
                    if (bdsDmCt.Position < 0)
                        return;

                    if (isLookup && EnterValid())
                    {
                        drLookup = ((DataRowView)bdsDmCt.Current).Row;
                        this.Close();
                    }
                    else
                    {
                        drCurrent = ((DataRowView)bdsDmCt.Current).Row;

                        frmDmMauCt frmDmMauCt = new frmDmMauCt();
                        frmDmMauCt.MdiParent = this.MdiParent;
                        frmDmMauCt.Load((string)drCurrent["Ma_Ct"]);                        
                    }
					break;
			}
		}

		private void ResizeEvent(object sender, EventArgs e)
		{
			dgvDmCt.ResizeGridView();
		}

		#endregion 
	}
}	