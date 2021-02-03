using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Text.RegularExpressions;

namespace Epoint.Lists
{
	public partial class frmDoiTuong_Edit : Epoint.Lists.frmEdit
	{
		DataRow drCurrent;
        private string strCode = string.Empty;

		private WebBrowser webBrowserHiden = new WebBrowser();
		private RichTextBox richBody = new RichTextBox();
		private CookieContainer loginCookie;

		#region Phuong thuc

		public frmDoiTuong_Edit()
		{
			InitializeComponent();
			webBrowserHiden.ScriptErrorsSuppressed = true;

			txtMa_Nh_Dt.Validating += new CancelEventHandler(txtMa_Nh_Dt_Validating);
			txtMa_Kv.Validating += new CancelEventHandler(txtMa_Kv_Validating);
			txtMa_CbNv.Validating += new CancelEventHandler(txtMa_CbNv_Validating);
			txtMa_Dt_Gia_Mua.Validating += new CancelEventHandler(txtMa_Dt_Gia_Validating);

			btSearch.Click += BtSearch_Click;
			btLinkData.Click += BtLinkData_Click;

			webBrowserHiden.DocumentCompleted += WebBrowserHiden_DocumentCompleted;
		}
		
		public override void Load(enuEdit enuNew_Edit, DataRow drCurrent)
		{
			this.drCurrent = drCurrent;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            			
			if (enuNew_Edit == enuEdit.Edit)
				this.drEdit = DataTool.SQLGetDataRowByID("LIDOITUONG", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
			else
			{
				this.drEdit = DataTool.SQLGetDataTable("LIDOITUONG", null, "0 = 1", "Ma_Dt").NewRow();
				Common.CopyDataRow(drCurrent, drEdit);
			}

			if (enuNew_Edit == enuEdit.New && drEdit.Table.Columns.Contains("Tien_No_Max"))
				drEdit["Tien_No_Max"] = 0;

            this.txtMa_Nh_Dt.Text = drCurrent["Ma_Nh_Dt"].ToString();

            //New: khi them moi thi khong can ke thua
            if (enuNew_Edit != enuEdit.New)
                Common.ScaterMemvar(this, ref drEdit);

            this.strCode = txtMa_Dt.Text;

            //Edit: Disable Ma_Dt
            if (enuNew_Edit == enuEdit.Edit)
                txtMa_Dt.Enabled = false;

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			cboDieu_Kien.SelectedIndex = 0;

			if (txtMa_Nh_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Dt.Text = DataTool.SQLGetNameByCode("LIDOITUONGNH", "Ma_Nh_Dt", "Ten_Nh_Dt", txtMa_Nh_Dt.Text.Trim());
			}
			else
				lbtTen_Nh_Dt.Text = string.Empty;

			if (txtMa_Kv.Text.Trim() != string.Empty)
			{
				lbtTen_Kv.Text = DataTool.SQLGetNameByCode("LIKHUVUC", "Ma_Kv", "Ten_Kv", txtMa_Kv.Text.Trim());
			}
			else
				lbtTen_CbNv.Text = string.Empty;

			if (txtMa_CbNv.Text.Trim() != string.Empty)
			{
				lbtTen_CbNv.Text = DataTool.SQLGetNameByCode("LINHANVIEN", "Ma_CbNv", "Ten_CbNv", txtMa_CbNv.Text.Trim());
			}
			else
				lbtTen_CbNv.Text = string.Empty;

			if (txtMa_Dt_Gia_Mua.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_Gia_Mua.Text = DataTool.SQLGetNameByCode("LIDOITUONG", "Ma_Dt", "Ten_Dt", txtMa_Dt_Gia_Mua.Text.Trim());
			}
			else
				lbtTen_Dt_Gia_Mua.Text = string.Empty;
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}			

			if (txtTen_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ten_Dt") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Nh_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Nh_Dt") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

            if (txtMa_So_Thue.Text.Trim() != string.Empty)
            {
                object objMa_Dt = SQLExec.ExecuteReturnValue("SELECT Ma_Dt FROM LIDOITUONG WHERE Ma_So_Thue = '" + 
                                                                txtMa_So_Thue.Text + "' AND Ma_Dt <> '" + (string)drEdit["Ma_Dt"] + "'");

                if (!(objMa_Dt == null || DBNull.Value == null))
                {
                    objMa_Dt = SQLExec.ExecuteReturnValue("SELECT Ma_So_Thue FROM LIDOITUONG WHERE Ma_Dt = '" + txtMa_Dt.Text + "'");

                    if (this.enuNew_Edit == enuEdit.Edit && (objMa_Dt == null || DBNull.Value == null) && txtMa_So_Thue.Text == (string)drEdit["Ma_So_Thue", DataRowVersion.Original])
                    {
                        return true;
                    }
                    if ((string)Parameters.GetParaValue("IS_MASOTHUE") == "1")
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã số thuế {" 
                                     + txtMa_So_Thue.Text + "} đã tồn tại trong Danh mục đối tượng" : "Tax Code {" + txtMa_So_Thue.Text + "} has existed in the Object list";
                        Common.MsgCancel(strMsg);
                        this.ActiveControl = txtMa_So_Thue;
                        return false;
                    }
                }
            }
			return bvalid;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LIDOITUONG", ref drEdit))
				return false;

			Common.CopyDataRow(drEdit, drCurrent);

            ////Sync data-------------
            //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
            //if (Is_Sync == "1")
            //{
            //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
            //    if (sqlCon.State != ConnectionState.Open)
            //    {
            //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
            //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
            //        Common.MsgCancel(strMsg);
            //    }
            //    else
            //    {
            //        DataToolSync1.SQLUpdate(enuNew_Edit, "LIDOITUONG", ref drEdit);
            //    }
            //}
            //----------------------

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit && this.strCode != txtMa_Dt.Text)
            //{
            //    DataTool.SQLChangeID("MA_DT", drCurrent);

