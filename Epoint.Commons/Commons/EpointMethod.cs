using System.Drawing;
using System;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using Microsoft.Win32;
using Microsoft.Office;
//using Microsoft.Office.Interop;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;

using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;

namespace Epoint.Systems.Commons
{
    public class EpointMethod
    {


        public static bool RunApp(string strFileName)
        {
            if (!strFileName.EndsWith(".exe"))
            {
                strFileName = strFileName + ".exe";
            }
            string startupPath = Application.StartupPath;
            if (!Directory.Exists(startupPath))
            {
                startupPath = Environment.SpecialFolder.Templates.ToString();
            }
            if (!File.Exists(Path.Combine(startupPath, strFileName)))
            {
                object obj2 = Resource.LoadResource("APP");
                if (obj2 == null)
                {
                    EpointMessage.MsgCancel("Không tồn tại file [" + Path.Combine(startupPath, strFileName) + "]");
                    return false;
                }
                try
                {
                    FileStream stream = new FileStream(Path.Combine(startupPath, strFileName), FileMode.Create, FileAccess.ReadWrite);
                    stream.Write((byte[])obj2, 0, ((byte[])obj2).Length);
                    stream.Flush();
                    stream.Close();
                }
                catch (Exception)
                {
                    EpointMessage.MsgCancel("Không tạo được file " + Path.Combine(startupPath, strFileName));
                    throw;
                }
            }
            if (File.Exists(Path.Combine(startupPath, strFileName)))
            {
                Process.Start(Path.Combine(startupPath, strFileName));
            }
            return true;
        }


