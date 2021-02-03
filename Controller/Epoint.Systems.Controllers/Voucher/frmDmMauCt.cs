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
	public partial class frmDmMauCt : Epoint.Systems.Customizes.frmView
	{
		#region Khai bao bien

		private DataTable dtDmMauCt;
		private DataRow drCurrent;
		private BindingSource bdsDmMauCt = new BindingSource();
		private dgvControl dgvDmMauCt = new dgvControl();
        private string strMa_Ct = string.Empty;

		#endregion 						

		#region Contructor

		public frmDmMauCt()
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
			dgvDmMauCt.Location = new Point(3, 3);
			dgvDmMauCt.Size = new Size(this.Size.Width - 12, this.Size.Height - 12);
			dgvDmMauCt.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			dgvDmMauCt.strZone = "DMMAUCT";

			dgvDmMauCt.BuildGridView(this.isLookup);

			this.Controls.Add(dgvDmMauCt);
		}

		private void FillData()
		{   
            dtDmMauCt = SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMMAUCT ORDER BY Stt, Ten_Mau");

            bdsDmMauCt.DataSource = dtDmMauCt;
            dgvDmMauCt.DataSource = bdsDmMauCt;

            if (this.strMa_Ct != string.Empty)
                bdsDmMauCt.Filter = "Ma_Ct = '" + strMa_Ct + "'";
            
            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsDmMauCt;

            bdsDmMauCt.Position = 0;
		}		

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmMauCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmMauCt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmMauCt.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmMauCt.NewRow();

			frmDmMauCt_Edit frm = new frmDmMauCt_Edit();
            frm.Load(enuNew_Edit, ref drCurrent);

			//Accept
			if (frm.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmMauCt.Position >= 0)
						dtDmMauCt.ImportRow(drCurrent);
					else
						dtDmMauCt.Rows.Add(drCurrent);

                    bdsDmMauCt.Position = bdsDmMauCt.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmMauCt.Current).Row);

				dtDmMauCt.AcceptChanges();
			}
			else
				dtDmMauCt.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmMauCt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmMauCt.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("SYSDMMAUCT", drCurrent))
			{
				bdsDmMauCt.RemoveAt(bdsDmMauCt.Position);
				dtDmMauCt.AcceptChanges();
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
			dgvDmMauCt.ResizeGridView();
		}

		#endregion 
	}
}	