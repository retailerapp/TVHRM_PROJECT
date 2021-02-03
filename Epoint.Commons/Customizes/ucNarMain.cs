using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Elements;

namespace Epoint.Systems.Customizes
{
    public partial class ucNarMain : UserControl
    {
        BindingSource bdsTreeMain = new BindingSource();
        DataTable dtTreeMain;
        DataTable dtGroupItemMain;

        public ucNarMain()
        {
            InitializeComponent();
            this.NarMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.tvMain.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(NodeMouseDoubleClickEvent);
            this.NarMain.KeyDown += new KeyEventHandler(KeyDownEvent);
            this.NarMain.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(tvMain_LinkClicked);
            //this.NarMain.MouseDoubleClick += new MouseEventHandler(NarMain_MouseClick);

            this.NarMain.SizeChanged += new EventHandler(NarMain_SizeChanged);
            this.MinimumSize = new Size(0, 0);
            this.MaximumSize = new Size(0, 0);
            this.NarMain.Height = this.Height;
            this.NarMain.BackColor = System.Drawing.Color.FromArgb(255, 216, 228, 248);
        }

        void NarMain_MouseClick(object sender, MouseEventArgs e)
        {
            //string Name = (Epoint.Systems.Controls.NarvarControl)sender;
            //MessageBox.Show(Name);
            //frmModule f = new frmModule();
            //f.ShowDialog();
        }

        void NarMain_SizeChanged(object sender, EventArgs e)
        {

            this.Width = this.NarMain.Width;
        }

