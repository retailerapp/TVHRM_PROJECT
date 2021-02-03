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
using DevExpress.XtraGrid.Views.BandedGrid;

namespace Epoint.Systems.Customizes
{
    public partial class frmQuickLookupMulti : Epoint.Systems.Customizes.frmView
    {
        private DataTable dtQuickLookup;
        private DataRow drCurrent;
        private BindingSource bdsQuickLookup = new BindingSource();
        private dgvGridControl dgvQuickLookup = new dgvGridControl();

        public string strTableName = string.Empty;
        public string strZone = string.Empty;
        public string strOrder = string.Empty;
        public bool bMuiltiLookup = false;

        bool bCheckKey = false;
        int BeginRow = -1, EndRow;

        public frmQuickLookupMulti()
        {
            this.KeyPreview = true;
            this.KeyPreview = true;
            this.ExportControl = dgvQuickLookup;

            this.dgvQuickLookup.dgvGridView.DoubleClick += new EventHandler(dgvQuickLookup_CellMouseDoubleClick);
            this.dgvQuickLookup.dgvGridView.Click += new EventHandler(dgvQuickLookup_CellMouseClick);

            InitializeComponent();
        }

        public frmQuickLookupMulti(string strTableName, string strZone, bool bMuiltiLookup)
        {
            this.strTableName = strTableName;
            this.strZone = strZone;
            this.bMuiltiLookup = bMuiltiLookup;

            this.KeyPreview = true;
            this.ExportControl = dgvQuickLookup;

            this.dgvQuickLookup.dgvGridView.DoubleClick += new EventHandler(dgvQuickLookup_CellMouseDoubleClick);
            this.dgvQuickLookup.dgvGridView.Click += new EventHandler(dgvQuickLookup_CellMouseClick);

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
               //DevExpress.XtraGrid.Columns.GridColumn dgvchkBoxColumn = new DevExpress.XtraGrid.Columns.GridColumn()

                DevExpress.XtraGrid.Columns.GridColumn ColSelect = new DevExpress.XtraGrid.Columns.GridColumn();
                //DataGridViewCheckBoxColumn dgvchkBoxColumn = new DataGridViewCheckBoxColumn();
                ColSelect.Name = "SELECT";
                ColSelect.FieldName = "SELECT";
                ColSelect.Visible = true;
                ColSelect.VisibleIndex = 0;
                ColSelect.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                ColSelect.Caption = "Chọn";
                ColSelect.Width = 80;
                dgvQuickLookup.dgvGridView.Columns.Insert(0, ColSelect);
                //dgvQuickLookup.dgvAdvBandedGridView.Columns.Add(ColSelect);
                //ColSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //ColSelect.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            }
        }

        private void FillData()
        {
            dtQuickLookup = DataTool.SQLGetDataTable(this.strTableName, "*", this.strLookupKeyFilter, this.strOrder);
            string sFilter = string.Empty;
            //Thêm cột chọn nhiều mã
            if (!dtQuickLookup.Columns.Contains("SELECT"))
            {
                DataColumn dcSelect = new DataColumn("SELECT", typeof(bool));
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
                            dr["SELECT"] = true;
                            dr.AcceptChanges();
                            break;
                        }
                    }
                }

            
            }

            dtQuickLookup.AcceptChanges();
            bdsQuickLookup.DataSource = dtQuickLookup;
            dgvQuickLookup.DataSource = bdsQuickLookup;
            //dgvQuickLookup.BuildGridView(this.isLookup);
            //bdsQuickLookup.Position = bdsQuickLookup.Find(this.strLookupColumn, sFilter);
            bdsQuickLookup.Position = bdsQuickLookup.Find("SELECT", true);
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

                if (bMuiltiLookup && dtQuickLookup.Columns.Contains("SELECT"))
                {
                    dtQuickLookup.AcceptChanges();
                    string strColumnSelect = "";
                    DataRow[] drArr = dtQuickLookup.Select("SELECT = true");
                    foreach (DataRow dr in drArr)
                    {
                        strColumnSelect = strColumnSelect + (strColumnSelect == "" ? "" : ",") + (string)dr[strLookupColumn];
                    }

                    drLookup.Table.Columns.Add(new DataColumn("MuiltiSelectValue", typeof(string)));
                    drLookup["MuiltiSelectValue"] = strColumnSelect != string.Empty ? strColumnSelect : (string)drLookup[strLookupColumn];
                }

                this.Close();
            }
        }
        #endregion

        void dgvQuickLookup_CellMouseDoubleClick(object sender, EventArgs e)
        {
            this.EnterProcess();
        }
        void dgvQuickLookup_CellMouseClick(object sender, EventArgs e)
        {
            if (bdsQuickLookup.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsQuickLookup.Current).Row;
            string strColumnName = dgvQuickLookup.dgvGridView.FocusedColumn.Name;

            

            if (!bCheckKey)
            {
                BeginRow = bdsQuickLookup.Position;

                if (strColumnName == "SELECT")
                {
                    drCurrent["SELECT"] = !(bool)drCurrent["SELECT"];
                }
                //dgvQuickLookup.Rows[e.RowIndex].Cells["Select"].Value = !(bool)dgvQuickLookup.Rows[e.RowIndex].Cells["Select"].Value;
            }
            else
            {
                if (BeginRow == -1)
                {
                    BeginRow = dgvQuickLookup.dgvGridView.FocusedRowHandle;
                }
                else
                {
                    EndRow = dgvQuickLookup.dgvGridView.FocusedRowHandle;
                }

                Check(BeginRow, EndRow);
                BeginRow = EndRow;
            }
                
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (bMuiltiLookup)
            {
                if (dtQuickLookup.Rows.Count > 0 && e.KeyCode == Keys.Space && dtQuickLookup.Columns.Contains("Select"))
                {
                    DataRow dr = ((DataRowView)bdsQuickLookup.Current).Row;
                    dr["SELECT"] = !(bool)dr["SELECT"];
                }
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = true;
            }

            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = false;
            }
                base.OnKeyUp(e);
        }

        void dgvQuickLookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = true;
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
                dgvQuickLookup.dgvGridView.SetRowCellValue(i, "SELECT", true);
            }
        }
    }
}