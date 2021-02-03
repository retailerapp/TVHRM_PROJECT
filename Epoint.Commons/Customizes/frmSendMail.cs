using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Systems.Customizes
{
	public partial class frmChart : Epoint.Systems.Customizes.frmView
	{
        public string strFileName = string.Empty;
        public string strFileType = string.Empty;
        private string strTen_Bc = string.Empty;

		public frmChart()
		{
			InitializeComponent();
		}		

		public void Load(DataRow drReport, DataRow drFilter, DataTable dtChartSource, dgvControl dgvChartSource)
		{
			
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			
			
			base.OnKeyDown(e);
		}
	}
}
