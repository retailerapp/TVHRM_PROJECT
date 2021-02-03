using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Epoint.Systems.Customizes
{
	public partial class ucBluePointInfo : Epoint.Systems.Controls.ucControl
	{
		public ucBluePointInfo()
		{
			InitializeComponent();

			this.BorderColor = SystemColors.GradientInactiveCaption;

			this.linkWebsite.LinkClicked += new LinkLabelLinkClickedEventHandler(linkWebsite_LinkClicked);
			this.linkEmail.LinkClicked += new LinkLabelLinkClickedEventHandler(linkEmail_LinkClicked);
		}

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);

			if (this.pictureBox1.Image == null)
				this.pictureBox1.Visible = false;
		}

		void linkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//System.Diagnostics.Process.Start("outlook.exe");
			System.Diagnostics.Process.Start("mailto:bluepointsoft@live.com");
		}

		void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("");
		}
	}
}