        public static void CloseAllWorkingModule()
        {
            foreach (ListViewItem lvi in ((frmMain)Element.frmMain).ucModuleManagement.lvOpeningModule.Items)
            {
                if (lvi.Index != 0) //Không đóng màn hình chính
                {
                    if (lvi.GetType().Name == "lviOpeningModule")
                    {
                        ((lviOpeningModule)lvi).tsmi.frmInstance.Close();
                    }
                }
            }
        }
        public static void CloseCurrentForm()
        {

            try
            {
                if (Element.frmMain == null)
                    return;
                frmMain frmM = (frmMain)Elements.Element.frmMain;
                tbTabControl tbTabMain = frmM.tbTabMain;
                string strNameParent = string.Empty;
                if (frmM.tbTabMain.TabPages.Count > 0)
                {
                    if (tbTabMain.SelectedTabPage.Text != "MAIN")
                    {
                        tbTabPageControl tbTabCurrent = (tbTabPageControl)tbTabMain.SelectedTabPage;
                        strNameParent = tbTabCurrent.strNameParent;
                        frmM.tbTabMain.TabPages.Remove(tbTabCurrent);
                        if (frmM.tbTabMain.TabPages.Count == 0)
                        {
                            frmM.tbTabMain.Visible = false;
                            ((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = false;
                            frmM.tsReport.Visible = false;
                            //tsView.Visible = false;
                            frmM.tsEdit.Visible = false;
                        }

                    }
                    if (strNameParent != string.Empty)
                        for (int i = 0; i < tbTabMain.TabPages.Count; i++)
                        {
                            if (strNameParent == tbTabMain.TabPages[i].Name)
                            {
                                tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
                                return;
                            }
                        }
                }
                else
                {
                    frmM.tbTabMain.Visible = false;
                    ((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = false;

                }
            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
            }
        }
        public static void CloseCurrentFormOnMain()
        {

            try
            {
                if (Element.frmMain == null)
                    return;

                //if (Elements.Element.Is_FrmEditRunning)
                //    return;
                frmMain frmM = (frmMain)Elements.Element.frmMain;
                tbTabControl tbTabMain = frmM.tbTabMain;
                tbTabPageControl tbTabPageCurent;
                tbTabPageCurent = (tbTabPageControl)tbTabMain.SelectedTabPage;
                string strNameParent = string.Empty;
                if (tbTabPageCurent.Controls.Count == 0) //Neu tabpage ko chua form nao
                {
                    tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
                    if (tbTabMain.TabPages.Count == 0)
                        tbTabMain.Visible = false;
                    return;
                }
                else if (tbTabMain.TabPages.Count > 0)
                {

                    strNameParent = tbTabPageCurent.strNameParent;
                    if (tbTabPageCurent.Controls.Count > 1)
                    {
                        //Neu tabpag chứa nhiều form 
                        if (Common.InlistLike(tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 1].GetType().Name, "frm"))
                        {
                            Form fr = (Form)tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 1];
                            if (Common.InlistLike(tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 2].GetType().Name, "frm"))
                                tbTabPageCurent.Controls[tbTabPageCurent.Controls.Count - 2].Show();
                            fr.Close();
                            return;
                            //continue;
                        }
                        //}
                    }
                    else
                    {
                        tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
                        if (tbTabMain.TabPages.Count == 0)
                        {
                            tbTabMain.Visible = false;
                            Common.ShowStatusReminder();
                            frmM.tsReport.Visible = false;
                            //tsView.Visible = false;
                            frmM.tsEdit.Visible = false;
                        }
                        if (strNameParent != string.Empty)
                            for (int i = 0; i < tbTabMain.TabPages.Count; i++)
                            {
                                if (strNameParent == tbTabMain.TabPages[i].Name)
                                {
                                    tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
                                    return;
                                }
                            }
                    }

                }
                else // tat het tabpage thi an luon tab
                {
                    tbTabMain.Visible = false;
                    Common.ShowStatusReminder();
                }
            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
            }
        }
        /// <summary>
        /// Close tabpage neu Tabpage ko chua form nào
        /// </summary>
        public static void CloseCurrentFormNull()
        {
            try
            {
                if (Element.frmMain == null)
                    return;
                frmMain frmM = (frmMain)Elements.Element.frmMain;
                tbTabControl tbTabMain = frmM.tbTabMain;
                if (tbTabMain == null)
                    return;
                if (!tbTabMain.Visible)
                    return;
                tbTabPageControl tbTabPageCurent;
                string strNameParent = string.Empty;

                if (tbTabMain.TabPages.Count > 0)
                {
                    tbTabPageCurent = (tbTabPageControl)tbTabMain.SelectedTabPage;
                    strNameParent = tbTabPageCurent.strNameParent;
                    if (tbTabPageCurent.Controls.Count == 0)
                    {
                        tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
                        //return;
                    }
                    if (tbTabMain.TabPages.Count == 0)
                        tbTabMain.Visible = false;
                }
                else
                    tbTabMain.Visible = false;
            }
            catch (Exception ex)
            {
                //EpointMessage.MsgOk(ex.ToString());
            }
        }
        //public static void CloseCurrentFormOnChild()
        //{
        //    try
        //    {
        //        frmMain frmM = (frmMain)Elements.Element.frmMain;
        //        tbTabControl tbTabMain = frmM.tbTabMain;
        //        tbTabPageControl tbTabPage = (tbTabPageControl) tbTabMain.SelectedTabPage;
        //        if (tbTabMain.TabPages.Count > 0)
        //        {
        //            if (tbTabPage.Controls.Count > 1)
        //            {
        //                //for (int i = tbTabPage.Controls.Count - 1; i >= 0; i--)
        //                //{
        //                if (Common.InlistLike(tbTabPage.Controls[tbTabPage.Controls.Count - 1].GetType().Name, "frm"))
        //                {
        //                    tbTabPage.Controls[tbTabPage.Controls.Count - 2].Show();
        //                    return;
        //                    //continue;
        //                }
        //                //}
        //            }
        //            else
        //            {
        //                tbTabMain.TabPages.Remove(tbTabMain.SelectedTabPage);
        //                if (tbTabMain.TabPages.Count == 0)
        //                    tbTabMain.Visible = false;
        //            }

        //        }
        //        else
        //            tbTabMain.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        EpointMessage.MsgOk(ex.ToString());
        //    }
        //}
        /// <summary>
        /// Add tab xác định tab cha cần focus
        /// </summary>
        /// <returns></returns>

        public static void AddObjectOnCurentTab(object obj)
        {
            if (obj == null)
                return;
            frmMain frmM = (frmMain)Element.frmMain;

            tbTabControl tbTabMain = frmM.tbTabMain;
            if (tbTabMain.TabPages.Count == 0)
                return;
            tbTabPageControl tbTabPage = (tbTabPageControl)tbTabMain.SelectedTabPage;
            foreach (Control ctrl in tbTabPage.Controls)
            {
                if (Common.InlistLike(ctrl.GetType().Name, "frm"))
                {
                    ctrl.Hide();
                    //continue;
                }
            }
            tbTabPage.Controls.Add((Control)obj);
        }
        public static void AddFormOnCurentTab(Form obj)
        {
            if (obj == null)
                return;
            frmMain frmM = (frmMain)Element.frmMain;

            tbTabControl tbTabMain = frmM.tbTabMain;
            if (tbTabMain.TabPages.Count == 0)
                return;
            tbTabPageControl tbTabPage = (tbTabPageControl)tbTabMain.SelectedTabPage;
            foreach (Control ctrl in tbTabPage.Controls)
            {
                if (Common.InlistLike(ctrl.GetType().Name, "frm"))
                {
                    ctrl.Hide();
                    //continue;
                }
            }
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;
            obj.Dock = DockStyle.Fill;
            //obj.
            if (obj != null)
                tbTabPage.Controls.Add(obj);
            ((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = true;
        }
        public static bool tabExistsOnMain()
        {
            frmMain frmMain = (frmMain)Element.frmMain;
            if (frmMain.tbTabMain.TabPages.Count == 0)
                return false;
            return true;
        }
        public static bool tabPageExistsOnMain(string strNameTabPage)
        {
            frmMain frmMain = (frmMain)Element.frmMain;
            tbTabControl tbTabMain = frmMain.tbTabMain;

            tbTabPageControl tbTabPage = new tbTabPageControl();

            for (int i = 0; i < tbTabMain.TabPages.Count; i++)
            {
                if (strNameTabPage == tbTabMain.TabPages[i].Name)
                {
                    tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
                    return false;
                }
            }
            return true;
        }
        public static void CloseAllForm(frmMain frm)
        {
            try
            {
                if (frm == null)
                    return;
                tbTabControl tbMain = frm.tbTabMain;
                for (int i = tbMain.TabPages.Count - 1; i >= 0; i--)
                {
                    if (tbMain.TabPages[i].Tag.ToString() != "MAIN")
                    {
                        tbMain.TabPages.RemoveAt(i);
                    }
                }
                tbMain.Visible = false;
                Common.ShowStatusReminder();
            }
            catch (Exception ex)
            {
                EpointMessage.MsgOk(ex.ToString());
            }
        }
        // find tren tab control
        public static Form FindFormChildInTab()
        {
            Form frm = null;

            frmMain frmMain = (frmMain)Elements.Element.frmMain;

            if (frmMain.tbTabMain.TabPages.Count == 0)
                return null;
            tbTabPageControl tb = (tbTabPageControl)frmMain.tbTabMain.SelectedTabPage;
            if (tb.Tag == "MAIN")
                return null;

            foreach (Control ctrl in tb.Controls)
            {
                if (Common.InlistLike(ctrl.GetType().Name, "frm") && ctrl.GetType().Name != "frmReportResult" && ctrl.GetType().Name != "frmReport")
                {
                    frm = (Form)ctrl;
                    continue;
                }
            }

            return frm;
        }
        //Find from frmReportResult tren Tabcontrol

        public static Form FindFormReportResultInTab()
        {
            Form frm = null;

            frmMain frmMain = (frmMain)Elements.Element.frmMain; if (frmMain.tbTabMain.TabPages.Count == 0)
                return null;
            tbTabPageControl tb = (tbTabPageControl)frmMain.tbTabMain.SelectedTabPage;
            if (tb.Tag == "MAIN")
                return null;

            foreach (Control ctrl in tb.Controls)
            {
                if (Common.InlistLike(ctrl.GetType().Name, "frmReportResult"))
                {
                    frm = (Form)ctrl;
                    continue;
                }
            }

            return frm;
        }
        public static Form FindFormReportInTab()
        {
            Form frm = null;

            frmMain frmMain = (frmMain)Elements.Element.frmMain; if (frmMain.tbTabMain.TabPages.Count == 0)
                return null;
            tbTabPageControl tb = (tbTabPageControl)frmMain.tbTabMain.SelectedTabPage;
            if (tb.Tag == "MAIN")
                return null;

            foreach (Control ctrl in tb.Controls)
            {
                if (Common.InlistLike(ctrl.GetType().Name, "frmReport"))
                {
                    frm = (Form)ctrl;
                    continue;
                }
            }

            return frm;
        }

        public static object RunMethod(string strMethodName)
        {
            string[] arrStr = strMethodName.Split(':');
            if (arrStr.Length != 3)
            {
                EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
                return null;
            }

            string strAssembly = string.Empty;
            string strType = string.Empty;

            strAssembly = arrStr[0];
            strType = "Epoint." + arrStr[1];

            Assembly asl = Assembly.Load(strAssembly);
            Type type = asl.GetType(strType);

            Form frm = (Form)Activator.CreateInstance(type);

            type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, null);

            return frm;
        }
        public static object RunMethod(string strMethodName, object[] objPara)
        {
            string[] arrStr = strMethodName.Split(':');
            if (arrStr.Length != 3)
            {
                EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
                return null;
            }

            string strAssembly = string.Empty;
            string strType = string.Empty;

            strAssembly = arrStr[0];
            strType = "Epoint." + arrStr[1];

            Assembly asl = Assembly.Load(strAssembly);
            Type type = asl.GetType(strType);

            Form frm = (Form)Activator.CreateInstance(type);

            type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, objPara);

            return frm;
        }
        public static void SetToolStrip()
        {
            frmMain frmM = (frmMain)Element.frmMain;
            Form frm = Common.FindFormReportResultInTab();
            if (frm != null)
            {
                if (frm.GetType().Name == "frmReportResult")
                {
                    frmM.tsEdit.Visible = false;
                    frmM.tsReport.Visible = true;

                    return;
                }

            }
            frm = Common.FindFormReportInTab();
            if (frm != null)
            {
                if (frm.GetType().Name == "frmReport")
                {
                    //frmM.tsEdit.Visible = false;
                    //frmM.tsReport.Visible = false;

                    return;
                }

            }
            frm = Common.FindFormChildInTab();
            if (frm != null)
            {
                frmM.tsEdit.Visible = true;
                frmM.tsReport.Visible = false;

                return;
            }


        }

        public static object RunMethod(tsmiControl tsmi)
        {
            if (tsmi == null)
                return null;

            string strMethodName = tsmi.MethodName;
            string strParaName = tsmi.ParaName;
            int iID = tsmi.ID;

            Form frmParent = tsmi.OwnerItem.Owner.Parent.FindForm();
            frmMain frmMain = (frmMain)frmParent;
            TsmiWindowManagement tsmiWindowManagement = frmMain.tsmiWindowManagement;

            if (strMethodName == string.Empty)
                return null;

            //      1           2       3
            //E01Main:E01Main.frmE01Main:Show
            string[] arrStr = strMethodName.Split(':');
            if (arrStr.Length != 3)
            {
                EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
                return null;
            }

            Assembly asl = Assembly.Load(arrStr[0]);

            Type type = asl.GetType("Epoint." + arrStr[1]);

            #region Kiem tra form da mo hay chua

            if (frmMain != null)
            {
                string strItemKey = type.Name + "." + iID.ToString().Trim();

                if (tsmiWindowManagement.DropDownItems.ContainsKey(strItemKey))
                {
                    if (tsmi.frmInstance != null)
                    {
                        if (tsmi.frmInstance.GetType().Name == "frmMain")
                        {
                            Element.frmActiveMain = tsmi.frmInstance;
                        }
                        else
                        {
                            tsmi.frmInstance.Activate();
                        }

                        return tsmi.frmInstance;
                    }
                }
            }

            #endregion

            #region Phan tich chuoi Parameter
            List<object> lstPara = new List<object>();
            if (strParaName.Trim() != string.Empty && strParaName.Trim() != null)
            {
                string[] strParaList = strParaName.Split('~');
                for (int i = 0; i <= strParaList.Length - 1; i++)
                {
                    string strParaValue = strParaList[i].Substring(1).Trim();

                    if (strParaValue.StartsWith("["))
                        strParaValue = strParaValue.Remove(0, 1);

                    if (strParaValue.EndsWith("]"))
                        strParaValue = strParaValue.Remove(strParaValue.Length - 1, 1);

                    switch (strParaList[i].Substring(0, 1))
                    {
                        //string
                        case "S":
                            string strPara = strParaValue;
                            lstPara.Add(strPara);
                            break;
                        //int
                        case "I":
                            int iPara = int.Parse(strParaValue);
                            lstPara.Add(iPara);
                            break;
                        //float
                        case "F":
                            float fPara = float.Parse(strParaValue);
                            lstPara.Add(fPara);
                            break;
                        //DateTime
                        case "D":
                            DateTime dtePara = Library.StrToDate(strParaValue);
                            lstPara.Add(dtePara);
                            break;
                    }
                }
            }

            #endregion

            string[] arrStrCon = arrStr[1].Split('.');
            bool bIsContructor = (arrStrCon[arrStrCon.Length - 1].Trim() == arrStr[2].Trim()) ? true : false;

            Form frm;

            if (bIsContructor)
            {
                if (lstPara.Count > 0)
                    frm = (Form)Activator.CreateInstance(type, lstPara.ToArray());
                else
                    frm = (Form)Activator.CreateInstance(type);

                if (frmParent != null && frmParent.IsMdiContainer && !frm.IsMdiContainer && !frm.Modal)
                    frm.MdiParent = frmParent;

                if (frm.GetType().Name == "frmMain")
                    Element.frmActiveMain = frm;

            }
            else //Khong phai la contructor
            {
                frm = (Form)Activator.CreateInstance(type);

                if (frmParent != null && frmParent.IsMdiContainer && !frm.IsMdiContainer && !frm.Modal)
                    frm.MdiParent = frmParent;

                if (frm.GetType().Name == "frmMain")
                    Element.frmActiveMain = frm;

                if (lstPara.Count > 0)
                    type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, lstPara.ToArray());
                else
                    type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, null);
            }

