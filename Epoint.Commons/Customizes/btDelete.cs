using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btDelete : Epoint.Systems.Controls.btControl
	{
		public btDelete()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btDelete
			// 
            this.Image = global::Epoint.Systems.Commons.Properties.Resources.Delete;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Size = new System.Drawing.Size(70, 23);
			this.Tag = "Delete";
			this.Text = "&Xóa";
			this.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			this.ResumeLayout(false);

		}


	}
}
