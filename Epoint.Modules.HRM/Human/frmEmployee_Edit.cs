using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Lists;

namespace Epoint.Modules.HRM
{
	public partial class frmEmployee_Edit : Epoint.Systems.Customizes.frmEdit
	{
		//Byte[] barrImg;
		//long lImgFileLength = 0;

		string strMa_CbNv = string.Empty;
		DataRow drCurrent;

		#region Phuong thuc

		public frmEmployee_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_ViTri.Validating += new CancelEventHandler(txtMa_ViTri_Validating);
            txtMa_Kv.Validating += new CancelEventHandler(txtMa_Kv_Validating);  

			this.picHinh.DoubleClick += new EventHandler(picHinhLoad);

            this.btXoa_Anh.Click += new EventHandler(btXoa_Anh_Click);


            this.cboTrang_Thai.SelectedValueChanged += new EventHandler(CboTrang_Thai_SelectedValueChanged);
		}

        

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{            
            this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
			this.strMa_CbNv = (string)drEdit["Ma_CbNv"];
			this.ActiveControl = txtMa_CbNv;

            LoadDataCombobox();

            if (enuNew_Edit == enuEdit.New)              
            {
                this.drEdit = DataTool.SQLGetDataTable("LINHANVIEN", null, "0 = 1", "Ma_Cbnv").NewRow();
                DataRow temp = DataTool.SQLGetDataRowByID("LINHANVIEN", "Ma_Cbnv", drEdit["Ma_Cbnv"].ToString());
                if (temp != null)
                    Common.CopyDataRow(temp, this.drEdit);

                this.drEdit["Ma_Cbnv"] = GetNewID();
            }

            if (enuNew_Edit == enuEdit.Edit)
            {
                txtMa_CbNv.Enabled = false; 
            }

			Common.ScaterMemvar(this, ref this.drEdit);
            txtMa_Data.Text = Element.sysMa_DvCs;

			BindingLanguage();
			LoadDicName();
            
            BindingPicture();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            //txtMa_Bp
            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("LIBOPHAN", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
                dicName.SetValue(lbtTen_Bp.Name, lbtTen_Bp.Text);
            }
            else
                lbtTen_Bp.Text = string.Empty;

            //txtMa_ViTri
            if (txtMa_ViTri.Text.Trim() != string.Empty)
            {
                lbtTen_ViTri.Text = DataTool.SQLGetNameByCode("HRVITRI", "Ma_ViTri", "Ten_ViTri", txtMa_ViTri.Text.Trim());
                dicName.SetValue(lbtTen_ViTri.Name, lbtTen_ViTri.Text);
            }
            else
                lbtTen_Bp.Text = string.Empty;


            //txtMa_Bp
            if (txtMa_Kv.Text.Trim() != string.Empty)
            {
                lbtTen_Kv.Text = DataTool.SQLGetNameByCode("LIKHUVUC", "Ma_Kv", "Ten_Kv", txtMa_Kv.Text.Trim());
                dicName.SetValue(lbtTen_Kv.Name, lbtTen_Kv.Text);
            }
            else
                lbtTen_Kv.Text = string.Empty;

		}
        private void LoadDataCombobox()
        {
            cboTrang_Thai.DataSource = SQLExec.ExecuteReturnDt(@"SP_HRM_GetDataCombobox 'TRANG_THAI' ");
            cboTrang_Thai.ValueMember = "Code";
            cboTrang_Thai.DisplayMember = "Description";

        }
        public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTen_CbNv.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

            if(this.cboTrang_Thai.Text =="Đã nghỉ việc")
            {
                if (Library.StrToDate(txtNgay_End.Text) == Element.sysNgay_Min)
                {
                    EpointMessage.MsgOk("Ngày nghỉ việc không được trống");
                    return false;
                }
                if (Library.StrToDate(txtNgay_End.Text)<= Library.StrToDate(dteNgay_Bd.Text))
                {
                    EpointMessage.MsgOk("Ngày nghỉ việc không được nhỏ hơn ngày bắt đầu");
                    txtNgay_End.Focus();
                    return false;
                }
            }


