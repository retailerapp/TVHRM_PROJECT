using System;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;
using Epoint.Systems.Commons;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;

namespace Epoint
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                Common.SetEnvironment();

                if (!Login())
                    return;

                Common.InitSystem();                

                if (!EpointMethod.CheckdataLics())
                {
                    EpointMethod.UpdateDataLics();
                    Application.Exit();
                }
                else
                {
                    frmMain frmmain = new frmMain();
                    Application.Run(frmmain);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static bool Login()
        {
            if (false)
            {
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
            else
            {
                Element.sysUser_Id = "ADMIN";
                return true;
            }
            
            
        }
    }
}