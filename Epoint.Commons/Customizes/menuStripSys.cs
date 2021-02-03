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
	public class menuStripSys : MenuStrip
	{
		public int iModule_ID = -1;

        public menuStripSys()
		{
			this.Margin = new Padding(2);
            //this.ImageScalingSize = new System.Drawing.Size(30, 30);
		}

		//Load Menu cho Main chính
		public void Load()
		{
            DataTable dtModule = DataTool.SQLGetDataTable("SYSMODULE", "*", "", "Module_Parent, Module_Id");
            //string strQuery = "SELECT * FROM vw_Module_Menu ";
            DataTable dtGroupItemMain = SQLExec.ExecuteReturnDt(@"select r2.Module_Id, Menu_Id = CAST( CAST(r2.Module_Id AS VARCHAR(5)) +  CAST(r1.Menu_Id AS VARCHAR(5)) AS INT), 
                                                                Menu_Parent, Menu_Name, Menu_NameE, r1.Stt, r1.Picture, 
                                                                Menu_Method, Menu_Para, r1.Show_On_Main, r1.Is_Customize, r1.Object_ID, Menu_NameO
                                                                 from SYSmenu r1
                                                                inner join SYSMODULEME r2 ON r1.Menu_Id = r2.Menu_Id
                                                                INNER JOIN SYSMODULE r3 ON r3.Module_Id = r2.Module_Id");

            //DataTable dtModule = SQLExec.ExecuteReturnDt(strQuery);
			DataRow[] drArrParent = dtModule.Select("Module_Parent = 100");
			string[] strArrNumber = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "p", "q", "r", "s", "t" };

			foreach (DataRow drParent in drArrParent)
			{//Menu cha

				int iModule_Parent_Id = (int)drParent["Module_Id"];

				if (iModule_Parent_Id == 9000) //Điều khiển
					if (!Element.sysIs_Admin)
						continue;

                //Kiểm tra phân hệ có hợp lệ hay không
                if ((bool)drParent["Is_Module"])
                {
                    if (!Core.Is_Module_Valid(iModule_Parent_Id))
                        continue;
                }

				tsmiControl tsmiParent = new tsmiControl();

				tsmiParent.Text = (string)drParent["Module_Name"];
				tsmiParent.Vietnamese = (string)drParent["Module_Name"];
				tsmiParent.English = (string)drParent["Module_NameE"];

				if (drParent.Table.Columns.Contains("Module_NameO"))
					tsmiParent.Other = (string)drParent["Module_NameO"];
				else
					tsmiParent.Other = tsmiParent.English;

                //string strPicture = (string)drParent["Picture"];
                //if (strPicture != string.Empty)
                //{
                //    string strFileName = Application.StartupPath + @"\Images\" + strPicture;
                //    if (System.IO.File.Exists(strFileName))
                //    {
                //        Image img = Image.FromFile(strFileName);

                //        tsmiParent.Image = img;
                //    }
                //}

                DataRow[] drArrChild = dtGroupItemMain.Select("Module_ID = " + iModule_Parent_Id.ToString());
				int iNumber = 0;

				foreach (DataRow drChild in drArrChild)
				{//Menu con

                    int iModule_Child_Id = (int)drChild["Menu_Id"];

					//Kiểm tra phân hệ có hợp lệ hay không
                    //if ((bool)drChild["Is_Module"])
                    //{
                    //    if (!Core.Is_Module_Valid(iModule_Child_Id))
                    //        continue;
                    //}

					tsmiControl tsmiChild = new tsmiControl();

					iNumber++;
                    iNumber++;
                    string strPrefix = string.Empty;

                    if (iNumber <= strArrNumber.Length)
                        strPrefix = "&" + strArrNumber[iNumber - 1] + ". ";


                    tsmiChild.Text = strPrefix + (string)drChild["Menu_Name"];
                    tsmiChild.Vietnamese = strPrefix + (string)drChild["Menu_Name"];
                    tsmiChild.English = strPrefix + (string)drChild["Menu_NameE"];

                    if (drChild.Table.Columns.Contains("Menu_NameO"))
                        tsmiChild.Other = ((string)drChild["Menu_NameO"]).Trim();
                    else
                        tsmiChild.Other = tsmiChild.English;

                    //strPicture = (string)drChild["Picture"];
                    //if (strPicture != string.Empty)
                    //{
                    //    string strFileName = Application.StartupPath + @"\Images\" + strPicture;
                    //    if (System.IO.File.Exists(strFileName))
                    //        tsmiChild.Image = Image.FromFile(strFileName);
                    //}

                    tsmiChild.MethodName = ((string)drChild["Menu_Method"]).Trim();
                    tsmiChild.ParaName = ((string)drChild["Menu_Para"]).Trim();
                    tsmiChild.ID = (int)drChild["Menu_Id"];
                    tsmiChild.Parent_ID = (int)drChild["Menu_Parent"];
                    tsmiChild.Object_Id = ((string)drChild["Object_Id"]).Trim();
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

			object obj = Common.RunMethod(tsmiMenu);
		}
	}

}
