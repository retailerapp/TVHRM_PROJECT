using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
	public partial class ucMa_DvCs : UserControl
	{
		public ucMa_DvCs()
		{
			InitializeComponent();

			this.cboMa_DvCs.TextChanged += new EventHandler(cboMa_DvCs_TextChanged);

			this.Load();
		}

		new public void Load()
		{
			this.cboMa_DvCs.lstItem.Width = 300;		

			this.cboMa_DvCs.lstItem.BuildListView("Ma_DvCs, Ten_DvCs, Ma_Data");

			DataTable dtDmDvCs = Data.SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMDVCS ORDER BY Ma_DvCs");

			this.cboMa_DvCs.lstItem.FillListView(dtDmDvCs);			
		}

		private void SetTen_DvCs()
		{
			if (this.lbtTen_DvCs.Text.Trim() == string.Empty) //Truong hop chua co Ten_DvCs
				this.cboMa_DvCs.SetValueManual();

			if (this.cboMa_DvCs.lviItem == null)
				return;

			if (this.cboMa_DvCs.Text.Trim() == this.cboMa_DvCs.lviItem.Text.Trim())
				this.lbtTen_DvCs.Text = this.cboMa_DvCs.lviItem.SubItems["Ten_DvCs"].Text;
		}

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);

			if (this.cboMa_DvCs.Text == string.Empty)
				this.cboMa_DvCs.Text = Elements.Element.sysMa_DvCs;

			this.SetTen_DvCs();
		}

		void cboMa_DvCs_TextChanged(object sender, EventArgs e)
		{
			this.SetTen_DvCs();
		}
	}
}
