using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmCheckData : Epoint.Systems.Customizes.frmView
	{
		DataTable dtCheckData;
		DataTable dtCheckDataLogic;

		BindingSource bdsCheckData = new BindingSource();
		BindingSource bdsCheckDataLogic = new BindingSource();

		DataRow drCurrent;

		public frmCheckData()
		{
			InitializeComponent();

			btRun.Click += new EventHandler(btRun_Click);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.BindingLanguage();

			this.dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			this.dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			this.Show();
		}

		void Build()
		{
			dgvCheckData.strZone = "CHECKDATA";
			dgvCheckData.BuildGridView();

			dgvCheckDataLogic.strZone = "CHECKDATALOGIC";
			dgvCheckDataLogic.BuildGridView();
		}

		void FillData()
		{
			if ((int)SQLExec.ExecuteReturnValue("SELECT COUNT(Name) FROM sys.Tables WHERE Name = 'SYSCheckData'") > 0)
			{
				dtCheckDataLogic = DataTool.SQLGetDataTable("SYSCheckData", "", "", "Stt");
				bdsCheckDataLogic.DataSource = dtCheckDataLogic;

				dgvCheckDataLogic.DataSource = bdsCheckDataLogic;
			}
		}

		public void Edit()
		{
			if (bdsCheckData.Position < 0)
				return;

			if (!dtCheckData.Columns.Contains("Stt") || !dtCheckData.Columns.Contains("Ma_Ct"))
				return;

			DataRow drCurrent = ((DataRowView)bdsCheckData.Current).Row;

			if (((string)drCurrent["Stt"]).Trim() == string.Empty || ((string)drCurrent["Ma_Ct"]).Trim() == string.Empty)
				return;

			DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);

			string strMethodName = (string)drDmCt["Edit_Voucher_Method"];

			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				EpointMessage.MsgCancel("Định dạng MethodName = " + strMethodName + " không đúng");
				return;
			}

			string strAssembly = string.Empty;
			string strType = string.Empty;

			strAssembly = arrStr[0];
			strType = "Epoint." + arrStr[1];

			Assembly asl = Assembly.Load(strAssembly);
			Type type = asl.GetType(strType);

			Form frm = (Form)Activator.CreateInstance(type);

			object[] objPara = new object[] { enuEdit.Edit, drCurrent, null };

			type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, objPara);
		}

		void Edit_CheckDataLogic(enuEdit enuNew_Edit)
		{
			if (bdsCheckDataLogic.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCheckDataLogic.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCheckDataLogic.Current).Row, ref drCurrent);
			else
				drCurrent = dtCheckDataLogic.NewRow();

			frmCheckDataLogic_Edit frmEdit = new frmCheckDataLogic_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCheckDataLogic.Position >= 0)
						dtCheckDataLogic.ImportRow(drCurrent);
					else
						dtCheckDataLogic.Rows.Add(drCurrent);

					bdsCheckDataLogic.Position = bdsCheckDataLogic.Find("Stt", drCurrent["Stt"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCheckDataLogic.Current).Row);

				dtCheckDataLogic.AcceptChanges();
			}
			else
				dtCheckDataLogic.RejectChanges();
		}

		void Delete_CheckDataLogic()
		{
			if (bdsCheckDataLogic.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCheckDataLogic.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("Sure_Delete")))
				return;

			if (DataTool.SQLDelete("SYSCheckData", drCurrent))
			{
				bdsCheckDataLogic.RemoveAt(bdsCheckDataLogic.Position);
				dtCheckDataLogic.AcceptChanges();
			}
		}

		void btRun_Click(object sender, EventArgs e)
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT1", Library.StrToDate(dteNgay_Ct1.Text));
			htPara.Add("NGAY_CT2", Library.StrToDate(dteNgay_Ct2.Text));
			htPara.Add("IS_CHECKSD", chkIs_CheckSD.Checked);
			htPara.Add("IS_CHECKCTPS", chkIs_CheckCtPS.Checked);
            htPara.Add("IS_CHECKLOGIC", chkIs_CheckLogic.Checked);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtCheckData = SQLExec.ExecuteReturnDt("sp_CheckData", htPara, CommandType.StoredProcedure);

			bdsCheckData.DataSource = dtCheckData;
			dgvCheckData.DataSource = bdsCheckData;

			this.bdsSearch = bdsCheckData;
			this.ExportControl = dgvCheckData;

			tabControl1.SelectedTab = pageCheckResult;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (e.KeyCode == Keys.F3)
			{
				if (tabControl1.SelectedTab == pageCheckDataLogic)
					this.Edit_CheckDataLogic(enuEdit.Edit);
				else if (tabControl1.SelectedTab == pageCheckResult)
					this.Edit();
			}
			else if (e.KeyCode == Keys.F2)
			{
				if (tabControl1.SelectedTab == pageCheckDataLogic)
					this.Edit_CheckDataLogic(enuEdit.New);
			}
			else if (e.KeyCode == Keys.F8)
			{
				if (tabControl1.SelectedTab == pageCheckDataLogic)
					this.Delete_CheckDataLogic();
			}
		}		
	}
}
