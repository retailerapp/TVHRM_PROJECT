using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Customizes;
using Epoint.Lists;

namespace Epoint.Controllers
{
	public partial class frmExportTax : Epoint.Systems.Customizes.frmView
	{
		string strXmlHeader = @"<!-- edited with XML Spy v4.1 U (http://www.xmlspy.com) by ThanhDX (FSS - HN)y--> 
								<!DOCTYPE Sections SYSTEM ""..\..\InterfaceTemplates\Schema.dtd"">
								<Sections Version=""130"">" + "\n\t";

		string strXmlFooter = @"</Sections>";

		DataTable dtThueVAT1;
		DataTable dtThueVAT2;

        string strQuy = string.Empty;
        
		string strXmlFileVao 
		{	
            get 
			{
                if(radioThang.Checked)
				    return Path.Combine(txtPath.Text, "01_2_GTGT_" + Library.StrToDate(dteNgay_Ct2.Text).Month.ToString().PadLeft(2, '0') + Library.StrToDate(dteNgay_Ct2.Text).Year + ".XML");
                else
                    return Path.Combine(txtPath.Text, "01_2_GTGT_" + strQuy + Library.StrToDate(dteNgay_Ct2.Text).Year + ".XML");
			}
         
		}

		string strXmlFileRa
		{
			get
			{
                if (radioThang.Checked)
				    return Path.Combine(txtPath.Text, "01_1_GTGT_" + Library.StrToDate(dteNgay_Ct2.Text).Month.ToString().PadLeft(2, '0') + Library.StrToDate(dteNgay_Ct2.Text).Year + ".XML");
                else
                    return Path.Combine(txtPath.Text, "01_1_GTGT_" + strQuy + Library.StrToDate(dteNgay_Ct2.Text).Year + ".XML");
			}
		}

		string strXmlFileToKhai
		{
			get
			{
                if (radioThang.Checked)
				    return Path.Combine(txtPath.Text, "01_GTGT_" + Library.StrToDate(dteNgay_Ct2.Text).Month.ToString().PadLeft(2, '0') + Library.StrToDate(dteNgay_Ct2.Text).Year + ".XML");
                else
                    return Path.Combine(txtPath.Text, "01_GTGT_" + strQuy + Library.StrToDate(dteNgay_Ct2.Text).Year + ".XML");
			}
		}

		public frmExportTax()
		{
			InitializeComponent();

			txtTk_Vat1.Validating += new CancelEventHandler(txtTk_Vat1_Validating);
			txtTk_Vat2.Validating += new CancelEventHandler(txtTk_Vat2_Validating);
			dteNgay_Ct2.Validating += new CancelEventHandler(dteNgay_Ct2_Validating);

			btPath.Click += new EventHandler(btPath_Click);
			btMa_DvCs_List.Click += new EventHandler(btMa_DvCs_List_Click);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}
        
		new public void Load()
		{
			this.dteNgay_Ct1.Text = Element.sysNgay_Ct1.ToString();
			this.dteNgay_Ct2.Text = Element.sysNgay_Ct2.ToString();

			//txtPath.Text = Common.GetBufferValue("EXPORTVAT_PATH");
            txtPath.Text = (string)Parameters.GetParaValue("EXPORTVAT_PATH");

			//Lấy Ma_DvCs ngầm định
			txtMa_DvCs_List.Text = Common.GetBufferValue("EXPORTVAT_MA_DVCS_LIST");
			txtTk_Vat1.Text = Common.GetBufferValue("TK_VAT_DAUVAO");
			txtTk_Vat2.Text = Common.GetBufferValue("TK_VAT_DAURA");

			if (txtTk_Vat1.Text == "") txtTk_Vat1.Text = "1331";
			if (txtTk_Vat2.Text == "") txtTk_Vat2.Text = "33311";

			this.BindingLanguage();
			this.Show();
		}

		bool FormCheckValid()
		{
			if (txtTk_Vat1.Text == string.Empty)
			{
				Common.MsgCancel("Chưa nhập tài khoản thuế VAT đầu vào");
				return false;
			}

			if (txtTk_Vat2.Text == string.Empty)
			{
				Common.MsgCancel("Chưa nhập tài khoản thuế VAT đầu ra");
				return false;
			}

			if (!Directory.Exists(txtPath.Text))
			{
				Common.MsgCancel("Đường dẫn [" + txtPath.Text + "] không hợp lệ!");
				return false;
			}

			return true;
		}

