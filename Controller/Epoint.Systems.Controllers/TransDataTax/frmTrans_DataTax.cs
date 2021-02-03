using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using System.Collections;
using Epoint.Systems.Controls;
using Epoint.Systems;

namespace Epoint.Controllers
{
    public partial class frmTrans_DataTax : Epoint.Systems.Customizes.frmView
    {
        string strMa_Ct;
        private BindingSource bdsTranVoucher = new BindingSource();
        private BindingSource bdsTranferList = new BindingSource();
        private DataTable dtTranVoucher;
        private DataTable dtTranList;
        private int iBeginRow = -1, iEndRow;
        private bool bCheckKey;
        DataRow drCurrent;

        public frmTrans_DataTax()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);
            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            btMa_Ct.Click += new EventHandler(btMa_Ct_Click);
            btShowData.Click += new EventHandler(btShowData_Click);
            
            dgvTransVoucher.KeyUp += new KeyEventHandler(dgvTransVoucher_KeyUp);
            dgvTransVoucher.KeyDown += new KeyEventHandler(dgvTransVoucher_KeyDown);
            dgvTransVoucher.CellClick += new DataGridViewCellEventHandler(dgvTransVoucher_CellClick);

            dgvTransList.KeyUp += new KeyEventHandler(dgvTransList_KeyUp);
            dgvTransList.KeyDown += new KeyEventHandler(dgvTransList_KeyDown);
            dgvTransList.CellClick += new DataGridViewCellEventHandler(dgvTransList_CellClick);            
        }

        void dgvTransVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "CHON")
            {
                //dgvTransVoucher.Rows[i].Cells[strColumnName].Value = !(bool)dgvTransVoucher.Rows[i].Cells[strColumnName].Value;
                dgvCell.Value = !(bool)dgvCell.Value;
            }

            if (!bCheckKey)
            {
                iBeginRow = dgvTransVoucher.CurrentRow.Index;
            }
            else
            {
                if (iBeginRow == -1)
                {
                    iBeginRow = dgvTransVoucher.CurrentRow.Index;
                }
                else
                {
                    iEndRow = dgvTransVoucher.CurrentRow.Index;
                }
                CheckVoucher(dgvTransVoucher, "Chon", iBeginRow, iEndRow);
                iBeginRow = iEndRow;
            }

            //////////////////////////////////
            if (bCheckKey)
                return;
        }

        void dgvTransList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "IS_SEND")
            {                
                dgvCell.Value = !(bool)dgvCell.Value;
            }

            if (!bCheckKey)
            {
                iBeginRow = dgvTransList.CurrentRow.Index;
            }
            else
            {
                if (iBeginRow == -1)
                {
                    iBeginRow = dgvTransList.CurrentRow.Index;
                }
                else
                {
                    iEndRow = dgvTransList.CurrentRow.Index;
                }
                CheckVoucher(dgvTransList, "Is_Send", iBeginRow, iEndRow);
                iBeginRow = iEndRow;
            }

            //////////////////////////////////
            if (bCheckKey)
                return;
        }

        private void CheckVoucher(dgvControl dgvPermission, string strColumnName, int beg, int end)
        {
            if (beg > end)
            {
                int temp = beg;
                beg = end;
                end = temp;
            }
            else
                beg = beg + 1;

            //DataTable dt = dgvPermission.DataSource as DataTable;
            for (int i = beg; i <= end; i++)
            {
                dgvPermission.Rows[i].Cells[strColumnName].Value = !(bool)dgvPermission.Rows[i].Cells[strColumnName].Value;
            }
        }

        void dgvTransVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = true;
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                for (int i = 0; i < dgvTransVoucher.Rows.Count; i++)
                {
                    dgvTransVoucher.Rows[i].Cells["CHON"].Value = true;
                }
            }

            if (e.Control && e.KeyCode == Keys.U)
            {
                for (int i = 0; i < dgvTransVoucher.Rows.Count; i++)
                {
                    dgvTransVoucher.Rows[i].Cells["CHON"].Value = false;
                }
            }
        }

        void dgvTransVoucher_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = false;
            }
        }

        void dgvTransList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = true;
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                for (int i = 0; i < dgvTransList.Rows.Count; i++)
                {
                    dgvTransList.Rows[i].Cells["IS_SEND"].Value = true;
                }
            }

            if (e.Control && e.KeyCode == Keys.U)
            {
                for (int i = 0; i < dgvTransList.Rows.Count; i++)
                {
                    dgvTransList.Rows[i].Cells["IS_SEND"].Value = false;
                }
            }
        }

        void dgvTransList_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = false;
            }
        }

        new public void Load()
        {
            //txtMa_Ct_List.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            this.txtNgay_Ct1.Text = Element.sysNgay_Ct1.ToString();
            this.txtNgay_Ct2.Text = Element.sysNgay_Ct2.ToString();

            this.txtNgay_Ct01.Text = Element.sysNgay_Ct1.ToString();
            this.txtNgay_Ct02.Text = Element.sysNgay_Ct2.ToString();

            this.Build();
            this.FillData();

            this.BindingLanguage();
            this.Show();
        }
        void Build()
        {
            dgvTransVoucher.strZone = "TRANFERTAX_VOUCHER";
            dgvTransVoucher.BuildGridView();
            dgvTransVoucher.ResizeGridView();

            dgvTransList.strZone = "TRANFERTAX_LIST";
            dgvTransList.BuildGridView();
            dgvTransList.ResizeGridView();
        }

        void FillData()
        {
            string strSQLExec =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSTRANFERTAXLIST ORDER BY Stt";

            dtTranList = SQLExec.ExecuteReturnDt(strSQLExec);
            bdsTranferList.DataSource = dtTranList;

            dgvTransList.DataSource = bdsTranferList;
            dgvTransList.ReadOnly = false;
            foreach (DataGridViewColumn dgvc in dgvTransList.Columns)
            {
                if (dgvc.Name == "IS_SEND")
                    dgvc.ReadOnly = false;
                else
                    dgvc.ReadOnly = true;
            }
        }
        public override void EpointRelease()
        {

            string strDBSource = Element.sysDatabaseName.ToString();
            string strDBDest = Parameters.GetParaValue("DATABASE_DEST").ToString();

            DateTime dteNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
            DateTime dteNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);
            string strMa_Ct_List = txtMa_Ct.Text;

            if (!Common.CheckDataLocked(dteNgay_Ct1) || !Common.CheckDataLocked(dteNgay_Ct2))
            {

                EpointProcessBox.AddMessage("Dữ liệu đã khóa, liên hệ với nhà quản trị !");
                return;
            }
            
            try
            {
                //Common.ShowStatus(Languages.GetLanguage("In_Process"));

                Hashtable ht = new Hashtable();
                ht["DBSOURCE"] = strDBSource;
                ht["DBDEST"] = strDBDest;
                ht["MA_DVCS"] = Element.sysMa_DvCs.ToString();
                if (tabControl1.SelectedTab == tabPageTranVoucher)
                {
                    EpointProcessBox.AddMessage("Đang chuyển số liệu chứng từ ");
                    if (dtTranVoucher == null)
                        return;
                    
                    foreach (DataRow dr in dtTranVoucher.Rows)
                    {
                        if ((bool)dr["CHON"])
                        {
                            ht["STT"] = dr["Stt"].ToString();
                            ht["MA_CT"] = dr["Ma_Ct"].ToString();

                            SQLExec.Execute("sp_Tranfer_Voucher", ht, CommandType.StoredProcedure);
                        }
                    }

                }
                else if (tabControl1.SelectedTab == tabPageTranList)
                {
                    EpointProcessBox.AddMessage("Đang chuyển danh mục ");
                    foreach (DataRow dr in dtTranList.Rows)
                    {
                        if ((bool)dr["IS_SEND"])
                        {
                            EpointProcessBox.AddMessage("Đang chuyển dữ liệu " + dr["Description"].ToString());
                            ht["TABLE_NAME"] = dr["Table_Name"].ToString();
                            SQLExec.Execute("sp_Tranfer_DanhMuc", ht, CommandType.StoredProcedure);
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabPageKhac)
                {

                    DateTime dteNgay_Ct01 = Library.StrToDate(this.txtNgay_Ct01.Text);
                    DateTime dteNgay_Ct02 = Library.StrToDate(this.txtNgay_Ct02.Text);

                    ht["NGAY_CT1"] = dteNgay_Ct01;
                    ht["NGAY_CT2"] = dteNgay_Ct02;
                    //ht["NAM"] = Element.sysWorkingYear;

                    if (chkDuDau_KeToan.Checked)
                    {
                        EpointProcessBox.AddMessage("Đang chuyển số dư đầu tài khoản ");
                        SQLExec.Execute("sp_Tranfer_DuDau_KeToan", ht, CommandType.StoredProcedure);
                    }
                    if (chkDuDau_TonKho.Checked)
                    {
                        EpointProcessBox.AddMessage("Đang chuyển số dư đầu tồn kho ");
                        SQLExec.Execute("sp_Tranfer_DuDau_TonKho", ht, CommandType.StoredProcedure);
                    }
                    if (chkTaiSan.Checked)
                    {
                        EpointProcessBox.AddMessage("Đang chuyển chứng từ tài sản ");
                        SQLExec.Execute("sp_Tranfer_TaiSan", ht, CommandType.StoredProcedure);
                    }
                }

                Element.sysNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
                Element.sysNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);
                EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));

            }
            catch (Exception)
            {
                EpointProcessBox.AddMessage("Không tìm thấy Database cần chuyển đến !");
            }
        }
        void btOk_Click(object sender, EventArgs e)
        {

            EpointProcessBox.Show(this);
            //this.Close();            
            //Common.CloseCurrentForm();
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Common.CloseCurrentForm();
        }
        void btShowData_Click(object sender, EventArgs e)
        {
            if (txtMa_Ct.Text == "")
            {
                Common.MsgOk(Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã chứng từ không được bỏ trống !" : "Voucher ID is not null !");                
                return;
            }

            DateTime dteNgay_Ct1 = Library.StrToDate(this.txtNgay_Ct1.Text);
            DateTime dteNgay_Ct2 = Library.StrToDate(this.txtNgay_Ct2.Text);
            string strMa_Ct_List = txtMa_Ct.Text;

            Hashtable ht = new Hashtable();
            ht["NGAY_CT1"] = dteNgay_Ct1;
            ht["NGAY_CT2"] = dteNgay_Ct2;
            ht["MA_CT_LIST"] = strMa_Ct_List;
            ht["MA_DVCS"] = Element.sysMa_DvCs.ToString();

            dtTranVoucher = SQLExec.ExecuteReturnDt("sp_Tranfer_ShowVoucher", ht, CommandType.StoredProcedure);
            bdsTranVoucher.DataSource = dtTranVoucher;
            dgvTransVoucher.DataSource = bdsTranVoucher;
        }

        void chkAll_Click(object sender, EventArgs e)
        {

        }

        void txtMa_Ct_Validating(object sender, CancelEventArgs e)
        {

        }
        void btMa_Ct_Click(object sender, EventArgs e)
        {
            string strValue = txtMa_Ct.Text.Trim();

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Ct", "", true, "", "");
            if (drLookup == null)
                txtMa_Ct.Text = string.Empty;
            else
            {
                txtMa_Ct.Text = drLookup["MuiltiSelectValue"].ToString();
            }
        }

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (tabControl1.SelectedTab != tabPageTranList)
                return;

            if (bdsTranferList.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsTranferList.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTranferList.Current).Row, ref drCurrent);
            else
                drCurrent = dtTranList.NewRow();

            frmTranList_Edit frmEdit = new frmTranList_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTranferList.Position >= 0)
                        dtTranList.ImportRow(drCurrent);
                    else
                        dtTranList.Rows.Add(drCurrent);

                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTranferList.Current).Row);

                dtTranList.AcceptChanges();
            }
            else
                dtTranList.RejectChanges();
        }

        public override void Delete()
        {
            if (tabControl1.SelectedTab == tabPageTranList)
            {
                if (bdsTranferList.Position < 0)
                    return;

                DataRow drCurrent = ((DataRowView)bdsTranferList.Current).Row;

                if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("SYSTRANFERTAXLIST", drCurrent))
                {
                    bdsTranferList.RemoveAt(bdsTranferList.Position);
                    dtTranList.AcceptChanges();
                }
            }

        }

    }
}
