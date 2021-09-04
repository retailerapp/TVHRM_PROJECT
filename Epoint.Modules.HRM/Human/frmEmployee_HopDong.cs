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
using System.Collections;
using System.IO;

namespace Epoint.Modules.HRM
{
    public partial class frmEmployee_HopDong : Epoint.Lists.frmView
    {
        #region Khai bao bien
        private tlControl tlDmCbNv = new tlControl();

        DataTable dtEmployee;
        DataTable dtHopDong;
        DataTable dtHopDongPL;

        BindingSource bdsEmployee = new BindingSource();
        BindingSource bdsHopDong = new BindingSource();
        BindingSource bdsHopDongPL = new BindingSource();

        private DataRow drCurrent;

        #endregion

        #region Contructor

        public frmEmployee_HopDong()
        {
            InitializeComponent();

            bdsEmployee.PositionChanged += new EventHandler(bdsEmployee_PositionChanged);
            this.btViewContract.Click += new EventHandler(btViewContract_Click);
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
            //dtEmployee = HRMCommon.GetCustomerTable("MA_KV");
            tlDmCbNv = HRMCommon.GetTreeViewCust(this.isLookup);

            this.splControl1.Visible = false;
            this.pageEmployee.Controls.Add(tlDmCbNv);

            dgvHopDong.strZone = "HOPDONGLD";
            dgvHopDong.BuildGridView();

            dgvHopDongPL.strZone = "HOPDONGLD_PL";
            dgvHopDongPL.BuildGridView();
        }

        private void FillData(string strKey)
        {
            //dtEmployee = SQLExec.ExecuteReturnDt("EXEC Sp_GetDmCbNv");
            dtEmployee = HRMCommon.GetCustomerTable("MA_KV", this.cboFill.Text);
            bdsEmployee.DataSource = dtEmployee;
            tlDmCbNv.DataSource = bdsEmployee;
            //bdsEmployee.Position = 0;

            //HOPDONG
            //dtHopDong = DataTool.SQLGetDataTable("HRHOPDONG", null, strKey, "Ngay_Begin, Ngay_End");
            dtHopDong = SQLExec.ExecuteReturnDt("SELECT * FROM HRHOPDONG");
            bdsHopDong.DataSource = dtHopDong;
            dgvHopDong.DataSource = bdsHopDong;

            //HOPDONGPL
            //dtHopDongPL = DataTool.SQLGetDataTable("HRHOPDONGPL", null, strKey, "Ngay_Begin, Ngay_End");
            dtHopDongPL = SQLExec.ExecuteReturnDt("SELECT * FROM HRHOPDONGPL");
            bdsHopDongPL.DataSource = dtHopDongPL;
            dgvHopDongPL.DataSource = bdsHopDongPL;

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
            if (tabDetail.SelectedTab == pageHopDong || dgvHopDong.Focused)
                this.EditHopDong(enuNew_Edit);
            else if (tabDetail.SelectedTab == pageHopDongPL || dgvHopDongPL.Focused)
                this.EditHopDongPL(enuNew_Edit);
        }

        public override void Delete()
        {
            if (tabDetail.SelectedTab == pageHopDong || dgvHopDong.Focused)
                this.DeleteHopDong();
            else if (tabDetail.SelectedTab == pageHopDongPL || dgvHopDongPL.Focused)
                this.DeleteHopDongPL();
        }
        void EditHopDong(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsHopDong.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsHopDong.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsHopDong.Current).Row, ref drCurrent);
            else
                drCurrent = dtHopDong.NewRow();

