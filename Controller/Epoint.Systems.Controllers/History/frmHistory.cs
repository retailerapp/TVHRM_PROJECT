using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmHistory : Epoint.Systems.Customizes.frmView
	{
		private DataTable dtHistoryVoucher;
		private DataTable dtHistoryOther;

		private BindingSource bdsHistoryVoucher = new BindingSource();
		private BindingSource bdsHistoryOther = new BindingSource();

		private DataRow drCurrent;
		string strStt = string.Empty;

		public frmHistory()
		{
			InitializeComponent();
			txtMember_ID.Validating += new CancelEventHandler(txtMember_ID_Validating);
			tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

			btRun.Click += new EventHandler(btRun_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
		}

		public override void Load()
		{
			this.Build();

			this.dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			this.dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			BindingLanguage();
			this.Show();
		}

		public void LoadWithStt(string strStt, DateTime dteNgay_Ct1, DateTime dteNgay_Ct2)
		{
			this.dteNgay_Ct1.Text = Library.DateToStr(dteNgay_Ct1);
			this.dteNgay_Ct2.Text = Library.DateToStr(dteNgay_Ct2);
			this.strStt = strStt;

			this.Build();
			FillData();

			BindingLanguage();

			this.Show();
		}

		void Build()
		{
			dgvHistoryVoucher.strZone = "HISTORYVOUCHER";
			dgvHistoryVoucher.BuildGridView();

			dgvHistoryOther.strZone = "HISTORYOTHER";
			dgvHistoryOther.BuildGridView();
		}

		void FillData()
		{
			DateTime dteNgay_Ct1 = Library.StrToDate(this.dteNgay_Ct1.Text);
			DateTime dteNgay_Ct2 = Library.StrToDate(this.dteNgay_Ct2.Text);
			dteNgay_Ct2 = new DateTime(dteNgay_Ct2.Year, dteNgay_Ct2.Month, dteNgay_Ct2.Day, 23, 59, 59);//Lấy cuối dteNgay_Ct2

            //Lay History Chung tu
            string strKey = string.Empty;
            string strKey2 = string.Empty;
            string strUpdate_Type = string.Empty;

            if (enuData_Type.Text != "")
            {
                if (enuData_Type.Text == "1")
                    strKey = strKey + " Update_Type = 'N'";
                if (enuData_Type.Text == "2")
                    strKey = strKey + " Update_Type = 'E'";
                if (enuData_Type.Text == "3")
                    strKey = strKey + " Update_Type = 'D'";
            }

            if (enuData_Type.Text != "")
            {
                if (enuData_Type.Text == "1")
                    strUpdate_Type = "N";
                if (enuData_Type.Text == "2")
                    strUpdate_Type = "E";
                if (enuData_Type.Text == "3")
                    strUpdate_Type = "D";
            }

            if (txtMa_Ct.Text != "")
            {
                strKey = strKey + " AND Ma_Ct = '" + txtMa_Ct.Text + "'";
                strKey2 = strKey2 + " Ma_Ct = '" + txtMa_Ct.Text + "'";
            }

            if (txtMember_ID.Text != "" && txtMa_Ct.Text != "")            
                strKey2 = strKey2 + " AND Member_ID = '" + txtMember_ID.Text + "'";

            if (txtMember_ID.Text != "" && txtMa_Ct.Text == "")
                strKey2 = strKey2 + " Member_ID = '" + txtMember_ID.Text + "'";
                         
			Hashtable ht = new Hashtable();
			ht["NGAY_CT1"] = dteNgay_Ct1;
			ht["NGAY_CT2"] = dteNgay_Ct2;
			ht["KEY"] = strKey;//Key này lấy dữ liệu sửa, đã xóa
            ht["KEY2"] = strKey2; //Key này lấy dữ liệu thêm mới
            ht["UPDATE_TYPE"] = strUpdate_Type;
			ht["STT"] = strStt;
            ht["LANGUAGE_TYPE"] = Element.sysLanguage.ToString().Substring(0,1);
			ht["MA_DVCS"] = Element.sysMa_DvCs;	

			dtHistoryVoucher = SQLExec.ExecuteReturnDt("sp_GetHistoryVoucher", ht, CommandType.StoredProcedure);

            //Lay History danh muc
			strKey = " (Ngay_Update BETWEEN '" + this.dteNgay_Ct1.Text + "' AND '" + this.dteNgay_Ct2.Text + " 23:59:59')";

            if (enuData_Type.Text != "")
            {
                if (enuData_Type.Text == "1")
                    strKey = strKey + " AND Update_Type = 'N'";
                if (enuData_Type.Text == "2")
                    strKey = strKey + " AND Update_Type = 'E'";
                if (enuData_Type.Text == "3")
                    strKey = strKey + " AND (Update_Type = 'D' OR Update_Type = 'M')";
            }

			if (txtMember_ID.Text != string.Empty)
				strKey = strKey + " AND Member_ID = '" + txtMember_ID.Text + "'";

			dtHistoryOther = DataTool.SQLGetDataTable("SYSHISTORYOTHER", Element.sysLanguage == enuLanguageType.Vietnamese ? @"CASE Update_Type WHEN 'N' THEN N'Thêm mới'
																			WHEN 'E' THEN N'Sửa'
																			WHEN 'D' THEN N'Xóa'
                                                                            WHEN 'M' THEN N'Gộp mã'
																			ELSE 'Khác' END AS Update_Type2,*" : @"CASE Update_Type WHEN 'N' THEN N'Add new'
																			WHEN 'E' THEN N'Edit'
																			WHEN 'D' THEN N'Delete'
                                                                            WHEN 'M' THEN N'Merge ID'
																			ELSE 'Other' END AS Update_Type2,*", strKey, "Ngay_Update, Member_ID, Code, Name");

			bdsHistoryVoucher.DataSource = dtHistoryVoucher;
			bdsHistoryOther.DataSource = dtHistoryOther;

			dgvHistoryVoucher.DataSource = bdsHistoryVoucher;
			dgvHistoryOther.DataSource = bdsHistoryOther;

			this.ExportControl = dgvHistoryVoucher;

		}

		private void Delete_HistoryVoucher()
		{
			if (bdsHistoryVoucher.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsHistoryVoucher.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("SYSHISTORYVOUCHER", drCurrent))
			{
				bdsHistoryVoucher.RemoveAt(bdsHistoryVoucher.Position);
				dtHistoryVoucher.AcceptChanges();
			}

		}

		private void Delete_HistoryOther()
		{
			if (bdsHistoryOther.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsHistoryOther.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("SYSHISTORYOTHER", drCurrent))
			{
				bdsHistoryOther.RemoveAt(bdsHistoryOther.Position);
				dtHistoryOther.AcceptChanges();
			}
		}
		
		public override void Delete()
		{
			if (this.tabControl1.SelectedTab == pageHistoryVoucher)
				this.Delete_HistoryVoucher();
			else if (this.tabControl1.SelectedTab == pageHistoryOther)
				this.Delete_HistoryOther();
		}

		void btRun_Click(object sender, EventArgs e)
		{
			FillData();
		}

		void Delete_All_HistoryVorcher()
		{
			string strMess = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc chắn xóa lịch sử dữ liệu ?" : "Are you sure delete history ?";

			if (Common.MsgYes_No(strMess, "N"))
			{
				Hashtable ht = new Hashtable();
				ht["NGAY_CT1"] = dteNgay_Ct1.Text;
				ht["NGAY_CT2"] = dteNgay_Ct2.Text;
				ht["MEMBER_ID"] = txtMember_ID.Text;
				ht["MA_DVCS"] = Element.sysMa_DvCs;

				if (SQLExec.Execute("Sp_Delete_All_HistoryVorcher", ht, CommandType.StoredProcedure))
				{
					this.FillData();
				}
			}
		}

		void Delete_All_HistoryOther()
		{
			string strMess = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc chắn xóa lịch sử dữ liệu ?" : "Are you sure delete history ?";

			if (Common.MsgYes_No(strMess, "N"))
			{
				Hashtable ht = new Hashtable();
				ht["NGAY_CT1"] = dteNgay_Ct1.Text;
				ht["NGAY_CT2"] = dteNgay_Ct2.Text;
				ht["MEMBER_ID"] = txtMember_ID.Text;
				ht["MA_DVCS"] = Element.sysMa_DvCs;

				if (SQLExec.Execute("Sp_Delete_All_HistoryOther", ht, CommandType.StoredProcedure))
				{
					this.FillData();
				}
			}
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			if (this.tabControl1.SelectedTab == pageHistoryVoucher)
				this.Delete_All_HistoryVorcher();
			else if (this.tabControl1.SelectedTab == pageHistoryOther)
				this.Delete_All_HistoryOther();
		}

		void txtMember_ID_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMember_ID.Text;
			bool bRequire = false;

			frmQuickLookup frmLookup = new frmQuickLookup("SYSMEMBER", "USER");
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSMEMBER", "Member_ID", strValue, bRequire, "Member_Type = 'U'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMember_ID.Text = string.Empty;				
			}
			else
			{
				txtMember_ID.Text = drLookup["Member_ID"].ToString();
				//lbtTen_Member.Text = drLookup["Member_Name"].ToString();
			}
		}

		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == pageHistoryVoucher)
				this.ExportControl = dgvHistoryVoucher;
			else
				this.ExportControl = dgvHistoryVoucher;
		}
	}
}
