using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using Epoint.Systems.Data;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;


namespace Epoint.Systems.Commons
{
    public class EpointProcessBox
    {
        
        private Thread thrStar;
        private string _Message;
       
        public static frmProcessBar frmpro = new frmProcessBar();

        public static frmProcessBar frmProcess
        {
            set {frmpro = value;}
            get {return frmpro;}
        }
        public string Message
        {
            set {_Message = value;}
            get {return _Message;}
        }
        public EpointProcessBox()
        {
            
        }

        public static void Show()
        {
            frmpro = new frmProcessBar();
            frmpro.ShowDialog();

            //Thread newThread = new Thread(new ThreadStart(ThreadShow));
            //newThread.Start(); // Dữ liệu truyền vào là một số nguyên 
            frmpro.txtExpr.Text = string.Empty;

            
        }
        public static void Show(frmView frm)
        {
            
            frmpro = new frmProcessBar(frm);
            frmpro.ShowDialog();

            //Thread newThread = new Thread(new ThreadStart(ThreadShow));
            //newThread.Start(); // Dữ liệu truyền vào là một số nguyên 
            frmpro.txtExpr.Text = string.Empty;


        }
        public static void ShowOK(bool bshow)
        {
            frmpro.btOK.Enabled = bshow;
        }
        public static void SetStatus(string strStatus)
        {
            frmpro.SetStatus(strStatus);
        }
        public static void ProcessBarStop()
        {
            frmpro.proBarRelease.Step = frmpro.proBarRelease.Maximum;
        }
        public static void AddMessage(string strMessage)
        {
            frmpro.AddMessage(strMessage);
        }
        
        public static void ThreadShow()
        {
            frmProcess = frmpro;
            frmpro.ShowDialog();
            
        }

        public static void setValue(int iValue)
        {
            frmpro.setValue(iValue);
        }
        public static void setMaxValue(int iMaxValue)
        {

            frmpro.setMaxValue(iMaxValue);
        }
    }
}
