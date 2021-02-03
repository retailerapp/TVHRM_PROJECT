using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;

namespace Epoint.Controllers
{
	public partial class frmReminder : Epoint.Systems.Customizes.frmView
	{
        DataTable dtBirthDayEmployee;
		DataTable dtReminder_HanThu;
		DataTable dtReminder_HanTra;
		DataTable dtReminder_TrangThaiCt;

        BindingSource bdsBirthDayEmployee = new BindingSource();
		BindingSource bdsReminder_HanThu = new BindingSource();
		BindingSource bdsReminder_HanTra = new BindingSource();
		BindingSource bdsReminder_TrangThaiCt = new BindingSource();

		bool bChange_Reminder = false;
		bool bChange_HanThu = false;
		bool bChange_HanTra = false;
		bool bChange_TrangThaiCt = false;

		int iStt = 1;

		DataRow drCurrent;

		public frmReminder()
		{
			InitializeComponent();

			tabReminder.SelectedIndexChanged += new EventHandler(tabReminder_SelectedIndexChanged);
			btRefresh.Click += new EventHandler(btRefresh_Click);
            btnSendMail.Click += new EventHandler(btnSendMail_Click);
			//btResetVoucher.Click += new EventHandler(btResetVoucher_Click);
			//btUpdateVoucher.Click += new EventHandler(btUpdateVoucher_Click);

			lvReminder.DoubleClick += new EventHandler(lvReminder_DoubleClick);
		}

		public void Load(int iStt)
		{
			this.iStt = iStt;

           
			bChange_Reminder = true;
			bChange_HanThu = true;
			bChange_HanTra = true;
			bChange_TrangThaiCt = true;

			this.Build();
			this.FillData();
			BindingLanguage();
			this.Show();
		}

		void Build()
		{
			dgvReminder_HanThu.strZone = "REMINDER_HANTT";
			dgvReminder_HanThu.BuildGridView();

			dgvReminder_HanTra.strZone = "REMINDER_HANTT";
			dgvReminder_HanTra.BuildGridView();

			dgvReminder_TrangThaiCt.strZone = "REMINDER_TRANGTHAICT";
			dgvReminder_TrangThaiCt.BuildGridView();


            dgvBirthDay.strZone = "NHANVIEN";
            dgvBirthDay.BuildGridView();

			if (@iStt == 1)
                tabReminder.SelectedTab = tabBirthDay;
			else if (@iStt == 2)
				tabReminder.SelectedTab = tabReminder_HanTra;
			else
				tabReminder.SelectedTab = tabReminder_TrangThaiCt;
		}

		private void FillData()
		{
			if (bChange_Reminder)
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				DataTable dtReminder = SQLExec.ExecuteReturnDt("sp_GetReminder", htPara, CommandType.StoredProcedure);

				int i = 0;

				if (dtReminder != null)
				{
					foreach (DataRow dr in dtReminder.Rows)
					{
                        if (!Common.CheckPermission(dr["Reminder_ID"].ToString(), enuPermission_Type.Allow_Access))
                        {
                            continue;
                        }
						if (this.lvReminder.Items.Count <= i)
						{
							ListViewItem lvi = new ListViewItem((string)dr["Description"]);
							lvi.Name = dr["Stt"].ToString();

							this.lvReminder.Items.Add(lvi);
						}
						else
							this.lvReminder.Items[i].Text = (string)dr["Description"];

						i++;
					}
				}

				bChange_Reminder = false;
			}

			//Xem kết quả
			Hashtable ht = new Hashtable();
			ht["LANGUAGE_TYPE"] = (char)Element.sysLanguage;
			ht["MA_DVCS"] = Element.sysMa_DvCs;

			//Chung tu den han thu
			if (tabReminder.SelectedTab == tabBirthDay)
			{
				ht["STT"] = 1;
				dtBirthDayEmployee = SQLExec.ExecuteReturnDt("sp_ViewReminder", ht, CommandType.StoredProcedure);

                bdsBirthDayEmployee.DataSource = dtBirthDayEmployee;
                dgvBirthDay.DataSource = bdsBirthDayEmployee;

				bChange_HanThu = false;

                ExportControl = dgvBirthDay;
                bdsSearch = bdsBirthDayEmployee;
			}

			//Chung tu den han tra
			if (bChange_HanTra && tabReminder.SelectedTab == tabReminder_HanTra)
			{
				ht["STT"] = 2;
                ht["MEMBER_ID"] = Element.sysUser_Id;
				dtReminder_HanTra = SQLExec.ExecuteReturnDt("sp_ViewReminder", ht, CommandType.StoredProcedure);

				bdsReminder_HanTra.DataSource = dtReminder_HanTra;
				dgvReminder_HanTra.DataSource = bdsReminder_HanTra;

				bChange_HanTra = false;

				ExportControl = dgvReminder_HanTra;
				bdsSearch = bdsReminder_HanTra;
			}