            drCurrent["Ma_CbNv"] = (string)drEmployee["Ma_CbNv"];
            frmHopDong_Edit frmEdit = new frmHopDong_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsHopDong.Position >= 0)
                        dtHopDong.ImportRow(drCurrent);
                    else
                        dtHopDong.Rows.Add(drCurrent);

                    bdsHopDong.Position = bdsHopDong.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsHopDong.Current).Row);

                dtHopDong.AcceptChanges();
            }
            else
                dtHopDong.RejectChanges();
        }
        void EditHopDongPL(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;


            if (bdsHopDong.Position < 0)
            {
                EpointMessage.MsgOk("Chọn hợp đồng có phụ lục đi kèm.");
                return;
            }
            if (bdsHopDongPL.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;
            DataRow drHd = ((DataRowView)bdsHopDong.Current).Row;
            //Copy hang hien tai            
            if (bdsHopDongPL.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsHopDongPL.Current).Row, ref drCurrent);
            else
                drCurrent = dtHopDongPL.NewRow();

            drCurrent["Ma_CbNv"] = (string)drEmployee["Ma_CbNv"];
            if (drCurrent["So_Hd"].ToString() == string.Empty)
            {
                drCurrent["So_Hd"] = drHd["So_Hd"];
            }

            frmHopDongPL_Edit frmEdit = new frmHopDongPL_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsHopDongPL.Position >= 0)
                        dtHopDongPL.ImportRow(drCurrent);
                    else
                        dtHopDongPL.Rows.Add(drCurrent);

                    bdsHopDongPL.Position = bdsHopDongPL.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsHopDongPL.Current).Row);

                dtHopDongPL.AcceptChanges();
            }
            else
                dtHopDongPL.RejectChanges();
        }

        void DeleteHopDong()
        {
            if (bdsHopDong.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsHopDong.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("HRHOPDONG", drCurrent))
            {
                bdsHopDong.RemoveAt(bdsHopDong.Position);
                dtHopDong.AcceptChanges();
            }
        }
        void DeleteHopDongPL()
        {
            if (bdsHopDongPL.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsHopDongPL.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("HRHOPDONGPL", drCurrent))
            {
                bdsHopDongPL.RemoveAt(bdsHopDongPL.Position);
                dtHopDongPL.AcceptChanges();
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

            bdsHopDong.Filter = "Ma_CbNv = '" + drCurrent["Ma_CbNv"] + "'";
            bdsHopDongPL.Filter = "Ma_CbNv = '" + drCurrent["Ma_CbNv"] + "'";

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

        void btViewContract_Click(object sender, EventArgs e)
        {
            try
            {
                string HDLD = Parameters.GetParaValue("HDLD").ToString(); // "HDLD20180824"; 
                string HDLD2 = Parameters.GetParaValue("HDLD2").ToString(); // "HDLD20180824";-- Hợp đồng không thời hạn
                string HDLD_PL = Parameters.GetParaValue("HDLDPL").ToString();  //"HDLD20180824_PL";
                string HDLD_HL = Parameters.GetParaValue("HDLDHL").ToString();  //"HDLD20180824_PL";--  -- Hợp đồng huấn luyện

                if (tabDetail.SelectedTab == pageHopDong || dgvHopDong.Focused)// View hop dong
                {
                    if (bdsHopDong.Position < 0)
                        return;

                    DataRow drCurrentHD = ((DataRowView)bdsHopDong.Current).Row;

                    string strSQLProc = "sp_GetHDLDInfo";
                    Hashtable htParameter = new Hashtable();
                    htParameter.Add("MA_CBNV", drCurrentHD["Ma_Cbnv"].ToString());
                    htParameter.Add("SO_HD", drCurrentHD["So_Hd"].ToString());
                    htParameter.Add("SO_PL", string.Empty);
                    DataTable dtResult = SQLExec.ExecuteReturnDt(strSQLProc, htParameter, CommandType.StoredProcedure);



                    string fileName = DataTool.SQLGetNameByCode("SYSRESOURCES", "FILE_ID", "FILE_ID", HDLD);
                    object objFileContent = Resource.LoadResource(HDLD);
                    if (drCurrentHD["Loai_Hd"].ToString() == "5")
                    {
                        fileName = DataTool.SQLGetNameByCode("SYSRESOURCES", "FILE_ID", "FILE_ID", HDLD_HL);
                        objFileContent = Resource.LoadResource(HDLD_HL);
                    }
                    if (drCurrentHD["Loai_Hd"].ToString() == "2")
                    {
                        fileName = DataTool.SQLGetNameByCode("SYSRESOURCES", "FILE_ID", "FILE_ID", HDLD2);
                        objFileContent = Resource.LoadResource(HDLD2);
                    }

                    string strFileTemplate = Application.StartupPath + @"\Template\" + fileName;


                    if (objFileContent != null)
                    {
                        FileStream stream = new FileStream(strFileTemplate, FileMode.Create, FileAccess.ReadWrite);
                        stream.Write((byte[])objFileContent, 0, ((byte[])objFileContent).Length);
                        stream.Close();

                    }
                    else
                        EpointMessage.MsgOk("Tập tin rỗng");



                    HRMCommon.WriteToWordQTTC04(dtResult, strFileTemplate, fileName);
                }
                else if (tabDetail.SelectedTab == pageHopDongPL || dgvHopDongPL.Focused)//View phụ lục hợp đồng
                {
                    if (bdsHopDongPL.Position < 0)
                        return;

                    DataRow drCurrentPL = ((DataRowView)bdsHopDongPL.Current).Row;
                    //if (drCurrentPL["File_Id"].ToString() != string.Empty)
                    //    HDLD_PL = drCurrentPL["File_Id"].ToString();
                    //else
                    //{
                    //    frmSelectHDPL frmSelect = new frmSelectHDPL();
                    //    frmSelect.Load();
                    //    if (frmSelect.isAccept)
                    //        HDLD_PL = frmSelect.FileId;
                    //}

                    frmSelectHDPL frmSelect = new frmSelectHDPL();
                    frmSelect.Load();
                    if (frmSelect.isAccept)
                        HDLD_PL = frmSelect.FileId;
                    string fileName = DataTool.SQLGetNameByCode("SYSRESOURCES", "FILE_ID", "FILE_ID", HDLD_PL);
                    string strFileTemplate = Application.StartupPath + @"\Template\" + fileName;

                    object objFileContent = Resource.LoadResource(HDLD_PL);
                    if (objFileContent != null)
                    {
                        FileStream stream = new FileStream(strFileTemplate, FileMode.Create, FileAccess.ReadWrite);
                        stream.Write((byte[])objFileContent, 0, ((byte[])objFileContent).Length);
                        stream.Close();

                    }
                    else
                        EpointMessage.MsgOk("Tập tin rỗng");


                    string strSQLProc = "sp_GetHDLDInfo";
                    Hashtable htParameter = new Hashtable();
                    htParameter.Add("MA_CBNV", drCurrentPL["Ma_Cbnv"].ToString());
                    htParameter.Add("SO_HD", string.Empty);
                    htParameter.Add("SO_PL", drCurrentPL["So_Pl"].ToString());
                    DataTable dtResult = SQLExec.ExecuteReturnDt(strSQLProc, htParameter, CommandType.StoredProcedure);
                    if (dtResult != null && dtResult.Rows.Count > 0)
                        HRMCommon.WriteToWordQTTC04(dtResult, strFileTemplate, fileName);
                    else
                        EpointMessage.MsgOk("Không xuất được báo cáo!");
                }
            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.Message);
            }

        }
        #endregion
    }
}
