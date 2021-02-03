using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Threading;

using Epoint.Systems;
using Epoint.Systems.Commons;
using Epoint.Systems.Controls;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
    public partial class frmTranferData : Epoint.Systems.Customizes.frmView
    {
        #region Declare
        DataTable dtTranferData;
        DataTable dtTranferDataStore;
        BindingSource bdsTranferData = new BindingSource();
        BindingSource bdsTranferDataStore = new BindingSource();

        DataRow drCurrent;

        Thread thread;
        #endregion

        #region Contructor
        public frmTranferData()
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            dgvTranferDataStore.CellClick += new DataGridViewCellEventHandler(dgvTranferDataStore_CellClick);
            chkShow_All.CheckedChanged += new EventHandler(chkShow_All_CheckedChanged);
            chkSendOnline.CheckedChanged += new EventHandler(chkSendOnline_CheckedChanged);

            btSendPath.Click += new EventHandler(btSendPath_Click);
            btUpLoadReceiveFile.Click += new EventHandler(btUpLoadReceiveFile_Click);

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        #endregion

        #region Phuong thuc
        public void Load()
        {
            this.Build();
            this.FillData();

            this.dteNgay_Send1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            this.dteNgay_Send2.Text = Library.DateToStr(Element.sysNgay_Ct2);

            this.BindingLanguage();
            this.Show();
        }

        void Build()
        {
            dgvSend.strZone = "TRANFER_SEND";
            dgvSend.BuildGridView();
            dgvSend.ResizeGridView();

            dgvTranferDataStore.strZone = "TRANFER_RECEIVE_STORE";
            dgvTranferDataStore.BuildGridView();
            dgvTranferDataStore.ResizeGridView();

            chkSendOnline.Checked = (Common.GetBufferValue("SendOnline") == "1");
            this.SetSendPath();
        }

        void FillData()
        {
            string strSQLExec =
                "SELECT *, " +
                        " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                    " FROM SYSTranferData ORDER BY Stt";

            dtTranferData = SQLExec.ExecuteReturnDt(strSQLExec);
            bdsTranferData.DataSource = dtTranferData;

            dgvTranferDataStore.DataSource = bdsTranferData;
            dgvSend.DataSource = bdsTranferData;

            dgvSend.ReadOnly = false;
            foreach (DataGridViewColumn dgvc in dgvSend.Columns)
            {
                if (dgvc.Name == "IS_SEND")
                    dgvc.ReadOnly = false;
                else
                    dgvc.ReadOnly = true;
            }

            string strSQLExecRe;

            if (Element.sysTong_Hop)
            {
                strSQLExecRe =
                    "SELECT *, " +
                            " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                        " FROM SYSTranferDataStore " +
                        " ORDER BY File_ID";
            }
            else
            {
                string strMa_DvCs_Allow_Receive = DataTool.SQLGetNameByCode("SYSDmDvCs", "Ma_DvCs", "Ma_DvCs_Allow_Receive", Element.sysMa_DvCs);

                strSQLExecRe =
                    "SELECT *, " +
                            " CAST(0 AS BIT) AS Is_Receive " + //--Is_Send: đã lưu trong CSDL
                        " FROM SYSTranferDataStore " +
                        " WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' OR (Ma_DvCs = '" + strMa_DvCs_Allow_Receive.Replace(",", "' OR Ma_DvCs = '") + "')" +
                        " ORDER BY File_ID";
            }

            dtTranferDataStore = SQLExec.ExecuteReturnDt(strSQLExecRe);
            bdsTranferDataStore.DataSource = dtTranferDataStore;
            dgvTranferDataStore.DataSource = bdsTranferDataStore;

            bdsTranferDataStore.Filter = chkShow_All.Checked ? "" : "Last_Receive_Log = ''";
        }

		void Send()
		{
            if (!System.IO.Directory.Exists(txtSendPath.Text.Trim()))
                return;

			if (dteNgay_Send1.Text.Replace(" ", "") == "//" || dteNgay_Send2.Text.Replace(" ", "") == "//")
				return;

            if (Library.StrToDate(dteNgay_Send1.Text) > Library.StrToDate(dteNgay_Send2.Text))
                return;

            Common.ShowStatus(Languages.GetLanguage("In_Process"));
            //EpointProcessBox.Show();
            //EpointProcessBox.SetStatus(Languages.GetLanguage("In_Process"));
            //EpointProcessBox.AddMessage(Languages.GetLanguage("In_Process"));

            string strFileName = FileNameValid;
            string strSourcePath = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\" + strFileName;
            string strTableList = string.Empty;

            if (!System.IO.Directory.Exists(strSourcePath))
            {
                System.IO.Directory.CreateDirectory(strSourcePath);
            }

            foreach (DataRow dr in dtTranferData.Rows)
            {
                if (!(bool)dr["Is_Send"])
                    continue;

                string strTable_Name = (string)dr["Table_Name"];
                string strTable_Name0 = DataTool.SQLGetNameByCode("SYSDmTable", "Table_Name", "Table_Name0", strTable_Name);
                string strData_Type = (string)dr["Data_Type"];
                string strFilter_Key = (string)dr["Filter_Key"];

                if (strTable_Name0 == string.Empty)
                {
                    EpointProcessBox.AddMessage("Không tồn tại bảng " + strTable_Name + " trong DmTable!");
                    //EpointMessage.MsgCancel("Không tồn tại bảng " + strTable_Name + " trong DmTable!");
                    continue;
                }

                string strSQLExec = "SELECT * FROM " + strTable_Name0;
                strTableList += "," + strTable_Name;

                //Điều kiện lọc cứng: Ngay_Ct, Ma_DvCs
                Hashtable htPara = new Hashtable();
                if (strData_Type == "1") //Chứng từ
                {
                    if (Common.InlistLike(strTable_Name0, "R06CTTS")) //Nếu là bảng CTTS
                        strSQLExec += " WHERE ((Ma_Dvcs = @Ma_Data) OR (Ma_Dvcs = @Ma_Data1))";
                    else
                        strSQLExec += " WHERE (Ngay_Ct BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) AND (Ma_DvCs = @Ma_DvCs)";
                    htPara.Add("NGAY_CT1", dteNgay_Send1.Text);
                    htPara.Add("NGAY_CT2", dteNgay_Send2.Text);
                    htPara.Add("MA_DVCS", Element.sysMa_DvCs);
                }
                else if (strData_Type == "2") //Danh mục
                {
                    if (Common.InlistLike(strTable_Name0, "R06CTTS")) //Nếu là bảng CTTS
                        strSQLExec += " WHERE ((Ma_Dvcs = @Ma_Data) OR (Ma_Dvcs = @Ma_Data1))";
                    else
                        strSQLExec += " WHERE ((Ma_Data = @Ma_Data) OR (Ma_Data = @Ma_Data1))";
                    htPara.Add("MA_DATA", Element.sysMa_Data);
                    htPara.Add("MA_DATA1", "*");
                }
                else if (strData_Type == "3") //hùng thêm Tài sản cố dịnh
                {
                    strSQLExec += " WHERE (Ngay_Ps BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) AND (Ma_DvCs = @Ma_DvCs)";
                    htPara.Add("NGAY_CT1", dteNgay_Send1.Text);
                    htPara.Add("NGAY_CT2", dteNgay_Send2.Text);
                    htPara.Add("MA_DVCS", Element.sysMa_DvCs);
                }
                else
                    strSQLExec += " WHERE (1 = 1)";

                //Điều kiện lọc mềm
                if (strFilter_Key != string.Empty)
                    strSQLExec += " AND (" + strFilter_Key + ")";

                DataTable dtSend = SQLExec.ExecuteReturnDt(strSQLExec, htPara, CommandType.Text);

                FileStream fs = new FileStream(strSourcePath + "\\" + strTable_Name + ".dat", FileMode.Create);
                new BinaryFormatter().Serialize(fs, dtSend);
                fs.Close();

            }

            //DataInfo
            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.LoadXml(
                "<?xml version='1.0' encoding='utf-8' ?>" +
                    "<DataInfo>" +
                        "<Member_ID>" + Element.sysUser_Id + "</Member_ID>" +
                        "<Ngay_Ct1>" + dteNgay_Send1.Text + "</Ngay_Ct1>" +
                        "<Ngay_Ct2>" + dteNgay_Send2.Text + "</Ngay_Ct2>" +
                        "<Ma_DvCs>" + Element.sysMa_DvCs + "</Ma_DvCs>" +
                        "<Ma_Data>" + Element.sysMa_Data + "</Ma_Data>" +
                        "<TableList>" + strTableList + "</TableList>" +
                    "</DataInfo>");

            xml.Save(strSourcePath + "\\info.xml");

            string strfilename;

            if (chkSendOnline.Checked) //Truyền thằng vào CSDL
            {
                Common.ZipFile(strSourcePath, Environment.GetFolderPath(Environment.SpecialFolder.Templates));
                System.IO.Directory.Delete(strSourcePath, true);
                strfilename = strSourcePath + ".ros";
            }
            else
            {
                Common.ZipFile(strSourcePath, txtSendPath.Text);
                System.IO.Directory.Delete(strSourcePath, true);
                strfilename = strSourcePath + ".ros";
            }

            if (chkSendOnline.Checked && File.Exists(strfilename)) //Truyền thẳng vào CSDL
            {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = this.GetTranferConnection(false);
                sqlcom.Parameters.Clear();

                FileInfo fileInfo = new FileInfo(strfilename);
                if (fileInfo.Length < 2147483647) //2147483647 - is the max size of the data 1.9gb 
                {
                    byte[] _fileData = File.ReadAllBytes(strfilename);

                    sqlcom.Parameters.AddWithValue("FILE_ID", strFileName);
                    sqlcom.Parameters.AddWithValue("FILE_CONTENT", _fileData);
                    sqlcom.Parameters.AddWithValue("NGAY_CT1", Library.StrToDate(this.dteNgay_Send1.Text));
                    sqlcom.Parameters.AddWithValue("NGAY_CT2", Library.StrToDate(this.dteNgay_Send2.Text));
                    sqlcom.Parameters.AddWithValue("MA_DVCS", Element.sysMa_DvCs);
                    sqlcom.Parameters.AddWithValue("MA_DATA", Element.sysMa_Data);
                    sqlcom.Parameters.AddWithValue("MEMBER_ID", Element.sysUser_Id);
                    sqlcom.Parameters.AddWithValue("TABLELIST", strTableList);

                    string strsql = @"INSERT INTO SYSTranferDataStore (File_ID, File_Content, Ngay_Ct1, Ngay_Ct2, Ma_DvCs, Ma_Data, Member_ID, TableList) 
								VALUES (@File_Id, @File_Content, @Ngay_Ct1, @Ngay_Ct2, @Ma_DvCs, @Ma_Data, @Member_ID, @TableList)";

                    sqlcom.CommandText = strsql;

                    try
                    {
                        sqlcom.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //EpointProcessBox.AddMessage("Không truyền đc dữ liệu, error: " + ex.Message);
                        EpointMessage.MsgCancel("Không truyền đc dữ liệu, error: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    //EpointProcessBox.AddMessage("Dung lượng file quá lớn");
                    EpointMessage.MsgOk("Dung lượng file quá lớn");
                }
            }

            Common.SetBufferValue("SendOnline", chkSendOnline.Checked ? "1" : "0");
            Element.sysNgay_Ct1 = Library.StrToDate(this.dteNgay_Send1.Text);
            Element.sysNgay_Ct2 = Library.StrToDate(this.dteNgay_Send2.Text);

            //EpointMessage.MsgOk(Languages.GetLanguage("End_Process"));
            //EpointProcessBox.AddMessage(Languages.GetLanguage("End_Process"));
            //EpointProcessBox.ShowOK(true);
			Common.EndShowStatus();
		}

        void Receive()
        {
            if (dtTranferDataStore.Rows.Count == 0)
                return;

            foreach (DataRow dr in dtTranferDataStore.Rows)
            {
                if (!(bool)dr["Is_Receive"])
                    continue;

                string strFile_ID = (string)dr["File_Id"];
                string strOutputPath = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
                string strOutPutFile = strOutputPath + "\\" + strFile_ID + ".ros";
                DateTime dteNgay_Receive1 = (DateTime)dr["Ngay_Ct1"];
                DateTime dteNgay_Receive2 = (DateTime)dr["Ngay_Ct2"];
                string strMa_Dvcs = (string)dr["Ma_Dvcs"];
                byte[] _dataFile = (byte[])dr["File_Content"];
                if (!System.IO.Directory.Exists(strOutputPath))
                {
                    System.IO.Directory.CreateDirectory(strOutputPath);
                }

                //if (dteNgay_Receive1.Text.Replace(" ", "") == "//" || dteNgay_Receive2.Text.Replace(" ", "") == "//")
                //    return;

                if (dteNgay_Receive1 > dteNgay_Receive2)
                    continue;

                if (strMa_Dvcs == string.Empty)
                    continue;

                if (!Common.CheckDataLocked(dteNgay_Receive1) || !Common.CheckDataLocked(dteNgay_Receive2))
                {
                    EpointMessage.MsgCancel("Data locked");
                    continue;
                }

                if (!EpointMessage.MsgYes_No("Bạn có chắc chắn nhận dữ liệu của [" + strMa_Dvcs + "] từ ngày [" + Library.DateToStr(dteNgay_Receive1) + "] đến ngày [" + Library.DateToStr(dteNgay_Receive2) + "] do [" + (string)dr["Member_ID"] + "] truyền không?"))
                    continue;

                File.WriteAllBytes(strOutPutFile, _dataFile);

                if (this.Receive(strOutPutFile, dteNgay_Receive1, dteNgay_Receive2, strMa_Dvcs))
                    SQLExec.Execute("UPDATE SYSTranferDataStore SET Last_Receive_Log = '" + Common.GetCurrent_Log() + "' WHERE File_ID = '" + strFile_ID + "'");
            }

            FillData();
        }

		bool Receive(string strOutPutFile, DateTime dteNgay_Receive1, DateTime dteNgay_Receive2, string strMa_Dvcs)
		{
			DataRow drDmDvCs = DataTool.SQLGetDataRowByID("SYSDmDvCs", "Ma_DvCs", Element.sysMa_DvCs);
			if (drDmDvCs != null && drDmDvCs.Table.Columns.Contains("Ma_DvCs_Allow_Receive"))
			{
				if (!((string)drDmDvCs["Ma_DvCs_Allow_Receive"]).Contains(strMa_Dvcs))
				{
					EpointMessage.MsgCancel(Element.sysMa_DvCs + " không được phép nhận dữ liệu từ " + strMa_Dvcs);
					return false;
				}
			}

			if (!System.IO.File.Exists(strOutPutFile))
				return false;

			Common.ShowStatus(Languages.GetLanguage("In_Process"));

			string[] sTemp = strOutPutFile.Split('\\');
			string sFileName = sTemp[sTemp.Length - 1].ToString().Replace(".ros", "");
			string strOutPath = strOutPutFile.Replace(".ros", "");
			string strSQLExec = string.Empty;

			Common.UnZipFile(strOutPutFile, strOutPath);

			// Tao table Import PH
			DataTable dtImportPH = null;
			if (File.Exists(strOutPath + "\\PH.dat"))
			{
				FileStream fsPH = new FileStream(strOutPath + "\\PH.dat", FileMode.Open);
				BinaryFormatter formatter = new BinaryFormatter();
				dtImportPH = (DataTable)formatter.Deserialize(fsPH);
				fsPH.Close();
			}
			//else return;

			lock (Element.frmActiveMain)
			{
				foreach (DataRow dr in dtTranferData.Rows)
				{
					//if (!(bool)dr["Is_Receive"]) //Danh sách Table nhận: kết hợp Tên file trong gói dữ liệu dtTranferDataStore và tồn tại trong dtTranferData
					//    continue;

					if (dr["Table_Name"].ToString().Trim() == "PH")
						continue;

					string strTable_Name = (string)dr["Table_Name"];
					string strTable_Name0 = DataTool.SQLGetNameByCode("SYSDmTable", "Table_Name", "Table_Name0", strTable_Name);
					string strTable_Delete = (string)dr["Table_Delete"];
					string[] strArrUnique_Key = ((string)dr["Unique_Key"]).Replace(" ", "").Split(',');
					string strData_Type = (string)dr["Data_Type"];
					string strFilter_Key = (string)dr["Filter_Key"];
					string strKey = string.Empty;

					if (strTable_Name0 == string.Empty)
					{
						EpointMessage.MsgCancel("Không tồn tại bảng " + strTable_Name + " trong DmTable!");
						continue;
					}

					if (File.Exists(strOutPath + "\\" + strTable_Name + ".dat"))
					{
						DataTable dtImport = null;
						DataRow drImportPH = null;
						string strSttImportOk = string.Empty;

						FileStream fs = new FileStream(strOutPath + "\\" + strTable_Name + ".dat", FileMode.Open);
						BinaryFormatter formatter = new BinaryFormatter();
						dtImport = (DataTable)formatter.Deserialize(fs);
						fs.Close();

						if (strData_Type == "1") //Chứng từ
						{
							if (!dtImport.Columns.Contains("Ngay_Ct") || !dtImport.Columns.Contains("Ma_DvCs") || !dtImport.Columns.Contains("Stt"))
							{
								EpointMessage.MsgCancel("Không import được " + strTable_Name0 + " do không tồn tại trường Ngay_Ct, DvCs, Stt");
								continue;
							}

							if (dtImportPH == null)
							{
								EpointMessage.MsgCancel("Không import được " + strTable_Name0 + " do không truyền bảng PH");
								continue;
							}

							//string strSQLExec = string.Empty;
							string strKeyDelete = string.Empty;

							strKeyDelete =
								"SELECT Stt FROM GLVOUCHER " +
									" WHERE Ngay_Ct BETWEEN '" + dteNgay_Receive1.ToShortDateString() + "' AND '" + dteNgay_Receive2.ToShortDateString() +
									"' AND Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Stt LIKE '" + strMa_Dvcs + "%'";

							if (strFilter_Key != string.Empty)
								strKeyDelete += " AND (" + strFilter_Key + ")";

							//Không xóa những chứng từ đã Locked
							if ((int)SQLExec.ExecuteReturnValue("SELECT CASE WHEN COL_LENGTH('GLVOUCHER', 'Locked') IS NULL THEN 0 ELSE 1 END") == 1)
								strKeyDelete += " AND (Locked = 0)";

							strSQLExec = string.Empty;
							//DataTable dtTableUpdate80 = SQLExec.ExecuteReturnDt("SELECT Table_Name FROM SYSTableUpdate WHERE Used = 1");
							//foreach (DataRow dr80 in dtTableUpdate80.Rows)
							//{
							//    strSQLExec += "DELETE FROM " + (string)dr80["Table_Name"] + " WHERE Stt IN (" + strKeyDelete + ") ";
							//}
							strSQLExec +=
								"DELETE FROM " + strTable_Name0 + " WHERE Stt IN (" + strKeyDelete + ") " +
								"DELETE FROM GLVOUCHER WHERE Stt IN (" + strKeyDelete + ") ";

							if (SQLExec.Execute(strSQLExec))
							{
								for (int i = 0; i < dtImport.Rows.Count; i++)
								{
									DataRow dr1 = dtImport.Rows[i];
									dr1["Ma_DvCs"] = Element.sysMa_DvCs; // gán lại Ma_DvCs cho thằng Import vào
									dr1["Ngay_Ct"] = ((DateTime)dr1["Ngay_Ct"]).ToShortDateString();

									if ((DateTime)dr1["Ngay_Ct"] < dteNgay_Receive1
										|| (DateTime)dr1["Ngay_Ct"] > dteNgay_Receive2
										//|| (string)dr1["Ma_DvCs"] != txtMa_DvCs.Text
												|| !((string)dr1["Stt"]).StartsWith(strMa_Dvcs))
										continue;

									string strStt = (string)dr1["Stt"];
									bool bReceivePHOk = false;

									Common.ShowStatus(Languages.GetLanguage("In_Process", Element.sysLanguage) + strStt);

									//Chỉ truyền số liệu khi tồn tại Stt trong bảng GLVOUCHER
									if (dtImportPH.Select("Stt = '" + strStt + "'").Length == 1)
									{
										if ((int)SQLExec.ExecuteReturnValue("SELECT CASE WHEN COL_LENGTH('GLVOUCHER', 'Locked') IS NULL THEN 0 ELSE 1 END") == 1)
										{
											if ((int)SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM GLVOUCHER WHERE Stt = '" + strStt + "' AND Locked = 1") == 1)
											{
												Common.ShowStatus(strStt + "... Locked");
												continue;
											}
										}

										drImportPH = dtImportPH.Select("Stt = '" + strStt + "'")[0];
										drImportPH["Ma_DvCs"] = Element.sysMa_DvCs;
										drImportPH["Ngay_Ct"] = ((DateTime)drImportPH["Ngay_Ct"]).ToShortDateString();

										if (!strSttImportOk.Contains(strStt + ","))
										{
											if (DataTool.SQLUpdate(enuEdit.New, "GLVOUCHER", ref drImportPH))
											{
												strSttImportOk += strStt + ",";
												bReceivePHOk = true;
											}
										}
										else
											bReceivePHOk = true;

										if (bReceivePHOk)
										{
											DataTool.SQLUpdate(enuEdit.New, strTable_Name0, ref dr1);
											//SQLExec.Execute(" EXEC sp_Ct_Update80 '" + drImportPH["Stt"].ToString() + "', '" + drImportPH["Ma_Ct"].ToString() + "' ");
										}
										else
										{
											EpointMessage.MsgCancel("Không thể nhận được chứng từ {Mã Ct: " + (string)drImportPH["Ma_Ct"] + "}, {Ngày ct: " + Library.DateToStr((DateTime)drImportPH["Ngay_Ct"]) + "}, {Số ct: " + (string)drImportPH["So_Ct"] + "}");
											continue;
										}
									}
								}
							}
						}
						else if (strData_Type == "2") //Danh mục
						{
							#region Danh muc
							//Tạo tham số
							Hashtable htPara = new Hashtable();
							for (int i = 0; i < strArrUnique_Key.Length; i++)
							{
								if (dtImport.Columns.Contains(strArrUnique_Key[i]))
								{
									htPara.Add(strArrUnique_Key[i], DBNull.Value);

									if (strKey != string.Empty)
										strKey += " AND ";

									strKey += " (" + strArrUnique_Key[i] + " = @" + strArrUnique_Key[i] + ") ";
								}
							}

							if (strKey == string.Empty)
							{
								EpointMessage.MsgCancel("Không import được " + strTable_Name0 + " do không tạo được Key");
								continue;
							}

							for (int i = 0; i < dtImport.Rows.Count; i++)
							{
								DataRow dr1 = dtImport.Rows[i];

								//Xóa key
								strSQLExec = "DELETE FROM " + strTable_Name0 + " WHERE " + strKey;

								//Tạo giá trị cho Parameter
								for (int j = 0; j < strArrUnique_Key.Length; j++)
								{
									if (htPara.ContainsKey(strArrUnique_Key[j]))
										htPara[strArrUnique_Key[j]] = dr1[strArrUnique_Key[j]];
								}

								if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
									DataTool.SQLUpdate(enuEdit.New, strTable_Name0, ref dr1);
							}
							#endregion
						}
						else if (strData_Type == "3") //HUNGNV thêm Tài sản cố định
						{
							if (!dtImport.Columns.Contains("Ngay_Ps") || !dtImport.Columns.Contains("Ma_DvCs") || !dtImport.Columns.Contains("Stt"))
							{
								EpointMessage.MsgCancel("Không import được " + strTable_Name0 + " do không tồn tại trường Ngay_Ps, DvCs, Stt");
								continue;
							}
							if (strTable_Name0 != "ASTSNG")
								strSQLExec = "DELETE FROM " + strTable_Name0 + " WHERE Ngay_Ps BETWEEN '" + dteNgay_Receive1.ToShortDateString() + "' AND '" + dteNgay_Receive2.ToShortDateString() +
										"' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";
							else
								strSQLExec = "DELETE FROM " + strTable_Name0 + " WHERE 0 =1 ";
							if (SQLExec.Execute(strSQLExec))
							{
								for (int i = 0; i < dtImport.Rows.Count; i++)
								{
									DataRow dr1 = dtImport.Rows[i];
									dr1["Ma_DvCs"] = Element.sysMa_DvCs; // gán lại Ma_DvCs cho thằng Import vào
									dr1["Ngay_ps"] = ((DateTime)dr1["Ngay_Ps"]).ToShortDateString();

									if ((DateTime)dr1["Ngay_Ps"] < dteNgay_Receive1
										|| (DateTime)dr1["Ngay_Ps"] > dteNgay_Receive2
										//|| (string)dr1["Ma_DvCs"] != txtMa_DvCs.Text
												|| !((string)dr1["Stt"]).StartsWith(strMa_Dvcs))
										continue;
									string strStt = (string)dr1["Stt"];
									DataTable dtCTTSNgia = DataTool.SQLGetDataTable("ASTSNG", "Stt", "", "Stt");
									if (strTable_Name0 != "ASTSNG")
									{
										//Chỉ truyền số liệu khi tồn tại Stt trong bảng Nguyen gia
										if (dtCTTSNgia.Select("Stt = '" + strStt + "'").Length == 1)
											DataTool.SQLUpdate(enuEdit.New, strTable_Name0, ref dr1);
										//else
										//{
										//    Common.ShowStatus(strStt + "... không có nguyên giá");
										//    continue;
										//}
									}
									else
									{
										if (dtCTTSNgia.Select("Stt = '" + strStt + "'").Length == 1)
											continue;
										else
											DataTool.SQLUpdate(enuEdit.New, strTable_Name0, ref dr1);
									}
								}
							}
						}
					}
				}
			}

			if (Directory.Exists(strOutPath))
				Directory.Delete(strOutPath, true);

			//Common.SetBufferValue("ReceiveFilePath", System.IO.Path.GetFullPath(txtReceiveFilePath.Text));

			EpointMessage.MsgOk(Languages.GetLanguage("End_Process"));
			Common.EndShowStatus();

			return true;
		}

        void Receive_Delete()
        {

        }

        void SetSendPath()
        {
            if (chkSendOnline.Checked) //Lấy Server, Database hiện hành
            {
                txtSendPath.Text = "[" + TranferOnlineServerName + "].[" + TranferOnlineServerDatabaseName + "]";
            }
            else
            {
                txtSendPath.Text = Common.GetBufferValue("SendFilePath");
            }
        }

        #endregion

        string FileNameValid
        {
            get
            {
                string strFileName =
                        Element.sysMa_DvCs + "_" +
                        DateTime.Now.Year + "_" +
                        DateTime.Now.Month.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Hour.ToString().PadLeft(2, '0') + "h_" +
                        DateTime.Now.Minute.ToString().PadLeft(2, '0') + "m_" +
                        DateTime.Now.Second.ToString().PadLeft(2, '0') + "s";

                return strFileName;
            }
        }

        string TranferOnlineServerName
        {
            get
            {
                string strTranferOnlineDatabase = (string)Parameters.GetParaValue("TRANFERONLINEDB");
                string strTranferOnlineServerName;

                //[Server].[Database]
                if (strTranferOnlineDatabase.Contains("].[") && strTranferOnlineDatabase.StartsWith("[") && strTranferOnlineDatabase.EndsWith("]"))
                {
                    strTranferOnlineServerName = strTranferOnlineDatabase.Split(new string[] { "].[" }, StringSplitOptions.None)[0];
                    strTranferOnlineServerName = strTranferOnlineServerName.Substring(1);
                }
                else
                    strTranferOnlineServerName = SQLExec.ExecuteReturnValue("SELECT @@SERVERNAME").ToString();

                return strTranferOnlineServerName;
            }
        }

        string TranferOnlineServerDatabaseName
        {
            get
            {
                string strTranferOnlineDatabase = (string)Parameters.GetParaValue("TRANFERONLINEDB");
                string strTranferOnlineDatabaseName;

                //[Server].[Database]
                if (strTranferOnlineDatabase.Contains("].[") && strTranferOnlineDatabase.StartsWith("[") && strTranferOnlineDatabase.EndsWith("]"))
                {
                    strTranferOnlineDatabaseName = strTranferOnlineDatabase.Split(new string[] { "].[" }, StringSplitOptions.None)[1];
                    strTranferOnlineDatabaseName = strTranferOnlineDatabaseName.Substring(0, strTranferOnlineDatabaseName.Length - 1);
                }
                else
                    strTranferOnlineDatabaseName = SQLExec.ExecuteReturnValue("SELECT db_name()").ToString();

                return strTranferOnlineDatabaseName;
            }
        }

		SqlConnection GetTranferConnection(bool bConnectDialog)
		{
			SqlConnection sqlconn = new SqlConnection();

			while (sqlconn.State == ConnectionState.Closed)
			{
				//Mở cửa sổ kết nối
				if (bConnectDialog)
				{
					frmSQLConnect frmConnect = new frmSQLConnect();
					frmConnect.txtServerName.Text = this.txtSendPath.Text;
					frmConnect.Load();

					if (!frmConnect.isAccept)
						break;
				}

				string strUser = Common.GetBufferValue("TRANFER_USER");
				string strPassword = Common.GetBufferValue("TRANFER_PASSWORD");
				bool bAuthentication = (Common.GetBufferValue("TRANFER_AUTHENTICATION") == "1");
				string strConnectString = "";

				if (bAuthentication)
					strConnectString = "Data Source=" + this.TranferOnlineServerName + ";Initial Catalog=" + this.TranferOnlineServerDatabaseName + ";Integrated Security=True";
				else
					strConnectString = "Data Source=" + this.TranferOnlineServerName + ";Initial Catalog=" + this.TranferOnlineServerDatabaseName + ";User Id=" + strUser + ";Password=" + strPassword + "";

				sqlconn.ConnectionString = strConnectString;

				try
				{
					sqlconn.Open();
				}
				catch (Exception)
				{
					bConnectDialog = true;
				}
			}
			return sqlconn;
		}

        #region Event
        public override void Edit(enuEdit enuNew_Edit)
        {
            if (tabControl1.SelectedTab != tabPage1)
                return;

            if (bdsTranferData.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsTranferData.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTranferData.Current).Row, ref drCurrent);
            else
                drCurrent = dtTranferData.NewRow();

            frmTranferData_Edit frmEdit = new frmTranferData_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            //Accept
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTranferData.Position >= 0)
                        dtTranferData.ImportRow(drCurrent);
                    else
                        dtTranferData.Rows.Add(drCurrent);

                    //bdsTranferData.Position = bdsTranferData.Find("IDENT00", drCurrent["IDENT00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTranferData.Current).Row);

                dtTranferData.AcceptChanges();
            }
            else
                dtTranferData.RejectChanges();
        }

        public override void Delete()
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                if (bdsTranferData.Position < 0)
                    return;

                DataRow drCurrent = ((DataRowView)bdsTranferData.Current).Row;

                if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("SYSTranferData", drCurrent))
                {
                    bdsTranferData.RemoveAt(bdsTranferData.Position);
                    dtTranferData.AcceptChanges();
                }
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                if (bdsTranferDataStore.Position < 0)
                    return;

                DataRow drCurrent = ((DataRowView)bdsTranferDataStore.Current).Row;

                if (!EpointMessage.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("SYSTranferDataStore", drCurrent))
                {
                    bdsTranferDataStore.RemoveAt(bdsTranferDataStore.Position);
                    dtTranferDataStore.AcceptChanges();
                }
            }
        }

        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == tabPage2)
            //{
            //    foreach (DataRow dr in dtTranferData.Rows)
            //    {
            //        dr["Chon"] = false;
            //    }
            //}

            //bdsTranferData.Filter = "Receive = true";
        }

        void dgvTranferDataStore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            drCurrent = ((DataRowView)bdsTranferDataStore.Current).Row;

            if (dgvTranferDataStore.CurrentCell.OwningColumn.Name == "IS_RECEIVE")
            {
                drCurrent["Is_Receive"] = !(bool)drCurrent["Is_Receive"];
            }
        }

        void chkShow_All_CheckedChanged(object sender, EventArgs e)
        {
            bdsTranferDataStore.Filter = chkShow_All.Checked ? "" : "Last_Receive_Log = ''";
        }

        void chkSendOnline_CheckedChanged(object sender, EventArgs e)
        {
            this.SetSendPath();

            //btSendPath.Enabled = txtSendPath.Enabled = !chkSendOnline.Checked;
        }

        void btSendPath_Click(object sender, EventArgs e)
        {
			if (chkSendOnline.Checked)
			{
				this.GetTranferConnection(true);
			}
			else
			{
				FolderBrowserDialog fbd = new FolderBrowserDialog();
				fbd.RootFolder = Environment.SpecialFolder.Desktop;
				fbd.Description = "Send path";

				if (fbd.ShowDialog() == DialogResult.OK)
				{
					txtSendPath.Text = fbd.SelectedPath;
					Common.SetBufferValue("SendFilePath", txtSendPath.Text);
				}
			}
        }

        void btUpLoadReceiveFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (Common.GetBufferValue("ReceiveFilePath") != string.Empty)
                ofd.InitialDirectory = Common.GetBufferValue("ReceiveFilePath");
            else
                ofd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();

            ofd.Filter = "ros file (*.ros)|*.ros";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                {
                    MemoryStream ms = Common.UnZipOneFile(ofd.FileName, "Info.xml");

                    if (ms != null)
                    {
                        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                        doc.Load(ms);

                        FileInfo fileInfo = new FileInfo(ofd.FileName);
                        if (fileInfo.Length < 2147483647) //2147483647 - is the max size of the data 1.9gb 
                        {
                            byte[] _fileData = File.ReadAllBytes(ofd.FileName);

                            Hashtable htPara = new Hashtable();
                            htPara["FILE_ID"] = ofd.SafeFileName.Replace(".ros", "");
                            htPara["FILE_CONTENT"] = _fileData;
                            htPara["NGAY_CT1"] = Library.StrToDate(doc.DocumentElement["Ngay_Ct1"].InnerText);
                            htPara["NGAY_CT2"] = Library.StrToDate(doc.DocumentElement["Ngay_Ct2"].InnerText);
                            htPara["MA_DVCS"] = doc.DocumentElement["Ma_DvCs"].InnerText;
                            htPara["MA_DATA"] = doc.DocumentElement["Ma_Data"].InnerText;
                            htPara["MEMBER_ID"] = doc.DocumentElement["Member_ID"].InnerText;
                            htPara["TABLELIST"] = doc.DocumentElement["TableList"].InnerText;

                            string strSQLExec = @"INSERT INTO SYSTranferDataStore(File_ID, File_Content, Ngay_Ct1, Ngay_Ct2, Ma_DvCs, Ma_Data, Member_ID, TableList) 
									VALUES (@File_Id, @File_Content, @Ngay_Ct1, @Ngay_Ct2, @Ma_DvCs, @Ma_Data, @Member_ID, @TableList)";

                            if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                            {
                                DataRow drNew = dtTranferDataStore.NewRow();
								Common.SetDefaultDataRow(ref drNew);

                                drNew["File_ID"] = htPara["FILE_ID"];
                                drNew["File_Content"] = htPara["FILE_CONTENT"];
                                drNew["Ngay_Ct1"] = htPara["NGAY_CT1"];
                                drNew["Ngay_Ct2"] = htPara["NGAY_CT2"];
                                drNew["Ma_DvCs"] = htPara["MA_DVCS"];
                                drNew["Ma_Data"] = htPara["MA_DATA"];
                                drNew["Member_ID"] = htPara["MEMBER_ID"];
                                drNew["TableList"] = htPara["TableList"];
                                dtTranferDataStore.Rows.Add(drNew);
                                drNew.AcceptChanges();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Dung lượng file quá lớn");
                        }
                    }
                }
            }

            return;
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                this.Send();
            }
            else
                this.Receive();
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
    }
}