			//Chung tu chua duyet
            //if (bChange_TrangThaiCt && tabReminder.SelectedTab == tabReminder_TrangThaiCt)
            //{
            //    ht["STT"] = 3;
            //    dtReminder_TrangThaiCt = SQLExec.ExecuteReturnDt("sp_ViewReminder", ht, CommandType.StoredProcedure);

            //    bdsReminder_TrangThaiCt.DataSource = dtReminder_TrangThaiCt;
            //    dgvReminder_TrangThaiCt.DataSource = bdsReminder_TrangThaiCt;

            //    bChange_TrangThaiCt = false;

            //    ExportControl = dgvReminder_TrangThaiCt;
            //    bdsSearch = bdsReminder_TrangThaiCt;
            //}		
	


//            EmailConfig.EmailBobyBirthDay =  @"<table style='width: 800px;'>
//                                                <tbody>
//                                                <tr style='height: 67px;'>
//                                                <td style='width: 10px; height: 67px;'>&nbsp;</td>
//                                                <td style='width: 548px; height: 67px;'>
//                                                <p><span style='color: #0000ff;'><strong>Ch&uacute;c mừng sinh nhật</strong> :<span style='color: #ff0000;'><strong> @Ten_Cbnv</strong></span> !&nbsp; (@Ngay_Sinh) </span></p>
//                                                <p><span style='color: #0000ff;'>Vị tr&iacute;: <strong>@Ten_Vitri</strong>, Chi Nh&aacute;nh: <strong>@Ten_Kv</strong></span></p>
//                                                <p><span style='color: #0000ff;'><em>@ContentEmail</em></span></p>
//                                                </td>
//                                                </tr>
//                                                <tr style='height: 181px;'>
//                                                <td style='width: 10px; height: 181px;'>&nbsp;</td>
//                                                <td style='width: 548px; height: 181px;'><img src='cid:@ContentID' alt='' width='499' height='312' /></td>
//                                                </tr>
//                                                </tbody>
//                                                </table>
//                                ";
            
        

        //EmailConfig.strHost = Parameters.GetParaValue("HOSTMAIL").ToString();//"smtp.gmail.com";
        //EmailConfig.strCredentials = Parameters.GetParaValue("MAILSERVER").ToString();//"vanhungsmile@gmail.com";
        //EmailConfig.strPassclient = Parameters.GetParaValue("PASS_EMAIL").ToString();//"";// tự đặt
        //EmailConfig.strFrom = Parameters.GetParaValue("MAILSERVER").ToString(); //"vanhungsmile@gmail.com";
        //EmailConfig.strCC = Parameters.GetParaValue("EMAIL_CC").ToString(); //"vanhungsmile@gmail.com";
        //EmailConfig.strContentEmail = Parameters.GetParaValue("EMAIL_CONTENT").ToString();
        //EmailConfig.iTimeSend = Convert.ToInt32(Parameters.GetParaValue("EMAIL_TIMESEND"));
        //EmailConfig.bIsAutomail = Convert.ToBoolean(Parameters.GetParaValue("ISAUTOMAIL"));
		}

		public void Edit()
		{
			BindingSource bdsCurrent;
			DataTable dtCurrent;

			if (tabReminder.SelectedTab == tabReminder_HanThu)
			{
				bdsCurrent = bdsReminder_HanThu;
				dtCurrent = dtReminder_HanThu;
			}
			else if (tabReminder.SelectedTab == tabReminder_HanTra)
			{
				bdsCurrent = bdsReminder_HanTra;
				dtCurrent = dtReminder_HanTra;
			}
			else
			{
				bdsCurrent = bdsReminder_TrangThaiCt;
				dtCurrent = dtReminder_TrangThaiCt;
			}
					
			if (bdsCurrent.Position < 0)
				return;
			
			if (!dtCurrent.Columns.Contains("Stt") || !dtCurrent.Columns.Contains("Ma_Ct"))
				return;

			DataRow drCurrent = ((DataRowView)bdsCurrent.Current).Row;

			if (((string)drCurrent["Stt"]).Trim() == string.Empty || ((string)drCurrent["Ma_Ct"]).Trim() == string.Empty)
				return;

			DataRow drDmCt = DataTool.SQLGetDataRowByID("SYSDMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);

			string strMethodName = (string)drDmCt["Edit_Voucher_Method"];

			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				EpointMessage.MsgCancel("Định dạng MethodName = " + strMethodName + " không đúng");
				return;
			}

			string strAssembly = string.Empty;
			string strType = string.Empty;

			strAssembly = arrStr[0];
			strType = "Epoint." + arrStr[1];

			Assembly asl = Assembly.Load(strAssembly);
			Type type = asl.GetType(strType);

			Form frm = (Form)Activator.CreateInstance(type);

			object[] objPara = new object[] { enuEdit.Edit, drCurrent, null };

			type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, objPara);
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			bChange_Reminder = true;
			bChange_HanThu = true;
			bChange_HanTra = true;
			bChange_TrangThaiCt = true;