		void WriteData()
		{
			Hashtable htPara = new Hashtable();
			htPara["NGAY_CT1"] = Library.StrToDate(dteNgay_Ct1.Text);
			htPara["NGAY_CT2"] = Library.StrToDate(dteNgay_Ct2.Text);
			htPara["TK"] = "";
			htPara["MA_THUE"] = "";
			htPara["THUE_GTGT"] = "";
			htPara["KIEU_NHOM"] = "0";
			htPara["KIEU_SX"] = txtKieu_Sx.Text;
			htPara["LAY_THUE"] = "1";
			htPara["NHOM_THEO_HD"] = chkNhom_Theo_Hd.Checked;
			htPara["VND_NT"] = true;
			htPara["LANGUAGE_TYPE"] = "V";
			htPara["MA_DVCS_LIST"] = txtMa_DvCs_List.Text;
			htPara["MA_DVCS"] = Element.sysMa_DvCs;

			#region FillData VAT Dauvao

			htPara["TK"] = txtTk_Vat1.Text;
			dtThueVAT1 = SQLExec.ExecuteReturnDt("sp_rptVATC01", htPara, CommandType.StoredProcedure);

			#endregion

			#region FillData VAT Daura

			htPara["TK"] = txtTk_Vat2.Text;
			dtThueVAT2 = SQLExec.ExecuteReturnDt("sp_rptVATC01", htPara, CommandType.StoredProcedure);

			#endregion

			this.WriteDauVao();
			this.WriteDauRa();

			this.WriteToKhai();
		}

