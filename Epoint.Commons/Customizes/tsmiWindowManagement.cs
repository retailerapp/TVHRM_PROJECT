using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;

namespace Epoint.Systems.Customizes
{
	public class TsmiWindowManagement : tsmiControl
	{
		private TsmiCascadeLayout tsmiCascadeLayout = new TsmiCascadeLayout();
		private TsmiTileHorizontal tsmiTileHorizontal = new TsmiTileHorizontal();
		private TsmiTileVertical tsmiTileVertical = new TsmiTileVertical();
		private TsmiArrangeIcons tsmiArrangeIcons = new TsmiArrangeIcons();
		private ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private TsmiCloseAllForm tsmiCloseAllForm = new TsmiCloseAllForm();

		public TsmiWindowManagement()
		{
			InitializeComponent();

			this.Name = "Window";
			this.Text = "Cửa sổ";
			this.Tag = "Window";
			this.Alignment = ToolStripItemAlignment.Right;
			this.RightToLeft = RightToLeft.Yes;
			this.Image = imageList1.Images[0];

			this.DropDownItems.Add(tsmiCascadeLayout);
			this.DropDownItems.Add(tsmiTileHorizontal);
			this.DropDownItems.Add(tsmiTileVertical);
			this.DropDownItems.Add(tsmiArrangeIcons);
			this.DropDownItems.Add(new ToolStripSeparator());
			this.DropDownItems.Add(tsmiCloseAllForm);

			tsmiCascadeLayout.Click += new EventHandler(MdiLayout_Click);
			tsmiTileHorizontal.Click += new EventHandler(MdiLayout_Click);
			tsmiTileVertical.Click += new EventHandler(MdiLayout_Click);
			tsmiArrangeIcons.Click += new EventHandler(MdiLayout_Click);
			tsmiCloseAllForm.Click += new EventHandler(tsmiCloseAllForm_Click);
		}

		public void AddMenuItemToWindowManagement(tsmiControl tsmi)
		{
			tsmiControl tsmi1 = new tsmiControl();
			tsmi1.ID = tsmi.ID;
			tsmi1.Name = tsmi.GetKey();
			tsmi1.Text = tsmi.Text;
			tsmi1.Tag = tsmi.Tag;
			tsmi1.English = tsmi.English;
			tsmi1.Vietnamese = tsmi.Vietnamese;
			tsmi1.Other = tsmi.Other;
			tsmi1.frmInstance = tsmi.frmInstance;
			tsmi1.bIs_Module = tsmi.bIs_Module;

			this.DropDownItems.Add(tsmi1);

			tsmi1.Click += new EventHandler(tsmiActiveMdiForm_Click);
			tsmi1.frmInstance.FormClosing += new FormClosingEventHandler(frmInstance_FormClosing);

			if (tsmi1.bIs_Module)
			{
				frmMain frmMain = (frmMain)this.Parent.FindForm();
				frmMain.ucModuleManagement.AddMenuItem(tsmi1);
			}

			if (this.Owner.Parent.FindForm().GetType().Name == "frmMain")
			{
				frmMain frm1 = (frmMain)this.Owner.Parent.FindForm();

				if (frm1.MdiChildren.Length > 0)
					frm1.pnlScreen.Visible = false;
			}
		}

		#region Events

		void MdiLayout_Click(object sender, EventArgs e)
		{
			tsmiControl msi = (tsmiControl)sender;

			switch (msi.Name)
			{
				case "ArrangeIcons":
					this.Parent.FindForm().LayoutMdi(MdiLayout.ArrangeIcons);
					break;
				case "Cascade":
					this.Parent.FindForm().LayoutMdi(MdiLayout.Cascade);
					break;
				case "TileHorizontal":
					this.Parent.FindForm().LayoutMdi(MdiLayout.TileHorizontal);
					break;
				case "TileVertical":
					this.Parent.FindForm().LayoutMdi(MdiLayout.TileVertical);
					break;
			}
		}

		void tsmiCloseAllForm_Click(object sender, EventArgs e)
		{
			foreach (Form frm in this.Parent.FindForm().MdiChildren)
			{
				frm.Close();
			}
		}

		void tsmiActiveMdiForm_Click(object sender, EventArgs e)
		{
			tsmiControl tsmiActivate = (tsmiControl)sender;

			if (tsmiActivate.frmInstance != null)
				tsmiActivate.frmInstance.Activate();
		}

		void frmInstance_FormClosing(object sender, FormClosingEventArgs e)
		{
			Form frm = (Form)sender;

			foreach (ToolStripItem tsmi in this.DropDownItems)
			{
				if (tsmi.GetType().ToString() == "Epoint.Systems.Controls.tsmiControl")
				{
					tsmiControl tsmi1 = (tsmiControl)tsmi;

					if (tsmi1.frmInstance != null)
					{
						if (tsmi1.frmInstance.Handle == frm.Handle)
						{
							this.DropDownItems.Remove(tsmi1);

							if (tsmi1.bIs_Module)
							{
								frmMain frmMain = (frmMain)this.Parent.FindForm();
								frmMain.ucModuleManagement.RemoveMenuItem(tsmi1);
							}

							break;
						}
					}
				}
			}

			if (this.Owner.Parent.FindForm().GetType().Name == "frmMain")
			{
				frmMain frm1 = (frmMain)this.Owner.Parent.FindForm();

				if (frm1.MdiChildren.Length <= 1)
					frm1.pnlScreen.Visible = true;
			}
		}

		#endregion

		#region Cac lop con

		private class TsmiCascadeLayout : tsmiControl
		{
			public TsmiCascadeLayout()
			{
				this.Name = MdiLayout.Cascade.ToString();
				this.Text = "Xếp tầng";
				this.Tag = "Cascade";
			}
		}

		private class TsmiTileHorizontal : tsmiControl
		{
			public TsmiTileHorizontal()
			{
				this.Name = MdiLayout.TileHorizontal.ToString();
				this.Text = "Xếp ngang";
				this.Tag = "Horizontal";
			}
		}

		private class TsmiTileVertical : tsmiControl
		{
			public TsmiTileVertical()
			{
				this.Name = MdiLayout.TileVertical.ToString();
				this.Text = "Xếp dọc";
				this.Tag = "Vertical";
			}
		}

		private class TsmiArrangeIcons : tsmiControl
		{
			public TsmiArrangeIcons()
			{
				this.Name = MdiLayout.ArrangeIcons.ToString();
				this.Text = "Xếp icon";
				this.Tag = "ArrangeIcons";
			}
		}

		private class TsmiCloseAllForm : tsmiControl
		{
			public TsmiCloseAllForm()
			{
				this.Name = "CloseAllForm";
				this.Text = "Đóng các form";
				this.Tag = "CloseAllForm";
			}
		}

		#endregion

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TsmiWindowManagement));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Windows.png");

		}
	}
}
