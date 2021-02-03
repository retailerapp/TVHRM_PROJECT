using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    
namespace Epoint.Controllers
{
    public class EmailConfig
    {

        //private static string _strEmailBobyBirthDay;
        //private static string _strHost;
        //private static string _strCredentials;
        //private static string _strPassclient;
        //private static string _strFrom;
        //private static string _strCC;
        //private static string _strContentEmail;
        //private static int _iTimeSend;
        //private static bool _bIsAutomail;

        //public static string EmailBobyBirthDay { get { return _strEmailBobyBirthDay; } set { _strEmailBobyBirthDay = value; } }
        //public static string strHost { get { return _strHost; } set { _strHost = value; } }
        //public static string strCredentials { get { return _strCredentials; } set { _strCredentials = value; } }
        //public static string strPassclient { get { return _strPassclient; } set { _strPassclient = value; } }
        //public static string strFrom { get { return _strFrom; } set { _strFrom = value; } }
        //public static string strCC { get { return _strCC; } set { _strCC = value; } }
        //public static string strContentEmail { get { return _strContentEmail; } set { _strContentEmail = value; } }
        //public static int iTimeSend { get { return _iTimeSend; } set { _iTimeSend = value; } }
        //public static bool bIsAutomail { get { return _bIsAutomail; } set { _bIsAutomail = value; } }

       
        //Random rd = new Random();
        //static int Numrd = new Random().Next(0, 3);
        public static string EMAIL_CONTENT = string.Empty;
        public static string strEmailBobyBirthDay = @"<table style='width: 800px;'>
                                                <tbody>
                                                <tr style='height: 67px;'>
                                                <td style='width: 10px; height: 67px;'>&nbsp;</td>
                                                <td style='width: 548px; height: 67px;'>
                                                <p><span style='color: #0000ff;'><strong>Ch&uacute;c mừng sinh nhật</strong> :<span style='color: #ff0000;'><strong> @Ten_Cbnv</strong></span> !&nbsp; (@Ngay_Sinh) </span></p>
                                                <p><span style='color: #0000ff;'>Vị tr&iacute;: <strong>@Ten_Vitri</strong>, Chi Nh&aacute;nh: <strong>@Ten_Kv</strong></span></p>
                                                <p><span style='color: #0000ff;'><em>@ContentEmail</em></span></p>
                                                </td>
                                                </tr>
                                                <tr style='height: 181px;'>
                                                <td style='width: 10px; height: 181px;'>&nbsp;</td>
                                                <td style='width: 548px; height: 181px;'><img src='cid:@ContentID' alt='' width='499' height='312' /></td>
                                                </tr>
                                                </tbody>
                                                </table>
                                ";



        public static string strHost = Parameters.GetParaValue("HOSTMAIL").ToString();//"smtp.gmail.com";
        public static string strCredentials = Parameters.GetParaValue("MAILSERVER").ToString();//"vanhungsmile@gmail.com";
        public static string strPassclient = Parameters.GetParaValue("PASS_EMAIL").ToString();//"";// tự đặt
        public static string strFrom = Parameters.GetParaValue("MAILSERVER").ToString(); //"vanhungsmile@gmail.com";
        public static string strCC = Parameters.GetParaValue("EMAIL_CC").ToString(); //"vanhungsmile@gmail.com";
        public static string strContentEmail = Parameters.GetParaValue(EMAIL_CONTENT == string.Empty ? "EMAIL_CONTENT" : EMAIL_CONTENT).ToString();
        public static int iTimeSend = Convert.ToInt32(Parameters.GetParaValue("EMAIL_TIMESEND"));
        public static bool bIsAutomail = Parameters.GetParaValue("ISAUTOMAIL").ToString() == "1" ? true : false;

