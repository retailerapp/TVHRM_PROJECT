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
    public partial class frmSync_Manual : Epoint.Systems.Customizes.frmView
    {
        string strMa_Ct;
        private BindingSource bdsTranVoucher = new BindingSource();
        private BindingSource bdsTranList = new BindingSource();
        private DataTable dtTranVoucher;
        private DataTable dtTranList;
        private int iBeginRow = -1, iEndRow;
        private bool bCheckKey;
        DataRow drCurrent;

        public frmSync_Manual()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);            

            dgvTransVoucher.KeyUp += new KeyEventHandler(dgvTransVoucher_KeyUp);
            dgvTransVoucher.KeyDown += new KeyEventHandler(dgvTransVoucher_KeyDown);
            dgvTransVoucher.CellClick += new DataGridViewCellEventHandler(dgvTransVoucher_CellClick);
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
        }

        void dgvTransVoucher_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = false;
            }
        }

        new public void Load()
        {            
            this.Build();
            this.FillData();

            this.BindingLanguage();
            this.Show();
        }
        void Build()
        {
            dgvTransVoucher.strZone = "SYNC_VOUCHER";
            dgvTransVoucher.BuildGridView();
            dgvTransVoucher.ResizeGridView();

            dgvTransList.strZone = "SYNC_LIST";
            dgvTransList.BuildGridView();
            dgvTransList.ResizeGridView();
        }

        void FillData()
        {
            //Fill data Sync Voucher
            string strSQLExec_Voucher =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCVOUCHER ORDER BY Stt";

            dtTranVoucher = SQLExec.ExecuteReturnDt(strSQLExec_Voucher);
            bdsTranVoucher.DataSource = dtTranVoucher;

            dgvTransVoucher.DataSource = bdsTranVoucher;
            dgvTransVoucher.ReadOnly = false;
            foreach (DataGridViewColumn dgvc in dgvTransVoucher.Columns)
            {
                if (dgvc.Name == "IS_SEND")
                    dgvc.ReadOnly = false;
                else
                    dgvc.ReadOnly = true;
            }

            //Fill data Sync List
            string strSQLExec_List =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCLIST ORDER BY Stt";

            dtTranList = SQLExec.ExecuteReturnDt(strSQLExec_List);
            bdsTranList.DataSource = dtTranList;

            dgvTransList.DataSource = bdsTranList;
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
                        
        }

        public static void Sync_Send_Data()
        {
            //Sync
            Hashtable htPara = new Hashtable();
            if (Collection.Parameters.ContainsKey("SYNC_SERVER"))
                htPara.Add("SERVER", Collection.Parameters["SYNC_SERVER"]);
            if (Collection.Parameters.ContainsKey("SYNC_DBSOURCE"))
                htPara.Add("DBSOURCE", Collection.Parameters["SYNC_DBSOURCE"]);
            if (Collection.Parameters.ContainsKey("SYNC_DBDEST"))
                htPara.Add("DBDEST", Collection.Parameters["SYNC_DBDEST"]);
            if (Collection.Parameters.ContainsKey("SYNC_USER"))
                htPara.Add("USER", Collection.Parameters["SYNC_USER"]);
            if (Collection.Parameters.ContainsKey("SYNC_PASS"))
                htPara.Add("PASS", Collection.Parameters["SYNC_PASS"]);           
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);
            
            //Begin Sync List
            string strSQLExec_List =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCLIST ORDER BY Stt";

            DataTable dtTranList = SQLExec.ExecuteReturnDt(strSQLExec_List);
            foreach (DataRow dr in dtTranList.Rows)
            {
                if ((bool)dr["IS_SEND"])
                {
                    htPara["TABLE_NAME"] = dr["Table_Name"].ToString();
                    htPara["NAM"] = Element.sysWorkingYear;
                    //EpointProcessBox.AddMessage("Sync List  ");
                    SQLExec.Execute("sp_Sync_Send_List", htPara, CommandType.StoredProcedure);
                }
            }

            //Begin Sync Voucher
            string strSQLExec_Voucher =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCVOUCHER ORDER BY Stt";

            DataTable dtTranVoucher = SQLExec.ExecuteReturnDt(strSQLExec_Voucher);
            foreach (DataRow dr in dtTranVoucher.Rows)
            {
                if ((bool)dr["IS_SEND"])
                {
                    htPara["MA_CT"] = dr["Ma_Ct"].ToString();
                    htPara["TABLE_NAME"] = dr["Table_Name"].ToString();
                    htPara["NAM"] = Element.sysWorkingYear;
                    //EpointProcessBox.AddMessage("Sync Voucher  ");
                    SQLExec.Execute("sp_Sync_Send_Voucher", htPara, CommandType.StoredProcedure);
                }
            }
            //EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
        }

        public static void Sync_Get_Data()
        {
            //Sync            
            Hashtable htPara = new Hashtable();
            if (Collection.Parameters.ContainsKey("SYNC_SERVER"))
                htPara.Add("SERVER", Collection.Parameters["SYNC_SERVER"]);
            if (Collection.Parameters.ContainsKey("SYNC_DBSOURCE"))
                htPara.Add("DBSOURCE", Collection.Parameters["SYNC_DBSOURCE"]);
            if (Collection.Parameters.ContainsKey("SYNC_DBDEST"))
                htPara.Add("DBDEST", Collection.Parameters["SYNC_DBDEST"]);
            if (Collection.Parameters.ContainsKey("SYNC_USER"))
                htPara.Add("USER", Collection.Parameters["SYNC_USER"]);
            if (Collection.Parameters.ContainsKey("SYNC_PASS"))
                htPara.Add("PASS", Collection.Parameters["SYNC_PASS"]);            
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            //Begin Sync List
            string strSQLExec_List =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCLIST ORDER BY Stt";

            DataTable dtTranList = SQLExec.ExecuteReturnDt(strSQLExec_List);
            foreach (DataRow dr in dtTranList.Rows)
            {
                if ((bool)dr["IS_SEND"])
                {
                    htPara["TABLE_NAME"] = dr["Table_Name"].ToString();
                    htPara["NAM"] = Element.sysWorkingYear;
                    //EpointProcessBox.AddMessage("Sync List  ");
                    SQLExec.Execute("sp_Sync_Get_List", htPara, CommandType.StoredProcedure);
                }
            }

            //Begin Sync Voucher
            string strSQLExec_Voucher =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSSYNCVOUCHER ORDER BY Stt";

            DataTable dtTranVoucher = SQLExec.ExecuteReturnDt(strSQLExec_Voucher);
            foreach (DataRow dr in dtTranVoucher.Rows)
            {
                if ((bool)dr["IS_SEND"])
                {
                    htPara["MA_CT"] = dr["Ma_Ct"].ToString();
                    htPara["TABLE_NAME"] = dr["Table_Name"].ToString();
                    htPara["NAM"] = Element.sysWorkingYear;
                    //EpointProcessBox.AddMessage("Sync Voucher  ");
                    SQLExec.Execute("sp_Sync_Get_Voucher", htPara, CommandType.StoredProcedure);
                }
            }
            //EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
        }

        void btOk_Click(object sender, EventArgs e)
        {
            string strMsg = string.Empty;

            //Kiểm tra xem quá trình đồng bộ có đang diễn ra.
            if ((string)SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_PROCESSING'") == "1")
            {
                strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang diễn ra trên máy khác. Vui lòng dừng thao tác đồng bộ và chờ trong ít phút !" 
                                : "The synchronization process is taking place on another machine. Please stop synchronous operation and wait a few minutes !";
                Common.MsgCancel(strMsg);
            }

            //Đồng bộ dữ liệu 2 chiều
            if ((string)SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'") == "1")
            {
                if((string)SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_PROCESSING'") == "0")
                {
                    //Quá trình đồng bộ đang diễn ra, host khác không được đồng bộ
                    SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value ='1' WHERE Parameter_ID = 'SYNC_PROCESSING'");

                    Sync_Send_Data();
                    Sync_Get_Data();

                    //Quá trình đồng bộ hoàn tất, các host có thể thực hiện đồng bộ
                    SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value ='0' WHERE Parameter_ID = 'SYNC_PROCESSING'");

                    strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Đồng bộ dữ liệu thành công !" : "Sync Finish !";
                    Common.MsgCancel(strMsg);                    
                }
            }            
            //this.Close();            
            //Common.CloseCurrentForm();
            
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Common.CloseCurrentForm();
        }
        
        public override void Edit(enuEdit enuNew_Edit)
        {
            //if (tabControl1.SelectedTab != tabPageTranList)
            //    return;

            //if (bdsTranList.Position < 0 && enuNew_Edit == enuEdit.Edit)
            //    return;
            
            //Edit Sync List
            if (tabControl1.SelectedTab == tabPageTranList)
            {
                //Copy hang hien tai            
                if (bdsTranList.Position >= 0)
                    Common.CopyDataRow(((DataRowView)bdsTranList.Current).Row, ref drCurrent);
                else
                    drCurrent = dtTranList.NewRow();

                frmSyncList_Edit frmEdit = new frmSyncList_Edit();
                frmEdit.Load(enuNew_Edit, drCurrent);

                //Accept
                if (frmEdit.isAccept)
                {
                    if (enuNew_Edit == enuEdit.New)
                    {
                        if (bdsTranList.Position >= 0)
                            dtTranList.ImportRow(drCurrent);
                        else
                            dtTranList.Rows.Add(drCurrent);

                    }
                    else
                        Common.CopyDataRow(drCurrent, ((DataRowView)bdsTranList.Current).Row);

                    dtTranList.AcceptChanges();
                }
                else
                    dtTranList.RejectChanges();
            }

            //Edit Sync voucher
            if (tabControl1.SelectedTab == tabPageTranVoucher)
            {
                //Copy hang hien tai            
                if (bdsTranVoucher.Position >= 0)
                    Common.CopyDataRow(((DataRowView)bdsTranVoucher.Current).Row, ref drCurrent);
                else
                    drCurrent = dtTranVoucher.NewRow();

                frmSyncVoucher_Edit frmEdit = new frmSyncVoucher_Edit();
                frmEdit.Load(enuNew_Edit, drCurrent);

                //Accept
                if (frmEdit.isAccept)
                {
                    if (enuNew_Edit == enuEdit.New)
                    {
                        if (bdsTranVoucher.Position >= 0)
                            dtTranVoucher.ImportRow(drCurrent);
                        else
                            dtTranVoucher.Rows.Add(drCurrent);

                    }
                    else
                        Common.CopyDataRow(drCurrent, ((DataRowView)bdsTranVoucher.Current).Row);

                    dtTranVoucher.AcceptChanges();
                }
                else
                    dtTranVoucher.RejectChanges();
            }

        }

        public override void Delete()
        {
            //Delete Sync List
            if (tabControl1.SelectedTab == tabPageTranList)
            {
                if (bdsTranList.Position < 0)
                    return;

                DataRow drCurrent = ((DataRowView)bdsTranList.Current).Row;

                if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("SYSSYNCLIST", drCurrent))
                {
                    bdsTranList.RemoveAt(bdsTranList.Position);
                    dtTranList.AcceptChanges();
                }
            }

            //Delete Sync Voucher
            if (tabControl1.SelectedTab == tabPageTranVoucher)
            {
                if (bdsTranVoucher.Position < 0)
                    return;

                DataRow drCurrent = ((DataRowView)bdsTranVoucher.Current).Row;

                if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("SYSSYNCVOUCHER", drCurrent))
                {
                    bdsTranVoucher.RemoveAt(bdsTranVoucher.Position);
                    dtTranVoucher.AcceptChanges();
                }
            }
        }
    }
}
