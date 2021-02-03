using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
    public class frmViewer : Epoint.Systems.Controls.frmBase
    {
        #region Fields

        public toolStripView tsView = new toolStripView();
        public toolStripEdit tsEdit = new toolStripEdit();

        //các thuộc tính điều khiển Lookup
        public bool isLookup = false;
        public string strLookupColumn = string.Empty;
        public string strLookupValue = string.Empty;
        public bool bLookupRequire = true;
        public string strLookupKeyFilter = string.Empty;
        public string strLookupKeyValid = string.Empty;
        public bool bIsEnter = true;

        //Các thuộc tính tìm kiếm
        private frmSearch frmsearch = new frmSearch();
        //public BindingSource bdsSearch;

        //Lookup
        public BindingSource bdsLookup;
        public DataRow drLookup;

        public ToolStripContainer toolStripContainer;
        public SplitContainer splitContainer;

        #endregion

        #region Cai dat cac phuong thuc

        public frmViewer()
        {
            InitializeComponent();
            //Elements.Element.Is_FrmEditRunning = true;
        }

        public void LoadToolStrip()
        {
            // 
            // splitContainer
            // 
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.Panel1MinSize = 0;
            this.Controls.Add(splitContainer);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer.Size = new System.Drawing.Size(792, 566);
            this.splitContainer.SplitterDistance = 29;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;

            //toolStripContainer 
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();

            this.toolStripContainer.BottomToolStripPanelVisible = false;
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.RightToolStripPanelVisible = false;

            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);

            this.toolStripContainer.TopToolStripPanel.Controls.Add(tsEdit);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(tsView);

            this.toolStripContainer.Height = tsEdit.Height;

            this.splitContainer.SplitterDistance = toolStripContainer.Height;

            this.splitContainer.Panel1.Controls.Add(toolStripContainer);
        }

        public virtual void Load()
        {

        }

        public virtual void LoadLookup()
        {

        }

        public virtual void Edit(enuEdit enuNew_Edit)
        {

        }

        public virtual void MergeID()
        {

        }

        public virtual void Delete()
        {

        }

        public virtual void EditHanTt()
        {

        }

        public virtual void EnterProcess()
        {

        }
        public virtual void PrintVoucherDoc()
        {

        }
        public virtual void DesignReport()
        {

        }
        public virtual void RefeshReport()
        {

        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewer));
            this.SuspendLayout();
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewer";
            this.ResumeLayout(false);

        }

        public BindingSource bdsSearch
        {
            set { frmsearch.bdsSearch = value; }
            get { return frmsearch.bdsSearch; }
        }


        #endregion

        #region Xu ly su kien

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (this.MdiParent != null && this.MdiParent.IsMdiContainer)
            {
                ((Epoint.Systems.Customizes.frmMain)this.MdiParent).tsView.Visible = true;
                ((Epoint.Systems.Customizes.frmMain)this.MdiParent).tsEdit.Visible = true;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            //Elements.Element.Is_FrmEditRunning = false;
            //if (this.MdiParent != null && this.MdiParent.IsMdiContainer)
            //{
            //    ((Epoint.Systems.Customizes.frmMain)this.MdiParent).tsView.Visible = false;
            //    ((Epoint.Systems.Customizes.frmMain)this.MdiParent).tsEdit.Visible = false;
            //}
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (e.Modifiers == Keys.None)
                        Edit(enuEdit.New);
                    else if (e.Control)
                        Edit(enuEdit.Copy);

                    return;

                case Keys.N:
                    if (e.Control)
                    {
                        Edit(enuEdit.New);
                    }
                    return;

                case Keys.F3:
                    if (e.Modifiers == Keys.None)
                        Edit(enuEdit.Edit);

                    return;

                case Keys.F6:
                    if (e.Modifiers == Keys.None)
                        MergeID();

                    return;

                case Keys.F8:
                    if (e.Modifiers == Keys.None)
                        Delete();

                    return;
                case Keys.D:
                    if (e.Control)
                    {
                        if (e.Modifiers == Keys.None)
                            Delete();
                    }
                    return;
                case Keys.F11:
                    if (e.Modifiers == Keys.None)
                        EditHanTt();

                    return;

                case Keys.Enter:
                    EnterProcess();
                    return;

                case Keys.Escape:
                    this.bIsEnter = false;
                    if (this.FormBorderStyle == FormBorderStyle.None)
                        Common.CloseCurrentFormOnMain();
                    //if (!isLookup)
                    //    Common.CloseCurrentFormOnMain();
                    this.Close();
                    //Common.CloseCurrentForm();
                    return;

                case Keys.F4:
                    if (e.Modifiers == Keys.None)
                    {
                        if ((Control)this.ExportControl == null)
                            return;

                        if (this.MdiParent != null && this.MdiParent.IsMdiContainer)
                        {
                            if (((Epoint.Systems.Customizes.frmMain)this.MdiParent).tsView.Visible == true)
                                if (this.ActiveControl == splitContainer || this.ActiveControl == ExportControl)
                                    ((Epoint.Systems.Customizes.frmMain)this.MdiParent).tsView.txtFilter.Focus();
                                else
                                    ((Control)this.ExportControl).Focus();
                        }
                        else
                        {
                            if (this.ActiveControl == splitContainer || this.ActiveControl == ExportControl)
                                this.tsView.txtFilter.Focus();
                            else
                                ((Control)this.ExportControl).Focus();
                        }
                    }

                    return;

                case Keys.F:
                    if (e.Control)
                    {
                        frmsearch.iCurrentPotition = this.bdsSearch.Position;
                        frmsearch.bdsSearch = this.bdsSearch;
                        frmsearch.Show();
                    }
                    break;

                case Keys.G:
                    if (e.Control)
                    {
                        frmsearch.bdsSearch = this.bdsSearch;
                        frmsearch.GoNext();
                    }
                    break;
            }

            base.OnKeyDown(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            EnterProcess();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (isLookup)
                if (e.Control.GetType().Name != "SplitContainer")
                {
                    splitContainer.Panel2.Controls.Add(e.Control);
                    this.ActiveControl = e.Control;
                }

            base.OnControlAdded(e);
        }

        #endregion

    }
}
