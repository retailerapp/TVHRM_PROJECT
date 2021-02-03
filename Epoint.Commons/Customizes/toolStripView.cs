using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Resources;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
    public class toolStripView : Epoint.Systems.Controls.tsControl
    {
        public tstFilter txtFilter = new tstFilter();
        public tsbSearch tsbSearch = new tsbSearch();
        public tsbFilter tsbFilter = new tsbFilter();
        public tsbTotal tsbTotal = new tsbTotal();
        public tsbExport tsbExport = new tsbExport();
        public tsbQuickReport tsbQuickReport = new tsbQuickReport();

        public toolStripView()
        {
            this.Items.Add(txtFilter);
            this.Items.Add(tsbSearch);
            this.Items.Add(tsbFilter);
            this.Items.Add(tsbTotal);

            this.Items.Add(new ToolStripSeparator());

            this.Items.Add(tsbExport);
            this.Items.Add(tsbQuickReport);
        }
    }

    public class tstFilter : tstControl
    {
        bool bLostFocus = false;
        string strColumnFilter = string.Empty;

        public tstFilter()
        {
            this.GotFocus += new EventHandler(tstFilter_GotFocus);
            this.LostFocus += new EventHandler(tstFilter_LostFocus);
            this.ToolTipText = Languages.GetLanguage("FILTER");
            this.TextChanged += new EventHandler(tstFilter_TextChanged);
            this.KeyDown += new KeyEventHandler(tstFilter_KeyDown);
        }

        void tstFilter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                case Keys.Enter:
                case Keys.Escape:
                case Keys.Tab:
                    Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();
                    // Tim form tren tabcontrol
                    if (frm == null)
                        frm = Common.FindFormChildInTab();

                    ((frmBase)frm).ActiveControl = (Control)((frmBase)frm).ExportControl;
                    break;
            }
        }

        void tstFilter_GotFocus(object sender, EventArgs e)
        {
            bLostFocus = false;
        }

        void tstFilter_LostFocus(object sender, EventArgs e)
        {
            this.bLostFocus = true;
            this.Text = string.Empty;
            this.strColumnFilter = "";
        }

        public void Filter()
        {
            Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();
            // Tim form tren tabcontrol
            if (frm == null)
                frm = Common.FindFormChildInTab();

            if (frm == null)
                return;

            object ExportControl = ((frmBase)frm).ExportControl;

            if (ExportControl == null)
                return;

            //dgvControl
            if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
            {
                dgvControl dgv = (dgvControl)ExportControl;

                if (strColumnFilter == string.Empty)
                    strColumnFilter = dgv.CurrentCell.OwningColumn.DataPropertyName;

                if (dgv.bdsFind == null) //|| this.CurrentCell == null)
                    return;

                if (dgv.bFilter == false)
                    dgv.strFilterOrg = dgv.bdsFind.Filter;

                string strFilter = "(" + strColumnFilter + " LIKE '%" + this.Text + "%')";

                if (((DataTable)dgv.bdsFind.DataSource).Columns[strColumnFilter].DataType.Name != "String")
                    return;

                if (dgv.strFilterOrg != string.Empty && dgv.strFilterOrg != null)
                    dgv.bdsFind.Filter = "(" + dgv.strFilterOrg + ") AND " + strFilter;
                else
                    dgv.bdsFind.Filter = strFilter;

                if (dgv.Rows.Count > 0)
                    dgv.CurrentCell = dgv.Rows[0].Cells[strColumnFilter];

                dgv.bFilter = true;
            }
            else if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
            {
                tlControl tl = (tlControl)ExportControl;

                //if (tl.FocusedColumn == null)
                //    return;

                if (strColumnFilter == string.Empty)
                    strColumnFilter = tl.FocusedColumn.FieldName;

                if (tl.bdsFind == null)
                    return;

                if (tl.bFilter == false)
                    tl.strFilterOrg = tl.bdsFind.Filter;

                string strFilter = strColumnFilter + " LIKE '%" + this.Text + "%'";

                //bdsFind.Filter = strFilter;
                if (tl.strFilterOrg != string.Empty && tl.strFilterOrg != null)
                    tl.bdsFind.Filter = "(" + tl.strFilterOrg + ") AND " + strFilter;
                else
                    tl.bdsFind.Filter = strFilter;

                if (tl.Nodes.Count > 0)
                    tl.SetNodeIndex(tl.Nodes[0], tl.Columns[strColumnFilter].VisibleIndex);

                tl.bFilter = true;
            }
        }

        void tstFilter_TextChanged(object sender, EventArgs e)
        {
            if (bLostFocus)
                return;

            this.Filter();
        }
    }

    public class tsbSearch : tsbControl
    {
        public tsbSearch()
        {
            Bitmap Bmp = new Bitmap(Resources.Resource.search_48, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Search");
            this.Text = Languages.GetLanguage("Search");
            this.Click += new EventHandler(tsbSearch_Click);
        }

        void tsbSearch_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch();
            Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();
            // Tim form tren tabcontrol
            if (frm == null)
                frm = Common.FindFormChildInTab();

            if (frm == null)
                return;

            object ExportControl = ((frmBase)frm).ExportControl;

            if (ExportControl == null)
                return;

            //dgvControl
            if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
            {
                dgvControl dgv = (dgvControl)ExportControl;

                frmSearch.bdsSearch = (BindingSource)dgv.DataSource;
            }
            else if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
            {
                tlControl tl = (tlControl)ExportControl;
                frmSearch.bdsSearch = (BindingSource)tl.DataSource;

                
            }
            frmSearch.Show();
        }
    }

    public class tsbFilter : tsbControl
    {
        public tsbFilter()
        {
            Bitmap Bmp = new Bitmap(Epoint.Systems.Commons.Properties.Resources.Filter, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Filter");
            this.Text = Languages.GetLanguage("Filter");
            this.Click += new EventHandler(tsbFilter_Click);
        }

        void tsbFilter_Click(object sender, EventArgs e)
        {
            Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();
            // Tim form tren tabcontrol
            if (frm == null)
                frm = Common.FindFormChildInTab();
            if (frm == null)
                return;

            if (((frmBase)frm).ExportControl == null)
            {
                EpointMessage.MsgCancel("Chưa gán ExportControl");
                return;
            }

            object ExportControl = ((frmBase)frm).ExportControl;

            frmFilter frmFilter = new frmFilter();
            frmFilter.Load(ExportControl);

        }
    }

    public class tsbTotal : tsbControl
    {
        public tsbTotal()
        {
            Bitmap Bmp = new Bitmap(Resources.Resource.Sum1, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Total");
            this.Text = Languages.GetLanguage("Total");
            this.Click += new EventHandler(tsbTotal_Click);
        }

        void tsbTotal_Click(object sender, EventArgs e)
        {
            DataTable dtTotal = null;
            string strColumnName = string.Empty;
            string strHeaderText = string.Empty;
            string strFilter = string.Empty;

            Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();
            // Tim form tren tabcontrol
            if (frm == null)
                frm = Common.FindFormChildInTab();

            if (frm == null)
                frm = Common.FindFormReportResultInTab();

            if (frm == null)
                return;

            object ExportControl = ((frmBase)frm).ExportControl;

            if (ExportControl == null)
                return;

            #region dgvControl, tlControl
            //dgvControl
            if (Common.Inlist(ExportControl.GetType().Name, "dgvControl,dgvReport,dgvVoucher"))
            {
                dgvControl dgv = (dgvControl)ExportControl;

                if (dgv.DataSource == null)
                    return;

                if (dgv.DataSource.GetType().Name != "BindingSource")
                    return;

                BindingSource bds = (BindingSource)dgv.DataSource;
                if (bds == null)
                    return;

                if (dgv.CurrentCell == null)
                    return;

                dtTotal = (DataTable)bds.DataSource;
                strColumnName = dgv.CurrentCell.OwningColumn.DataPropertyName;
                strHeaderText = dgv.CurrentCell.OwningColumn.HeaderText;
                strFilter = bds.Filter;
            }
            if (Common.Inlist(ExportControl.GetType().Name, "dgvGridReport,dgvGridControl,dgvReportGrid"))
            {
                dgvGridControl dgv = (dgvGridControl)ExportControl;

                if (dgv.DataSource == null)
                    return;

                if (dgv.DataSource.GetType().Name != "BindingSource")
                    return;

                BindingSource bds = (BindingSource)dgv.DataSource;
                if (bds == null)
                    return;

                if (dgv.dgvGridView == null)
                    return;

                dtTotal = (DataTable)bds.DataSource;
                strColumnName = dgv.dgvGridView.FocusedColumn.Name;
                strHeaderText = dgv.dgvGridView.FocusedColumn.Caption;
                strFilter = bds.Filter;
            }
            //tlControl
            if (Common.Inlist(ExportControl.GetType().Name, "tlControl,tlReport"))
            {
                tlControl tl = (tlControl)ExportControl;

                if (tl.DataSource == null)
                    return;

                if (tl.DataSource.GetType().Name != "BindingSource")
                    return;

                BindingSource bds = (BindingSource)tl.DataSource;
                if (bds == null)
                    return;

                if (tl.FocusedColumn == null)
                    return;

                dtTotal = (DataTable)bds.DataSource;
                strColumnName = tl.FocusedColumn.FieldName;
                strHeaderText = tl.FocusedColumn.Caption;
                strFilter = bds.Filter;
            }

            if (!Common.Inlist(dtTotal.Columns[strColumnName].DataType.Name, "Byte, Int16, Int32, Int64, Decimal, Double"))
                return;

            #endregion

            if (dtTotal == null)
                return;

            double dbSumToltal = Common.SumDCValue(dtTotal, strColumnName, strFilter);
            string strMsg = Languages.GetLanguage("SUM") + " " + strHeaderText + ": " + dbSumToltal.ToString("N");

            if (dtTotal.Columns.Contains("Bold"))
            {
                string strFilterNormal = strFilter + (strFilter == string.Empty || strFilter == null ? "" : " AND ") + " Bold = 0 ";
                string strFilterBold = strFilter + (strFilter == string.Empty || strFilter == null ? "" : " AND ") + " Bold = 1 ";

                double dbSumNormal = Common.SumDCValue(dtTotal, strColumnName, strFilterNormal);
                double dbSumBold = Common.SumDCValue(dtTotal, strColumnName, strFilterBold);

                strMsg += "\n" + Languages.GetLanguage("SUM_NORMAL") + ": " + dbSumNormal.ToString("N");
                strMsg += "\n" + Languages.GetLanguage("SUM_BOLD") + ": " + dbSumBold.ToString("N");
            }

            EpointMessage.MsgOk(strMsg);
        }
    }

    public class tsbExport : tsbControl
    {
        public tsbExport()
        {
            Bitmap Bmp = new Bitmap(Resources.Resource.Export, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Export");
            this.Text = Languages.GetLanguage("Export");
            this.Click += new EventHandler(tsbExport_Click);
        }

        void tsbExport_Click(object sender, EventArgs e)
        {
            Form frmView = Common.FindFormReportResultInTab();
            if (frmView != null)
            {    //Kết xuất dữ liệu trên báo cáo
                if (frmView.GetType().Name == "frmReportResult")
                {
                    Form frmReport = frmView;
                    frmReport.GetType().InvokeMember("Export", System.Reflection.BindingFlags.InvokeMethod, null, frmReport, null);
                }
            }
            else //Kết xuất dữ liệu trên lưới thông thường
            {
                Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();

                frm = Common.FindFormChildInTab();

                if (frm == null)
                    return;
                object ExportControl = ((frmBase)frm).ExportControl;

                if (ExportControl == null)
                    return;

                Common.Export(ExportControl);
            }
        }
    }

    public class tsbQuickReport : tsbControl
    {
        public tsbQuickReport()
        {
            Bitmap Bmp = new Bitmap(Resources.Resource.QuickReport, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Quick_Report");
            this.Text = Languages.GetLanguage("Quick_Report");
            this.Click += new EventHandler(tsbQuickReport_Click);
        }

        void tsbQuickReport_Click(object sender, EventArgs e)
        {
            Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();
            // Tim form tren tabcontrol
            if (frm == null)
                frm = Common.FindFormChildInTab();
            if (frm == null)
                return;

            object ExportControl = ((frmBase)frm).ExportControl;

            if (ExportControl == null)
                return;

            Common.RunQuickReport(ExportControl);
        }
    }
}
