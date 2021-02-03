using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmSQLConnect : Epoint.Systems.Customizes.frmEdit
	{

		public frmSQLConnect()
		{
			InitializeComponent();

			chkAuthentication.CheckedChanged += new EventHandler(chkAuthentication_CheckedChanged);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load()
		{
			txtUser.Text = Common.GetBufferValue("TRANFER_USER");
			txtPassword.Text = Common.GetBufferValue("TRANFER_PASSWORD");
			chkAuthentication.Checked = (Common.GetBufferValue("TRANFER_AUTHENTICATION") == "1");

			groupBox1.Enabled = !chkAuthentication.Checked;

			this.ShowDialog();
		}

		void chkAuthentication_CheckedChanged(object sender, EventArgs e)
		{
			groupBox1.Enabled = !chkAuthentication.Checked;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			Common.SetBufferValue("TRANFER_USER", txtUser.Text);
			Common.SetBufferValue("TRANFER_PASSWORD", txtPassword.Text);
			Common.SetBufferValue("TRANFER_AUTHENTICATION", chkAuthentication.Checked ? "1" : "0");

			this.isAccept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
	}
}