			this.FillData();
		}

        //void btResetVoucher_Click(object sender, EventArgs e)
        //{
        //    if (SQLExec.Execute("UPDATE SYSQueue SET Failure_Count = 0 WHERE Failure_Count > 0"))
        //    {
        //        bChange_TrangThaiCt = true;

        //        this.FillData();
        //    }
        //}

        //void btUpdateVoucher_Click(object sender, EventArgs e)
        //{
        //    string strExec = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Sp_Exec), '') FROM SYSQueue WHERE Failure_Count <=3 AND Stt IN (SELECT Stt FROM R80Ph WHERE Duyet = 1)");

        //    if (strExec != "")
        //    {
        //        Common.ShowStatus(Languages.GetLanguage("IN_PROCESS"));
        //        if (SQLExec.Execute("EXEC " + strExec))
        //        {
        //            bChange_TrangThaiCt = true;
        //            this.FillData();
        //        }
        //        Common.EndShowStatus();
        //    }
        //}

		void tabReminder_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.FillData();

			if (tabReminder.SelectedTab == tabReminder_HanThu)
			{
				ExportControl = dgvReminder_HanThu;
				bdsSearch = bdsReminder_HanThu;
			}
			else if (tabReminder.SelectedTab == tabReminder_HanTra)
			{
				ExportControl = dgvReminder_HanTra;
				bdsSearch = bdsReminder_HanTra;
			}
			else if (tabReminder.SelectedTab == tabReminder_TrangThaiCt)
			{
				ExportControl = dgvReminder_TrangThaiCt;
				bdsSearch = bdsReminder_TrangThaiCt;
			}
		}

		void lvReminder_DoubleClick(object sender, EventArgs e)
		{
			//tabReminder.SelectedIndex = iCurrent;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (e.KeyCode == Keys.F12)
			{
				this.Edit();
			}
		}



        #region email
        void btnSendMail_Click(object sender, EventArgs e)
        {
            EpointProcessBox.Show(this);
        }
        public string SendMail(SmtpClient client, string strFrom,string strFromDescr, string strTo, string strCC ,string strSubject, string strBody,string strImagePath)
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
            if(strCC != string.Empty)
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
        private void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MailMessage mail = (MailMessage)e.UserState;
            string subject = mail.Subject;

            if (e.Cancelled)
            {
                //string cancelled = string.Format("[{0}] Send canceled.", subject);
                //MessageBox.Show(cancelled);
            }
            if (e.Error != null)
            {
                //string error = String.Format("[{0}] {1}", subject, e.Error.ToString());
                //MessageBox.Show(error);
            }
            else
            {
                //MessageBox.Show("Message sent.");
            }
            //mailSent = true;
        }
       
        public override void EpointRelease()
        {
            try
            {
                string strMsg = string.Empty;
                string strMa_Cbnv, strTen_Cbnv, strEmail, strSubject;


                //string strHost = EmailConfig.strHost;
                //string strCredentials = EmailConfig.strCredentials;
                //string strPassclient = EmailConfig.strPassclient;
                //string strFrom = EmailConfig.strFrom;
                //string strCC = EmailConfig.strCC;
                //string strContentEmail = EmailConfig.strContentEmail;


                
                #region Format mail

                 //string strBodyMail = EmailConfig.EmailBobyBirthDay();

                #endregion
              foreach (DataRow drP in dtBirthDayEmployee.Rows)
                {

                  int Numrd = new Random().Next(0, 3);

                  if ((Boolean)drP["Sent_Mail"])
                      continue;

                    strMa_Cbnv = drP["Ma_Cbnv"].ToString();
                    strTen_Cbnv = drP["Ten_Cbnv"].ToString();


                    EpointProcessBox.AddMessage("Đang gửi " + strMa_Cbnv + " - " + strTen_Cbnv);
                   
                    EmailConfig.EMAIL_CONTENT = "EMAIL_CONTENT" + Numrd.ToString();
                  //EmailConfig.strContentEmail = 
                    EmailConfig.SendMailBirthday(string.Empty,drP);
                    System.Threading.Thread.Sleep(20000);
                  // Lưu lại thông tin gửi mail
                    //EmailConfig.SaveInfoSendMail(strMa_Cbnv, (DateTime)drP["Ngay_Sinh"]);                    

                    EpointProcessBox.AddMessage(strMsg);
                }
                
                EpointProcessBox.AddMessage("Kết thúc ! ");
                EpointProcessBox.ShowOK(true);
            }
            catch (Exception ex)
            {
                EpointProcessBox.AddMessage(ex.ToString());
                EpointProcessBox.ShowOK(true);
            }
        }
        #endregion
    }
}
