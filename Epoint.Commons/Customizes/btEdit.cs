using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btEdit : Epoint.Systems.Controls.btControl
	{
		public btEdit()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btEdit
			// 
            this.Image = global::Epoint.Systems.Commons.Properties.Resources.Edit;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Size = new System.Drawing.Size(70, 23);
			this.Tag = "Edit";
			this.Text = "&Sửa";
			this.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			this.ResumeLayout(false);

		}

	}
}
