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
    public partial class frmKPISalary : Epoint.Systems.Customizes.frmView
    {
        DataSet dsSalary = new DataSet();
        private DataTable dtKPISalary; 
        private DataTable dtRatio;
        private DataTable dtDmTn;
        private DataTable dtImport;

        private BindingSource bdsKPISalary = new BindingSource(); 
        private BindingSource bdsRatio = new BindingSource();
        private DataRow drCurrent;
        private dgvControl dgvKPISalary = new dgvControl();
        private dgvControl dgvKPIRatio = new dgvControl();

        private string OptionProcess = string.Empty;
        private string strFileName = string.Empty;

        public frmKPISalary()
        {
            InitializeComponent();

           
            cboKPI.TextChanged += new EventHandler(cboKPI_TextChanged);
            btImport.Click += new EventHandler(btImport_Click);     

            dgvKPISalary.CellValidated += new DataGridViewCellEventHandler(dgvBangLuong_CellValidated);

            radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);

            this.KeyDown += new KeyEventHandler(frmBangLuong_KeyDown);
        }

        void btnSendMail_Click(object sender, EventArgs e)
        {          
            EpointProcessBox.Show(this);
        }

        void btImport_Click(object sender, EventArgs e)
        {
            OptionProcess = "IMPORT";

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
                    DataSet dsImport = Common.ReadExcelToDataSet(strFileName);
                    DataTable dtResult = SQLExec.ExecuteReturnDt("DECLARE @KPICAMPAIGN AS TVP_KPICAMPAIGN SELECT * FROM @KPICAMPAIGN");
                    DataTable dtRatio = SQLExec.ExecuteReturnDt("DECLARE @KPICAMPAIGN AS TVP_KPICAMPAIGN SELECT * FROM @KPICAMPAIGN");
                    foreach (DataTable table in dsImport.Tables)
                    {
                        if(table.Columns.Contains("Ma_Cbnv") && table.Columns.Contains("Segment")) // Import ket qua KPI
                        {                          

                            foreach (DataColumn cl in table.Columns)
                            {
                                string sColumnName = cl.ColumnName;
                                if (this.CheckItemId(sColumnName))// Nếu là chỉ tiêu KPI
                                {
                                    foreach (DataRow row in table.Rows)
                                    {
                                        DataRow drResult = dtResult.NewRow();
                                        drResult["KPIID"] = row["Month"];
                                        drResult["ObjectID"] = row["Ma_CbNv"];
                                        drResult["Type"] = row["Segment"];
                                        drResult["ItemID"] = sColumnName;

                                        double amt = 0;
                                        double.TryParse(row[sColumnName].ToString().Replace("%", ""), out amt);
                                        drResult["Amt"] = amt;

                                        dtResult.Rows.Add(drResult);
                                    }
                                }
                            } 
                        }
                        else if(table.Columns.Contains("Segment"))// Import Trong So KPI
                        {
                            foreach (DataColumn cl in table.Columns)
                            {
                                string sColumnName = cl.ColumnName;
                                if (this.CheckItemId(sColumnName))// Nếu là chỉ tiêu KPI
                                {
                                    foreach (DataRow row in table.Rows)
                                    {
                                        DataRow drRatio = dtRatio.NewRow();
                                        drRatio["KPIID"] = row["Month"];
                                        drRatio["ObjectID"] = row["Segment"];
                                        drRatio["ItemID"] = sColumnName;
                                        double amt = 0;
                                        double.TryParse(row[sColumnName].ToString().Replace("%", ""), out amt);
                                        drRatio["Amt"] = amt;
                                        dtRatio.Rows.Add(drRatio);
                                    }
                                }
                            }
                        }

                    }
                                                         
                    bool Is_Avail = true;
                    if (true)
                    {
                        SqlCommand command = SQLExec.GetNewSQLConnection().CreateCommand();
                        command.CommandText = "Sp_IF_KPIResult";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", Element.sysUser_Id);
                        command.Parameters.AddWithValue("@Is_OverWrite", Is_Avail);
                        SqlParameter parameter = new SqlParameter
                        {
                            SqlDbType = SqlDbType.Structured,
                            ParameterName = "@KPICAMPAIGN",
                            TypeName = "TVP_KPICAMPAIGN",
                            Value = dtResult
                        };
                        command.Parameters.Add(parameter);
                        SqlParameter parameter1 = new SqlParameter
                        {
                            SqlDbType = SqlDbType.Structured,
                            ParameterName = "@KPIRATIO",
                            TypeName = "TVP_KPICAMPAIGN",
                            Value = dtRatio
                        };
                       
                        command.Parameters.Add(parameter1);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception exception)
                        {
                            Is_Avail = false;
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

            ////Gắn Ma_Bp vào ComboBox
            DataTable dtKPIMaster = SQLExec.ExecuteReturnDt("SELECT KPIID,Descr FROM KPIMaster ORDER BY EndDate DESC");
            //dtDmBp.Rows.Add(new string[] { "*", "Tất cả" });

            cboKPI.lstItem.BuildListView("KPIID:100,Descr:250");
            cboKPI.lstItem.DataSource = dtKPIMaster;
            cboKPI.lstItem.Size = new Size(320, cboKPI.lstItem.Items.Count * 50);
            cboKPI.lstItem.GridLines = true;
            if (dtKPIMaster.Rows.Count > 0)
            {
                //cboKPI.SelectedIndex = cboKPI.Items.Count - 1;
                cboKPI.Text = dtKPIMaster.Rows[0][0].ToString();
            }


            this.Build();
            this.FillData();

            this.ShowBangLuong();
           
            this.Show();
        }
                
        #region Methods
        
        private void Build()
        {
            //Build            
            dgvKPISalary.Dock = DockStyle.Fill;
            dgvKPISalary.AutoGenerateColumns = true;
            this.panel1.Controls.Add(dgvKPISalary);

            dgvKPIRatio.Dock = DockStyle.Fill;
            dgvKPIRatio.AutoGenerateColumns = true;
            this.panel3.Controls.Add(dgvKPIRatio);

        }

        private void FillData()
        {

            //Lấy nội dung bảng lương
            Hashtable htPara = new Hashtable();
            htPara.Add("KPIID", cboKPI.Text);
            htPara.Add("USERID", Element.sysUser_Id);
            dsSalary = SQLExec.ExecuteReturnDs("KPI_KPIResult_GetById", htPara, CommandType.StoredProcedure);
            dtRatio = SQLExec.ExecuteReturnDt("KPI_Ratio_GetById", htPara, CommandType.StoredProcedure);
            
            if(radioButton1.Checked)
            {
                dtKPISalary = dsSalary.Tables[0];
            }
            else if (radioButton2.Checked)
            {
                dtKPISalary = dsSalary.Tables[0];
            }
            else if(radioButton2.Checked)
            {
                dtKPISalary = dsSalary.Tables[1];
            }

            bdsKPISalary.DataSource = dtKPISalary;
            dgvKPISalary.DataSource = bdsKPISalary;
            this.ExportControl = dgvKPISalary;
            bdsSearch = bdsKPISalary;
            bdsRatio.DataSource = dtRatio;
            dgvKPIRatio.DataSource = bdsRatio;


        }

        private void ShowBangLuong()
        {
            dgvKPISalary.ReadOnly = false;

            if (dsSalary == null || dsSalary.Tables.Count == 0)
                return;


            for (int i = 0; i < dgvKPISalary.Columns.Count; i++)
            {
                string strColumnName = dgvKPISalary.Columns[i].Name;              
                if (true)
                {
                    //if (radioButton1.Checked)
                    //{
                    //    //dgvKPISalary.Columns[strColumnName].Visible = true;
                    //}
                    //else if (radioButton2.Checked)
                    //{
                    //    //dgvKPISalary.Columns[strColumnName].Visible = true;
                    //}
                    //else
                    //{
                    //    //dgvKPISalary.Columns[strColumnName].Visible = true;
                    //}
                    if (radioButton1.Checked)
                    {
                        dtKPISalary = dsSalary.Tables[0];
                    }
                    else if (radioButton2.Checked)
                    {
                        dtKPISalary = dsSalary.Tables[0];
                    }
                    else if (radioButton2.Checked)
                    {
                        dtKPISalary = dsSalary.Tables[1];
                    }

                    bdsKPISalary.DataSource = dtKPISalary;
                    dgvKPISalary.DataSource = bdsKPISalary;
                    this.ExportControl = dgvKPISalary;
                    dgvKPISalary.Columns[i].ReadOnly = true;
                }
                else
                {
                    dgvKPISalary.Columns[i].ReadOnly = true;
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
            if (bdsKPISalary.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            if (enuNew_Edit == enuEdit.New)
                return;

            if (bdsKPISalary.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsKPISalary.Current).Row, ref drCurrent);
            else
                drCurrent = dtKPISalary.NewRow();

           
            //Accept
            if (true)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsKPISalary.Position >= 0)
                        dtKPISalary.ImportRow(drCurrent);
                    else
                        dtKPISalary.Rows.Add(drCurrent);

                    bdsKPISalary.Position = bdsKPISalary.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsKPISalary.Current).Row);
                }

                dtKPISalary.AcceptChanges();
            }
        }

        public override void Delete()           
        {
            
        } 
        private bool CheckItemId(string ItemId)
        {
            object obj = SQLExec.ExecuteReturnValue("EXEC KPI_CheckItemId '" + ItemId + "'");
            bool isItem = obj != null ? (int)(obj) > 0 ? true : false : false;
            return isItem;
        }

        #endregion

        #region Event

        void btCalcSalary_Click(object sender, EventArgs e)
        {
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

        void cboKPI_TextChanged(object sender, EventArgs e)
        {
            if (cboKPI.lviItem != null)
                lbtKPIDescr.Text = cboKPI.lviItem.SubItems["Descr"].Text;

            if (cboKPI.Text == string.Empty)
                return;

            this.FillData();
        }
        void cboMa_Kv_TextChanged(object sender, EventArgs e)
        {           
            this.FillData();
        }
        void dgvBangLuong_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsKPISalary.Current).Row;
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