            //    //Sync data-------------            
            //    if (Is_Sync == "1")
            //    {
            //        SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
            //        if (sqlCon.State != ConnectionState.Open)
            //        {
            //            SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
            //            string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
            //            Common.MsgCancel(strMsg);
            //        }
            //        else
            //        {
            //            DataToolSync1.SQLChangeID("MA_DT", drEdit);
            //        }
            //    }
            //    //----------------------
            //}

			return true;
		}

		private async Task RunAsync(string strKeyFilter)
		{
			LIDoiTuong doituong = new LIDoiTuong { };
			try
			{
				doituong = await RunAsyncAPI(strKeyFilter);
			}
			catch (Exception)
			{
				doituong = null;
			}

			//Thoa dieu kien kiem kiem
			if (doituong != null)
			{
				lbtTen_Dt.Text = doituong.Title;
				lbtMa_So_Thue.Text = doituong.MaSoThue;
				lbtDia_Chi.Text = doituong.DiaChiCongTy;
				lbtNganh_Nghe.Text = doituong.NganhNgheTitle;
				lbtOng_Ba.Text = doituong.GiamDoc;
				lbtSo_Phone.Text = doituong.NoiDangKyQuanLy_DienThoai;
				lbtSo_Fax.Text = doituong.NoiDangKyQuanLy_Fax;
				lbtNgay_Sinh.Text = Library.DateToStr(doituong.NgayCap);
			}//Tim bang bang cach khac
			else
			{
				await RunAsyncWebsite();
			}
		}

		private async Task<LIDoiTuong> RunAsyncAPI(string strKeyFilter)
		{
			LIDoiTuong doituong = null;
            //try
            //{
            //    using (var client = new HttpClient())
            //    {
            //        client.BaseAddress = new Uri("https://thongtindoanhnghiep.co/");
            //        client.DefaultRequestHeaders.Accept.Clear();
            //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //        HttpResponseMessage response = await client.GetAsync($"api/company/{strKeyFilter}");
            //        //Newston.json 6.0
            //        //if (response.IsSuccessStatusCode)
            //        //{
            //        //	doituong = await response.Content.ReadAsAsync<LIDoiTuong>();
            //        //}

            //        if (response.IsSuccessStatusCode)
            //        {
            //            //response.EnsureSuccessStatusCode();
            //            string jsonStr = await response.Content.ReadAsStringAsync();
            //            doituong = Newtonsoft.Json.JsonConvert.DeserializeObject<LIDoiTuong>(jsonStr);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    doituong = null;
            //}

			return doituong;
		}

		private async Task RunAsyncWebsite()
		{
			string postData = ("q=" + txtSearch.Text);
			CookieContainer tempCookie = new CookieContainer();
			UTF8Encoding encoding = new UTF8Encoding();
			byte[] byteData = encoding.GetBytes(postData);

			HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create("http://www.thongtincongty.com");
			postReq.Method = "POST";
			postReq.KeepAlive = true;
			postReq.CookieContainer = tempCookie;
			postReq.ContentType = "application/x-www-form-urlencoded";
			postReq.Referer = "http://www.thongtincongty.com";
			postReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 " + "Safari/537.36";
			postReq.ContentLength = byteData.Length;
			Stream postreqstream = postReq.GetRequestStream();
			postreqstream.Write(byteData, 0, byteData.Length);
			postreqstream.Close();

			HttpWebResponse postresponse = (HttpWebResponse)postReq.GetResponse();
			tempCookie.Add(postresponse.Cookies);
			loginCookie = tempCookie;
			StreamReader postreqreader = new StreamReader(postresponse.GetResponseStream());
			richBody.Text = postreqreader.ReadToEnd();
			webBrowserHiden.DocumentText = richBody.Text;
		}
		#endregion

		#region Su kien

