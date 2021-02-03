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
    public partial class frmViewLicenseEx : Epoint.Systems.Customizes.frmView
    {

        #region Khai bao bien

        private DataTable dtListCustomerLics;
        private DataRow drCurrent;
        private BindingSource bdsListCustomerLics = new BindingSource();
        //private dgvControl dgvResource = new dgvControl();

        #endregion

        #region Contructor

        public frmViewLicenseEx()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            this.dgvListCustomerLics.Resize += new EventHandler(dgvChangeID_Resize);
            this.dgvListCustomerLics.CellClick += new DataGridViewCellEventHandler(dgvListCustomerLics_CellClick);     
            this.chkConfirm.CheckedChanged += new EventHandler(chkConfirm_CheckedChanged);

        }

        void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkConfirm.Checked)
                this.bdsListCustomerLics.Filter = "Confirmed = 1";
            else
                this.bdsListCustomerLics.Filter = "Confirmed = 0";
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

                SQLExec.Execute("UPDATE SYSLICS_Expression SET Active = '" + Convert.ToBoolean(drCurrent["Active"]) + "' WHERE Ident00 = " + drCurrent["Ident00"].ToString());
            }
           
            if (Common.Inlist(strColumnName, "CONFIRMED"))
            {
                drCurrent = ((DataRowView)bdsListCustomerLics.Current).Row;
                drCurrent["Confirmed"] = !Convert.ToBoolean(drCurrent["Confirmed"]);
                drCurrent.AcceptChanges();

                SQLExec.Execute("UPDATE SYSLICS_Expression SET Confirmed = '" + Convert.ToBoolean(drCurrent["Confirmed"]) + "' WHERE Ident00 = " + drCurrent["Ident00"].ToString()) ;
            }
        }

        void cboCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            

        }

        public override void Load()
        {
            
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

            dgvListCustomerLics.strZone = "LISTCUSTOMERLICSEX";
            dgvListCustomerLics.BuildGridView(false);

            //this.Controls.Add(dgvResource);
        }

        private void FillData()
        {
            this.dtListCustomerLics = DataTool.SQLGetDataTable("SYSLICS_Expression", "", "", "DateAcc");
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
            
        }

        public override void Delete()
        {
            
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
