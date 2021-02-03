﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Lists;
using Epoint.Controllers;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;

namespace Epoint.Modules.HRM
{
	public partial class frmEmployee_DanhGia : Epoint.Lists.frmView
	{
		#region Khai bao bien
		private tlControl tlDmCbNv = new tlControl();

		DataTable dtEmployee;		
        DataTable dtDanhGia;        

		BindingSource bdsEmployee = new BindingSource();		
        BindingSource bdsDanhGia = new BindingSource();        

		private DataRow drCurrent;

		#endregion

		#region Contructor

		public frmEmployee_DanhGia()
		{
			InitializeComponent();

			bdsEmployee.PositionChanged += new EventHandler(bdsEmployee_PositionChanged);

            //btNew.Click += new EventHandler(btNew_Click);
            //btEdit.Click += new EventHandler(btEdit_Click);
            //btDelete.Click += new EventHandler(btDelete_Click);            
		}
		public override void Load()
		{
			this.Build();
			this.FillData(string.Empty);
			this.BindingData();
			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
            //
            tlDmCbNv = HRMCommon.GetTreeViewCust(this.isLookup);

            this.splControl1.Visible = false;
			this.pageEmployee.Controls.Add(tlDmCbNv);

            dgvDanhGia.strZone = "DANHGIA";
            dgvDanhGia.BuildGridView();
		}

		private void FillData(string strKey)
		{
            //dtEmployee = SQLExec.ExecuteReturnDt("EXEC Sp_GetDmCbNv");
            dtEmployee = HRMCommon.GetCustomerTable("MA_KV");
			bdsEmployee.DataSource = dtEmployee;
			tlDmCbNv.DataSource = bdsEmployee;
			//bdsEmployee.Position = 0;

			//DANHGIA
            dtDanhGia = DataTool.SQLGetDataTable("HRDANHGIA", null, strKey, "Ngay_DG");            
            bdsDanhGia.DataSource = dtDanhGia;
            dgvDanhGia.DataSource = bdsDanhGia;

            //Tham số các khoản thu nhập
			string strSQLExec =
				"SELECT T1.*, T2.Ten_Tn, T2.Dvt FROM HRPARAVALUE0 T1 LEFT JOIN HRPARALIST T2 ON T1.Ma_Tn = T2.Ma_Tn " +
					" ORDER BY Ngay_Ap";

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsEmployee;
			ExportControl = tlDmCbNv;

			tlDmCbNv.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlDmCbNv.strZone + "'");
		}

