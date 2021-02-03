using Epoint.Controllers;
using Epoint.Systems.Commons;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sendmail_Birthday
{
    public partial class Sendmail : ServiceBase
    {
        Timer tmSendmail = new Timer();
        int Sendmail_Interval = 500000;
        public Sendmail()
        {
            Common.SetEnvironment();
            Element.sysUser_Id = "SYSTEM";
            Common.InitSystem();
            Sendmail_Interval = Parameters.GetParaValue("Sendmail_Interval") == null ? 500000 : Convert.ToInt32(Parameters.GetParaValue("Sendmail_Interval"));
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            tmSendmail = new Timer();
            tmSendmail.Interval = Sendmail_Interval;
            tmSendmail.Elapsed += new ElapsedEventHandler(tmSendmail_Tick);            
            tmSendmail.Start();

            WriteToFile("Start Servicer at : " + DateTime.Now.ToLongTimeString

        protected override void OnStop()
        {
            WriteToFile("Stop Servicer at : " + DateTime.Now.ToLongTimeString());
            tmSendmail.Enabled = false;
        }

        void tmSendmail_Tick(object sender, EventArgs e)
        {
            if (EmailConfig.bIsAutomail)
            {
                sendmail();

            }
            //this.Hide();
            //throw new NotImplementedException();
        }
        void sendmail()
        {
            try
            {
                string strMsgLog = string.Empty;
                string strMsg = string.Empty;
                string strMa_Cbnv, strTen_Cbnv, strEmail, strSubject;
                DataTable dtBirthDayEmployee;

                string strHost = EmailConfig.strHost;
                string strCredentials = EmailConfig.strCredentials;
                string strPassclient = EmailConfig.strPassclient;
                string strFrom = EmailConfig.strFrom;
                string strCC = EmailConfig.strCC;
                string strContentEmail = EmailConfig.strContentEmail;



                #region Format mail

                string strBodyMail = EmailConfig.strEmailBobyBirthDay;

                #endregion
                //Xem kết quả
                Hashtable ht = new Hashtable();
                ht["LANGUAGE_TYPE"] = (char)Element.sysLanguage;
                ht["MA_DVCS"] = Element.sysMa_DvCs;
                ht["STT"] = 1;
                dtBirthDayEmployee = SQLExec.ExecuteReturnDt("sp_ViewReminder", ht, CommandType.StoredProcedure);



                foreach (DataRow drP in dtBirthDayEmployee.Rows)
                {
                    if ((Boolean)drP["Sent_Mail"])
                        continue;

                    strMa_Cbnv = drP["Ma_Cbnv"].ToString();
                    strTen_Cbnv = drP["Ten_Cbnv"].ToString();
                    strEmail = drP["Email"].ToString();
                    //if (strEmail == string.Empty)
                    //    continue;
                    int Numrd = new Random().Next(0, 3);
                    EmailConfig.EMAIL_CONTENT = "EMAIL_CONTENT" + Numrd.ToString();
                    EmailConfig.SendMailBirthday(strBodyMail, drP);

                    System.Threading.Thread.Sleep(20000);
                    strMsgLog += "\n" + strMa_Cbnv + "---" + strTen_Cbnv + "(" + drP["Ngay_Sinh_Text"].ToString() + ")" + "\n";
                    // Lưu lại thông tin gửi mail
                    //EmailConfig.SaveInfoSendMail(strMa_Cbnv, (DateTime)drP["Ngay_Sinh"]);

                }

                WriteToFile(DateTime.Now.ToLongTimeString());
                WriteToFile(strMsgLog);


            }
            catch (Exception ex)
            {
                WriteToFile(DateTime.Now.ToLongTimeString());
                WriteToFile(ex.ToString());
            }
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\MailLogs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\MailLogs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }  
    }
}
