using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Commons;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;

namespace Epoint.Controllers
{
	public partial class frmReUpdate : Epoint.Systems.Customizes.frmEdit
	{
		public frmReUpdate()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load()
		{
			BindingLanguage();

			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			this.Show();
		}

		private bool ReUpdate()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct1.Text)) || !Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct2.Text)))
			{
				EpointMessage.MsgCancel("Dữ liệu đã khóa");
				return false;
			}

			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Library.StrToDate(dteNgay_Ct1.Text).Year)
			{
				EpointMessage.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Library.StrToDate(dteNgay_Ct1.Text).Year.ToString() + "!");
				return false;
			}

			Hashtable ht = new Hashtable();
			ht.Add("NGAY_CT1", Library.StrToDate(dteNgay_Ct1.Text));
			ht.Add("NGAY_CT2", Library.StrToDate(dteNgay_Ct2.Text));
			ht.Add("REUPDATE_THUCHI", this.chkReUpdate_ThuChi.Checked);
			ht.Add("REUPDATE_CONGNO", this.chkReUpdate_CongNo.Checked);
			ht.Add("REUPDATE_CHIPHI", this.chkReUpdate_ChiPhi.Checked);
			ht.Add("REUPDATE_DOANHTHU", this.chkReUpdate_DoanhThu.Checked);
			ht.Add("REUPDATE_THUEVAT", this.chkReUpdate_ThueVAT.Checked);
			ht.Add("REUPDATE_SOCAI", this.chkReUpdate_SoCai.Checked);
			ht.Add("REUPDATE_THEKHO", this.chkReUpdate_TheKho.Checked);
			ht.Add("REUPDATE_HANTT", this.chkReUpdate_HanTt.Checked);
			ht.Add("MA_DVCS", Element.sysMa_DvCs);

			Common.ShowStatus(Languages.GetLanguage("IN_PROCESS"));

			lock (this)
			{
				if (!SQLExec.Execute("Sp_ReUpdate", ht, CommandType.StoredProcedure))
				{
					Common.EndShowStatus();
					return false;
				}
			}

			EpointMessage.MsgOk(Languages.GetLanguage("END_PROCESS"));
			Common.EndShowStatus();

			return true;
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;
			if (dteNgay_Ct1.IsNull)
			{
				EpointMessage.MsgOk(Languages.GetLanguage("Ngay_Ct1") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (dteNgay_Ct2.IsNull)
			{
				EpointMessage.MsgOk(Languages.GetLanguage("Ngay_Ct2") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (!this.chkReUpdate_ThuChi.Checked && !this.chkReUpdate_CongNo.Checked &&
					!this.chkReUpdate_ChiPhi.Checked && !this.chkReUpdate_DoanhThu.Checked &&
						!this.chkReUpdate_ThueVAT.Checked && !this.chkReUpdate_SoCai.Checked &&
							!this.chkReUpdate_TheKho.Checked && !this.chkReUpdate_HanTt.Checked)
			{
				EpointMessage.MsgCancel(Languages.GetLanguage("Nothing") + " " + Languages.GetLanguage("Selected"));
				return false;
			}

			return bvalid;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (FormCheckValid())
				if (this.ReUpdate())
					this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{		
			this.Close();
		}
	}
}
