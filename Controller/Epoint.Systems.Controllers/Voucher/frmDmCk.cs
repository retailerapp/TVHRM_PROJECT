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
	public partial class frmDmCk : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

		private DataTable dtDmCk;
		private DataRow drCurrent;
		private BindingSource bdsDmCk = new BindingSource();
		private dgvControl dgvDmCk = new dgvControl();
        private string strMa_Ct = string.Empty;

		#endregion 						

		#region Contructor

		public frmDmCk()
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
        public void Load(string strMa_Ct)
        {
            this.strMa_Ct = strMa_Ct;

            this.Load();
        }		
		
		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvDmCk.Location = new Point(3, 3);
			dgvDmCk.Size = new Size(this.Size.Width - 22, this.Size.Height - 42);
			dgvDmCk.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			dgvDmCk.strZone = "DMCK";

			dgvDmCk.BuildGridView(this.isLookup);

			this.panel1.Controls.Add(dgvDmCk);
		}

		private void FillData()
		{
            //dtDmCk = DataTool.SQLGetDataTable("L00DmCk", null, null, null);
            dtDmCk = SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMCK ORDER BY Ma_Ct");

            bdsDmCk.DataSource = dtDmCk;
            dgvDmCk.DataSource = bdsDmCk;

            if (this.strMa_Ct != string.Empty)
                bdsDmCk.Filter = "Ma_Ct = '" + strMa_Ct + "'";
            
            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsDmCk;

            bdsDmCk.Position = 0;
		}		

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCk.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmCk.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCk.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCk.NewRow();

			frmDmCk_Edit frm = new frmDmCk_Edit();
            frm.Load(enuNew_Edit, ref drCurrent);

			//Accept
			if (frm.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCk.Position >= 0)
						dtDmCk.ImportRow(drCurrent);
					else
						dtDmCk.Rows.Add(drCurrent);

                    bdsDmCk.Position = bdsDmCk.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCk.Current).Row);

				dtDmCk.AcceptChanges();
			}
			else
				dtDmCk.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmCk.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmCk.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("SYSDMCK", drCurrent))
			{
				bdsDmCk.RemoveAt(bdsDmCk.Position);
				dtDmCk.AcceptChanges();
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

		private void ResizeEvent(object sender, EventArgs e)
		{
			dgvDmCk.ResizeGridView();
		}

		#endregion 
	}
}	