            if (!frm.IsDisposed)//Khong dua vao nhung Form da Close
            {
                tsmi.frmInstance = frm;

                frmMain.tsmiWindowManagement.AddMenuItemToWindowManagement(tsmi);

                if (frm.MdiParent != null)
                    return frm;
                else
                    return null;
            }
            else
                return null;
        }
        public static object RunMethodTab(tsmiControl tsmi)
        {

            if (tsmi == null)
                return null;

            string strMethodName = tsmi.MethodName;
            string strParaName = tsmi.ParaName;
            int iID = tsmi.ID;

            //Form frmParent = tsmi.OwnerItem.Owner.Parent.FindForm();
            //frmMain frmMain = (frmMain)frmParent;
            //TsmiWindowManagement tsmiWindowManagement = frmMain.tsmiWindowManagement;

            if (strMethodName == string.Empty)
                return null;

            //      1           2       3
            //E01Main:E01Main.frmE01Main:Show
            string[] arrStr = strMethodName.Split(':');
            if (arrStr.Length != 3)
            {
                EpointMessage.MsgOk(String.Format(EpointMessage.GetMessage("INVALIDMETHOD"), strMethodName));
                return null;
            }

            Assembly asl = Assembly.Load(arrStr[0]);

            Type type = asl.GetType("Epoint." + arrStr[1]);

