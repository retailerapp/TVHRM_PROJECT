using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;
using System.Data.SqlClient;
using System.Collections;

namespace Epoint.Modules.HRM
{
	public partial class frmLamViec_Edit : frmEdit
	{
		#region Phuong thuc

		public frmLamViec_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			//this.chkIs_Chuyen_Ma_Kv.CheckedChanged += new EventHandler(Chk_CheckedChanged);
			this.chkIs_Changed.CheckedChanged += new EventHandler(Chk_CheckedChanged);
			this.chkIs_Nghi_Viec.CheckedChanged += new EventHandler(Chk_CheckedChanged);
			cboType_Changed.TextChanged += new EventHandler(cbo_TextChanged);

		}
		void cbo_TextChanged(object sender, EventArgs e)
		{
			if (txtMa_CbNv.Text.Trim() == string.Empty || cboType_Changed.Text.Trim() == string.Empty)
				return;
			{
				txtValue_New.KeyFilter = cboType_Changed.Text;

				Hashtable htParameter = new Hashtable();
				htParameter.Add("MA_CBNV", txtMa_CbNv.Text);
				htParameter.Add("TYPECHANGED", cboType_Changed.Text.Trim());
				string strValue_Current = SQLExec.ExecuteReturnValue("HRM_GetCurentValueByType", htParameter, CommandType.StoredProcedure).ToString();

				txtValue_Current.Text = strValue_Current;
			}




		}
		private void Chk_CheckedChanged(object sender, EventArgs e)
        {
   //         if(this.chkIs_Chuyen_Ma_Kv.Checked)
   //         {
			//	txtMa_Kv_Den.Enabled = true;
			//	txtNgay_Chuyen_Ma_Kv.Enabled = true;
			//	txtNgay_Chuyen_Ma_Kv.Text = Library.DateToStr(DateTime.Now);
			//}	
			//else
   //         {
			//	txtMa_Kv_Den.Enabled = false;
			//	txtNgay_Chuyen_Ma_Kv.Enabled = false;
			//	txtNgay_Chuyen_Ma_Kv.Text = Library.DateToStr(Element.sysNgay_Min);
			//}


			if (this.chkIs_Nghi_Viec.Checked)
			{
				txtSo_Nghi_Viec.Enabled = true;
				txtNgay_End.Enabled = true;
				txtNgay_End.Text = Library.DateToStr(DateTime.Now);

				this.chkIs_Thu_Viec.Checked = false;
				this.chkIs_Bat_Dau.Checked = false;
				this.chkIs_Changed.Checked = false;

				txtNgay_Begin.Text = Library.DateToStr(Element.sysNgay_Min);
				txtNgay_Changed.Text = Library.DateToStr(Element.sysNgay_Min);
				txtNgay_Thu_Viec.Text = Library.DateToStr(Element.sysNgay_Min);

			}
			else
			{
				txtSo_Nghi_Viec.Enabled = false;
				txtNgay_End.Enabled = false;
				txtNgay_End.Text = Library.DateToStr(Element.sysNgay_Min);
				
			}
			if (this.chkIs_Changed.Checked)
			{
				txtValue_Current.Enabled = true;
				txtValue_New.Enabled = true;
				txtNgay_Changed.Enabled = true;
				cboType_Changed.Enabled = true;
				txtNgay_Changed.Text = Library.DateToStr(DateTime.Now);

				if (cboType_Changed.Text.Trim() != string.Empty)
				{
					txtValue_New.KeyFilter = cboType_Changed.Text;
				}

				this.chkIs_Thu_Viec.Checked = false;
				this.chkIs_Bat_Dau.Checked = false;
				this.chkIs_Nghi_Viec.Checked = false;
				txtNgay_Begin.Text = Library.DateToStr(Element.sysNgay_Min);
				txtNgay_End.Text = Library.DateToStr(Element.sysNgay_Min);
				txtNgay_Thu_Viec.Text = Library.DateToStr(Element.sysNgay_Min);
			}
			else
			{
				txtValue_Current.Enabled = false;
				txtValue_New.Enabled = false;
				txtNgay_Changed.Enabled = false;
				cboType_Changed.Enabled = false;
				txtNgay_End.Text = Library.DateToStr(Element.sysNgay_Min);
				txtValue_Current.Text = string.Empty;
				txtValue_New.Text = string.Empty;
			}
		}

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;		

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
			LoadCbo();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//txtMa_Dt
			if (txtMa_CbNv.Text.Trim() != string.Empty)
				lbtTen_CbNv.Text = DataTool.SQLGetNameByCode("LINHANVIEN", "Ma_CBNV", "Ten_CbNv", txtMa_CbNv.Text.Trim());
			else
				lbtTen_CbNv.Text = string.Empty;