		void txtMa_Nh_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Dt.Text.Trim();
			bool bRequire = true;

			frmDoiTuongNh frmLookup = new frmDoiTuongNh();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONGNH", "Ma_Nh_Dt", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Dt.Text = string.Empty;
				lbtTen_Nh_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Dt.Text = ((string)drLookup["Ma_Nh_Dt"]).Trim();
				lbtTen_Nh_Dt.Text = ((string)drLookup["Ten_Nh_Dt"]).Trim();
			}

			dicName.SetValue(lbtTen_Nh_Dt.Name, lbtTen_Nh_Dt.Text);
		}

		void txtMa_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_CbNv.Text.Trim();
			bool bRequire = false;

            frmNhanVien frmLookup = new frmNhanVien();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LINHANVIEN", "Ma_CbNv", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_CbNv.Text = string.Empty;
				lbtTen_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_CbNv.Text = ((string)drLookup["Ma_CbNv"]).Trim();
				lbtTen_CbNv.Text = ((string)drLookup["Ten_CbNv"]).Trim();
			}

			dicName.SetValue(lbtTen_CbNv.Name, lbtTen_CbNv.Text);
		}

		void txtMa_Kv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kv.Text.Trim();
			bool bRequire = false;

            frmKhuVuc frmLookup = new frmKhuVuc();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIKHUVUC", "Ma_Kv", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kv.Text = string.Empty;
				lbtTen_Kv.Text = string.Empty;
			}
			else
			{
				txtMa_Kv.Text = ((string)drLookup["Ma_Kv"]).Trim();
				lbtTen_Kv.Text = ((string)drLookup["Ten_Kv"]).Trim();
			}

			dicName.SetValue(lbtTen_Kv.Name, lbtTen_Kv.Text);
		}

		void txtMa_Dt_Gia_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_Gia_Mua.Text.Trim();
			bool bRequire = false;

			frmDoiTuong frmLookup = new frmDoiTuong();
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "LIDOITUONG", "Ma_Dt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_Gia_Mua.Text = string.Empty;
				lbtTen_Dt_Gia_Mua.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_Gia_Mua.Text = ((string)drLookup["Ma_Dt"]).Trim();
				lbtTen_Dt_Gia_Mua.Text = ((string)drLookup["Ten_Dt"]).Trim();
			}

			dicName.SetValue(lbtTen_Dt_Gia_Mua.Name, lbtTen_Dt_Gia_Mua.Text);
		}

		private void BtLinkData_Click(object sender, EventArgs e)
		{
			if (lbtTen_Dt.Text != string.Empty && lbtMa_So_Thue.Text != string.Empty)
			{
				txtTen_Dt.Text = lbtTen_Dt.Text;
				txtDia_Chi.Text = lbtDia_Chi.Text;
				txtOng_Ba.Text = lbtOng_Ba.Text;
				txtSo_Phone.Text = lbtSo_Phone.Text;
				txtSo_Fax.Text = lbtSo_Fax.Text;
				txtNgay_Sinh.Text = lbtNgay_Sinh.Text;
			}
		}

		private void BtSearch_Click(object sender, EventArgs e)
		{
			lbtTen_Dt.Text = string.Empty;
			lbtMa_So_Thue.Text = string.Empty;
			lbtDia_Chi.Text = string.Empty;
			lbtNganh_Nghe.Text = string.Empty;
			lbtOng_Ba.Text = string.Empty;
			lbtSo_Phone.Text = string.Empty;
			lbtSo_Fax.Text = string.Empty;
			lbtNgay_Sinh.Text = string.Empty;

			webBrowser.DocumentText = string.Empty;

			RunAsync(txtSearch.Text);
		}

		private void WebBrowserHiden_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			string pattern = @"<a .*?href=['""](.+?)['""].*?>(.+?)</a>";
			string replacePattern = "<b>$2</b>";
			string strHtml = string.Empty;

			HtmlElementCollection divs = webBrowserHiden.Document.Body.GetElementsByTagName("div");
			int i = 0;
			//Tìm chính xác
			foreach (HtmlElement div in divs)
			{
				if ((div.GetAttribute("className") == "jumbotron"))
				{
					strHtml += Regex.Replace(div.InnerHtml, pattern, replacePattern);
					i = (i + 1);
				}
			}
			//Tìm tiếp 1 lần nữa
			if (i == 0)
			{
				foreach (HtmlElement div in divs)
				{
					if ((div.GetAttribute("className") == "search-results"))
					{
						strHtml += Regex.Replace(div.InnerHtml, pattern, replacePattern);
						i = (i + 1);
					}
				}
			}

			if (i == 0)
				webBrowser.DocumentText = "<h2 style=\'font-weight: bold; color: red\'><b>KHÔNG TÌM THẤY DOANH NGHIỆP PHÙ HỢP</b></h2>";
			else
				webBrowser.DocumentText = strHtml;
		}
		#endregion
	}
}