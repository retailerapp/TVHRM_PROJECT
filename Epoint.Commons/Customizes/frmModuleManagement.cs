using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Elements;

namespace Epoint.Systems.Customizes
{
	public partial class frmModuleManagement : Form
	{
		public frmModuleManagement()
		{
			InitializeComponent();

			this.SetColor();
			this.btHide.Click += new EventHandler(btHide_Click);
			this.Load();
		}

		private new void Load()
		{
			frmMain frmmain = (frmMain)Element.frmMain;

			foreach (ListViewItem lvi in frmmain.ucModuleManagement.lvOpeningModule.Items)
			{
				lviOpeningModule lviModule = new lviOpeningModule();
				lviModule.tsmi = ((lviOpeningModule)lvi).tsmi;
				lviModule.Text = ((lviOpeningModule)lvi).Text;
				lviModule.ImageKey = "OpeningModule";

				this.lvOpeningModule.Items.Add(lviModule);
			}

			this.lvOpeningModule.MultiSelect = false;
			this.lvOpeningModule.Focus();

			if (lvOpeningModule.Items.Count > 0)
				lvOpeningModule.Items[0].Selected = true;
		}

		private void SetColor()
		{
			this.BackColor = System.Drawing.Color.FromArgb(255, 157, 185, 235);

			this.btHide.BackColor = Color.FromArgb(0, 255, 255, 255);

			this.lvOpeningModule.BackColor = System.Drawing.Color.FromArgb(255, 216, 228, 248);
		}

		void btHide_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);

			this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (lvOpeningModule.Items.Count == 0)
			{
				this.Close();
				return;
			}

			int iCurrentIndex = lvOpeningModule.SelectedIndices[0];
			int iNextIndex = lvOpeningModule.Items.Count - 1 > iCurrentIndex ? iCurrentIndex + 1 : 0;
			int iPreviousIndex = iCurrentIndex > 0 ? iCurrentIndex - 1 : lvOpeningModule.Items.Count - 1;

			switch (e.KeyCode)
			{
				case Keys.Q:
				case Keys.Down:					
					lvOpeningModule.Items[iNextIndex].Selected = true;
					break;

				case Keys.Up:
					lvOpeningModule.Items[iPreviousIndex].Selected = true;
					break;
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);

			if (!e.Control)
			{
				if (lvOpeningModule.SelectedIndices.Count > 0)
				{
					Element.frmActiveMain = ((lviOpeningModule)lvOpeningModule.SelectedItems[0]).tsmi.frmInstance;
				}

				this.Close();
			}
		}
	}
}