			if (txtMa_Kv_Den.Text.Trim() != string.Empty)
				lbtTen_Kv.Text = DataTool.SQLGetNameByCode("LIKHUVUC", "Ma_Kv", "Ten_Kv", txtMa_Kv_Den.Text.Trim());
			else
				lbtTen_Kv.Text = string.Empty;

		}
		private void LoadCbo()
		{
			DataTable dtDmHD = SQLExec.ExecuteReturnDt("SP_HRM_GetDataCombobox 'TYPECHANGE'");
			//dtDmBp.Rows.Add(new string[] { "*", "Tất cả" });

			cboType_Changed.lstItem.BuildListView("Code:200,Label:250");
			cboType_Changed.lstItem.DataSource = dtDmHD;
			cboType_Changed.lstItem.Size = new Size(320, cboType_Changed.lstItem.Items.Count * 30);
			cboType_Changed.lstItem.GridLines = true;


		}
		public bool FormCheckValid()
		{
			bool bvalid = true;
            if (chkIs_Nghi_Viec.Checked)
            {                
                if (Library.StrToDate(txtNgay_End.Text) == Element.sysNgay_Min)
                {
                    EpointMessage.MsgOk("Ngày nghỉ không được trống");
                    return false;
                }
            }

            if (chkIs_Changed.Checked)
			{
				if (txtValue_New.Text.Trim() == string.Empty)
				{
					Common.MsgOk("Dữ liệu thay đổi không được rỗng!");
					return false;
				}
				if (Library.StrToDate(txtNgay_Changed.Text) == Element.sysNgay_Min)
				{
					EpointMessage.MsgOk("Ngày thay đổi dữ liệu không được trống");
					return false;
				}
			}

			return bvalid;
		}
		public void SetEffectDate(ref DataRow dataRow)
		{
			if (this.chkIs_Nghi_Viec.Checked)
			{
				dataRow["Date_Effect"] = dataRow["Ngay_End"];

			}
			else if (this.chkIs_Changed.Checked)
			{
				dataRow["Date_Effect"] = dataRow["Ngay_Changed"];
			}
			else if (this.chkIs_Bat_Dau.Checked)
			{
				dataRow["Date_Effect"] = dataRow["Ngay_Begin"];
			}
			else if (this.chkIs_Thu_Viec.Checked)
			{
				dataRow["Date_Effect"] = dataRow["Ngay_Thu_Viec"];
			}
		}
		public bool Save()
		{
			
			Common.GatherMemvar(this, ref drEdit);
			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			SetEffectDate(ref drEdit);

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "HRLAMVIEC", ref drEdit))
			{
				return false;
			}
			if(chkIs_Changed.Checked)
            {

				//string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to change Zone ?" : "Bạn có muốn cập nhật lại khu vực cho nhân viên không ?";
				//if (Common.MsgYes_No(strMsg))
    //            {
				//	SQLExec.ExecuteNotMessage("UPDATE LINHANIEN SET Ma_Kv = '"+txtMa_Kv_Den.Text+"',Dia_Ban = '"+txtMa_Kv_Den.Text+"'",null,CommandType.Text);
    //            }					


			}
			if (chkIs_Nghi_Viec.Checked)
			{
				SQLExec.Execute("UPDATE LINHANVIEN SET Is_Nghi_Viec = 1 , Ngay_End  = '"+ txtNgay_End.Text + "', Trang_Thai = N'Đã nghỉ việc', StatusId = 4 WHERE Ma_Cbnv = '" + txtMa_CbNv.Text + "'");
			}
			return true;
		}
		#endregion

		#region Su kien
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
		#endregion
	}
}
