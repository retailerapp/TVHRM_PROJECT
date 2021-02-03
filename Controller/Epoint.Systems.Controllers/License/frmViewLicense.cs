using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
    public partial class frmViewLicense : Epoint.Systems.Customizes.frmView
    {

        #region Khai bao bien

        private DataTable dtListCustomerLics;
        private DataRow drCurrent;
        private BindingSource bdsListCustomerLics = new BindingSource();
        //private dgvControl dgvResource = new dgvControl();

        #endregion

        #region Contructor

        public frmViewLicense()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            this.dgvListCustomerLics.Resize += new EventHandler(dgvChangeID_Resize);
            this.dgvListCustomerLics.CellClick += new DataGridViewCellEventHandler(dgvListCustomerLics_CellClick);
            this.dgvListCustomerLics.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvListCustomerLics_CellMouseDoubleClick);

            this.cboCustomer.SelectedValueChanged += new EventHandler(cboCustomer_SelectedValueChanged);
            this.chkConfirm.CheckedChanged += new EventHandler(chkConfirm_CheckedChanged);

        }

        void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkConfirm.Checked)
                this.bdsListCustomerLics.Filter = "Confirmed = 1";
            else
                this.bdsListCustomerLics.Filter = "Confirmed = 0";
        }

        void dgvListCustomerLics_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Edit(enuEdit.Edit);
        }

        void dgvListCustomerLics_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            //string strColumnName = dgvPermission.Columns[e.ColumnIndex].Name;
            ///////////////////////////////
            DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.Inlist(strColumnName, "ACTIVE"))
            {
                drCurrent = ((DataRowView)bdsListCustomerLics.Current).Row;
                drCurrent["Active"] = !Convert.ToBoolean(drCurrent["Active"]);
                drCurrent.AcceptChanges();

                SQLExec.Execute("UPDATE SYSLICS SET Active = '" + Convert.ToBoolean(drCurrent["Active"]) + "' WHERE CustID = '" + drCurrent["CustID"].ToString() + "'  AND Ma_Dvcs = '" + drCurrent["Ma_Dvcs"].ToString() + "' AND PC_NAME = '" + drCurrent["PC_NAME"].ToString() + "' ");
            }
            if (Common.Inlist(strColumnName, "ISUPDATE"))
            {
                drCurrent = ((DataRowView)bdsListCustomerLics.Current).Row;
                drCurrent["ISUPDATE"] = !Convert.ToBoolean(drCurrent["ISUPDATE"]);
                drCurrent.AcceptChanges();

                SQLExec.Execute("UPDATE SYSLICS SET ISUPDATE = '" + Convert.ToBoolean(drCurrent["ISUPDATE"]) + "' WHERE CustID = '" + drCurrent["CustID"].ToString() + "'  AND Ma_Dvcs = '" + drCurrent["Ma_Dvcs"].ToString() + "' AND PC_NAME = '" + drCurrent["PC_NAME"].ToString() + "' ");
            }
            if (Common.Inlist(strColumnName, "CONFIRMED"))
            {
                drCurrent = ((DataRowView)bdsListCustomerLics.Current).Row;
                drCurrent["Confirmed"] = !Convert.ToBoolean(drCurrent["Confirmed"]);
                drCurrent.AcceptChanges();

                SQLExec.Execute("UPDATE SYSLICS SET Confirmed = '" + Convert.ToBoolean(drCurrent["Confirmed"]) + "' WHERE CustID = '" + drCurrent["CustID"].ToString() + "'  AND Ma_Dvcs = '" + drCurrent["Ma_Dvcs"].ToString() + "' AND PC_NAME = '" + drCurrent["PC_NAME"].ToString() + "' ");
            }
        }

        void cboCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboCustomer.SelectedValue.ToString() == "ALL")
            {
                bdsListCustomerLics.RemoveFilter();
            }
            else
            {
                bdsListCustomerLics.Filter = "CustID = '" + cboCustomer.SelectedValue.ToString() + "'";
            }

        }

        public override void Load()
        {
            this.cboCustomer.DataSource = SQLExec.ExecuteReturnDt(@"SELECT Distinct CustID = 'ALL',Ten_Dvcs = N'Tất cả',Descr = N'Tất cả' UNION ALL
                                                                    SELECT Distinct CustID,Ten_Dvcs,Descr = CustID + '--' + Ten_Dvcs FROM SYSLICS
                                                                                ORDER BY CustID");
            this.cboCustomer.DisplayMember = "Descr";
            this.cboCustomer.ValueMember = "CustID";


            Build();
            FillData();
            BindingLanguage();

            this.Show();
        }

        #endregion

        #region Build, FillData

        private void Build()
        {
            dgvListCustomerLics.Dock = DockStyle.Fill;

            dgvListCustomerLics.strZone = "LISTCUSTOMERLICS";
            dgvListCustomerLics.BuildGridView(false);

            //this.Controls.Add(dgvResource);
        }

        private void FillData()
        {
            this.dtListCustomerLics = DataTool.SQLGetDataTable("SYSLICS", "", "", "CustID");
            this.bdsListCustomerLics.DataSource = this.dtListCustomerLics;
            this.dgvListCustomerLics.DataSource = this.bdsListCustomerLics;
            base.ExportControl = this.dgvListCustomerLics;
            base.bdsSearch = this.bdsListCustomerLics;

            this.bdsListCustomerLics.Filter = "Confirmed = 0";

        }

        #endregion

        #region Update

        public override void Edit(enuEdit enuNew_Edit)
        {
            if (enuNew_Edit == enuEdit.New)
                return;

            if (bdsListCustomerLics.Position < 0)
                return;

            //Copy hang hien tai            
            if (bdsListCustomerLics.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsListCustomerLics.Current).Row, ref drCurrent);
            else
                drCurrent = dtListCustomerLics.NewRow();

            frmViewLicense_Edit frm = new frmViewLicense_Edit();
            frm.Load(enuNew_Edit, ref drCurrent);

            //Accept
            if (frm.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsListCustomerLics.Position >= 0)
                        dtListCustomerLics.ImportRow(drCurrent);
                    else
                        dtListCustomerLics.Rows.Add(drCurrent);

                    bdsListCustomerLics.Position = bdsListCustomerLics.Find("MA_DVCS", drCurrent["MA_DVCS"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsListCustomerLics.Current).Row);

                dtListCustomerLics.AcceptChanges();
            }
            else
                dtListCustomerLics.RejectChanges();
        }

        public override void Delete()
        {
            //if (bdsResource.Position < 0)
            //    return;

            //DataRow drCurrent = ((DataRowView)bdsResource.Current).Row;

            //if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
            //    return;

            //if (DataTool.SQLDelete("SYSGOPMA", drCurrent))
            //{
            //    bdsResource.RemoveAt(bdsResource.Position);
            //    dtResource.AcceptChanges();
            //}
        }

        #endregion

        #region Su kien

        void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    Delete();
                    break;
            }
        }

        void dgvChangeID_Resize(object sender, EventArgs e)
        {
            this.dgvListCustomerLics.ResizeGridView();
        }

        #endregion

    }
}
