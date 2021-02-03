using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btExit : Epoint.Systems.Controls.btControl
	{
		public btExit()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btExit
			// 
			this.Image = global::Epoint.Systems.Commons.Properties.Resources.Exit;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Size = new System.Drawing.Size(70, 23);
			this.Tag = "Exit";
			this.Text = "&Thoát";
			this.ResumeLayout(false);

		}

	}
}
