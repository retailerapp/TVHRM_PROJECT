using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Epoint.Modules
{
	public partial class ucNotice : Epoint.Systems.Controls.ucControl
	{
		public ucNotice()
		{
			InitializeComponent();

			this.BorderColor = SystemColors.GradientInactiveCaption;
		}

		public string Text
		{
			get 
			{ 
				return this.lblNotice.Text; 
			}
			set 
			{ 
				this.lblNotice.Text = value; 
			}
		}

		public void SetText(string strNotice)
		{
			this.lblNotice.Text = strNotice;
		}

		public void SetText(string strID, string strDescription)
		{
			this.lblNotice.Text = strID.Trim() + " - " + strDescription.Trim();
		}
	}
}