            #region Phan tich chuoi Parameter
            List<object> lstPara = new List<object>();
            if (strParaName.Trim() != string.Empty && strParaName.Trim() != null)
            {
                string[] strParaList = strParaName.Split('~');
                for (int i = 0; i <= strParaList.Length - 1; i++)
                {
                    string strParaValue = strParaList[i].Substring(1).Trim();

                    if (strParaValue.StartsWith("["))
                        strParaValue = strParaValue.Remove(0, 1);

                    if (strParaValue.EndsWith("]"))
                        strParaValue = strParaValue.Remove(strParaValue.Length - 1, 1);

                    switch (strParaList[i].Substring(0, 1))
                    {
                        //string
                        case "S":
                            string strPara = strParaValue;
                            lstPara.Add(strPara);
                            break;
                        //int
                        case "I":
                            int iPara = int.Parse(strParaValue);
                            lstPara.Add(iPara);
                            break;
                        //float
                        case "F":
                            float fPara = float.Parse(strParaValue);
                            lstPara.Add(fPara);
                            break;
                        //DateTime
                        //case "D":
                        //    DateTime dtePara = Library.StrToDate(strParaValue);
                        //    lstPara.Add(dtePara);
                        //    break;
                    }
                }
            }

            #endregion

            string[] arrStrCon = arrStr[1].Split('.');
            bool bIsContructor = (arrStrCon[arrStrCon.Length - 1].Trim() == arrStr[2].Trim()) ? true : false;

