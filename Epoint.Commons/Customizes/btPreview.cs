using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btPreview : Controls.btControl
	{
		public btPreview()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btPreview
			// 
			this.Image = global::Epoint.Systems.Commons.Properties.Resources.Preview;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Size = new System.Drawing.Size(70, 23);
			this.Tag = "Preview";
			this.Text = "&Xem";
			this.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			this.ResumeLayout(false);

		}
	}
}
