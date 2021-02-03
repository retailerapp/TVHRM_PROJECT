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
	public partial class frmWorkingYear : Epoint.Systems.Customizes.frmView
	{
		public frmWorkingYear()
		{
			InitializeComponent();
            Element.Is_FrmEditRunning = false;
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);			            
		}
		public void Load()
		{
            txtNam_Current.Text = Convert.ToString(Element.sysWorkingYear);
            txtNam_Next.Text = Convert.ToString(Element.sysWorkingYear + 1);

            if (Element.sysLanguage == Epoint.Systems.enuLanguageType.Vietnamese)
                lblCreate_Nam_Next.Text = "* Để tạo năm làm việc " + (Element.sysWorkingYear + 1) + ". Nhấn nút Đồng ý !";
            else
                lblCreate_Nam_Next.Text = "* To create working year " + (Element.sysWorkingYear + 1) + ". Click Accept button !";

            this.Show();

			BindingLanguage();
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
                ht["TH_BD_HT"] = txtTh_Bd_Ht.Text;

				strSQLExec = "INSERT INTO SYSNAM (Nam, Ma_DvCs, Th_Bd_Ht) VALUES (@Nam, @Ma_DvCs, @Th_Bd_Ht)";

				SQLExec.Execute(strSQLExec, ht, CommandType.Text);

				EpointMessage.MsgOk(Languages.GetLanguage("END_PROCESS"));
			}

		}       
		void btAccept_Click(object sender, EventArgs e)
		{
            this.TaoNamMoi();
            this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{            
			this.Close();
		}        
	}
}
