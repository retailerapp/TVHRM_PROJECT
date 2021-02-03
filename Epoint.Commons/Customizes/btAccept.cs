using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btAccept : Epoint.Systems.Controls.btControl
	{
		public btAccept()
		{
			InitializeComponent();
		}
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Commons.Common.CloseCurrentFormNull();
        }
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// btAccept
			// 
            this.Image = global::Epoint.Systems.Commons.Properties.Resources.accepted1;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Tag = "Accept";
			this.Text = "Đồ&ng ý";
			this.ResumeLayout(false);

		}

	}
}
