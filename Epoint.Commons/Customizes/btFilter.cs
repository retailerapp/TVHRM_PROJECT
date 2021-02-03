using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btFilter : Epoint.Systems.Controls.btControl
	{
		public btFilter()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btFilter
			// 
			this.Image = global::Epoint.Systems.Commons.Properties.Resources.Filter;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Size = new System.Drawing.Size(70, 23);
			this.Tag = "Filter";
			this.Text = "&Lọc";
			this.ResumeLayout(false);

		}

	}
}