        public static DataTable getBirthDayEmployee()
        {
            Hashtable ht = new Hashtable();
            ht["LANGUAGE_TYPE"] = (char)Element.sysLanguage;
            ht["MA_DVCS"] = Element.sysMa_DvCs;
            ht["STT"] = 1;
            return SQLExec.ExecuteReturnDt("sp_ViewReminder", ht, CommandType.StoredProcedure);
        }
        public static void SaveInfoSendMail(string strMa_Cbnv,DateTime dteNgay_Sinh)
        {
            try
            {
                // Lưu lại thông tin gửi mail
            Hashtable htupdate = new Hashtable();
            htupdate["MA_CBNV"] = strMa_Cbnv;
            htupdate["NAM"] = DateTime.Now.Year;
            htupdate["MA_DVCS"] = Element.sysMa_DvCs;
            htupdate["NGAY_SINH"] = dteNgay_Sinh;
            SQLExec.ExecuteNotMessage("sp_SYS_EMPLOYEE_BD", htupdate, CommandType.StoredProcedure);
            }
            catch { }
            
        }
        public static string SendMail(SmtpClient client, string strFrom, string strFromDescr, string strTo, string strCC, string strSubject, string strBody, string strImagePath)
        {
            string strMeg = string.Empty;
            //Builed The MSG
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            LinkedResource inline = new LinkedResource(strImagePath, MediaTypeNames.Image.Jpeg);
            inline.ContentId = Guid.NewGuid().ToString();



            Attachment att = new Attachment(strImagePath);
            att.ContentDisposition.Inline = true;

            strBody = strBody.Replace("@ContentID", inline.ContentId);
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString(strBody, null, MediaTypeNames.Text.Html);
            avHtml.LinkedResources.Add(inline);
            msg.AlternateViews.Add(avHtml);
            //msg.To.Add("reciver@gmail.com");
            msg.To.Add(strTo);
            msg.From = new MailAddress(strFrom, strFromDescr, System.Text.Encoding.UTF8);
            if (strCC != string.Empty && strCC != strTo)
                msg.CC.Add(strCC);
            msg.Subject = strSubject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //msg.Body = strBody;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.Attachments.Add(att);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;


            //Add the Creddentials

            //client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
            object userState = msg;
            try
            {
                //you can also call client.Send(msg)
                client.SendAsync(msg, userState);
                //client.Send(msg);
                return "\nMessage sent " + strTo;

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return ex.Message + " \nSend Mail Error : " + strTo;
            }
            catch (Exception ex1)
            {
                return ex1.Message;
            }
        }
        public static void SendMailBirthday(string strMa_Cbnv, string strTen_Cbnv, string strEmail, string strBodyMail,DateTime dteNgay_Sinh)
        {
            
            if (strEmail == string.Empty)
                return;


            int Numrd;
            Random rd = new Random();
            string[] filePahts = Directory.GetFiles(Application.StartupPath + @"\Images\HPBD\", "*.jpg");

            Numrd = rd.Next(0, filePahts.Length - 1);

            string fileImage = filePahts[Numrd];

            string strBody;
            strContentEmail = Parameters.GetParaValue(EMAIL_CONTENT == string.Empty ? "EMAIL_CONTENT" : EMAIL_CONTENT).ToString();

            strBody = strBodyMail.Replace("@Ma_Cbnv", strMa_Cbnv);
            strBody = strBody.Replace("@Ten_Cbnv", strTen_Cbnv);
            strBody = strBody.Replace("@Ma_Bp", "");
            strBody = strBody.Replace("@Ma_ViTri", "");
            strBody = strBody.Replace("@Ten_Kv", "");
            strBody = strBody.Replace("@Ngay_Sinh", Library.DateToStr(dteNgay_Sinh));
            strBody = strBody.Replace("@ContentEmail", strContentEmail);


            string strTo = strEmail;
            //Add the Creddentials
            SmtpClient client = new SmtpClient();
            if (strHost.Contains("gmail"))
            {
                client.Port = 587;//or use 587  
                client.EnableSsl = true;
            }
            else
            {
                client.Port = 25;
            }


            client.Host = strHost;            //
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(strCredentials, strPassclient);

            string strSubject = "[Non-Working]Chúc mừng sinh nhật!";
            string strMsg = SendMail(client, strFrom, "PhongNhanSu", strTo, strCC, strSubject, strBody, fileImage);

            // Lưu lại thông tin gửi mail
            EmailConfig.SaveInfoSendMail(strMa_Cbnv, dteNgay_Sinh);  
        }
        public static void SendMailBirthday(string strBodyMail,DataRow drNhanvien)
        {
            strBodyMail = strEmailBobyBirthDay;
            string strMa_Cbnv = drNhanvien["Ma_Cbnv"].ToString();
            string strTen_Cbnv = drNhanvien["Ten_Cbnv"].ToString();
            string strEmail = drNhanvien["Email"].ToString();

            //strCC = "hungnv@tuanviet-trading.com";

            if (strEmail == string.Empty && strCC != string.Empty)
            {
                strEmail = strCC;
            }
           

            if (strEmail == string.Empty)
            { return; }

            int Numrd;
            Random rd = new Random();
            string[] filePahts = Directory.GetFiles(Application.StartupPath + @"\Images\HPBD\", "*.jpg");

            Numrd = rd.Next(0, filePahts.Length - 1);

            string fileImage = filePahts[Numrd];

            string strBody;
            strContentEmail = Parameters.GetParaValue(EMAIL_CONTENT == string.Empty ? "EMAIL_CONTENT" : EMAIL_CONTENT).ToString();

            strBody = strBodyMail.Replace("@Ma_Cbnv", strMa_Cbnv);
            strBody = strBody.Replace("@Ten_Cbnv", strTen_Cbnv);
            strBody = strBody.Replace("@Ma_Bp", drNhanvien["Ma_Bp"].ToString());
            strBody = strBody.Replace("@Ten_Vitri", drNhanvien["Ten_Vitri"].ToString());
            strBody = strBody.Replace("@Ten_Kv", drNhanvien["Ten_Kv"].ToString());
            strBody = strBody.Replace("@Ngay_Sinh", drNhanvien["Ngay_Sinh_Text"].ToString());
            strBody = strBody.Replace("@ContentEmail", strContentEmail);


            string strTo = strEmail;
            //Add the Creddentials
            SmtpClient client = new SmtpClient();
            if (strHost.Contains("gmail"))
            {
                client.Port = 587;//or use 587  
                client.EnableSsl = true;
            }
            else
            {
                client.Port = 25;
            }


            client.Host = strHost;            //
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(strCredentials, strPassclient);

            string strSubject = "[Tuấn Việt]Chúc mừng sinh nhật!";
            string strMsg = SendMail(client, strFrom, "[Phòng Nhân Sự]", strTo, strCC, strSubject, strBody, fileImage);

            // Lưu lại thông tin gửi mail
            EmailConfig.SaveInfoSendMail(strMa_Cbnv, (DateTime)drNhanvien["Ngay_Sinh"]);
        }
    }
}
