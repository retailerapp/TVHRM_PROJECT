using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;

namespace Epoint.Systems.Customizes
{
    public partial class frmQuickLookup : Epoint.Systems.Customizes.frmView
    {
        private DataTable dtQuickLookup;
        private DataRow drCurrent;
        private BindingSource bdsQuickLookup = new BindingSource();
        private dgvControl dgvQuickLookup = new dgvControl();

        public string strTableName = string.Empty;
        public string strZone = string.Empty;
        public string strOrder = string.Empty;
        public bool bMuiltiLookup = false;

        bool bChecked = false, bCheckKey;
        int BeginRow = -1, EndRow;

        public frmQuickLookup(string strTableName, string strZone)
        {
            this.strTableName = strTableName;
            this.strZone = strZone;
            this.ExportControl = dgvQuickLookup;

            this.KeyPreview = true;
            this.dgvQuickLookup.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvQuickLookup_CellMouseDoubleClick);
            this.dgvQuickLookup.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQuickLookup_CellMouseClick);

            InitializeComponent();


        }
        public frmQuickLookup(string strTableName, string strZone,string strOrder)
        {
            this.strTableName = strTableName;
            this.strZone = strZone;
            this.strOrder = strOrder;
            this.ExportControl = dgvQuickLookup;

            this.KeyPreview = true;
            this.dgvQuickLookup.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvQuickLookup_CellMouseDoubleClick);
            this.dgvQuickLookup.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQuickLookup_CellMouseClick);

            InitializeComponent();


        }
        public frmQuickLookup(string strTableName, string strZone, bool bMuiltiLookup)
        {
            this.strTableName = strTableName;
            this.strZone = strZone;
            this.bMuiltiLookup = bMuiltiLookup;

            this.KeyPreview = true;
            this.ExportControl = dgvQuickLookup;
           
            this.dgvQuickLookup.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvQuickLookup_CellMouseDoubleClick);
            this.dgvQuickLookup.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQuickLookup_CellMouseClick);

            // check chọn một khoảng khi nhấn SHIFT
            this.dgvQuickLookup.KeyDown += new KeyEventHandler(dgvQuickLookup_KeyDown);
            this.dgvQuickLookup.KeyUp += new KeyEventHandler(dgvQuickLookup_KeyUp);
            InitializeComponent();


        }

        public frmQuickLookup()
        {
            this.KeyPreview = true;
            this.dgvQuickLookup.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvQuickLookup_CellMouseDoubleClick);
            this.dgvQuickLookup.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQuickLookup_CellMouseClick);

            // check chọn một khoảng khi nhấn SHIFT
            this.dgvQuickLookup.KeyDown += new KeyEventHandler(dgvQuickLookup_KeyDown);
            this.dgvQuickLookup.KeyUp += new KeyEventHandler(dgvQuickLookup_KeyUp);
            InitializeComponent();
        }

        public override void Load()
        {

            this.Tag = strZone;

            this.Build();
            this.FillData();
            this.BindingLanguage();

            this.ShowDialog();
        }

        public override void LoadLookup()
        {
            DataRow drLookup = DataTool.SQLGetDataRowByID("SYSLookup", "ColumnID", this.strLookupColumn);

            if (drLookup != null)
            {
                this.strTableName = (string)drLookup["Table_Lookup"];
                this.strZone = (string)drLookup["Table_Alias"];

                this.Load();
            }
        }

        #region Build, FillData

        private void Build()
        {
            dgvQuickLookup.Dock = DockStyle.Fill;
            dgvQuickLookup.ReadOnly = true;
            dgvQuickLookup.strZone = this.strZone;

            dgvQuickLookup.BuildGridView(this.isLookup);

            this.Controls.Add(dgvQuickLookup);

            //dgvQuickLookup.ResizeGridView();

            if (bMuiltiLookup)
            {
                DataGridViewCheckBoxColumn dgvchkBoxColumn = new DataGridViewCheckBoxColumn();
                dgvchkBoxColumn.DataPropertyName = "SELECT";
                dgvchkBoxColumn.Name = "SELECT";
                dgvchkBoxColumn.Width = 40;

                dgvQuickLookup.Columns.Insert(0, dgvchkBoxColumn);
            }
        }

        private void FillData()
        {
            dtQuickLookup = DataTool.SQLGetDataTable(this.strTableName, "*", this.strLookupKeyFilter, this.strOrder);
            string sFilter = string.Empty;
            //Thêm cột chọn nhiều mã
            if (!dtQuickLookup.Columns.Contains("Select"))
            {
                DataColumn dcSelect = new DataColumn("Select", typeof(bool));
                dcSelect.DefaultValue = false;
                dtQuickLookup.Columns.Add(dcSelect);
            }
            //bool bisAc = false;

            if(this.strLookupValue != string.Empty)
            {
                this.strLookupValue = this.strLookupValue.Replace(" ", "");
                string[] ArrLookup_Value = this.strLookupValue.Split(',');
                sFilter = ArrLookup_Value[0];

                foreach (string sLookup_Value in ArrLookup_Value)
                {
 
                    foreach (DataRow dr in dtQuickLookup.Rows)
                    {
                        if (dr[this.strLookupColumn].ToString() == sLookup_Value)
                        {
                            dr["Select"] = true;
                            dr.AcceptChanges();
                            break;
                        }
                    }
                }

            
            }

            dtQuickLookup.AcceptChanges();
            bdsQuickLookup.DataSource = dtQuickLookup;
            dgvQuickLookup.DataSource = bdsQuickLookup;
            //bdsQuickLookup.Position = bdsQuickLookup.Find(this.strLookupColumn, sFilter);
            bdsQuickLookup.Position = bdsQuickLookup.Find("Select", true);
            bdsSearch = bdsQuickLookup;

        }

        #endregion

        #region EnterProcess
        bool EnterValid()
        {
            if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
                return true;

            if (bdsQuickLookup == null || bdsQuickLookup.Position < 0)
                return false;

            drCurrent = ((DataRowView)bdsQuickLookup.Current).Row;

            DataTable dtTemp = dtQuickLookup.Clone();
            dtTemp.ImportRow(drCurrent);

            if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
                return true;
            else
                return false;

        }

        public override void EnterProcess()
        {
            if (bdsQuickLookup.Position < 0)
                return;

            if (EnterValid())
            {
                drLookup = ((DataRowView)bdsQuickLookup.Current).Row;

                if (bMuiltiLookup && dtQuickLookup.Columns.Contains("Select"))
                {
                    dtQuickLookup.AcceptChanges();
                    string strColumnSelect = "";
                    DataRow[] drArr = dtQuickLookup.Select("Select = true");
                    foreach (DataRow dr in drArr)
                    {
                        strColumnSelect = strColumnSelect + (strColumnSelect == "" ? "" : ",") + (string)dr[strLookupColumn];
                    }

                    drLookup.Table.Columns.Add(new DataColumn("MuiltiSelectValue", typeof(string)));
                    drLookup["MuiltiSelectValue"] = strColumnSelect;
                }

                this.Close();
            }
        }
        #endregion

        void dgvQuickLookup_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.EnterProcess();
        }

        void dgvQuickLookup_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (dgvQuickLookup.Columns[e.ColumnIndex].DataPropertyName.ToUpper() == "SELECT")
            {
                if (!bCheckKey)
                {
                    BeginRow = e.RowIndex;

                    dgvQuickLookup.Rows[e.RowIndex].Cells["Select"].Value = !(bool)dgvQuickLookup.Rows[e.RowIndex].Cells["Select"].Value;
                }
                else
                {
                    if (BeginRow == -1)
                    {
                        BeginRow = e.RowIndex;
                    }
                    else
                    {
                        EndRow = e.RowIndex;
                    }

                    Check(BeginRow, EndRow);
                    BeginRow = EndRow;
                }
            }
        }

        void dgvQuickLookup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = false;
            }
        }

        private void Check(int beg, int end)
        {
            if (beg > end)
            {
                int temp = beg;
                beg = end;
                end = temp - 1;
            }
            //else
            //    beg = beg + 1;

            for (int i = beg + 1; i <= end; i++)
            {
                dgvQuickLookup.Rows[i].Cells["Select"].Value = (bool)dgvQuickLookup.Rows[beg].Cells["Select"].Value;
            }
        }
        void dgvQuickLookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = true;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (bMuiltiLookup)
            {
                if (dtQuickLookup.Rows.Count > 0 && e.KeyCode == Keys.Space && dtQuickLookup.Columns.Contains("Select"))
                {
                    DataRow dr = ((DataRowView)bdsQuickLookup.Current).Row;
                    dr["Select"] = !(bool)dr["Select"];
                }
            }

            base.OnKeyDown(e);
        }
    }
}