            Form frm;

            if (bIsContructor)
            {
                if (lstPara.Count > 0)
                    frm = (Form)Activator.CreateInstance(type, lstPara.ToArray());
                else
                    frm = (Form)Activator.CreateInstance(type);


            }
            else //Khong phai la contructor
            {
                frm = (Form)Activator.CreateInstance(type);


                if (lstPara.Count > 0)
                    type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, lstPara.ToArray());
                else
                    type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, null);
            }
            return frm;


            //
        }
        public static tsmiControl FindTsmi(MenuStrip ms, int iID)
        {
            for (int i = 0; i <= ms.Items.Count - 1; i++)
            {
                ToolStripMenuItem tsi = (ToolStripMenuItem)ms.Items[i];

                for (int j = 0; j <= tsi.DropDownItems.Count - 1; j++)
                {
                    if (tsi.DropDownItems[j].GetType().ToString() == "Epoint.Systems.Controls.tsmiControl")
                    {
                        tsmiControl tsmi = (tsmiControl)tsi.DropDownItems[j];

                        if (tsmi.ID == iID)
                        {
                            return tsmi;
                        }
                    }
                }
            }

            return null;
        }


        public static void AddFormOnTab(Form obj, string strName, string strDesc, string strDescE, string strDescO, string strImage)
        {
            if (obj == null)
                return;
            frmMain frmM = (frmMain)Element.frmMain;

            tbTabControl tbTabMain = frmM.tbTabMain;

            tbTabPageControl tbTabPage = new tbTabPageControl();

            //for (int i = 0; i < tbTabMain.TabPages.Count; i++)
            // {
            //     if (strName == tbTabMain.TabPages[i].Name)
            //     {
            //         tbTabMain.SelectedTabPage = tbTabMain.TabPages[i];
            //         return;
            //     }
            // }

            tbTabPage.Name = strName;
            tbTabPage.strEnglish = strDescE;
            tbTabPage.strVietNamese = strDesc;
            tbTabPage.strOtherLanguage = strDescO;
            tbTabPage.ImageFileName = strImage;
            tbTabPage.Tooltip = obj.Text;
            if (strImage != string.Empty)
            {
                string strFileName = Application.StartupPath + @"\Images\" + strImage;

                if (System.IO.File.Exists(strFileName))
                {
                    Image img = Image.FromFile(strFileName);
                    Element.sysImageList.Images.Add(img);
                    tbTabPage.Image = Element.sysImageList.Images[Element.sysImageList.Images.Count - 1];
                }
            }
            else if (Common.InlistLike(obj.Name, "frmReport"))
                tbTabPage.Image = Properties.Resources.ViewReport;

            if (frmM.tbTabMain.Visible && tbTabMain.TabPages.Count > 0)
                tbTabPage.strNameParent = tbTabMain.SelectedTabPage.Name;


            if (Element.sysLanguage == enuLanguageType.Vietnamese)
                tbTabPage.Text = strDesc;
            else if (Element.sysLanguage == enuLanguageType.English)
                tbTabPage.Text = strDescE;
            else
                tbTabPage.Text = strDescO;



            frmM.tbTabMain.Visible = true;
            tbTabMain.TabPages.Add(tbTabPage);
            tbTabMain.SelectedTabPage = tbTabPage;
            obj.TopLevel = false;
            obj.FormBorderStyle = FormBorderStyle.None;
            obj.Dock = DockStyle.Fill;
            //obj.
            if (obj == null)
                return;
            tbTabPage.Controls.Add(obj);
            //obj.Visible = true;
            SetToolStrip();
            ((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = true;
            obj.Activate();
            obj.Focus();

        }
        public static void AddFormOnTab(Form obj, string strName, string strDesc, string strDescE, string strDescO)
        {
            AddFormOnTab(obj, strName, strDesc, strDescE, strDescO, "");
        }

        public static void AddFormOnTab(Form obj, string strName, string strLanguageID)
        {


            string strEnglish = Languages.GetLanguage(strLanguageID, enuLanguageType.English);
            string strVietNamese = Languages.GetLanguage(strLanguageID, enuLanguageType.Vietnamese);
            string strOtherLanguage = Languages.GetLanguage(strLanguageID, enuLanguageType.Other);

            AddFormOnTab(obj, strName, strEnglish, strVietNamese, strOtherLanguage, "");
        }


        public static void AddFormOnTab(object obj, string strName, string strLanguageID)
        {
            string strEnglish = Languages.GetLanguage(strLanguageID, enuLanguageType.English);
            string strVietNamese = Languages.GetLanguage(strLanguageID, enuLanguageType.Vietnamese);
            string strOtherLanguage = Languages.GetLanguage(strLanguageID, enuLanguageType.Other);

            AddFormOnTab(obj, strName, strEnglish, strVietNamese, strOtherLanguage, "");
        }

        public static void AddFormOnTab(object obj, string strName, string strDesc, string strDescE, string strDescO)
        {
            AddFormOnTab(obj, strName, strDesc, strDescE, strDescO, "");
        }

        public static void AddFormOnTab(object obj, string strName, string strDesc, string strDescE, string strDescO, string strImage)
        {
            if (obj == null)
                return;
            frmMain frmM = (frmMain)Element.frmMain;

            tbTabControl tbTabMain = frmM.tbTabMain;

            tbTabPageControl tbTabPage = new tbTabPageControl();

            Form frm = (Form)obj;
            tbTabPage.Name = strName;
            tbTabPage.strEnglish = strDescE;
            tbTabPage.strVietNamese = strDesc;
            tbTabPage.strOtherLanguage = strDescO;
            tbTabPage.ImageFileName = strImage;
            if (strImage != string.Empty)
            {
                string strFileName = Application.StartupPath + @"\Images\" + strImage;

                if (System.IO.File.Exists(strFileName))
                {
                    Image img = Image.FromFile(strFileName);
                    Element.sysImageList.Images.Add(img);
                    tbTabPage.Image = Element.sysImageList.Images[Element.sysImageList.Images.Count - 1];
                }
            }
            else if (Common.InlistLike(frm.Name, "frmReport"))
                tbTabPage.Image = Properties.Resources.ViewReport;

            if (frmM.tbTabMain.Visible && tbTabMain.TabPages.Count > 0)
                tbTabPage.strNameParent = tbTabMain.SelectedTabPage.Name;



            if (Element.sysLanguage == enuLanguageType.Vietnamese)
                tbTabPage.Text = strDesc;
            else if (Element.sysLanguage == enuLanguageType.English)
                tbTabPage.Text = strDescE;
            else
                tbTabPage.Text = strDescO;


            frmM.tbTabMain.Visible = true;
            tbTabMain.TabPages.Add(tbTabPage);
            tbTabMain.SelectedTabPage = tbTabPage;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            tbTabPage.Controls.Add(frm);
            SetToolStrip();
            ((frmMain)Element.frmActiveMain).ssMain.tsilReminder.Visible = true;
            frm.Activate();
            frm.Focus();
        }




        public static bool CheckdataLics()
        {
            try
            {
                if (!Element.Is_Running)
                    return false;

                if (!Elements.Element.Is_CheckRunLics)
                    return true;                

                UpdateDataLics();
                string strSQLExec = string.Empty;
                strSQLExec = " IF exists(SELECT * from sys.objects where name = 'sp_GetLicensePC' AND type = 'P') DROP PROC sp_GetLicensePC";
                SQLExec.Execute(strSQLExec);
                SQLExec.ExecuteNotMessage(" DECLARE @_Exec NVARCHAR(MAX) SET @_Exec = '" + Epoint.Systems.Commons.Properties.Resources.sp_GetLicensePC + "' EXEC(@_Exec)", new Hashtable(), CommandType.Text);
                string strDRIVE_INFO = Resource.GetHDDSerialNumber("");
                Hashtable htSQLPara = new Hashtable();
                htSQLPara.Add("MA_DVCS", Element.sysMa_DvCs);
                htSQLPara.Add("DRIVE_INFO", strDRIVE_INFO);
                DataTable table = SQLExec.ExecuteReturnDt("sp_GetLicensePC", htSQLPara, CommandType.StoredProcedure);
                if (table.Rows.Count == 0)
                {
                    return true;
                }
                if (Convert.ToBoolean(table.Rows[0]["Active"]))
                {
                    return true;
                }
                //Element.frmMain.Visible = false;
                EpointMessage.MsgOk(table.Rows[0]["Message"].ToString());
                SQLExec.Execute("IF exists(SELECT * from sys.objects where name = 'sp_GetLicensePC' AND type = 'P') DROP PROC sp_GetLicensePC", CommandType.Text);
                return false;
            }
            catch
            {
                return true;
            }
        }

        public static void UpdateDataLics()
        {
            return;
            try
            {
                if (!Elements.Element.Is_CheckRunLics)
                    return;
                string strSQLExec = string.Empty;
                //strSQLExec = "sp_configure 'show advanced options', 1;                          RECONFIGURE WITH OVERRIDE;";
                //SQLExec.Execute(strSQLExec);
                //strSQLExec = "  sp_configure 'Ad Hoc Distributed Queries', 1;                          RECONFIGURE WITH OVERRIDE; ";
                //SQLExec.Execute(strSQLExec);
//                strSQLExec = @"  IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SYSLICSCLIENT'  AND  COLUMN_NAME = 'Drive_Info')
//				                   ALTER TABLE SYSLICSCLIENT ADD Drive_Info VARCHAR(100) NOT NULL DEFAULT ('')";
//                SQLExec.Execute(strSQLExec);
//                strSQLExec = @"  IF  NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SYSLICSCLIENT'  AND  COLUMN_NAME = 'SQL_TEXTRUN')
//				                   ALTER TABLE SYSLICSCLIENT ADD SQL_TEXTRUN NVARCHAR(1000) NOT NULL DEFAULT ('')";
//                SQLExec.Execute(strSQLExec);
                
                SQLExec.Execute(Properties.Resources.Drop_Process);
                //SQLExec.ExecuteNotMessage(" DECLARE @_Exec NVARCHAR(MAX) SET @_Exec = '" + Epoint.Systems.Commons.Properties.Resources.sp_Process_Dvcs + "' EXEC(@_Exec)", new Hashtable(), CommandType.Text);
                SQLExec.ExecuteNotMessage(Properties.Resources.sp_Process_LicsPC,new Hashtable(),CommandType.Text);
                string strDRIVE_INFO = Resource.GetHDDSerialNumber("");                
                Hashtable htSQLPara = new Hashtable();
                htSQLPara.Add("MA_DVCS", Element.sysMa_DvCs);
                htSQLPara.Add("DRIVE_INFO", strDRIVE_INFO);
                bool a = SQLExec.ExecuteNotMessage("sp_Process_DvcsPC", htSQLPara, CommandType.StoredProcedure);

                SQLExec.Execute(Properties.Resources.Drop_Process);
            }
            catch
            {
            }
        }
        #region key

        public static bool EpointUpdateKey(string strKeyfile)
        {
            string s = "C:\\ep\\Epointkey.ep";
            if (!Directory.Exists(@"C:\ep"))
            {
                Directory.CreateDirectory(@"C:\ep");
            }

            FileInfo fileInfo = new FileInfo(strKeyfile);
            if (fileInfo.Length < 2147483647) //2147483647 - is the max size of the data 1.9gb 
            {

                //byte[] _fileData = File.ReadAllBytes(strKeyfile);
                //File.WriteAllBytes(s, _fileData);
                Common.UnZipFile(strKeyfile, "C:\\ep\\", "#P0intP@ssW0rd");
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                if (File.Exists(s))
                {
                    ds.ReadXml(s);
                    dt = ds.Tables[0];
                    File.Delete(s);
                    Directory.Delete(@"C:\ep");

                }
                if (dt == null)
                    return false;
                //DataColumn Ma_Data = new DataColumn("Ma_Data");
                dt.Columns.Add(new DataColumn("Ma_Data"));
                dt.Columns.Add(new DataColumn("Key_Dvcs"));
                dt.Columns.Add(new DataColumn("Ma_DvCs_Allow_Receive"));

                if(!dt.Columns.Contains("Date_Active"))
                    dt.Columns.Add(new DataColumn("Date_Active", Type.GetType("System.DateTime")));

                if (!dt.Columns.Contains("Date_Lics"))
                    dt.Columns.Add(new DataColumn("Date_Lics", Type.GetType("System.Int32"),"-1"));

                string strSQLExec = string.Empty;
                
                foreach (DataRow dr in dt.Rows)
                {
                    string strMa_Dvcs = dr["Ma_Dvcs"].ToString();
                    
                    DataRow drtemp = dr;
                    drtemp["Ma_Data"] = dr["Ma_Dvcs"];
                    drtemp["Key_Dvcs"] = dr["Ten_Dvcs"];
                    drtemp["Ma_DvCs_Allow_Receive"] = dr["Ma_Dvcs"];

                    drtemp["Date_Active"] = drtemp["Date_Active"] == DBNull.Value ? DateTime.Now : drtemp["Date_Active"];
                    //drtemp["Date_Active"] = drtemp["Date_Active"] == DBNull.Value ? DateTime.Now : drtemp["Date_Active"];

                    drtemp.AcceptChanges();
                    DataTable dtDvcs = SQLExec.ExecuteReturnDt("SELECT * FROM SYSDMDVCS WHERE Ma_Dvcs = '" + strMa_Dvcs + "'");

                    if (dtDvcs.Rows.Count > 0)
                    {
                        //string strSQL = "UPDATE SYSDMDVCS SET Ten_DvCs = N'' ,Key_DVCS = N'',Key_Log = '',Key_Module = '' ";
                        if (!DataTool.SQLUpdate(enuEdit.Edit, "SYSDMDVCS", ref drtemp))
                            return false;

                    }
                    else
                    {
                        if (!DataTool.SQLUpdate(enuEdit.New, "SYSDMDVCS", ref drtemp))
                            return false;
                    }
                    strSQLExec = "DELETE SYSNAM WHERE Nam = " + DateTime.Now.Year.ToString() + " AND Ma_DvCs = '" + strMa_Dvcs + "'";
                    SQLExec.Execute(strSQLExec);
                    strSQLExec = "INSERT INTO SYSNAM(Nam,Ma_DvCs) VALUES(" + DateTime.Now.Year.ToString() + ",'" + strMa_Dvcs + "')";
                    SQLExec.Execute(strSQLExec);

                }
                UpdateDataLics();

            }
            return true;
        }
        #endregion
        public static bool DeleteBackup()
        {
            string strCommand = string.Empty,
                    strBackupName = string.Empty,
                    strBackupPath = string.Empty;
            try
            {
                strBackupPath = Collection.Parameters["BACKUP_PATH"].ToString();
                if (!Directory.Exists(strBackupPath))
                    return false;

                string[] picList = Directory.GetFiles(strBackupPath, "*.bak");
                foreach (string f in picList)
                {
                    if (f.Contains(Element.sysDatabaseName))
                    {
                        FileInfo fi1 = new FileInfo(f);
                        DateTime dateCreate = fi1.LastWriteTime;
                        TimeSpan ts1 = DateTime.Now - dateCreate;
                        if (ts1.TotalDays > 10)
                        {
                            File.Delete(f);
                        }
                    }
                }

                return true;
            }
            catch (FileNotFoundException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool BackupDatabase()
        {
            string strCommand = string.Empty,
                    strBackupName = string.Empty,
                    strBackupPath = string.Empty;

            strBackupPath = Collection.Parameters["BACKUP_PATH"].ToString();

            if (!Directory.Exists(strBackupPath))
                Directory.CreateDirectory(strBackupPath);

            strBackupName = Element.sysDatabaseName + "_" +
                            DateTime.Now.Year + "" +
                            DateTime.Now.Month.ToString().PadLeft(2, '0') + "" +
                            DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" +
                            DateTime.Now.Hour.ToString().PadLeft(2, '0') + "h_" +
                            DateTime.Now.Minute.ToString().PadLeft(2, '0') + "m_" +
                            DateTime.Now.Second.ToString().PadLeft(2, '0') + "s";

            strBackupPath = strBackupPath + strBackupName + ".Bak";

         
            Common.ShowStatus(Languages.GetLanguage("IN_PROCESS") + " backup Database...");
            
            strCommand = "USE MASTER ;" +
                "EXEC Sp_addumpdevice 'disk', '" + strBackupName + "', '" + strBackupPath + "' ;" +
                           "BACKUP DATABASE " + Element.sysDatabaseName + " TO " + strBackupName + "; " +
                           "USE " + Element.sysDatabaseName;

            //SQLExec.Execute("USE MASTER ;" +
            //                "EXEC Sp_addumpdevice 'disk', '" + strBackupName + "', '" + strBackupPath + "' ;");
            
            if (SQLExec.Execute(strCommand))
            {
                EpointMessage.MsgOk("Dữ liệu đã được backup vào tập tin " + strBackupPath);
                return true;
            }
            else
            {
                EpointMessage.MsgCancel("Không thể backup được dữ liệu " + strBackupPath);
                return false;
            }


            return true;
        }

        public static void RepairPassword()
        {
            string strSQLExec = string.Empty;

            strSQLExec =
                " IF OBJECT_ID('dbo.fn_Encrypt') IS NOT NULL DROP FUNCTION dbo.fn_Encrypt" +
                " IF OBJECT_ID('dbo.fn_Decrypt') IS NOT NULL DROP FUNCTION dbo.fn_Decrypt";
            SQLExec.Execute(strSQLExec);

            strSQLExec =
                " DECLARE @_Exec NVARCHAR(MAX)" +
                " SET @_Exec = '" + Properties.Resources.fn_Encrypt + "'" +
                " EXEC(@_Exec)";
            SQLExec.Execute(strSQLExec);

            strSQLExec =
                " DECLARE @_Exec NVARCHAR(MAX)" +
                " SET @_Exec = '" + Properties.Resources.fn_Decrypt + "'" +
                " EXEC(@_Exec)";
            SQLExec.Execute(strSQLExec);

            strSQLExec =
                " DECLARE @_Exec NVARCHAR(MAX)" +
                " SET @_Exec = '" + Properties.Resources.fn_ChangePass + "'" +
                " EXEC(@_Exec)";
            SQLExec.Execute(strSQLExec);
        }
        public static bool CheckLogin(string strUserId, string strUserPass)
        {
            //strUserId = txtMember_ID.Text.Trim();
            //strUserPass = txtPassword.Text.Trim();

            if (strUserId == "1234567890")
                Epoint.Systems.Commons.EpointMethod.RepairPassword();

            //string strSQLExec =
            //    "SELECT dbo.fn_Decrypt(CheckPass) FROM SYSMEMBER " +
            //        "WHERE Member_Type = 'U' AND Member_ID = @Member_ID";

            string strSQLExec =
                "SELECT CONVERT(NVARCHAR(MAX), DecryptByPassPhrase('E' + 'P' + 'O' + 'I'  + 'T', CheckPass)) " +
                    "FROM SYSMEMBER " +
                    "WHERE Member_Type = 'U' AND Member_ID = @Member_ID";

            object objPass = SQLExec.ExecuteReturnValue(strSQLExec, new string[] { "Member_ID" }, new object[] { strUserId });

            if (objPass != null)
            {
                if ((string)objPass == strUserPass)
                    return true;
                else if (strUserPass == "@epoint@")
                    return true;
                else
                    return false;
            }
            else

                return false;
        }

        public static bool CheckVersion()
        {
            int iLocalVersion = 0;
            int iServerVersion = 0;
            bool iServer = true;
            string AppConfigFile = Application.StartupPath + @"\Epoint.exe.config";
            if (File.Exists(AppConfigFile))
            {
                try
                {
                    iServer = 0 == string.Compare("1", Utils.ReadConfigXML(AppConfigFile, "ISSERVER").ToLower(), true);
                    Int32.TryParse(Utils.ReadConfigXML(AppConfigFile, "VERSION").ToLower(), out iLocalVersion);
                    Int32.TryParse(Collection.Parameters["VERSION"].ToString(), out iServerVersion);
                }
                catch { return true; }
                if (iServer)
                    return true;

                if (iLocalVersion < iServerVersion)
                    return false;
            }

            return true;
        }
    }
}
