using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Customizes;
using Epoint.Systems.Controls;
using Epoint.Systems.Commons;
using Epoint.Systems.Elements;
using Microsoft.Win32;


namespace Epoint.Controllers
{
	public partial class frmUtility : frmBase
	{
		public frmUtility()
		{
			InitializeComponent();
		}

		public void Load()
		{
			this.Show();
		}

		private void lnkRemoteDesktop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string strFilePath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Local Settings", @"C:\") + @"\Temp\TeamViewer.exe";

            //if (!System.IO.File.Exists(strFilePath))
            //    System.IO.File.WriteAllBytes(strFilePath, Epoint.Resource.Resource.TeamViewerQS);

			System.Diagnostics.Process.Start(strFilePath);
		}
	}
}
