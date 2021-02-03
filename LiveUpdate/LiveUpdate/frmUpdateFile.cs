using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems;
using Epoint.Controllers;


namespace AutoMail
{
    public partial class frmUpdateFile : Form
    {        
        object objFileContent;

        Timer tmSendmail = new Timer();
        private System.ComponentModel.IContainer component = null;

        public frmUpdateFile()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);
            tmSendmail.Tick += new EventHandler(tmSendmail_Tick);
            this.MinimumSizeChanged += new EventHandler(MinimumSizeChanged_Change);
            this.Resize += new EventHandler(Form_Resize);

            this.openToolStripMenuItem.Click += new EventHandler(openToolStripMenuItem_Click);
            this.exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);
            tmSendmail.Interval = 500000;
            tmSendmail.Start();
            
        }

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show(); //Hiển thị Form
            this.WindowState = FormWindowState.Normal; //Trở về trạng thái bình thường
            notifyIcon1.Visible = false;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) //Khi Form bị Minimize
            {
                notifyIcon1.Visible = true;//Xuất hiện Icon (hình tròn web) bên dưới Taskbar
                this.Hide(); //Ẩn Form               
            }
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

        new public void Load()
        {
            tmSendmail.Interval = EmailConfig.iTimeSend;
            tmSendmail.Start();
            
            //this.BindingLanguage();
            //this.Show();
            this.WindowState = FormWindowState.Minimized;
             notifyIcon1.Visible = true;//Xuất hiện Icon (hình tròn web) bên dưới Taskbar
             this.Hide(); //Ẩn Form     

            
        }

        void btOk_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;//Xuất hiện Icon (hình tròn web) bên dưới Taskbar
            this.Hide(); //Ẩn Form  
        }
        void MinimumSizeChanged_Change(object sender, EventArgs e)
        {

        }
        void UpdateVersion()
        {           

            return;
        }
        void btCancel_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;//Xuất hiện Icon (hình tròn web) bên dưới Taskbar
            this.Hide(); //Ẩn Form 
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (component != null))
            {
                component.Dispose();
            }
            base.Dispose(disposing);
        }
        void sendmail()
        {
            try
            {
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
                    // Lưu lại thông tin gửi mail
                    //EmailConfig.SaveInfoSendMail(strMa_Cbnv, (DateTime)drP["Ngay_Sinh"]);

                }


            }
            catch (Exception ex)
            {

            }
        }
    }
}
