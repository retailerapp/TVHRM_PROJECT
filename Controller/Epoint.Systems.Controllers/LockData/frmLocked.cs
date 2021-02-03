using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmLocked : Epoint.Systems.Customizes.frmView
	{
		#region Fields

		private DataTable dtDmNam;
		private DataTable dtLocked;

		private DataRow drDmNam;
		private DataRow drLocked;
		private DataRow drCurrent;

		private BindingSource bdsDmNam = new BindingSource();
		private BindingSource bdsLocked = new BindingSource();

		#endregion

		public frmLocked()
		{
			InitializeComponent();

			this.lvDmNam.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lvDmNam_ItemSelectionChanged);
			this.btSave.Click += new EventHandler(btSave_Click);

			this.chkLocked_SdHanTt.CheckedChanged += new EventHandler(chkLocked_SdHanTt_CheckedChanged);
			this.chkLocked_Sdk.CheckedChanged += new EventHandler(chkLocked_Sdk_CheckedChanged);
			this.chkLocked_Sdv.CheckedChanged += new EventHandler(chkLocked_Sdv_CheckedChanged);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			if (!Element.sysIs_Admin)
			{
				chkLocked_Sdv.Enabled = false;
				chkLocked_Sdk.Enabled = false;
				chkLocked_SdHanTt.Enabled = false;
			}

			this.Show();
		}

		private void Build()
		{
			this.lvDmNam.strZone = "NAM";
			this.lvDmNam.BuildListView("Nam");

			this.dgvLocked.strZone = "LOCKED";
			this.dgvLocked.BuildGridView();
			this.dgvLocked.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		}

		private void FillData()
		{
			dtDmNam = DataTool.SQLGetDataTable("SYSNAM", "", "Ma_DvCs = '" + Element.sysMa_DvCs + "'", "Nam");
			bdsDmNam.DataSource = dtDmNam;
			lvDmNam.DataSource = bdsDmNam;

			lvDmNam.SmallImageList = imageList1;
			foreach (ListViewItem lvi in lvDmNam.Items)
			{
				lvi.ImageIndex = 0;
			}

			dtLocked = DataTool.SQLGetDataTable("SYSLOCKED", "*, YEAR(Ngay_Locked1) AS Nam_Locked1, YEAR(Ngay_Locked2) AS Nam_Locked2", "Ma_DvCs = '" + Element.sysMa_DvCs + "'", "Ngay_Locked1,Ngay_Locked2");
			bdsLocked.DataSource = dtLocked;
			dgvLocked.DataSource = bdsLocked;

			if (this.lvDmNam.Items.Count > 0)
			{
				ListViewItem lvi = lvDmNam.FindItemWithText(Element.sysWorkingYear.ToString());

				if (lvi != null)
					lvi.Selected = true;
			}
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (!Element.sysIs_Admin)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "User " + Element.sysUser_Id + " have not right to lock data" : "Người dùng " + Element.sysUser_Id + " không có quyền khóa dữ liệu";
				EpointMessage.MsgCancel(strMsg);
				return;
			}
			
			if (this.tabControl1.SelectedTab != this.tabPage1)
				return;

			if (bdsLocked.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			if (bdsLocked.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsLocked.Current).Row, ref drCurrent);
			else
				drCurrent = dtLocked.NewRow();

			frmLocked_Edit frmEdit = new frmLocked_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent, Convert.ToInt32(lvDmNam.SelectedItems[0].Text));

			if (frmEdit.isAccept)
			{
				drCurrent["Nam_Locked1"] = ((DateTime)drCurrent["Ngay_Locked1"]).Year;
				drCurrent["Nam_Locked2"] = ((DateTime)drCurrent["Ngay_Locked2"]).Year;

				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsLocked.Position >= 0)
						dtLocked.ImportRow(drCurrent);
					else
						dtLocked.Rows.Add(drCurrent);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsLocked.Current).Row);

				dtLocked.AcceptChanges();
			}
			else
				dtLocked.RejectChanges();

		}

		public override void Delete()
		{
			if (bdsLocked.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsLocked.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("Sure_Delete")))
				return;

			if (DataTool.SQLDelete("SYSLOCKED", drCurrent))
			{
				bdsLocked.RemoveAt(bdsLocked.Position);
				dtLocked.AcceptChanges();
			}		
		}

		void lvDmNam_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.Item != null)
			{
				lvDmNam.MoveDataSourceToCurrentRow();
				drDmNam = ((DataRowView)bdsDmNam.Current).Row;

				int iNam = Convert.ToInt32(e.Item.Text);

				txtTh_Bd_Ht.Text = drDmNam["Th_Bd_Ht"].ToString();
				bdsLocked.Filter = "Nam_Locked1 = " + Convert.ToString(iNam) + " OR Nam_Locked2 = " + Convert.ToString(iNam);

				chkLocked_Sdk.Checked = (bool)drDmNam["Locked_Sdk"];
				chkLocked_Sdv.Checked = (bool)drDmNam["Locked_Sdv"];
				chkLocked_SdHanTt.Checked = (bool)drDmNam["Locked_SdHanTt"];
				btSave.Enabled = false;
			}
		}

		void btSave_Click(object sender, EventArgs e)
		{
			if (lvDmNam.SelectedItems.Count == 1)
			{
				lvDmNam.MoveDataSourceToCurrentRow();
				drDmNam = ((DataRowView)bdsDmNam.Current).Row;

				string iNam = lvDmNam.SelectedItems[0].Text;
				
				Hashtable htParameter = new Hashtable();
				htParameter.Add("LOCKED_SDK", chkLocked_Sdk.Checked);
				htParameter.Add("LOCKED_SDV", chkLocked_Sdv.Checked);
				htParameter.Add("LOCKED_SDHANTT", chkLocked_SdHanTt.Checked);
				htParameter.Add("NAM", iNam);
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

				string strSQLExec = 
					"UPDATE SYSNam SET " +
						" Locked_Sdk = @Locked_Sdk, Locked_Sdv = @Locked_Sdv, Locked_SdHanTt = @Locked_SdHanTt " +
						" WHERE Nam = @Nam AND Ma_DvCs = @Ma_DvCs";

				if (SQLExec.Execute(strSQLExec, htParameter, CommandType.Text))
				{
					drDmNam["Locked_Sdk"] = chkLocked_Sdk.Checked;
					drDmNam["Locked_Sdv"] = chkLocked_Sdv.Checked;
					drDmNam["Locked_SdHanTt"] = chkLocked_SdHanTt.Checked;
				}

				btSave.Enabled = false;
			}
		}

		void chkLocked_Sdv_CheckedChanged(object sender, EventArgs e)
		{
			btSave.Enabled = true;
		}

		void chkLocked_Sdk_CheckedChanged(object sender, EventArgs e)
		{
			btSave.Enabled = true;
		}

		void chkLocked_SdHanTt_CheckedChanged(object sender, EventArgs e)
		{
			btSave.Enabled = true;
		}
	}
}