			return bvalid;
		}

		public bool Save()
		{
            //Update lai Ma_CbNv
            strMa_CbNv = txtMa_CbNv.Text;

			Common.GatherMemvar(this, ref drEdit);

            if (cboTrang_Thai.Text == "Đã nghỉ việc")
            {                
                drEdit["Is_nghi_viec"] = 1;
            }
            else
            {
                drEdit["Is_nghi_viec"] = 0;
                drEdit["Ngay_End"] = Element.sysNgay_Min;
                drEdit["So_nghi_viec"] = string.Empty;
            }
            //Kiem tra Valid tren Form
            if (!FormCheckValid())
				return false;

            if (drEdit.Table.Columns.Contains("Hinh"))
                drEdit.Table.Columns.Remove("Hinh");

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "LINHANVIEN", ref drEdit))
				return false;

			this.SavePicture();

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_CBNV", drEdit);

			return true;
		}
        private string GetNewID()
        {
            string Ma_CBNV_Latest= SQLExec.ExecuteReturnValue("SELECT Ma_Cbnv =  Max(Ma_Cbnv) from LINHANVIEN WHERE ISNUMERIC(Ma_Cbnv) = 1 ").ToString();

            string strMa_Dt_New = string.Empty;

            if (Ma_CBNV_Latest == "")
                Ma_CBNV_Latest = "00001";

            Hashtable htParameter = new Hashtable();
            htParameter.Add("TABLENAME", "LINHANVIEN");
            htParameter.Add("COLUMNNAME", "MA_CBNV");
            htParameter.Add("CURRENTID", Ma_CBNV_Latest);
            htParameter.Add("KEY", "");
            htParameter.Add("NGAY_CT", "");
            htParameter.Add("SUFFIXLEN", "");
            strMa_Dt_New = SQLExec.ExecuteReturnValue("sp_GetNewId", htParameter, CommandType.StoredProcedure).ToString();

            return strMa_Dt_New;
        }
		#region Picture

		private void BindingPicture()
		{
			object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM LINHANVIEN WHERE Ma_CbNv = '" + strMa_CbNv + "'");
			Byte[] bytePic = (Byte[])objPic;

			if (objPic != null && bytePic.Length != 0)
			{
				byte[] barrImg = bytePic;
				string strFileName = Convert.ToString(DateTime.Now.ToFileTime());
				FileStream fs = new FileStream(strFileName, FileMode.CreateNew, FileAccess.Write);
				fs.Write(barrImg, 0, barrImg.Length);
				fs.Flush();
				fs.Close();
				picHinh.Image = Image.FromFile(strFileName);
				picHinh.SizeMode = PictureBoxSizeMode.Zoom;
			}
		}

		private void LoadPicture()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

			fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			fileDialog.Filter = fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*"; ;

			if (fileDialog.ShowDialog() != DialogResult.OK)
				return;

			FileInfo fiImage = new FileInfo(fileDialog.FileName);
			FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

			picHinh.Image = new Bitmap(Image.FromStream(fs), picHinh.Size);
			picHinh.SizeMode = PictureBoxSizeMode.Zoom;
		}

		private void SavePicture()
		{
			Hashtable ht = new Hashtable();

			if (picHinh.Image != null)
			{
				byte[] barrImg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(picHinh.Image).ConvertTo(picHinh.Image, typeof(byte[]));
				ht["HINH"] = barrImg;
			}
			else
			{
				ht["HINH"] = new byte[] { };
			}

			SQLExec.Execute("UPDATE LINHANVIEN SET Hinh = @Hinh WHERE Ma_CbNv = '" + strMa_CbNv + "'", ht, CommandType.Text);
		}

        #endregion

        #endregion

        #region Su kien

        private void CboTrang_Thai_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTrang_Thai.Text == "Đã nghỉ việc")
            {
                drEdit["Is_nghi_viec"] = 1;
                this.txtNgay_End.Enabled = true;
                this.txtSo_Nghi_Viec.Enabled = true;
            }
            else
            {
                drEdit["Is_nghi_viec"] = 0;
                this.txtNgay_End.Enabled = false;
                this.txtSo_Nghi_Viec.Enabled = false;
            }
            try
            {
                if (drEdit.Table.Columns.Contains("StatusId"))
                {
                    drEdit["StatusId"] = cboTrang_Thai.SelectedValue;
                }
            }
            catch (Exception)
            { }
        }
        void btXoa_Anh_Click(object sender, EventArgs e)
        {
            if (Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE_HINH")))
            {
                SQLExec.Execute("UPDATE LINHANVIEN SET Hinh = '' WHERE Ma_CbNv = '" + strMa_CbNv + "'");
                picHinh.Image = null;
            }                       
        }		

        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;

            //
            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
            }

            dicName.SetValue(lbtTen_Bp.Name, lbtTen_Bp.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
        void txtMa_ViTri_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_ViTri.Text.Trim();
            bool bRequire = false;

            frmViTri frmLookup = new frmViTri();
            DataRow drLookup = Lookup.ShowLookup(frmLookup, "HRVITRI", "Ma_ViTri", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_ViTri.Text = string.Empty;
                lbtTen_ViTri.Text = string.Empty;
            }
            else
            {
                txtMa_ViTri.Text = drLookup["Ma_ViTri"].ToString();
                lbtTen_ViTri.Text = drLookup["Ten_ViTri"].ToString();
            }

            dicName.SetValue(lbtTen_ViTri.Name, lbtTen_ViTri.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
        void txtMa_Kv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kv.Text.Trim();
            bool bRequire = false;

            frmViTri frmLookup = new frmViTri();
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
                txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();
                lbtTen_Kv.Text = drLookup["Ten_Kv"].ToString();
            }

            dicName.SetValue(lbtTen_Kv.Name, lbtTen_Kv.Text);

            if ((((txtTextLookup)sender).AutoFilter != null) && ((txtTextLookup)sender).AutoFilter.Visible)
            {
                ((txtTextLookup)sender).AutoFilter.Visible = false;
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
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

		void picHinhLoad(object sender, EventArgs e)
		{
			LoadPicture();			
		}

		#endregion

        
	}
}
