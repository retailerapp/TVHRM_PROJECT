using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
	public partial class frmDataLog : Epoint.Systems.Customizes.frmView
	{

		#region Khai bao bien

		private DataTable dtDataLog;
		private BindingSource bdsDataLog = new BindingSource();

		#endregion

		#region Contructor

		public frmDataLog()
		{
			InitializeComponent();

			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.btDeleteAll.Click += new EventHandler(btDeleteAll_Click);
		}

		public override void Load()
		{
			Build();
			BindingLanguage();

			btDeleteAll.Enabled = Element.sysIs_Admin;

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvDataLog.strZone = "DATALOG";
			dgvDataLog.BuildGridView(false);
		}

		private void FillData()
		{
			string strKey = "1 = 1 ";

			if (!txtModify_Date1.IsNull)
				strKey += " AND (T1.Modify_Date >= '" + txtModify_Date1.Text + "')";

			if (!txtModify_Date2.IsNull)
				strKey += " AND (T1.Modify_Date < DATEADD(day, 1, '" + txtModify_Date2.Text + "'))";

			if (txtMember_ID.Text != string.Empty)
				strKey += " AND (T1.Member_ID = '" + txtMember_ID.Text + "')";

			if (txtStt.Text != string.Empty)
				strKey += " AND (T1.Data_ID = '" + txtStt.Text + "')";

			if (!txtNgay_Ct1.IsNull && !txtNgay_Ct2.IsNull)
				strKey += " AND (T1.Data_ID IN (SELECT Stt FROM R80Ph WHERE Ngay_Ct BETWEEN '" + txtNgay_Ct1.Text + "' AND '" + txtNgay_Ct2.Text + "'))";

			if (txtSo_Ct.Text != string.Empty)
				strKey += " AND (T1.Data_ID IN (SELECT Stt FROM R80Ph WHERE So_Ct = '" + txtSo_Ct.Text + "'))";

			string strSQLExec = 
				"SELECT T1.*, T2.Stt, T2.Ma_Ct, T2.Ngay_Ct, T2.So_Ct, T2.Dien_Giai " +
					" FROM SYSDataLog T1 LEFT JOIN R80Ph T2 ON T1.Data_ID = T2.Stt" +
					" WHERE " + strKey;

			dtDataLog = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsDataLog.DataSource = dtDataLog;
			dgvDataLog.DataSource = bdsDataLog;
			bdsDataLog.Position = 0;

			//Uy quyen cho lop co so tim kiem
			bdsSearch = bdsDataLog;
		}
		
		#endregion

		#region Update

		public override void Delete()
		{
			if (bdsDataLog.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDataLog.Current).Row;

			if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
			
			if (DataTool.SQLDelete("SYSDataLog", drCurrent))
			{
				bdsDataLog.RemoveAt(bdsDataLog.Position);
				dtDataLog.AcceptChanges();
			}
		}

		#endregion

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btDeleteAll_Click(object sender, EventArgs e)
		{
			if (dtDataLog != null)
			{
				if (EpointMessage.MsgYes_No("Có chắc chắn xóa toàn bộ nhật ký không?"))
				{
					foreach (DataRow dr in dtDataLog.Rows)
					{
						DataTool.SQLDelete("SYSDataLog", dr);
					}

					dtDataLog.Rows.Clear();
				}
			}
		}
	}
}
