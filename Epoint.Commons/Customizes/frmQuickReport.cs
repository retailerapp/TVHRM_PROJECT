using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataDynamics.ActiveReports;
using DataDynamics;
using DataDynamics.ActiveReports.Export;

using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems;

namespace Epoint.Systems.Customizes
{
	public partial class frmQuickReport : frmBase
	{
		private rptQuickReport repFile;			

		#region Method
		public frmQuickReport()
		{
			InitializeComponent();

			this.KeyPreview = true;
			this.KeyDown += new KeyEventHandler(frmQuickReport_KeyDown);
		}

		void frmQuickReport_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.S)
			{
				string strPath = Application.StartupPath + @"\Reports\";
				SaveFileDialog sfdlg = new SaveFileDialog();
				sfdlg.OverwritePrompt = true;
				sfdlg.InitialDirectory = strPath;
				sfdlg.DefaultExt = "rpx";
				sfdlg.Filter = "*.rpx|*.rpx";

				if (sfdlg.ShowDialog() != DialogResult.OK)
					return;

				strPath = sfdlg.FileName;
				if (repFile != null)
					repFile.SaveLayout(strPath);
			}

            if (e.KeyCode == Keys.Escape)
                this.Close();
		}		

		new public void Load(rptQuickReport repFile)
		{	
			this.repFile = repFile;			
			this.Print();

			this.Show();
		}

		private void Print()
		{				
			viewReport.Document = repFile.Document;
			
          
			repFile.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF");					
			repFile.Run();						
		}
		#endregion
	}
}