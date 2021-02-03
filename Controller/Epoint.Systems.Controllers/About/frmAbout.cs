using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmAbout : Epoint.Systems.Customizes.frmView
	{
		public frmAbout()
		{
			InitializeComponent();			
		}
		public override void Load()
		{
			this.Show();
		}

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://epoint.com.vn");
        }        
	}
}
