using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btPrint : Epoint.Systems.Controls.btControl
	{
		public btPrint()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btPrint
			// 
			this.Image = global::Epoint.Systems.Commons.Properties.Resources.print_48;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Tag = "Print";
			this.Text = "&In";
			this.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			this.ResumeLayout(false);

		}
	}
}
