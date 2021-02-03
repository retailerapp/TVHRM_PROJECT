using System;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class btCancel : Epoint.Systems.Controls.btControl
	{
		public btCancel()
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
			// btCancel
			// 
            this.Image = global::Epoint.Systems.Commons.Properties.Resources.Exit;
			this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Tag = "Cancel";
			this.Text = "&Cancel";
			this.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			this.ResumeLayout(false);

		}

	}
}
