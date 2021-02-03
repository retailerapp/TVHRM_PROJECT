using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btNew : Epoint.Systems.Controls.btControl
	{
		public btNew()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btNew
			// 
			this.Image = global::Epoint.Systems.Commons.Properties.Resources.Add;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Size = new System.Drawing.Size(70, 23);
			this.Tag = "New";
			this.Text = "&Thêm";
			this.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			this.ResumeLayout(false);

		}

	}
}
