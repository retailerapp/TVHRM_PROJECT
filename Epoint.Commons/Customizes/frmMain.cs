using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Systems.Customizes
{
    public partial class frmMain : frmBase
    {

        public int iModule_ID = -1;
        private bool is_ShowTable = false;
        private ucWTable ucDesk;
        public menuStripMain msMain;
        public menuStripSys msMainSys;
        public statusStripMain ssMain;
        public toolStripSystem tsSystem;
        public toolStripView tsView;
        public toolStripEdit tsEdit;
        public toolStripReport tsReport;
        public UcTreeMain ucTreeMain;

        public tbTabControl tbTabMain;
        public pnlControl pnImage;
        public ucNarMain ucNarvarMain;


        public TsmiWindowManagement tsmiWindowManagement;
        public ucCustomerInfo ucCustomer;
        public UcModuleManagement ucModuleManagement;
        private int UcModuleHeight = 0;
        Point pUcModule = new Point(0, 0);
        
        //public menuStripMain msMain = new menuStripMain();
        //public statusStripMain ssMain = new statusStripMain();
        //public toolStripSystem tsSystem = new toolStripSystem();
        //public toolStripView tsView = new toolStripView();
        //public toolStripEdit tsEdit = new toolStripEdit();
        //public toolStripReport tsReport = new toolStripReport();
        //public UcTreeMain ucTreeMain = new UcTreeMain();
        //public TsmiWindowManagement tsmiWindowManagement = new TsmiWindowManagement();
        //public UcModuleManagement ucModuleManagement = new UcModuleManagement();

        public frmMain()
        {
            InitializeComponent();

            if (Element.Is_Running)
            {



                msMain = new menuStripMain();
                //
                msMainSys = new menuStripSys();

                ssMain = new statusStripMain();
                tsSystem = new toolStripSystem();
                tsView = new toolStripView();
                tsEdit = new toolStripEdit();
                tsReport = new toolStripReport();

                ucTreeMain = new UcTreeMain();
                tbTabMain = new tbTabControl();

                ucNarvarMain = new ucNarMain();// Create Tree

                tsmiWindowManagement = new TsmiWindowManagement();
                ucModuleManagement = new UcModuleManagement();
                ucCustomer = new ucCustomerInfo();

                this.WindowState = FormWindowState.Maximized;
                this.toolStripContainer.Enter += new EventHandler(toolStripContainer_Enter);
                this.Paint += new PaintEventHandler(frmMain_Paint);
                this.SetColor();

                //this.ucTreeMain.Visible = false;
                this.ssMain.tsbtYear.Click += new EventHandler(tsbtYear_Click);
                this.tbTabMain.HeaderButtonClick += new DevExpress.XtraTab.ViewInfo.HeaderButtonEventHandler(tbTabMain_HeaderButtonClick);
                this.tbTabMain.KeyPress += new KeyPressEventHandler(tbTabMain_KeyPress);
                this.tbTabMain.KeyDown += new KeyEventHandler(tbTabMain_KeyDown);
                this.tbTabMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(tbTabMain_SelectedPageChanged);
                //this.tbTabMain.VisibleChanged += new EventHandler(tbTabMain_VisibleChanged);
                this.KeyDown += new KeyEventHandler(frmMain_KeyDown);


            }
        }
        
        public void LoadToolStrip()
        {
            //ToolStrip
            this.msMain.Load(this.iModule_ID);
            this.msMain.Items.Add(tsmiWindowManagement);

            this.msMainSys.Load();
            this.msMainSys.Items.Add(tsmiWindowManagement);
            //this.toolStripContainer.ImageScalingSize = new System.Drawing.Size(50, 50);
            //this.toolStripContainer.MaximumSize = new System.Drawing.Size(this.Width, 300);
            //this.toolStripContainer.Size = new System.Drawing.Size(300, 58);
            //msMainSys.Visible = false;
            //this.toolStripContainer.TopToolStripPanel.Controls.Add(msMain);
            //this.toolStripContainer.TopToolStripPanel.Controls.Add(msMainSys);

            //this.pnlScreen.Dock = DockStyle.Bottom;
            //this.toolStripContainer.Dock = DockStyle.Top;
            this.toolStripContainer.TopToolStripPanel.Dock = DockStyle.Top;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(tsReport);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(tsEdit);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(tsView);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(tsSystem);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(msMain);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(msMainSys);

            this.toolStripContainer.Height = msMain.Height + tsSystem.Height;

            if (Element.sysTextToolStrip)
            {
                this.toolStripContainer.Height += 2;
            }

            this.pnlScreen.Height = this.Height - this.toolStripContainer.Height;


            tsReport.Visible = false;
            //tsView.Visible = false;
            tsEdit.Visible = false;
            tsmiWindowManagement.Visible = false;
            msMainSys.Hide();
            //msMain.Visible = false;

            //this.ssMain.Dock = DockStyle.Bottom;
            //this.Controls.Add(ssMain);

            LoadScreen();
            //if (!Commons.EpointMethod.CheckdataLics())
            //{
            //    this.Hide();

            //    Commons.EpointMethod.UpdateDataLics();
            //    Application.Exit();
            //    this.Close();
            //}
        }

        public void LoadToolStrip(int iModule_ID)
        {

            this.LoadToolStrip();

        }

        public void LoadScreen()
        {
            //TreeMain
            //ucTreeMain = new UcTreeMain();
            //ucTreeMain.LoadControl(this.iModule_ID);
            //ucTreeMain.Dock = DockStyle.Top;
            //ucTreeMain.Width = pnlLeftScreen.Width - 20;
            //ucTreeMain.MinimumSize = new Size(ucTreeMain.Width, pnlLeftScreen.Height / 3);
            //ucTreeMain.MaximumSize = new Size(ucTreeMain.Width, pnlLeftScreen.Height * 6 / 6);
            //ucTreeMain.SetProperlyHeight();
            //ucTreeMain.Visible = false;
            //pnlLeftScreen.Controls.Add(ucTreeMain);

            ucNarvarMain = new ucNarMain();
            ucNarvarMain.LoadControl();
            ucNarvarMain.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            ucNarvarMain.SetProperlyHeight(this);

            //ucNarvarMain.Width = pnlLeftScreen.Width;
            //pnlLeftScreen.Controls.Add(ucNarvarMain);
            //this.pnlLeftScreen.Visible = false;

            /////////////////////////
            pnlScreen.Dock = DockStyle.Fill;

            this.pnlCenter.Dock = DockStyle.Fill;
            this.ucNarvarMain.Dock = DockStyle.Left;

            pnlScreen.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                        | AnchorStyles.Left)
                        | AnchorStyles.Right)));

            ////////////////////////
            tbTabPageControl tbTabPageMain = new tbTabPageControl();
            tbTabPageMain.Tag = "MAIN";

            pnImage = new pnlControl();
            //if (Element.sysLanguage == enuLanguageType.Vietnamese)
            //    pnImage.BackgroundImage = Commons.Properties.Resources.Background_V;
            //else
            //    pnImage.BackgroundImage = Commons.Properties.Resources.Background_E;
            this.pnImage = new pnlControl();
            if (Element.sysLanguage == enuLanguageType.Vietnamese)
            {
                this.pnImage.BackgroundImage = Commons.Properties.Resources.Background_V;
                if (File.Exists(Application.StartupPath + @"\Images\Background_V.png"))
                {
                    this.pnImage.BackgroundImage = Image.FromFile(Application.StartupPath + @"\Images\Background_V.png");
                }
            }
            else if (Element.sysLanguage == enuLanguageType.English)
            {
                this.pnImage.BackgroundImage = Commons.Properties.Resources.Background_E;
                if (File.Exists(Application.StartupPath + @"\Images\Background_E.png"))
                {
                    this.pnImage.BackgroundImage = Image.FromFile(Application.StartupPath + @"\Images\Background_E.png");
                }
            }
            else
            {
                this.pnImage.BackgroundImage = Commons.Properties.Resources.Background_E;
                if (File.Exists(Application.StartupPath + @"\Images\Background_O.png"))
                {
                    this.pnImage.BackgroundImage = Image.FromFile(Application.StartupPath + @"\Images\Background_O.png");
                }
            }
            pnImage.BackgroundImageLayout = ImageLayout.Stretch;
            pnImage.Dock = DockStyle.Fill;


           
            this.tbTabMain.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                        | AnchorStyles.Left)
                        | AnchorStyles.Right)));

            tbTabMain.Dock = DockStyle.Fill;
            tbTabMain.Visible = false;


            pnlScreen.Dock = DockStyle.Fill;

            this.pnlScreen.Controls.Add(ucNarvarMain);

            this.pnlCenter.Controls.Add(tbTabMain);
            this.pnlCenter.Controls.Add(pnImage);

            this.ssMain.Dock = DockStyle.Bottom;
            this.pnlCenter.Controls.Add(ssMain);




            //ModuleManagement Nhac viet

            this.ucModuleManagement.Dock = DockStyle.Bottom;
            this.ucModuleManagement.Width = pnlLeftScreen.Width - 20;
            this.UcModuleHeight = this.ucModuleManagement.Height;
            //this.ucModuleManagement.Height = this.UcModuleHeight - this.ucModuleManagement.lvReminder.Height;

            this.pnImage.Controls.Add(ucModuleManagement);

            //ucCustomer = new ucCustomerInfo();
            //ucCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            //ucCustomer.Location = new Point(this.pnImage.Width / 2 + 200, this.pnImage.Height / 2);
            //this.pnImage.Controls.Add(ucCustomer);

            //ucModuleManagement.Width = 250;
            //ucModuleManagement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            //ucModuleManagement.Location = new Point(this.pnlCenter.Width - ucModuleManagement.Width - 1, 1);
            //ucModuleManagement.Location = new Point(this.pnlCenter.Width - ucModuleManagement.Width - 1, this.pnlCenter.Height - ucModuleManagement.Height - 20);
            //ucModuleManagement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            /*
           
                        //ModuleManagement Nhac viet
                        //ucModuleManagement.Dock = DockStyle.Bottom;
                        //ucModuleManagement.Width = pnlLeftScreen.Width - 20;

                        //    pnlLeftScreen.Controls.Add(ucModuleManagement);

                        //ucModuleManagement.Width = 250;
                        //ucModuleManagement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        //if (iModule_ID <= 0)
                        //{
                        //    this.pnlCenter.Controls.Add(ucModuleManagement);
                        //    //ucModuleManagement.Location = new Point(this.pnlCenter.Width - ucModuleManagement.Width - 1, 1);
                        //    ucModuleManagement.Location = new Point(this.pnlCenter.Width - ucModuleManagement.Width - 1, this.pnlCenter.Height - ucModuleManagement.Height - 20);
                        //    ucModuleManagement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        //}

                        //Cac control khac

                        //ucCustomer = new ucCustomerInfo();
                        //this.pnlCenter.Controls.Add(ucCustomer);

                        //tbTabPageMain.Controls.Add(ucCustomer);
                        //ucCustomer.Location = new Point(0, 0);
                        //ucCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        */

            //Test
            //ucWTable ucDesk = new ucWTable();
            //ucDesk.Load();
            //ucDesk.Dock = DockStyle.Fill;
            //pnImage.Controls.Add(ucDesk);

            //

        }

        private void SetColor()
        {
        }

        #region Event

        void toolStripContainer_Enter(object sender, EventArgs e)
        {
            this.ucTreeMain.Focus();
        }
        void tbTabMain_HeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.HeaderButtonEventArgs e)
        {
            Commons.Common.CloseCurrentForm();

        }
        void tbTabMain_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tbTabMain.Visible)
            {
                this.tsView.Visible = true;
                this.tsReport.Visible = true;
                this.tsEdit.Visible = true;
            }
            else
            {
                this.tsView.Visible = false;
                this.tsReport.Visible = false;
                this.tsEdit.Visible = false;
            }
        }

        void tbTabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            Commons.Common.SetToolStrip();
            Commons.Common.ActiveFormOnTab();
        }

        void tbTabMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        void tbTabMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Commons.Common.CloseCurrentFormOnMain();
        }

        void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Commons.Common.CloseCurrentFormOnMain();
        }

        void tsbtYear_Click(object sender, EventArgs e)
        {
            frmChonNam frmNam = new frmChonNam();
            frmNam.Load();

            int iNam = Convert.ToInt32(this.ssMain.tsbtYear.Text.Trim());
            Commons.Common.SetSysWorkingYear(iNam);
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            ucNarvarMain.Focus();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (this.ucTreeMain != null)
                this.ucTreeMain.Focus();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            if (Element.Is_Running)
            {
                this.Text = Element.sysTen_Dvi.ToUpper() + "_" + Element.sysMa_DvCs;// 

                //thêm Sub khi nào khác tên
                string strTen_Dvi_Sub = DataTool.SQLGetNameByCode("SYSDMDVCS", "Ma_DvCs", "Ten_DvCs", Element.sysMa_DvCs);
                if (Element.sysTen_Dvi.ToUpper() != strTen_Dvi_Sub.ToUpper())
                    this.Text = this.Text + " - " + strTen_Dvi_Sub.ToUpper();
                // Set lai ten cty su dung
                ucCustomer.lblTen_Dvi.Text = Element.sysTen_Dvi.ToUpper();
                ucCustomer.lblDia_Chi.Text = Element.sysDia_Chi_Dv;

            }
        }

        protected override void OnClosed(EventArgs e)
        {
            this.Hide();
            // update acount server
            Commons.EpointMethod.UpdateDataLics();
            base.OnClosed(e);

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.Q:
            //        if (e.Control)
            //        {
            //            frmModuleManagement frmModule = new frmModuleManagement();
            //            frmModule.Show();
            //        }
            //        return;

            //    case Keys.F9:
            //        if (!e.Control && !e.Alt && !e.Shift)
            //        {
            //            if (tsSystem.tsbtYear.Enabled && ucTreeMain.Visible)
            //            {
            //                frmChonNam frmNam = new frmChonNam();
            //                frmNam.Load();

            //                int iNam = Convert.ToInt32(this.tsSystem.tsbtYear.Text.Trim());
            //                Commons.Common.SetSysWorkingYear(iNam);
            //            }
            //        }
            //        break;
            //}
            switch (e.KeyCode)
            {

                case Keys.Q:
                    if (e.Control)
                    {
                        // them thử
                        if (!is_ShowTable)
                        {
                            if (ucDesk == null)
                            {
                                ucDesk = new ucWTable();
                                ucDesk.Load();
                                ucDesk.Dock = DockStyle.Fill;
                                pnImage.Controls.Add(ucDesk);
                            }
                            is_ShowTable = true;
                            ucDesk.Visible = true;
                        }
                        else
                        {
                            ucDesk.Visible = false;
                            is_ShowTable = false;
                        }

                        //
                    }
                    return;
                case Keys.F10:
                    if (e.Control)
                    {
                        Element.Is_ShowConfig = !Element.Is_ShowConfig;
                        msMain.Items.Clear();
                        msMain.Load();
                    }
                    return;
                case Keys.Escape:
                    Commons.Common.CloseCurrentFormNull();
                    return;
            }

            //base.OnKeyDown(e);

        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Tab || (keyData == Keys.Shift | keyData == Keys.Tab))
        //    {
        //        if (ucTreeMain.Focused || ucTreeMain.tvMain.Focused)
        //            ucModuleManagement.Focus();
        //        else
        //            ucTreeMain.Focus();

        //        return true;
        //    }
        //    else if (keyData == Keys.Escape)
        //    {
        //        if (this.ucTreeMain.Visible && Element.frmActiveMain != Element.frmMain)
        //        {
        //            Element.frmActiveMain = Element.frmMain;
        //            return true;
        //        }
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        #endregion
    }
}
