using System;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;
using Epoint.Systems.Commons;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Microsoft.Win32;

namespace AutoMail
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]        
        public static void Main()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkApp.SetValue("AutoMail", Application.ExecutablePath.ToString());
            Common.SetEnvironment();
            Element.sysUser_Id = "SYSTEM";
            if (!Login())
                return;
            
            Common.InitSystem();
            //frmMain frmmain = new frmMain();
            frmUpdateFile frm = new frmUpdateFile();
            //frm.Load();
            if (!EpointMethod.CheckdataLics())
            {
                Application.Exit();

                EpointMethod.UpdateDataLics();
            }
            else
            {
                frm.Load();
                Application.Run(frm);

            }

        }

        private static bool Login()
        {
            return true;
            frmLogin frmLog = new frmLogin();
            frmLog.TopMost = true;
            frmLog.ShowDialog();

            if (!frmLog.isAccept)
            {
                Application.Exit();
                Application.ExitThread();

                return false;
            }

            Element.sysUser_Id = frmLog.strUserId;

            return true;
        }
    }
}