        public void LoadControl()
        {
            dtTreeMain = DataTool.SQLGetDataTable("SYSModule", "*", "Show_On_Main = 1 AND  Is_Module = 1 ", "Stt");
            bdsTreeMain.DataSource = dtTreeMain;


            dtGroupItemMain = SQLExec.ExecuteReturnDt(@"select r2.Module_Id, Menu_Id = CAST( CAST(r2.Module_Id AS VARCHAR(5)) +  CAST(r1.Menu_Id AS VARCHAR(5)) AS INT), 
                                                            Menu_Parent, Menu_Name, Menu_NameE, r1.Stt, r1.Picture, 
                                                            Menu_Method, Menu_Para, r1.Show_On_Main, r1.Is_Customize, r1.Object_ID, Menu_NameO
                                                             from SYSmenu (NOLOCK) r1
                                                            inner join SYSMODULEME (NOLOCK) r2 ON r1.Menu_Id = r2.Menu_Id
                                                            INNER JOIN SYSMODULE  (NOLOCK) r3 ON r3.Module_Id = r2.Module_Id 
       
                                                             ORDER BY r2.Module_Id,Stt");

            //string strQuery = "SELECT * FROM vw_Module_Menu ";


            //Kiểm tra Permission
            foreach (DataRow dr in dtTreeMain.Rows)
            {
                //Kiểm tra phân hệ có hợp lệ hay không
                if ((bool)dr["Is_Module"])
                    if (!Core.Is_Module_Valid((int)dr["Module_ID"]))
                    {
                        dr.Delete();
                        continue;
                    }

                if (!Common.CheckPermission((string)dr["Object_ID"], enuPermission_Type.Allow_Access))
                    dr.Delete();
            }
            //Kiểm tra Permission
            foreach (DataRow dr in dtGroupItemMain.Rows)
            {
                //Kiểm tra phân hệ có hợp lệ hay không
                if (!Common.CheckPermission((string)dr["Object_ID"], enuPermission_Type.Allow_Access))
                    dr.Delete();
                
            }

            this.NarMain.KeyFieldName = "Module_ID";
            this.NarMain.ParentFieldName = "Module_Parent";
            this.NarMain.DisplayFieldName = "Module_Name";
            this.NarMain.ImageFileName = "Picture";

            this.NarMain.VietNameseFieldName = "Module_Name";
            this.NarMain.EngLishFieldName = "Module_NameE";
            this.NarMain.OtherFieldName = "Module_NameO";



            this.NarMain.KeyFieldNameItem = "Menu_ID";
            this.NarMain.ParentFieldNameItem = "Module_ID";
            this.NarMain.DisplayFieldNameItem = "Menu_Name";
            this.NarMain.OjbjectID_FieldNameItem = "Object_ID";
            this.NarMain.ImageFileNameItem = "Picture";

            this.NarMain.VietNameseFieldNameItem = "Menu_Name";
            this.NarMain.EngLishFieldNameItem = "Menu_NameE";
            this.NarMain.OtherFieldNameItem = "Menu_NameO";


            this.NarMain.TableNarbarItem = dtGroupItemMain;

            this.NarMain.DataSource = bdsTreeMain;
        }

        public void LoadControl(int iModule_ID)
        {
            if (iModule_ID <= 0)
            {
                this.LoadControl();
                return;
            }

            string strQuery = "SELECT * FROM SYSMENU (NOLOCK) " +
                                    " WHERE (Show_On_Main = 1) AND " +
                                    " Menu_ID IN(SELECT Menu_ID FROM SYSMODULEME (NOLOCK) WHERE Module_ID = " + iModule_ID + ") " +
                                    " ORDER BY Stt ";

            dtTreeMain = SQLExec.ExecuteReturnDt(strQuery);
            bdsTreeMain.DataSource = dtTreeMain;

            //Kiểm tra Permission
            foreach (DataRow dr in dtTreeMain.Rows)
            {
                if (!Common.CheckPermission((string)dr["Object_ID"], enuPermission_Type.Allow_Access))
                    dr.Delete();
            }

            this.NarMain.KeyFieldName = "Menu_ID";
            this.NarMain.ParentFieldName = "Menu_Parent";
            this.NarMain.DisplayFieldName = "Menu_Name";
            this.NarMain.ImageFileName = "Picture";

            this.NarMain.VietNameseFieldName = "Menu_Name";
            this.NarMain.EngLishFieldName = "Menu_NameE";
            this.NarMain.OtherFieldName = "Menu_NameO";

            this.NarMain.DataSource = bdsTreeMain;
        }

        public void RunMethod()
        {


            if (this.NarMain.SelectedLink == null)
                return;

            if (this.NarMain.SelectedLink.Item.Tag == "")
                return;

            int iID = int.Parse(this.NarMain.SelectedLink.ItemName);

            NarvarItemControl tbCtrl = (NarvarItemControl)this.NarMain.SelectedLink.Item;

            frmMain frmM = (frmMain)this.FindForm();
            


            tsmiControl tsmi = Common.FindTsmi(frmM.msMainSys, iID);
            tbTabControl tbTabMain = frmM.tbTabMain;
            if (tsmi != null)
            {

                tbTabPageControl tbTabPage = new tbTabPageControl();
                tbTabPage.Name = "tabPage" + iID.ToString();

                for (int i = 0; i < tbTabMain.TabPages.Count; i++)
                {
                    if (tbTabPage.Name == tbTabMain.TabPages[i].Name)
                    {
                        tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
                        return;
                    }
                }

                Form obj = (Form)Common.RunMethodTab(tsmi);

                if (Common.InlistLike(obj.Text,"frm"))
                {
                    frmView fv = new frmView();
                    try
                    {
                        fv = (frmView)obj;
                        fv.Object_ID = tbCtrl.strObject_ID;
                    }
                    catch { }
                    
                    if (!fv.isView)
                    {
                        return;
                    }
                }       //obj.Visible = false;
                Common.AddFormOnTab(obj, "tabPage" + iID.ToString(), tbCtrl.strVietNamese, tbCtrl.strEnglish, tbCtrl.strOtherLanguage, tbCtrl.strImageFileName, tbCtrl.strObject_ID);
            }

        }
        public void RunMethodFormBase()
        {


            if (this.NarMain.SelectedLink == null)
                return;

            if (this.NarMain.SelectedLink.Item.Tag == "")
                return;

            int iID = int.Parse(this.NarMain.SelectedLink.ItemName);

            NarvarItemControl tbCtrl = (NarvarItemControl)this.NarMain.SelectedLink.Item;

            frmMain frmM = (frmMain)this.FindForm();



            tsmiControl tsmi = Common.FindTsmi(frmM.msMainSys, iID);
            tbTabControl tbTabMain = frmM.tbTabMain;
            if (tsmi != null)
            {

                tbTabPageControl tbTabPage = new tbTabPageControl();
                tbTabPage.Name = "tabPage" + iID.ToString();

                for (int i = 0; i < tbTabMain.TabPages.Count; i++)
                {
                    if (tbTabPage.Name == tbTabMain.TabPages[i].Name)
                    {
                        tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
                        return;
                    }
                }

                frmBase obj = (frmBase)Common.RunMethodTabFormBase(tsmi);

                if (Common.InlistLike(obj.Text, "frm"))
                {
                    frmView fv = new frmView();
                    try
                    {
                        fv = (frmView)obj;
                        fv.Object_ID = tbCtrl.strObject_ID;
                    }
                    catch { }

                    if (!fv.isView)
                    {
                        return;
                    }
                }       //obj.Visible = false;
                Common.AddFormOnTab(obj, "tabPage" + iID.ToString(), tbCtrl.strVietNamese, tbCtrl.strEnglish, tbCtrl.strOtherLanguage, tbCtrl.strImageFileName, tbCtrl.strObject_ID);
            }

        }
        public void SetProperlyHeight(frmMain frm)
        {
            //int iHeight = (tvMain.VisibleNodeCount * tvMain.Height) + 50;

            //int iHeight = frm.MaximumSize.Height ;

            this.Height = this.MaximumSize.Height;


        }
        void tvMain_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                RunMethodFormBase();
            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.Message);
            }
        }
        void NodeMouseDoubleClickEvent(object sender, TreeNodeMouseClickEventArgs e)
        {
            RunMethodFormBase();
        }

        void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RunMethod();

                e.Handled = true;
            }
        }


        protected override void OnEnter(EventArgs e)
        {
            //base.OnEnter(e);
            this.NarMain.Focus();
        }
        protected override void OnGotFocus(EventArgs e)
        {
            //base.OnGotFocus(e);
            //Element.Is_FrmEditRunning = false;
            this.NarMain.Focus();
        }
    }
}