		void WriteDauVao()
		{
			foreach (DataRow dr in dtThueVAT1.Rows)
			{
				dr["Ten_Vt"] = ((string)dr["Ten_Vt"]).Replace(@"""", "");
				dr["Ten_DtGtGt"] = ((string)dr["Ten_DtGtGt"]).Replace(@"""", "");
			}

			DataRow[] arrDv01 = dtThueVAT1.Select("Bold = 0 AND Phan_Loai_Thue = 'V01'");
			DataRow[] arrDv02 = dtThueVAT1.Select("Bold = 0 AND Phan_Loai_Thue = 'V02'");
			DataRow[] arrDv03 = dtThueVAT1.Select("Bold = 0 AND Phan_Loai_Thue = 'V03'");
			DataRow[] arrDv04 = dtThueVAT1.Select("Bold = 0 AND Phan_Loai_Thue = 'V04'");
			DataRow[] arrDv05 = dtThueVAT1.Select("Bold = 0 AND Phan_Loai_Thue = 'V05'");

			int iStt = 7;
			int iStt2 = 17;
			bool iFirstCell = true;

			string strFile = this.strXmlHeader;
			
			#region Hàng hóa dịch vụ dùng riêng chịu thuế
			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";

			if (arrDv01.Length > 0)
			{
				foreach (DataRow dr in arrDv01)
				{
					iStt++;
					iStt2++;
					strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|"+ (string)dr["Ma_HOADON"] +"| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";                    
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ghi_Chu"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";                    

					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;

				strFile += "<Cells>" + "\n\t";
				strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += "</Cells>" + "\n\t";
				iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";

			#endregion

			#region Hàng hóa dịch vụ không đủ điều kiện khấu trừ
			iFirstCell = true;
			iStt += 4;
			iStt2 += 4;

			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";

			if (arrDv02.Length > 0)
			{
				foreach (DataRow dr in arrDv02)
				{
					iStt++;
					iStt2++;

                    strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ghi_Chu"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";                    


					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;

                strFile += "<Cells>" + "\n\t";
                strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += "</Cells>" + "\n\t";


				iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";
			#endregion

			#region Hàng hóa dịch vụ dùng chung chịu thuế và không chịu thuế
			iFirstCell = true;
			iStt += 4;
			iStt2 += 4;

			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";

			if (arrDv03.Length > 0)
			{
				foreach (DataRow dr in arrDv03)
				{
					iStt++;
					iStt2++;

                    strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ghi_Chu"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";                    

					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;

                strFile += "<Cells>" + "\n\t";
                strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += "</Cells>" + "\n\t";

				iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";

			#endregion

			#region Hàng hóa, dịch vụ dùng cho dự án đầu tư đủ điều kiện được khấu trừ thuế
			iFirstCell = true;
			iStt += 4;
			iStt2 += 4;

			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";

			if (arrDv04.Length > 0)
			{
				foreach (DataRow dr in arrDv04)
				{
					iStt++;
					iStt2++;

                    strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ghi_Chu"] + "| StatusID=|0001|/>" + "\n\t";             
                    strFile += "</Cells>" + "\n\t";

					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;
                strFile += "<Cells>" + "\n\t";
                strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += "</Cells>" + "\n\t";
                iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";

			#endregion

			#region Hàng hóa, dịch vụ không phải tổng hợp trên tờ khai
			iFirstCell = true;
			iStt += 4;
			iStt2 += 4;

			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";

			if (arrDv05.Length > 0)
			{
				foreach (DataRow dr in arrDv05)
				{
					iStt++;
					iStt2++;

                    strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ghi_Chu"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";               


					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;

                strFile += "<Cells>" + "\n\t";
                strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += "</Cells>" + "\n\t";
                iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";

			#endregion

			#region Tổng tiền
			iStt += 13;
			iStt2 += 9;

			string strTongTien = @"<Section Dynamic=|0| MaxRows=|0|>
									<Cells>
										<Cell CellID=|F_" + iStt + @"| CellID2=|V_" + iStt2 + "| Encode=|1| Value=|" + Convert.ToInt64(Common.SumDCValue(dtThueVAT1, "Tien", "Bold = false")).ToString() + @"|/>
										<Cell CellID=|F_" + (iStt + 1) + @"| CellID2=|V_" + (iStt2 + 2) + "| Encode=|1| Value=|" + Convert.ToInt64(Common.SumDCValue(dtThueVAT1, "Tien3", "Bold = false")).ToString() + @"|/>
									</Cells>
									</Section>";

			strFile += strTongTien;
			#endregion

			strFile += this.strXmlFooter;

			strFile = strFile.Replace("|", @"""");
			strFile = strFile.Replace("&", @"");

			while (strFile.Contains("		"))
			{
				strFile = strFile.Replace("		", "	");				
			}

			File.WriteAllText(this.strXmlFileVao, strFile);
		}

		void WriteDauRa()
		{
			int iStt = 7;
			int iStt2 = 17;
			bool iFirstCell = true;

			DataRow[] arrDr01 = dtThueVAT2.Select("Thue_GtGt = 0 AND Bold = 0 AND Phan_Loai_Thue = 'R01'");
			DataRow[] arrDr02 = dtThueVAT2.Select("Thue_GtGt = 0 AND Bold = 0 AND Phan_Loai_Thue = 'R02'");
			DataRow[] arrDr03 = dtThueVAT2.Select("Thue_GtGt = 5 AND Bold = 0 AND Phan_Loai_Thue = 'R03'");
			DataRow[] arrDr04 = dtThueVAT2.Select("Thue_GtGt = 10 AND Bold = 0 AND Phan_Loai_Thue = 'R04'");
			DataRow[] arrDr05 = dtThueVAT2.Select("Bold = 0 AND Phan_Loai_Thue = 'R05'");

			string strFile = this.strXmlHeader;

			#region Hàng không chiu thuế

			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";

			if (arrDr01.Length > 0)
			{
				foreach (DataRow dr in arrDr01)
				{
					iStt++;
					iStt2++;

                    strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|"+ (string)dr["Ma_HOADON"] +"| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";


					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;

				strFile += "<Cells>" + "\n\t";
				strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
				strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
				strFile += "</Cells>" + "\n\t";

				iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";
			#endregion

			#region Thue suat 0

			iFirstCell = true;
			iStt += 4;
			iStt2 += 4;

			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";

			if (arrDr02.Length > 0)
			{
				foreach (DataRow dr in arrDr02)
				{
					iStt++;
					iStt2++;

                    strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";

					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;

                strFile += "<Cells>" + "\n\t";
                strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += "</Cells>" + "\n\t";

				iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";
			#endregion

			#region 5%
			iFirstCell = true;
			iStt += 4;
			iStt2 += 4;

			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";
			if (arrDr03.Length > 0)
			{
				foreach (DataRow dr in arrDr03)
				{
					iStt++;
					iStt2++;

					strFile += "<Cells>" + "\n\t";
                    strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";

					strFile += "</Cells>" + "\n\t";

					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;
                				
                strFile += "<Cells>" + "\n\t";
                strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += "</Cells>" + "\n\t";

				iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";

			#endregion

			#region 10
			iFirstCell = true;
			iStt += 4;
			iStt2 += 4;
			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";
			if (arrDr04.Length > 0)
			{
				foreach (DataRow dr in arrDr04)
				{
					iStt++;
					iStt2++;
                    					
                    strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";

					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;

				strFile += "<Cells>" + "\n\t";                
                strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += "</Cells>" + "\n\t";

				iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";
			#endregion

			#region Hàng hóa, dịch vụ không phải tổng hợp trên tờ khai
			iFirstCell = true;
			iStt += 4;
			iStt2 += 4;
			strFile += "<Section Dynamic=|1| MaxRows=|0|>" + "\n\t";
			if (arrDr05.Length > 0)
			{
				foreach (DataRow dr in arrDr05)
				{
					iStt++;
					iStt2++;

					strFile += "<Cells>" + "\n\t";
                    strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["KH_HOADON"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Seri0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["So_Ct0"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (dr["Ngay_Ct0"] == DBNull.Value ? "" : Library.DateToStr((DateTime)dr["Ngay_Ct0"])) + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_DtGtGt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ma_So_Thue"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + (string)dr["Ten_Vt"] + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Thue_GtGt"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|" + Convert.ToInt64(dr["Tien3"]).ToString() + "| StatusID=|0001|/>" + "\n\t";
                    strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                    strFile += "</Cells>" + "\n\t";					

					iFirstCell = false;
				}
			}
			else
			{
				iStt++;
				iStt2++;

				strFile += "<Cells>" + "\n\t";                
                strFile += @"<Cell CellID=|C_" + iStt + "| CellID2=|AU_" + iStt2 + "| FirstCell=|" + (iFirstCell ? "0" : "1") + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|D_" + iStt + "| CellID2=|C_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|E_" + iStt + "| CellID2=|E_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|F_" + iStt + "| CellID2=|G_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|G_" + iStt + "| CellID2=|M_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|H_" + iStt + "| CellID2=|R_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|I_" + iStt + "| CellID2=|X_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|J_" + iStt + "| CellID2=|AB_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|K_" + iStt + "| CellID2=|AF_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|L_" + iStt + "| CellID2=|AJ_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|M_" + iStt + "| CellID2=|AN_" + iStt2 + "| Encode=|1| Receive=|1| Value=|0| StatusID=|0001|/>" + "\n\t";
                strFile += @"<Cell CellID=|N_" + iStt + "| CellID2=|AR_" + iStt2 + "| Encode=|1| Receive=|1| Value=|| StatusID=|0001|/>" + "\n\t";
                strFile += "</Cells>" + "\n\t";

				iFirstCell = false;
			}
			strFile += "</Section>" + "\n\t";
			#endregion

			#region Tổng tiền
			iStt += 4;
			iStt2 += 4;

			string strTongTien = @"<Section Dynamic=|0| MaxRows=|0|>
									<Cells>
										<Cell CellID=|F_" + iStt + @"| CellID2=|V_" + iStt2 + "| Encode=|1| Value=|" + Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien", "(Bold = false AND Phan_Loai_Thue <> 'R01') OR (Bold = false AND Phan_Loai_Thue <> 'R05')")).ToString() + @"|/>
										<Cell CellID=|F_" + (iStt + 1) + @"| CellID2=|V_" + (iStt2 + 4) + "| Encode=|1| Value=|" + Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien3", "(Bold = false AND Phan_Loai_Thue <> 'R01') OR (Bold = false AND Phan_Loai_Thue <> 'R05')")).ToString() + @"|/>
										<Cell CellID=|F_" + (iStt + 2) + @"| CellID2=|V_" + (iStt2 + 2) + "| Encode=|1| Value=|" + Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien", "(Bold = false AND Phan_Loai_Thue <> 'R05')")).ToString() + @"|/>
									</Cells>
									</Section>" + "\n\t";

			strFile += strTongTien;
			#endregion

			strFile += this.strXmlFooter;

			strFile = strFile.Replace("|", @"""");
			strFile = strFile.Replace("&", @"");

			while (strFile.Contains("		"))
			{
				strFile = strFile.Replace("		", "	");				
			}


			File.WriteAllText(this.strXmlFileRa, strFile);
		}

		void WriteToKhai()
		{
			double dTien_CT23 = Convert.ToInt64(Common.SumDCValue(dtThueVAT1, "Tien", "(Bold = false AND Phan_Loai_Thue <> 'V05')"));
			double dTien3_CT24 = Convert.ToInt64(Common.SumDCValue(dtThueVAT1, "Tien3", "(Bold = false AND Phan_Loai_Thue <> 'V05')"));
			double dTien3_CT25 = Convert.ToInt64(Common.SumDCValue(dtThueVAT1, "Tien3", "(Bold = false AND Phan_Loai_Thue = 'V01')"));
			double dTien_CT26 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien", "(Bold = false AND Phan_Loai_Thue = 'R01')"));
			double dTien_CT27 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien", "(Bold = false AND Phan_Loai_Thue <> 'R01') AND (Bold = false AND Phan_Loai_Thue <> 'R05')"));
			double dTien3_CT28 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien3", "(Bold = false AND Phan_Loai_Thue <> 'R01') AND (Bold = false AND Phan_Loai_Thue <> 'R05')"));
			double dTien_CT29 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien", "(Bold = false AND Phan_Loai_Thue = 'R02')"));
			double dTien_CT30 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien", "(Bold = false AND Phan_Loai_Thue = 'R03')"));
			double dTien3_CT31 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien3", "(Bold = false AND Phan_Loai_Thue = 'R03')"));
			double dTien_CT32 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien", "(Bold = false AND Phan_Loai_Thue = 'R04')"));
			double dTien3_CT33 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien3", "(Bold = false AND Phan_Loai_Thue = 'R04')"));
			double dTien_CT34 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien", "((Bold = false AND Phan_Loai_Thue <> 'R01') OR (Bold = false AND Phan_Loai_Thue <> 'R05'))"));
			double dTien3_CT35 = Convert.ToInt64(Common.SumDCValue(dtThueVAT2, "Tien3", "((Bold = false AND Phan_Loai_Thue <> 'R01') OR (Bold = false AND Phan_Loai_Thue <> 'R05'))"));

			string strFile = this.strXmlHeader +
				@"<Section Dynamic=|0| MaxRows=|0|>
					<Cells>
						<Cell CellID=|D_7| CellID2=|R_63| Encode=|1| Value=|| MCT=||/>
					</Cells>
				</Section>
				<Section Dynamic=|0| MaxRows=|0|>
					<Cells>
						<Cell CellID=|I_23| CellID2=|BS_36| Encode=|1| Value=|| MCT=||/>
						<Cell CellID=|L_24| CellID2=|CT_37| Encode=|1| Value=|0| MCT=|11|/>
						<Cell CellID=|J_27| CellID2=|BW_40| Encode=|1| Value=|" + dTien_CT23.ToString() + @"| MCT=|11|/>
						<Cell CellID=|L_27| CellID2=|CT_40| Encode=|1|  Receive=|0| Value=|" + dTien3_CT24.ToString() + @"| MCT=||/>
						<Cell CellID=|L_28| CellID2=|CT_41| Encode=|1| Value=|" + dTien3_CT25.ToString() + @"| MCT=||/>
						<Cell CellID=|J_30| CellID2=|BW_43| Encode=|1| Value=|" + dTien_CT26.ToString() + @"| MCT=||/>
						<Cell CellID=|J_31| CellID2=|BW_44| Encode=|1| Value=|" + dTien_CT27.ToString() + @"| MCT=||/>
						<Cell CellID=|L_31| CellID2=|CT_44| Encode=|1| Value=|" + dTien3_CT28.ToString() + @"| MCT=||/>
						<Cell CellID=|J_32| CellID2=|BW_45| Encode=|1| Value=|" + dTien_CT29.ToString() + @"| MCT=||/>
						<Cell CellID=|J_33| CellID2=|BW_46| Encode=|1| Value=|" + dTien_CT30.ToString() + @"| MCT=||/>
						<Cell CellID=|L_33| CellID2=|CT_46| Encode=|1| Value=|" + dTien3_CT31.ToString() + @"| MCT=||/>
						<Cell CellID=|J_34| CellID2=|BW_47| Encode=|1| Value=|" + dTien_CT32.ToString() + @"| MCT=||/>
						<Cell CellID=|L_34| CellID2=|CT_47| Encode=|1| Receive=|0| Value=|" + dTien3_CT33.ToString() + @"| MCT=||/>
						<Cell CellID=|J_35| CellID2=|BW_48| Encode=|1| Value=|" + dTien_CT34.ToString() + @"| MCT=||/>
						<Cell CellID=|L_35| CellID2=|CT_48| Encode=|1| Receive=|0| Value=|" + dTien3_CT35.ToString() + @"| MCT=||/>
						<Cell CellID=|L_36| CellID2=|CT_49| Encode=|1| Receive=|0| Value=|0| MCT=||/>
						<Cell CellID=|L_38| CellID2=|CT_51| Encode=|1| Value=|0| MCT=||/>
						<Cell CellID=|L_39| CellID2=|CT_52| Encode=|1| Receive=|0| Value=|0| MCT=||/>
						<Cell CellID=|L_40| CellID2=|CT_53| Encode=|1| Receive=|0| Value=|0| MCT=||/>
						<Cell CellID=|L_42| CellID2=|CT_55| Encode=|1| Value=|0| MCT=||/>
						<Cell CellID=|L_43| CellID2=|CT_56| Encode=|1| Value=|0| MCT=||/>
						<Cell CellID=|L_44| CellID2=|CT_57| Encode=|1| Value=|0| MCT=||/>
						<Cell CellID=|L_45| CellID2=|CT_58| Encode=|1| Value=|0| MCT=||/>
						<Cell CellID=|L_46| CellID2=|CT_59| Encode=|1| Value=|0| MCT=||/>
						<Cell CellID=|L_47| CellID2=|CT_60| Encode=|1| Value=|0| MCT=||/>
					</Cells>
				</Section>
				<Section Dynamic=|0| MaxRows=|0|>
					<Cells>
						<Cell CellID=|D_49| CellID2=|U_65| Encode=|1| Value=|| MCT=||/>
						<Cell CellID=|D_50| CellID2=|U_66| Encode=|1| Receive=|0| Value=|| MCT=||/>
						<Cell CellID=|K_49| CellID2=|BV_67| Encode=|1| Value=|| MCT=||/>
						<Cell CellID=|K_50| CellID2=|C_63| Encode=|1| Value=|" + Library.DateToStr(DateTime.Now) + @"| MCT=||/>
						<Cell CellID=|K_52| CellID2=|Y_63| Encode=|1| Value=|1| MCT=||/>
						<Cell CellID=|L_52| CellID2=|AG_63| Encode=|1| Value=|| MCT=||/>
						<Cell CellID=|O_52| CellID2=|AH_63| Encode=|1| Receive=|1| Value=||/>
						<Cell CellID=|L_14| CellID2=|| Encode=|1| Receive=|1| Value=|1701|/>
                        <Cell CellID=|B_18| CellID2=|C_33| Encode=|1| Receive=|1| Value=||/>
                        <Cell CellID=|D_20| CellID2=|O_34| Encode=|0| Receive=|1| Value=||/>
                        <Cell CellID=|P_20| CellID2=|W_63| Encode=|1| Receive=|1| Value=||/>
                        <Cell CellID=|N_52| CellID2=|AM_63| Encode=|1| Receive=|1| Value=||/>
					</Cells>
				</Section> " + "\n\t" +
				this.strXmlFooter;

			strFile = strFile.Replace("|", @"""");

			while (strFile.Contains("		"))
			{
				strFile = strFile.Replace("		", "	");
			}

			File.WriteAllText(this.strXmlFileToKhai, strFile);
		}

		void btPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			//fbd.RootFolder = Environment.SpecialFolder.Desktop;
			fbd.SelectedPath = txtPath.Text;
			fbd.Description = "Send path";

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				txtPath.Text = fbd.SelectedPath;

				Common.SetBufferValue("EXPORTVAT_PATH", txtPath.Text);
			}
		}

		void txtTk_Vat1_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Vat1.Text.Trim();
			bool bRequire = true;

            //frmTaiKhoan frmLookup = new frmTaiKhoan();
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "Tk LIKE '133%'", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Vat1.Text = string.Empty;
				lbtTen_Tk_Vat1.Text = string.Empty;
			}
			else
			{
				txtTk_Vat1.Text = drLookup["Tk"].ToString();
				lbtTen_Tk_Vat1.Text = drLookup["Ten_Tk"].ToString();
			}

			//SetPath();
		}

		void txtTk_Vat2_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Vat2.Text.Trim();
			bool bRequire = true;

           
			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "Tk LIKE '3331%'", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Vat2.Text = string.Empty;
				lbtTen_Tk_Vat2.Text = string.Empty;
			}
			else
			{
				txtTk_Vat2.Text = drLookup["Tk"].ToString();
				lbtTen_Tk_Vat2.Text = drLookup["Ten_Tk"].ToString();
			}

			//SetPath();
		}

		void dteNgay_Ct2_Validating(object sender, CancelEventArgs e)
		{
			//SetPath();
		}

		void btMa_DvCs_List_Click(object sender, EventArgs e)
		{
			string strValue = txtMa_DvCs_List.Text;
			bool bRequire = true;
			string strKey = "";

			frmQuickLookup frmLookup = new frmQuickLookup("SYSDmDvCs", "DMDVCS", true);
			DataRow drLookup = Lookup.ShowLookup(frmLookup, "SYSDmDvCs", "Ma_DvCs", strValue, bRequire, strKey);

			if (drLookup == null)
				txtMa_DvCs_List.Text = string.Empty;
			else
			{
				txtMa_DvCs_List.Text = drLookup["MuiltiSelectValue"].ToString();
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (!FormCheckValid())
				return;

            string thong = Library.StrToDate(dteNgay_Ct2.Text).Month.ToString().PadLeft(2, '0');

            //Tính ra quý
            if (Library.StrToDate(dteNgay_Ct2.Text).Month.ToString().PadLeft(2, '0') == "03")
                strQuy = "Q01";
            else if (Library.StrToDate(dteNgay_Ct2.Text).Month.ToString().PadLeft(2, '0') == "06")
                strQuy = "Q02";
            else if (Library.StrToDate(dteNgay_Ct2.Text).Month.ToString().PadLeft(2, '0') == "09")
                strQuy = "Q03";
            else
                strQuy = "Q04";

			Common.ShowStatus(Languages.GetLanguage("In_Process"));

			this.WriteData();

			EpointMessage.MsgOk(Languages.GetLanguage("End_Process"));
			Common.EndShowStatus();

			try
			{
				Common.SetBufferValue("EXPORTVAT_MA_DVCS_LIST", txtMa_DvCs_List.Text);
				Common.SetBufferValue("TK_VAT_DAUVAO", txtTk_Vat1.Text);
				Common.SetBufferValue("TK_VAT_DAURA", txtTk_Vat2.Text);
			}
			catch (Exception)
			{
				EpointMessage.MsgOk("Không ghi vào được Register!");
				throw;
			}

			Element.sysNgay_Ct1 = Library.StrToDate(this.dteNgay_Ct1.Text);
			Element.sysNgay_Ct2 = Library.StrToDate(this.dteNgay_Ct2.Text);

			this.Close();            
		}

		void btCancel_Click(object sender, EventArgs e)
		{
            this.Close();
		}
	}
}
