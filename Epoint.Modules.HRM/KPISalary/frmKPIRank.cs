using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Commons;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;
using Epoint.Lists;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Epoint.Modules.KPI
{
    public partial class frmKPIRank : Epoint.Systems.Customizes.frmView
    {
        private DataTable dtKPIRank;
        private DataTable dtDmTn;
        private DataTable dtImport;

        private BindingSource bdsKPIRank = new BindingSource();
        private DataRow drCurrent;
        private dgvControl dgvKPIRank = new dgvControl();

        private string OptionProcess = string.Empty;
        private string strFileName = string.Empty;

        public frmKPIRank()
        {
            InitializeComponent();

           
            cboApplyFor.TextChanged += new EventHandler(cboMa_Bp_TextChanged);
            //btCreateSalary.Click += new EventHandler(btCreateSalary_Click);
            //btCalcSalary.Click += new EventHandler(btCalcSalary_Click);
            //btDeleteSalary.Click += new EventHandler(btDeleteSalary_Click);
            //btPostedSalary.Click += new EventHandler(btPostedSalary_Click);
            btImport.Click += new EventHandler(btImport_Click);
            btnSendMail.Click += new EventHandler(btnSendMail_Click);           

            dgvKPIRank.CellValidated += new DataGridViewCellEventHandler(dgvBangLuong_CellValidated);

            this.KeyDown += new KeyEventHandler(frmBangLuong_KeyDown);
        }

        void btnSendMail_Click(object sender, EventArgs e)
        {
            OptionProcess = "EMAIL";
            EpointProcessBox.Show(this);
        }

        void btImport_Click(object sender, EventArgs e)
        {
            OptionProcess = "KPIRANK";
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xls files (*.xls;*.xlsx)|*.xls;*.xlsx";
            ofd.RestoreDirectory = true;

            if (Common.GetBufferValue("ImportExcelPathHRM") != string.Empty)
                ofd.InitialDirectory = Common.GetBufferValue("ImportExcelPathHRM");
            else
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Common.SetBufferValue("ImportExcelPathHRM", System.IO.Path.GetDirectoryName(ofd.FileName));
                    strFileName = ofd.FileName;
                }
                catch { }


                try
                {
                    DataTable dtStruct = new DataTable();
                    dtStruct = SQLExec.ExecuteReturnDt("DECLARE @TVP_Table AS TVP_HRSALARYRANK SELECT * FROM @TVP_Table");
                    
                    dtImport = Common.ReadExcel(strFileName);     
                    foreach(DataRow dr in dtImport.Rows)
                    {
                        DataRow drStruct = dtStruct.NewRow();
                        Common.CopyDataRow(dr, drStruct);
                        dtStruct.Rows.Add(drStruct);
                    }

                    if (dtStruct != null)
                    {
                        SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                        command.CommandText = "Sp_IF_HRSALARYRANK";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TableName", "HRSalaryRank");
                        command.Parameters.AddWithValue("@UserId", Element.sysUser_Id);
                        SqlParameter parameter = new SqlParameter
                        {
                            SqlDbType = SqlDbType.Structured,
                            ParameterName = "@TVP_Table",
                            TypeName = "TVP_HRSALARYRANK",
                            Value = dtStruct
                        };
                        command.Parameters.Add(parameter);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception exception)
                        {
                            command.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                            command.CommandType = CommandType.Text;
                            command.Parameters.Clear();
                            command.ExecuteNonQuery();
                            EpointProcessBox.AddMessage("Có lỗi xảy ra :" + exception.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không mở được bảng dữ liệu " + strFileName + "Error :" + ex.Message);
                }
            }
        }

        public override void Load()
        {

            //DataTable dtThang = SQLExec.ExecuteReturnDt("SELECT 0 Thang UNION SELECT DISTINCT MONTH(Ngay_Ct) AS Thang FROM HRSALARY WHERE YEAR(Ngay_Ct) = " + Element.sysWorkingYear.ToString());

            ////Gắn Ma_Bp vào ComboBox
            DataTable dtDmBp = SQLExec.ExecuteReturnDt("SP_HRM_GetDataCombobox 'KIPRANK_APPLYFOR'");
            //dtDmBp.Rows.Add(new string[] { "*", "Tất cả" });

            cboApplyFor.lstItem.BuildListView("Code:100,Label:250");
            cboApplyFor.lstItem.DataSource = dtDmBp;
            cboApplyFor.lstItem.Size = new Size(320, cboApplyFor.lstItem.Items.Count * 30);
            cboApplyFor.lstItem.GridLines = true;

            ////Gắn Ma_Bp vào ComboBox
            //DataTable dtKv = SQLExec.ExecuteReturnDt("SELECT '*' Ma_Kv, N'Tất cả' Ten_Kv UNION SELECT Ma_Kv, Ten_Kv FROM LIKHUVUC ORDER BY Ma_Kv");
            ////dtDmBp.Rows.Add(new string[] { "*", "Tất cả" });

            ////cboMa_Kv.lstItem.BuildListView("Ma_Kv:100,Ten_Kv:250");
            ////cboMa_Kv.lstItem.DataSource = dtKv;
            ////cboMa_Kv.lstItem.Size = new Size(320, cboMa_Kv.lstItem.Items.Count * 30);
            ////cboMa_Kv.lstItem.GridLines = true;

            this.Build();
            this.FillData();

            this.ShowBangLuong();
           
            this.Show();
        }
                
        #region Methods
        
        private void Build()
        {
            //Build
            dgvKPIRank.strZone = "KPIRANK";
            dgvKPIRank.Dock = DockStyle.Fill;
            dgvKPIRank.BuildGridView();
            //dgvKPIRank.Columns["ItemID"].Frozen = true;
            //dgvKPIRank.Columns["Description"].Frozen = true;
            //dgvKPIRank.Columns["ApplyFor"].Frozen = true;
            this.panel1.Controls.Add(dgvKPIRank);
        }

        private void FillData()
        {
            //Lấy cấu trúc các cột
            //Lấy nội dung bảng lương
            //Hashtable htPara = new Hashtable();
            //htPara.Add("NAM", Element.sysWorkingYear);
            //htPara.Add("MA_BP", cboMa_Bp.Text);
            //htPara.Add("LANGUAGE_TYPE", Element.sysLanguage);
            //htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtKPIRank = SQLExec.ExecuteReturnDt("Sp_HRM_GETSALARYRANK", CommandType.StoredProcedure);

            bdsKPIRank.DataSource = dtKPIRank;
            dgvKPIRank.DataSource = bdsKPIRank;
            this.ExportControl = dgvKPIRank;
            bdsSearch = bdsKPIRank;
        }

        private void ShowBangLuong()
        {
            //1-THANHTOAN
            //2-THUNHAP
            //3-TRULUONG

            dgvKPIRank.ReadOnly = false;

            for (int i = 0; i < dgvKPIRank.Columns.Count; i++)
            {
                string strColumnName = dgvKPIRank.Columns[i].Name;              
                if (true)
                {
                    
                }
                else
                {
                    dgvKPIRank.Columns[i].ReadOnly = true;
                }
            }
        }

        private void CalSalary()
        {            
            this.FillData();
        }
        private void DeleteSalary()
        {
            
        }
        private void LoadingSalary()
        {
            this.FillData();
        }
        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsKPIRank.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            if (enuNew_Edit == enuEdit.New)
                return;

            if (bdsKPIRank.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsKPIRank.Current).Row, ref drCurrent);
            else
                drCurrent = dtKPIRank.NewRow();

           
            //Accept
            if (true)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsKPIRank.Position >= 0)
                        dtKPIRank.ImportRow(drCurrent);
                    else
                        dtKPIRank.Rows.Add(drCurrent);

                    bdsKPIRank.Position = bdsKPIRank.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsKPIRank.Current).Row);
                }

                dtKPIRank.AcceptChanges();
            }
        }

        public override void Delete()
        {
        }

        #endregion

        #region Event

        void btCalcSalary_Click(object sender, EventArgs e)
        {
            this.OptionProcess = "CALSALARY";
            EpointProcessBox.Show(this);
        }



        void btCreateSalary_Click(object sender, EventArgs e)
        {
           
        }

        void btDeleteSalary_Click(object sender, EventArgs e)
        {
          
        }

        void btPostedSalary_Click(object sender, EventArgs e)
        {
           
        }

        void frmBangLuong_KeyDown(object sender, KeyEventArgs e)
        {
        }

        void cboThang_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        void cboMa_Bp_TextChanged(object sender, EventArgs e)
        {
            if (cboApplyFor.lviItem != null)
                lbtTen_Bp.Text = cboApplyFor.lviItem.SubItems["Label"].Text;

            if (cboApplyFor.Text == string.Empty)
                return;

            this.FillData();
        }
        void cboMa_Kv_TextChanged(object sender, EventArgs e)
        {
           
            this.FillData();
        }
        void dgvBangLuong_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsKPIRank.Current).Row;
            DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (!dgvCell.IsInEditMode)
                return;

            if ((string)drCurrent["Ma_CbNv"] == string.Empty)
                return;

            if (dtDmTn.Select("Is_Input = true AND Ma_Tn = '" + strColumnName + "'").Length == 1)
            {
                //Hashtable htPara = new Hashtable();
                //htPara.Add("NAM", Element.sysWorkingYear);
                //htPara.Add("THANG", this.cboThang.SelectedValue);
                //htPara.Add("MA_CBNV", (string)drCurrent["Ma_CbNv"]);
                //htPara.Add("MA_DVCS", Element.sysMa_DvCs);
                //htPara.Add("MA_TN", strColumnName);
                //htPara.Add("TIEN", dgvCell.Value);

                //if (SQLExec.Execute("sp_HRM_SaveBangLuong", htPara, CommandType.StoredProcedure))
                //{
                //    drCurrent.AcceptChanges();
                //}
            }
        }

        void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowBangLuong();
        }

        #endregion


        #region email
        public string SendMail(SmtpClient client, string strFrom, string strFromDescr, string strTo, string strSubject, string strBody)
        {
            string strMeg = string.Empty;
            //Builed The MSG
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //msg.To.Add("reciver@gmail.com");
            msg.To.Add(strTo);
            //msg.From = new MailAddress("dummy@gmail.com", "One Ghost", System.Text.Encoding.UTF8);
            msg.From = new MailAddress(strFrom, strFromDescr, System.Text.Encoding.UTF8);
            msg.Subject = strSubject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = strBody;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            //Attachment att = new Attachment(@"D:\TVlogo.png");
            //msg.Attachments.Add(att);

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
        public void SaveFileText(string strFileName, string strText)
        {
            try
            {
                FileStream stream = new FileStream(strFileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                writer.WriteLine(strText);
                writer.Flush();
                writer.Close();
                stream.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "");
            }
        }
        public override void EpointRelease()
        {
            #region Import KPI

            if (OptionProcess == "KPIRANK")
            {
                try
                {                   
                    EpointProcessBox.AddMessage("Kết thúc import file " + strFileName);
                }
                catch (Exception ex)
                {
                    EpointProcessBox.AddMessage(ex.ToString());
                    EpointProcessBox.ShowOK(true);
                }
            }
            #endregion

            #region Send mail bang luong
            if (OptionProcess == "EMAIL")
            {

            }
            #endregion 
            
            #region Tính Lương
            if (OptionProcess == "CALSALARY")
            {
                try
                {
                    EpointProcessBox.setValue(50);
                    this.CalSalary();                     
                    EpointProcessBox.AddMessage("Kết thúc ! ");
                }
                catch (Exception ex)
                {
                    EpointProcessBox.AddMessage(ex.ToString());
                    EpointProcessBox.ShowOK(true);
                }

            }
            #endregion
            #region Loading Lương
            if (OptionProcess == "LOADING")
            {
                try
                {
                   
                }
                catch (Exception ex)
                {
                    EpointProcessBox.AddMessage(ex.ToString());
                    EpointProcessBox.ShowOK(true);
                }

            }
           #endregion
         #region Delete Lương
            if (OptionProcess == "DELETE")
            {
                try
                {
                    EpointProcessBox.setValue(30);
                    this.DeleteSalary();
                    //EpointProcessBox.CloseForm();
                    EpointProcessBox.AddMessage("Kết thúc ! ");
                }
                catch (Exception ex)
                {
                    EpointProcessBox.AddMessage(ex.ToString());
                    EpointProcessBox.ShowOK(true);
                }

            }
            #endregion
        }
        
        #endregion

    }
}
