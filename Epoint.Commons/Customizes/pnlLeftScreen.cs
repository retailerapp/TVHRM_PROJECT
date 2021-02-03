using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Text;

namespace Epoint.Systems.Customizes
{
	public class pnlLeftScreen : Epoint.Systems.Controls.pnlControl
	{

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);

			Graphics g = e.Graphics;
			Rectangle rtg = new Rectangle(0, 0, this.Width, this.Height);

			if (this.Width > 0 && this.Height > 0)
			{
				Color Color1 = Color.FromArgb(255, 216, 228, 248); //System.Drawing.SystemColors.InactiveCaptionText;
				Color Color2 = Color.FromArgb(255, 122, 150, 223); //System.Drawing.SystemColors.InactiveCaption;

				System.Drawing.Drawing2D.LinearGradientBrush br = new LinearGradientBrush(rtg, Color1, Color2, LinearGradientMode.Vertical);

				g.FillRectangle(br, rtg);
			}

		}

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
		{
			//base.OnPaintBackground(e);
			Graphics g = e.Graphics;
			Rectangle rtg = new Rectangle(0, 0, this.Width, this.Height);

			if (this.Width > 0 && this.Height > 0)
			{
				Color Color1 = Color.FromArgb(255, 216, 228, 248); //System.Drawing.SystemColors.InactiveCaptionText;
				Color Color2 = Color.FromArgb(255, 122, 150, 223); //System.Drawing.SystemColors.InactiveCaption;

				System.Drawing.Drawing2D.LinearGradientBrush br = new LinearGradientBrush(rtg, Color1, Color2, LinearGradientMode.Vertical);

				g.FillRectangle(br, rtg);
			}
		}
	}
	
}
