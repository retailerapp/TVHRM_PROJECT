using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
    public class menuStripMain : MenuStrip
    {
        public int iModule_ID = -1;

        public menuStripMain()
        {
            this.Margin = new Padding(2);
            this.ImageScalingSize = new System.Drawing.Size(20, 20);
        }

        //Load Menu cho Main chính
        public void Load()
        {
            DataTable dtModule = DataTool.SQLGetDataTable("SYSMODULE", "*", "", "Module_Parent, Module_Id");
            //string strQuery = "SELECT * FROM vw_Module_Menu ";
            DataRow[] drArrParent;
            //DataTable dtModule = SQLExec.ExecuteReturnDt(strQuery);
            if (Element.Is_ShowConfig)
                drArrParent = dtModule.Select("Module_Parent = 0 AND Module_Id <> 100");
            else
                drArrParent = dtModule.Select("Module_Parent = 0 AND Module_Id <> 100 AND Module_Id = 7000");
            string[] strArrNumber = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "p", "q", "r", "s", "t" };

            foreach (DataRow drParent in drArrParent)
            {//Menu cha

                int iModule_Parent_Id = (int)drParent["Module_Id"];
                string strPicture = (string)drParent["Picture"];

                if (iModule_Parent_Id == 9000) //Điều khiển
                    if (!Element.sysIs_Admin)
                        continue;

                tsmiControl tsmiParent = new tsmiControl();

                tsmiParent.Text = (string)drParent["Module_Name"];
                tsmiParent.Vietnamese = (string)drParent["Module_Name"];
                tsmiParent.English = (string)drParent["Module_NameE"];
                tsmiParent.ImageName = strPicture;
                if (drParent.Table.Columns.Contains("Module_NameO"))
                    tsmiParent.Other = (string)drParent["Module_NameO"];
                else
                    tsmiParent.Other = tsmiParent.English;


                if (strPicture != string.Empty)
                {
                    string strFileName = Application.StartupPath + @"\Images\" + strPicture;
                    if (System.IO.File.Exists(strFileName))
                    {
                        Image img = Image.FromFile(strFileName);

                        tsmiParent.Image = img;
                    }
                }

                DataRow[] drArrChild = dtModule.Select("Module_Parent = " + iModule_Parent_Id.ToString());
                int iNumber = 0;

                foreach (DataRow drChild in drArrChild)
                {//Menu con

                    int iModule_Child_Id = (int)drChild["Module_Id"];
                    strPicture = (string)drChild["Picture"];
                    //Kiểm tra phân hệ có hợp lệ hay không
                    if ((bool)drChild["Is_Module"])
                    {
                        if (!Core.Is_Module_Valid(iModule_Child_Id))
                            continue;
                    }

                    tsmiControl tsmiChild = new tsmiControl();

                    iNumber++;
                    string strPrefix = string.Empty;

                    if (iNumber <= strArrNumber.Length)
                        strPrefix = "&" + strArrNumber[iNumber - 1] + ". ";

                    tsmiChild.Text = strPrefix + (string)drChild["Module_Name"];
                    tsmiChild.Vietnamese = strPrefix + (string)drChild["Module_Name"];
                    tsmiChild.English = strPrefix + (string)drChild["Module_NameE"];
                    tsmiChild.ImageName = strPicture;
                    if (drChild.Table.Columns.Contains("Module_NameO"))
                        tsmiChild.Other = (string)drChild["Module_NameO"];
                    else
                        tsmiChild.Other = tsmiChild.English;


                    if (strPicture != string.Empty)
                    {
                        string strFileName = Application.StartupPath + @"\Images\" + strPicture;
                        if (System.IO.File.Exists(strFileName))
                            tsmiChild.Image = Image.FromFile(strFileName);
                    }

                    tsmiChild.MethodName = ((string)drChild["Module_Method"]).Trim();
                    tsmiChild.ParaName = ((string)drChild["Module_Para"]).Trim();
                    tsmiChild.ID = (int)drChild["Module_ID"];
                    tsmiChild.Parent_ID = (int)drChild["Module_Parent"];
                    tsmiChild.bIs_Module = (bool)drChild["Is_Module"];
                    tsmiChild.Click += new EventHandler(tsmiRunMethod);

                    //Kiem tra Permission
                    if (Common.CheckPermission((string)drChild["Object_ID"], enuPermission_Type.Allow_Access))
                        tsmiParent.DropDownItems.Add(tsmiChild);
                }

                this.Items.Add(tsmiParent);
            }

        }

        //Load Menu cho main phân hệ
        public void Load(int iModule_ID)
        {
            this.iModule_ID = iModule_ID;

            if (iModule_ID <= 0)
            {
                this.Load();
                return;
            }

            DataTable dtMenu = SQLExec.ExecuteReturnDt("Sp_GetModule_Menu", "@Module_ID", iModule_ID, CommandType.StoredProcedure);
            DataRow[] drArrParent = dtMenu.Select("Menu_Parent = 0");
            string[] strArrNumber = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "p", "q", "r", "s", "t" };

            foreach (DataRow drParent in drArrParent)
            {//Menu cha

                int iMenu_Parent_Id = (int)drParent["Menu_Id"];

                tsmiControl tsmiParent = new tsmiControl();

                tsmiParent.Text = (string)drParent["Menu_Name"];               

                string strPicture = (string)drParent["Picture"];
                tsmiParent.ImageName = strPicture;
                if (strPicture != string.Empty)
                {
                    string strFileName = Application.StartupPath + @"\Images\" + strPicture;
                    if (System.IO.File.Exists(strFileName))
                        tsmiParent.Image = Image.FromFile(strFileName);
                }
                tsmiParent.English = ((string)drParent["Menu_NameE"]).Trim();
                tsmiParent.Vietnamese = ((string)drParent["Menu_Name"]).Trim();
                tsmiParent.MethodName = ((string)drParent["Menu_Method"]).Trim();
                tsmiParent.ParaName = ((string)drParent["Menu_Para"]).Trim();

                if (drParent.Table.Columns.Contains("Menu_NameO"))
                    tsmiParent.Other = ((string)drParent["Menu_NameO"]).Trim();
                else
                    tsmiParent.Other = tsmiParent.English;

                DataRow[] drArrChild = dtMenu.Select("Menu_Parent = " + iMenu_Parent_Id.ToString());
                int iNumber = 0;

                foreach (DataRow drChild in drArrChild)
                {//Menu con

                    iNumber++;
                    string strPrefix = string.Empty;

                    if (iNumber <= strArrNumber.Length)
                        strPrefix = "&" + strArrNumber[iNumber - 1] + ". ";

                    int iModule_Child_Id = (int)drChild["Menu_Id"];

                    tsmiControl tsmiChild = new tsmiControl();

                    tsmiChild.Text = strPrefix + (string)drChild["Menu_Name"];
                    tsmiChild.Vietnamese = strPrefix + (string)drChild["Menu_Name"];
                    tsmiChild.English = strPrefix + (string)drChild["Menu_NameE"];
                    tsmiChild.ImageName = (string)drChild["Picture"]; ;
                    tsmiChild.Object_Id = (string)drChild["Object_Id"];
                    if (drChild.Table.Columns.Contains("Menu_NameO"))
                        tsmiChild.Other = ((string)drChild["Menu_NameO"]).Trim();
                    else
                        tsmiChild.Other = tsmiChild.English;

                    strPicture = (string)drChild["Picture"];
                    if (strPicture != string.Empty)
                    {
                        string strFileName = Application.StartupPath + @"\Images\" + strPicture;
                        if (System.IO.File.Exists(strFileName))
                            tsmiChild.Image = Image.FromFile(strFileName);
                    }

                    tsmiChild.MethodName = ((string)drChild["Menu_Method"]).Trim();
                    tsmiChild.ParaName = ((string)drChild["Menu_Para"]).Trim();
                    tsmiChild.ID = (int)drChild["Menu_Id"];
                    tsmiChild.Parent_ID = (int)drChild["Menu_Parent"];
                    tsmiChild.bIs_Module = false;
                    tsmiChild.Click += new EventHandler(tsmiRunMethod);

                    //Kiem tra Permission
                    if (Common.CheckPermission((string)drChild["Object_ID"], enuPermission_Type.Allow_Access))
                        tsmiParent.DropDownItems.Add(tsmiChild);
                }

                this.Items.Add(tsmiParent);
            }
        }

        void tsmiRunMethod(object sender, EventArgs e)
        {
            tsmiControl tsmiMenu = (tsmiControl)sender;

            if (tsmiMenu.MethodName == string.Empty)
                return;

            //object obj = Common.RunMethod(tsmiMenu);


            frmMain frmM = (frmMain)this.FindForm();
            tbTabControl tbTabMain = frmM.tbTabMain;

            if (tsmiMenu != null)
            {

                tbTabPageControl tbTabPage = new tbTabPageControl();
                tbTabPage.Name = "tabPage" + tsmiMenu.ID.ToString();

                for (int i = 0; i < tbTabMain.TabPages.Count; i++)
                {
                    if (tbTabPage.Name == tbTabMain.TabPages[i].Name)
                    {
                        tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
                        return;
                    }
                }
                tbTabPage.Text = tsmiMenu.Text;

                Form obj = (Form)Common.RunMethodTab(tsmiMenu);
                if (obj == null)
                {

                    return;
                }
                frmM.tbTabMain.Visible = true;

                Common.AddFormOnTab(obj, "tabPage" + tsmiMenu.ID.ToString(), tsmiMenu.Vietnamese, tsmiMenu.English, tsmiMenu.Other, tsmiMenu.ImageName);
            }
        }
    }

}