		private void BindingData()
		{
			foreach (Control ctrl in tpTTNV.Controls)
			{
                if (ctrl.GetType() == typeof(txtTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(txtDateTime) || ctrl.GetType() == typeof(cboControl) || ctrl.GetType() == typeof(ComboBox))
				{
					string strFieldName = ctrl.Name.Substring(3);

					if (((DataTable)bdsEmployee.DataSource).Columns.Contains(strFieldName))
						ctrl.DataBindings.Add("Text", bdsEmployee, strFieldName);
				}                
			}

			//picHinh.DataBindings.Add("Image", bdsEmployee, "Hinh");
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{			
            if (tabDetail.SelectedTab == pageDanhGia || dgvDanhGia.Focused)
                this.EditDanhGia(enuNew_Edit);            
		}

		public override void Delete()
		{
            if (tabDetail.SelectedTab == pageDanhGia || dgvDanhGia.Focused)
                this.DeleteDanhGia();            
		}
        //void btNew_Click(object sender, EventArgs e)
        //{   
        //    if (tabEmployee.Focused || pageEmployee.Focused || tlDmCbNv.Focused)
        //        this.EditEmployee(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageGiaDinh || dgvGiaDinh.Focused)
        //        this.EditGiaDinh(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageDaoTao || dgvDaoTao.Focused)
        //        this.EditDaoTao(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageCongTac || dgvCongTac.Focused)
        //        this.EditCongTac(enuEdit.New);        
        //    else if (tabDetail.SelectedTab == pageKhenThuong || dgvKhenThuong.Focused)
        //        this.EditKhenThuong(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageHopDong || dgvHopDong.Focused)
        //        this.EditHopDong(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageNghiPhep || dgvNghiPhep.Focused)
        //        this.EditNghiPhep(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageBaoHiem || dgvBaoHiem.Focused)
        //        this.EditBaoHiem(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageDanhGia || dgvDanhGia.Focused)
        //        this.EditDanhGia(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageKinhNghiem || dgvKinhNghiem.Focused)
        //        this.EditKinhNghiem(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageKyNang || dgvKyNang.Focused)
        //        this.EditKyNang(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageTuyenDung || dgvTuyenDung.Focused)
        //        this.EditTuyenDung(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageThue || dgvThue.Focused)
        //        this.EditThue(enuEdit.New);            
        //}
        //void btEdit_Click(object sender, EventArgs e)
        //{   
        //    if (tabEmployee.Focused || pageEmployee.Focused || tlDmCbNv.Focused)
        //        this.EditEmployee(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageGiaDinh || dgvGiaDinh.Focused)
        //        this.EditGiaDinh(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageDaoTao || dgvDaoTao.Focused)
        //        this.EditDaoTao(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageCongTac || dgvCongTac.Focused)
        //        this.EditCongTac(enuEdit.Edit);        
        //    else if (tabDetail.SelectedTab == pageKhenThuong || dgvKhenThuong.Focused)
        //        this.EditKhenThuong(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageHopDong || dgvHopDong.Focused)
        //        this.EditHopDong(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageNghiPhep || dgvNghiPhep.Focused)
        //        this.EditNghiPhep(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageBaoHiem || dgvBaoHiem.Focused)
        //        this.EditBaoHiem(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageDanhGia || dgvDanhGia.Focused)
        //        this.EditDanhGia(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageKinhNghiem || dgvKinhNghiem.Focused)
        //        this.EditKinhNghiem(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageKyNang || dgvKyNang.Focused)
        //        this.EditKyNang(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageTuyenDung || dgvTuyenDung.Focused)
        //        this.EditTuyenDung(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageThue || dgvThue.Focused)
        //        this.EditThue(enuEdit.Edit);            
        //}

        //void btDelete_Click(object sender, EventArgs e)
        //{
        //    if (tabEmployee.Focused || pageEmployee.Focused || tlDmCbNv.Focused)
        //        this.DeleteEmployee();
        //    else if (tabDetail.SelectedTab == pageGiaDinh || dgvGiaDinh.Focused)
        //        this.DeleteGiaDinh();
        //    else if (tabDetail.SelectedTab == pageDaoTao || dgvDaoTao.Focused)
        //        this.DeleteDaoTao();
        //    else if (tabDetail.SelectedTab == pageCongTac || dgvCongTac.Focused)
        //        this.DeleteCongTac();        
        //    else if (tabDetail.SelectedTab == pageKhenThuong || dgvKhenThuong.Focused)
        //        this.DeleteKhenThuong();
        //    else if (tabDetail.SelectedTab == pageHopDong || dgvHopDong.Focused)
        //        this.DeleteHopDong();
        //    else if (tabDetail.SelectedTab == pageNghiPhep || dgvNghiPhep.Focused)
        //        this.DeleteNghiPhep();
        //    else if (tabDetail.SelectedTab == pageBaoHiem || dgvBaoHiem.Focused)
        //        this.DeleteBaoHiem();
        //    else if (tabDetail.SelectedTab == pageDanhGia || dgvDanhGia.Focused)
        //        this.DeleteDanhGia();
        //    else if (tabDetail.SelectedTab == pageKinhNghiem || dgvKinhNghiem.Focused)
        //        this.DeleteKinhNghiem();
        //    else if (tabDetail.SelectedTab == pageKyNang || dgvKyNang.Focused)
        //        this.DeleteKyNang();
        //    else if (tabDetail.SelectedTab == pageTuyenDung || dgvTuyenDung.Focused)
        //        this.DeleteTuyenDung();
        //    else if (tabDetail.SelectedTab == pageThue || dgvThue.Focused)
        //        this.DeleteThue();               
        //}

		void EditEmployee(enuEdit enuNew_Edit)
		{
			if (bdsEmployee.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			if (bdsEmployee.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsEmployee.Current).Row, ref drCurrent);
			else
				drCurrent = dtEmployee.NewRow();

			frmEmployee_Edit frmEdit = new frmEmployee_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsEmployee.Position >= 0)
						dtEmployee.ImportRow(drCurrent);
					else
						dtEmployee.Rows.Add(drCurrent);

					bdsEmployee.Position = bdsEmployee.Find("MA_CBNV", drCurrent["MA_CBNV"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsEmployee.Current).Row);

				dtEmployee.AcceptChanges();
			}
		}
        void EditDanhGia(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsDanhGia.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsDanhGia.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDanhGia.Current).Row, ref drCurrent);
            else
                drCurrent = dtDanhGia.NewRow();

            drCurrent["Ma_CbNv"] = (string)drEmployee["Ma_CbNv"];

            frmDanhGia_Edit frmEdit = new frmDanhGia_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDanhGia.Position >= 0)
                        dtDanhGia.ImportRow(drCurrent);
                    else
                        dtDanhGia.Rows.Add(drCurrent);

                    bdsDanhGia.Position = bdsDanhGia.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsDanhGia.Current).Row);

                dtDanhGia.AcceptChanges();
            }
            else
                dtDanhGia.RejectChanges();
        }        
		void DeleteEmployee()
		{
			if (bdsEmployee.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsEmployee.Current).Row;

			if ((bool)drCurrent["Is_BoPhan"])
				return;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("LINHANVIEN", drCurrent))
			{
				bdsEmployee.RemoveAt(bdsEmployee.Position);
				dtEmployee.AcceptChanges();
			}
		}
        void DeleteDanhGia()
        {
            if (bdsDanhGia.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsDanhGia.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("HRDANHGIA", drCurrent))
            {
                bdsDanhGia.RemoveAt(bdsDanhGia.Position);
                dtDanhGia.AcceptChanges();
            }
        }        
		public override void MergeID()
		{
			if (bdsEmployee.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsEmployee.Current).Row;
			string strOldValue = (string)drCurrent["Ma_CbNv"];

			frmMergeID frm = new frmMergeID();

			frm.Load("LINHANVIEN", "Ma_CbNv", "Ten_CbNv", strOldValue, "DMCBNV");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_CbNv", "LINHANVIEN", strOldValue, strNewValue))
				{
					bdsEmployee.RemoveCurrent();
					bdsEmployee.Position = bdsEmployee.Find("Ma_CbNv", strNewValue);
				}
			}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsEmployee == null || bdsEmployee.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsEmployee.Current).Row;
			DataTable dtTemp = dtEmployee.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void EnterProcess()
		{
			if (bdsEmployee.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsEmployee.Current).Row;
				this.Close();
			}
		}

		#endregion

		#region Su kien

		void bdsEmployee_PositionChanged(object sender, EventArgs e)
		{
			drCurrent = ((DataRowView)bdsEmployee.Current).Row;

            bdsDanhGia.Filter = "Ma_CbNv = '" + drCurrent["Ma_CbNv"] + "'";
            
			object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM LINHANVIEN WHERE Ma_CbNv = '" + (string)drCurrent["Ma_CbNv"] + "'");
			Byte[] bytePic = (Byte[])objPic;
			if (objPic != null && objPic != DBNull.Value && bytePic.Length != 0)
			{
				byte[] barrImg = bytePic;
				string strFileName = Convert.ToString(DateTime.Now.ToFileTime());
				System.IO.FileStream fs = new System.IO.FileStream(strFileName, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
				fs.Write(barrImg, 0, barrImg.Length);
				fs.Flush();
				fs.Close();
				picHinh.Image = Image.FromFile(strFileName);
				picHinh.SizeMode = PictureBoxSizeMode.Zoom;
			}
			else
				picHinh.Image = null;
		}

        //void btDetailNew_Click(object sender, EventArgs e)
        //{
        //    if (tabDetail.SelectedTab == pageGiaDinh)
        //        this.EditGiaDinh(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageDaoTao)
        //        this.EditDaoTao(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageCongTac)
        //        this.EditCongTac(enuEdit.New);        
        //    else if (tabDetail.SelectedTab == pageKhenThuong)
        //        this.EditKhenThuong(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageHopDong)
        //        this.EditHopDong(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageNghiPhep)
        //        this.EditNghiPhep(enuEdit.New);
        //    else if (tabDetail.SelectedTab == pageTsTn0)
        //        this.EditTsTn0(enuEdit.New);
        //}

        //void btDetailEdit_Click(object sender, EventArgs e)
        //{
        //    if (tabDetail.SelectedTab == pageGiaDinh)
        //        this.EditGiaDinh(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageDaoTao)
        //        this.EditDaoTao(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageCongTac)
        //        this.EditCongTac(enuEdit.Edit);        
        //    else if (tabDetail.SelectedTab == pageKhenThuong)
        //        this.EditKhenThuong(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageHopDong)
        //        this.EditHopDong(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageNghiPhep)
        //        this.EditNghiPhep(enuEdit.Edit);
        //    else if (tabDetail.SelectedTab == pageTsTn0)
        //        this.EditTsTn0(enuEdit.Edit);
        //}

        //void btDetailDelete_Click(object sender, EventArgs e)
        //{
        //    if (tabDetail.SelectedTab == pageGiaDinh)
        //        this.DeleteGiaDinh();
        //    else if (tabDetail.SelectedTab == pageDaoTao)
        //        this.DeleteDaoTao();
        //    else if (tabDetail.SelectedTab == pageCongTac)
        //        this.DeleteCongTac();        
        //    else if (tabDetail.SelectedTab == pageKhenThuong)
        //        this.DeleteKhenThuong();
        //    else if (tabDetail.SelectedTab == pageHopDong)
        //        this.DeleteHopDong();
        //    else if (tabDetail.SelectedTab == pageNghiPhep)
        //        this.DeleteNghiPhep();
        //    else if (tabDetail.SelectedTab == pageTsTn0)
        //        this.DeleteTsTn0();
        //}

        //void btNew_Click(object sender, EventArgs e)
        //{
        //    this.EditEmployee(enuEdit.New);
        //}

        //void btEdit_Click(object sender, EventArgs e)
        //{
        //    this.EditEmployee(enuEdit.Edit);
        //}

        //void btDelete_Click(object sender, EventArgs e)
        //{
        //    this.DeleteEmployee();
        //}

		#endregion
	}
}
