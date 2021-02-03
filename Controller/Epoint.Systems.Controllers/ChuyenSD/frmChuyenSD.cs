using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;

namespace Epoint.Controllers
{
	public partial class frmChuyenSD : Epoint.Systems.Customizes.frmView
	{
		public frmChuyenSD()
		{
			InitializeComponent();
            Element.Is_FrmEditRunning = false;
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);			
            btYear.Click += new EventHandler(btYear_Click);
		}
		public void Load()
		{
			this.Show();

			BindingLanguage();
		}

		void ChuyenSoDu()
		{
			int iNam_Nay = Element.sysWorkingYear;
			int iNam_Sau = iNam_Nay + 1;
			string strMa_DvCs = Element.sysMa_DvCs;

            if (!chkChuyen_Cdk.Checked && !chkChuyen_SDHanTt.Checked && !chkChuyen_Cdv.Checked && !chkChuyen_Cdv_NTXT.Checked  && !chkChuyen_SDZ.Checked)
				return;

			if (!DataTool.SQLCheckExist("SYSNAM", new string[] { "Nam", "Ma_DvCs" }, new object[] { iNam_Sau, strMa_DvCs}))
			{
				EpointMessage.MsgCancel("Chưa tạo năm làm việc mới " + iNam_Sau.ToString().Trim());                
				return;
			}

			//Kiểm tra khóa dữ liệu năm sau
			if (chkChuyen_Cdk.Checked || chkChuyen_SDHanTt.Checked || chkChuyen_SDZ.Checked)
			{
				string strSQLExec =
					"SELECT TOP 1 Locked_Sdk FROM SYSNam " +
						" WHERE Nam = " + iNam_Sau.ToString().Trim() + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

				if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
				{
					EpointMessage.MsgCancel("Số dư đầu năm " + iNam_Sau.ToString().Trim() + " đã khóa!");
					return;
				}
			}

			//Kiểm tra khóa dữ liệu năm sau
            if (chkChuyen_Cdv.Checked || chkChuyen_Cdv_NTXT.Checked)
			{
				string strSQLExec =
					"SELECT TOP 1 Locked_Sdv FROM SYSNam " +
						" WHERE Nam = " + iNam_Sau.ToString().Trim() + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

				if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
				{
					EpointMessage.MsgCancel("Số dư đầu năm " + iNam_Sau.ToString().Trim() + " đã khóa!");
					return;
				}
			}

			if (!EpointMessage.MsgYes_No("Bạn có chắc chắn chuyển số dư sang năm " + iNam_Sau.ToString() + " hay không?"))
				return;

			Hashtable ht = new Hashtable();
			ht["NAM_NAY"] = Element.sysWorkingYear;
			ht["MA_DVCS"] = Element.sysMa_DvCs;
            ht["USER"] = Element.sysUser_Id;

			if (chkChuyen_Cdk.Checked)
			{
				Common.ShowStatus(Languages.GetLanguage("Chuyen_Cdk"));
				SQLExec.Execute("Sp_Chuyen_Cdk", ht, CommandType.StoredProcedure);
			}
			if (chkChuyen_SDHanTt.Checked)
			{
				Common.ShowStatus(Languages.GetLanguage("Chuyen_SDHanTT"));
				SQLExec.Execute("Sp_Chuyen_SDHanTt", ht, CommandType.StoredProcedure);
			}
			if (chkChuyen_Cdv.Checked)
			{
				Common.ShowStatus(Languages.GetLanguage("Chuyen_Cdv"));
				SQLExec.Execute("Sp_Chuyen_Cdv", ht, CommandType.StoredProcedure);
			}
            if (chkChuyen_Cdv_NTXT.Checked)
            {
                Common.ShowStatus(Languages.GetLanguage("Chuyen_Cdv_NTXT"));
                SQLExec.Execute("Sp_Chuyen_Cdv_NTXT", ht, CommandType.StoredProcedure);
            }
			if (chkChuyen_SDZ.Checked)
			{
				Common.ShowStatus(Languages.GetLanguage("Chuyen_SDZ"));
				SQLExec.Execute("Sp_Chuyen_SDZ", ht, CommandType.StoredProcedure);
			}

			Common.EndShowStatus();
			EpointMessage.MsgOk(Languages.GetLanguage("END_PROCESS"));
		}

		void TaoNamMoi()
		{
			int iNam_Nay = Element.sysWorkingYear;
			int iNam_Sau = iNam_Nay + 1;
			string strMa_DvCs = Element.sysMa_DvCs;
			string strMsg = string.Empty;

			string strSQLExec = "SELECT COUNT(*) FROM SYSNam WHERE (Nam = " + iNam_Sau.ToString().Trim() + " AND Ma_DvCs = '" + strMa_DvCs + "')";

			if ((int)SQLExec.ExecuteReturnValue(strSQLExec) > 0)
			{
				strMsg = (Element.sysLanguage == Epoint.Systems.enuLanguageType.Vietnamese)? "Đã tồn tại năm làm việc " : "There is working year ";
				strMsg += iNam_Sau.ToString().Trim();

				EpointMessage.MsgCancel(strMsg);
			}
			else
			{
				strMsg = Element.sysLanguage == Epoint.Systems.enuLanguageType.Vietnamese ? "Chưa có năm làm việc mới " : "There is not new working year ";
				strMsg += iNam_Sau.ToString().Trim();
				strMsg += Element.sysLanguage == Epoint.Systems.enuLanguageType.Vietnamese ? "\nBạn có muốn tạo năm làm việc mới không ?" : "\n Do you want to create new working year ?";

				if (!EpointMessage.MsgYes_No(strMsg))
					return;

				Hashtable ht = new Hashtable();
				ht["NAM"] = iNam_Sau;
				ht["MA_DVCS"] = strMa_DvCs;

				strSQLExec = "INSERT INTO SYSNAM (Nam, Ma_DvCs, Th_Bd_Ht) VALUES (@Nam, @Ma_DvCs, 1)";

				SQLExec.Execute(strSQLExec, ht, CommandType.Text);

				EpointMessage.MsgOk(Languages.GetLanguage("END_PROCESS"));
			}

		}

        void btYear_Click(object sender, EventArgs e)
        {
            this.TaoNamMoi();
        }
		
		void btAccept_Click(object sender, EventArgs e)
		{
			ChuyenSoDu();
		}

		void btCancel_Click(object sender, EventArgs e)
		{            
			this.Close();
		}
	}
}
