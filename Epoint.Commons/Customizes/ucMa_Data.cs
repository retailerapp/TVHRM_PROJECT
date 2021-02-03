using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
	public partial class ucMa_Data : UserControl
	{
		public ucMa_Data()
		{
			InitializeComponent();

			this.cboMa_Data.TextChanged += new EventHandler(cboMa_Data_TextChanged);

			if (Elements.Element.Is_Running)
				this.Load();
		}
        
		new public void Load()
		{
			this.cboMa_Data.lstItem.Width = 300;
			this.cboMa_Data.lstItem.strZone = "CBOMA_DATA";

			this.cboMa_Data.lstItem.BuildListView();

			DataTable dtDmDvCs = Data.SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMDVCS ORDER BY Ma_DvCs");

			this.cboMa_Data.lstItem.FillListView(dtDmDvCs);

			if ((string)Librarys.Parameters.GetParaValue("AUTO_DEFAULT_MA_DATA") == "1")
				this.cboMa_Data.Text = "*";
			else
				this.cboMa_Data.Text = Elements.Element.sysMa_Data;
		}

		private void SetTen_DvCs()
		{
			if (this.lbtTen_DvCs.Text.Trim() == string.Empty) //Truong hop chua co Ten_DvCs
				this.cboMa_Data.SetValueManual();

			if (this.cboMa_Data.lviItem == null)
				return;

			if (this.cboMa_Data.Text.Trim() == this.cboMa_Data.lviItem.Text.Trim())
				this.lbtTen_DvCs.Text = this.cboMa_Data.lviItem.SubItems["Ten_DvCs"].Text;
		}

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);

			if (this.cboMa_Data.Text == string.Empty)
				this.cboMa_Data.Text = Elements.Element.sysMa_Data;

			this.SetTen_DvCs();
		}

		void cboMa_Data_TextChanged(object sender, EventArgs e)
		{
			this.SetTen_DvCs();
		}
	}
}
